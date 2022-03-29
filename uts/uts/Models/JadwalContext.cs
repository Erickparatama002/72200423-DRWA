using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;

namespace uts.Models
{
    public class JadwalContext : DbContext
    {
        public JadwalContext(DbContextOptions<JadwalContext> options) : base(options)
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

        public List<JadwalItem> GetAlljadwal()
        {
            List<JadwalItem> list = new List<JadwalItem>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM jadwal_guru", conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new JadwalItem()
                        {
                            id_jadwal_guru = reader.GetInt32("id_jadwal_guru"),
                            tahun_akademik = reader.GetString("tahun_akademik"),
                            semester = reader.GetString("semester"),
                            id_guru = reader.GetInt32("id_guru"),
                            hari = reader.GetString("hari"),
                            id_kelas = reader.GetInt32("id_kelas"),
                            id_mapel = reader.GetInt32("id_mapel"),
                            jam_mulai = reader.GetString("jam_mulai"),
                            jam_selesai = reader.GetString("jam_selesai")
                        });
                    }
                }
            }
            return list;
        }

        public List<JadwalItem> Getjadwal(string id)
        {
            List<JadwalItem> list = new List<JadwalItem>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM jadwal_guru WHERE id_mapel = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new JadwalItem()
                        {
                            id_jadwal_guru = reader.GetInt32("id_jadwal_guru"),
                            tahun_akademik = reader.GetString("tahun_akademik"),
                            semester = reader.GetString("semester"),
                            id_guru = reader.GetInt32("id_guru"),
                            hari = reader.GetString("hari"),
                            id_kelas = reader.GetInt32("id_kelas"),
                            id_mapel = reader.GetInt32("id_mapel"),
                            jam_mulai = reader.GetString("jam_mulai"),
                            jam_selesai = reader.GetString("jam_selesai")
                        });
                    }
                }
            }
            return list;
        }

        public List<JadwalItem> GetJadwalNIP(string nip)
        {
            List<JadwalItem> list = new List<JadwalItem>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT jadwal_guru.id_jadwal_guru, jadwal_guru.tahun_akademik," +
                    " jadwal_guru.semester, jadwal_guru.id_guru, jadwal_guru.hari, jadwal_guru.id_kelas, jadwal_guru.id_mapel," +
                    " jadwal_guru.jam_mulai, jadwal_guru.jam_selesai, guru.nip FROM jadwal_guru INNER JOIN guru ON guru.id_guru=jadwal_guru.id_guru WHERE guru.nip = @nip", conn);
                cmd.Parameters.AddWithValue("@nip", nip);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new JadwalItem()
                        {
                            id_jadwal_guru = reader.GetInt32("id_jadwal_guru"),
                            tahun_akademik = reader.GetString("tahun_akademik"),
                            semester = reader.GetString("semester"),
                            id_guru = reader.GetInt32("id_guru"),
                            hari = reader.GetString("hari"),
                            id_kelas = reader.GetInt32("id_kelas"),
                            id_mapel = reader.GetInt32("id_mapel"),
                            jam_mulai = reader.GetString("jam_mulai"),
                            jam_selesai = reader.GetString("jam_selesai"),
                            nip = reader.GetString("nip")
                        });
                    }
                }
            }
            return list;
        }

        public JadwalItem Addjadwal(JadwalItem ki)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("insert into guru (tahun_akademik,semester,id_guru,hari,id_kelas,id_mapel,jam_mulai,jam_selesai) " +
                    "values (@tahun_akademik,@semester,@id_guru,@hari,@id_kelas,@id_mapel,@jam_mulai,@jam_selesai)", conn);
                cmd.Parameters.AddWithValue("@tahun_akademik", ki.tahun_akademik);
                cmd.Parameters.AddWithValue("@semester", ki.semester);
                cmd.Parameters.AddWithValue("@id_guru", ki.id_guru);
                cmd.Parameters.AddWithValue("@hari", ki.hari);
                cmd.Parameters.AddWithValue("@id_kelas", ki.id_kelas);
                cmd.Parameters.AddWithValue("@id_mapel", ki.id_mapel);
                cmd.Parameters.AddWithValue("@jam_mulai", ki.jam_mulai);
                cmd.Parameters.AddWithValue("@jam_selesai", ki.jam_selesai);

                cmd.ExecuteReader();
            }
            return ki;
        }
    }
}
