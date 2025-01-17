#include <iostream>
using namespace std;

class Drib {
private:
	int chisl;
	int znam;
public:
	Drib()
	{
		chisl = 0;
		znam = 0;
	}
	Drib(int chisl, int znam) :chisl(chisl), znam(znam) {}

	inline int GetCh() const
	{
		return chisl;
	}
	inline void SetCh(int chisl)
	{
		this->chisl = chisl;
	}

	inline int GetZn() const
	{
		return znam;
	}
	inline void SetZn(int znam)
	{
		this->znam = znam;
	}

	inline void input()
	{
		cout << "Enter chiselnyk: ";
		cin >> chisl;

		cout << "Enter znamenyk: ";
		cin >> znam;
	}
	inline void show() const
	{
		cout << "Drib: " << chisl << "/" << znam << endl;
	}

	friend Drib operator+(const Drib&, const Drib&);
	friend Drib operator-(const Drib&, const Drib&);
	friend Drib operator*(const Drib&, const Drib&);
	friend Drib operator/(const Drib&, const Drib&);

	friend bool operator==(const Drib&, const Drib&);
	friend bool operator!=(const Drib&, const Drib&);
	friend bool operator<(const Drib&, const Drib&);
	friend bool operator>(const Drib&, const Drib&);
};

Drib operator+(const Drib& x, const Drib& y)
{
	Drib z;
	if (x.znam == y.znam) {
		z.chisl = x.chisl + y.chisl;
		z.znam = x.znam;
	}
	else {
		z.znam = x.znam * y.znam;
		z.chisl = x.chisl * y.znam + y.chisl * x.znam;
	}

	return z;
}
Drib operator-(const Drib& x, const Drib& y)
{
	Drib z;

	if (x.znam == y.znam) {
		z.chisl = x.chisl - y.chisl;
		z.znam = x.znam;
	}
	else {
		z.chisl = x.chisl * y.znam - y.chisl * x.znam;
		z.znam = x.znam * y.znam;
	}

	return z;
}
Drib operator*(const Drib& x, const Drib& y)
{
	Drib z;

	z.chisl = x.chisl * y.chisl;
	z.znam = x.znam * y.znam;

	return z;
}
Drib operator/(const Drib& x, const Drib& y)
{
	Drib z;

	z.chisl = x.chisl * y.znam;
	z.znam = x.znam * y.chisl;

	return z;
}

bool operator==(const Drib& x, const Drib& y)
{
	if (&x == &y) return true;
	return (x.chisl * y.znam == y.chisl * x.znam);
}
bool operator!=(const Drib& x, const Drib& y)
{
	return !(x == y);
}
bool operator<(const Drib& x, const Drib& y)
{
	if (x != y) return (x.chisl / x.znam < y.chisl / y.znam);
	else return false;
}
bool operator>(const Drib& x, const Drib& y)
{
	if (x != y) return (x.chisl / x.znam > y.chisl / y.znam);
	else return false;
}

class Flat {
private:
	double price{ 0 };
	int area{ 0 };
	int num_rooms{ 0 };
public:
	Flat(){}
	Flat(double price, int area, int num_rooms):price(price),
		area(area), num_rooms(num_rooms){}

	inline double GetPrice()const {
		return price;
	}
	inline int GetArea() const {
		return area;
	}
	inline int GetNum_Rooms() const {
		return num_rooms;
	}

	inline void SetPrice(double Price) { price = Price; }
	inline void SetArea(int Area) { area = Area; }
	inline void SetNun_Rooms(int Num_rooms) { num_rooms = Num_rooms; }

	friend bool operator==(const Flat& a, const Flat& b) {
		return (a.area == b.area);
	}
	Flat& operator++() {
		++num_rooms;
		return *this;
	}
	Flat& operator--() {
		--num_rooms;
		return *this;
	}

	friend bool operator>(const Flat& a, const Flat& b) {
		double res_A = a.area * a.price;
		double res_B = b.area * b.price;
		return (res_A > res_B);
	}
	friend bool operator<=(const Flat& a, const Flat& b) {
		double res_A = a.area * a.price;
		double res_B = b.area * b.price;
		return (res_A <= res_B);
	}
};

int main()
{
    
}
