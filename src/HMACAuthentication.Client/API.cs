using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace HMACAuthentication.Client
{
    public static class API
    {
        public static class Product
        {
            public static string getProducts(string apiUrl, string apiUser, string apiKey)
            {
                //&Signature={5}

                var baseFormat = "Action={0}&Timestamp={1}&UserID={2}&Version={3}&Format={4}";
                var baseString = string.Format(baseFormat, WebUtility.UrlEncode("GetProducts"), WebUtility.UrlEncode(DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss-0000")), WebUtility.UrlEncode("maintenance@sellercenter.net"), "1.0", "XML");
                var oauth_signature = CreateSignature(apiKey, baseString);
                return apiUrl + baseString + "&Signature=" +  oauth_signature;
            }
            public static string productCreate(string baseUri)
            {
                return "";
            }
            public static string productUpdate(string baseUri)
            {
                return "";
            }
            public static string productRemove(string baseUri)
            {
                return "";
            }

        }

        private static string CreateSignature(string apiKey, string message )
        {
            var encoding = new ASCIIEncoding();
            var keyByte = encoding.GetBytes(apiKey);
            var messageBytes = encoding.GetBytes(message);
            using (var hmacsha256 = new HMACSHA256(keyByte))
            {
                var hashmessage = hmacsha256.ComputeHash(messageBytes);
                var signature = Convert.ToBase64String(hashmessage);
                return WebUtility.UrlEncode(signature);
            }
        }
    }
}
