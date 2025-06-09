#include <iostream>
using namespace std;

int main()
{

	// task 1

	/*int mark, av_m = 0;

	cout << "Enter five marks (1 - 12): ";
	cin >> mark;
	av_m += mark;
	cin >> mark;
	av_m += mark;
	cin >> mark;
	av_m += mark;
	cin >> mark;
	av_m += mark;
	cin >> mark;
	av_m += mark;
	
	av_m /= 5;

	if (av_m >= 4) {
		cout << "You are welcome!";
	}
	else {
		cout << "You aren`t passed to an exam.";
	}*/

	// task 2

	/*int x, n;
	cout << "Enter 4 digits number: ";
	cin >> x;

	if ((x / 1000) >= 1 && (x / 1000) <= 9) {
		int f = x / 1000;
		int s = (x / 100) % 10;
		int t = (x / 10) % 10;
		int fou = x % 10;
		n = s * 1000 + f * 100 + fou * 10 + t;
		cout << n;
	}
	else {
		cerr << "You entered wrong number.";
		return 1;
	}*/

	// task 3

	/*int min, x;
	cout << "Enter 7 numbers: ";
	cin >> min;
	for (int i = 1; i < 6; i++) {
		cin >> x;
		if (min > x) min = x;
	}
	cout << "Minimal number is: " << min << endl;*/

	// task 4

	/*int cargo, distance_1, distance_2, cons, tank = 300, ref;

	cout << "Enter weight of cargo: ";
	cin >> cargo;
	cout << endl << "Enter distance from A to B: ";
	cin >> distance_1;
	cout << endl << "Enter distace from B to C: ";
	cin >> distance_2;

	if (cargo <= 500) cons = 1;
	else if (cargo > 500 && cargo <= 1000) cons = 4;
	else if (cargo > 1000 && cargo <= 1500) cons = 7;
	else if (cargo > 1500 && cargo <= 2000) cons = 9;
	else {
		cerr << "The plane can`t carry cargo more than 2000 kg.";
		system("pause");
		return 1;
	}
	cout << endl << "Cargo weight: " << cargo << " kg, fuel consumption: " << cons << " l/km.\nDistance from A to B: " << distance_1 << " km, from B to C: " << distance_2 << " km.\n" << endl;

	if (distance_1 * cons > tank) {
		cerr << "Fuel is not enough to fly to B" << endl;
		system("pause");
		return 0;
	} 
	else if (distance_1 * cons < tank) {
		ref = distance_2 * cons;
		if (ref > tank) {
			cerr << "Fuel is not enough to fly from B to C" << endl;
			system("pause");
			return 0;
		}
		else if (tank - distance_1 * cons >= distance_2 * cons) {
			cout << "You don`t need refueling." << endl;
		}
		else {
			cout << "You need to refuel " << ref << " l" << endl;
		}
	}*/

	// task 5

	int x, salary, late, count_c;
	double result;

	cout << "Enter:\n1 - count amount of code;\n2 - count delays;\n3 - count salary." << endl;
	cin >> x;

	switch (x)
	{
	case 1: 
		cout << "Enter desired salary: ";
		cin >> salary;
		cout << "Enter delays: ";
		cin >> late;

		result = salary * 2 + int(late / 3) * 20 * 2;
		cout << "You need to write " << result << " lines of code" << endl;
		break;
	case 2:
		cout << "Enter count of code lines: ";
		cin >> count_c;
		cout << "Enter desired salary: ";
		cin >> salary;

		result = int(salary - count_c * 0.5) / 20;
		if (result < 0) result *= -1;
		cout << "You may be late " << result * 3 + 2 << " times." << endl;
		break;
	case 3:
		cout << "Enter count of code lines: ";
		cin >> count_c;
		cout << "Enter count of delays: ";
		cin >> late;

		result = (count_c * 0.5) - (late / 3) * 20;
		cout << "Your salary is: " << result << endl;

		break;
	default:
		cerr << "Wrong choise!!!";
		system("pause");
		return 1;
	}


	system("pause");
	return 0;
}

