using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HMACAuthentication.Client
{
    class Program
    {
        static readonly string _apiUrl = "https://api.sellercenter.lamoda.ua/?";
        static readonly string _apiUser = "globalmarkets+marketplacetest@b2cdirect.com";
        static readonly string _apiKey = "5a8cdd2527e4e682fa75434f449dac1600c098b6";

        static void Main(string[] args)
        {
            GetProductsAsync().Wait();

        }

        static async Task GetProductsAsync()
        {
            var _apiClient = new StandardHttpClient();
            var getProductsUri = API.Product.getProducts(_apiUrl, _apiUser, _apiKey);
            var dataString = await _apiClient.GetStringAsync(getProductsUri);
            
            Console.Write(dataString);
            Console.ReadLine();

        }
    }
}