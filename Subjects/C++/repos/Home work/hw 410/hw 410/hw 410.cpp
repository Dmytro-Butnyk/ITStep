#include <iostream>
#define N 10
using namespace std;

void CopyArray(int* arr1, int* arr2, int size){

	for (int i = 0; i < size; ++i) {
		arr1 = arr2;
		arr1++;
		arr2++;
	}
	arr1 -= size;
	arr2 -= size;
}

void FillArr(int* arr, int size) {

	for (int i = 0; i < size; ++i) {
		arr[i] = rand() % 20 + 1;
	}
}

void ShowArr(int* arr, int size) {
	for (int i = 0; i < size; ++i) {
		cout.width(3);
		cout << arr[i];
	}
	cout << endl;
}

void ReversedArr(int*& arr, int size) {
	int* narr = new int[size];
	for (int i = size - 1, o = 0; i >= 0; --i, ++o) {
		narr[o] = arr[i];
	}

	delete[] arr;
	arr = narr;
}

int main()
{
	srand(time(NULL));

	// task 1
	/*int arr_s[N];
	int arr_e[N];
	FillArr(arr_s, N);

	ShowArr(arr_s, N);
	int* arr1 = arr_s;
	int* arr2 = arr_e;

	for (int i = 0; i < N; ++i) {
		*arr1 = *arr2;
		++arr1;
		++arr2;
	}
	ShowArr(arr_e, N);
	delete [] arr1, arr2;
	*/

	// task 2

	/*int size = 2;
	cout << "Enter size of array: ";
	cin >> size;

	if (size <= 1) {
		cerr << "Wrong size!" << endl;
		system("pause");
		return 1;
	}

	int* arr = new int[size];

	FillArr(arr, size);
	cout << "Original array: " << endl;
	ShowArr(arr, size);
	ReversedArr(arr, size);
	cout << "Reverced array: " << endl;
	ShowArr(arr, size);
	delete [] arr;
	*/

	// task 3

	int m, n;
	cout << "Enter sizes of arrays A and B: ";
	cin >> m >> n;

	int* A = new int[m], *B = new int[n];
	FillArr(A, m);
	FillArr(B, n);



	int count = 0; 
	int* C = new int[count];

	for (int i = 0; i < m; i++) {
		for (int j = 0; j < N; j++) {
			if (A[i] == B[j]) {
				bool isDuplicate = false;
				for (int k = 0; k < count; k++) {
					if (A[i] == C[k]) {
						isDuplicate = true;
						break;
					}
				}

				if (!isDuplicate) {
					C[count] = A[i];
					count++;
				}
			}
		}
	}
	cout << "Array A:" << endl;
	ShowArr(A, m);
	cout << "Array B:" << endl;
	ShowArr(B, n);
	cout << "Array C:" << endl;
	ShowArr(C, count);


	system("pause");
	return 0;
}