#pragma warning(disable:4996)
#include <iostream>
#include <algorithm>
using namespace std;

/*class MyString {
private:
	int size = 81;
	char* str = new char[size] {""};
public:
	MyString() {
		str = new char[size = 81] { "" };
	}
	MyString(int size) {
		str = new char[this->size = size + 1] {""};
	}
	MyString(const char* MyString) {
		str = new char[size = strlen(MyString) + 1];
		strcpy(str, MyString);
	}
	MyString(MyString& toCopy) {
		str = new char[strlen(toCopy.str) + 1];
		strcpy(str, toCopy.str);
	}
	MyString& operator =(MyString& toCopy) {
		if (str != nullptr) delete[] str;
		str = new char[strlen(toCopy.str) + 1];
		strcpy(str, toCopy.str);
		size = toCopy.size;
		return *this;
	}

	~MyString() {
		delete[] str;
	}

	const char* GetMyString() const {
		return str;
	}
	void SetMyString(char* str) {
		if (strlen(this->str) > strlen(str) && str != nullptr) {
			strcpy(this->str, str);
		}
	}

	inline void ShowMyString() {
		cout << str;
	}
	inline void InputMyString() {
		char ch[1024];
		cout << "Enter MyString: " << endl;
		cin.getline(ch, 1024);
		str = new char[size = 1024];
		strcpy(str, ch);
	}

	inline void SetNewSize(int size) {
		char* buf = new char[strlen(str)+1];
		strcpy(buf, str);
		if (str != nullptr) delete[] str;
		if (str == nullptr) {
			delete[] str;
			str = new char[size+1];
		}
		if (size > this->size || size < this->size) {
			str = new char[size+1];
			str[size + 1] = '\0';
			strncpy(str, buf, size);
		}
		else if (size+1 == strlen(buf)) {
			str = new char[size+1];
			strcpy(str, buf);
		}
		this->size = size + 1;
	}

};*/

class ArrayInt {
private:
	int size;
	int* array;
public:
	ArrayInt() {
		size = 10;
		array = new int[size] {0};
	}
	ArrayInt(int size) {
		this->size = size;
		array = new int[size] {0};
	}
	ArrayInt(int* arr, int size) {
		array = new int[size];
		memcpy(array,arr,size*sizeof(int));
		this->size = size;
	}
	ArrayInt(const ArrayInt& toCopy) {
		array = new int[size = toCopy.size];
		memcpy(array, toCopy.array, size);
	}
	ArrayInt& operator =(ArrayInt& toCopy) {
		if (array != NULL) delete[] array;
		array = new int[size = toCopy.size];
		memcpy(array, toCopy.array, size);
		return *this;
	}
	~ArrayInt() {
		delete[] array;
	}
	int* GetArray() const {
		int* array_cpy = new int[size];
		memcpy(array_cpy, array, size);
		return array_cpy;
	}
	int GetSize() const {
		return size;
	}
	void ShowArray() {
		cout << "Your array:\n";
		for (int i = 0; i < size; ++i) {
			cout.width(4);
			cout << array[i];
		}
		cout << endl;
	}
	void SortArray() {
		sort(array, array+size);
	}
	int MinOfArray() {
		int min = array[0];
		for (int i = 0; i < size; ++i) {
			min = (min > array[i])?array[i] : min;
		}
		return min;
	}
	int MaxOfArray() {
		int max = array[0];
		for (int i = 0; i < size; ++i) {
			max = (max > array[i]) ? max : array[i];
		}
		return max;
	}
	void InputArray() {
		cout << "Enter " << size << " elements:\n";
		for (int i = 0; i < size; ++i) {
			cout << "Enter " << i + 1 << " element: ";
			cin >> array[i];
		}
	}
};

int main()
{
	ArrayInt array;

	array.InputArray();
	array.ShowArray();
	int min = array.MinOfArray();
	cout << "Min: " << min;
	int max = array.MaxOfArray();
	cout << "Max: " << max;
	
	array.SortArray();
	array.ShowArray();

	cout << endl;
	system("pause");
}
