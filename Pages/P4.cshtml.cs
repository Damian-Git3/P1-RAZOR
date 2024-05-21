using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Practica1.Pages
{
    public class P4Model : PageModel
    {
        public List<int> NumerosAleatorios { get; private set; }
        public int Sum { get; private set; }
        public double Promedio { get; private set; }
        public List<int> Moda { get; private set; }
        public double Mediana { get; private set; }

        public void OnGet()
        {
            GenerarNumerosAleatorios();
            Calcular();
        }

        private void GenerarNumerosAleatorios()
        {
            Random rand = new Random();
            NumerosAleatorios = new List<int>();
            for (int i = 0; i < 20; i++)
            {
                NumerosAleatorios.Add(rand.Next(0, 101));
            }
        }

        private void Calcular()
        {
            Sum = NumerosAleatorios.Sum();
            Promedio = NumerosAleatorios.Average();
            Moda = EncontrarModa(NumerosAleatorios);
            Mediana = EncontrarMediana(NumerosAleatorios);
        }

        private List<int> EncontrarModa(List<int> numeros)
        {
            var numberCounts = numeros.GroupBy(n => n)
                                      .Select(g => new { Number = g.Key, Count = g.Count() })
                                      .OrderByDescending(g => g.Count)
                                      .ToList();

            int maxCount = numberCounts.First().Count;
            return numberCounts.Where(g => g.Count == maxCount)
                               .Select(g => g.Number)
                               .ToList();
        }

        private double EncontrarMediana(List<int> numeros)
        {
            var numeroOrdenados = numeros.OrderBy(n => n).ToList();
            int count = numeroOrdenados.Count;
            if (count % 2 == 0)
            {
                return (numeroOrdenados[count / 2 - 1] + numeroOrdenados[count / 2]) / 2.0;
            }
            else
            {
                return numeroOrdenados[count / 2];
            }
        }
    }
}
