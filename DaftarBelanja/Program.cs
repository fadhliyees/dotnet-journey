using System.ComponentModel.DataAnnotations;

void TampilkanMenu()
{
    Console.WriteLine("==================");
    Console.WriteLine("| Daftar Belanja |");
    Console.WriteLine("==================");
    Console.WriteLine("1. Tambah Barang");
    Console.WriteLine("2. Lihat Daftar");
    Console.WriteLine("3. Hapus Barang");
    Console.WriteLine("4. Cari Barang");
    Console.WriteLine("5. Urutkan Daftar");
    Console.WriteLine("6. Hapus Semua Barang");
    Console.WriteLine("7. Keluar");
}

void TambahBarang(List<Item> daftarBelanja)
{
    Console.Write("Nama Barang: ");
    string? nama = Console.ReadLine();
    Console.Write("Jumlah: ");
    string? jumlahInput = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(nama) && int.TryParse(jumlahInput, out int jumlah))
    {
        daftarBelanja.Add(new Item { Nama = nama, Jumlah = jumlah });
        Console.WriteLine($"\nBarang '{nama}' berhasil ditambahkan.\n");
    }
    else
    {
        Console.WriteLine("Input tidak valid.\n");
    }
}

void LihatDaftar(List<Item> daftarBelanja)
{
    if (daftarBelanja.Count == 0)
    {
        Console.WriteLine("Daftar belanja kosong.\n");
    }
    else
    {
        Console.WriteLine("=== Daftar Belanja ===");
        for (int i = 0; i < daftarBelanja.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {daftarBelanja[i].Nama} - Jumlah: {daftarBelanja[i].Jumlah}");
        }
    }
}

void HapusBarang(List<Item> daftarBelanja)
{
    Console.Write("Masukkan nomor barang yang ingin dihapus: ");
    string? input = Console.ReadLine();

    // 1. Validasi nomor indeks barang
    if (int.TryParse(input, out int index) && index > 0 && index <= daftarBelanja.Count)
    {
        Item barang = daftarBelanja[index - 1];

        // 2. Minta input jumlah yang ingin dihapus
        Console.Write($"Masukkan jumlah '{barang.Nama}' yang ingin dihapus (Jumlah saat ini: {barang.Jumlah}): ");
        string? inputJumlah = Console.ReadLine();

        if (int.TryParse(inputJumlah, out int jumlahHapus) && jumlahHapus > 0)
        {
            // 3. Logika pengurangan atau penghapusan total
            if (jumlahHapus >= barang.Jumlah)
            {
                // Jika jumlah yang dihapus sama atau lebih besar dari stok, hapus item dari list
                daftarBelanja.RemoveAt(index - 1);
                Console.WriteLine($"Semua barang '{barang.Nama}' berhasil dihapus dari daftar.\n");
            }
            else
            {
                // Jika hanya dikurangi sebagian
                barang.Jumlah -= jumlahHapus;
                Console.WriteLine($"{jumlahHapus} unit '{barang.Nama}' berhasil dikurangi. Sisa: {barang.Jumlah}.\n");
            }
        }
        else
        {
            Console.WriteLine("Jumlah barang tidak valid.\n");
        }
    }
    else
    {
        Console.WriteLine("Nomor barang tidak valid.\n");
    }
}

void CariBarang(List<Item> daftarBelanja)
{
    Console.Write("Masukkan nama barang yang ingin dicari: ");
    string? input = Console.ReadLine()?.ToLower();
    if (!string.IsNullOrWhiteSpace(input))
    {
        var hasil = daftarBelanja.Where(b => b.Nama.Contains(input, StringComparison.OrdinalIgnoreCase)).ToList();
        if (hasil.Any())
        {
            Console.WriteLine("=== Hasil Pencarian ===");
            for (int i = 0; i < hasil.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {hasil[i].Nama} - Jumlah: {hasil[i].Jumlah}");
            }
        }
        else
        {
            Console.WriteLine("Barang tidak ditemukan.\n");
        }
    }
    else
    {
        Console.WriteLine("Nama barang tidak boleh kosong.\n");
    }
}

void UrutkanDaftar(List<Item> daftarBelanja)
{
    daftarBelanja.Sort((a, b) => string.Compare(a.Nama, b.Nama, StringComparison.OrdinalIgnoreCase));
    Console.WriteLine("Daftar belanja berhasil diurutkan berdasarkan nama barang.\n");
}

void HapusSemuaBarang(List<Item> daftarBelanja)
{
    Console.Write("Apakah Anda yakin ingin menghapus semua barang? (y/n): ");
    string? konfirmasi = Console.ReadLine();
    if (konfirmasi?.ToLower() == "y")
    {
        daftarBelanja.Clear();
        Console.WriteLine("Semua barang berhasil dihapus dari daftar.\n");
    }
    else
    {
        Console.WriteLine("Penghapusan dibatalkan.\n");
    }
}

void Main()
{
    List<Item> daftarBelanja = new List<Item>();
    bool running = true;
    while (running)
    {
        Console.Clear();
        TampilkanMenu();
        Console.Write("Pilih menu (1-7): ");
        string? pilihan = Console.ReadLine();
        switch (pilihan)
        {
            case "1":
                TambahBarang(daftarBelanja);
                Console.ReadLine();
                break;
            case "2":
                LihatDaftar(daftarBelanja);
                Console.ReadLine();
                break;
            case "3":
                HapusBarang(daftarBelanja);
                Console.ReadLine();
                break;
            case "4":
                CariBarang(daftarBelanja);
                Console.ReadLine();
                break;
            case "5":
                UrutkanDaftar(daftarBelanja);
                Console.ReadLine();
                break;
            case "6":
                HapusSemuaBarang(daftarBelanja);
                Console.ReadLine();
                break;
            case "7":
                running = false;
                Console.WriteLine("Terima kasih telah menggunakan aplikasi Daftar Belanja!");
                Console.ReadLine();
                break;
            default:
                Console.WriteLine("Pilihan tidak valid!\n");
                Console.ReadLine();
                break;
        }
    }
}

Main();

class Item
{
    public required string Nama { get; set; }
    public int Jumlah { get; set; }
}