using Domain.Models.Animal;

namespace Domain.Models
{
    public class Dog: AnimalModel
    {
        public string Bark()
        {
            return "This animal barks";
        }
    }
}
