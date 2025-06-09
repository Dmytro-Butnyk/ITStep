#include <iostream>
#include <string>
#include <fstream>
#include <stack>
using namespace std;

class Firm {
private:
    string name{"Name"};
    string owner{ "Owner" };
    string phoneNumber{ "Phone number" };
    string adress{ "Adress" };
    string direction{ "Direction" };

public:
    Firm(string name, string owner, string phoneNumber, string adress, string direction):
        name(name), owner(owner), phoneNumber(phoneNumber), adress(adress), direction(direction){}
    Firm(){}

    inline string GetName() const { return name; }
    inline string GetOwner() const { return owner; }
    inline string GetPhoneNumber() const { return phoneNumber; }
    inline string GetAdress() const { return adress; }
    inline string GetDirection() const { return direction; }

    friend istream& operator>>(istream& s, Firm& x) {
        cout << "Firm name: ";
        getline(cin, x.name);
        cout << "Owner name: ";
        getline(cin,x.owner);
        cout << "Phone number: ";
        getline(cin, x.phoneNumber);
        cout << "Adress: ";
        getline(cin, x.adress);
        cout << "Direction: ";
        getline(cin,x.direction);
        return s;
    }
    inline void Show() const {
        cout << endl << "Firm name: " << name;
        cout << "\nOwner name: " << owner;
        cout << "\nPhone number: " << phoneNumber;
        cout << "\nAdress: " << adress;
        cout << "\nDirection: " << direction << endl;
    }

    inline string ToString() const {
        return name + "\n" + owner + "\n" + phoneNumber + "\n" + adress + "\n" + direction;
    }


    friend ifstream& operator>>(ifstream& s, Firm& x) {
        s >> x.name;
        s >> x.owner;
        s >> x.phoneNumber;
        s >> x.adress;
        s >> x.direction;
        return s;
    }
    friend ostream& operator<<(ostream & s, Firm & x) {
        s << x.ToString();
        return s;
    }

};

class FirmDirectory {
private:
    string path{""};
    int size{0};
    Firm* firms{nullptr};
public:
    FirmDirectory(string path, int size, Firm*& firms) : size(size), firms(firms), path(path){
        firms = nullptr;
    }
    FirmDirectory(int size, Firm*& firms) : size(size), firms(firms) {
        firms = nullptr;
    }
    FirmDirectory(string path):path(path){
        ifstream inFile(path);
        inFile >> size;
        firms = new Firm[size];
        for (int i = 0; i < size; ++i) {
            inFile >> firms[i];
        }
        inFile.close();
    }
    ~FirmDirectory() {
        ofstream inFile(path);
         inFile << *this;
        
        inFile.close();

        if (firms != nullptr) delete[]firms;
    }

    FirmDirectory(FirmDirectory&& x) {
        path = x.path;
        firms = x.firms;
        size = x.size;

        x.firms = nullptr;
    }
    FirmDirectory& operator=(FirmDirectory&& x) {
        if (this != &x) {
            if (firms != nullptr) delete[] firms;
            path = x.path;
            firms = x.firms;
            size = x.size;

            x.firms = nullptr; 
        }

        return *this;
    }

    void AddFirm() {

        Firm* temp = firms;
        
        firms = new Firm[size + 1]();

        for (int i = 0; i < size; ++i) {
            firms[i] = temp[i];
        }
       
        cin>>firms[size];
        ++size;
        if(temp!=nullptr) delete[] temp;
    }
    void DeleteFirm() {
        Firm* temp = firms;

        firms = new Firm[size - 1];

        for (int i = 0; i < size - 1; ++i) {
            firms[i] = temp[i];
        }

        --size;
        delete[] temp;
    }

    void SearchByName(string name) {
        for (int i = 0; i < size; ++i) {
            if (firms[i].GetName() == name)
                cout << firms[i];
        }
    }
    void SearchByOwner(string name) {
        for (int i = 0; i < size; ++i) {
            if (firms[i].GetOwner() == name)cout << firms[i];
        }
    }
    void SearchByPhoneNumber(string name) {
        for (int i = 0; i < size; ++i) {
            if (firms[i].GetPhoneNumber() == name)  cout << firms[i];

        }
    }
    void SearchByDirection(string name) {
        for (int i = 0; i < size; ++i) {
            if (firms[i].GetDirection() == name)cout << firms[i];
        }
    }

    friend ifstream& operator>>(ifstream& s, FirmDirectory& x) {
        s >> x.size;
        for (int i = 0; i < x.size; ++i) {
            s >> x.firms[i];
        }
        return s;
    }
    friend ofstream& operator<<(ofstream& s, FirmDirectory& x) {
        if (x.size > 0) {
            s << x.size << "\n";
            for (int i = 0; i < x.size; ++i) {
                s << x.firms[i].ToString();
            }
       }
        return s;
    }

    friend istream& operator>>(istream& s, FirmDirectory& x) {
        if (x.firms != nullptr) delete[] x.firms;

        cout << "Size: ";
        s >> x.size;

        x.firms = new Firm[x.size];
        for (int i = 0; i < x.size; ++i) {
            cin>>x.firms[i];
        }
        return s;
    }
    friend ostream& operator<<(ostream& s, FirmDirectory& x) {
        s << "Size: " << x.size << "\tPath: " << x.path;

        s << "\nFirms:\n";
        for (int i = 0; i < x.size; ++i) {
            x.firms[i].Show();
        }
        return s;
    }



};

bool isValidHTML(const string& filePath) {
    ifstream inputFile(filePath);

    if (!inputFile.is_open()) {
        cerr << "Error opening file: " << filePath << endl;
        return false;
    }

    stack<string> tagStack;
    string line;

    while (getline(inputFile, line)) {
        size_t pos = 0;
        while ((pos = line.find('<', pos)) != string::npos) {
            size_t endPos = line.find('>', pos);
            if (endPos == string::npos) {
                cout << "Error: unclosed tag found in line: " << line << endl;
                return false;
            }

            string tag = line.substr(pos + 1, endPos - pos - 1);

            if (tag[0] == '/') {
                if (tagStack.empty()) {
                    cout << "Error: unexpected closing tag found in line: " << line << endl;
                    return false;
                }

                string openTag = tagStack.top();
                tagStack.pop();

                if (openTag != tag.substr(1)) {
                    cout << "Error: mismatched closing tag found in line: " << line << endl;
                    return false;
                }
            }
            else {
                tagStack.push(tag);
            }

            pos = endPos + 1;
        }
    }

    if (!tagStack.empty()) {
        cout << "Error: unclosed tags found in the file." << endl;
        return false;
    }

    cout << "HTML file is valid." << endl;
    return true;
}

int main()
{
    setlocale(0, "");
    FirmDirectory f("file.txt");
    int choice = -1;
    
    while (choice != 0) {
        cout << "Enter\n1 - Пошук за назвою;\n2 - Пошук за власником;" <<
            "\n3 - Пошук за номером телефону;\n4 - Пошук за родом діяльності;" <<
            "\n5 -  Виведення на екран всіх записів;\n6 - Додавання;" <<
            "\n7 - Видалення";
        cin >> choice;
        cin.ignore();

            string s;

        switch(choice) {
        case 1:
            cout << "Enter: ";
            getline(cin, s);
            f.SearchByName(s);
            break;
        case 2:
            cout << "Enter: ";
            getline(cin, s);
            f.SearchByOwner(s);
            break;
        case 3:
            cout << "Enter: ";
            getline(cin, s);
            f.SearchByPhoneNumber(s);
            break;
        case 4:
            cout << "Enter: ";
            getline(cin, s);
            f.SearchByDirection(s);
            break;
        case 5:
            cout << f;
            break;
        case 6:
            f.AddFirm();
            break;
        case 7:
            f.DeleteFirm();
        }

    }

    string filePath = "HTML.txt";

    isValidHTML(filePath);

    cout << endl;
    system("pause");
}