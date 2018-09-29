using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;

namespace ProductConsoleApp
{
    /// <summary>
    /// JSON object of a Category item
    /// </summary>
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public bool CanListAuctions { get; set; }
        public bool CanListClassifieds { get; set; }
        public bool CanRelist { get; set; }
        public string LegalNotice { get; set; }
        public int DefaultDuration { get; set; }
        public List<int> AllowedDurations { get; set; }//List of AllowedDurations
        public Fees Fees { get; set; }//Fees object
        public int FreePhotoCount { get; set; }
        public int MaximumPhotoCount { get; set; }
        public bool IsFreeToRelist { get; set; }
        public List<Promotion> Promotions { get; set; }//List of Promotion items contained in category
        public List<object> EmbeddedContentOptions { get; set; }
        public int MaximumTitleLength { get; set; }
        public int AreaOfBusiness { get; set; }
        public int DefaultRelistDuration { get; set; }

    }
    /// <summary>
    /// JSON object of a Promotion item which is a child of Category
    /// </summary>
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
    /// <summary>
    /// JSON object of a Fee item which is a child of Category
    /// </summary>
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
        public List<ListingFeeTier> ListingFeeTiers { get; set; }//List of ListingFeeTiers items contained in Fees
        public double SecondCategory { get; set; }
    }
    /// <summary>
    /// Create a json object of ListingFeeTier which is a child of Fee for complete creation of Category json object
    /// </summary>
    public class ListingFeeTier
    {
        public int MinimumTierPrice { get; set; }
        public double FixedFee { get; set; }
    }
    /// <summary>
    /// Class with a main method as the entrypoint of the c# console application
    /// </summary>
    public class Program
    {
        //Instantiate a single Http client object that is used in all methods
        public static HttpClient client = new HttpClient();

        static void Main(string[] args)
        {

        }
        /// <summary>
        /// This method returns the boolean status of CanRelist parameter in the Category json object 
        /// </summary>
        /// <returns>bool</returns>
        public static async Task<bool> GetCanRelistStatus()
        {
            //var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://api.tmsandbox.co.nz/v1/Categories/6327/Details.json?catalogue=false");
            if(response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsAsync<Category>();
                return content.CanRelist;
            }
            return false;
        }
        /// <summary>
        /// This method returns a string representation of the Category
        /// </summary>
        /// <returns>string</returns>
        public static async Task<string> GetCategory()
        {
            HttpResponseMessage response = await client.GetAsync("https://api.tmsandbox.co.nz/v1/Categories/6327/Details.json?catalogue=false");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsAsync<Category>();
                return content.Name;
            }
            return null;
        }
        /// <summary>
        /// This method returns a List of JSON Promotion objects contained in Category
        /// </summary>
        /// <returns>List of Promotion JSON objects</returns>
        public static async Task<List<Promotion>> GetPromotionList()
            {
            HttpResponseMessage response = await client.GetAsync("https://api.tmsandbox.co.nz/v1/Categories/6327/Details.json?catalogue=false");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsAsync<Category>();
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
