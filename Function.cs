using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Amazon.Lambda.Core;
using Amazon.Lambda.APIGatewayEvents;
using System.Dynamic;
using System.Net.Http.Json;
using System.Net.Http;
using Newtonsoft.Json;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace Assignment9NyTimes
{

    public class Results
    {
        public string list_name { get; set; }
        public string list_name_encoded { get; set; }
        public string bestsellers_date { get; set; }
        public string published_date { get; set; }
        public string published_date_description { get; set; }
        public string next_published_date { get; set; }
        public string previous_published_date { get; set; }
        public string display_name { get; set; }
        public int normal_list_ends_at { get; set; }
        public string updated { get; set; }
        public Book[] books { get; set; }
        public object[] corrections { get; set; }
    }

    public class Book
    {
        public int rank { get; set; }
        public int rank_last_week { get; set; }
        public int weeks_on_list { get; set; }
        public string publisher { get; set; }
        public string description { get; set; }
        public string price { get; set; }
        public string title { get; set; }
        public string author { get; set; }
    }




    public class Function
    {
        public static HttpClient client = new HttpClient();
        public async Task<ExpandoObject> FunctionHandler(APIGatewayProxyRequest input, ILambdaContext context)
        {
            string url = "https://api.nytimes.com/svc/books/v3/lists/current/hardcover-fiction.json?api-key=pWH5lXvpDR6A9MOJ8OnsHEaCzpw6cAFk";
            using (HttpResponseMessage response = await client.GetAsync(url))
            {
                Book myBook = JsonConvert.DeserializeObject<Book>(response.Content.ReadFromJsonAsync<Book>()));
                //List<Book> bestBooks = await JsonConvert.DeserializeObject<Book>(response.Content.ReadFromJsonAsync<Book>());
            }

            //WebParser wtf = new WebParser


            //ExpandoObject bookList = JsonConvert.DeserializeObject<Book>(input.Body);


            return  ;

        }
    }


}
