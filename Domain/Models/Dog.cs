using Domain.Models.Animal;

namespace Domain.Models
{
    public class Dog : AnimalModel
    {
        public string Bark()
        {
            return "This animal barks";
        }
     
        public string Breed {  get; set; }
        public int Weight { get; set; }

    }
}
