using System;

namespace Poly
{
    public sealed class Polynomial
    {
        const double eps = double.Epsilon;

        double[] coeffs;

        public Polynomial(params double[] coefficients)
        {
            coeffs = coefficients;
        }

        /// <summary>
        /// Indexer
        /// </summary>
        public double this[int index]
        {
            get
            {
                if (index < 0 || index >= this.coeffs.Length)
                {
                    throw new ArgumentOutOfRangeException("Index out of range");
                }

                return coeffs[index];
            }

            private set
            {
                if (index < 0 || index >= this.coeffs.Length)
                {
                    throw new ArgumentOutOfRangeException("Index out of range");
                }

                coeffs[index] = value;
            }
        }

        public double[] GetCoeffs()
        {
            double[] coeffs = new double[Length];
            Array.Copy(this.coeffs, coeffs, Length);
            return coeffs;
        }

        private int Length
        {
            get
            {
                return coeffs.Length;
            }
        }

        #region Operators

        /// <summary>
        /// Overloaded "+" operator
        /// </summary>
        /// <param name="firstPol"> First polynomial </param>
        /// <param name="secondPol"> Second polynomial </param>
        /// <returns> Sum of two polynomials </returns>
        public static Polynomial operator +(Polynomial firstPol, Polynomial secondPol)
        {
            Polynomial result = new Polynomial();
            bool firstIsLonger = firstPol.Length >= secondPol.Length;
            int min;
            if (firstIsLonger)
            {
                min = secondPol.Length;
                result.coeffs = new double[firstPol.Length];
                Array.Copy(firstPol.coeffs, result.coeffs, firstPol.Length);
            }
            else
            {
                min = firstPol.Length;
                result.coeffs = new double[secondPol.Length];
                Array.Copy(secondPol.coeffs, result.coeffs, secondPol.Length);
            }

            for (int i = 0; i < min; i++)
            {
                result.coeffs[i] += firstIsLonger ? secondPol.coeffs[i] : firstPol.coeffs[i];
            }

            return result;
        }

        /// <summary>
        /// Overloaded "-" operator for single polynomial
        /// </summary>
        /// <param name="polynomial"> Polynomial </param>
        /// <returns> Negative polynomial </returns>
        public static Polynomial operator -(Polynomial polynomial)
        {
            Polynomial result = new Polynomial(new double[polynomial.Length]);
            Array.Copy(polynomial.coeffs, result.coeffs, polynomial.Length);
            for (int i = 0; i < polynomial.Length; i++)
            {
                result.coeffs[i] = -polynomial.coeffs[i];
            }
            return result;
        }

        /// <summary>
        /// Overloaded "-" operator
        /// </summary>
        /// <param name="firstPol"> First polynomial </param>
        /// <param name="secondPol"> Second polynomial </param>
        /// <returns> Result of substraction second polynomial out of first </returns>
        public static Polynomial operator -(Polynomial firstPol, Polynomial secondPol)
        {
            return (firstPol + (-secondPol));
        }

        /// <summary>
        /// Overloaded "*" operator
        /// </summary>
        /// <param name="firstPol"> First polynomial </param>
        /// <param name="secondPol"> Second polynomial </param>
        /// <returns> Multiplied polynomial </returns>
        public static Polynomial operator *(Polynomial firstPol, Polynomial secondPol)
        {
            Polynomial result = new Polynomial(new double[firstPol.Length + secondPol.Length - 1]);

            int min = firstPol.Length > secondPol.Length ? secondPol.Length : firstPol.Length;
            int max = firstPol.Length > secondPol.Length ? firstPol.Length : secondPol.Length;

            bool firstIsLonger = firstPol.Length > secondPol.Length;
            for (int i = 0; i < min; i++)
            {
                int k = 0;
                while (k < max)
                {
                    result.coeffs[k + i] += firstIsLonger ? secondPol.coeffs[i] * firstPol.coeffs[k] : firstPol.coeffs[i] * secondPol.coeffs[k];
                    k++;
                }

            }
            return result;
        }

        /// <summary>
        /// Overloaded "*" operator for multiplying polynomial and number
        /// </summary>
        /// <param name="polynomial"> Polynomial </param>
        /// <param name="multiplier"> Multiplier </param>
        /// <returns> Multiplied polynomial </returns>
        public static Polynomial operator *(Polynomial polynomial, double multiplier)
        {
            Polynomial num = new Polynomial(multiplier);
            return polynomial * num;
        }

        /// <summary>
        /// Same as previous, but in different order
        /// </summary>
        public static Polynomial operator *(double multiplier, Polynomial polynomial)
        {
            return polynomial * multiplier;
        }

        /// <summary>
        /// Overloaded "/" operator for divider and polynomial
        /// </summary>
        /// <param name="polynomial"> Polynomial </param>
        /// <param name="divider"> Divider </param>
        /// <returns> Result of dividing polynomial by a number </returns>
        public static Polynomial operator /(Polynomial polynomial, double divider)
        {
            Polynomial result = new Polynomial();

            for (int i = 0; i < polynomial.Length; i++)
            {
                result.coeffs[i] = polynomial.coeffs[i] / divider;
            }

            return result;
        }

        /// <summary>
        /// Overloaded "==" operator
        /// </summary>
        /// <param name="firstPol"> First polynomial </param>
        /// <param name="secondPol"> Second polynomial </param>
        /// <returns> Result of comparison </returns>
        public static bool operator ==(Polynomial firstPol, Polynomial secondPol)
        {
            if (firstPol.Length != secondPol.Length)
            {
                return false;
            }
            for (int i = 0; i < firstPol.Length; i++)
            {
                if (Math.Abs(firstPol.coeffs[i] - secondPol.coeffs[i]) > eps)
                {
                    return false;
                }
            }
            return true;
        }


        /// <summary>
        /// Overloaded "!=" operator
        /// </summary>
        public static bool operator !=(Polynomial firstPol, Polynomial secondPol)
        {
            return !(firstPol == secondPol);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Overrided Equals method
        /// </summary>
        /// <param name="obj"> Object to compare </param>
        /// <returns> Comparison result </returns>
        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != this.GetType())
            {
                return false;
            }
            return this == (Polynomial)obj;
        }

        /// <summary>
        /// Overrided ToString method
        /// </summary>
        /// <returns> String-formed polynomial </returns>
        public override string ToString()
        {
            string stringPoly = "";
            for (int i = this.Length - 1; i >= 0; i--)
            {
                if (coeffs[i] == 0)
                {
                    continue;
                }
                if (coeffs[i] > 0)
                {
                    stringPoly += " + ";
                }
                else
                {
                    stringPoly += " - ";
                }
                if (i == 0)
                {
                    stringPoly += Math.Abs(coeffs[i]);
                }
                else
                {
                    stringPoly += (Math.Abs(coeffs[i]) + "*x^" + i);
                }
            }

            return stringPoly.Trim(' ', '+');
        }


        /// <summary>
        /// Overrided GetHashCode method
        /// </summary>
        /// <returns> Hash code </returns>
        public override int GetHashCode()
        {
            int hash = 31;

            foreach (var item in coeffs)
            {
                hash = (hash * 13) + item.GetHashCode();
            }

            return hash;
        }

        #endregion
    }
}
