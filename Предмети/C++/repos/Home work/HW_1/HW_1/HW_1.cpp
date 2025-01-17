#include <iostream>
using namespace std;


int main()
{
	// task 1

	/*int sec;
	cout << "Enter seconds: ";
	cin >> sec;

	int hours, minutes;

	hours = sec / 3600;
	minutes = (sec % 3600) / 60;
	sec = sec % 60;

	cout << "Hours: " << hours << ", minutes: " << minutes << ", seconds: " << sec;*/

	// task 2

	/*double n;
	cout << "Enter number: ";
	cin >> n;

	int hrn = int(n), cop = int(n * 100) % 100;

	cout << "Hrn: " << hrn << ", cop: " << cop << endl;*/

	//  task 3

	/*double dist, time, min, sec, speed;
	cout << "Enter distance (meters): ";
	cin >> dist;
	cout << "Enter time (m.sec.): ";
	cin >> time;
	min = int(time);
	sec = (time - int(time)) * 100;
	speed = (dist / (min * 60 + sec)) * 3.6;
	cout << "Time: " << min << " minutes, " << sec << " seconds." << endl;
	cout << "Distance: " << dist << " meters." << endl;
	cout << "Your speed: " << speed << " (km/h)" << endl;*/

	// task 4

	int days, d, week;

	cout << "Enter count of days: ";
	cin >> days;
	week = days / 7;
	d = days % 7;
	cout << "Weeks: " << week << ", days: " << d << endl;

	system("pause");
	return 0;
}

