#include <iostream>
using namespace std; 

template <typename T>
class Matrix {
private:
    int size_x{ 2 };
    int size_y{ 2 };
    T** matrix;

public:
    Matrix() {
        matrix = new T * [size_x];
        for (int i = 0; i < size_x; ++i) {
            matrix[i] = new T[size_y]{ 0 };
        }
    }

    Matrix(int size_x, int size_y, T**& matrix) : size_x(size_x), size_y(size_y) {
        this->matrix = matrix;
    }

    Matrix(const Matrix& m) {
        size_x = m.size_x;
        size_y = m.size_y;
        matrix = new T * [size_x];
        for (int i = 0; i < size_x; ++i) {
            matrix[i] = new T[size_y];
            std::copy(m.matrix[i], m.matrix[i] + size_y, matrix[i]);
        }
    }

    Matrix& operator=(const Matrix& m) {
        if (this != &m) {
            DeleteM();
            size_x = m.size_x;
            size_y = m.size_y;
            matrix = new T * [size_x];
            for (int i = 0; i < size_x; ++i) {
                matrix[i] = new T[size_y];
                std::copy(m.matrix[i], m.matrix[i] + size_y, matrix[i]);
            }
        }
        return *this;
    }

    ~Matrix() {
        DeleteM();
    }

    friend Matrix operator+(const Matrix& a, int b) {
        Matrix c(a);
        for (int i = 0; i < c.size_x; ++i) {
            for (int o = 0; o < c.size_y; ++o) {
                c.matrix[i][o] += b;
            }
        }
        return c;
    }

    friend Matrix operator-(const Matrix& a, int b) {
        Matrix c(a);
        for (int i = 0; i < c.size_x; ++i) {
            for (int o = 0; o < c.size_y; ++o) {
                c.matrix[i][o] -= b;
            }
        }
        return c;
    }

    friend Matrix operator*(const Matrix& a, int b) {
        Matrix c(a);
        for (int i = 0; i < c.size_x; ++i) {
            for (int o = 0; o < c.size_y; ++o) {
                c.matrix[i][o] *= b;
            }
        }
        return c;
    }

    friend Matrix operator/(const Matrix& a, int b) {
        Matrix c(a);
        for (int i = 0; i < c.size_x; ++i) {
            for (int o = 0; o < c.size_y; ++o) {
                c.matrix[i][o] /= b;
            }
        }
        return c;
    }

    void Keyboard() {
        for (int i = 0; i < size_x; ++i) {
            for (int o = 0; o < size_y; ++o) {
                std::cout << "Enter element x:" << i + 1 << ", y: " << o + 1 << ": ";
                std::cin >> matrix[i][o];
            }
        }
    }

    void Random() {
        for (int i = 0; i < size_x; ++i) {
            for (int o = 0; o < size_y; ++o) {
                matrix[i][o] = rand() % (100 + 100 + 1) - 100;
            }
        }
    }

    void Show() {
        for (int i = 0; i < size_x; ++i) {
            for (int o = 0; o < size_y; ++o) {
                std::cout.width(4);
                std::cout << matrix[i][o];
            }
            std::cout << std::endl;
        }
    }

    T FindMin() {
        T min = matrix[0][0];
        for (int i = 0; i < size_x; ++i) {
            for (int o = 0; o < size_y; ++o) {
                min = (min < matrix[i][o]) ? min : matrix[i][o];
            }
        }
        return min;
    }

    T FindMax() {
        T max = matrix[0][0];
        for (int i = 0; i < size_x; ++i) {
            for (int o = 0; o < size_y; ++o) {
                max = (max > matrix[i][o]) ? max : matrix[i][o];
            }
        }
        return max;
    }

private:
    void DeleteM() {
        for (int i = 0; i < size_x; ++i) {
            delete[] matrix[i];
        }
        delete[] matrix;
    }
};


int main()
{
    int** matrix = new int*[5];
    for (int i = 0; i < 5; ++i) {
        matrix[i] = new int[5] {0};
    }
    Matrix<int> a(5, 5, matrix);

    a = a + 1;
    a.Show();
    a.Random();
    a.Show();

    cout << endl;
    system("pause");
}