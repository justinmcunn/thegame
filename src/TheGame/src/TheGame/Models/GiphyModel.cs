
using Newtonsoft.Json;

namespace TheGame.Models
{
    public class GiphyModel
    {
        public DataModel Data { get; set; }
        public class DataModel
        {
            [JsonProperty("image_url")]
            public string ImageUrl { get; set; }
        }
    }
}
