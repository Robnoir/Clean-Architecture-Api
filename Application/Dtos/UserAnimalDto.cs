using Domain.Models;
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
        public string UserName { get; set; }
        public Guid AnimalId { get; set; }
        public string AnimalName { get; set; }

        public List<DogDto> dogs { get; set; }
        public List<CatDto> cat { get; set; }
        public List<BirdDto> bird { get; set; }
    }
}
