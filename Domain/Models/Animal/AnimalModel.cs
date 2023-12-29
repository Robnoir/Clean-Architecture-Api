using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Animal
{
    public class AnimalModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;
        public string? Breed { get; set; }
        public int? Weight { get; set; } 
        public string? BirdColor { get; set; }


        public virtual ICollection<UserAnimal> UserAnimals { get; set; }
    }
}
