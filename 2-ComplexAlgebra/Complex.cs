using System;

namespace ComplexAlgebra
{
    /// <summary>
    /// A type for representing Complex numbers.
    /// </summary>
    ///
    /// TODO: Model Complex numbers in an object-oriented way and implement this class.
    /// TODO: In other words, you must provide a means for:
    /// TODO: * instantiating complex numbers
    /// TODO: * accessing a complex number's real, and imaginary parts
    /// TODO: * accessing a complex number's modulus, and phase
    /// TODO: * complementing a complex number
    /// TODO: * summing up or subtracting two complex numbers
    /// TODO: * representing a complex number as a string or the form Re +/- iIm
    /// TODO:     - e.g. via the ToString() method
    /// TODO: * checking whether two complex numbers are equal or not
    /// TODO:     - e.g. via the Equals(object) method
    public class Complex
    {
        // TODO: fill this class

        private const double Zero = 0d;

        public Complex(double real, double imaginary)
        {
            this.Real = real;
            this.Imaginary = imaginary;
        }

        public double Real { get; }

        public double Imaginary { get; }

        public double Modulus => Math.Sqrt(Real * Real + Imaginary * Imaginary);

        public double Phase => Math.Atan2(Imaginary, Real);

        public override string ToString()
        {
            if (Imaginary == Zero)
            {
                return Real.ToString();
            }
            var imAbsoluteValue = Math.Abs(Imaginary);
            var imValue = imAbsoluteValue == 1.0 ? "" : imAbsoluteValue.ToString();
            string sign;
            if (Real == Zero)
            {
                sign = Imaginary > 0 ? "" : "-";
                return sign + "i" + imValue;
            }
            else
            {
                sign = Imaginary > 0 ? "+" : "-";
                return $"{Real} {sign} i{imValue}";
            }
        }

        protected bool Equals(Complex other)
        {
            return Real.Equals(other.Real) && Imaginary.Equals(other.Imaginary);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            if (obj.GetType() != GetType())
            {
                return false;
            }
            return Equals(obj as Complex);
        }

        public override int GetHashCode() => HashCode.Combine(Real, Imaginary);

        public Complex Complement() => new Complex(Real, -Imaginary);

        public Complex Plus(Complex complex) => new Complex(Real + complex.Real, Imaginary + complex.Imaginary);

        public Complex Minus(Complex complex) => new Complex(Real - complex.Real, Imaginary - complex.Imaginary);
    }
}