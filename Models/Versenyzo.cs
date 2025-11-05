namespace EuroskillsAPI.Models
{
    public class Versenyzo
    {
        public int Id { get; set; }
        public string Nev { get; set; } = string.Empty;
        public string SzakmaId { get; set; } = string.Empty;
        public string OrszagId { get; set; } = string.Empty;
        public int Pont { get; set; }
    }
}
