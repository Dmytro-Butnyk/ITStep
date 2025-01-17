#include <iostream>
using namespace std;

int main()
{

	/*double value;
	cout << "Enter value: ";
	cin >> value;
	int grn = (int)value;
	int cop = int(value * 100) % 100;
	cout << grn << "hrn, " << cop << " cop." << endl;*/

	/*
	&&	||	!
	<	>	<=	>=	
	==	!=	( only int, char )
	(умова)?exprTrue: exprFalse
	*/
	/*(grn > cop) ? grn *= 2 : cop /= 2;
	cout << "***\n" << grn << "hrn, " << cop << " cop." << endl;

	int v = (grn > cop ? grn : cop) * 10;
	cout << "***\n" << v << " - is v.";*/

	/*
	switch(x):
	case 1: ...; break;
	case 2: ...; break;
	case 3: ...; break;
	...
	default: ...;
	*/


	// task 1

	/*int x;
	cout << "Enter n: ";
	cin >> x;

	if (x % 2 == 0) {
		cout << "Is an even number." << endl;
	}
	else
	{
		cout << " Is an odd number." << endl;
	}*/

	// task 2

	/*int x;
	cout << "Enter n: ";
	cin >> x;

	(x % 2 == 0) ? x *= 3 : x /= 2;
	cout << x;*/

	// task 3

	//int x, y, z, min;
	//cout << "Enter x, y, z: ";
	//cin >> x >> y >> z;
	//min = x;
	//(y < min) ? min = y : min;
	//(z < min) ? min = y : min;
	//cout << min;

	// task 4

	/*int x;
	cout << "Enter number: ";
	cin >> x;
	if (x < 0) {
		cout << "Negative number.";
	}else if (x > 0) {
		cout << "Positive number.";
	}
	else {
		cout << "Zero";
	}*/

	// task 5

	/*int x;
	cout << "Enter 5 digits number: ";
	cin >> x;

	if ((x / 10000) >= 1) {
		int f_n = x / 10000;
		int s_n = (x / 1000) % 10;
		int t_n = (x / 100) % 10;
		int for_n = (x / 10) % 10;
		int fiv_n = x % 10;
		int n = (fiv_n * 10000)+(t_n * 1000)+(s_n * 100)+(for_n * 10)+f_n;
		cout << n;
	}
	else {
		cout << "You entered wrong number.";
		return 0;
	}*/

	// task 6

	/*int x;
	cout << "Enter 5 digits number: ";
	cin >> x;

	if ((x / 100000) >= 1) {
		int n1 = x / 100000;
		int n2 = (x / 10000) % 10;
		int n3 = (x / 1000) % 10;
		int n4 = (x / 100) % 10;
		int n5 = (x / 10) % 10;
		int n6 = x % 10;

		if (n1 + n2 + n3 == n4 + n5 + n6) {
			cout << "It is the lucky number!!!" << endl;
		}
		else {
			cout << "It is the unlucky number!!!" << endl;
		}
	}
	else {
		cout << "Wrong number!";
		return 0;
	}*/

	// task 8

	/*int x;
	cout << "Enter number of finger: ";
	cin >> x;

	if (x < 5 && x > 0) {
		switch (x) {
		case 1:
			cout << "It is \"pollex\" finger." << endl;
			break;
		case 2:
			cout << "It is \"index\" finger." << endl;
			break;
		case 3:
			cout << "It is \"medius\" finger." << endl;
			break;
		case 4:
			cout << "It is \"annularis\" finger." << endl;
			break;
		case 5:
			cout << "It is \"digitus\" finger." << endl;
			break;
		default:
			return 0;
		}
	}
	else {
		cout << "Wrong finger!";
		return 0;
	}*/

	// task 9
	
	int a, b, c, x, y;
	cout << "Enter len, width, height and len, width: ";
	cin >> a >> b >> c >> x >> y;

	if (b < x && a < y or a < x && c < x or c < x && b < y or b < y && a < x or a < y && c < x or c < y && b < x ) {
		cout << "Yes, it can.";
	}
	else {
		cout << "No, it can't.";
	}


	system("pause");
	return 0;
}

