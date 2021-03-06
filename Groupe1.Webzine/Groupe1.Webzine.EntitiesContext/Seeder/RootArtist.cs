using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Groupe1.Webzine.EntitiesContext.Seeder
{
    public class RootArtist
    {
        [JsonPropertyName("genres")]
        public List<string> Genres { get; set; }
    }
}
