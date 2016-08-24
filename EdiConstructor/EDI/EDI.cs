using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EdiConstructor.Segmentos;

namespace EdiConstructor.EDI
{
    public abstract class EDI
    {
        public string Mensaje { get; protected set; }
        public List<SegmentoEDI> Segmentos { get; protected set; }



        protected EDI()
        {
            Segmentos = new List<SegmentoEDI>();
        }



        protected string CleanText(string str)
        {
            if (str != null)
            {
                StringBuilder sb = new StringBuilder();

                foreach (char c in str)
                {
                    if (!c.Equals('?') && !c.Equals(':') && !c.Equals('\'') && !c.Equals(',') && !c.Equals('+'))
                    {
                        sb.Append(c);
                    }
                }

                return sb.ToString();
            }

            return null;
        }


        public static string CleanNumbers(string number)
        {
            if (number != null)
            {
                StringBuilder sb = new StringBuilder();

                foreach (char c in number)
                {
                    if (!c.Equals('?') && !c.Equals(':') && !c.Equals('\'') && !c.Equals('+'))
                    {
                        sb.Append(c);
                    }
                }

                return sb.ToString();
            }

            return null;
        }
    }
}
