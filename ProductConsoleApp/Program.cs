using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Threading;

namespace ProductConsoleApp
{
    public class JsonObjects
    {
        public static void test()
        {
            Console.WriteLine("Hello world");
        }
    }
    public class Promotion
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int MinimumPhotoCount { get; set; }
        public double? OriginalPrice { get; set; }
        public bool? Recommended { get; set; }
    }
    public class ProductName
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public bool CanListAuctions { get; set; }
        public bool CanListClassifieds { get; set; }
        public bool CanRelist { get; set; }
        public string LegalNotice { get; set; }
        public int DefaultDuration { get; set; }
        public List<int> AllowedDurations { get; set; }
        public Fees Fees { get; set; }
        public int FreePhotoCount { get; set; }
        public int MaximumPhotoCount { get; set; }
        public bool IsFreeToRelist { get; set; }
        public List<Promotion> Promotions { get; set; }
        public List<object> EmbeddedContentOptions { get; set; }
        public int MaximumTitleLength { get; set; }
        public int AreaOfBusiness { get; set; }
        public int DefaultRelistDuration { get; set; }

    }
    public class Fees
    {
        public double Bundle { get; set; }
        public double EndDate { get; set; }
        public double Feature { get; set; }
        public double Gallery { get; set; }
        public double Listing { get; set; }
        public double Reserve { get; set; }
        public double Subtitle { get; set; }
        public double TenDays { get; set; }
        public List<ListingFeeTier> ListingFeeTiers { get; set; }
        public double SecondCategory { get; set; }
    }
    public class ListingFeeTier
    {
        public int MinimumTierPrice { get; set; }
        public double FixedFee { get; set; }
    }
    public class Program
    {
        static void Main(string[] args)
        {

        }

        public static async Task<bool> GetCanRelistStatus()
        {
            var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://api.tmsandbox.co.nz/v1/Categories/6327/Details.json?catalogue=false");
            if(response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsAsync<ProductName>();
                return content.CanRelist;
            }
            return false;
        }

        public static async Task<string> GetProductName()
        {
            var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://api.tmsandbox.co.nz/v1/Categories/6327/Details.json?catalogue=false");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsAsync<ProductName>();
                return content.Name;
            }
            return null;
        }

        public static async Task<List<Promotion>> GetPromotionList()
            {
            var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://api.tmsandbox.co.nz/v1/Categories/6327/Details.json?catalogue=false");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsAsync<ProductName>();
                List<Promotion> ListOfPromotions = new List<Promotion>();
                foreach (Promotion promo in content.Promotions)
                {
                    ListOfPromotions.Add(promo);
                }
                return ListOfPromotions;
            }
            return null;
        }
    }
}
