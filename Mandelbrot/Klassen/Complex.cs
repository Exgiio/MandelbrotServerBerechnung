using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandelbrotBerechnung.Klassen
{
    public class Complex
    {
        #region Felder

        private double m_Realteil = 0.0;
        private double m_Imaginärteil = 0.0;

        #endregion

        #region Konstruktor

        public Complex(double real, double imag)
        {
            this.m_Realteil = real;
            this.m_Imaginärteil = imag;
        }

        #endregion

        #region Eigenschaften

        public double Realteil
        {
            set
            {
                m_Realteil = value;
            }
            get
            {
                return m_Realteil;
            }
        }

        public double Imaginärteil
        {
            set
            {
                m_Imaginärteil = value;
            }
            get
            {
                return m_Imaginärteil;
            }
        }

        #endregion

        #region Methoden

        public static double Magnitude(Complex z)
        {
            return Math.Sqrt((z.m_Realteil * z.m_Realteil) + (z.m_Imaginärteil * z.m_Imaginärteil));
        }

        public static void Square(ref Complex z)
        {
            double temp = (z.Realteil * z.Realteil) - (z.Imaginärteil * z.Imaginärteil);
            z.Imaginärteil = 2.0 * z.Realteil * z.Imaginärteil;
            z.Realteil = temp;
        }

        public static void AddCtoZ(Complex c, ref Complex z)
        {
            z.m_Realteil += c.m_Realteil;
            z.m_Imaginärteil += c.m_Imaginärteil;
        }

        #endregion
    }
}
