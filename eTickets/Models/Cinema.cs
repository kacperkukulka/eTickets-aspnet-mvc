using eTickets.Base;
using System.ComponentModel.DataAnnotations;

namespace eTickets.Models {
    public class Cinema : IEntityBase {
        public int Id { get; set; }
        [Display(Name = "Cinema logo")]
        [Required(ErrorMessage = "Cinema logo is required")]
        public string ImageUrl { get; set; }
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Cinema name is required")]
        [StringLength(50,MinimumLength = 3, ErrorMessage = "Cinema name must be between 3 and 50 characters")]
        public string Name { get; set; }
        [Display(Name = "Description")]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        public List<Movie> Movies { get; set; } = new List<Movie>();
    }
}
