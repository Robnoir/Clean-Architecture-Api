using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class User
    {
        public Guid Id {get; set; }
        public string Username { get; set; } = string.Empty;

        public string Email {get; set;} = string.Empty;

        public string PasswordHash { get; set; } = string.Empty;
    }
}