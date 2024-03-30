using Npgsql;
using PercobaanApi1.Helpers;


namespace PercobaanApi1.Models
{
    public class PersonContext
    {
        private string __contstr;
        private string __errorMessage;

        public PersonContext(string pContstr)
        {
            __contstr = pContstr;
        }

        public void CreatePerson (Person person)
        {
            Person person1 = new Person()
            {
                id_person = person.id_person,
                nama = person.nama,
                alamat = person.alamat,
                email = person.email
            };
            string query = string.Format(@"INSERT INTO users.person (id_person,nama,alamat,email) VALUES (@id_person, @nama, @alamat, @email)") ;
            sqlDBHelper db = new sqlDBHelper(this.__contstr);
            try
            {
                using (NpgsqlCommand cmd = db.getNpgsqlCommand(query))
                {
                    cmd.Parameters.AddWithValue("@id_person",person1.id_person);
                    cmd.Parameters.AddWithValue("@nama", person1.nama);
                    cmd.Parameters.AddWithValue("@alamat", person1.alamat);
                    cmd.Parameters.AddWithValue("@email", person1.email);

                    cmd.ExecuteNonQuery();
                }

            }
           catch (Exception ex) 
            {
                __errorMessage = ex.Message;
            }
        }

        public List<Person> ListPerson()
        {
            List<Person> list1 = new List<Person>();
            string query = string.Format(@"SELECT id_person, nama, alamat, email FROM users.person;");
            sqlDBHelper db = new sqlDBHelper(this.__contstr);
            try
            {
                NpgsqlCommand cmd = db.getNpgsqlCommand(query);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list1.Add(new Person() 
                    {
                        id_person = int.Parse(reader["id_person"].ToString()),
                        nama = reader["nama"].ToString(),
                        alamat = reader["alamat"].ToString(),
                        email = reader["email"].ToString()
                    });
                }
                cmd.Dispose();
                db.CloseConnection();
            }
            catch (Exception ex) 
            {
                __errorMessage = ex.Message;
            }
            return list1;
        }

        public void UpdatePerson (int id_person, Person person)
        {
            string query = string.Format (@"UPDATE users.person SET nama = @nama, alamat = @alamat, email = @email WHERE id_person = @id_person");
            sqlDBHelper db = new sqlDBHelper (this.__contstr);

            using (NpgsqlCommand cmd = db.getNpgsqlCommand(query)) 
            { 
                cmd.Parameters.AddWithValue ("id_person", id_person);
                cmd.Parameters.AddWithValue ("nama",person.nama);
                cmd.Parameters.AddWithValue ("alamat", person.alamat);
                cmd.Parameters.AddWithValue("email", person.email);
                cmd.ExecuteNonQuery(); 
            }

        }

        public void DeletePerson(int id_person)
        {
            string query = string.Format(@"DELETE FROM users.person WHERE id_person = @id_person");
            sqlDBHelper db = new sqlDBHelper(this.__contstr);

            using (NpgsqlCommand cmd = db.getNpgsqlCommand(query))
            {
                cmd.Parameters.AddWithValue("id_person", id_person);

                cmd.ExecuteNonQuery();
            }

        }
    }

}
