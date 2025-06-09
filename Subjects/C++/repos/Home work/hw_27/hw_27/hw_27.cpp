#include <iostream>
#include <string>
#include <sstream>
#include <algorithm>
using namespace std;

string compressText(const string& input) {
    stringstream input_stream(input);
    string word;
    string compressed_text;

    while (input_stream >> word) {
        compressed_text += word + " ";
    }

    if (!compressed_text.empty()) {
        compressed_text.pop_back();
    }

    return compressed_text;
}

template <typename T>
T findMaximum(const T array[], int size) {
    if (size <= 0) {
        throw invalid_argument("Array size must be greater than zero.");
    }

    T maximum = array[0];
    for (int i = 1; i < size; ++i) {
        if (array[i] > maximum) {
            maximum = array[i];
        }
    }
    return maximum;
}

template <typename T>
void sortArray(T array[], int size) {
    sort(array, array + size);
}

template <typename T>
int binarySearch(const T array[], int size, const T& value) {
    int left = 0;
    int right = size - 1;

    while (left <= right) {
        int mid = left + (right - left) / 2;

        if (array[mid] == value) {
            return mid;  
        }
        else if (array[mid] < value) {
            left = mid + 1;
        }
        else {
            right = mid - 1;
        }
    }

    return -1; 
}

template <typename T>
void replaceElement(T array[], int size, const T& oldValue, const T& newValue) {
    for (int i = 0; i < size; ++i) {
        if (array[i] == oldValue) {
            array[i] = newValue;
            return;  
        }
    }
}

int main()
{
    string input_text;
    cout << "Enter a string: ";
    getline(cin, input_text);

    string comp = compressText(input_text);
    cout << "Compressed text: " << comp << endl;


    cout << endl;
    system("pause");
}