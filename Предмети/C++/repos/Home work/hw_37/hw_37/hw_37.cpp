#include <iostream>
#include <fstream>
#include <string>
#include <stack>
using namespace std;

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

int main() {
    string filePath = "file.txt";
    
    isValidHTML(filePath);

    cout << endl;
    system("pause");
}
