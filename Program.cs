using System.Net;
using Newtonsoft.Json;
namespace CurrencyInfo
{

    class Currency
    {
        public string Ccy { get; set; }
        public string BaseCurrency { get => "UAH"; }
        public double Buy { get; set; }
        public double Sale { get; set; }

        public Currency() { }

        public override string ToString()
        {
            return $"Currency: {Ccy,-10}Base currency: {BaseCurrency,-10}Buy: {Buy,-10}Sale: {Sale}";
        }
    }





    internal class Program
    {
        static void Main(string[] args)
        {
            WebClient wc = new WebClient();
            string json = wc.DownloadString("https://api.privatbank.ua/p24api/pubinfo?json&exchange&coursid=5");
            List<Currency> list = JsonConvert.DeserializeObject<List<Currency>>(json);


            while (true)
            {
                Console.WriteLine("Choose currency (1 - EUR, 2 - USD, 0 - exit): ");

                int choise = int.Parse(Console.ReadLine());
                if (choise == 0)
                {
                    break;
                }
                Currency cur = list[choise-1];
                Console.WriteLine(cur);
            }
        }
    }
}