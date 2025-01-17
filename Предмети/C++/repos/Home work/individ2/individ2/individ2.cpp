#include <iostream>
#include <algorithm>
#include <map>
#include <vector>
#include <random>
#include <fstream>
#include <sstream>
#include <nlohmann/json.hpp>
using json = nlohmann::json;
using namespace std;

typedef map<string, vector<double>> transactions;
// CARD
class Card {
private:
	string type{ "Debit" };
	transactions trns;
	double balance{ 0 };
public:
	Card(string type, transactions trns, double balance):
	 type(type), trns(trns), balance(balance){}
	Card() {
		trns.insert({ "Days", {} });
		trns.insert({ "Weeks", {} });
		trns.insert({ "Months", {} });
	}
	Card(string type): type(type) {
		trns.insert({ "Days", {} });
		trns.insert({ "Weeks", {} });
		trns.insert({ "Months", {} });
	}
	Card(const Card& other)
		: type(other.type), trns(other.trns), balance(other.balance) {}
	Card& operator=(const Card& other) {
		if (this != &other) {
			type = other.type;
			trns = other.trns;
			balance = other.balance;
		}
		return *this;
	}

	string GetType() const {
		return type;
	}
	transactions GetTransactions() const {
		return trns;
	}
	double GetBalance() const {
		return balance;
	}

	void ReplenishBalance() {
		double b;
		cout << "Enter value to replenish: ";
		cin >> b;
		balance += b;
		cout << "Balance replenished.";
	}
	void AddTransaction() {
		cout << "Adding transaction..." << endl << endl;		
			cout << "Enter sum of your expenses for today: ";
			PushExpenses("Days");
			auto itD = trns.find("Days");
			auto itW = trns.find("Weeks");
			auto itM = trns.find("Months");
			if (itD->second.size() == 7) {
				double sum = 0;
				for (int i = 0; i < 7; ++i) {
					sum += itD->second[i];
				}
				itW->second.push_back(sum);
				itD->second.clear();
			}
			if (itW->second.size() == 4) {
				double sum = 0;
				for (int i = 0; i < 4; ++i) {
					sum += itW->second[i];
				}
				itM->second.push_back(sum);
				itW->second.clear();
			}
			if (itM->second.size() == 12) {
				itM->second.clear();
			}
			cout << "Statistic updated." << endl;
	}
	void PushExpenses(string key) {
		double count;
		cin >> count;
		while (count < 0 || count > balance) {
			if (count < 0) {
				cout << "Wrong value!!!";
			}
			else if (type == "Credit") {
				break;
			}
			else {
				cout << "Not enough balance!!!";
				return;
			}
			cin >> count;
		}
		balance -= count;
		auto it = trns.find(key);
		it->second.push_back(count);
		cout << "Expenses added!";
	}

	friend ostream& operator<<(ostream& s, const Card& c) {
		s << "Card type: " << c.type
			<< "\nBalance: " << c.balance << "\n";
		s << "Transactions:\n";
		for (auto it = c.trns.begin(); it != c.trns.end(); ++it) {
			s << it->first;
			for (int i = 0; i < it->second.size(); ++i) {
				s << " " << it->second[i];
			}
			s << "\n";
		}
		s << "* * * * * * * * * * * * * *" << endl;

		return s;
	}
	friend ofstream& operator<<(ofstream& s, const Card& c) {
		 s << c.type;
		for (auto it = c.trns.begin(); it != c.trns.end(); ++it) {
			s << '\n' << it->first;
			for (int i = 0; i < it->second.size(); ++i) {
				s << " " << it->second[i];
			}
		}
		s << "\n" << c.balance;
		return s;
	}

	json to_json() const {
		return {
			{"type", type},
			{"transactions", trns},
			{"balance", balance} };
	}

	static Card from_json(const json& j) {
		Card card;
		card.type = j.at("type").get<string>();
		card.trns = j.at("transactions").get<map<string, vector<double>>>();
		card.balance = j.at("balance").get<double>();
		return card;
	}
};
// USER
class User {
private:
	long long id{0LL};
	int pinCode{0};
	int numberCards{ 1 };
	vector<Card> cards;

	void GenerateId() {
		random_device rd;
		mt19937_64 generator(rd());
		uniform_int_distribution<long long> distribution(1000000000000000, 9999999999999999);

		id = distribution(generator);
	}
public:
	User() {
		GenerateId();
		Card wallet("Wallet");
		cards.push_back(wallet);
	}
	User(long long userId, int userPinCode, int userNumberCards, const vector<Card>& userCards)
		: id(userId), pinCode(userPinCode), numberCards(userNumberCards), cards(userCards) {}
	User(vector<Card> cards, long long id, int pinCode): cards(cards), id(id), pinCode(pinCode) {}
	User(long long id, int pinCode) :id(id), pinCode(pinCode) {}
	User(const User& other)
		: cards(other.cards), id(other.id),
		pinCode(other.pinCode), numberCards(other.numberCards) {}
	User& operator=(const User& other) {
		if (this != &other) {
			id = other.id;
			pinCode = other.pinCode;
			numberCards = other.numberCards;
			cards = other.cards;
		}
		return *this;
	}
	inline void SetPinCode(int PinCode) {
		pinCode = PinCode;
	}

	long long GetId() const {
		return id;
	}
	int GetPinCode() const {
		return pinCode;
	}
	int GetNumberCards() const { return numberCards; }
	vector<Card> GetCards() const { return cards; }

	void ShowCards() {
		for (int i = 0; i < cards.size(); ++i) {
			cout << i+1 << ". " << cards[i];
		}
	}
	void AddCard() {
		string type;
		int ch = -1;
		A:
		cout << "1 - Debit | 2 - Credit | 3 - Wallet" << endl;
		cin >> ch;
		cin.ignore();
		switch (ch) {
		case 1:
			type = "Debit";
			break;
		case 2:
			type = "Credit";
			break;
		case 3:
			type = "Wallet";
			break;
		default:
			cerr << "Wrong choice!";
			goto A;
		}
		Card new_card(type);
		cards.push_back(new_card);
		numberCards++;
		cout << "Successfully added!" << endl;
	}
	void DeleteCard() {
		if (numberCards == 1) {
			cerr << "You have only one card! Can`t delete so." << endl;
			return;
		}
		cout << "Choose the card that you need to delete:\n";
		ShowCards();
		int ch;
		cin >> ch;
		if (ch > cards.size()+1 || ch < 1) {
			cerr << "Wrong choice!";
			return;
		}
		cards.erase(cards.begin() + (ch - 1));
		numberCards--;
		cout << "Successfully deleted" << endl;
	}
	void UpdateTransaction() {
		ShowCards();
		int ch = 0;
		cout << "Enter number of card transaction was from: ";
		cin >> ch;
		if (ch > cards.size() + 1 || ch < 1) {
			cerr << "Wrong choice!";
			return;
		}
		cards[ch - 1].AddTransaction();
	}
	void UpdateReplenish() {
		ShowCards();
		int ch = 0;
		cout << "Enter number of card replenish to: ";
		cin >> ch;
		if (ch > cards.size() + 1 || ch < 1) {
			cerr << "Wrong choice!";
			return;
		}
		cards[ch - 1].ReplenishBalance();
		cout << endl;
	}
	void ShowStatForBiggest() {
		ShowCards();
		int ch_c = 0, ch = -1;
		cout << "Enter number of card: ";
		cin >> ch_c;
		if (ch_c > cards.size() + 1 || ch_c < 1) {
			cerr << "Wrong choice!";
			return;
		}
		A:
		cout << "\nChoose category to show stat of biggest cost:\n";
		cout << "|  1 - Days  |  2 - Weeks  |   3 - Months   |\n";
		cin >> ch;
		cin.ignore();
		string type, t;
		switch (ch) {
		case 1:
			type = "Days";
			t = "day";
			break;
		case 2:
			type = "Weeks";
			t = "week";
			break;
		case 3:
			type = "Months";
			t = "month";
			break;
		default:
			cerr << "Wrong choice!";
			system("cls");
			goto A;
		}
			auto it = cards[ch_c - 1].GetTransactions()[type];
			if (it.empty()) {
				cout << endl << "No transactions." << endl;
				return;
			}
			double max = it[0];
			int index;
			for (int i = 0; i < it.size(); ++i) {
				if (max < it[i]) {
				max = it[i];
				index = i;
				}
			}
			system("cls");
			cout << "The biggest transaction was at: " << index + 1 << " " << t << "\n" <<
				"it counts: " << max << endl;
	}
	friend ostream& operator<<(ostream& s, const User& us) {
		s << "Id: " << us.id << ";\nPin code: " << us.pinCode <<
			";\nCards:\n";
		for (int i = 0; i < us.cards.size(); ++i) {
			s << us.cards[i];
		}
		s << endl;
		return s;
	}
	/*
	void serialize(ofstream& outFile) const {
		outFile.write(reinterpret_cast<const char*>(&id), sizeof(long long));
		outFile.write(reinterpret_cast<const char*>(&pinCode), sizeof(int));
		outFile.write(reinterpret_cast<const char*>(&numberCards), sizeof(int));

		for (const auto& card : cards) {
			card.serialize(outFile);
		}
	}
	void deserialize(ifstream& inFile) {
		inFile.read(reinterpret_cast<char*>(&id), sizeof(long long));
		inFile.read(reinterpret_cast<char*>(&pinCode), sizeof(int));
		inFile.read(reinterpret_cast<char*>(&numberCards), sizeof(int));

		cards.resize(numberCards);
		for (auto& card : cards) {
			card.deserialize(inFile);
		}
	}
	*/

	json to_json() const {
		json jsonCards;
		for (const auto& card : cards) {
			jsonCards.push_back(card.to_json());
		}

		return {
			{"id", id},
			{"pinCode", pinCode},
			{"numberCards", numberCards},
			{"cards", jsonCards} };
	}

	static User from_json(const json& j) {
		User user;
		user.id = j.at("id").get<long long>();
		user.pinCode = j.at("pinCode").get<int>();
		user.numberCards = j.at("numberCards").get<int>();

		const auto& jsonCards = j.at("cards");
		user.cards.clear();
		for (const auto& jsonCard : jsonCards) {
			user.cards.push_back(Card::from_json(jsonCard));
		}

		return user;
	}
	void updateFromUser(const User& newUser) {
		id = newUser.id;
		pinCode = newUser.pinCode;
		numberCards = newUser.numberCards;
		cards = newUser.cards;
	}
};



void writeUsersToFile(const string& filename, const vector<User>& users) {
	json jsonUsers;
	for (const auto& user : users) {
		jsonUsers.push_back(user.to_json());
	}

	ofstream file(filename, ios::trunc);
	if (file.is_open()) {
		file << jsonUsers.dump(2);
		file.close();
	}
	else {
		cout << "Unable to open file for writing." << endl;
	}
}

vector<User> readUsersFromFile(const string& filename) {
	ifstream inFile(filename);
	json jsonFromFile;
	inFile >> jsonFromFile;
	inFile.close();

	vector<User> usersFromFile;
	for (const auto& jsonUser : jsonFromFile) {
		usersFromFile.push_back(User::from_json(jsonUser));
	}

	return usersFromFile;
}

int main()
{ 
	string path{ "users.json" };
	vector<User> users = readUsersFromFile(path);
	/*User us;
	users.push_back(us);
	writeUsersToFile(path, users);*/
	
	int index;
	
	int ch1, ch2;
	ch1 = ch2 = -1;

	while (ch1 != 0) {
		cout << "1 - Log in to account;\n2 - Create new account\n0 - exit:\n\t";
		cin >> ch1;
		cin.ignore();

		switch (ch1)
		{
		case 1: {
			users = readUsersFromFile(path);
			long long id;
			int pin;
			cout << "Enter your id: ";
			cin >> id;
			cout << "Enter pin code: ";
			cin >> pin;
			cin.ignore();
			bool isFound = false;
			for (int i = 0; i < users.size(); ++i) {
				if (users[i].GetId() == id &&
					users[i].GetPinCode() == pin) {
					index = i;
					isFound = true;
					break;
				}
			}
			if (!isFound) {
				cerr << "Wrong id or pin code!" << endl;
				break;
			}
			ch1 = 0;
			break;
		}
		case 2: {
			User new_user;
			cout << "Set pin code for your account.\n" <<
				"It must be more than 5 digits: ";
			int code = 0;
			cin >> code;
			while (code < 10000) {
				cout << "Code must be more than 5 digits: ";
				cin >> code;
			}

			cin.ignore();
			new_user.SetPinCode(code);
			cout << "Your account: " << new_user;
			users.push_back(new_user);
			writeUsersToFile(path, users);
			break;
		}
		case 0: {
			ch2 = 0;
			writeUsersToFile(path, users);
			exit;
		}
		default:
			writeUsersToFile(path, users);
			exit;
		}
	}
	system("cls");
	
	while (ch2 != 0) {
		cout << "1 - Show cards;\n2 - Add card;\n3 - Delete card;\n" <<
			"4 - Add transaction for today;\n5 - Replenish balance;\n6 - Show biggest cost of period;\n0 - Exit:\n\t";
		cin >> ch2;
		cin.ignore();

		switch (ch2)
		{
		case 1: {
			system("cls");
			cout << "Your cards:" << endl;
			users[index].ShowCards();
			break;
		}
		case 2: {
			system("cls");
			cout << "Adding card...." << endl;
			users[index].AddCard();
			cout << endl;

			break;
		}
		case 3: {
			system("cls");
			cout << "Deleting card...." << endl;
			users[index].DeleteCard();
			cout << endl;
			break;
		}
		case 4: {
			system("cls");
			users[index].UpdateTransaction();
			cout << endl;
			break;
		}
		case 5: {
			system("cls");
			users[index].UpdateReplenish();
			cout << endl;
			break;
		}
		case 6: {
			system("cls");
			users[index].ShowStatForBiggest();
			cout << endl;
			break;
		}
		case 0: {
			writeUsersToFile(path, users);
			exit;
		}
		default:
			writeUsersToFile(path, users);
			exit;
		}
	}
	writeUsersToFile(path, users);

	cout << endl;
	system("pause");
}
