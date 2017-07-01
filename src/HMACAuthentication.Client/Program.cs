using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;
using HMACAuthentication.Client.Model.Product;
using Newtonsoft.Json;

namespace HMACAuthentication.Client
{
    class Program
    {
        static readonly string _apiUrl = "https://api.sellercenter.lamoda.ua/?";
        static readonly string _apiUser = "globalmarkets+marketplacetest@b2cdirect.com";
        static readonly string _apiKey = "5a8cdd2527e4e682fa75434f449dac1600c098b6";

        static void Main(string[] args)
        {
            //GetProductsAsync().Wait();
            ProductCreateAsync().Wait();

        }

        static async Task GetProductsAsync()
        {
            var _apiClient = new StandardHttpClient();
            var getProductsUri = API.Product.getProducts(_apiUrl, _apiUser, _apiKey);
            var dataString = await _apiClient.GetStringAsync(getProductsUri);

            Console.Write(dataString);
            Console.ReadLine();

        }

        static async Task ProductCreateAsync()
        {

            
            var model = new ProductCreateModel.Request()
            {
                Product = new ProductCreateModel.Product()
                {
                    Categories = "2436",
                    Brand = "Nadasa",
                    Condition = "refurbished",
                    Description = "<![CDATA[This is a <b>bold</b> product.]]>",
                    Name = "Magic Product",
                    Price = "100.00",
                    PrimaryCategory = "2436",
                    ProductId = "123456",
                    Quantity = "10",
                    SalePrice = "32.5",
                    SaleEndDate = DateTime.Now.AddMonths(10).ToString("yyyy-MM-ddTHH:mm:ss+03:00", new System.Globalization.CultureInfo("tr-TR")),
                    SaleStartDate = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss+03:00", new System.Globalization.CultureInfo("tr-TR")),
                    SellerSku = "241053821734",
                    ShipmentType = "dropshipping",
                    Status = "active",
                    //TaxClass = "default",
                    Variation = "XXL",
                    ProductData = new ProductCreateModel.ProductData()
                    {
                        Megapixels = "490",
                        Network = "This is network",
                        NumberCpus = "32",
                        OpticalZoom = "7",
                        SystemMemory = "4"
                    }

                }
            };


            var qq = Serialize(model);



            var _apiClient = new StandardHttpClient();
            var productCreateUri = API.Product.productCreate(_apiUrl, _apiUser, _apiKey);
            var response = await _apiClient.PutAsync(productCreateUri, qq);
            Console.Write(response.Content.ReadAsStringAsync().Result);
            Console.ReadLine();

        }


        public static string Serialize<T>(T dataToSerialize)
        {
            try
            {
                var ns = new XmlSerializerNamespaces();
                ns.Add("", "");
                
                var stringwriter = new StringWriterUTF8();
                var serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(stringwriter, dataToSerialize, ns);
               



                return stringwriter.ToString();
            }
            catch
            {
                throw;
            }
        }

        public static T Deserialize<T>(string xmlText)
        {
            try
            {
                var stringReader = new System.IO.StringReader(xmlText);
                var serializer = new XmlSerializer(typeof(T));
                return (T)serializer.Deserialize(stringReader);
            }
            catch
            {
                throw;
            }
        }
    }
}