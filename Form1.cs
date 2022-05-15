namespace LeagueDrafter
{
    using HtmlAgilityPack;
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = true;
            var htmk = await GetHtml();
            ParseHtmlUsingHtmlAgilityPack(htmk);
            progressBar1.Visible = false;
            //System.Diagnostics.Debug.WriteLine("click");
        }

        private static Task<string> GetHtml()
        {
            var client = new HttpClient();
            return client.GetStringAsync("https://u.gg/lol/profile/oc1/xnips/overview");
        }

        private void ParseHtmlUsingHtmlAgilityPack(string html)
        {
            var text = "";
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);


            var level = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='level-header']").InnerText;
            text += level;

            this.richTextBox1.Text = text;

            // var name = htmlDoc.GetElementbyId("$0").InnerText;
            //System.Diagnostics.Debug.WriteLine(name);
        }

    }
}