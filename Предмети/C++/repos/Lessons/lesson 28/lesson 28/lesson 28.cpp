#include <iostream>
using namespace std;

template <typename T>
class Array {
private: 
	unsigned size;
	T* arr{nullptr};
	int l_index  = 0;
public:
	void SetSize(int size, int grow = 1) {
		if (arr != nullptr) {
			T* copy_arr = new T[this->size];
			for (int i = 0; i < this->size; ++i) {
				copy_arr[i] = arr[i];
			}
			delete[] arr;
		}

		if (size >= this->size) {

			arr = new T[size+grow];
			int i = 0;
			for (i; i < this->size; ++i) {
				arr[i] = copy_arr[i];
			}
			l_index = i - 1;
			for (i; i < size+grow; ++i) {
				arr[i] = T();
			}
			this->size = size + grow;
		}
		else {
			arr = new T[size];
			for (int i = 0; i < size; ++i) {
				arr[i] = copy_arr[i];
			}
			l_index = size - 1;
			this->size = size;
		}
		
			delete[] copy_arr;
	}

	Array() {
		size = 10;
		arr = new T[size]{ T() };
	}
	Array(const T*& array, int size) :size(size) {
		arr = array;
		l_index = size - 1;
		arr = nullptr;
	}
	Array (const Array& copy) {
		size = copy.size;
		arr = copy;
		l_index = copy.l_index;
	}

	Array& operator=(const Array& copy) {
		if (arr != nullptr) delete[] arr;
		size = copy.size;
		arr = copy.arr;
		l_index = copy.l_index;
		return this*;
	}
	~Array() {
		delete[] arr;
	}

	inline int GetSize() const {
		return size;
	}
	int GetUpperBound() {
		return l_index;
	}
	bool IsEmpty() {
		return arr == nullptr;
	}
	void FreeExtra() {
		SetSize(l_index + 1);
	}
	void RemoveAll() {
		delete[] arr;
		l_index = 0;
		arr = nullptr;
		size = 0;
	}
	T GetAt(int index) {
		return arr[index];
	}
	void SetAt(int index, T value) {
		assert(index >= 0 and index < size and "Wrong element position!");

		if (index > l_index) l_index = index;
		arr[index] = value;
	}
	T& operator[](int index) {
		assert(index >= 0 and index < size and "Wrong element position!");

		if (index > l_index) l_index = index;
		return arr[index];
	}
	T operator[](int index) {
		assert(index >= 0 and index < size and "Wrong element position!");
		return arr[index];
	}

	void Add(T value) {
		l_index++;

		if (l_index == size) SetSize(size);

		arr[l_index] = value;
	}

	void Append(const T* array, int size) {
		T* new_arr = new T[this->size];
		for (int i = 0; i < this->size; ++i) {
			new_arr[i] = arr[i];
		}
		delete[] arr;
		delete[] arr;
		arr = new T[this->size + size];
		int i = 0;
		for (int i = 0; i < this->size; ++i) {
			arr[i] = new_arr[i];
		}
		for (int o = 0; i < size + this->size; ++i, ++o) {
			arr[o] = array[o];
		}

		delete[] new_arr;
	}
	const T* GetData() {
		assert(arr != nullptr && "Arr is nullptr!");
		return arr;
	}
};

int main()
{



}