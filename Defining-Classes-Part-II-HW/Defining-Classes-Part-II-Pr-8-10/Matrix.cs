using System;
using System.Text;

namespace Defining_Classes_Part_II_Pr_8_10
{
    public class Matrix<T> where T : struct, IComparable
    {
        private int rows;
        private int cols;
        private T[,] genericMatrix;

        public int Rows {
            get { return this.rows; }
            set
            {
                if (value > 0)
                {
                    this.rows = value;    
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Rows must be > 0");
                }
            }
        }

        public int Cols
        {
            get { return this.cols; }
            set
            {
                if (value > 0)
                {
                    this.cols = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Cols must be > 0");
                }
            }
        }

        public Matrix(int rows, int cols)
        {
            this.rows = rows;
            this.cols = cols;
            this.genericMatrix = new T[this.rows, this.cols];
        } //creates a matrix with given rows and cols consisting of default for T values

        public Matrix(T[,] predefinedMatrix) //creates a matrix, consisting of predefined values, passed as a T[,]
        {
            this.genericMatrix = predefinedMatrix;
            this.rows = genericMatrix.GetLength(0);
            this.cols = genericMatrix.GetLength(1);
        }

        public T this[int indexOfRows, int indexOfCols]
        {
            get
            {
                if (indexOfRows > this.rows - 1 || indexOfRows < 0)
                {
                    throw new IndexOutOfRangeException(String.Format(
                        "Invalid index: {0}.", indexOfRows));
                }

                if (indexOfCols > this.cols - 1 || indexOfCols < 0)
                {
                    throw new IndexOutOfRangeException(String.Format(
                        "Invalid index: {0}.", indexOfCols));
                }
                T result = this.genericMatrix[indexOfRows, indexOfCols];
                return result;
            }

            set { this.genericMatrix[indexOfRows, indexOfCols] = value; }
        }

        public static Matrix<T> operator + (Matrix<T> matrix1, Matrix<T> matrix2)
        {
            if (matrix1.Rows != matrix2.Rows || matrix1.Cols != matrix2.Cols)
            {
                throw new ArgumentException("Matrices must have the same number of rows and the same number of columns");
            }
            Matrix<T> result = new Matrix<T>(matrix1.Rows, matrix1.Cols);

            for (int i = 0; i < result.Rows; i++)
            {
                for (int j = 0; j < result.Cols; j++)
                {
                    result[i, j] = (dynamic)matrix1[i, j] + matrix2[i, j];
                }
            }

            return result;
        }

        public static Matrix<T> operator - (Matrix<T> matrix1, Matrix<T> matrix2)
        {
            if (matrix1.Rows != matrix2.Rows || matrix1.Cols != matrix2.Cols)
            {
                throw new ArgumentException("Matrices must have the same number of rows and the same number of columns");
            }
            Matrix<T> result = new Matrix<T>(matrix1.Rows, matrix1.Cols);

            for (int i = 0; i < result.Rows; i++)
            {
                for (int j = 0; j < result.Cols; j++)
                {
                    result[i, j] = (dynamic)matrix1[i, j] - matrix2[i, j];
                }
            }

            return result;
        }

        public static Matrix<T> operator * (Matrix<T> matrix1, Matrix<T> matrix2)
        {
            if (matrix1.Cols != matrix2.Rows)
            {
                throw new ArgumentException("These matrices cannot be multiplied");
            }
            Matrix<T> resultMatrix = new Matrix<T>(matrix1.Rows, matrix2.Cols);
            T result = (dynamic)0;
            for (int i = 0; i < matrix1.Rows; i++)
            {
                for (int j = 0; j < matrix2.Cols; j++)
                {
                    for (int k = 0; k < matrix1.Cols; k++)
                    {
                        result += (dynamic)matrix1[i, k] * matrix2[k, j];
                    }
                    resultMatrix[i, j] = result;
                    result = (dynamic)0;
                }
            }
            return resultMatrix;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < this.rows; i++)
            {
                for (int j = 0; j < this.cols; j++)
                {
                    result.Append(string.Format("{0, 11}", this.genericMatrix[i, j]));
                }
                result.Append(Environment.NewLine);
            }

            return result.ToString();
        }

        public static bool operator true(Matrix<T> matrix)
        {

            for (int i = 0; i < matrix.Rows; i++)
            {
                for (int j = 0; j < matrix.Cols; j++)
                {
                    if (matrix[i, j] == (dynamic)0)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static bool operator false(Matrix<T> matrix)
        {
            for (int i = 0; i < matrix.Rows; i++)
            {
                for (int j = 0; j < matrix.Cols; j++)
                {
                    if (matrix[i, j] == (dynamic)0)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
