using Npgsql;
using PercobaanApi1.Helpers;

namespace PercobaanApi1.Models
{
    public class MuridContext
    {
        private string __contstr;
        private string __errorMessage;

        public MuridContext(string pContstr)
        {
            __contstr = pContstr;
        }

        public void CreateMurid(Murid murid)
        {
            Murid murid1 = new Murid()
            {
                id_murid = murid.id_murid,
                nama = murid.nama,
                email = murid.email,
                absen = murid.absen
            };
            string query = string.Format(@"INSERT INTO users.murid (id_murid,nama,email,absen) VALUES (@id_murid, @nama, @email, @absen)");
            sqlDBHelper db = new sqlDBHelper(this.__contstr);
            try
            {
                using (NpgsqlCommand cmd = db.getNpgsqlCommand(query))
                {
                    cmd.Parameters.AddWithValue("@id_murid", murid1.id_murid);
                    cmd.Parameters.AddWithValue("@nama", murid1.nama);
                    cmd.Parameters.AddWithValue("@email", murid1.email);
                    cmd.Parameters.AddWithValue("@absen", murid1.absen);

                    cmd.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                __errorMessage = ex.Message;
            }
        }

        public List<Murid> ListMurid()
        {
            List<Murid> list1 = new List<Murid>();
            string query = string.Format(@"SELECT * FROM users.murid;");
            sqlDBHelper db = new sqlDBHelper(this.__contstr);
            try
            {
                NpgsqlCommand cmd = db.getNpgsqlCommand(query);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list1.Add(new Murid()
                    {
                        id_murid = int.Parse(reader["id_murid"].ToString()),
                        nama = reader["nama"].ToString(),
                        email = reader["email"].ToString(),
                        absen = int.Parse(reader["absen"].ToString())
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

        public void UpdateMurid(int id_murid, Murid murid)
        {
            string query = string.Format(@"UPDATE users.murid SET nama = @nama, email = @email, absen = @absen WHERE id_murid = @id_murid");
            sqlDBHelper db = new sqlDBHelper(this.__contstr);

            using (NpgsqlCommand cmd = db.getNpgsqlCommand(query))
            {
                cmd.Parameters.AddWithValue("id_murid", id_murid);
                cmd.Parameters.AddWithValue("nama", murid.nama);
                cmd.Parameters.AddWithValue("alamat", murid.email);
                cmd.Parameters.AddWithValue("email", murid.absen);
                cmd.ExecuteNonQuery();
            }

        }

        public void DeleteMurid(int id_murid)
        {
            string query = string.Format(@"DELETE FROM users.murid WHERE id_murid = @id_murid");
            sqlDBHelper db = new sqlDBHelper(this.__contstr);

            using (NpgsqlCommand cmd = db.getNpgsqlCommand(query))
            {
                cmd.Parameters.AddWithValue("id_murid", id_murid);

                cmd.ExecuteNonQuery();
            }

        }
    }
}

