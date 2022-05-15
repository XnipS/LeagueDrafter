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
            var htmk = await GetHtml();
            ParseHtmlUsingHtmlAgilityPack(htmk);
            System.Diagnostics.Debug.WriteLine("click");
        }

        private static Task<string> GetHtml()
        {
            var client = new HttpClient();
            return client.GetStringAsync("https://github.com/XnipS");
        }

        private static void ParseHtmlUsingHtmlAgilityPack(string html)
        {
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);
            var name = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='js-pinned-items-reorder-container']/ol/li/div/div").InnerText;
            System.Diagnostics.Debug.WriteLine(name);
        }

    }
}