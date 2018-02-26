using System;
namespace Matrices
{
    /// <summary>
    /// Matrix.
    /// </summary>
    public class Matrix
    {
        /// <summary>
        /// Gets or sets the matrix.
        /// </summary>
        /// <value>The matrix.</value>
        public double[,] matrix { get; set; }
        /// <summary>
        /// The rows.
        /// </summary>
        private int rows { get; set; }
        /// <summary>
        /// The columns.
        /// </summary>
        private int columns { get; set; }

        /// <summary>
        /// Initializes a new instance of the Matrix class.
        /// </summary>
        /// <param name="rows">Rows.</param>
        /// <param name="columns">Columns.</param>
        public Matrix(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;
            this.matrix = new double[rows, columns];
        }

        /// <summary>
        /// Prints the matrix.
        /// </summary>
        public void print()
        {
            for (int i = 0; i < this.rows; i++)
            {
                for (int j = 0; j < this.columns; j++)
                {
                    Console.Write(this.matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Equals the specified a and b.
        /// </summary>
        /// <returns>The equals.</returns>
        /// <param name="a">The first matrix.</param>
        /// <param name="b">The second matrix.</param>
        public static void equals(out Matrix a, Matrix b)
        {
            a = new Matrix(b.rows, b.columns);

            for (int i = 0; i < a.rows; i++)
            {
                for (int j = 0; j < a.columns; j++)
                {
                    a.matrix[i, j] = b.matrix[i, j];
                }
            }
        }

        /// <summary>
        /// Adds two matrices, yielding a new matrix.
        /// </summary>
        /// <param name="a">The first <see cref="Matrices.Matrix"/> to add.</param>
        /// <param name="b">The second <see cref="Matrices.Matrix"/> to add.</param>
        /// <returns>The resulted <see cref="T:Matrices.Matrix"/>.</returns>
        public static Matrix operator +(Matrix a, Matrix b)
        {
            Matrix result = new Matrix(a.rows, a.columns);

            if (a.rows == b.rows && a.columns == b.columns)
            {
                result.columns = a.columns;
                result.rows = a.rows;

                for (int i = 0; i < a.rows; i++)
                {
                    for (int j = 0; j < b.columns; j++)
                    {
                        result.matrix[i, j] = a.matrix[i, j] + b.matrix[i, j];
                    }
                }
            } else throw new System.ArgumentException("Summed matrices of different sizes.");

            return result;
        }

        /// <summary>
        /// Subtracts a <see cref="Matrices.Matrix"/> from a <see cref="Matrices.Matrix"/>, yielding a new <see cref="T:Matrices.Matrix"/>.
        /// </summary>
        /// <param name="a">The <see cref="Matrices.Matrix"/> to subtract from (the minuend).</param>
        /// <param name="b">The <see cref="Matrices.Matrix"/> to subtract (the subtrahend).</param>
        /// <returns>The resulted <see cref="T:Matrices.Matrix"/>.</returns>
        public static Matrix operator -(Matrix a, Matrix b)
        {
            Matrix result = new Matrix(a.rows, a.columns);

            if (a.rows == b.rows && a.columns == b.columns)
            {
                result.columns = a.columns;
                result.rows = a.rows;

                for (int i = 0; i < a.rows; i++)
                {
                    for (int j = 0; j < b.columns; j++)
                    {
                        result.matrix[i, j] = a.matrix[i, j] - b.matrix[i, j];
                    }
                }
            }
            else throw new System.ArgumentException("Suptracted matrices of different sizes.");

            return result;
        }

        /// <summary>
        /// Computes the product of Matrix <c>a</c> and Matrix <c>b</c>, yielding a new <see cref="T:Matrices.Matrix"/>.
        /// </summary>
        /// <param name="a">The first <see cref="Matrices.Matrix"/> to multiply.</param>
        /// <param name="b">The second <see cref="Matrices.Matrix"/> to multiply.</param>
        /// <returns>The <see cref="T:Matrices.Matrix"/> that is the <c>a</c> * <c>b</c>.</returns>
        public static Matrix operator *(Matrix a, Matrix b)
        {
            Matrix result = new Matrix(a.rows, b.columns);

            if (a.columns == b.rows)
            {
                result.rows = a.rows;
                result.columns = b.columns;

                for (int i = 0; i < a.rows; i++)
                {
                    for (int j = 0; j < b.columns; j++)
                    {
                        double sum = 0;

                        for (int k = 0; k < b.rows; k++)
                        {
                            sum += (a.matrix[i, k] * b.matrix[k, j]);
                        }

                        result.matrix[i, j] = sum;
                    }
                }
            }
            else throw new System.ArgumentException("Summed matrices of different sizes.");

            return result;
        }

        /// <summary>
        /// Computes the product of the scalar <c>a</c> and Matrix <c>b</c>, yielding a new <see cref="T:Matrices.Matrix"/>.
        /// </summary>
        /// <param name="a">The scalar <see cref="int"/> to multiply.</param>
        /// <param name="b">The <see cref="Matrices.Matrix"/> to multiply.</param>
        /// <returns>The resulting <see cref="T:Matrices.Matrix"/> that is <c>a</c> * <c>b</c>.</returns>
        public static Matrix operator *(int a, Matrix b)
        {
            Matrix result = new Matrix(b.rows, b.columns);

            for (int i = 0; i < b.rows; i++)
            {
                for (int j = 0; j < b.columns; j++)
                {
                    result.matrix[i, j] = a * b.matrix[i, j];
                }
            }

            return result;
        }

        /// <summary>
        /// Computes the product of Matrix <c>b</c> and scalar <c>a</c>, yielding a new <see cref="T:Matrices.Matrix"/>.
        /// </summary>
        /// <param name="b">The <see cref="Matrices.Matrix"/> to multiply.</param>
        /// <param name="a">The scalar <see cref="int"/> to multiply.</param>
        /// <returns>The resulting <see cref="T:Matrices.Matrix"/> that is the <c>b</c> * <c>a</c>.</returns>
        public static Matrix operator *(Matrix b, int a)
        {
            Matrix result = new Matrix(b.rows, b.columns);

            for (int i = 0; i < b.rows; i++)
            {
                for (int j = 0; j < b.columns; j++)
                {
                    result.matrix[i, j] = a * b.matrix[i, j];
                }
            }

            return result;
        }

        //public static Matrix Inverse(Matrix a)
        //{
        //    Matrix result;

        //    Matrix.equals(out result, a);

        //    for (int j = 0; j < a.columns; j++)
        //    {
        //        for (int i = 0; i < a.rows; i++)
        //        {
        //            result = DivideRow(result, i, j);
        //            Console.WriteLine("divide "+ i + "\n");
        //            result.print();

        //        }

        //        result = SubtractAll(result, j);
        //        Console.WriteLine("subtract " + j + "\n");
        //        result.print();
        //    }

        //    return result;
        //}

        //private static Matrix DivideRow(Matrix a, int i, int k)
        //{
        //    Matrix result;

        //    Matrix.equals(out result, a);

        //    for (int j = 0; j < a.columns; j++)
        //    {
        //        if (Math.Abs(result.matrix[i, k]) > 0.00000000000)
        //        {
        //            result.matrix[i, j] /= result.matrix[i, k];
        //        }
        //    }

        //    return result;
        //}

        //private static Matrix SubtractAll(Matrix a, int k)
        //{
        //    Matrix result;

        //    Matrix.equals(out result, a);

        //    for (int i = 0; i < a.rows; i++)
        //    {
        //        if(i != k)
        //        {
        //            for (int j = 0; j < result.columns; j++)
        //            {
        //                result.matrix[i, j] -= result.matrix[k, j]; 
        //            }
        //        }
        //    }

        //    return result;
        //}
    }
}
