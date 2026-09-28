bool mainLagi = true;
Random random = new Random();

while (mainLagi)
{
    int randomNumber;
    string? userInput;
    int userAttempts = 0;
    bool tebakanBenar = false;
    string? userDifficulty;
    Console.WriteLine("====================");
    Console.WriteLine("| Game Tebak Angka |");
    Console.WriteLine("====================");
    Console.WriteLine("Tingkat Kesulitan:");
    Console.WriteLine("1. Easy (1-50)");
    Console.WriteLine("2. Medium (1-100)");
    Console.WriteLine("3. Hard (1-500)");

    Console.Write("Silahkan pilih tingkat kesulitan (1-3): ");
    userDifficulty = Console.ReadLine();

    switch (userDifficulty)
    {
        case "1":
            randomNumber = random.Next(1, 51);
            Console.WriteLine("");
            Console.Write("Silahkan tebak angka antara 1 sampai 50: ");
            do
            {
                if (userAttempts > 0)
                    Console.Write("\nSilahkan coba lagi: ");

                userInput = Console.ReadLine();

                if (int.TryParse(userInput, out int validNumber))
                {
                    if (validNumber < randomNumber)
                        Console.Write("Tebakan Anda terlalu rendah.");
                    else if (validNumber > randomNumber)
                        Console.Write("Tebakan Anda terlalu tinggi.");
                    else
                    {
                        Console.WriteLine("");
                        Console.WriteLine("BENAR!");
                        tebakanBenar = true;
                    }
                }
                else
                {
                    Console.WriteLine("Input tidak valid. Silahkan masukkan angka antara 1 sampai 50.");
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

            break;
        case "2":
            randomNumber = random.Next(1, 101);
            Console.WriteLine("");
            Console.Write("Silahkan tebak angka antara 1 sampai 100: ");
            do
            {
                if (userAttempts > 0)
                    Console.Write("\nSilahkan coba lagi: ");

                userInput = Console.ReadLine();

                if (int.TryParse(userInput, out int validNumber))
                {
                    if (validNumber < randomNumber)
                        Console.Write("Tebakan Anda terlalu rendah.");
                    else if (validNumber > randomNumber)
                        Console.Write("Tebakan Anda terlalu tinggi.");
                    else
                    {
                        Console.WriteLine("");
                        Console.WriteLine("BENAR!");
                        tebakanBenar = true;
                    }
                }
                else
                {
                    Console.WriteLine("Input tidak valid. Silahkan masukkan angka antara 1 sampai 100.");
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

            break;
        case "3":
            randomNumber = random.Next(1, 501);
            Console.WriteLine("");
            Console.Write("Silahkan tebak angka antara 1 sampai 500: ");
            do
            {
                if (userAttempts > 0)
                    Console.Write("\nSilahkan coba lagi: ");

                userInput = Console.ReadLine();

                if (int.TryParse(userInput, out int validNumber))
                {
                    if (validNumber < randomNumber)
                        Console.Write("Tebakan Anda terlalu rendah.");
                    else if (validNumber > randomNumber)
                        Console.Write("Tebakan Anda terlalu tinggi.");
                    else
                    {
                        Console.WriteLine("");
                        Console.WriteLine("BENAR!");
                        tebakanBenar = true;
                    }
                }
                else
                {
                    Console.WriteLine("Input tidak valid. Silahkan masukkan angka antara 1 sampai 500.");
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

            break;
        default:
            Console.Clear();
            Console.WriteLine("Pilihan tidak valid!");
            continue;
    }

    Console.WriteLine("");
    Console.WriteLine("Apakah Anda ingin bermain lagi? (y/n): ");
    string? mainLagiInput = Console.ReadLine();
    if (mainLagiInput?.ToLower() == "y")
    {
        mainLagi = true;
        Console.Clear();
    }
    else
    {
        mainLagi = false;
    }
}

Console.WriteLine("");
Console.WriteLine("Terima kasih telah bermain! Sampai jumpa lagi.");