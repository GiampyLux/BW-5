namespace BW5.Models
{
    public class Armadio
    {
        public int Id { get; set; }
        public string CodiceUnivoco { get; set; }
        public int CassettoId { get; set; }

        public IEnumerable<Cassetto> Cassetti {  get; set; }
    }
}
