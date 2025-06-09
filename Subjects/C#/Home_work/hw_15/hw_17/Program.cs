// See https://aka.ms/new-console-template for more information
using hw_17;
using static System.Console;

Random rand = new Random();
// task 1

WriteLine("\n\nTASK 1\n\n");
List<int> task1 = Enumerable.Range(0, 30).
    Select(_ => rand.Next(-10, 20)).ToList();

// 1
WriteLine("#1\n" + string.Join(" ", task1));
// 2
WriteLine("#2\n" + string.Join(" ", task1.Where(num =>
num % 2 == 0 && num != 0)));
// 3
var oddInt = task1.Where(num => num % 2 != 0);
WriteLine("#3\n" + string.Join(" ", oddInt));
// 4
var numbersInRange = task1.Skip(2).Take(6 - 1).ToList();
WriteLine("#4\n" + string.Join(" ", numbersInRange));
// 5
var numK7 = task1
    .Where(num => num % 7 == 0 && num != 0)
    .OrderBy(num => num).ToList();
WriteLine("#5\n" + string.Join(" ", numK7));
// 6
var numK8 = task1
    .Where(num => num % 8 == 0 && num != 0)
    .OrderBy(num => -num).ToList();
WriteLine("#6\n" + string.Join(" ", numK8));


// task 2
WriteLine("\n\nTASK 2\n\n");
/* Завдання 2:
Для масиву рядків з назвою міст, реалізуйте наступні запити:
-Отримати весь масив міст.
- Отримати міста з довжиною назви, що дорівнює заданому.
- Отримати міста, назви яких починаються з літери A.
- Отримати міста, назви яких закінчуються літерою M.
- Отримати міста, назви яких починаються з літери N і
закінчуються літерою K */

List<string> task2 = new()
{
    "Kyiv",
    "Kremenchuk",
    "Kharkiv",
    "Ivano-Frankivsk",
    "Tokyo",
    "Osaka",
    "Fukuoka",
    "Saitama"
};
// 1
task2.ForEach(city => Write(city + " "));
// 2
var citiesLen = task2.Where(city => city.Length == 7);
WriteLine("#2\n" + string.Join(" ", citiesLen));
// 3
var citiesOnK = task2.Where(city => city.StartsWith("K"));
WriteLine("#3\n" + string.Join(" ", citiesOnK));
// 4
var citiesEndA = task2.Where(city => city.EndsWith("a"));
WriteLine("#4\n" + string.Join(" ", citiesEndA));
// 5
var citiesOnKEndK = task2.Where(city => city.StartsWith("K") && city.EndsWith("k"));
WriteLine("#4\n" + string.Join(" ", citiesOnKEndK));

// task 3
WriteLine("\n\nTASK 3\n\n");

/*Завдання 3:
Реалізуйте тип користувача «Студент» з інформацією про ім’я,
прізвище, вік, назву навчального закладу. Для масиву «Студент»
реалізуйте наступні запити:
-Отримати весь масив студентів.
- Отримати список студентів з прізвищем, яке починається з
Bro.
- Отримати список студентів, старших 19 років.
- Отримати список студентів, старших 20 років і молодших 23
років.
- Отримати список студентів, які навчаються в Oxford, і вік
яких старше 18 років. Результат відсортуйте за віком, за
спаданням.*/

List<Student> students = new()
{
    new Student("Ivan", "Ivanenko", 18, "Oxford"),
    new Student("Petro", "Petrenko", 21, "University B"),
    new Student("Oleksandr", "Oleksandrenko", 22, "University C"),
    new Student("Mykola", "Mykolenko", 19, "Oxford"),
    new Student("Vasyl", "Vasylenko", 24, "University E"),
    new Student("Dmytro", "Dmytrenko", 20, "University F"),
    new Student("Serhii", "Serhiienko", 26, "Oxford"),
    new Student("Andrii", "Andriienko", 27, "University H"),
    new Student("Yurii", "Yurienko", 18, "University I"),
    new Student("Volodymyr", "Volodymyrenko", 29, "University J")
};

// 1
WriteLine("#1");
students.ForEach(WriteLine);
// 2
var studentsOnDmy = students
    .Where(student => student.lastName.Contains("Dmy"))
    .ToList();
WriteLine("#2");
studentsOnDmy.ForEach(WriteLine);
// 3
var studentsOver19 = students
    .Where(s => s.age > 19)
    .ToList();
WriteLine("#3");
studentsOver19.ForEach(WriteLine);
// 4
var studentsOver20under23 = students
    .Where(s => s.age > 20 && s.age < 23)
    .ToList();
WriteLine("#4");
studentsOver20under23.ForEach(WriteLine);
// 5 
var studentsInOxford = students
    .Where(s => s.educationalInstitution is "Oxford")
    .OrderByDescending(s => s.age > 18)
    .ToList();
WriteLine("#5");
studentsInOxford.ForEach(WriteLine);

// task 4
WriteLine("\n\nTASK 4\n\n");

//Завдання 4:
//Реалізуйте користувацький тип «Фірма». В ньому має бути
//інформація про назву фірми, дату заснування, профіль бізнесу
//(маркетинг, IT, і т. д.), ПІБ директора, кількість працівників,
//адреса.
//Для масиву фірм реалізуйте такі запити:
// Отримати інформацію про всі фірми.
// Отримати фірми, які мають у назві слово «Food».
// Отримати фірми, які працюють у галузі маркетингу.
// Отримати фірми, які працюють у галузі маркетингу або IT.
// Отримати фірми з кількістю працівників більшою, ніж 100.
// Отримати фірми з кількістю працівників у діапазоні від 100 до
//300.
// Отримати фірми, які знаходяться в Лондоні.
// Отримати фірми, в яких прізвище директора White.
// Отримати фірми, які засновані більше двох років тому.
// Отримати фірми з дня заснування яких минуло 123 дні.
// Отримати фірми, в яких прізвище директора Black і мають у
//назві фірми слово «White».

List<Firm> firms = new()
{
    new Firm("FoodMart", new DateTime(2000, 1, 1), "Food", "John White", 200, "London"),
    new Firm("TechBros", new DateTime(2010, 1, 1), "IT", "James Black", 300, "New York"),
    new Firm("MarketGurus", new DateTime(2005, 1, 1), "Marketing", "Emma Green", 150, "London"),
    new Firm("FoodCraft", new DateTime(2020, 1, 1), "Food", "Olivia White", 60, "Paris"),
    new Firm("CodeMasters", new DateTime(2018, 1, 1), "IT", "Liam Brown", 220, "Berlin"),
    new Firm("AdsEmpire", new DateTime(2012, 1, 1), "Marketing", "Noah Black", 400, "Tokyo"),
    new Firm("FoodParadise", new DateTime(2015, 1, 1), "Food", "Ava White", 90, "London"),
    new Firm("TechSpace", new DateTime(2019, 1, 1), "IT", "Isabella Green", 120, "New York"),
    new Firm("MarketLeaders", new DateTime(2008, 1, 1), "Marketing", "Sophia Black", 350, "Paris"),
    new Firm("FoodHeaven", new DateTime(2021, 1, 1), "Food", "Mia White", 70, "Berlin")
};

// 1
firms.ForEach(WriteLine);
// 2
var foodFirms = firms
    .Where(f => f.Name.Contains("Food"))
    .ToList();
// 3
var marketingFirms = firms
    .Where(f => f.BusinessProfile == "Marketing")
    .ToList();
// 4
var marketingOrITFirms = firms
    .Where(f => f.BusinessProfile == "Marketing" || f.BusinessProfile == "IT")
    .ToList();
// 5
var firmsMore100Employees = firms
    .Where(f => f.EmployeeCount > 100)
    .ToList();
// 6
var firmsWith100To300Employees = firms
    .Where(f => f.EmployeeCount >= 100 && f.EmployeeCount <= 300)
    .ToList();
// 7
var firmsInLondon = firms
    .Where(f => f.Address.Contains("London"))
    .ToList();
// 8
var firmsWithDirectorWhite = firms
    .Where(f => f.DirectorName.Split(' ').Last() == "White")
    .ToList();
// 9
var firms2YearsOld = firms
    .Where(f => (DateTime.Now - f.FoundationDate).TotalDays > 2 * 365)
    .ToList();
// 10
var firmsFounded123DaysAgo = firms
    .Where(f => (DateTime.Now - f.FoundationDate).TotalDays == 123)
    .ToList();
// 11
var firmsWhiteDirectorBlack = firms
    .Where(f => f.DirectorName.Split(' ').Last() == "Black" && f.Name.Contains("White"))
    .ToList();

// task 5
WriteLine("\n\nTASK 5\n\n");

//Завдання 5
//Для масиву цілих чисел реалізуйте користувацьке сортування.
//Сортування має працювати за сумою цифр числа (за зростанням
//та зменшенням). Наприклад, якщо сортування проводиться за
//зменшенням, потрібно повернути числа з максимальною сумою
//в порядку зменшення суми. Наприклад, якщо масив містить 121,
//75, 81, після сортування за зменшенням ми отримаємо 75, 81, 121.
//Такий результат, тому що 7+5 = 12, 8+1 = 9, 1+2+1 = 4

List<int> numbers = new List<int> { 121, 75, 81 };

// 1
var sortedNumbers = numbers
    .OrderByDescending(number => number.ToString().Sum(c => c - '0'))
    .ToList();
sortedNumbers.ForEach(num => Write(num + " "));

// task 6
WriteLine("\n\nTASK 6\n\n");

//Завдання 6
//Для двох масивів цілих реалізуйте такі запити:
// Отримати різницю двох масивів (елементи першого масиву,
//яких немає у другому).
// Отримати перетин масивів (спільні елементи для обох масивів).
// Отримати об’єднання масивів (елементи обох масивів без
//дублікатів)
// Отримати вміст першого масиву без повторень.

List<int> array1 = Enumerable.Range(0, 10)
    .Select(_ => rand.Next(1, 10)).ToList();
List<int> array2 = Enumerable.Range(0, 10)
    .Select(_ => rand.Next(1, 10)).ToList();

// 1
var difference = array1.Except(array2).ToList();
// 2
var intersection = array1.Intersect(array2).ToList();
// 3
var union = array1.Union(array2).ToList();
// 4
var distinctArray1 = array1.Distinct().ToList();

//Завдання 7:
//Додайте до третього завдання клас, який містить інформацію про
//працівників. Потрібно зберігати такі дані:
// ПІБ співробітника
// Посада
// Контактний телефон
// Email
// Заробітна плата
//Помістіть інформацію про працівників всередину фірми.
//Для масиву співробітників фірми реалізуйте наступні запити:
// Отримати список усіх працівників певної фірми.
// Отримати список усіх працівників певної фірми, в яких
//заробітна плата більша заданої.
//Отримати список працівників усіх фірм, в яких є посада
//«Менеджер».
// Отримати список працівників, в яких телефон починається з 23.
// Отримати усіх працівників, у яких Email починається з «di».
// Отримати список працівників з ім'ям Lionel.

List<Firm> firms = new()
{
    new Firm("FoodMart", new DateTime(2000, 1, 1), "Food", "John White", 200, "London", new List<Employee>
    {
        new Employee("Nazar", "Worker", "+38097568527", "nazar@gmail.com", 1500),
        new Employee("Andry", "Manager", "+38097568527", "woAndr@gmail.com", 1500),
        new Employee("Vanya", "Director", "+38097568527", "dirVan@gmail.com", 1500),
    }),
    new Firm("TechBros", new DateTime(2010, 1, 1), "IT", "James Black", 300, "New York",new List<Employee>
    {
        new Employee("Nazar", "Worker", "+38097568527", "nazar@gmail.com", 1500),
        new Employee("Andry", "Manager", "+38097568527", "woAndr@gmail.com", 1500),
        new Employee("Vanya", "Director", "+38097568527", "dirVan@gmail.com", 1500),
    }),
    new Firm("MarketGurus", new DateTime(2005, 1, 1), "Marketing", "Emma Green", 150, "London",new List<Employee>
    {
        new Employee("Nazar", "Worker", "+38097568527", "nazar@gmail.com", 1500),
        new Employee("Andry", "Manager", "+38097568527", "woAndr@gmail.com", 1500),
        new Employee("Vanya", "Director", "+38097568527", "dirVan@gmail.com", 1500),
    })
};

// 1
var employersOfFirm = new int();
