#include <iostream>
using namespace std;

void AddCol(int** arr, int r, int& c, int pos) {
	int** newArr = new int* [r];
	for (int i = 0; i < r; ++i) {
		newArr[i] = new int[c+=1];
	}

	for (int i = 0; i < r; ++i) {
		for (int o1 = 0, o2 = 0; o1 < c-1; ++o1, ++o2) {
			if (o1 == pos) ++o1;
			newArr[i][o1] = arr[i][o2];
		}
			delete[] arr[i];
	}
	delete[] arr;
	arr = newArr;
}

void DelCol(int**& arr, int& r, int& c, int pos) {
    int** newArr = new int* [r];
    for (int i = 0; i < r; i++) {
        newArr[i] = new int[c - 1];
    }

    for (int i = 0; i < r; i++) {
        int destCol = 0;
        for (int j = 0; j < c; j++) {
            if (j != pos) {
                newArr[i][destCol] = arr[i][j];
                destCol++;
            }
        }
    }
    for (int i = 0; i < r; i++) {
        delete[] arr[i];
    }
    delete[] arr;
    arr = newArr;
    c--;
}

int* MinOfCol(int** arr, int r, int c) {
    int* minOfCol = new int[r];

    for (int i = 0; i < r; ++i) {
        int min = arr[r][0];
        for (int o = 0; o < c; ++o) {
            min = (arr[i][o] < min) ? arr[i][o] : min;
        }
        minOfCol[i] = min;
    }

    return minOfCol;
}

int main()
{


	cout << endl;
	system("pause");
}
