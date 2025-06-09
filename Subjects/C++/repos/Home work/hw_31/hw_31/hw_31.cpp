#include <iostream>
using namespace std;

/*
class Pet {
protected:
	string name{ "Pet name" };
	string owner_name{ "Owner name" };
	int age{ 0 };
	string type{ type };
public:
	Pet(string name, string owner_name, int age, string type) :name(name),
		owner_name(owner_name), age(age), type(type) {}
	Pet() {}
	virtual ~Pet() { cout << "Pet del"; }

	inline string GetName() const {
		return name;
	}
	inline string GetOwnerName() const {
		return owner_name;
	}
	inline int GetAge() const {
		return age;
	}
	inline bool GetTrained() const {
		return 0;
	}

	inline void SetAge(int Age) {
		age = Age;
	}


	void virtual Show() const {
		cout << "Name: " << name << "\nOwner name: " << owner_name <<
			"\nAge: " << age << endl;
	}

	void virtual Voice() {
		cout << name << " say: Pet voice!";
	}
};

class Cat : public Pet {
protected:
	string home_name{ "Home name" };
	string fav_toy{ "Toy" };
	string food{ "Food" };
	string behavior{ "Playful" };
public:
	Cat(string name, string owner_name, int age, string type, string home_name, string fav_toy,
		string food, string behavior) :
		Pet(name, owner_name, age, type), home_name(home_name),
		fav_toy(fav_toy), food(food), behavior(behavior) {}
	Cat() {}

	inline string GetHomeName() const { return home_name; }
	inline string GetFavToy() const { return fav_toy; }
	inline string GetFood() const { return food; }
	inline string GetBehavior() const { return behavior; }

	void Voice() {
		cout << home_name << " say: \"Meow :3\"";
	}

	void Show() const {
		cout << "Home name: " << home_name << "\nOwner name: " << owner_name <<
			"\nAge: " << age << "\nFavorite toy: " << fav_toy << "\nFavorite food: " << food
			<< "\nBehavior: " << behavior << endl;
	}

	~Cat() { cout << "C del"; }
};

class Dog : public Pet {
protected:
	string home_name{ "Home name" };
	bool trained{ 0 };
	string fav_place{ "Park" };
public:
	Dog(string name, string owner_name, int age, string type, string home_name,
		bool trained, string fav_place) :
		Pet(name, owner_name, age, type), home_name(home_name),
		trained(trained), fav_place(fav_place) {}
	Dog() {}

	inline string GetHomeName() const { return home_name; }
	inline string GetFavPlace() const { return fav_place; }
	inline bool GetTrained() const { return trained; }

	void Voice() {
		cout << home_name << " say: \"Wooof :>\"";
	}

	void Show() const {
		cout << "Home name: " << home_name << "\nOwner name: " << owner_name <<
			"\nAge: " << age << "\nFavorite place: " << fav_place <<
			"\nIs trained: " << ((trained) ? "Yes" : "No") << endl;
	}

	~Dog() { cout << "D del"; }
};

class Parrot : public Pet {
protected:
	string home_name{ "Home name" };
	string color{ "Green" };
	bool can_speak{ 0 };
public:
	Parrot(string name, string owner_name, int age, string type, string home_name,
		string color, bool can_speak) :
		Pet(name, owner_name, age, type), home_name(home_name),
		color(color), can_speak(can_speak) {}
	Parrot() {}

	inline string GetHomeName() const { return home_name; }
	inline string GetColor() const { return color; }
	inline bool GetCanSpeak() const { return can_speak; }

	void Voice() {
		cout << home_name << " say: \"Chirik-chirik :>\"";
	}

	void Show() const {
		cout << "Home name: " << home_name << "\nOwner name: " << owner_name <<
			"\nAge: " << age << "\nFavorite color: " << color <<
			"\n Is can speak: " << ((can_speak) ? "Yes" : "No") << endl;
	}
	~Parrot() { cout << "P del"; }
};
*/

class String {
protected:
	char* data;
	int length;

public:
	String() : data(nullptr), length(0) {}
	String(const char* str)
	{
		length = strlen(str);
		data = new char[length + 1];
		strcpy(data, str);
	}
	String(const String& x)
	{
		length = x.length;
		data = new char[length + 1];
		strcpy(data, x.data);
	}
	String& operator=(const String& x)
	{
		if (this != &x) {
			delete[] data;
			length = x.length;
			data = new char[length + 1];
			strcpy(data, x.data);
		}
		return *this;
	}
	~String()
	{
		clear();
	}

	inline int GetLength() const
	{
		return length;
	}
	inline void clear()
	{
		delete[] data;
		data = nullptr;
		length = 0;
	}

	String operator+(const String& x) const
	{
		String result;
		result.length = length + x.length;
		result.data = new char[result.length + 1];
		strcpy(result.data, data);
		strcat(result.data, x.data);

		return result;
	}
	String& operator+=(const String& x)
	{
		*this += x;
		return *this;
	}

	inline bool operator==(const String& x) const
	{
		return (length == x.length) && (strcmp(data, x.data) == 0);
	}
	inline bool operator!=(const String& x) const
	{
		return !(*this == x);
	}
};

class BinaryString : public String {
public:
	BinaryString() : String() {}
	BinaryString(const char* str)
	{
		length = strlen(str);
		data = new char[length + 1];
		bool isValid = true;

		for (int i = 0; i < length; ++i) {
			if (str[i] != '0' && str[i] != '1') {
				isValid = false;
				break;
			}
		}

		if (isValid) {
			strcpy(data, str);
		}
		else {
			clear();
		}
	}
	BinaryString(const BinaryString& x) : String(x) {}
	BinaryString& operator=(const BinaryString& x)
	{
		if (this != &x) {
			String::operator=(x);
		}
		return *this;
	}

	inline void changeSign()
	{
		data[0] = (data[0] == '+') ? '-' : '+';
	}

	BinaryString operator+(const BinaryString& x) const
	{
		BinaryString result;
		result.length = length + x.length;
		result.data = new char[result.length + 1];
		strcpy(result.data, data);
		strcat(result.data, x.data);

		return result;
	}
	BinaryString& operator+=(const BinaryString& x)
	{
		*this += x;
		return *this;
	}
	inline bool operator==(const BinaryString& x) const
	{
		if (&*this == &x) return true;

		return (this->data == x.data && this->length == length) ? true : false;
	}
	inline bool operator!=(const BinaryString& x) const
	{
		return !(*this == x);
	}
};

int main()
{
    std::cout << "Hello World!\n";
}
