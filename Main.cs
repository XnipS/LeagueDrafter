namespace LeagueDrafter
{
    using Newtonsoft.Json;
    using RiotSharp;
    using System.Threading.Tasks;
    public partial class Main : Form
    {
        //Global
        public string key = "";
        public string version = "";
        public KeyInput form2 = null;
        //
        public void SubmitKey (string k)
        {
            form2.Hide();
            LoadKey(k);
            
        }
        //Init
        public Main()
        {
            InitializeComponent();
        }
        //Window loaded
        private void Form1_LoadAsync(object sender, EventArgs e)
        {
            form2 = new KeyInput();
            form2.main = this;

            Thread.Sleep(1000);
            var x = GetKeyPath();

            try
            {
               var key = File.ReadAllText(x + "key.devkey");
                
                LoadKey(key);
                    } catch {
                MessageBox.Show("Devkey not detected!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                form2.Show();
                this.Opacity = 0;
            }
           // DebugInfo.AppendText(x + "key.devkey");
        }
        private void LoadKey (string x)
        {   
            try
            {
                key = x;
                var api = RiotApi.GetInstance(key, 10, 50);
                DebugInfo.AppendText("Devkey loaded.");
                RetrieveRiotData();
                this.Opacity = 1;
            }
            catch
            {
                MessageBox.Show("Devkey not detected!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                form2.Show();
                this.Opacity = 0;
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
            string str = Input_Name.Text;
            str = str.Replace(System.Environment.NewLine, String.Empty);
            string[] sr = str.Split(" joined the lobby");
            Query_Bar.Visible = true;
            for (int i = 0; i < sr.Length; i++)
            {
                Query_Bar.Value = (100 / sr.Length) * i;
                try
                {
                   // MessageBox.Show("_" + sr[i] + "_");
                   if(sr[i] == "")
                    {
                        break;
                    }
                    var summoner = await api.Summoner.GetSummonerByNameAsync(RiotSharp.Misc.Region.Oce, sr[i]);
                    DebugInfo.AppendText("\nSummoner " + (i+1) + " Loaded!");
                    DisplayStats(summoner, api, i);
                }
                catch (RiotSharpException ex)
                {
                    MessageBox.Show("Riot API Error!\n" + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            Query_Bar.Visible = false;
        }
        //Print results
        private async void DisplayStats(RiotSharp.Endpoints.SummonerEndpoint.Summoner summoner, RiotApi api, int num)
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
            switch (num)
            {
                case (0):
                    Query_Output.Text = results;
                    break;
                case (1):
                    richTextBox1.Text = results;
                    break;
                case (2):
                    richTextBox2.Text = results;
                    break;
                case (3):
                    richTextBox3.Text = results;
                    break;
                case (4):
                    richTextBox4.Text = results;
                    break;
            }
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
            x = x.Remove(1, 25);
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