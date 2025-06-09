using hw_18;
using Newtonsoft.Json;

// task 1

Fraction[] fractions = new Fraction[5];
for (int i = 0; i < fractions.Length; i++)
{
    fractions[i] = new Fraction { Numerator = i + 1, Denominator = i + 2 };
}

string json = JsonConvert.SerializeObject(fractions);
File.WriteAllText("fractions.json", json);

string jsonFromFile = File.ReadAllText("fractions.json");
Fraction[] fractionsFromFile = JsonConvert.DeserializeObject<Fraction[]>(jsonFromFile);

// task 2

Journal journal = new Journal { Title = "Journal Title", Publisher = "Publisher Name", PublicationDate = DateTime.Now, PageCount = 100 };

json = JsonConvert.SerializeObject(journal);
File.WriteAllText("journal.json", json);

jsonFromFile = File.ReadAllText("journal.json");
Journal journalFromFile = JsonConvert.DeserializeObject<Journal>(jsonFromFile);

// task 3

JournalWithArticles journalWithArticles = new JournalWithArticles
{
    Title = "Journal Title",
    Publisher = "Publisher Name",
    PublicationDate = DateTime.Now,
    PageCount = 100,
    Articles = new List<Article>
    {
        new Article { Title = "Article 1", CharacterCount = 1000, Preview = "Preview 1" },
        new Article { Title = "Article 2", CharacterCount = 2000, Preview = "Preview 2" }
    }
};

json = JsonConvert.SerializeObject(journalWithArticles);
File.WriteAllText("journalWithArticles.json", json);

jsonFromFile = File.ReadAllText("journalWithArticles.json");
JournalWithArticles journalWithArticlesFromFile = JsonConvert.DeserializeObject<JournalWithArticles>(jsonFromFile);

// task 4

JournalWithArticles[] journals = new JournalWithArticles[2];
journals[0] = journalWithArticles;
journals[1] = new JournalWithArticles
{
    Title = "Journal Title 2",
    Publisher = "Publisher Name 2",
    PublicationDate = DateTime.Now,
    PageCount = 200,
    Articles = new List<Article>
    {
        new Article { Title = "Article 3", CharacterCount = 3000, Preview = "Preview 3" },
        new Article { Title = "Article 4", CharacterCount = 4000, Preview = "Preview 4" }
    }
};

json = JsonConvert.SerializeObject(journals);
File.WriteAllText("journals.json", json);

jsonFromFile = File.ReadAllText("journals.json");
JournalWithArticles[] journalsFromFile = JsonConvert.DeserializeObject<JournalWithArticles[]>(jsonFromFile);