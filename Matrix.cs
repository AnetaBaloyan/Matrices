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
        public int rows { get; }
        /// <summary>
        /// The columns.
        /// </summary>
        public int columns { get; }

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
        public static void Assign(out Matrix a, Matrix b)
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
             else throw new System.ArgumentException("Multibplied matrices of incompareable sizes.");

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

        /// <summary>
        /// Determines whether a specified instance of <see cref="Matrices.Matrix"/> is equal to another specified <see cref="Matrices.Matrix"/>.
        /// </summary>
        /// <param name="a">The first <see cref="Matrices.Matrix"/> to compare.</param>
        /// <param name="b">The second <see cref="Matrices.Matrix"/> to compare.</param>
        /// <returns><c>true</c> if <c>a</c> and <c>b</c> are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(Matrix a, Matrix b)
        {
            bool result = true;
            if (a.rows == b.rows && a.columns == b.columns)
            {
                for (int i = 0; i < a.rows; i++)
                {
                    for (int j = 0; j < a.columns; j++)
                    {
                        if(a.matrix[i, j] != b.matrix[i, j])
                        {
                            result = false;
                        };
                    }
                }
                return result;
            }
            else return false;
        }

        public static Matrix Identity(int n)
        {
            Matrix result = new Matrix(n, n);
            for (int i = 0; i < n; i++)
            {
                result.matrix[i, i] = 1;
            }
            return result;
        }

        /// <summary>
        /// Determines whether a specified instance of <see cref="Matrices.Matrix"/> is not equal to another specified <see cref="Matrices.Matrix"/>.
        /// </summary>
        /// <param name="a">The first <see cref="Matrices.Matrix"/> to compare.</param>
        /// <param name="b">The second <see cref="Matrices.Matrix"/> to compare.</param>
        /// <returns><c>true</c> if <c>a</c> and <c>b</c> are not equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(Matrix a, Matrix b)
        {
            return (a == b) == false;
        }

        public static Matrix operator |(Matrix a, Matrix b)
        {
            Matrix result= new Matrix(a.rows, a.columns + b.columns);
            for (int i = 0; i < result.rows; i++)
            {
                for (int j = 0; j < result.columns; j++)
                {
                    if (j < a.columns)
                    {
                        result.matrix[i, j] = a.matrix[i, j];
                    } else result.matrix[i, j] = b.matrix[i, (j - a.columns)];
                }
            }
            return result;
        }

        /// <summary>
        /// The Inverse of the specified Matrix.
        /// </summary>
        /// <returns>The inverse.</returns>
        /// <param name="a">The Matrix.</param>
        public static Matrix Inverse(Matrix a)
        {
            if (a.columns != a.rows)
            {
                Console.WriteLine("The matrix is NOT invertible!");
                return new Matrix(0, 0);
            }
            else
            {
                Matrix result = new Matrix(a.rows, a.columns);
                Matrix workingMatrix = new Matrix(a.rows, 2 * a.columns);

                workingMatrix = a | Identity(a.rows);

                for (int i = 0; i < a.rows; i++)
                {
                    workingMatrix = DivideRow(workingMatrix, i);
                    //Console.WriteLine("divide " + i + "\n");
                    //result.print();

                    workingMatrix = SubtractAll(workingMatrix, i);
                    //Console.WriteLine("subtract " + i + "\n");
                    //result.print();
                }

                for (int i = 0; i < a.rows; i++)
                {
                    for (int j = 0; j < a.columns; j++)
                    {
                        result.matrix[i, j] = workingMatrix.matrix[i, j];
                    }
                }

                if (result != Identity(a.rows))
                {
                    Console.WriteLine("The matrix is NOT invertible!");
                    return new Matrix(0, 0);
                }
                else
                {
                    for (int i = 0; i < a.rows; i++)
                    {
                        for (int j = 0; j < a.columns; j++)
                        {
                            result.matrix[i, j] = workingMatrix.matrix[i, a.columns + j];
                        }
                    }
                    return result;
                }
            }
        }

        /// <summary>
        /// Cancelles the kth row of the given matrix.
        /// </summary>
        /// <returns>The matrix with cancelled row.</returns>
        /// <param name="a">The matrix.</param>
        /// <param name="k">The index of row to divide.</param>
        private static Matrix DivideRow(Matrix a, int k)
        {
            Matrix result;

            Matrix.Assign(out result, a);

            int last = result.rows - 1;

            while(result.matrix[k, k] == 0 && last != k) 
            {
                for (int j = k; j < a.columns; j++)
                {
                    double temp = result.matrix[k, j];
                    result.matrix[k, j] = result.matrix[last, j];
                    result.matrix[last, j] = temp;
                }
                //Console.WriteLine("switch " + k + "th with the " + last + "th" + "\n");
                //result.print();

                last--;
            }

            if (result.matrix[k, k] != 0)
            {
                double divisor = result.matrix[k, k];
                for (int j = k; j < a.columns; j++)
                {
                    result.matrix[k, j] /= divisor;
                }
            }

            return result;
        }

        /// <summary>
        /// Subtracts the row from all other rows of the given matrix.
        /// </summary>
        /// <returns>The the resulting matrix.</returns>
        /// <param name="a">The matrix.</param>
        /// <param name="k">The index of the row.</param>
        private static Matrix SubtractAll(Matrix a, int k)
        {
            Matrix result;

            Matrix.Assign(out result, a);

            for (int i = 0; i < a.rows; i++)
            {
                if (i != k)
                {
                    double argument = result.matrix[i, k];
                    for (int j = 0; j < result.columns; j++)
                    {
                        if (argument != 0)
                        {
                            result.matrix[i, j] -= (argument * result.matrix[k, j]);
                        }
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Transpose the specified matrix.
        /// </summary>
        /// <returns>The transpose.</returns>
        /// <param name="a">The matrix.</param>
        public static Matrix Transpose(Matrix a) 
        {
            Matrix result = new Matrix(a.columns, a.rows);
            for (int i = 0; i < a.rows; i++)
            {
                for (int j = 0; j < a.columns; j++)
                {
                    result.matrix[j, i] = a.matrix[i, j];
                }
            }
            return result;
        }

        /// <summary>
        /// Determines if the matrix is orthogonal.
        /// </summary>
        /// <returns><c>true</c>, if the matrix isorthogonal, <c>false</c> otherwise.</returns>
        /// <param name="a">The matrix.</param>
        public static bool IsOrthogonal(Matrix a)
        {
            return Inverse(a) == Transpose(a);
        }

        /// <summary>
        /// Rotates the specified matrix a, by angle t about the origin, clockwise if d is true and counterclockwise otherwise.
        /// </summary>
        /// <returns>The rotated matrix.</returns>
        /// <param name="a">The matrix.</param>
        /// <param name="t">The angle.</param>
        /// <param name="d">If set to <c>true</c> clockwise, and counterclockwise otherwise.</param>
        public static Matrix Rotation(Matrix a, int t, bool d)
        {
            Matrix template = new Matrix(2, 2);
            Matrix result = new Matrix(2, 2);
            double[,] container;

            if(d)
            {
                container = new double[,] { { Math.Cos(t), Math.Sin(t) }, { Math.Sin(-t), Math.Cos(t) } };
            } 
            else 
            {
                container = new double[,] { { Math.Cos(t), Math.Sin(-t) }, { Math.Sin(t), Math.Cos(t) } };
            }

            template.matrix = container;

            result = a * template;
            return result;
        }

        /// <summary>
        /// Scaling the specified matrix a by a factor k.
        /// </summary>
        /// <returns>The resulting matrix.</returns>
        /// <param name="a">The matrix.</param>
        /// <param name="k">The factor k.</param>
        public static Matrix Scaling(Matrix a, int k)
        {
            Matrix result = new Matrix(2, 2);

            result = a * k * Identity(a.columns);
            return result;
        }

        /// <summary>
        /// I don't know what this is.
        /// </summary>
        /// <returns>The translated matrix.</returns>
        public static Matrix Translation()
        {
            Matrix result = new Matrix(0, 0);
            return result;
        }

        /// <summary>
        /// The smallest element of the given matrix.
        /// </summary>
        /// <returns>The smallest element.</returns>
        /// <param name="a">The matrix.</param>
        public static double Min(Matrix a)
        {
            double min = a.matrix[0, 0];

            for (int i = 0; i < a.rows; i++)
            {
                for (int j = 0; j < a.columns; j++)
                {
                    if (min > a.matrix[i, j]) min = a.matrix[i, j];
                }
            }

            return min;
        }

        /// <summary>
        /// The biggest element of the given matrix.
        /// </summary>
        /// <returns>The biggest element.</returns>
        /// <param name="a">The matrix.</param>
        public static double Max(Matrix a)
        {
            double max = a.matrix[0, 0];

            for (int i = 0; i < a.rows; i++)
            {
                for (int j = 0; j < a.columns; j++)
                {
                    if (max < a.matrix[i, j]) max = a.matrix[i, j];
                }
            }

            return max;
        }
    }
}
