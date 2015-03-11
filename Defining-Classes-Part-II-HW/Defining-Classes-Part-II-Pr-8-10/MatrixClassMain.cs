using System;

namespace Defining_Classes_Part_II_Pr_8_10
{
    class MatrixClassMain
    {
        static void Main()
        {
            Matrix<int> testMatrix = new Matrix<int>(4, 3); //creates an int matrix w/ 4 rows and 3 cols, all cells = 0

            testMatrix[1, 1] = 5; // setting value to a cell and printing it
            Console.WriteLine("Matrix[1,1] = {0}", testMatrix[1,1]);

            Matrix<double> testMatrix2 = new Matrix<double>(new double[,]{{1.2, 2.3, 3.4}, {1.2, 2.3, 3.4}});
            Console.WriteLine("Another Matrix[1,1] = {0}", testMatrix2[1,1]); //testing the second constructor

            Matrix<int> matrix1 = new Matrix<int>(3, 3); //two matrices for testing +, - and *
            Matrix<int> matrix2 = new Matrix<int>(3, 3);

            for (int i = 0; i < matrix1.Rows; i++)
            {
                for (int j = 0; j < matrix1.Cols; j++)
                {
                    matrix1[i, j] = (i + 3)*(j + 1) + 5;
                    matrix2[i, j] = (i + 1) * (j + 2);
                }
            }

            Console.WriteLine("Matrix 1:\n{0}", matrix1);
            Console.WriteLine("Matrix 2:\n{0}", matrix2);

            Matrix<int> resultOfAddition = matrix1 + matrix2;
            Matrix<int> resultOfSubtraction = matrix1 - matrix2;
            Matrix<int> resultOfMultiplication = matrix1 * matrix2;

            Console.WriteLine("Matrix1 + Matrix2 =\n{0}", resultOfAddition);
            Console.WriteLine("Matrix1 - Matrix2 =\n{0}", resultOfSubtraction);
            Console.WriteLine("Matrix1 * Matrix2 =\n{0}", resultOfMultiplication);

            //testing true/false
            if (matrix1)
            {
                Console.WriteLine("{0} does not contain zero elements", matrix1);
            }
            else
            {
                Console.WriteLine("{0} contains zero element(s)");
            }

            matrix1[0, 0] = 0;

            if (matrix1)
            {
                Console.WriteLine("{0} does not contain zero elements", matrix1);
            }
            else
            {
                Console.WriteLine("{0} contains zero element(s)", matrix1);
            }
        }
    }
}
