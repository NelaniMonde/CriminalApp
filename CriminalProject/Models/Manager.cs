using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CriminalProject.Models
{
    public class Manager
    {
        [Key]
        [DisplayName("Manager Number:\t\t\t   ")]
        public int ManagerNo { get; set; }

        [RegularExpression(@"(((\d{2}((0[013578]|1[02])(0[1-9]|[12]\d|3[01])|(0[13456789]|1[012])(0[1-9]|[12]\d|30)|02(0[1-9]|1\d|2[0-8])))|([02468][048]|[13579][26])0229))(( |-)(\d{4})( |-)([01]8((( |-)\d{1})|\d{1}))|(\d{4}[01]8\d{1}))",
        ErrorMessage = "Invalid ID Number")]
        [DisplayName("ID:\t\t\t  ")]
        public string ManagerID { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Please enter Manager First Name, No Numbers allowed")]
        [StringLength(14, MinimumLength = 4, ErrorMessage = "Last name should be between 4 and 30 characters")]

        [DisplayName("Firstname:\t\t\t  ")]
        public string Name { get; set; }


        [Required]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Please enter Manager Last Name, No Numbers allowed")]
        [StringLength(14, MinimumLength = 4, ErrorMessage = "Last name should be between 4 and 30 characters")]
        [DisplayName("Lastname:\t\t\t   ")]
        public string LastName { get; set; }

      public ICollection<CriminalRecords> Criminals { get; set; } = new List<CriminalRecords>();
       
    }
}
