using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Practica1.Pages
{
    public class P3Model : PageModel
    {
        public double ResultMethod1 { get; private set; }
        public double ResultMethod2 { get; private set; }
        public double A { get; set; }
        public double B { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public int N { get; set; }
        public void OnGet()
        {
        }

        public void OnPost(double a, double b, double x, double y, int n)
        {
            A = a;
            B = b;
            X = x;
            Y = y;
            N = n;
            ResultMethod1 = CalculateBinomialExpressionMethod1(A, B, X, Y, N);
            ResultMethod2 = CalculateBinomialExpressionMethod2(A, B, X, Y, N);
        }

        private double CalculateBinomialExpressionMethod1(double a, double b, double x, double y, int n)
        {
            double result = 0;
            for (int k = 0; k <= n; k++)
            {
                result += BinomialCoefficient(n, k) * Math.Pow(a * x, n - k) * Math.Pow(b * y, k);
            }
            return result;
        }

        private double CalculateBinomialExpressionMethod2(double a, double b, double x, double y, int n)
        {
            // Utilizando la misma fórmula para ambos métodos en este caso.
            return CalculateBinomialExpressionMethod1(a, b, x, y, n);
        }

        private int BinomialCoefficient(int n, int k)
        {
            int result = 1;
            for (int i = 1; i <= k; i++)
            {
                result = result * (n - (k - i)) / i;
            }
            return result;
        }
    }
}
