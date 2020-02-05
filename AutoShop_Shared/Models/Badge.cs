using Newtonsoft.Json;

namespace AutoShop_Shared.Models
{
    public class Badge
    {
        //Title, Label, Picture

        [JsonProperty("title")]
        public string Title { get; set; }
        public string Label { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }

    }
}
