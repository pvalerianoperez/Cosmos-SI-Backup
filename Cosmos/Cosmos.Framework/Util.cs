using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Dynamic;
using System.IO;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Cosmos.Framework
{
    public static class Util
    {

        public static string ObjectToJson<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });
        }

        public static JObject JsonToJObject(string json)
        {
            return JObject.Parse(json);
        }

        public static long GetUnixTime(DateTime dateTime)
        {
            return (long)(dateTime.ToUniversalTime().Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
        }

        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            return new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(unixTimeStamp).ToLocalTime();
        }

        public static DateTime GetLocalDateTime(DateTime utcDatetime)
        {
            return utcDatetime.AddHours(/*TokenUser.GetInstance()?.Utc ?? 0*/-5);
        }

        public static T JsonToObject<T>(string json)
        {
            return (T)JsonConvert.DeserializeObject(json);
        }

        public static List<T> Purge<T>(List<T> list) where T : IComparable<T>
        {
            list.Sort();

            for (int i = 0; i < list.Count - 1; i++)
                for (int j = i + 1; j < list.Count; j++)
                    if (list[i].CompareTo(list[j]) == 0)
                        list.RemoveAt(j--);
                    else break;

            return list;
        }

        public static List<T> CollectionToList<T, C>(C collection) where T : IComparable<T> where C : Collection<T>
        {
            List<T> list = new List<T>();

            foreach (var element in collection)
                list.Add(element);

            return list;

        }

        public static List<V> ConvertList<T, V>(List<T> list, Func<T, V> converter)
        {
            List<V> res = new List<V>();

            foreach (var t in list)
                res.Add(converter(t));

            return res;
        }

        public static string Base64Encode(string text)
        {
            string intermedio = Convert.ToBase64String(Encoding.UTF8.GetBytes(text));
            return intermedio;
        }

        public static string Base64Decode(string base64)
        {
            string intermedio = Encoding.UTF8.GetString(Base64ToByteArray(base64));
            return intermedio;
        }

        public static byte[] Base64ToByteArray(string base64)
        {
            return Convert.FromBase64String(base64);
        }

        public static string ReadAppSetting(string key)
        {
            string result = "Not Found";

            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                result = appSettings[key] ?? "Not Found";
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error reading app settings");
            }

            return result;
        }

        public static Dictionary<string, bool> ReadEventsAppSetting()
        {
            Dictionary<string, bool> logEventos = new Dictionary<string, bool>();

            List<string> values = new List<string>();
            foreach (string key in ConfigurationManager.AppSettings)
            {
                if (key.StartsWith("Event2Log_"))
                {
                    string value = key.Replace("Event2Log_", "");
                    bool action = Convert.ToBoolean(ConfigurationManager.AppSettings[key]);
                    logEventos.Add(value, action);
                }

            }

            return logEventos;
        }

        public static bool IsPropertyExist(dynamic settings, string name)
        {
            if (settings is ExpandoObject)
                return ((IDictionary<string, object>)settings).ContainsKey(name);

            return settings.GetType().GetProperty(name) != null;
        }

        private static string RemoveAccents(string text)
        {
            return text.Replace("á", "a")
                        .Replace("é", "e")
                        .Replace("í", "i")
                        .Replace("ó", "o")
                        .Replace("ú", "u")
                        .Replace("Á", "A")
                        .Replace("É", "E")
                        .Replace("Í", "I")
                        .Replace("Ó", "O")
                        .Replace("Ú", "U");
        }

}

    public static class Extensions
    {

        public static Stream ToStream(this string s)
        {
            try
            {

                var stream = new MemoryStream();
                var writer = new StreamWriter(stream);
                writer.Write(s);
                writer.Flush();
                stream.Position = 0;
                return stream;
            }
            catch (Exception)
            {
                // Hacer algo con el error
                return new MemoryStream();
            }
        }

        public static string ToStringData(this MemoryStream stream)
        {
            try
            {

                string data;

                using (stream)
                {
                    stream.Position = 0;
                    var reader = new StreamReader(stream);
                    data = reader.ReadToEnd();
                }

                return data;
            }
            catch (Exception)
            {
                // Hacer algo con el error
                return "";
            }
        }

        public static string Reverse(this string s)
        {
            string reverse = string.Empty;

            for (int i = s.Length - 1; i >= 0; i--)
                reverse += s[i];

            return reverse;
        }

        public static bool Validate(this DataRow row, string index)
        {
            return row.Table.Columns.Contains(index) && !string.IsNullOrEmpty(row[index]?.ToString());
        }
    }

}
