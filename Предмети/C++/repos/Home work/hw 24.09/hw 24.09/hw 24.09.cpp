#include <iostream>
using namespace std;

template<typename T> void showArr(T arr, int size) {

	for (int i = 0; i < size; ++i) {
		for (int o = 0; o < size; ++o) {
			cout.width(5);
			cout << arr[i][o];
		}
		cout << endl << endl;
	}
	cout << "***" << endl;
}

template<typename T> void fillLab(T arr, int size) {

	for (int i = 0; i < size; ++i) {
		for (int o = 0; o < size; ++o) {
			arr[i][o] = 0;
		}
	}
	for (int i = 1; i < size-1; ++i) {
		for (int o = 1; o < size-1; ++o) {
			arr[i][o] = rand() % (1 - 0 + 1);
		}
	}
}

template<typename T, typename K> void copyArr(K arr1, T arr2, int size) {
	for (int i = 0; i < size; ++i) {
		for (int o = 0; o < size; ++o) {
			arr1[i][o] = arr2[i + 1][o + 1];
		}
	}
}

template<typename T> void checkLife(T arr, int size) {
	for (int i = 1; i < size - 1; ++i) {
		for (int o = 1; o < size - 1; ++o) {
			if (arr[i - 1][o - 1] + arr[i - 1][o] + arr[i - 1][o + 1] + arr[i][o - 1] + arr[i][o + 1] + arr[i + 1][o - 1] + arr[i + 1][o] + arr[i + 1][o + 1] == 2 && arr[i][o] == 1) arr[i][o] = 1;
			else if (arr[i - 1][o - 1] + arr[i - 1][o] + arr[i - 1][o + 1] + arr[i][o - 1] + arr[i][o + 1] + arr[i + 1][o - 1] + arr[i + 1][o] + arr[i + 1][o + 1] == 2 && arr[i][o] == 0) arr[i][o] = 0;
			else if (arr[i - 1][o - 1] + arr[i - 1][o] + arr[i - 1][o + 1] + arr[i][o - 1] + arr[i][o + 1] + arr[i + 1][o - 1] + arr[i + 1][o] + arr[i + 1][o + 1] == 2 && arr[i][o] == 0) arr[i][o] = 0;
			else if (arr[i - 1][o - 1] + arr[i - 1][o] + arr[i - 1][o + 1] + arr[i][o - 1] + arr[i][o + 1] + arr[i + 1][o - 1] + arr[i + 1][o] + arr[i + 1][o + 1] == 3) arr[i][o] = 1;
			else arr[i][o] = 0;

		}
	}
}


int main()
{

	//task 1

	/*const int size = 5;
	int array[size][size];

	int number;
	cout << "Enter number of first element: ";
	cin >> number;

	for (int i = 0; i < size; ++i) {
		for (int o = 0; o < size; ++o) {
			array[i][o] = number;
			number *= 2;
		}
	}
	showArr(array, size);*/

	// task 2

	srand(time(NULL));

	const int size_1 = 10, size_2 = 11;
	int desert[size_1][size_1], lab[size_2][size_2], n = 5;

	cout << "Enter how many generations must be: ";
	cin >> n;


	fillLab(lab, size_2);

	for (int i = 1; i <= n; ++i) {
		cout << "Generation " << i << endl;
		copyArr(desert, lab, size_1);
		showArr(desert, size_1);
		checkLife(lab, size_2);
	}


	system("pause");
	return 0;
}