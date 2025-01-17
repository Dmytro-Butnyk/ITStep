
#include <iostream>
using namespace std;

// task 1

int* AlMemory(int size) {
	int* arr = new int[size] {0};
	return arr;
}
void FillArr(int* arr, int size) {
	for (int i = 0; i < size; ++i) {
		arr[i] = rand() % (30 + 30 + 1) - 30;
	}
}
void ShowArr(int* arr, int size) {
	for (int i = 0; i < size; ++i) {
		cout.width(3);
		cout << arr[i];
	}
	cout << endl;
}
void DeleteArr(int*& arr) {
	delete[] arr;
}
void AddToEnd(int*& arr, int& size) {
	int* n_arr = new int[size + 1] {0};

	for (int i = 0; i < size; ++i) {
		n_arr[i] = arr[i];
	}
	size += 1;
	delete[] arr;
	arr = n_arr;
}
void AddToPosition(int*& arr, int& size, int p) {
	int* n_arr = new int[size + 1] {0};

	for (int i = 0, j = 0; i < size + 1; ++i, ++j) {
		if (i == p) ++i;
		n_arr[i] = arr[j];
	}

	size += 1;
	delete[] arr;
	arr = n_arr;
}
void DeleteInPosition(int*& arr, int& size, int p) {

	int* n_arr = new int[size - 1] {0};

	for (int i = 0, j = 0; i < size - 1; ++i, ++j) {
		if (j == p) ++j;
		n_arr[i] = arr[j];
	}

	size -= 1;
	delete[] arr;
	arr = n_arr;
}

// task 2

int* DelSimNum(int* arr, int& size) {
	
	int count = 0;
	int* narr = new int[count];
	for (int i = 0; i < size; ++i) {
		int c = 0;
		for (int o = 2; o < arr[i]; ++o) {
			if ((unsigned)arr[i] % o == 0) {
				++c;
				break;
			}
		}
		if(c != 0) {
			narr[count] = arr[i];
			++count;
		}
	}
	delete[] arr;
	size = count;
	return narr;
}

// task 3

void SortNP(int* arr, int size, int*& min, int*& pos, int& m, int& p) {
	int mi = 0, po = 0;
	int* minus = new int[mi], * posit = new int[po];
		for (int i = 0; i < size; ++i) {
			if (arr[i] < 0) {
				minus[mi] = arr[i];
				mi++;
			}
			else if (arr[i] > 0) {
				posit[po] = arr[i];
				po++;
			}
	}
		m = mi;
		p = po;
		min = minus;
		pos = posit;

}
int main()
{
	srand(time(NULL));
	//task 1

	int size;
	cout << "Enter size of array: ";
	cin >> size;
	if (size <= 1) {
		cerr << "Wrong size!" << endl;
		system("pause");
		return 1;
	}
	int* arr = AlMemory(size);
	FillArr(arr, size);
	ShowArr(arr, size);
	cout << "***" << endl;
	/*arr = DelSimNum(arr, size);
	ShowArr(arr, size);*/

	int n, p;
	int* negative, *positive;
	SortNP(arr, size, negative, positive, n, p);
	cout << "Negative array: ";
	ShowArr(negative, n);
	cout << "Positive array: ";
	ShowArr(positive, p);

	system("pause");
}