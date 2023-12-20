using Domain.Models.Animal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class UserAnimalModel
    {
        public Guid UserId { get; set; }
        public User user { get; set; }

        public Guid AnimalId { get; set; }
        public AnimalModel Animal { get; set; }

    }
}
