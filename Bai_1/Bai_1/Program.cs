using System;

namespace MatrixApp
{
    // ==================== Helpers ====================
    public static class InputCheck
    {
        public static int ReadInt(string prompt, int? min = null, int? max = null)
        {
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out int v) &&
                    (!min.HasValue || v >= min) &&
                    (!max.HasValue || v <= max))
                    return v;

                if (min.HasValue && max.HasValue)
                    Console.WriteLine($"Vui long nhap so nguyen tu {min} den {max}.");
                else if (min.HasValue)
                    Console.WriteLine($"Gia tri phai >= {min}.");
                else if (max.HasValue)
                    Console.WriteLine($"Gia tri phai <= {max}.");
                else
                    Console.WriteLine("Nhap sai. Vui long nhap so nguyen.");
            }
        }
    }

    public class Matrix
    {
        public int Rows { get; }
        public int Cols { get; }
        private readonly int[,] _data;

        public Matrix(int rows, int cols)
        {
            if (rows <= 0 || cols <= 0)
                throw new ArgumentException("Kich thuoc ma tran phai duong.");
            Rows = rows;
            Cols = cols;
            _data = new int[rows, cols];
        }

        public int this[int r, int c]
        {
            get => _data[r, c];
            set => _data[r, c] = value;
        }

        public void Input(string name = "A")
        {
            Console.WriteLine($"-- Nhap ma tran {name} ({Rows}x{Cols}) --");
            for (int i = 0; i < Rows; i++)
                for (int j = 0; j < Cols; j++)
                    this[i, j] = InputCheck.ReadInt($"[{name}][{i + 1},{j + 1}] = ");
        }

        public void Display(string title = "Matrix")
        {
            Console.WriteLine($"-- {title} ({Rows}x{Cols}) --");
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    Console.Write($"{_data[i, j],8}");
                }
                Console.WriteLine();
            }
        }

        // Cong 2 ma tran 
        public static Matrix Add(Matrix A, Matrix B)
        {
            if (A.Rows != B.Rows || A.Cols != B.Cols)
                throw new ArgumentException("Khong the cong: kich thuoc 2 ma tran phai bang nhau.");

            Matrix C = new Matrix(A.Rows, A.Cols);
            for (int i = 0; i < A.Rows; i++)
                for (int j = 0; j < A.Cols; j++)
                    C[i, j] = A[i, j] + B[i, j];
            return C;
        }

        // Nhan 2 ma tran
        public static Matrix Multiply(Matrix A, Matrix B)
        {
            if (A.Cols != B.Rows)
                throw new ArgumentException("Khong the nhan: so cot cua A phai bang so dong cua B.");

            Matrix C = new Matrix(A.Rows, B.Cols);
            for (int i = 0; i < A.Rows; i++)
            {
                for (int j = 0; j < B.Cols; j++)
                {
                    int sum = 0;
                    for (int k = 0; k < A.Cols; k++)
                        sum += A[i, k] * B[k, j];
                    C[i, j] = sum;
                }
            }
            return C;
        }

        // Chuyen vi
        public Matrix Transpose()
        {
            Matrix T = new Matrix(Cols, Rows);
            for (int i = 0; i < Rows; i++)
                for (int j = 0; j < Cols; j++)
                    T[j, i] = this[i, j];
            return T;
        }

        // Tim max, min
        public (int max, int min) MaxMin()
        {
            int max = _data[0, 0];
            int min = _data[0, 0];
            for (int i = 0; i < Rows; i++)
                for (int j = 0; j < Cols; j++)
                {
                    if (_data[i, j] > max) max = _data[i, j];
                    if (_data[i, j] < min) min = _data[i, j];
                }
            return (max, min);
        }

        // Tao ma tran tu input nguoi dung
        public static Matrix CreateFromInput(string name = "A")
        {
            int rows = InputCheck.ReadInt($"Nhap so dong ma tran {name}: ", min: 1);
            int cols = InputCheck.ReadInt($"Nhap so cot ma tran {name}: ", min: 1);
            var M = new Matrix(rows, cols);
            M.Input(name);
            return M;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n===== CHUONG TRINH XU LY MA TRAN (OOP) =====");
                Console.WriteLine("1. Nhap va hien thi mot ma tran");
                Console.WriteLine("2. Cong hai ma tran (A + B)");
                Console.WriteLine("3. Nhan hai ma tran (A x B)");
                Console.WriteLine("4. Chuyen vi ma tran (A^T)");
                Console.WriteLine("5. Tim gia tri lon nhat va nho nhat (max/min)");
                Console.WriteLine("0. Thoat");
                int choice = InputCheck.ReadInt("Chon chuc nang: ", 0, 5);

                try
                {
                    switch (choice)
                    {
                        case 1:
                            {
                                var A = Matrix.CreateFromInput("A");
                                A.Display("Ma tran A");
                                break;
                            }
                        case 2:
                            {
                                var A = Matrix.CreateFromInput("A");
                                var B = Matrix.CreateFromInput("B");
                                var C = Matrix.Add(A, B);
                                C.Display("A + B");
                                break;
                            }
                        case 3:
                            {
                                var A = Matrix.CreateFromInput("A");
                                var B = Matrix.CreateFromInput("B");
                                var C = Matrix.Multiply(A, B);
                                C.Display("A x B");
                                break;
                            }
                        case 4:
                            {
                                var A = Matrix.CreateFromInput("A");
                                var T = A.Transpose();
                                T.Display("A^T (chuyen vi)");
                                break;
                            }
                        case 5:
                            {
                                var A = Matrix.CreateFromInput("A");
                                var (max, min) = A.MaxMin();
                                A.Display("Ma tran A");
                                Console.WriteLine($"Max = {max}, Min = {min}");
                                break;
                            }
                        case 0:
                            Console.WriteLine("Tam biet!");
                            return;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Loi: " + ex.Message);
                }
            }
        }
    }
}
