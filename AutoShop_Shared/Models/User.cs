using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace AutoShop_Shared.Models
{
    public class User
    {
        [JsonProperty("id")]
        public string ID { get; set; }


        [JsonProperty("email")]
        [DataType(DataType.EmailAddress)]
        [Required(AllowEmptyStrings =false,ErrorMessage ="L'email est obligatoire")]       
        public string Email { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Photo { get; set; }
        public byte Level { get; set; }
        public uint Experience { get; set; }

        [JsonProperty("badge")]
        public Badge ActiveBadge { get; set; }


    }

}
