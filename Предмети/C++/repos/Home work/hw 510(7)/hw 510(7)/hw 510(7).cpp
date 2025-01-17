#include <iostream>
#include <string>
#define N 4
using namespace std;



template<typename T>
void ShowArray(T arr, int size) {
	for (int i = 0; i < size; ++i) {
		for (int o = 0; o < size; ++o) {
			cout.width(4);
			cout << arr[i][o];
		}
		cout << endl;
	}
}

template<typename T>
void FillArray(T arr, int size) {
	for (int i = 0; i < size; ++i) {
		for (int o = 0; o < size; ++o) {
			arr[i][o] = rand() % (50 + 50 + 1) - 50;
		}
	}
}

template<typename T>
void ArrTool(T arr, int size) {
	int min, max;
	min = max = arr[0][0];

	for (int i = 0; i < size; ++i) {
		if (min > arr[i][i]) min = arr[i][i];
		if (max > arr[i][i]) max = arr[i][i];
	}
	cout << "Min on main diagonale: " << min << ";\n" <<
		"Max on main diagonale: " << max << ".\n" << endl;
}
template<typename T>
void ArrTool (T arr, int size, int row)
{
	for (int i = 0; i < size; ++i) {
		for (int j = i + 1; j < size; ++j) {
			if (arr[row][i] > arr[row][j]) swap(arr[row][i], arr[row][j]);
		}
	}
}

int main()
{
	srand(time(NULL));
	
	int choice;
	cout << "Enter 1 to start game: ";
	cin >> choice;

	while (choice == 1) {
		int number = rand() % 9999 + 1000, tries = 0;
		string n = to_string(number);
		const char* nch = n.c_str();
		char pTry[N];
		cout << n << endl;

		cout << "Enter 4 digital number: ";
		cin.getline(pTry, N);
		cin.ignore();

		while(pTry != nch){
			int bulls = 0, cows = 0;
			for (int i = 0; i < N; ++i) {
				for (int o = 0; o < N; ++o) {
					if (nch[i] == pTry[o]) ++bulls;
					break;
				}
			}
			cout << "Bulls: " << bulls << endl;

			for (int i = 0; i < N; ++i){
				if (nch[i] == pTry[i]) ++cows;
			}
			cout << "Cows: " << cows << endl;
			cout << "Next try: " << endl;
			++tries;
			cin.getline(pTry, N);
			cin.ignore();
		}
		cout << "You win! Number of tries: " << tries << endl;
		cout << "\nEnter 1 to start or else to stop: ";
		cin >> choice;
	}

	system("pause");
	return 0;
}