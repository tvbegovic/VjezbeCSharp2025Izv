using System.ComponentModel.Design;

Console.Write("Unesite redni broj mjeseca (1-12): ");
string unos = Console.ReadLine();
bool ok = int.TryParse(unos, out int mjesec);
if(!ok)
{
    Console.WriteLine("Pogrešan format");
    return;
}
if(mjesec < 1 || mjesec > 12)
{
    Console.WriteLine("Mjesec je izvan raspona");
    return;
}
int brojDana;
string dani = "dana";
switch(mjesec)
{
    case 2:
        if(DateTime.IsLeapYear(DateTime.Now.Year))
            brojDana = 29;
        else
            brojDana = 28;
        break;
    case 4:
    case 6:
    case 9:
    case 11:
        brojDana = 30;
        break;
    default:
        brojDana = 31;
        dani = "dan";
        break;
}
Console.WriteLine($"{mjesec}. mjesec ima {brojDana} {dani}");
