using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;

namespace uts.Models
{
    public class MapelContext : DbContext
    {
        public MapelContext(DbContextOptions<MapelContext> options) : base(options)
        {
        }
        public string ConnectionString { get; set; }

        //public KelasContext(string connectionString)


        private MySqlConnection GetConnection()
        {
            return new MySqlConnection("Server = localhost; Database = kelas; Uid = root; Pwd =");
        }

        public List<MapelItem> GetAllmapel()
        {
            List<MapelItem> list = new List<MapelItem>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM mapel", conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new MapelItem()
                        {
                            id_mapel = reader.GetInt32("id_mapel"),
                            nama_mapel = reader.GetString("nama_mapel"),
                            deskripsi = reader.GetString("deskripsi")
                 
                        });
                    }
                }
            }
            return list;
        }

        public List<MapelItem> Getmapel(string id)
        {
            List<MapelItem> list = new List<MapelItem>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM mapel WHERE id_mapel = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new MapelItem()
                        {
                            id_mapel = reader.GetInt32("id_mapel"),
                            nama_mapel = reader.GetString("nama_mapel"),
                            deskripsi = reader.GetString("deskripsi")
                        });
                    }
                }
            }
            return list;
        }

        public MapelItem AddMapel(MapelItem ki)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT into mapel (nama_mapel,deskripsi) VALUES (@nama_mapel,@deskripsi)", conn);
                cmd.Parameters.AddWithValue("@nama_mapel", ki.nama_mapel);
                cmd.Parameters.AddWithValue("@deskripsi", ki.deskripsi);
                

                cmd.ExecuteReader();
            }
            return ki;
        }
    }
}
