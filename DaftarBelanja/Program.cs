void TampilkanMenu()
{
    Console.WriteLine("==================");
    Console.WriteLine("| Daftar Belanja |");
    Console.WriteLine("==================");
    Console.WriteLine("1. Tambah Barang");
    Console.WriteLine("2. Lihat Daftar");
    Console.WriteLine("3. Hapus Barang");
    Console.WriteLine("4. Cari Barang");
    Console.WriteLine("5. Keluar");
}

string TambahBarang(List<string> daftarBelanja)
{
    Console.Write("Nama Barang: ");
    string? barang = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(barang))
    {
        daftarBelanja.Add(barang);
        return $"\nBarang '{barang}' berhasil ditambahkan.\n";
    }
    else
    {
        return "Nama barang tidak boleh kosong.\n";
    }
}

string LihatDaftar(List<string> daftarBelanja)
{
    if (daftarBelanja.Count == 0)
    {
        return "Daftar belanja kosong.\n";
    }
    else
    {
        string daftar = "=== Daftar Belanja ===\n";
        for (int i = 0; i < daftarBelanja.Count; i++)
        {
            daftar += $"{i + 1}. {daftarBelanja[i]}\n";
        }
        return daftar;
    }
}

void HapusBarang(List<string> daftarBelanja)
{
    Console.Write("Masukkan nomor barang yang ingin dihapus: ");
    string? input = Console.ReadLine();
    if (int.TryParse(input, out int index) && index > 0 && index <= daftarBelanja.Count)
    {
        string barangDihapus = daftarBelanja[index - 1];
        daftarBelanja.RemoveAt(index - 1);
        Console.WriteLine($"Barang '{barangDihapus}' berhasil dihapus.\n");
    }
    else
    {
        Console.WriteLine("Nomor barang tidak valid.\n");
    }
}

string CariBarang(List<string> daftarBelanja)
{
    Console.Write("Masukkan nama barang yang ingin dicari: ");
    string? input = Console.ReadLine()?.ToLower();
    if (!string.IsNullOrWhiteSpace(input))
    {
        var hasil = daftarBelanja.Where(b => b.Contains(input, StringComparison.OrdinalIgnoreCase)).ToList();
        if (hasil.Any())
        {
            string daftar = "=== Hasil Pencarian ===\n";
            for (int i = 0; i < hasil.Count; i++)
            {
                daftar += $"{i + 1}. {hasil[i]}\n";
            }
            return daftar;
        }
        else
        {
            return "Barang tidak ditemukan.\n";
        }
    }
    else
    {
        return "Nama barang tidak boleh kosong.\n";
    }
}

void Main()
{
    List<string> daftarBelanja = new List<string>();
    bool running = true;
    while (running)
    {
        Console.Clear();
        TampilkanMenu();
        Console.Write("Pilih menu (1-5): ");
        string? pilihan = Console.ReadLine();
        switch (pilihan)
        {
            case "1":
                Console.WriteLine(TambahBarang(daftarBelanja));
                Console.ReadLine();
                break;
            case "2":
                Console.WriteLine(LihatDaftar(daftarBelanja));
                Console.ReadLine();
                break;
            case "3":
                HapusBarang(daftarBelanja);
                Console.ReadLine();
                break;
            case "4":
                Console.WriteLine(CariBarang(daftarBelanja));
                Console.ReadLine();
                break;
            case "5":
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