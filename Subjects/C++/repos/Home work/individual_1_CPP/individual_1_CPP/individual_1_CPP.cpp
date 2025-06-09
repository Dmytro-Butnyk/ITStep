#include <iostream>
#include <ctime>
#define ROWS 10
#define COLS 10
using namespace std;

int MINES = 100;

void InitialiseBoard(char board[ROWS][COLS], char hiddenBoard[ROWS][COLS]) {
    // заповнення дошки символами
    for (int i = 0; i < ROWS; ++i) {
        for (int j = 0; j < COLS; ++j) {
            board[i][j] = '-';
            hiddenBoard[i][j] = '-';
        }
    }

    // розміщення мін 
    srand(unsigned(time(0)));
    for (int k = 0; k < MINES; ++k) {
        int randRow = rand() % ROWS;
        int randCol = rand() % COLS;

        // перевірка, чи є міна в клітинці 
        while (board[randRow][randCol] == '*') {
            randRow = rand() % ROWS;
            randCol = rand() % COLS;
        }

        board[randRow][randCol] = '*';
    }
}

void PrintBoard(const char board[ROWS][COLS]) {
    for (int i = 0; i < ROWS; ++i) {
        for (int j = 0; j < COLS; ++j) {
            cout << board[i][j] << ' ';
        }
        cout << endl;
    }
}

// перевірка на правильність ходу
bool IsValidMove(int row, int col) {
    return row >= 0 && row < ROWS && col >= 0 && col < COLS;
}

// метод рахує міни навколо клітинки
int NumMinesNear(const char board[ROWS][COLS], int row, int col) {
    int count = 0;
    for (int i = -1; i <= 1; ++i) {
        for (int j = -1; j <= 1; ++j) {
            int newRow = row + i;
            int newCol = col + j;

            if (IsValidMove(newRow, newCol) && board[newRow][newCol] == '*') {
                ++count;
            }
        }
    }

    return count;
}

// метод відкриває клітинки, якщо в них немає мін
void OpenEmptyCells(char board[ROWS][COLS], char hiddenBoard[ROWS][COLS], int row, int col) {
    if (!IsValidMove(row, col) || hiddenBoard[row][col] != '-') {
        return;
    }

    int mines = NumMinesNear(board, row, col);
    hiddenBoard[row][col] = (mines == 0) ? ' ' : mines + '0';

    if (mines == 0) {
        for (int i = -1; i <= 1; ++i) {
            for (int j = -1; j <= 1; ++j) {
                OpenEmptyCells(board, hiddenBoard, row + i, col + j);
            }
        }
    }
}


bool IsWin(const char hiddenBoard[ROWS][COLS], const char board[ROWS][COLS]) {
    for (int i = 0; i < ROWS; ++i) {
        for (int j = 0; j < COLS; ++j) {
            if (hiddenBoard[i][j] == '-' && board[i][j] != '*') {
                return false;
            }
        }
    }
    return true;
}

void ShowAllMines(char board[ROWS][COLS]) {
    for (int i = 0; i < ROWS; ++i) {
        for (int j = 0; j < COLS; ++j) {
            if (board[i][j] == '*') {
                board[i][j] = 'X';
            }
        }
    }
}

int main() {
    setlocale(0, "");
    char board[ROWS][COLS];
    char hiddenBoard[ROWS][COLS];

    cout << "Enter number of mines: ";
    cin >> MINES;

    InitialiseBoard(board, hiddenBoard);

    while (true) {
        PrintBoard(hiddenBoard);

        int row, col;
        cout << "Enter coordinates (row column): ";
        cin >> row >> col;
        --row; 
        --col;


        if (!IsValidMove(row, col)) {
            cout << "Wrong coordinates! Try again." << endl;
            continue;
        }

        if (board[row][col] == '*') {
            cout << "You have blown up! You loose!" << endl;
            ShowAllMines(board);
            PrintBoard(board);
            break;
        }
        else {
            OpenEmptyCells(board, hiddenBoard, row, col);

            if (IsWin(hiddenBoard, board)) {
                ShowAllMines(board);
                PrintBoard(board);
                cout << "Congratulations! You won!" << endl;
                break;
            }
        }
    }

    cout << endl;
    system("pause");
}
