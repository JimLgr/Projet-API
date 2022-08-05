namespace MrTerenceWebAPI.DTO.Fournisseur
{
    public class FournisseurIndexDTO
    {
        public long FournisseurId { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public long AdresseId { get; set; }
    }
}
