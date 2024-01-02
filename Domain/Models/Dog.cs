using Domain.Models.Animal;

namespace Domain.Models
{
    public class Dog : AnimalModel
    {
        public string Bark()
        {
            return "This animal barks";
        }
     
        public string DogBreed {  get; set; }
        public int DogWeight { get; set; }

    }
}
