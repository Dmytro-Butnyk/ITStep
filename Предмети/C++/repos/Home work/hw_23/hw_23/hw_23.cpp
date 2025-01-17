#pragma warning(disable:4996)
#include <iostream>
#define N 252
using namespace std;

class People {
private:
    char* name = new char[N];
    int age{ 0 };
public:
    People(){
        strcpy(name, "No name");
    }
    People(const char* name, int age) :age(age) {
        strcpy(this->name, name);
    }
    People(const People& p) {
        strcpy(name, p.name);
        age = p.age;
    }
    People& operator=(const People& p) {
        if (name != nullptr) delete[] name;
        strcpy(name = new char[N], p.name);
        age = p.age;

        return *this;
    }

    char* GetName() const {
        return name;
    }
    int GetAge() const {
        return age;
    }

    void SetName(const char* Name) {
        if (name != nullptr) delete[] name;
        strcpy(name = new char[N], Name);
    }
    void SetAge(int Age) {
        age = Age;
    }

    void Show() const {
        cout << "Name: " << name << ", Age: " << age << endl;
    }
};

class Flat {
private:
    int p_num{ 3 };
    People* people = new People[p_num];
    int size{57};
    int num{1};
public:
    Flat() {};
    Flat(int p_num, People*& people, int size, int num) :p_num(p_num), size(size), num(num) {
        delete[] this->people;
        this->people = people;
    }
    Flat(const Flat& f) {
        delete[] people;
        p_num = f.p_num;
        people = f.people;
        size = f.size;
        num = f.num;
    }
    Flat& operator=(const Flat& f) {
        delete[] people;
        p_num = f.p_num;
        people = f.people;
        size = f.size;
        num = f.num;

        return *this;
    }
    People* GetPeople() const {
        return people;
    }
    int GetSize() const {
        return size;
    }
    int GetNum() const {
        return num;
    }

    void SetPeople(People* p, int p_num) {
        delete[] people;
        this->p_num = p_num;
        people = p;
    }
    void SetNum(int num) {
        this->num = num;
    }

    void Show() {
        cout << "Flat:\n";
        for (int i = 0; i < p_num; ++i) {
            people[i].Show();
        }
        cout << "\nSize: " << size << ", number: " << num << endl;
    }
};

class House {
private:
	char* adress;
	int count_flats;
	int floors;
	Flat* flats;
public:
	House()
	{
		strcpy(adress = new char[10], "No adress");
		floors = 0;
		count_flats = 3;
		flats = new Flat[count_flats];
	}
	House(const char* adress, int floors, int count_flats, Flat* flats) :floors(floors), count_flats(count_flats)
	{
		strcpy(this->adress = new char[strlen(adress) + 1], adress);
		this->flats = new Flat[count_flats];
		this->flats = flats;
	}
	House(const House& x)
	{
		strcpy(adress = new char[strlen(x.adress) + 1], x.adress);
		floors = x.floors;
		count_flats = x.count_flats;
		flats = new Flat[x.count_flats];
	}
	House& operator=(const House& x)
	{
		if (flats != nullptr) {
			delete[] flats;
		}
		if (adress != nullptr) delete[] adress;

		strcpy(adress = new char[strlen(x.adress) + 1], x.adress);
		floors = x.floors;
		count_flats = x.count_flats;
		flats = new Flat[x.count_flats];

		return *this;
	}
	~House()
	{
		if (flats != nullptr) {
			delete[] flats;
		}
		if (adress != nullptr) delete[] adress;
	}

	inline char* GetAdress() const
	{
		return adress;
	}
	inline void SetAdress(const char* adress)
	{
		if (this->adress != nullptr) delete[] this->adress;
		strcpy(this->adress = new char[strlen(adress) + 1], adress);
	}

	inline int GetKilkFloors() const
	{
		return floors;
	}
	inline void SetKilkFloors(int floors)
	{
		this->floors = floors;
	}

	inline int GetKilkApart() const
	{
		return count_flats;
	}
	inline Flat* GetFlats() const
	{
		return flats;
	}
	inline void SetFlats(Flat* arr)
	{
		if (flats != nullptr) {
			delete[] flats;
		}
		flats = new Flat[count_flats];
	}

	inline void Show() const
	{
		cout << "Adresses: " << adress << " | Floors: " << floors << " | Count of flats: " << count_flats << endl;
		cout << "Flats:\n";
		for (int i = 0; i < count_flats; ++i) {
			cout << i + 1 << ".\n";
			flats[i].Show();
			cout << endl;
		}
	}
};

int main()
{
    Flat p1;
    p1.SetNum(228);
    Flat p2(p1);

    p1.Show();
    p2.Show();
    
    House dom;
    dom.Show();

    cout << endl;
    system("pause");
}