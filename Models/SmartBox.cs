using System.ComponentModel.DataAnnotations;

namespace webapp_travel_agency.Models
{
    public class SmartBox
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [StringLength(25, ErrorMessage = "Il nome non può essere maggiore di 25 caratteri")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [StringLength(100, ErrorMessage = "Il nome non può essere maggiore di 100 caratteri")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Il campo è obbligatorio")]
        public string? Image { get; set; }

        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [Range(0, 500, ErrorMessage = "Il prezzo non può essere superiore di 500")]
        public int? Price { get; set; }

        public SmartBox()
        {

        }

    }
}
