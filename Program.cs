using System;
using Matrices;

namespace Matrices
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Matrix myMatrix = new Matrix(2, 2);

            double[,] a = { { 2, 2 }, { 1, 3 } };
            myMatrix.matrix = a;
            Console.WriteLine("Matrix A\n");
            myMatrix.print();
            Console.WriteLine("_________________\n");

            Matrix myOtherMatrix = new Matrix(3, 3);

            double[,] b = { { 1, 2, -1 }, { 2, 2, 4 }, {1, 3, -3 } };
            myOtherMatrix.matrix = b;
            Console.WriteLine("Matrix B\n");
            myOtherMatrix.print();
            Console.WriteLine("_________________\n");

            //Console.WriteLine("A + A\n");
            //(myMatrix + myMatrix).print();


            Console.WriteLine("A - A\n");
            (myMatrix - myMatrix).print();
            Console.WriteLine("_________________\n");


            Console.WriteLine("A * A\n");
            (myMatrix * myMatrix).print();
            Console.WriteLine("_________________\n");

            Console.WriteLine("B * 5\n");
            (myOtherMatrix * 5).print();
            Console.WriteLine("_________________\n");

            Console.WriteLine("Inverse of A\n");
            Matrix.Inverse(myMatrix).print();
            Console.WriteLine("_________________\n");

            Console.WriteLine("Inverse of B\n");
            Matrix.Inverse(myOtherMatrix).print();
            Console.WriteLine("_________________\n");

            Console.WriteLine("Transpose of B\n");
            Matrix.Transpose(myOtherMatrix).print();
            Console.WriteLine("_________________\n");

            Console.WriteLine("min = " + Matrix.Min(myMatrix));
            Console.WriteLine("max = " + Matrix.Max(myMatrix));
            Console.WriteLine("_________________\n");

            Console.WriteLine("min = " + Matrix.Min(myOtherMatrix));
            Console.WriteLine("max = " + Matrix.Max(myOtherMatrix));
            Console.WriteLine("_________________\n");

        }
    }
}

