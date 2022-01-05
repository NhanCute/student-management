using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Model.Models
{
    [Table("StudentInformations")]
    public class StudentInformation
    {
        [Key]
        public string ID { set; get; }

        [Required]
        [MaxLength(256)]
        public string StudentName { set; get; }

        [Required]
        [MaxLength(256)]
        public string StudentAge { set; get; }

        [Required]
        [MaxLength(256)]
        public string StudentMark { set; get; }

        [Required]
        [MaxLength(50)]
        public string StudentGender { set; get; }

        [Required]
        [MaxLength(50)]
        public string StudentCreatedAt { set; get; }

        [Required]
        [MaxLength(50)]
        public string StudentUpdatedAt { set; get; }
        
        [MaxLength(50)]
        public string StudentCity { set; get; }


    }
}
