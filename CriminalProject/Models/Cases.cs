using System.ComponentModel.DataAnnotations;

namespace CriminalProject.Models
{
    public class Cases
    {
       public List <Suspects> Suspects { get; set; }

        public List<Manager> ManagerList { get; set; }

        public List<CriminalRecords> CriminalRecords { get; set; }
    }
}
