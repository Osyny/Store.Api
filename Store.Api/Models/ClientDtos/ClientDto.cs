using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.Api.Models.ClientDtos
{
    public class ClientDto
    {
        [Required]
        public string Surname { get; set; }
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        [Required]
        [MaxLength(255)]
        public string FatherName { get; set; }
        public DateTime Birthday { get; set; }

        [NotMapped]
        public string FullName => $"{Surname} {Name} {FatherName}";


    }
}
