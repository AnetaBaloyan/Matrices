using System;
using Matrices;

namespace Matrices
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Matrix myMatrix = new Matrix(2, 3);

            double[,] a = { { 1, 2, 3 }, { 4, 5, 6 } };
            myMatrix.matrix = a;

            Matrix myOtherMatrix = new Matrix(3, 3);

            double[,] b = { { 1, 2, -1 }, { 2, 2, 4 }, {1, 3, -3} };
            myOtherMatrix.matrix = b;

            myMatrix += myMatrix;

            myMatrix.print();


            Console.WriteLine("_______________\n");

            myMatrix -= myMatrix;

            myMatrix.print();


            Console.WriteLine("_______________\n");

            myMatrix *= myOtherMatrix;

            myMatrix.print();

            Console.WriteLine("_______________\n");

            myOtherMatrix *= 5;

            myOtherMatrix.print();

            //Console.WriteLine("_______________\n");

            //Matrix inverseOfTheSecondMatrix = Matrix.Inverse(myOtherMatrix);

            //myOtherMatrix.print();
            //inverseOfTheSecondMatrix.print();

        }
    }
}
