// lesson 29_2.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include <iostream>
using namespace std;

template <typename T> 
class MyQueuePr;

template <typename T>
class Node {
public:
    friend class MyQueuePr<T>;
    Node(T v, int pr) : value(v), prior(pr), next(nullptr) {}
    Node() {}
private:
    T value = T();
    int prior = 0;
    Node<T>* next = nullptr;
};

template<typename T>
class MyQueuePr {
public:
    MyQueuePr() :head(nullptr), end(nullptr), size(24){}
    bool IsEmpty() const {
        return (head == nullptr) ? true : false;
    }
    int getCount();

    bool isFull()const {
        return (getCount() == size) ? true : false;
    }
    
    int getSize() const {
        return size;
    }

    T& peek() {
        if (IsEmpty() != true) {
            return head->value;
        }
        return T();
    }

    void InsertWithPriority(T value, int pr);

    void PullHighestPriorityElement() {
        if (IsEmpty() != true) {
            if (head == end) {
                delete head;
                head = end = nullptr;
            }
            else {
                Node<T>* temp = head;
                head = head->next;
                delete temp;
            }
        }
    }
private:
    Node<T>* head;
    Node<T>* end;
    int size;
};

template<typename T>
void MyQueuePr<T>::InsertWithPriority(T value, int pr) {
    Node<T>* temp = new Node<T>(value, pr);
    if (IsEmpty()){
        head = end = temp;
        return;
    }
    if (head == end) {
        if (pr > head->pr) {
            temp->next = head;
            head = temp;
        }
        else {
            end->next = temp;
            end = temp;
        }
        return;
    }

    if (pr > head->pr) {
        temp->next = head;
        head = temp;
    }
    else {
        Node<T>* temp1 = head;
        while (temp1->next != nullptr && temp1->next->pr > pr) {
            temp1 = temp1->next;
        }
        if (temp1 == end) {
            end->next = temp;
            end = temp;
        }
        else {
            temp->next = temp1->next;
            temp1 - next = temp;
        }
    }
}


template <typename T>
int MyQueuePr<T>::getCount() {
    if (head == nullptr) return 0;
    if (head == end) return 1;
    int count = 1;
    Node<T>* temp = head;
    while (temp!=end) {
        ++count;
        temp = temp->next;

    }
    return count;
}

int main()
{
    std::cout << "Hello World!\n";
}

// Запуск программы: CTRL+F5 или меню "Отладка" > "Запуск без отладки"
// Отладка программы: F5 или меню "Отладка" > "Запустить отладку"

// Советы по началу работы 
//   1. В окне обозревателя решений можно добавлять файлы и управлять ими.
//   2. В окне Team Explorer можно подключиться к системе управления версиями.
//   3. В окне "Выходные данные" можно просматривать выходные данные сборки и другие сообщения.
//   4. В окне "Список ошибок" можно просматривать ошибки.
//   5. Последовательно выберите пункты меню "Проект" > "Добавить новый элемент", чтобы создать файлы кода, или "Проект" > "Добавить существующий элемент", чтобы добавить в проект существующие файлы кода.
//   6. Чтобы снова открыть этот проект позже, выберите пункты меню "Файл" > "Открыть" > "Проект" и выберите SLN-файл.
