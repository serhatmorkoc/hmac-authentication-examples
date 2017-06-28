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
        static readonly string _apiUrl = "https://api.sellercenter.lazada.sg/?";
        static readonly string _apiUser = "api@sellercenter.net";
        static readonly string _apiKey = "b1bdb357ced10fe4e9a69840cdd4f0e9c03d77fe";

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