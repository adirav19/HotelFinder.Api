using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer
{
    public class Hotel
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(50)]
        [Required]//gerkeli bir alan 
        public string Name { get; set; }
        [StringLength(50)]
        [Required]
        public string City { get; set; }
    }
}
