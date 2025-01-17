#include <iostream>
#include <vector>
#include <map>
#include <fstream>
#include <string>
#include <sstream>
using namespace std;

typedef map<string, vector<string>> salers;

void ReadFile(const string& Path, salers& sal) {
    ifstream file(Path);
    if (!file.is_open()) {
        cerr << "Error. File couldn`t open!";
        return;
    }

    string key, product;
    while ((file >> key).good()) {
        string product;
        getline(file, product);
        stringstream myProducts;
        myProducts << product;
        string town;
        vector<string> product_name;
        while (myProducts >> town) {
            if (town.find("-") != -1) {
                town.replace(town.find("-"), 1, " ");
            }
            product_name.push_back(town);
        }
        sal.insert({ key, product_name });
    }
    file.close();
}

int main()
{
    std::cout << "Hello World!\n";
}
