using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;

namespace Practica1.Pages
{
    public class P2Model : PageModel
    {
        public string MensajeOriginal { get; set; }
        public string MensajeCodificado { get; set; }
        public string MensajeDecodificado { get; set; }
        public int N { get; set; }

        public void OnGet()
        {
        }

        public void OnPostEncode(string mensaje, int n)
        {
            MensajeOriginal = mensaje;
            N = n;
            MensajeCodificado = CifradoCesar(mensaje, n);
        }

        public void OnPostDecode(string mensaje, int n)
        {
            MensajeCodificado = mensaje;
            N = n;
            MensajeDecodificado = CifradoCesar(mensaje, -n);
        }

        private static string CifradoCesar(string mensaje, int n)
        {
            StringBuilder resultado = new StringBuilder();
            n = n % 26;

            foreach (char c in mensaje.ToUpper())
            {
                if (char.IsLetter(c))
                {
                    char posicion = (char)(c + n);
                    if (n > 0 && posicion > 'Z')
                    {
                        posicion = (char)(posicion - 26);
                    }
                    else if (n < 0 && posicion < 'A')
                    {
                        posicion = (char)(posicion + 26);
                    }
                    resultado.Append(posicion);
                }
                else
                {
                    resultado.Append(c);
                }
            }
            return resultado.ToString();
        }
    }
}
