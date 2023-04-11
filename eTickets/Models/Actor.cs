using eTickets.Base;
using System.ComponentModel.DataAnnotations;

namespace eTickets.Models {
    public class Actor : IEntityBase {
        public int Id { get; set; }
        [Display(Name = "Profile Picture")]
        [Required(ErrorMessage = "Profile picture is required")]
        public string ImageUrl { get; set; }
        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Full Name is required")]
        [StringLength(50,MinimumLength = 3,ErrorMessage = "Full name must be of length greater than 3 and less than 50")]
        public string FullName { get; set; }
        [Display(Name = "Biography")]
        [Required]
        public string Bio { get; set; }

        public List<Actor_Movie> Actors_Movies { get; set; } = new List<Actor_Movie>();
    }
}
