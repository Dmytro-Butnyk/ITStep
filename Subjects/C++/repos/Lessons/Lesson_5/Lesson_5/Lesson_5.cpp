#include <iostream>
using namespace std;

int sumaA(int x[][3], int row, int col) {
	int suma = 0;

	for (int i = 0; i < row; i++) {
		for (int o = 0; o < col; o++) {
			suma += x[i][o];
		}
	}
	return suma;
}

int minA(int x[][3], int row, int col) {
	int min = x[0][0];
	for (int i = 0; i < row; i++) {
		for (int o = 0; o < col; o++) {
			if (min > x[i][o]) min = x[i][o];
		}
	}
	return min;
}

int maxA(int x[][3], int row, int col) {
	int max = x[0][0];
	for (int i = 0; i < row; i++) {
		for (int o = 0; o < col; o++) {
			if (max < x[i][o]) max = x[i][o];
		}
	}
	return max;
}

int averA(int x[][3], int row, int col) {
	double average = 0;
	for (int i = 0; i < row; ++i) {
		for (int o = 0; o < row; ++o) {
			average += x[i][o];
		}
	}
	average /= row * col;
	return average;
}

int main()
{

	// task 1

	/*const int row = 3, col = 3;

	int arr[row][col] = {
		{3, 2, 1},
		{4, 5, 6},
		{9, 8, 7}
	};

	cout << sumaA(arr, row, col) 
		<< endl << averA(arr, row, col)
		<< endl << minA(arr, row, col)
		<< endl << maxA(arr, row, col);*/

	// task 2

	/*const int row = 3, col = 4;

	int arr[row][col] = {
		{3, 2, 1, 7},
		{4, 5, 6, 7},
		{9, 8, 7, 7}
	};
	int sumaR[row], sumaC[col], suma = 0;

	for (int i = 0; i < row; i++) {
		int sr = 0;
		for (int o = 0; o < col; o++) {
			sr += arr[i][o];
			suma += arr[i][o];
		}
		sumaR[i] = sr;
	}
	for (int i = 0; i < col; i++) {
		int sc = 0;
		for (int o = 0; o < row; o++) {
			sc += arr[o][i];
		}
		sumaC[i] = sc;
	}

	for (int i = 0; i < row; i++) {
		for (int o = 0; o < col; o++) {
			cout.width(3);
			cout << arr[i][o];
		}
		cout << '|' << sumaR[i]<< endl;
	}
	for (int i = 0; i < col + 1; i++) {
		cout.width(3);
		cout << '-';
	}
	cout << endl;
	for (int i = 0; i < col; i++) {
		cout.width(3);
		cout << sumaC[i];
	}
	cout.width(2);
	cout << "| " << suma << endl;*/

	// task 3

	const int row = 3, col = 4;

	int arr[row][col] = {
		{3, 2, 1, 7},
		{4, 5, 6, 7},
		{9, 8, 7, 7}
	};
	int minR[row], minC[col];

	for (int i = 0; i < row; i++) {
		minR[i] = arr[i][0];
		for (int o = 0; o < col; o++) {

			if (minR[i] > arr[i][o]) minR[i] = arr[i][o];

		}
	}
	for (int i = 0; i < row; i++) {
		for (int o = 0; o < col; o++) {
			arr[i][o] -= minR[i];
		}
	}
	for (int i = 0; i < row; i++) {
		for (int o = 0; o < col; o++) {
			cout.width(3);
			cout << arr[i][o];
		}
		cout << endl;
	}
	cout << endl;

	// ------------
	
	for (int i = 0; i < col; i++) {
		minC[i] = arr[0][i];
		for (int o = 0; o < row; o++) {

			if (minC[i] > arr[o][i]) minC[i] = arr[o][i];

		}
	}
	for (int i = 0; i < col; i++) {
		for (int o = 0; o < row; o++) {
			arr[o][i] -= minC[i];
		}
	}

	for (int i = 0; i < row; i++) {
		for (int o = 0; o < col; o++) {
			cout.width(3);
			cout << arr[i][o];
		}
		cout << endl;
	}
}

