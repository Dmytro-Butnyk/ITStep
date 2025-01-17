#include <iostream>
#include <array>
#include <algorithm>
using namespace std;

int main()
{
	srand(time(NULL));

	// task 1

	/*int up, low, num, sum = 0;
	cout << "Enter range of randon (start end): ";
	cin >> low >> up;

	const int el = 20;
	int arr[el];

	for (int i = 0; i < el; i++) {
		arr[i] = rand() % (up - low + 1) + low;
		cout.width(3);
		cout << arr[i];
	}
	cout << endl;

	cout << "Enter some number in your range: ";
	cin >> num;

	for (auto it : arr) {
		if (it < num) sum += it;
	}

	cout << "Suma of elements less than "<< num << " is: " << sum << endl;*/

	// task 2
	/*
	const int month = 12;
	double income[month], max_profit, min_profit;
	int up_range, bottom_range, min_index = 0, max_index = 0;

	for (int i = 0; i < month; i++) {
		cout << "Enter profit for " << i + 1 << " month: ";
		cin >> income[i];
	}
	for (auto it : income) {
		cout << it << " ";
	}cout << endl;

	cout << "Enter range of months (for example: 3 6): ";
	cin >> bottom_range >> up_range;
	bottom_range--;
	up_range--;

	if (up_range < bottom_range) swap(up_range, bottom_range);

	min_profit = max_profit = income[bottom_range];
	for (int i = bottom_range; i <= up_range; i++) {
		if (max_profit < income[i]) {
			max_profit = income[i];
			max_index = i + 1;
		}
		if (min_profit > income[i]) {
			min_profit = income[i];
			min_index = i + 1;
		}
	}

	cout << "Month with max profit in your range is: " << max_index <<
	"\nMonth with min profit in your range is: " << min_index << endl;
	*/

	// task 3

	/*
	const int elements = 10;
	double arr[elements], sum_negative = 0,
		prod_mm = 1, prod_paired = 1, sum_pn = 0;

	double t_range = 50.0, b_range = -50.0;

	for (int i = 0; i < elements; ++i) {
		arr[i] = b_range + double(rand()) / RAND_MAX * (t_range - b_range);
	}
	double max = arr[0], min = arr[0];

	for (auto it : arr) {
		cout << it << " ";
	}cout << endl;

	for (int i = 0; i < elements; ++i) {
		if (arr[i] < 0) sum_negative += arr[i];
	}

	int index_min, index_max;
	for (int i = 0; i < elements; i++) {
		if (max < arr[i]) {
			max = arr[i];
			index_max = i;
		}
		if (min > arr[i]) {
			min = arr[i];
			index_min = i;
		}
	}
	if (index_min > index_max) swap(index_min, index_max);
	for (int i = index_min + 1; i < index_max; i++) {
		prod_mm *= arr[i];
	}

	for (int i = 2; i < elements; i + 2) {
		prod_paired *= arr[i];
	}

	double f_n, l_n;
	for (int i = 0; i < elements; i++) {
		if (arr[i] < 0) f_n = i;
		break;
	}
	for (int i = elements-1; i > 0; i--) {
		if (arr[i] < 0) l_n = i;
		break;
	}
	for (int i = f_n + 1; i < l_n; i++) {
		sum_pn += arr[i];
	}

	cout << "Suma of negative numbers: " << sum_negative << endl;
	cout << "Product of elements between min and max: " << prod_mm << endl;
	cout << "Product of elements with paired index: " << prod_paired << endl;
	cout << "Suma of elements between first and last negative elements: " << sum_pn << endl;
	*/

	// task 4

	const int elements = 10;
	int marks[elements];

	for (int i = 0; i < elements; i++) {
		cout << "Enter mark № " << i + 1 << ':';
		cin >> marks[i];
	}
	int x = -1;
	while (x != 0) {
		cout << "Enter\n1 - to show marks;\n2 - to show 3 best exams;" <<
			"\n3 - to change mark;\n4 - to show average mark and to know can you be for scholarships.";
		cin >> x;

		switch (x)
		{
		case 1:
			for (int i = 0; i < elements; i++) {
				cout << i + 1 << ". " << marks[i] << endl;
			}
			break;
		case 2:
			int arr[elements];
			for (int i = 0; i < elements; ++i) {
				arr[i] = marks[i];
			}
			sort(arr[0], elements);
			cout << "3 best marks: " << endl;
			for (int i = elements - 4; i < elements; i++) {
				cout.width(3);
				cout << arr[i];
			}
			cout << endl;
			delete[] arr;
			break;
		case 3:
			int exam, new_mark;
			cout << "Enter number of exam (1 - 10) to change: ";
			cin >> exam;
			cout << "Enter new mark: ";
			cin >> new_mark;

			marks[exam] = new_mark;
		case 4:
			double aver = 0;

			for (auto it : marks) {
				aver += it;
			}
			aver /= elements;

			if (aver >= 10.7) cout << "You can get scholarships" << endl;
			else cout << "You can`t get scholarships" << endl;

			break;
		default:
			break;
		}
	}

	system("pause");
	return 0;
}