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
                var datetime = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss+03:00", new System.Globalization.CultureInfo("tr-TR"));

                var baseFormat = "Action={0}&Filter=all&Format=XML&Timestamp={1}&UserID={2}&Version=1.0";
                var baseString = string.Format(baseFormat, WebUtility.UrlEncode("GetProducts"), WebUtility.UrlEncode(datetime), WebUtility.UrlEncode(apiUser));
                var oauth_signature = CreateSignature(apiKey, baseString);
                return apiUrl + baseString + "&Signature=" +  oauth_signature;
            }
            public static string productCreate(string apiUrl, string apiUser, string apiKey)
            {
                var datetime = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss+03:00", new System.Globalization.CultureInfo("tr-TR"));

                var baseFormat = "Action={0}&Timestamp={1}&UserID={2}&Version=1.0";
                var baseString = string.Format(baseFormat, WebUtility.UrlEncode("ProductCreate"), WebUtility.UrlEncode(datetime), WebUtility.UrlEncode(apiUser));
                var oauth_signature = CreateSignature(apiKey, baseString);
                return apiUrl + baseString + "&Signature=" + oauth_signature;
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

        private static string CreateSignature( string apiKey, string message)
        {
            var key1 = Encoding.UTF8.GetBytes(apiKey);
            var message1 = Encoding.UTF8.GetBytes(message);
            var hmacSHA = new HMACSHA256(key1);
            var hash = hmacSHA.ComputeHash(message1, 0, message1.Length);
            return BitConverter.ToString(hash).Replace("-", "").ToLower();

 
        }
    }
}
