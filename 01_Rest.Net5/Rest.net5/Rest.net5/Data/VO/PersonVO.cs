
using Rest.net5.Hypermedia;
using Rest.net5.Hypermedia.Abstract;
using Rest.net5.Model.Base;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Rest.net5.Data.VO
{
    public class PersonVO :ISupportsHyperMedia
    {
        [JsonPropertyName("Id")]
        public long Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
  
        public string Address { get; set; }

        public string Gender { get; set; }

        public bool Enabled { get; set; }

        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
    }
}
