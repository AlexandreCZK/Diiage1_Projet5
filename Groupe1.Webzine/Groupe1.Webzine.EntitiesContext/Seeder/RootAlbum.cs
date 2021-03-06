using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Groupe1.Webzine.EntitiesContext.Seeder
{
    public class RootAlbum
    {
        [JsonPropertyName("items")]
        public List<ItemAlbums> Items { get; set; }
    }
    public class ItemAlbums
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("images")]
        public List<Image> Images { get; set; }
    }

    public class Image
    {
        [JsonPropertyName("height")]
        public int Height { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("width")]
        public int Width { get; set; }
    }
}
