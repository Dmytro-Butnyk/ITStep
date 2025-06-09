#pragma warning(disable:4996)
#include <iostream>
#include <cstring>
#include <fstream>
using namespace std;

class Contact {
private:
	char* name;
	char number[14];
	char description[524];
public:
	Contact(const char* name, const char* number, const char* description)
	{
		this->name = new char[strlen(name) + 1];
		strcpy(this->name, name);
		strcpy(this->number, number);
		strcpy(this->description, description);
	}
	Contact()
	{
		name = new char[12] {"No name"};
		strcpy(number, "No number");
		strcpy(description, "No info");
	}
	~Contact()
	{
		delete[] name;
	}

	inline void init()
	{
		char s[524];
		cout << "Name: ";
		cin.getline(s, 524);

		delete[] name;
		name = new char[strlen(s) + 1];
		strcpy(name, s);

		cout << "Number: ";
		cin.getline(number, 14);

		cout << "Description: ";
		cin.getline(description, 524);
	}
	inline void show() const
	{
		cout << "Info:\n";
		cout << "Name: " << name << "\nNumber: " << number << "\nDescription: " << description << endl;
	}

	inline char* GetInitials() const
	{
		return name;
	}
	inline void SetInitials(const char* name)
	{
		delete[] this->name;
		this->name = new char[strlen(name) + 1];
		strcpy(this->name, name);
	}

	inline const char* GetNumber() const
	{
		return number;
	}
	inline void SetNumber(const char* number)
	{
		strcpy(this->number, number);
	}

	inline const char* GetAdditionalInfo() const
	{
		return description;
	}
	inline void SetAdditionalInfo(const char* description)
	{
		strcpy(this->description, description);
	}
};
int main()
{
	cout << endl;
	system("pause");
}