using Newtonsoft.Json;
using System.Collections.Generic;

namespace JsonSerialization
{
    public class Item
    {
        public string Name { get; set; }
        public int Store { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string json = @"
            {
              ""2"": {
                ""name"": ""Cannonball"",
                ""store"": 5
              },
              ""6"": {
                ""name"": ""Cannon base"",
                ""store"": 187500
              },
            }";

            string jsonArray = @"
            [
              {
                ""name"": ""Cannonball"",
                ""store"": 5
              },
              {
                ""name"": ""Cannon base"",
                ""store"": 187500
              }
            ]";

            var dict = JsonConvert.DeserializeObject<Dictionary<string, Item>>(json);
            var dictArr = JsonConvert.DeserializeObject<List<Item>>(jsonArray);

            var arr = new Item [] { new Item { Name = "Name1", Store = 1 }, new Item { Name = "Name2", Store = 2 } };
            var jsonFromList = JsonConvert.SerializeObject(arr);

            dynamic request = new
            {
                publisherId = "tfs",
                eventType = " workitem.created",
                resourceVersion = "1.0",
                consumerId = "webHooks",
                consumerActionId = "httpRequest",
                publisherInputs = new
                {
                    projectId = "test123",
                },
                consumerInputs = new
                {
                    url = "https://mydomain/api/ServiceHook/SaveWorkItem"
                }
            };
            var jsonRequest = JsonConvert.SerializeObject(request);
        }
    }
}
