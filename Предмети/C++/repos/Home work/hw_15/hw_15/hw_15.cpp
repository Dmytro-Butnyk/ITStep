#include <iostream>
#include <algorithm>
#include <string>
using namespace std;

/*
struct Book {
	string name;
	string author;
	string publisher;
	string genre;

	void Init() {
		cout << "Enter name of the book: ";
		getline(cin, name);
		cout << "Enter author name: ";
		getline(cin, author);
		cout << "Enter publisher name: ";
		getline(cin, publisher);
		cout << "Enter genre of the book: ";
		getline(cin, genre);
	}
	void Show() {
		cout << "Book:\nName: " << name << "\nAuthor: " << author <<
			"\nPublisher: " << publisher << "\nGenre: " << genre << endl;
	}
};

struct Library {
	Book books[10];

	void Edit(int number) {
		books[number - 1].Init();
	}
	void ShowLibrary() {
		for (int i = 0; i < 10; ++i) {
			books[i].Show();
		}
	}
	void FindByAuthor(string a) {
		cout << "Books with author \"" << a << "\": " << endl;
		for (int i = 0; i < 10; ++i) {
			if (books[i].author == a) {
				books[i].Show();
			}
		}
	}
	void FindByName(string n) {
		cout << "Books with name \"" << n << "\": " << endl;
		for (int i = 0; i < 10; ++i) {
			if (books[i].name == n) {
				books[i].Show();
			}
		}
	}
	void SortByName() {
		sort(books, books + 10, [](const Book& a, const Book& b) {
			return a.name < b.name;
			});
		cout << "Library sorted by name" << endl;
	}
	void SortByAuthor() {
		sort(books, books + 10, [](const Book& a, const Book& b) {
			return a.author < b.author;
			});
		cout << "Library sorted by author" << endl;
	}
};
*/

struct Product {
    string name;
    string manufacturer;
    double price;
};

struct Warehouse {
    static const int maxProducts = 100;

    Product products[maxProducts];

    int numProducts;

    Warehouse() : numProducts(0) {}

    void addProduct(const Product& product) {
        if (numProducts < maxProducts) {
            products[numProducts++] = product;
        }
        else {
            cout << "Warehouse is full. Cannot add more products." << endl;
        }
    }

    void removeProduct(const string& name) {
        for (int i = 0; i < numProducts; ++i) {
            if (products[i].name == name) {
                products[i] = products[--numProducts];
                cout << "Product removed successfully." << endl;
                return;
            }
        }
        cout << "Product not found." << endl;
    }

    void replaceProduct(const string& name) {
        for (int i = 0; i < numProducts; ++i) {
            if (products[i].name == name) {
                cout << "Enter new name: ";
                cin >> products[i].name;
                cout << "Enter new manufacturer: ";
                cin >> products[i].manufacturer;
                cout << "Enter new price: ";
                cin >> products[i].price;
                cout << "Product replaced successfully." << endl;
                return;
            }
        }
        cout << "Product not found." << endl;
    }

    void searchProduct(const string& keyword) {
        for (int i = 0; i < numProducts; ++i) {
            if (products[i].name == keyword || products[i].manufacturer == keyword || to_string(products[i].price) == keyword) {
                cout << "Name: " << products[i].name << ", Manufacturer: " << products[i].manufacturer << ", Price: " << products[i].price << endl;
            }
        }
        if (CountByKeyword(keyword) == 0) {
            cout << "No products found matching the keyword." << endl;
        }
    }

    void sortByPrice() {
        sort(products, products + numProducts, [](const Product& a, const Product& b) {
            return a.price < b.price;
            });
        cout << "Warehouse sorted by price." << endl;
    }

    void printAllProducts() {
        for (int i = 0; i < numProducts; ++i) {
            cout << "Name: " << products[i].name << ", Manufacturer: " << products[i].manufacturer << ", Price: " << products[i].price << endl;
        }
    }

    int CountByKeyword(const string& keyword) {
        return count_if(products, products + numProducts, [keyword](const Product& p) {
            return p.name == keyword || p.manufacturer == keyword || to_string(p.price) == keyword;
            });
    }
};

int main()
{
}