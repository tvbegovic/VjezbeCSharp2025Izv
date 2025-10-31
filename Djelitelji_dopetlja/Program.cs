﻿bool nastavi = true;
do
{
    Console.Write("Broj (1-100.000): ");
    string unos = Console.ReadLine();
    if(string.IsNullOrEmpty(unos))
        nastavi = false;
    else
    {
        bool ok = int.TryParse(unos, out int broj);
        if (!ok)
        {
            Console.WriteLine("Pogrešan format");
            continue;
        }
        if (broj < 1 || broj > 100000)
        {
            Console.WriteLine("Broj je izvan raspona");
            continue;
        }

        long zbroj = 0;
        for (int i = 1; i <= broj; i++)
        {
            if (i % 3 == 0 || i % 5 == 0)
            {
                zbroj += i;
            }
        }
        Console.WriteLine($"Zbroj brojeva od 1 do {broj} djeljivih sa 3 ili 5 je {zbroj:N0}");
    }
}
while (nastavi);
