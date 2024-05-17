namespace PercobaanApi1.Models
{
    public class Person
    {
        public int id_person { get; set; }
        public string nama { get; set; }
        public string alamat { get; set; }
        public string email { get; set; }
    }

    public class Murid
    {
        public int id_murid { get; set; }
        public string nama { get; set; }
        public string email { get; set; }
        public int absen { get; set; }
    }
}
