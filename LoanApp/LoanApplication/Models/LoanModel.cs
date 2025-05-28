using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LoanApplication.Models
{
    public class LoanModel
    {
        [Key]         
        public int ID {  get; set; }

        [Required]
        //[DataType(DataType.)]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage ="Please enter a name, No Numbers allowed")]
        [DisplayName("Name: ")]
      
        public string Name { get; set; }
        
        [Required]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Please enter a surname, No Numbers allowed")]
        [DisplayName("Surname: ")]
        public string Surname { get; set; }
        
        [Required]
        [DisplayName("Gross Salary: ")]
        [Range(0,1000000000000)]
        public float GrossSalary { get; set; }

       
        [Required]
        [Range(0,1200)]
        [DisplayName("Credit Score: ")]
        public float CreditScore { get; set; }

        [Range(0, 1000000000000)]
        [DisplayName("Price Of Property: ")]
        [Required]
        public float PriceOfProperty { get; set; }

        [DisplayName("Loan Status: ")]
        [Required]
        public string LoanStatus { get; set;}

        [DisplayName("Maximum Instalment: ")]
        [Required]
        public float MaximumInstalment { get; set;}
        [DisplayName("Loan Granted: ")]
        [Required]
        public float LoanGranted { get; set;}
        [DisplayName("Deposite Required: ")]
        [Required]
        public float DepositeRequired { get; set;}
        [DisplayName("Monthly Instalment: ")]
        [Required]
        public float MonthlyInstalment { get; set;}   
    }
}
