#include <iostream>
#define N 512
using namespace std;

// task 1
/*
struct Book {
	char name[N];
	char author[N];
	char publisher[N];
	char genre[N];

	void Init() {
		cout << "Enter name of the book: ";
		cin.getline(name, N);
		cout << "Enter author name: ";
		cin.getline(author, N);
		cout << "Enter publisher name: ";
		cin.getline(publisher, N);
		cout << "Enter genre of the book: ";
		cin.getline(genre, N);
	}
	void Show() {
		cout << "Book:\nName: " << name << "\nAuthor: " << author <<
			"\nPublisher: " << publisher << "\nGenre: " << genre << endl;
	}
	bool IsFits(string a, string g) {
		bool res = false;
		if (author == a && genre == g) {
			Show();
			cout << "Do you want to buy it?\n1 - yes; 0 - no: ";
			cin >> res;
		}
		return res;
	}
};
*/

// task 2
struct Car {
	int length;
	int v_engine;
	int p_engine;
	char color[N];

	void Init() {
		cout << "Enter length: ";
		cin >> length;
		cout << "Enter V engine: ";
		cin >> v_engine;
		cout << "Enter P engine: ";
		cin >> p_engine;
		cout << "Enter color: ";
		cin.getline(color, N);
	}
	void Show() {
		cout << "Cer:\nLength: " << length << "\V engine: " << v_engine <<
			"\P engine: " << p_engine << "\nColor: " << color << endl;
	}
	bool IsFits(int v, string c) {
		if (v_engine == v && color == c) {
			Show();
		}
		return true;
	}
};

int main()
{
	// task 1
	/*
	const int size = 3;
	Book shelf[size];

	for (int i = 0; i < size; ++i) {
		shelf[i].Init();
	}
	cout << "***********************\n";
	string a, g;
	cout << "Enter author of book: ";
	cin >> a;
	cout << "enter genre: ";
	cin >> g;
	for (int i = 0; i < size; ++i) {
		if (shelf[i].IsFits(a, g)) {
			cout << "Buyed!";
		}
	}
	*/

	// task 2


	cout << endl;
	system("pause");
}
