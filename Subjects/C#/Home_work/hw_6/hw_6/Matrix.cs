using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace hw_6
{
    public class Matrix
    {
        private int rows;
        private int cols;
        private int[][] matrix;

        public Matrix()
        {
            rows = 3;
            cols = 3;
            matrix = new int[rows][];
            Random random = new Random();
            for (int i = 0; i < rows; i++)
            {
                matrix[i] = new int[cols];
                for (int j = 0; j < cols; j++)
                {
                    matrix[i][j] = random.Next(-100, 100);
                }
            }
        }
        public Matrix(int rows, int cols, int[][] matr)
        {
            this.rows = rows;
            this.cols = cols;
            this.matrix = matr;
        }
        public Matrix(int rows, int cols)
        {
            this.rows = rows;
            this.cols = cols;
            matrix = new int[rows][];
            Random random = new Random();
            for (int i = 0; i < rows; i++)
            {
                matrix[i] = new int[cols];
                for (int j = 0; j < cols; j++)
                {
                    matrix[i][j] = random.Next(-100, 100);
                }
            }
        }

        public int Rows
        {
            get { return rows; }
            set
            {
                if (value < 2) throw new ArgumentException("Invalid set argument!");

                rows = value;
                int[][] new_matr = new int[rows][];
                Random random = new Random();
                for (int i = 0; i < rows; i++)
                {
                    new_matr[i] = new int[cols];
                    for (int j = 0; j < cols; j++)
                    {
                        new_matr[i][j] = random.Next(-100, 100);
                    }
                }
                matrix = new_matr;
            }
        }
        public int Cols
        {
            get { return cols; }
            set
            {
                if (value < 2) throw new ArgumentException("Invalid set argument!");

                cols = value;
                int[][] new_matr = new int[rows][];
                Random random = new Random();
                for (int i = 0; i < rows; i++)
                {
                    new_matr[i] = new int[cols];
                    for (int j = 0; j < cols; j++)
                    {
                        new_matr[i][j] = random.Next(-100, 100);
                    }
                }
                matrix = new_matr;
            }
        }
        public int[][] Matr { get; set; }
        public int this[int row, int column]
        {
            get
            {
                if (row < 0 || row >= rows) throw new ArgumentException("Invalid argument!");
                if (column < 0 || column >= cols) throw new ArgumentException("Invalid argument!");
                return matrix[row][column];
            }
            set
            {
                if (row < 0 || row >= rows) throw new ArgumentException("Invalid argument!");
                if (column < 0 || column >= cols) throw new ArgumentException("Invalid argument!");
                matrix[row][column] = value;
            }
        }

        public void Show()
        {
            WriteLine($"Rows: {rows} Columns: {cols}\n");
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    Write($"{matrix[i][j],5}");
                }
                WriteLine();
            }
        }
        public void Input()
        {
            Write("Rows: ");
            int r;
            if (!int.TryParse(ReadLine(), out r))
            {
                throw new Exception("Input error!");
            }
            Rows = r;

            Write("Columns: ");
            int c;
            if (!int.TryParse(ReadLine(), out c))
            {
                throw new Exception("Input error!");
            }
            Cols = c;

            for (int i = 0; i < rows; ++i)
            {
                for (int j = 0; j < cols; ++j)
                {
                    Write($"Enter [{i},{j}] value: ");
                    if (!int.TryParse(ReadLine(), out matrix[i][j]))
                    {
                        throw new Exception("Input error!");
                    }
                    WriteLine();
                }
            }
        }

        public override string ToString()
        {
            return $"{matrix} {rows},{cols}";
        }
        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }
        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != GetType()) return false;

            var other = (Matrix)obj;
            return ToString() == other.ToString();
        }

        public int Max()
        {
            int max = int.MinValue;
            foreach (var mas in matrix)
            {
                if (mas.Max() > max) max = mas.Max();
            }
            return max;
        }
        public int Min()
        {
            int min = int.MaxValue;
            foreach (var mas in matrix)
            {
                if (mas.Min() < min) min = mas.Min();
            }
            return min;
        }
    }
