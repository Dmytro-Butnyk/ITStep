// See https://aka.ms/new-console-template for more information
using lesson_18;
using Newtonsoft.Json;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using static System.Console;

// task 1
/*
var random = new Random();
var numbers = Enumerable
    .Range(0, 100)
    .Select(_ => random.Next())
    .ToList();

var primeNumbers = numbers.Where(IsPrime).ToList();
var nonPrimeNumbers = numbers.Except(primeNumbers).ToList();

var primeNumbersJson = JsonConvert.SerializeObject(primeNumbers);

var serializer = new XmlSerializer(typeof(List<int>));
var stringWriter = new StringWriter();
serializer.Serialize(stringWriter, nonPrimeNumbers);
var nonPrimeNumbersXml = stringWriter.ToString();

try
{
    File.WriteAllText("primeNumbers.json", primeNumbersJson);
    File.WriteAllText("nonPrimeNumbers.xml", nonPrimeNumbersXml);

    var deserializedPrimeNumbers = JsonConvert.DeserializeObject<List<int>>(File.ReadAllText("primeNumbers.json"));
    var stringReader = new StringReader(File.ReadAllText("nonPrimeNumbers.xml"));
    var deserializedNonPrimeNumbers = (List<int>)serializer.Deserialize(stringReader);
}
catch(Exception ex)
{
    WriteLine(ex.Message);
}

static bool IsPrime(int number)
{
    if (number < 2) return false;
    for (int i = 2; i * i <= number; i++)
    {
        if (number % i == 0) return false;
    }
    return true;
}
*/

// task 2
/*
var album = new Album
(
    "Example Album",
    "Example Artist",
    2022,
    new TimeSpan(0, 40, 0),
    "Example Record Label",
    new List<Song>
            {
                new Song("Song 1", "Rock", new TimeSpan(0, 4, 0)),
                new Song("Song 2", "Pop", new TimeSpan(0, 3, 30)),
            }
);

WriteLine($"Album:\n{album}");

try
{
    var json = JsonConvert.SerializeObject(album);

    var xmlSer = new XmlSerializer(typeof(Album));
    var stringWriter = new StringWriter();
    xmlSer.Serialize(stringWriter, album);
    var xmlSerAlbum = stringWriter.ToString();

    File.WriteAllText("album.json", json);
    File.WriteAllText("xmlSerAlbum.xml", xmlSerAlbum);

    var deserializedAlbum = JsonConvert.DeserializeObject<Album>(File.ReadAllText("album.json"));
}
catch(Exception ex)
{
    WriteLine(ex.Message);
}
*/

// task 3

var account = new PaymentAccount
{
    DailyPayment = 100,
    Days = 30,
    DailyFine = 10,
    DelayDays = 2
};

WriteLine(account);

try
{
    while (ReadLine() != "0")
    {
        Clear();
        WriteLine("1 - show;\n2 - UpdateDays\n3 - UpdateDailyFine\n4 - UpdateDelayDays\n");
        switch (ReadLine())
        {
            case "1":
                {
                    WriteLine(account);
                    break;
                }
            case "2":
                {
                    WriteLine("Input new days:");
                    int newDays;
                    if (int.TryParse(ReadLine(), out newDays))
                    {
                        account.UpdateDays(newDays);
                    }
                    break;
                }
            case "3": 
                {
                    WriteLine("Input new daily fine:");
                    int newFine;
                    if (int.TryParse(ReadLine(), out newFine))
                    {
                        account.UpdateDailyFine(newFine);
                    }
                    break;
                }
            case "4":
                {
                    WriteLine("Input new delay days:");
                    int newFine;
                    if (int.TryParse(ReadLine(), out newFine))
                    {
                        account.UpdateDailyFine(newFine);
                    }
                    break;
                }
        }

        var formatter = new BinaryFormatter();
        using (var stream = new FileStream("account.bin", FileMode.Create, FileAccess.Write))
        {
            formatter.Serialize(stream, account);
        }

        using (var stream = new FileStream("account.bin", FileMode.Open, FileAccess.Read))
        {
            account = (PaymentAccount)formatter.Deserialize(stream);
        }
        WriteLine("0 - exit\nElse - continue.");
    }
}
catch (Exception ex)
{
    WriteLine(ex.Message);
}