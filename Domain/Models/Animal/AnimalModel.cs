namespace Domain.Models.Animal
{
    public class AnimalModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public ICollection<UserAnimal> UserAnimals { get; set; }
    }
}
