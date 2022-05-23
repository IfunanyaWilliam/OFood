using OFood.Data.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OFood.Data.Models
{
    public class CreateViewModel
    {
        [Required]
        [DisplayName("Cuisine Type")]
        public CuisineType Cuisine { get; set; }

        [Required]
        public string Name { get; set; }
    }

}
