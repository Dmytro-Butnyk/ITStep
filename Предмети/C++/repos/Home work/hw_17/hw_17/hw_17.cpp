#include <iostream>
#include <fstream>
#include <string>
#include <sstream>
using namespace std;

void CompareFiles(const string& file1Path, const string& file2Path) {
    ifstream file1(file1Path);
    ifstream file2(file2Path);

    if (!file1.is_open() || !file2.is_open()) {
        cerr << "Error opening files." << endl;
        return;
    }

    string line1, line2;
    int lineNum = 0;

    while (getline(file1, line1) && getline(file2, line2)) {
        lineNum++;

        if (line1 != line2) {
            cout << "Files different at line " << lineNum << ":\nFile 1: " << line1 << "\nFile 2: " << line2 << endl;
        }
    }

    if (file1.eof() && !file2.eof()) {
        cout << "File 1 is shorter than File 2." << endl;
    }
    else if (!file1.eof() && file2.eof()) {
        cout << "File 2 is shorter than File 1." << endl;
    }

    file1.close();
    file2.close();
}
void FileStat(const string& from, const string& in)
{
	fstream inFile;
	fstream outFile;
	string line{ "" };

	try {
		inFile.open(from);
		outFile.open(in, ios::out | ios::trunc);
		if (!inFile.is_open() || !outFile.is_open()) throw exception("Error");
	}
	catch (exception& error) {
		cout << error.what() << endl;
		return;
	}

	int num_char = 0;
	int num_lines = 0;
	int num_words = 0;

	while (getline(inFile, line)) {
		++num_lines;
		num_char += line.length();

		bool isWord = false;
		for (char var : line) {
			if (isspace(var)) isWord = false;
			else if (!isWord) {
				isWord = true;
				++num_words;
			}
		}


	}
	outFile << "Number symvols: " << num_char << endl;
	outFile << "Number rows: " << num_lines << endl;
	outFile << "Number words: " << num_words;

	inFile.close();
	outFile.close();
}
void Shifr(const string& start, const string& end, int key)
{
	fstream inFile;
	fstream outFile;
	string line{ "" };

	try {
		inFile.open(start);
		outFile.open(end, ios::out | ios::trunc);
		if (!inFile.is_open() || !outFile.is_open()) throw exception("Error");
	}
	catch (exception& error) {
		cout << error.what() << endl;
		return;
	}

	while (getline(inFile, line)) {
		for (int i = 0; i < line.length(); ++i) {
			line[i] += key;
			outFile << line[i];
		}
		cout << endl;
	}

	inFile.close();
	outFile.close();
}

int main()
{
    string file1Path = "file1.txt";
    string file2Path = "file2.txt";

    CompareFiles(file1Path, file2Path);

    cout << endl;
    system("pause");
}
