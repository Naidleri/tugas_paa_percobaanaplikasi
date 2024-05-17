namespace PercobaanApi1.Models
{
    public class Login
    {
        public int id_person { get; set; }
        public string nama { get; set; }
        public string alamat { get; set; }
        public string email { get; set; }
        public int peran_fk { get; set; }
        public string nama_peran { get; set; }
        public string token { get; set; }

    }
}
