
using Rest.net5.Model.Base;
using System.Text.Json.Serialization;

namespace Rest.net5.Data.VO
{
    public class PersonVO
    {
        [JsonPropertyName("Id")]
        public long Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
  
        public string Address { get; set; }

        public string Gender { get; set; }
    }
}
