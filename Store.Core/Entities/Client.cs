using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Entities
{
    public class Client : BaseEntity
    {
        [Required]
        [MaxLength(255)]
        public string Surname { get; set; }
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        [Required]
        [MaxLength(255)]
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
