#include <iostream>
using namespace std;

void Paid(int hours) {

	double paid = 0, taxes = 0, p_w_t = 0;

	if (hours < 0) {
		cerr << "Wrong count of hours!";
		system("pause");
		return;
	}
	else if (hours <= 40) {
		paid = hours * 100;
	}
	else if(hours > 40){
		paid = (40 * 100) + (hours - 40) * 50;
	}
	cout << "Paid without taxes: " << paid << " HRN." << endl;

	if (paid >= 3600) {
		taxes = (3600 * 0.15) + (paid - 3600) * 0.20 + ((3600 * 0.85) + (paid - 3600) * 0.80)* 0.05;
		p_w_t = paid - taxes;
	}
	else {
		p_w_t = paid * 0.95;
		taxes = paid * 0.05;
	}
	cout << "Suma of taxes: " << taxes << " HRN.\n" <<
		"Final paid: " << p_w_t << " HRN" << endl;

}

bool PerfNum(int n) {
	int sum = 0;
	for (int i = 1; i < n; i++) {
		if (n % i == 0) {
			sum += i;
		}
	}
	return sum == n;
}

int CountPerfNum(int start, int end) {
	int count = 0;
	for (int i = start; i <= end; ++i) {
		if (PerfNum(i)) {
			++count;
		}
	}
	return count;
}

void ShowCard(int value, int suit) {
	
	for (int i = 1; i <= 6; ++i) {
		for (int o = 1; o <= 4; ++o) {
			if (i == 1 || i == 6 || o == 1 || o == 4) cout << "* "; 
			else if (i == 2 && o == 2 || i == 5 && o == 3) {
				if (value <= 10) cout << value;
				else if (value == 11) cout << "J";
				else if (value == 12) cout << "Q";
				else if (value == 13) cout << "K";
				else cout << "A";
				if (suit == 1) cout << "♥";
				else if (suit == 2) cout << "♠";
				else if (suit == 3) cout << "♦";
				else cout << "♣";
			
			}
			else cout << "  ";
		}
		cout << endl;
	}
}

int fact(int n) {
	if (n == 0 || n == 1) {
		return 1;
	}
	else {
		return n * fact(n - 1);
	}
}

void CSDigits(int n) {
	int factorial = fact(n);
	int sum = 0;
	int digitCount = 0;

	while (factorial > 0) {
		int digit = factorial % 10;
		sum += digit;
		factorial /= 10;
		digitCount++;
	}
	cout << "Count of digits: " << digitCount << ", suma of that digits " << sum << endl;
}

int BTD(int binary) {
	int decimal = 0;
	int base = 1; 

	while (binary > 0) {
		int last = binary % 10; 
		decimal += last * base;
		binary /= 10; 
		base *= 2; 
	}

	return decimal;
}

int IndexMax(int* arr, int size) {

	int max = INT_MIN;
	for (int i = 0; i < size; ++i) {
		if (max < arr[i]) max = arr[i];
	}
	for (int i = 0; i < size; ++i) {
		if (max == arr[i]) return i;
	}
}

template <typename T>
void SwapColumns(T arr, int size, int col1, int col2) {
	for (int i = 0; i < size; ++i) {
		swap(arr[i][col1 - 1], arr[i][col2 - 1]);
	}
}

int main()
{
	srand(time(NULL));

	// task 1

	/*int hours = 0;
	cout << "Enter count of work hours: ";
	cin >> hours;
	Paid(hours);*/

	// task 2

	/*int start, end;
	cout << "Enter start of range: ";
	cin >> start;
	cout << "Enter end of range: ";
	cin >> end;

	if (end < start) swap(start, end);
	cout << "Count of perfect numbers in your range is: " << CountPerfNum(start, end) << endl;*/

	// task 3

	/*int value_c, suit;
	cout << "Enter card value (6 - 14): ";
	cin >> value_c;
	if (value_c < 6 || value_c > 14) {
		cerr << "Wrong value!!!";
		system("pause");
		return 1;
	}
	cout << "Enter card suit\n1 - Hearts;\n2 - Spades;\n3 - Diamonds;\n4 - Clubs :";
	cin >> suit;
	if (suit < 1 || suit > 4) {
		cerr << "Wrong suit!!!";
		system("pause");
		return 1;
	}
	ShowCard(value_c, suit);*/

	// task 4

	/*int n;
	cout << "Enter number: ";
	cin >> n;

	CSDigits(n);*/

	// task 5

	/*int n;
	cout << "Enter binary number: ";
	cin >> n;

	cout << "Decimal form your binary: " << BTD(n) << endl;*/

	// task 6

	/*const int el = 10;
	int arr[el];
	for (int i = 0; i < el; ++i) {
		arr[i] = rand() % 30 + 1;
		cout << arr[i] << "  ";
	}
	cout << endl;

	cout << "Max element`s index: " << IndexMax(arr, el) << endl;*/

	// task 7

	const int size = 5;
	int arr[size][size];
	for (int i = 0; i < size; ++i) {
		for (int o = 0; o < size; ++o) {
			arr[i][o] = rand() % 30 + 1;
			cout.width(3);
			cout << arr[i][o];
		}
		cout << endl;
	}

	int col_1, col_2;
	cout << "Enter number of col 1 that you want to swap: ";
	cin >> col_1;
	cout << "Enter number of second col: "; 
	cin >> col_2;
	SwapColumns(arr, size, col_1, col_2);
	cout << "*************" << endl;
	for (int i = 0; i < size; ++i) {
		for (int o = 0; o < size; ++o) {
			cout.width(3);
			cout << arr[i][o];
		}
		cout << endl;
	}


	system("pause");
	return 0;
}