namespace LeagueDrafter
{
    using Newtonsoft.Json;
    using RiotSharp;
    using System.Threading.Tasks;
    public partial class Form1 : Form
    {
        //Global
        public string key = "";
        public string version = "";
        //Init
        public Form1()
        {
            InitializeComponent();
        }
        //Window loaded
        private void Form1_LoadAsync(object sender, EventArgs e)
        {
            Thread.Sleep(1000);
            var x = GetKeyPath();
            try
            {
                key = File.ReadAllText(x + "key.devkey");
                DebugInfo.AppendText("Devkey loaded.");
                RetrieveRiotData();
            }
            catch
            {
                MessageBox.Show("Devkey not detected!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
        //Setup static data
        private async void RetrieveRiotData()
        {
            try
            {
                version = await GetCurrentGameVersionAsync();
                DebugInfo.AppendText("\nStatic data loaded: " + version);
            }
            catch
            {
                MessageBox.Show("Data Dragon could not be reached!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Query button
        private async void button1_Click(object sender, EventArgs e)
        {
            var api = RiotApi.GetInstance(key, 10, 50);
            try
            {
                Query_Bar.Visible = true;
                var summoner = await api.Summoner.GetSummonerByNameAsync(RiotSharp.Misc.Region.Oce, Input_Name.Text);
                Query_Bar.Visible = false;
                System.Diagnostics.Debug.WriteLine("Summoner Loaded!");
                DisplayStats(summoner, api);
            }
            catch (RiotSharpException ex)
            {
                MessageBox.Show("Riot API Error!\n" + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Print results
        private async void DisplayStats(RiotSharp.Endpoints.SummonerEndpoint.Summoner summoner, RiotApi api)
        {
            string results = "";
            //Basic Info
            results += "Name: " + summoner.Name;
            results += "\nLevel: " + summoner.Level;
            results += "\nLast Updated: " + summoner.RevisionDate;
            //Top champs
            var master = await api.ChampionMastery.GetChampionMasteriesAsync(RiotSharp.Misc.Region.Oce, summoner.Id);
            results += "\nMost played: ";
            for (int i = 0; i < 10; i++)
            {
                results += "\n" + (i + 1) + ": " + await GetChampNameFromID(master[i].ChampionId.ToString());
            }

            //Output
            Query_Output.Text = results;
        }
        //DDragon Champ name from id
        private async Task<string> GetChampNameFromID(string id)
        {
            Champion champ;
            using var client = new HttpClient();
            string x = await client.GetStringAsync("https://ddragon.leagueoflegends.com/cdn/" + version + "/data/en_US/champion.json");

            var list = JsonConvert.DeserializeObject<ChampData>(x);

            foreach (var pair in list.Data)
            {
                if (pair.Value.key == id)
                {
                    return pair.Value.name.ToString();
                }
            }
            MessageBox.Show("Could not find champion data...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return "Unknown";
        }
        //DDragon Game Version
        private async Task<string> GetCurrentGameVersionAsync()
        {
            using var client = new HttpClient();
            string x = await client.GetStringAsync("https://ddragon.leagueoflegends.com/api/versions.json");
            x = x.Replace("[", "");
            x = x.Replace("]", "");
            x = x.Replace("\"", "");
            var y = x.Split(",");
            return y[0];
        }
        //Clean file path regardless of user
        private static string GetKeyPath()
        {
            var x = AppContext.BaseDirectory;
            x = FlipString(x);
            x = x.Remove(1, 28);
            x = FlipString(x);
            return x;
        }
        //Flip string
        private static string FlipString(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}