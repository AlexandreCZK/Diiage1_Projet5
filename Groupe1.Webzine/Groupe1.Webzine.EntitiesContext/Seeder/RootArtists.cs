using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Groupe1.Webzine.EntitiesContext.Seeder
{
    public class RootArtists
    {
        [JsonPropertyName("artists")]
        public Artists Artists { get; set; }
    }

    public class Artists
    {
        [JsonPropertyName("items")]
        public List<ItemArtiste> Items { get; set; }
    }

    public class ItemArtiste
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
