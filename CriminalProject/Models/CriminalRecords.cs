using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace CriminalProject.Models
{
    public class CriminalRecords
    {
      

        [Key]
        public int CriminalRecordId { get; set; }

   
        public string Offences { get; set; }

        [Required]
        [Range(0, 100)]
        [DisplayName("Sentence")]
        public int Sentence { get; set; }



        [Required]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Please enter Issued At, No Numbers allowed")]
        [StringLength(14, MinimumLength = 4, ErrorMessage = "Issued At should be between 4 and 14 characters")]
        [DisplayName("Issued At")]
        public string? LocationIssued { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Please enter Issued by, No Numbers allowed")]
        [StringLength(14, MinimumLength = 4, ErrorMessage = "Issued by should be between 4 and 14 characters")]
        public string? IssuedBy { get; set; }

      
        [DataType(DataType.Date)]
        public DateTime DateIssued { get; set; }

      
        
        public int ManagerNoForeign { get; set; }
        public Manager Manager { get; set; }

        //Suspect foreign key
        public int? SuspectNo { get; set; }
        public Suspects Suspects { get; set; }
       
        


    }
}
