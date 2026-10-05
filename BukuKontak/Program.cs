using System.Globalization;

string FormatNama(string nama)
{
    if (string.IsNullOrWhiteSpace(nama))
        return nama;

    // ToLower() dulu, karena ToTitleCase tidak handle huruf kapital di tengah
    string namaLower = nama.ToLower().Trim();

    TextInfo textInfo = new CultureInfo("id-ID", false).TextInfo;
    string namaFormatted = textInfo.ToTitleCase(namaLower);

    return namaFormatted;
}

void TampilkanMenu()
{
    Console.WriteLine("===============");
    Console.WriteLine("| Buku Kontak |");
    Console.WriteLine("===============");
    Console.WriteLine("1. Tambah Kontak");
    Console.WriteLine("2. Lihat Semua Kontak");
    Console.WriteLine("3. Cari Kontak");
    Console.WriteLine("4. Hapus Kontak");
    Console.WriteLine("5. Keluar");
}

void TambahKontak(Dictionary<string, List<string>> daftarKontak)
{
    Console.Write("Nama: ");
    string? nama = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(nama))
    {
        Console.WriteLine("\nNama tidak boleh kosong.\n");
        return;
    }
    string namaFormatted = FormatNama(nama);

    Console.Write("Nomor Kontak: ");
    string? nomor = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(nomor))
    {
        Console.WriteLine("\nNomor tidak boleh kosong.\n");
        return;
    }

    // Cek nomor sudah dipakai siapa
    foreach (KeyValuePair<string, List<string>> entry in daftarKontak)
    {
        if (entry.Value.Contains(nomor))
        {
            Console.WriteLine($"\nNomor {nomor} sudah terdaftar atas nama {entry.Key}.\n");
            return;
        }
    }

    // Kalau nama belum ada, buat List baru
    if (!daftarKontak.ContainsKey(namaFormatted))
    {
        daftarKontak[namaFormatted] = new List<string>();
    }

    // Tambah nomor ke List milik nama tersebut
    daftarKontak[namaFormatted].Add(nomor);
    Console.WriteLine($"Kontak atas nama {namaFormatted} berhasil ditambahkan.");
}

void LihatDaftarKontak(Dictionary<string, List<string>> daftarKontak)
{
    if (daftarKontak.Count == 0)
    {
        Console.WriteLine("\nDaftar kontak kosong.\n");
        return;
    }

    Console.WriteLine("\n=== Daftar Kontak ===");
    int nomorUrut = 1;
    foreach (KeyValuePair<string, List<string>> entry in daftarKontak)
    {
        // Gabungkan semua nomor jadi 1 string dipisah koma
        string semuaNomor = string.Join(", ", entry.Value);
        Console.WriteLine($"{nomorUrut}. {entry.Key} - {semuaNomor}");
        nomorUrut++;
    }
}

void CariKontak(Dictionary<string, List<string>> daftarKontak)
{
    if (daftarKontak.Count == 0)
    {
        Console.WriteLine("\nDaftar kontak kosong.\n");
        return;
    }

    Console.Write("Masukkan nama kontak yang ingin dicari: ");
    string? userInput = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(userInput))
    {
        Console.WriteLine("\nMohon masukkan nama yang ingin dicari.\n");
        return;
    }

    string inputFormatted = FormatNama(userInput);
    if (daftarKontak.TryGetValue(inputFormatted, out List<string>? nomorLengkap))
    {
        Console.WriteLine($"\n{inputFormatted} - {string.Join(", ", nomorLengkap)}");
        return;
    }

    Console.WriteLine("\n=== Hasil Pencarian Serupa ===");
    bool ditemukan = false;
    int nomor = 1;
    foreach (KeyValuePair<string, List<string>> entry in daftarKontak)
    {
        if (entry.Key.ToLower().Contains(userInput.ToLower()))
        {
            string semuaNomor = string.Join(", ", entry.Value);
            Console.WriteLine($"{nomor}. {entry.Key} - {semuaNomor}");
            nomor++;
            ditemukan = true;
        }
    }

    if (!ditemukan)
    {
        Console.WriteLine("\nKontak tidak ditemukan.\n");
    }
}

void HapusKontak(Dictionary<string, List<string>> daftarKontak)
{
    // 1. Cek apakah ada kontak
    if (daftarKontak.Count == 0)
    {
        Console.WriteLine("\nDaftar kontak kosong.\n");
        return;
    }

    // 2. Input nama yang mau dihapus
    Console.Write("Masukkan nama kontak yang ingin dihapus: ");
    string? userInput = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(userInput))
    {
        Console.WriteLine("\nNama tidak boleh kosong.\n");
        return;
    }

    // 3. Cari kontak yang cocok (partial match, case-insensitive)
    List<string> cocok = new List<string>();
    foreach (var kontak in daftarKontak)
    {
        if (kontak.Key.ToLower().Contains(userInput.ToLower()))
        {
            cocok.Add(kontak.Key);
        }
    }

    // 4. Kalau tidak ada yang cocok
    if (cocok.Count == 0)
    {
        Console.WriteLine($"\nKontak dengan nama mengandung '{userInput}' tidak ditemukan.\n");
        return;
    }

    // 5. Tampilkan hasil pencarian
    Console.WriteLine("\n=== Kontak yang cocok ===");
    for (int i = 0; i < cocok.Count; i++)
    {
        string nama = cocok[i];
        List<string> nomorListTampil = daftarKontak[nama];
        Console.WriteLine($"{i + 1}. {cocok[i]} - {string.Join(", ", nomorListTampil)}");
    }

    // 6. Minta konfirmasi nama lengkap
    Console.Write("\nKetik nama lengkap yang ingin dihapus: ");
    string? namaHapus = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(namaHapus))
    {
        Console.WriteLine("\nNama tidak boleh kosong. Penghapusan dibatalkan.\n");
        return;
    }

    // 7. Cari nama lengkap yang cocok (case-insensitive)
    string? namaAsli = null;
    foreach (string nama in cocok)
    {
        if (nama.ToLower() == namaHapus.ToLower())
        {
            namaAsli = nama;   // ← simpan nama dengan huruf asli
            break;
        }
    }

    // 8. Kalau tidak ada yang exact match
    if (namaAsli == null)
    {
        Console.WriteLine($"\n'{namaHapus}' tidak ada dalam daftar yang cocok.\n");
        return;
    }

    // 9. Hapus (di luar loop!)
    List<string> nomorListHapus = daftarKontak[namaAsli];
    daftarKontak.Remove(namaAsli);
    Console.WriteLine($"\nKontak '{namaAsli}' ({string.Join(", ", nomorListHapus)}) berhasil dihapus.\n");
}

void Pause()
{
    Console.WriteLine("\nTekan tombol Enter apapun untuk lanjut...");
    Console.ReadLine();
}

void Main()
{
    Dictionary<string, List<string>> daftarKontak = new Dictionary<string, List<string>>();
    daftarKontak["Budiman"] = new List<string> { "081234567890" };
    daftarKontak["Budi"] = new List<string> { "089876543210", "083223456543" };
    daftarKontak["Budiawan"] = new List<string> { "085555555555" };

    bool running = true;
    while (running)
    {
        Console.Clear();
        TampilkanMenu();
        Console.Write("\nSilahkan pilih menu (1-5): ");
        string? userInput = Console.ReadLine();

        switch (userInput)
        {
            case "1":
                TambahKontak(daftarKontak);
                Pause();
                break;
            case "2":
                LihatDaftarKontak(daftarKontak);
                Pause();
                break;
            case "3":
                CariKontak(daftarKontak);
                Pause();
                break;
            case "4":
                HapusKontak(daftarKontak);
                Pause();
                break;
            case "5":
                running = false;
                break;
        }
    }

    Console.WriteLine("\nTerima kasih telah menggunakan Buku Kontak.");
    Pause();
    Console.Clear();
}

Main();