using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Groupe1.Webzine.EntitiesContext.Seeder
{
    public class RootTrack
    {
        [JsonPropertyName("items")]
        public List<ItemTrack> Items { get; set; }
    }
    public class ItemTrack
    {
        [JsonPropertyName("duration_ms")]
        public int DurationMs { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}