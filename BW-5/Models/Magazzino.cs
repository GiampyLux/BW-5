namespace BW5.Models
{
    public class Magazzino
    {
        public int Id { get; set; }
        public int IdProdotto { get; set; }
        public bool Disponibilita { get; set; }
        public string Cassetto { get; set; }
        public string Armadio {  get; set; }
    }
}
