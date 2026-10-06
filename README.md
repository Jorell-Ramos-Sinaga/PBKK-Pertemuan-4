# Laporan Student Registration App

| Nama | NRP |
|---|---|
| Jorell Ramos Sinaga | 5025241202 |

---

## 1. MainWindow.xaml

File ini berisi seluruh tampilan aplikasi.

```xml
<Window x:Class="StudentRegistrationApp.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        Title="Student Registration App"
        Height="650" Width="1050"
        MinHeight="600" MinWidth="950"
        WindowStartupLocation="CenterScreen"
        Background="#EAF1FB">

    <Window.Resources>
        <Style x:Key="RoundButton" TargetType="Button">
            <Setter Property="Foreground" Value="White"/>
            <Setter Property="FontWeight" Value="SemiBold"/>
            <Setter Property="Cursor" Value="Hand"/>
            <Setter Property="Template">
                <Setter.Value>
                    <ControlTemplate TargetType="Button">
                        <Border x:Name="bd" Background="{TemplateBinding Background}"
                                CornerRadius="6" Padding="{TemplateBinding Padding}">
                            <ContentPresenter HorizontalAlignment="Center"
                                              VerticalAlignment="Center"/>
                        </Border>
                        <ControlTemplate.Triggers>
                            <Trigger Property="IsMouseOver" Value="True">
                                <Setter TargetName="bd" Property="Opacity" Value="0.85"/>
                            </Trigger>
                            <Trigger Property="IsEnabled" Value="False">
                                <Setter TargetName="bd" Property="Opacity" Value="0.4"/>
                            </Trigger>
                        </ControlTemplate.Triggers>
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
        </Style>

        <Style x:Key="PlaceholderBox" TargetType="TextBox">
            <Setter Property="Padding" Value="6,0"/>
            <Setter Property="VerticalContentAlignment" Value="Center"/>
            <Setter Property="Template">
                <Setter.Value>
                    <ControlTemplate TargetType="TextBox">
                        <Border Background="White" BorderBrush="#C9D3E3"
                                BorderThickness="1" CornerRadius="5">
                            <Grid>
                                <ScrollViewer x:Name="PART_ContentHost"
                                              Margin="{TemplateBinding Padding}"
                                              VerticalAlignment="{TemplateBinding VerticalContentAlignment}"/>
                                <TextBlock x:Name="ph" Text="{TemplateBinding Tag}"
                                           Foreground="#A0A8B8" Margin="8,0,0,0"
                                           VerticalAlignment="{TemplateBinding VerticalContentAlignment}"
                                           IsHitTestVisible="False" Visibility="Collapsed"/>
                            </Grid>
                        </Border>
                        <ControlTemplate.Triggers>
                            <Trigger Property="Text" Value="">
                                <Setter TargetName="ph" Property="Visibility" Value="Visible"/>
                            </Trigger>
                        </ControlTemplate.Triggers>
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
        </Style>

        <Style x:Key="PanelTitle" TargetType="TextBlock">
            <Setter Property="FontSize" Value="15"/>
            <Setter Property="FontWeight" Value="Bold"/>
            <Setter Property="Foreground" Value="#1F3C88"/>
            <Setter Property="Margin" Value="0,0,0,12"/>
        </Style>
    </Window.Resources>

    <Grid Margin="15">
        <Grid.RowDefinitions>
            <RowDefinition Height="Auto"/>
            <RowDefinition Height="*"/>
        </Grid.RowDefinitions>

        <Border Grid.Row="0" Background="White" CornerRadius="10" Padding="20,12" Margin="0,0,0,12">
            <Grid>
                <StackPanel Orientation="Horizontal">
                    <TextBlock Text="&#x1F393;" FontSize="40" VerticalAlignment="Center" Margin="0,0,15,0"/>
                    <StackPanel VerticalAlignment="Center">
                        <TextBlock Text="STUDENT REGISTRATION" FontSize="24"
                                   FontWeight="Bold" Foreground="#1F3C88"/>
                        <TextBlock Text="Kelola Data Mahasiswa dengan Mudah" Foreground="#555"/>
                    </StackPanel>
                </StackPanel>
                <StackPanel Orientation="Horizontal" HorizontalAlignment="Right">
                    <TextBlock Text="&#x1F4D6;" FontSize="34" VerticalAlignment="Center" Margin="0,0,10,0"/>
                    <StackPanel VerticalAlignment="Center">
                        <TextBlock Text="Knowledge Today" Foreground="#1F3C88"/>
                        <TextBlock Text="A Better Tomorrow" Foreground="#1F3C88"/>
                    </StackPanel>
                </StackPanel>
            </Grid>
        </Border>

        <Grid Grid.Row="1">
            <Grid.ColumnDefinitions>
                <ColumnDefinition Width="340"/>
                <ColumnDefinition Width="12"/>
                <ColumnDefinition Width="*"/>
            </Grid.ColumnDefinitions>

            <Border Grid.Column="0" Background="White" CornerRadius="10" Padding="15">
                <Grid>
                    <Grid.RowDefinitions>
                        <RowDefinition Height="Auto"/>
                        <RowDefinition Height="Auto"/>
                        <RowDefinition Height="Auto"/>
                        <RowDefinition Height="Auto"/>
                        <RowDefinition Height="Auto"/>
                        <RowDefinition Height="Auto"/>
                        <RowDefinition Height="Auto"/>
                        <RowDefinition Height="*"/>
                        <RowDefinition Height="Auto"/>
                    </Grid.RowDefinitions>
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition Width="105"/>
                        <ColumnDefinition Width="*"/>
                    </Grid.ColumnDefinitions>

                    <TextBlock Grid.Row="0" Grid.ColumnSpan="2" Text="&#x1F4DD; Form Mahasiswa"
                               Style="{StaticResource PanelTitle}"/>

                    <TextBlock Grid.Row="1" Text="NRP" VerticalAlignment="Center"/>
                    <TextBox Grid.Row="1" Grid.Column="1" x:Name="txtNrp" Height="32"
                             Margin="0,0,0,10" Tag="Masukkan NRP"
                             Style="{StaticResource PlaceholderBox}"/>

                    <TextBlock Grid.Row="2" Text="Nama Mahasiswa" VerticalAlignment="Center"/>
                    <TextBox Grid.Row="2" Grid.Column="1" x:Name="txtNama" Height="32"
                             Margin="0,0,0,10" Tag="Masukkan nama mahasiswa"
                             Style="{StaticResource PlaceholderBox}"/>

                    <TextBlock Grid.Row="3" Text="Program Studi" VerticalAlignment="Center"/>
                    <ComboBox Grid.Row="3" Grid.Column="1" x:Name="cmbProdi" Height="32"
                              Margin="0,0,0,10" VerticalContentAlignment="Center">
                        <ComboBoxItem Content="Teknik Informatika"/>
                        <ComboBoxItem Content="Sistem Informasi"/>
                        <ComboBoxItem Content="Manajemen"/>
                        <ComboBoxItem Content="Akuntansi"/>
                    </ComboBox>

                    <TextBlock Grid.Row="4" Text="Jenis Kelamin" VerticalAlignment="Center"/>
                    <StackPanel Grid.Row="4" Grid.Column="1" Orientation="Horizontal" Margin="0,0,0,10">
                        <RadioButton x:Name="rbLaki" Content="Laki-laki" Margin="0,0,20,0"
                                     VerticalAlignment="Center"/>
                        <RadioButton x:Name="rbPerempuan" Content="Perempuan"
                                     VerticalAlignment="Center"/>
                    </StackPanel>

                    <TextBlock Grid.Row="5" Text="Tanggal Lahir" VerticalAlignment="Center"/>
                    <DatePicker Grid.Row="5" Grid.Column="1" x:Name="dpTanggalLahir" Height="32"
                                Margin="0,0,0,10" VerticalContentAlignment="Center"/>

                    <TextBlock Grid.Row="6" Text="Alamat" VerticalAlignment="Top" Margin="0,8,0,0"/>
                    <TextBox Grid.Row="6" Grid.Column="1" x:Name="txtAlamat" Height="75"
                             Margin="0,0,0,10" Tag="Masukkan alamat"
                             TextWrapping="Wrap" AcceptsReturn="True"
                             VerticalContentAlignment="Top"
                             Style="{StaticResource PlaceholderBox}"/>

                    <TextBlock Grid.Row="7" Text="Nomor Telepon" VerticalAlignment="Top" Margin="0,8,0,0"/>
                    <TextBox Grid.Row="7" Grid.Column="1" x:Name="txtTelepon" Height="32"
                             VerticalAlignment="Top" MaxLength="15"
                             Tag="Masukkan nomor telepon"
                             Style="{StaticResource PlaceholderBox}"/>

                    <UniformGrid Grid.Row="8" Grid.ColumnSpan="2" Columns="3" Margin="0,10,0,0">
                        <Button x:Name="btnSimpan" Content="&#x1F4BE; Simpan" Height="38" Margin="0,0,5,0"
                                Background="#1E9E57" Style="{StaticResource RoundButton}"
                                Click="BtnSimpan_Click"/>
                        <Button x:Name="btnUpdate" Content="&#x270F; Update" Height="38" Margin="2,0,2,0"
                                Background="#1E6FEB" Style="{StaticResource RoundButton}"
                                IsEnabled="False" Click="BtnUpdate_Click"/>
                        <Button x:Name="btnBersihkan" Content="&#x1F9F9; Bersihkan" Height="38" Margin="5,0,0,0"
                                Background="#7A8599" Style="{StaticResource RoundButton}"
                                Click="BtnBersihkan_Click"/>
                    </UniformGrid>
                </Grid>
            </Border>

            <Border Grid.Column="2" Background="White" CornerRadius="10" Padding="15">
                <Grid>
                    <Grid.RowDefinitions>
                        <RowDefinition Height="Auto"/>
                        <RowDefinition Height="Auto"/>
                        <RowDefinition Height="*"/>
                    </Grid.RowDefinitions>

                    <TextBlock Grid.Row="0" Text="&#x1F4CB; Data Mahasiswa" Style="{StaticResource PanelTitle}"/>

                    <Grid Grid.Row="1" Margin="0,0,0,12">
                        <Grid.ColumnDefinitions>
                            <ColumnDefinition Width="*"/>
                            <ColumnDefinition Width="Auto"/>
                            <ColumnDefinition Width="Auto"/>
                        </Grid.ColumnDefinitions>

                        <TextBox x:Name="txtCari" Grid.Column="0" Height="36"
                                 Tag="&#x1F50D;  Cari NRP atau nama mahasiswa..."
                                 Style="{StaticResource PlaceholderBox}"
                                 TextChanged="TxtCari_TextChanged"/>
                        <Button Grid.Column="1" Content="Cari" Width="70" Height="36"
                                Margin="8,0,0,0" Background="#1E6FEB"
                                Style="{StaticResource RoundButton}" Click="BtnCari_Click"/>

                        <Border Grid.Column="2" Margin="12,0,0,0" Padding="12,0"
                                Background="#E6F6EC" BorderBrush="#7CCB9A"
                                BorderThickness="1" CornerRadius="6">
                            <StackPanel Orientation="Horizontal" VerticalAlignment="Center">
                                <TextBlock Text="&#x1F465;" FontSize="18" Margin="0,0,8,0"/>
                                <TextBlock Text="Jumlah Mahasiswa: " VerticalAlignment="Center"/>
                                <TextBlock x:Name="lblJumlah" Text="0" FontSize="18"
                                           FontWeight="Bold" VerticalAlignment="Center"/>
                            </StackPanel>
                        </Border>
                    </Grid>

                    <DataGrid Grid.Row="2" x:Name="dgMahasiswa"
                              AutoGenerateColumns="False" IsReadOnly="True"
                              CanUserAddRows="False" SelectionMode="Single"
                              HeadersVisibility="Column" GridLinesVisibility="Horizontal"
                              HorizontalGridLinesBrush="#E3E8F0" Background="White"
                              RowHeight="38" ColumnHeaderHeight="34"
                              BorderBrush="#C9D3E3">
                        <DataGrid.ColumnHeaderStyle>
                            <Style TargetType="DataGridColumnHeader">
                                <Setter Property="Background" Value="#E8EEF9"/>
                                <Setter Property="FontWeight" Value="Bold"/>
                                <Setter Property="HorizontalContentAlignment" Value="Center"/>
                                <Setter Property="BorderBrush" Value="#C9D3E3"/>
                                <Setter Property="BorderThickness" Value="0,0,1,1"/>
                            </Style>
                        </DataGrid.ColumnHeaderStyle>
                        <DataGrid.Columns>
                            <DataGridTextColumn Header="No" Binding="{Binding No}" Width="40"/>
                            <DataGridTextColumn Header="NRP" Binding="{Binding Nrp}" Width="80"/>
                            <DataGridTextColumn Header="Nama" Binding="{Binding Nama}" Width="*"/>
                            <DataGridTextColumn Header="Prodi" Binding="{Binding ProdiKode}" Width="50"/>
                            <DataGridTextColumn Header="JK" Binding="{Binding JK}" Width="40"/>
                            <DataGridTextColumn Header="Tgl Lahir"
                                                Binding="{Binding TanggalLahir, StringFormat=dd/MM/yyyy}"
                                                Width="90"/>
                            <DataGridTextColumn Header="No Telepon" Binding="{Binding Telepon}" Width="110"/>
                            <DataGridTemplateColumn Header="Aksi" Width="90">
                                <DataGridTemplateColumn.CellTemplate>
                                    <DataTemplate>
                                        <StackPanel Orientation="Horizontal" HorizontalAlignment="Center">
                                            <Button Content="&#x270F;" Width="30" Height="28" Margin="0,0,5,0"
                                                    Background="#1E6FEB" ToolTip="Edit"
                                                    Style="{StaticResource RoundButton}"
                                                    Click="BtnEdit_Click"/>
                                            <Button Content="&#x1F5D1;" Width="30" Height="28"
                                                    Background="#E03B3B" ToolTip="Hapus"
                                                    Style="{StaticResource RoundButton}"
                                                    Click="BtnHapus_Click"/>
                                        </StackPanel>
                                    </DataTemplate>
                                </DataGridTemplateColumn.CellTemplate>
                            </DataGridTemplateColumn>
                        </DataGrid.Columns>
                    </DataGrid>
                </Grid>
            </Border>
        </Grid>
    </Grid>
</Window>
```

### Penjelasan

**Window dan Resources**
- Bagian atas mengatur judul, ukuran, posisi window di tengah layar, dan warna latar biru muda.
- Di `Window.Resources` ada 3 style yang dipakai berulang:
  - `RoundButton`: tombol dengan sudut membulat, efek transparan saat di-hover, dan memudar saat dinonaktifkan.
  - `PlaceholderBox`: TextBox dengan teks petunjuk (placeholder). Teksnya diambil dari properti `Tag`, dan otomatis hilang saat kotak diisi.
  - `PanelTitle`: gaya judul untuk tiap panel.
- Karakter ikon ditulis dengan kode entity (misalnya `&#x1F393;`) supaya tampil sebagai ikon di aplikasi.

**Layout utama**
- `Grid` luar dibagi 2 baris: baris atas untuk header, baris bawah untuk isi.
- Baris isi dibagi 3 kolom: panel form (lebar 340), jarak 12, dan panel data (sisa lebar).

**Header**
- Sisi kiri berisi judul "STUDENT REGISTRATION" dan subjudul, sisi kanan berisi tagline "Knowledge Today, A Better Tomorrow".

**Panel Form Mahasiswa (kiri)**
- Berupa `Grid` dengan 2 kolom (label dan input). Kontrol yang diberi `x:Name` dipakai oleh kode C#:

| Kontrol | Nama | Fungsi |
|---|---|---|
| TextBox | `txtNrp` | Input NRP |
| TextBox | `txtNama` | Input nama |
| ComboBox | `cmbProdi` | Pilih program studi |
| RadioButton | `rbLaki`, `rbPerempuan` | Pilih jenis kelamin |
| DatePicker | `dpTanggalLahir` | Pilih tanggal lahir |
| TextBox | `txtAlamat` | Input alamat (multi-baris) |
| TextBox | `txtTelepon` | Input nomor telepon (maks. 15 karakter) |
| Button | `btnSimpan`, `btnUpdate`, `btnBersihkan` | Simpan, ubah, dan reset form |

- `btnUpdate` awalnya nonaktif (`IsEnabled="False"`), baru aktif saat mode edit.
- Ketiga tombol disusun dengan `UniformGrid` 3 kolom agar lebarnya sama.

**Panel Data Mahasiswa (kanan)**
- `txtCari` dan tombol Cari untuk pencarian. Event `TextChanged` membuat hasil tersaring otomatis saat mengetik.
- `lblJumlah` di dalam kotak hijau menampilkan total mahasiswa.
- `dgMahasiswa` adalah tabel data. Kolomnya diikat (`Binding`) ke properti class `Mahasiswa` (No, Nrp, Nama, ProdiKode, JK, TanggalLahir, Telepon).
- Kolom "Aksi" memakai `DataGridTemplateColumn` yang berisi tombol edit dan hapus di setiap baris, dengan event `BtnEdit_Click` dan `BtnHapus_Click`.

---

## 2. MainWindow.xaml.cs

File ini berisi logika aplikasi: class data `Mahasiswa`, event tombol, validasi, dan pengisian tabel.

```csharp
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
```

### Penjelasan

**Class `Mahasiswa`**
- Model data satu mahasiswa. Properti `Id` sesuai primary key di database, sedangkan `No` hanya nomor urut untuk tampilan tabel.
- `JK` otomatis menjadi "L" atau "P" dari `JenisKelamin`.
- `ProdiKode` mengubah nama program studi menjadi kode singkat (TI, SI, MN, AK) agar kolom Prodi di tabel ringkas.

**Field dan constructor di `MainWindow`**
- `_repo` adalah objek `MahasiswaRepository` untuk mengakses database.
- `_sedangDiedit` menyimpan data yang sedang diedit. Jika `null`, berarti form dalam mode tambah data.
- Constructor mengisi tanggal lahir dengan hari ini, lalu memanggil `RefreshGrid()` untuk menampilkan data dari database.

**Event handler tombol**
- `BtnSimpan_Click`: membaca dan memvalidasi form lewat `BacaForm`, menyimpan ke database, lalu menyegarkan tabel dan mengosongkan form.
- `BtnEdit_Click`: mengambil data dari baris yang diklik (lewat `DataContext` tombol), memasukkannya ke form, lalu menonaktifkan Simpan dan mengaktifkan Update.
- `BtnUpdate_Click`: memvalidasi form, memakai `Id` dari data yang diedit, lalu memperbarui database.
- `BtnHapus_Click`: menampilkan dialog konfirmasi Yes/No. Data hanya dihapus jika pengguna memilih Yes.
- `BtnBersihkan_Click`: mengosongkan form dan kembali ke mode tambah data.
- `BtnCari_Click` dan `TxtCari_TextChanged`: memanggil `RefreshGrid()` sehingga tabel tersaring sesuai kata kunci. Pengecekan `IsLoaded` mencegah error saat window baru dibuat.

**Method pendukung**
- `BacaForm`: mengambil isi form dan memvalidasi: semua field wajib diisi, panjang karakter dibatasi, telepon hanya angka, dan NRP tidak boleh ganda (dicek ke database lewat `NrpExists`). Jika valid, hasilnya dikembalikan sebagai objek `Mahasiswa`.
- `BersihkanForm`: mereset semua input ke kondisi awal dan mengembalikan tombol Simpan/Update ke status semula.
- `RefreshGrid`: mengambil data dari database (dengan filter pencarian), memberi nomor urut, mengisi tabel, dan memperbarui angka jumlah mahasiswa. Angka jumlah selalu total seluruh data, bukan hasil pencarian.
- `TampilkanErrorDb`: menampilkan pesan error dalam dialog jika koneksi atau query database gagal, sehingga aplikasi tidak langsung berhenti.

---

## 3. MahasiswaRepository.cs

File ini khusus mengurus akses ke database MySQL. Dibuat lewat klik kanan project, Add, Class.

```csharp
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
```

### Penjelasan

**Connection string**
- `_connStr` berisi alamat database: server `localhost`, port `3307` (port MySQL XAMPP yang sudah diganti dari 3306), database `studentdb`, user `root` tanpa password (bawaan XAMPP).
- Library yang dipakai adalah `MySqlConnector` (dipasang lewat NuGet).

**Pola yang dipakai di setiap method**
- Membuka koneksi (`MySqlConnection`), membuat perintah SQL (`MySqlCommand`), lalu menjalankannya. Keyword `using` memastikan koneksi otomatis ditutup setelah selesai.
- Semua nilai dikirim lewat parameter (`@nrp`, `@nama`, dan seterusnya), tidak disambung langsung ke string SQL, sehingga aman dari SQL injection.

**Method-method**

| Method | Fungsi |
|---|---|
| `GetAll(keyword)` | Mengambil semua data mahasiswa. Jika ada kata kunci, data difilter berdasarkan NRP atau nama dengan `LIKE`. Hasilnya diubah menjadi daftar objek `Mahasiswa`. |
| `Count()` | Menghitung total data dengan `COUNT(*)` untuk kotak "Jumlah Mahasiswa". |
| `NrpExists(nrp, excludeId)` | Mengecek apakah NRP sudah dipakai data lain. Parameter `excludeId` dipakai agar saat edit, data itu sendiri tidak dianggap duplikat. |
| `Insert(m)` | Menambah data baru dengan `INSERT`. |
| `Update(m)` | Mengubah data yang `Id`-nya cocok dengan `UPDATE`. |
| `Delete(id)` | Menghapus data berdasarkan `Id` dengan `DELETE`. |
| `IsiParameter` | Method bantu privat untuk mengisi parameter yang sama pada `Insert` dan `Update`, supaya kode tidak berulang. |
