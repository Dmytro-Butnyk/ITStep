#include <iostream>
using namespace std;

int Max(int* arr, int size) {
    int max_val = arr[0];
    for (int i = 1; i < size; i++) {
        if (arr[i] > max_val) {
            max_val = arr[i];
        }
    }
    return max_val;
}

int Min(int* arr, int size) {
    int min_val = arr[0];
    for (int i = 1; i < size; i++) {
        if (arr[i] < min_val) {
            min_val = arr[i];
        }
    }
    return min_val;
}

double Avg(int* arr, int size) {
    double sum = 0.0;
    for (int i = 0; i < size; i++) {
        sum += arr[i];
    }
    return sum / size;
}

template <typename T>
void Action(int* arrA, int sizeA, int* arrB, int sizeB, T (*func)(int*, int)) {
    T resultA = func(arrA, sizeA);
    T resultB = func(arrB, sizeB);

    cout << "Result for A: " << resultA << endl;
    cout << "Result for B: " << resultB << endl;
}

int main() {
    int arrayA[] = { 5, 12, 8, 15, 10 };
    int arrayB[] = { 7, 2, 9, 4, 6 };
    int sizeA = sizeof(arrayA) / sizeof(arrayA[0]);
    int sizeB = sizeof(arrayB) / sizeof(arrayB[0]);

    int choice;
    cout << "Choose the operation:" << endl;
    cout << "1. Max" << endl;
    cout << "2. Min" << endl;
    cout << "3. Average" << endl;
    cin >> choice;

    if (choice == 1) {
        Action(arrayA, sizeA, arrayB, sizeB, Max);
    }
    else if (choice == 2) {
        Action(arrayA, sizeA, arrayB, sizeB, Min);
    }
    else if (choice == 3) {
        Action(arrayA, sizeA, arrayB, sizeB, Avg);
    }
    else {
        cout << "Wrong operation!" << endl;
    }

    cout << endl;
    system("pause");
}
