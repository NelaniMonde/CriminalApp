namespace CriminalProject.Models
{
    public class SuspectsNCrimininal
    {
        public Suspects Suspects { get; set; } = new Suspects();
        public List<CriminalRecords> CriminalRecords { get; set; }
    }
}
