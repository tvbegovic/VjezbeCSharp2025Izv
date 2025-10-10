Console.Write("Ime: ");
string ime = Console.ReadLine();
if (string.IsNullOrWhiteSpace(ime))
{
    Console.WriteLine("Ime ne smije biti prazno.");
    return;
}

Console.Write("Prezime: ");
string prezime = Console.ReadLine();
if (string.IsNullOrWhiteSpace(prezime))
{
    Console.WriteLine("Prezime ne smije biti prazno.");
    return;
}

Console.WriteLine($"Vaši inicijali su {ime.Substring(0, 1)}.{prezime.Substring(0, 1)}.");
