#pragma warning(disable:4996)
#include <iostream>
#include <string>
#include <algorithm>
#include <cctype>
#include <map>
#include <cstddef>
using namespace std;

int mystrcmp(const char* str1, const char* str2) {
    if (strlen(str1) > strlen(str2)) return 1;
    if (strlen(str1) < strlen(str2)) return -1;

    for (int i = 0; i < strlen(str1); ++i) {
        if (str1[i] != str2[i]) return 2;
    }
    return 0;
}

char* Uppercase(char* str1) {
    char* ptr = str1;
    while (*ptr) {
        *ptr = toupper(*ptr);
        ptr++;
    }
    return str1;
}

char* Lowercase(char* str1) {
    char* ptr = str1;
    while (*ptr) {
        *ptr = tolower(*ptr);
        ptr++;
    }
    return str1;
}

char* mystrrev(char* str) {
    int len = strlen(str);
    for (int i = 0; i < len / 2; i++) {
        char temp = str[i];
        str[i] = str[len - 1 - i];
        str[len - 1 - i] = temp;
    }
    return str;
}

int main() {
    string text = "Це текст прикладу. Це друге речення. А ось третє речення.";
    string wToRep = "текст";
    string repW = "слово";

    size_t pos = text.find(wToRep);
    while (pos != string::npos) {
        text.replace(pos, wToRep.length(), repW);
        pos = text.find(wToRep, pos + repW.length());
    }

    bool newSentence = true;
    for (char& c : text) {
        if (newSentence && isalpha(c)) {
            c = toupper(c);
            newSentence = false;
        }
        else if (c == '.') {
            newSentence = true;
        }
    }

    map<char, int> letterCount;
    for (char letter : text) {
        if (isalpha(letter)) {
            letterCount[tolower(letter)]++;
        }
    }

    int digitCount = 0;
    for (char letter : text) {
        if (isdigit(letter)) {
            digitCount++;
        }
    }

    cout << "Замінений текст: " << text << endl;
    cout << "Рахунок літер в тексті:" << endl;
    for (const auto& pair : letterCount) {
        cout << pair.first << ": " << pair.second << " разів" << endl;
    }
    cout << "Рахунок цифр в тексті: " << digitCount << " разів" << endl;


    cout << endl;
    system("pause");
}
