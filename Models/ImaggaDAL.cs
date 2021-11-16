//using ImaggaSampleClass;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project
{
    public class ImaggaDAL
    {
        /*exemples: 
         * good imgs:
         * https://www.kipa.co.il/userFiles/296656_b81d1e615312088704277587a2d3f051.jpg
         * https://img.haarets.co.il/img/1.1918554/2215950335.jpg?width=1200&height=1200
                    
        * bad img:
        * https://cdn.mos.cms.futurecdn.net/42E9as7NaTaAi4A6JcuFwG-1200-80.jpg
         */
        public bool CheckImage(string imgURL)
        {// Checks if the image contains ice with a confidence of more than fifty
            //string apiKey = "acc_91c1a8d7ff8abfb";
            //string apiSecret = "1157dc63e93aedbfa7275adbfcb9a0a7";
            string apiKey = "acc_10b70e980926bdf";
            string apiSecret = "c6a796f97ab96d56dbdf242ce654063e";
            string basicAuthValue = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(String.Format("{0}:{1}", apiKey, apiSecret)));
            var client = new RestClient("https://api.imagga.com/v2/tags");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddParameter("image_url", imgURL);
            request.AddHeader("Authorization", String.Format("Basic {0}", basicAuthValue));

            IRestResponse response = client.Execute(request);
            List<Tag> results = ConvertToDictionary(response.Content);
            return isIceCream(results);
        }
        public List<Tag> ConvertToDictionary(string response)
        {//convert from JSON file to list of tagd ->pairs of (tag,confidence)
            List<Tag> Result = new List<Tag>();
            Root TheTags = JsonConvert.DeserializeObject<Root>(response);
            if (TheTags.result == null)
                return null;
            foreach (var item in TheTags.result.tags)
                Result.Add(new Tag(item.tag, item.confidence));
            return Result;
        }
        public bool isIceCream(List<Tag> listResults)
        { //return true if the image contains ice with a confidence of more than fifty
            if (listResults == null)
                return false;
            for (int i = 0; i < listResults.Count; i++)
                if ((listResults[i].tag.en == "ice" || listResults[i].tag.en == "ice cream" || listResults[i].tag.en == "frozen dessert")
                    && listResults[i].confidence > 50)
                    return true;
            return false;

        }

    }
}
