#include <iostream>
using namespace std; 



template <typename T>
class Node {
public:

    friend class MyTree<T>;
    Node(){}
    Node(T val):value(val), pLeft(nullptr), pRight(nullptr){}

    friend ostream& operator<<(ostream& s, Node<T> node) {
        s << value << " ";
        return s;
    }
private:
    T value = T();
    Node<T>* pLeft;
    Node<T>* pRight;
};

template <typename T>
class MyTree {
public:

    MyTree() {top = nullptr}
    MyTree(T valltop) {
        top = new Node<T>(valltop);
    }
private:
    Node<T>* top;
};


int main()
{
    std::cout << "Hello World!\n";
}