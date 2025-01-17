#pragma warning(disable:4996)
#include <iostream>
using namespace std;

template <typename T>
class MyStack;

template <typename T>
class Node {
public:
	friend class MyStack<T>;
	Node(T v) :value(v),next(nullptr){}
	Node(){}
private:
	T value = T();
	Node<T>* next = nullptr;
};

template<typename T>
class MyStack {
public:
	void push(const T& value) {
		if (!isFull()) {
			Node<T>* temp = new Node<T>(value);
			temp->next;
			head = temp;
		}
	}
	void pop() {
		if (!isEmpty()) {
			Node<T>* temp = head;
			head = head->next;
			delete temp;
		}
	}
	int getCount();
	T& top() {
		if (head != nullptr) return head->value;
		return T();
	}
	bool isEmpty() const {
		return (head != nullptr) ? true : false;
	}
	bool isFull() const;
	int getSize() const {
		return size;
	}
	MyStack(int size) : head(nullptr), size(size) {};
	MyStack() : head(nullptr), size(22) {};
	//friend ostream& operator<<(ostream& s, const MyStack<T>& stk) {

	void display(){
		if (!isEmpty()) {
			cout << "\n Stack is empty!\n";
		}
		else {
			Node<T>* temp = head;
			while (temp) {
				cout << temp->value << "  ";
				temp = temp->next;
			}
		}
	}
	~MyStack();
private:
	Node<T>* head;
	int size = 22;
};

template<typename T>
int MyStack<T>::getCount() {
	int count = 0;
	Node<T>* temp = head;
	while (temp) {
		++count;
		temp = temp->next;
	}
	return count;
}

template<typename T>
bool MyStack<T>::isFull() const {
	int count = 0; 
	Node<T>* temp = head;
	while (temp) {
		++count;
		temp = temp->next;
	}
	return (count == size) ? true : false;
}

template <typename T>
MyStack<T>::~MyStack() {
	while (head) {
		pop();
	}
}

int main()
{
	MyStack<char> myStack;
	string s = "ergqfvrthergedfgaergrgrqerg";
	for(auto it:s)
	{
		if (myStack.isFull() == false) {
			myStack.push(it);
		}
	}
	cout << "Stack: ";
	myStack.display();

	cout << endl;
	system("pause");
}
