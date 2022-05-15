namespace LeagueDrafter
{
    using RiotSharp;
    public partial class Form1 : Form
    {
        //Global
        public string key = "";
        //Init
        public Form1()
        {
            InitializeComponent();
        }
        //Window loaded
        private void Form1_Load(object sender, EventArgs e)
        {
            var x = GetKeyPath();
            try
            {
                key = File.ReadAllText(x + "key.devkey");
                System.Diagnostics.Debug.WriteLine("Devkey loaded.");
            }
            catch
            {
                MessageBox.Show("Devkey not detected!","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        //Query button
        private async void button1_Click(object sender, EventArgs e)
        {
            var api = RiotApi.GetInstance(key, 10, 50);
            try
            {
                progressBar1.Visible = true;
                var summoner = await api.Summoner.GetSummonerByNameAsync(RiotSharp.Misc.Region.Oce, textBox1.Text);
                progressBar1.Visible = false;
                System.Diagnostics.Debug.WriteLine(summoner.Level);
            }
            catch (RiotSharpException ex)
            {
                MessageBox.Show("Riot API Error!\n" + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Clean file path regardless of user
        private static string GetKeyPath ()
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