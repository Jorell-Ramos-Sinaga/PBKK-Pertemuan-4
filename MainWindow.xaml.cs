using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace StudentRegistrationApp
{
    public class Mahasiswa
    {
        public int Id { get; set; }
        public int No { get; set; }
        public string Nrp { get; set; }
        public string Nama { get; set; }
        public string Prodi { get; set; }
        public string JenisKelamin { get; set; }
        public DateTime TanggalLahir { get; set; }
        public string Alamat { get; set; }
        public string Telepon { get; set; }

        public string JK => JenisKelamin == "Laki-laki" ? "L" : "P";

        public string ProdiKode => Prodi switch
        {
            "Teknik Informatika" => "TI",
            "Sistem Informasi" => "SI",
            "Manajemen" => "MN",
            "Akuntansi" => "AK",
            _ => Prodi
        };
    }

    public partial class MainWindow : Window
    {
        private readonly MahasiswaRepository _repo = new MahasiswaRepository();
        private Mahasiswa _sedangDiedit = null;

        public MainWindow()
        {
            InitializeComponent();
            dpTanggalLahir.SelectedDate = DateTime.Today;
            RefreshGrid();
        }

        private void BtnSimpan_Click(object sender, RoutedEventArgs e)
        {
            if (!BacaForm(out Mahasiswa baru)) return;

            try
            {
                _repo.Insert(baru);
            }
            catch (Exception ex)
            {
                TampilkanErrorDb(ex);
                return;
            }

            RefreshGrid();
            BersihkanForm();
            MessageBox.Show("Data berhasil disimpan.", "Sukses",
                MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (_sedangDiedit == null) return;
            if (!BacaForm(out Mahasiswa hasil)) return;

            hasil.Id = _sedangDiedit.Id;

            try
            {
                _repo.Update(hasil);
            }
            catch (Exception ex)
            {
                TampilkanErrorDb(ex);
                return;
            }

            RefreshGrid();
            BersihkanForm();
            MessageBox.Show("Data berhasil diperbarui.", "Sukses",
                MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void BtnBersihkan_Click(object sender, RoutedEventArgs e)
        {
            BersihkanForm();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (((Button)sender).DataContext is not Mahasiswa m) return;

            _sedangDiedit = m;
            txtNrp.Text = m.Nrp;
            txtNama.Text = m.Nama;
            txtAlamat.Text = m.Alamat;
            txtTelepon.Text = m.Telepon;
            dpTanggalLahir.SelectedDate = m.TanggalLahir;
            rbLaki.IsChecked = m.JenisKelamin == "Laki-laki";
            rbPerempuan.IsChecked = m.JenisKelamin == "Perempuan";

            foreach (ComboBoxItem item in cmbProdi.Items)
            {
                if (item.Content.ToString() == m.Prodi)
                {
                    cmbProdi.SelectedItem = item;
                    break;
                }
            }

            btnSimpan.IsEnabled = false;
            btnUpdate.IsEnabled = true;
        }

        private void BtnHapus_Click(object sender, RoutedEventArgs e)
        {
            if (((Button)sender).DataContext is not Mahasiswa m) return;

            var hasil = MessageBox.Show(
                $"Yakin ingin menghapus data {m.Nama} ({m.Nrp})?",
                "Konfirmasi Hapus",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (hasil != MessageBoxResult.Yes) return;

            try
            {
                _repo.Delete(m.Id);
            }
            catch (Exception ex)
            {
                TampilkanErrorDb(ex);
                return;
            }

            if (_sedangDiedit?.Id == m.Id) BersihkanForm();
            RefreshGrid();
        }

        private void BtnCari_Click(object sender, RoutedEventArgs e)
        {
            RefreshGrid();
        }

        private void TxtCari_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (IsLoaded) RefreshGrid();
        }

        private bool BacaForm(out Mahasiswa m)
        {
            m = null;

            string nrp = txtNrp.Text.Trim();
            string nama = txtNama.Text.Trim();
            string alamat = txtAlamat.Text.Trim();
            string telepon = txtTelepon.Text.Trim();
            string prodi = (cmbProdi.SelectedItem as ComboBoxItem)?.Content?.ToString();
            string gender = rbLaki.IsChecked == true ? "Laki-laki"
                          : rbPerempuan.IsChecked == true ? "Perempuan" : "";

            if (nrp == "" || nama == "" || alamat == "" || telepon == "" ||
                prodi == null || gender == "" || dpTanggalLahir.SelectedDate == null)
            {
                MessageBox.Show("Semua data harus diisi!", "Peringatan",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (nrp.Length > 20 || nama.Length > 100 || alamat.Length > 200)
            {
                MessageBox.Show("NRP maks. 20, nama maks. 100, dan alamat maks. 200 karakter.",
                    "Peringatan", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (!telepon.All(char.IsDigit))
            {
                MessageBox.Show("Nomor telepon hanya boleh berisi angka!", "Peringatan",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            try
            {
                if (_repo.NrpExists(nrp, _sedangDiedit?.Id ?? 0))
                {
                    MessageBox.Show("NRP sudah terdaftar!", "Peringatan",
                        MessageBoxButton.OK, MessageBoxImage.Warning);
                    return false;
                }
            }
            catch (Exception ex)
            {
                TampilkanErrorDb(ex);
                return false;
            }

            m = new Mahasiswa
            {
                Nrp = nrp,
                Nama = nama,
                Prodi = prodi,
                JenisKelamin = gender,
                TanggalLahir = dpTanggalLahir.SelectedDate.Value,
                Alamat = alamat,
                Telepon = telepon
            };
            return true;
        }

        private void BersihkanForm()
        {
            _sedangDiedit = null;
            txtNrp.Clear();
            txtNama.Clear();
            txtAlamat.Clear();
            txtTelepon.Clear();
            cmbProdi.SelectedIndex = -1;
            rbLaki.IsChecked = false;
            rbPerempuan.IsChecked = false;
            dpTanggalLahir.SelectedDate = DateTime.Today;
            btnSimpan.IsEnabled = true;
            btnUpdate.IsEnabled = false;
            dgMahasiswa.SelectedItem = null;
        }

        private void RefreshGrid()
        {
            try
            {
                var tampil = _repo.GetAll(txtCari.Text.Trim());

                for (int i = 0; i < tampil.Count; i++)
                    tampil[i].No = i + 1;

                dgMahasiswa.ItemsSource = null;
                dgMahasiswa.ItemsSource = tampil;
                lblJumlah.Text = _repo.Count().ToString();
            }
            catch (Exception ex)
            {
                TampilkanErrorDb(ex);
            }
        }

        private void TampilkanErrorDb(Exception ex)
        {
            MessageBox.Show(
                "Gagal terhubung/mengakses database:\n\n" + ex.Message,
                "Error Database", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}