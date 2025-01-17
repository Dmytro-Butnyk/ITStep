#include <iostream>
#pragma warning(disable:4996)
using namespace std;

class Human {
	// private: 

public:
	char* getName()const {
		if (name == nullptr) return new char[10] {"NoName"};
		return name;
	}
	char* getLastName()const {
		if (lastName == nullptr) return new char[10] {"NoName"};
		return lastName;
	}
	unsigned getAge() const {
		return age;
	}

	void setName(char* name) {
		if (this->name != nullptr) delete[] this->name;
		this-> name = new char [strlen(name)+1];
		strcpy(this->name, name);
	}
	void setLastName(char* lastName) {
		if (this->lastName != nullptr) delete[] this->lastName;
		this->lastName = new char[strlen(lastName) + 1];
		strcpy(this->lastName, lastName);
	}
	void setAge(unsigned age) {
		this->age = age;
	}
private:
	char* name{ nullptr };
	char* lastName{ nullptr };
	unsigned age = 0;

};

int main()
{

	Human first;
	cout << first.getName() << endl;
	char s[25]{ "" };

	cout << "Enter name: " << endl;
	cin.getline(s, 25);
	first.setName(s);

	cout << "Enter last name: " << endl;
	cin.getline(s, 25);
	first.setLastName(s);
	
	int a;
	cout << "Enter age: " << endl;
	cin >> a;
	first.setAge(a);

	cout << "Name: " << first.getName() << "; Last name: " << first.getLastName() << "; Age: " << first.getAge();

	cout << endl; 
	system("pause");
}