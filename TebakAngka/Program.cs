void TampilkanHeader()
{
    Console.WriteLine("====================");
    Console.WriteLine("| Game Tebak Angka |");
    Console.WriteLine("====================");
    Console.WriteLine("Tingkat Kesulitan:");
    Console.WriteLine("1. Easy (1-50)");
    Console.WriteLine("2. Medium (1-100)");
    Console.WriteLine("3. Hard (1-500)");
}

int PilihKesulitan()
{
    while (true)
    {
        Console.Write("Silahkan pilih tingkat kesulitan (1-3): ");
        string? userDifficulty = Console.ReadLine();
        switch (userDifficulty)
        {
            case "1":
                return 50;
            case "2":
                return 100;
            case "3":
                return 500;
            default:
                Console.Clear();
                Console.WriteLine("Pilihan tidak valid!\n");
                TampilkanHeader();
                break;
        }
    }
}

int BacaAngka(int min, int max)
{
    while (true)
    {
        string? userInput = Console.ReadLine();
        if (int.TryParse(userInput, out int validNumber))
        {
            if (validNumber >= min && validNumber <= max)
                return validNumber;
            else
                Console.WriteLine($"Input tidak valid. Silahkan masukkan angka antara {min} sampai {max}.");
        }
        else
        {
            Console.WriteLine($"Input harus berupa angka antara {min} sampai {max}.");
        }
    }
}

int CekTebakan(int tebakan, int angkaRahasia)
{
    if (tebakan < angkaRahasia)
        return -1; // Tebakan terlalu rendah
    else if (tebakan > angkaRahasia)
        return 1; // Tebakan terlalu tinggi
    else
        return 0; // Tebakan benar
}

void MainGame(int maxNumber)
{
    Random random = new Random();
    int randomNumber = random.Next(1, maxNumber + 1);
    int userAttempts = 0;
    bool tebakanBenar = false;

    Console.Write($"Silahkan tebak angka antara 1 sampai {maxNumber}: ");

    do
    {
        if (userAttempts > 0)
        {
            Console.Write("\nSilahkan tebak lagi: ");
        }

        int tebakan = BacaAngka(1, maxNumber);

        int hasilTebakan = CekTebakan(tebakan, randomNumber);

        if (hasilTebakan == -1)
        {
            Console.WriteLine("Tebakan Anda terlalu rendah.");
        }
        else if (hasilTebakan == 1)
        {
            Console.WriteLine("Tebakan Anda terlalu tinggi.");
        }
        else
        {
            tebakanBenar = true;
        }

        userAttempts++;
    }
    while (!tebakanBenar && userAttempts < 7);

    if (tebakanBenar)
    {
        Console.WriteLine("");
        Console.WriteLine($"Selamat! Anda berhasil menebak angka {randomNumber}.");
        Console.WriteLine($"Jumlah percobaan Anda: {userAttempts}");
    }
    else
    {
        Console.WriteLine("");
        Console.WriteLine($"Maaf, Anda telah mencapai batas percobaan. Angka yang benar adalah {randomNumber}.");
    }
}



bool TanyaMainLagi()
{
    Console.Write("Apakah Anda ingin bermain lagi? (y/n): ");
    string? userChoice = Console.ReadLine();
    return userChoice?.ToLower() == "y";
}

bool mainLagi = true;

while (mainLagi)
{
    Console.Clear();
    TampilkanHeader();
    int maxNumber = PilihKesulitan();
    MainGame(maxNumber);
    mainLagi = TanyaMainLagi();

    if (mainLagi)
        Console.Clear();
}

Console.WriteLine("");
Console.WriteLine("Terima kasih telah bermain! Sampai jumpa lagi.");