using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public string FatherName { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime RegistrationDate { get; set; }


        [NotMapped]
        public string FullName => $"{Surname} {Name} {FatherName}";
    }
}
