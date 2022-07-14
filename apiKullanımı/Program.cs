using System;
using System.Linq;
using System.Xml.Linq;

namespace apiKullanımı
{
    class Program
    {
        static void Main(string[] args)
        {
            string apiKey = "5ef9ab480d733ebc67740da680f7cdd8";
            string city = "";

            Console.WriteLine("Hava Durumunu öğrenmek istediğiniz şehri seçiniz: ");
            Console.WriteLine("1:   Ankara");
            Console.WriteLine("2:   İstanbul");
            Console.WriteLine("3:   İzmir");
            switch (Console.ReadLine())
            {
                case "1":
                    city = "ankara";
                    break;
                case "2":
                    city = "istanbul";
                    break;
                case "3":
                    city = "izmir";
                    break;
                default:
                    break;
            }


            string connection = "https://api.openweathermap.org/data/2.5/weather?q=" + city + "&mode=xml&lang=tr&units=metric&appid=" + apiKey;
            XDocument weather = XDocument.Load(connection);
            var hava = weather.Descendants("clouds").ElementAt(0).Attribute("name");
            var sicak = weather.Descendants("temperature").ElementAt(0).Attribute("value");
            var ruzgar = weather.Descendants("speed").ElementAt(0).Attribute("value");

            Console.WriteLine("Hava durumu: {0}", hava.Value);
            Console.WriteLine("Sıcaklık   : {0} derece", sicak.Value);
            Console.WriteLine("Rüzgar Hızı: {0} metre/saniye", ruzgar.Value);
            Console.ReadLine();
        }
    }
}
