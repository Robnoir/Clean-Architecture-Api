using Domain.Models.Animal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Cat : AnimalModel
    {
        public bool LikesToPlay { get; set; }
        public string Breed { get; set; }
        public int Weight { get; set; }
    }
}
