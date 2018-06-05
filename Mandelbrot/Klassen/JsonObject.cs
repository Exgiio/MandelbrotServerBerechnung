using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandelbrotBerechnung.Klassen
{
    class JsonObject
    {
        #region Felder

        private decimal m_RealFrom = 0;
        private decimal m_RealTo = 0;
        private decimal m_ImaginaryFrom = 0;
        private decimal m_ImaginaryTo = 0;
        private decimal m_Intervall = 0;
        private int m_MaxInteration = 0;

        #endregion

        #region Eigenschaften

        public decimal RealFrom
        {
            get
            {
                return m_RealFrom;
            }
        }

        public decimal RealTo
        {
            get
            {
                return m_RealTo;
            }
        }

        public decimal ImaginaryFrom
        {
            get
            {
                return m_ImaginaryFrom;
            }
        }

        public decimal ImaginaryTo
        {
            get
            {
                return m_ImaginaryTo;
            }
        }

        public decimal Intervall
        {
            get
            {
                return m_Intervall;
            }
        }

        public int MaxIteration
        {
            get
            {
                return m_MaxInteration;
            }
        }

        #endregion

        #region Konstruktor/en

        public JsonObject(string json)
        {
            if (!string.IsNullOrWhiteSpace(json))
            {
                JObject jObject = JObject.Parse(json);
                decimal.TryParse(jObject["RealFrom"].ToString().Replace(".", ","), out m_RealFrom);
                decimal.TryParse(jObject["RealTo"].ToString().Replace(".", ","), out m_RealTo);
                decimal.TryParse(jObject["ImaginaryFrom"].ToString().Replace(".", ","), out m_ImaginaryFrom);
                decimal.TryParse(jObject["ImaginaryTo"].ToString().Replace(".", ","), out m_ImaginaryTo);
                decimal.TryParse(jObject["Intervall"].ToString().Replace(".", ","), out m_Intervall);
                int.TryParse(jObject["MaxIteration"].ToString(), out m_MaxInteration);
            }
        }

        #endregion
    }
}
