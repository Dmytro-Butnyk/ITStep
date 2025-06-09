#include <iostream>
#include <vector>
using namespace std;

// Task 1
/*
class Employer {
protected:
	int age{ 0 };
	string name{ "No name" };
	double salary{ 0 };
	int experience{ 0 };
public:

	Employer(int age, string name, double salary, int experience): age(age), name (name),
		salary(salary), experience(experience){}
	Employer(){}

	inline int GetAge() const {
		return age;
	}
	inline string GetName() const {
		return name;
	}
	inline double GetSalary() const {
		return salary;
	}
	inline int GetExperience() const {
		return experience;
	}

	inline void SetAge(int Age) {
		age = Age;
	}
	inline void SetSalary(double Salary) {
		salary = Salary;
	}
	inline void SetExperience(int Experience) {
		experience = Experience;
	}

	inline virtual void Print() const = 0;
	inline virtual double CalculateSalary() = 0;
	inline bool IsMore3Y() {
		if (experience >= 3) {
			return true;
		}
		return false;
	}
	virtual ~Employer() {}
};

class President : public Employer {
private:
	string dateS{ "" };
	string companyName{ "" };
	string education{ "" };
public:

	President(int age, string name, double salary, int experience,
		string dateS, string companyName, string education):
		Employer(age, name, salary, experience), dateS(dateS),
		companyName(companyName), education(education){}
	President(){}

	inline string GetDateS() const {
		return dateS;
	}
	inline string GetCompanyName() const {
		return companyName;
	}
	inline string GetEducation() const {
		return education;
	}

	inline void SetCompanyName(string name) {
		companyName = name;
	}
	inline void SetEducation(string edu) {
		education = edu;
	}

	inline void Print() const {
		cout << "President name: " << name << "\nCompany name: " << companyName <<
			"\nAge: " << age << "\nSalary: " << salary <<
			"\nDate of start position: " << dateS << endl;
 	}

	inline double CalculateSalary() {
		if (IsMore3Y()) {
			return salary *= 2;
		}
	}
};

class Manager : public Employer {
private: 
	string typeWork{ "" };
	string education{ "" };
	int numberOfSub{ 0 };
public:
	Manager(int age, string name, double salary, int experience,
		string typeWork, string education, int numberOfSub):
		Employer(age, name, salary, experience), typeWork(typeWork),
		education(education), numberOfSub(numberOfSub){}
	Manager(){}

	inline string GetTypeWork() const {
		return typeWork;
	}
	inline string GetEducation() const {
		return education;
	}
	inline int GetNumberOfSub() const {
		return numberOfSub;
	}

	inline void Print() const {
		cout << "Manager name: " << name <<
			"\nAge: " << age << "\nType of management: " << typeWork
			<< "\nNumber of subordinates: " << numberOfSub <<
			"\nSalary: " << salary << endl;
	}

	inline double CalculateSalary() {
		if (IsMore3Y()) {
			return salary *= 1.5;
		}
	}
};

class Worker : public Employer {
private:
	string typeOfWork{ "" };
public:
	Worker(int age, string name, double salary, int experience, 
		string typeOfWork): Employer(age, name, salary, experience),
		typeOfWork(typeOfWork){}
	Worker(){}

	inline string GetTypeOfWork() const {
		return typeOfWork;
	}
	inline void SetTypeOfWork(string t) {
		typeOfWork = t;
	}

	inline void Print() const {
		cout << "Worker name: " << name <<
			"\nAge: " << age << "\nType of work: " << typeOfWork <<
			"\nSalary: " << salary << endl;
	}

	inline double CalculateSalary() {
		if (IsMore3Y()) {
			return salary *= 1.2;
		}
	}
};
*/

// Task 2
/*
class Area {
public:
	virtual ~Area(){}
	Area(){}
	inline virtual double FindArea() = 0;
	inline virtual void Print() const = 0;
};

class Rectangle : public Area {
private:
	double a{ 0 };
	double b{ 0 };
public:
	Rectangle(double a, double b): a(a), b(b){}
	Rectangle(){}

	inline double GetA() const {
		return a;
	}
	inline double GetB() const {
		return b;
	}

	inline void SetA(double A) {
		a = A;
	}
	inline void SetB(double B) {
		b = B;
	}

	inline double FindArea() {
		return a * b;
	}
	inline void Print() const {
		cout << "RECTANGLE:\n" << "A: " << a << "\nB: " << b << endl;
	}
};
class Triangle : public Area {
private:
	double a{ 0 };
	double b{ 0 };
	double c{ 0 };
public:
	Triangle(double a, double b, double c):a(a), b(b), c(c){}
	Triangle(){}

	inline double FindArea() {
		double p = (a + b + c) / 2;
		return sqrt((p * (p - a) * (p - b) * (p - c)));
	}

	inline void Print() const {
		cout << "TRIANGLE:\n" << "A: " << a << "\nB: " << b << "\nC: " << c << endl;
	}
};
class Trapeze : public Area {
private:
	double a{ 0 };
	double b{ 0 };
	double c{ 0 };
public:
	Trapeze(double a, double b, double c) :a(a), b(b), c(c) {}
	Trapeze() {}

	inline double FindArea() {
		double h = sqrt(c * c - (pow((pow((a - b), 2)) / (2 * (a - b)),2)));
		return ((a + b) / 2) * h;
	}

	inline void Print() const {
		
		cout << "TRAPEZE:\n" << "A: " << a << "\nB: " << b << "\nSide ribs: " << c << endl;
	}
};
*/

// Task 3 

class Vehicle {
protected:
	int maxNum;

public:
	Vehicle(int maxNum) : maxNum(maxNum) {}

	virtual void TransportPeople() const = 0;

	int GetMaxNum() const {
		return maxNum;
	}
};

class Car : public Vehicle {
public:
	Car(int maxNum) : Vehicle(maxNum) {}

	void TransportPeople() const override {
		cout << "Car transports " << maxNum << " people." << endl;
	}
};

class Bus : public Vehicle {
public:
	Bus(int maxNum) : Vehicle(maxNum) {}

	void TransportPeople() const override {
		cout << "Bus transports " << maxNum << " people." << endl;
	}
};

class Taxi : public Vehicle {
public:
	Taxi(int maxNum) : Vehicle(maxNum) {}

	void TransportPeople() const override {
		cout << "Taxi transports " << maxNum << " people." << endl;
	}
};

bool BrokenV() {
	return rand() % (1 - 0 + 1);
}

int main()
{
	srand(unsigned(time(NULL)));
	// Task 1
	/*
	const int size = 4;
	const double sal = 20000;
	Employer* Company[size]{
		new President(48, "Igor", sal, 20, "03.05.2017", "Brain", "second high"),
		new Manager(31, "Zhenya", sal, 10, "Sales", "first high", 1),
		new Worker(25, "Misha", sal, 2, "Saller"),
		new Worker(24, "Andrey", sal, 3, "Stock")
	};

	cout << "Experience >= 3: \n";
	for (int i = 0; i < size; ++i) {

		if (Company[i]->IsMore3Y()) {
			Company[i]->Print();
			cout << endl;
		}
	}

	cout << endl << "Recalculated salary:\n";
	for (int i = 0; i < size; ++i) {
		Company[i]->CalculateSalary();
		Company[i]->Print();
		cout << endl;
	}

	for (int i = 0; i < size; ++i) {
		delete Company[i];
	}
	*/

	// Task 2
	/*
	const int size = 3;
	Area* figures[size]{
		new Rectangle(2, 4),
		new Triangle(3, 4, 5),
		new Trapeze(1, 4, 3)
	};

	for (int i = 0; i < size; ++i) {
		figures[i]->Print();
		cout << "Area: " << figures[i]->FindArea() << endl;
	}
	*/

	// Task 3
	const int NumCars = 3;
	const int NubBuses = 2;
	const int NumTaxis = 4;

	vector<Vehicle*> autopark;

	for (int i = 0; i < NumCars; ++i) {
		autopark.push_back(new Car(4));
	}

	for (int i = 0; i < NubBuses; ++i) {
		autopark.push_back(new Bus(30));
	}

	for (int i = 0; i < NumTaxis; ++i) {
		autopark.push_back(new Bus(8));
	}

	int peopleTransported = 0;
	int numberBroken = 0;

	for (const auto& veh : autopark) {
		if (!BrokenV()) {
			veh->TransportPeople();
			peopleTransported += veh->GetMaxNum();
		}
		else ++numberBroken;
	}

	cout << "Total transorted people: " << peopleTransported * 2 <<
		"\nBroken ones count: " << numberBroken << endl;

	for (const auto& veh : autopark) {
		delete veh;
	}

	cout << endl;
	system("pause");
}