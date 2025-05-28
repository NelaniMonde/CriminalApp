using CriminalProject.Data;
using Microsoft.Extensions.Hosting;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CriminalProject.Models
{
    public class Suspects
    {
        [Key]
        [DisplayName("Suspect Number:\t\t\t   ")]
        public int SuspectNo { get; set; }

        [RegularExpression(@"(((\d{2}((0[013578]|1[02])(0[1-9]|[12]\d|3[01])|(0[13456789]|1[012])(0[1-9]|[12]\d|30)|02(0[1-9]|1\d|2[0-8])))|([02468][048]|[13579][26])0229))(( |-)(\d{4})( |-)([01]8((( |-)\d{1})|\d{1}))|(\d{4}[01]8\d{1}))",
        ErrorMessage = "Invalid ID Number")]
        [DisplayName("ID:\t\t\t  ")]
        public string SuspectID { get; set; }

        [StringLength(14, MinimumLength = 4, ErrorMessage = "Last name should be between 4 and 14 characters")]

        [DisplayName("Firstname:\t\t\t  ")]
        public string? FirstName { get; set;}


        [StringLength(14, MinimumLength = 4, ErrorMessage = "Last name should be between 4 and 14 characters")]
        [DisplayName("Lastname:\t\t\t   ")]
        public string? LastName { get; set;}

        public ICollection<CriminalRecords> CriminalRecords { get; set; }

    }
}
