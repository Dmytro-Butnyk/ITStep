#include <iostream>
using namespace std;

int main()
{

	// task 1 

	// 5

	/*
	int size = 5;
	int x1 = size, y1 = 0;
	for (int i = 0; i < size; i++) {
		if (i <= size / 2) {
			for (int o = 0; o < y1; o++) {
				cout << "  ";
			}
			for (int o = 0; o < x1; o++) {
				cout << "* ";
			}
			x1 -= 2;
			y1++;
			cout << endl;
		}
		if (i >= size / 2) {
			x1 += 2;
			y1--;
			for (int o = 0; o < y1; o++) {
				cout << "  ";
			}
			for (int o = 0; o < x1; o++) {
				cout << "* ";
			}
			cout << endl;
		}
	}

	// 6

	int x2 = 1, y2 = size - 2; 

	for (int i = 0; i < size; i++) {
		if (i < size / 2) {
			for (int o = 0; o < x2; o++) {
				cout << "* ";
			}
			for (int o = 0; o < y2; o++) {
				cout << "  ";
			}
			for (int o = 0; o < x2; o++) {
				cout << "* ";
			}
			cout << endl;
			x2 ++;
			y2 -= 2;
		}
		if (i == size / 2) {
			for (int o = 0; o < size; o++) {
				cout << "* ";
			}
			cout << endl;
		}
		if (i > size / 2) {
			x2 --;
			y2 += 2;
			for (int o = 0; o < x2; o++) {
				cout << "* ";
			}
			for (int o = 0; o < y2; o++) {
				cout << "  ";
			}
			for (int o = 0; o < x2; o++) {
				cout << "* ";
			}
			cout << endl;
		}
	}

	// 7

	int x3 = 1, y3 = size - 2;

	for (int i = 0; i < size; i++) {
		if (i < size / 2) {
			for (int o = 0; o < x3; o++) {
				cout << "* ";
			}
			for (int o = 0; o < y3; o++) {
				cout << "  ";
			}
			
			cout << endl;
			x3++;
			y3 -= 2;
		}
		if (i == size / 2) {
			for (int o = 0; o < size / 2 + 1; o++) {
				cout << "* ";
			}
			cout << endl;
		}
		if (i > size / 2) {
			x3--;
			y3 += 2;
			for (int o = 0; o < x3; o++) {
				cout << "* ";
			}
			for (int o = 0; o < y3; o++) {
				cout << "  ";
			}
			cout << endl;
		}
	}

	// 8

	int x4 = 1, y4 = size - 1;

	for (int i = 0; i < size; i++) {
		if (i < size / 2) {
			
			for (int o = 0; o < y4; o++) {
				cout << "  ";
			}
		
		for (int o = 0; o < x4; o++) {
			cout << "* ";
		}
			cout << endl;
			x4++;
			y4 --;
		}
		if (i == size / 2) {
			for (int o = 0; o < size / 2; o++) {
				cout << "  ";
			}
			for (int o = 0; o < size / 2 + 1; o++) {
				cout << "* ";
			}
			cout << endl;
		}
		if (i > size / 2) {
			x4--;
			y4 ++;
			
			for (int o = 0; o < y4; o++) {
				cout << "  ";
			}
			for (int o = 0; o < x4; o++) {
				cout << "* ";
			}
			cout << endl;
		}
	}

	//9

	int x5 = size;
	
	for (int i = 0; i < size; i++) {
		for (int o = 0; o < x5; o++) {
			cout << "* ";
		}
		cout << endl;
		x5--;
	}
	*/

	// task 2

	/*int number, digits_count = 0, digits_suma = 0, zero_count = 0;
	double digits_ave = 0;

	cout << "Enter number: ";
	cin >> number;

	int temp = number;

	while (temp != 0) {
		int digit = temp % 10;
		digits_count++;
		digits_suma += digit;
		if (digit == 0) zero_count++;
		temp /= 10;
	}
	if (digits_count > 0) digits_ave = double(digits_suma) / digits_count;

	cout << "Count of digits: " << digits_count << endl;
	cout << "Suma of digits: " << digits_suma << endl;
	cout << "Average of digits: " << digits_ave << endl;
	cout << "Zero count: " << zero_count << endl;*/

	// task 3

	/*int count = 0;

	for (int i = 100; i <= 999; i++) {
		int digit_1 = i / 100;
		int digit_2 = (i / 10) % 10;
		int digit_3 = i % 10;

		if (digit_1 != digit_2 && digit_2 != digit_3 && digit_3 != digit_1) count++;
	}

	cout << "Count of numbers with different digits: " << count << endl;*/

	// task 4

	/*int number;
	cout << "Enter number: ";
	cin >> number;

	for (int i = 1; i <= number; i++) {
		double divider = double(number) / i;
		if (divider - int(divider) == 0) cout << divider << "  ";
	}
	cout << endl;*/

	// task 5 (dod)
	
	srand(time(NULL));
	int user_score = 0, pc_score = 0, lvl_multiple, choise = 1;
	int up_bound, low_bound;
	double hp;
	int lvl = 1, attempt;

	cout << "GUESS MY NUMBER\n" << endl;
A:
	cout << "Do you want to start game? (1 - YES, 0 - NO)" << endl;
	cin >> choise;
	switch (choise) {
	case 0:
		cout << "Exiting game..." << endl;
		system("pause");
		return 0;
	case 1:
		cout << "The game is started :)" << endl;
		break;
	default:
		cerr << "Wrong choise!!!";
		system("pause");
		return 1;
	}

	do {
		if (user_score > 0) {
			cout << "Enter level of difficulty (1 - easy, 2 - hard): ";
			cin >> lvl;
		}

		if (lvl == 1) {
			up_bound = 10;
			low_bound = 1;
			hp = 0.5;
			lvl_multiple = 5;
		}
		else if (lvl == 2) {
			up_bound = 100;
			low_bound = 10;
			hp = 0.25;
			lvl_multiple = 10;
		}
		else lvl = 1;

		cout << "Level " << lvl << endl;
		int number = rand() % (up_bound - low_bound + 1) + low_bound;
		cout << "You need to guess the number that computer was make.\n";

		for (int health = up_bound * hp; health >= 0; health--) {
			if (health > 0) {
				cout << "Your health: " << health << '/' << up_bound * hp << endl;
			}
			else {
				cout << "You lose! Try again." << endl;
				pc_score += (up_bound * hp) * lvl_multiple;
				cout << "Player score: " << user_score << "\nComputer score: " << pc_score << endl;
				system("pause");
				system("cls");
				goto A;
			}
			cout << "Guess: ";
			cin >> attempt;

			if (attempt != number) {
				cout << "Wrong answer :(" << endl;
				int hint;
				cout << "Do you want to get a hint (costs 1 hp) (1 - yea, any key - no): ";
				cin >> hint;
				if (hint == 1) {
					health--;
					if (attempt > number) cout << "Your attempt is more than number!" << endl;
					else cout << "Your attempt is less than number!" << endl;
				}
			}
			else {
				cout << "YOU GUESSED THE NUMBER!!!" << endl;
				user_score += health * lvl_multiple;
				cout << "Player score: " << user_score << "\nComputer score: " << pc_score << endl;
				system("pause");
				cout << "Do you want to continue or exit? (1 - C, 0 - E): ";
				cin >> choise;
				system("cls");
				break;
			}
			

		}
	} while (choise == 1);


	system("pause");
	return 0;
}