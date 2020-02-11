using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace AutoShop_Shared.Models
{
    public class User
    {
        [JsonProperty("id")]
        public string ID { get; set; }


        [JsonProperty("email")]
        [Required(AllowEmptyStrings =false,ErrorMessage ="L'email est obligatoire")]  
        [Display(Name = "Courriel", Prompt = "Saisir votre courriel")]
        [EmailAddress(ErrorMessage = "Ce n'est pas une addresse mail")]
        public string Email { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Photo { get; set; }
        [Range(1,100,ErrorMessage = "Le level doit être compris de 1 à 100")]
        public byte Level { get; set; }
        public uint Experience { get; set; }

        [JsonProperty("badge")]
        public Badge ActiveBadge { get; set; }
        public string PartitionKey { get; internal set; }
    }

}
