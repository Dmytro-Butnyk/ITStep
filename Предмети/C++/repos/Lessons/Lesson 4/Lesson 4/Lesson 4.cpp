#include <iostream>
#include <random>
using namespace std;
#define N 5

int main()
{
	srand(time(NULL));

	/*int x[N];

	for (int i = 0; i < size(x); i++) {
		x[i] = i + 1;
		cout << x[i] << ' ';
	}

	int size_of_x = sizeof(x) / sizeof(x[0]);

	cout << "\nSize of x array: " << size(x) << endl;*/

	// task 1

	/*const int month = 6;
	double income[month], sum_income = 0;
	cout << "Enter income for every of six month: ";
	for (int i = 0; i < size(income); i++) {
		cin >> income[i];
		sum_income += income[i];
	}
	for (int i = 0; i < size(income); i++) {
		cout << "Income of " << i + 1 << " month is: " << income[i] << endl;
	}
	cout << "Suma of income for six month: " << sum_income << endl;*/

	// task 2

	/*const int num = 10;
	int rnd[10];

	cout << "Original array: " << endl;

	for (int i = size(rnd) - 1; i >= 0; i--) {
		rnd[i] = rand() % (50 - 1 + 1) + 1;
	}

	for (auto i : rnd) {
		cout << i << " ";
	}

	cout << "\nReversed array: " << endl;

	for (int i = size(rnd) - 1; i >= 0; i--) {
		cout << rnd[i] << " ";
	}
	cout << endl;*/

	// task 3

	/*const int count = 6;
	float sides[count], perimeter = 0;

	for (int i = 0; i < size(sides); i++) {
		cout << "Enter length of " << i + 1 << " side: ";
		cin >> sides[i];
	}

	for (auto i : sides) {
		perimeter += i;
	}
	cout << "Perimeter of pentagon: " << perimeter << endl;
	*/

	// task 4

	/*const int el = 10;
	int array[el], max, min;

	for (int i = 0; i < size(array); i++) {
		array[i] = rand() % (100 - 1 + 1) + 1;
	}

	cout << "Array:" << endl;
	for (auto i : array) {
		cout << i << " ";
	}

		min = max = array[0];
	for (auto it : array) {
		if (min > it) {
			min = it;
		}
		if (max < it) {
			max = it;
		}
	}
	cout << "\nMin element: " << min << ", max element: " << max << endl; */

	// task 5 

	/*const int month = 12;
	double firm[month];

	for (int i = 0; i < size(firm); i++) {
		cout << "Enter income for " << i + 1 << " month: ";
		cin >> firm[i];
	}
	int min, max;
	min = max = firm[0];

	for (auto it : firm) {
		if (min > it) {
			min = it;
		}
		if (max < it) {
			max = it;
		}
	}

	int index_min, index_max;

	for (int i = 0; i < size(firm); i++) {
		if (firm[i] == min) {
			index_min = i + 1;
			break;
		}
	}
	for (int i = 0; i < size(firm); i++) {
		if (firm[i] == max) {
			index_max = i + 1;
			break;
		}
	}
	cout << "Minimal income is in " << index_min << " month, maximal income is in " << index_max << " month" << endl;*/
	
	// task 6

	/*const int el = 20;
	int array[el];

	for (int i = 0; i < size(array); i++) {
		array[i] = rand() % (100 - 10 + 1) + 10;
		if (i == 4 || i == 14) array[i] = 4;
	}
	cout << "Array:" << endl;
	for (auto it : array) {
		cout << it << ' ';
	}
	cout << endl;

	int min, index1, index2;
	min = array[0];

	for (auto it : array) {
		if (min > it) {
			min = it;
		}
	}
	int index_min, index_max;

	for (int i = 0; i < size(array); i++) {
		if (array[i] == min) {
			index1 = i;
			break;
		}
	}
	for (int i = 0; i < size(array); i++) {
		if (array[i] == min) {
			index2 = i;
		}
	}
	if (index2 - index1 > 5) {

		bool isSort;
		int j = 0;
		do {
			isSort = false;
			for (int i = index1; i < index2 - 1 - j; ++i) {
				if (array[i] > array[i + 1]) {
					swap(array[i], array[i + 1]);
					isSort = true;
				}
			}
			j++;
		} while (isSort);

		for (int i = index1 + 1; i < index2; i++) {
			for (int j = index1 + 1; j < index2 - 1; j++) {
				if (array[j] > array[j + 1]) {
					swap(array[j], array[j + 1]);
				}
			}
		}

	}
	cout << "Sorted array:" << endl;
	for (auto it : array) {
		cout << it << " ";
	}
	cout << endl;*/

	// task 8

	const int el = 20;
	int arr[el], pos = 0, neg = 0;

	for (int i = 0; i < size(arr); i++) {
		arr[i] = rand() % (20 + 20 + 1) - 20;
	}
	cout << "Array:" << endl;
	for (auto it : arr) {
		cout << it << " ";
	}

	for (auto it : arr) {
		if (it > 0) pos += it;
		if (it < 0) neg += it;
	}
	





	cout << endl;
	system("pause");
	return 0;
}