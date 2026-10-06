using System;
using System.Collections.Generic;
using MySqlConnector;

namespace StudentRegistrationApp
{
    public class MahasiswaRepository
    {
        private readonly string _connStr =
            "Server=localhost;Port=3307;Database=studentdb;User ID=root;Password=;";

        public List<Mahasiswa> GetAll(string keyword = "")
        {
            var list = new List<Mahasiswa>();

            using var conn = new MySqlConnection(_connStr);
            conn.Open();

            using var cmd = new MySqlCommand(
                @"SELECT Id, Nrp, Nama, Prodi, JenisKelamin, TanggalLahir, Alamat, NoTelepon
                  FROM Mahasiswa
                  WHERE @kw = '' OR Nrp LIKE @like OR Nama LIKE @like
                  ORDER BY Id", conn);
            cmd.Parameters.AddWithValue("@kw", keyword);
            cmd.Parameters.AddWithValue("@like", "%" + keyword + "%");

            using var r = cmd.ExecuteReader();
            while (r.Read())
            {
                list.Add(new Mahasiswa
                {
                    Id = r.GetInt32(0),
                    Nrp = r.GetString(1),
                    Nama = r.GetString(2),
                    Prodi = r.GetString(3),
                    JenisKelamin = r.GetString(4),
                    TanggalLahir = r.GetDateTime(5),
                    Alamat = r.GetString(6),
                    Telepon = r.GetString(7)
                });
            }
            return list;
        }

        public int Count()
        {
            using var conn = new MySqlConnection(_connStr);
            conn.Open();
            using var cmd = new MySqlCommand("SELECT COUNT(*) FROM Mahasiswa", conn);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        public bool NrpExists(string nrp, int excludeId)
        {
            using var conn = new MySqlConnection(_connStr);
            conn.Open();
            using var cmd = new MySqlCommand(
                "SELECT COUNT(*) FROM Mahasiswa WHERE Nrp = @nrp AND Id <> @id", conn);
            cmd.Parameters.AddWithValue("@nrp", nrp);
            cmd.Parameters.AddWithValue("@id", excludeId);
            return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
        }

        public void Insert(Mahasiswa m)
        {
            using var conn = new MySqlConnection(_connStr);
            conn.Open();
            using var cmd = new MySqlCommand(
                @"INSERT INTO Mahasiswa (Nrp, Nama, Prodi, JenisKelamin, TanggalLahir, Alamat, NoTelepon)
                  VALUES (@nrp, @nama, @prodi, @jk, @tgl, @alamat, @telp)", conn);
            IsiParameter(cmd, m);
            cmd.ExecuteNonQuery();
        }

        public void Update(Mahasiswa m)
        {
            using var conn = new MySqlConnection(_connStr);
            conn.Open();
            using var cmd = new MySqlCommand(
                @"UPDATE Mahasiswa
                  SET Nrp = @nrp, Nama = @nama, Prodi = @prodi, JenisKelamin = @jk,
                      TanggalLahir = @tgl, Alamat = @alamat, NoTelepon = @telp
                  WHERE Id = @id", conn);
            IsiParameter(cmd, m);
            cmd.Parameters.AddWithValue("@id", m.Id);
            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            using var conn = new MySqlConnection(_connStr);
            conn.Open();
            using var cmd = new MySqlCommand("DELETE FROM Mahasiswa WHERE Id = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }

        private static void IsiParameter(MySqlCommand cmd, Mahasiswa m)
        {
            cmd.Parameters.AddWithValue("@nrp", m.Nrp);
            cmd.Parameters.AddWithValue("@nama", m.Nama);
            cmd.Parameters.AddWithValue("@prodi", m.Prodi);
            cmd.Parameters.AddWithValue("@jk", m.JenisKelamin);
            cmd.Parameters.AddWithValue("@tgl", m.TanggalLahir.Date);
            cmd.Parameters.AddWithValue("@alamat", m.Alamat);
            cmd.Parameters.AddWithValue("@telp", m.Telepon);
        }
    }
}