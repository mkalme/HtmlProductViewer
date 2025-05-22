using HtmlAgilityPack;
using System.Diagnostics;
using System.Net;

namespace HtmlProductViewer {
    internal static class Program {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            Test();
            
            Application.Run(new Form1());
        }

        private static void Test() {
            string url = "https://www.rimi.lv/e-veikals/en/products/food-cupboard/speciality-foods-and-rice-cakes/gluten-free-products/makaroni-fusilli-ica-bez-lipekla-500g/p/804897";

            WebClient webClient = new WebClient();
            string page = webClient.DownloadString(url);

            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(page);

            int count = 0;

            foreach (var node in doc.DocumentNode.SelectNodes("//script")) {
                Clipboard.SetText(node.OuterHtml);

                count++;
                if (count == 5) return;
            }


            //node.SelectSingleNode("product__details");

            //foreach (HtmlNode table in doc.GetElementbyId("product_tabs")) {
            ///This is the table.    
            //foreach (HtmlNode row in table.SelectNodes("tr")) {
            //    ///This is the row.
            //    foreach (HtmlNode cell in row.SelectNodes("th|td")) {
            //        Debug.WriteLine(cell.InnerText);
            //    }
            //}
            //}
        }
    }
}