Console.Write("Siapa namamu?\t");
string? nama = Console.ReadLine();

Console.Write("Berapa umurmu?\t");
int umur = int.Parse(Console.ReadLine() ?? "0");

Console.Write("Kamu tinggal di kota mana?\t");
string? kota = Console.ReadLine();

Console.WriteLine();
Console.WriteLine($"Halo, {nama}!");
Console.WriteLine($"Tahun depan umur kamu {umur + 1}!");
Console.WriteLine($"Kamu tinggal di {kota}.");