using System.ComponentModel.DataAnnotations;

namespace eTickets.Models {
    public class Cinema {
        public int Id { get; set; }
        [Display(Name = "Cinema logo")]
        public string ImageUrl { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }

        public List<Movie> Movies { get; set; }
    }
}
