namespace DatiCondivi.Dtos
{
    public class StudenteDto : BaseDto
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public DateTime? DataNascita { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string CodiceFiscale { get; set; }
    }
}
