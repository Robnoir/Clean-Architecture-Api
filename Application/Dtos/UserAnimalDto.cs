using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{

    public class UserAnimalDto
    {
        public Guid UserId { get; set; }
        //public Guid AnimalId { get; set; }
        public string Username { get; set; }


        public List<DogDto> Dogs { get; set; }
        public List<CatDto> Cats { get; set; }
        public List<BirdDto> Birds { get; set; }
    }
}
