using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;

namespace uts.Models
{
    public class GuruContext : DbContext
    {
        public GuruContext(DbContextOptions<GuruContext> options) : base(options)
        {
        }
        public string ConnectionString { get; set; }

        //public KelasContext(string connectionString)
        //{
        //    this.ConnectionString = connectionString;
        //}

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection("Server = localhost; Database = kelas; Uid = root; Pwd =");
        }

        public List<GuruItem> GetAllguru()
        {
            List<GuruItem> list = new List<GuruItem>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM guru", conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new GuruItem()
                        {
                            id_guru = reader.GetInt32("id_guru"),
                            rfid = reader.GetString("rfid"),
                            nip = reader.GetString("nip"),
                            nama_guru = reader.GetString("nama_guru"),
                            alamat = reader.GetString("alamat"),
                            status_guru = reader.GetInt32("status_guru")
                        });
                    }
                }
            }
            return list;
        }

        public List<GuruItem> Getguru(string id)
        {
            List<GuruItem> list = new List<GuruItem>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM guru WHERE id_guru = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new GuruItem()
                        {
                            id_guru = reader.GetInt32("id_guru"),
                            rfid = reader.GetString("rfid"),
                            nip = reader.GetString("nip"),
                            nama_guru = reader.GetString("nama_guru"),
                            alamat = reader.GetString("alamat"),
                            status_guru = reader.GetInt32("status_guru")
                        });
                    }
                }
            }
            return list;
        }

        public GuruItem Addguru(GuruItem ki)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("insert into guru(rfid,nip,nama_guru,alamat_guru,status) values (@rfid,@nip,@nama_guru,@alamat,@status_guru)", conn);
                cmd.Parameters.AddWithValue("@rfid", ki.rfid);
                cmd.Parameters.AddWithValue("@nip", ki.nip);
                cmd.Parameters.AddWithValue("@nama_guru", ki.nama_guru);
                cmd.Parameters.AddWithValue("@alamat", ki.alamat);
                cmd.Parameters.AddWithValue("@status_guru", ki.status_guru);

                cmd.ExecuteReader();
            }
            return ki;
        }
    }
}
