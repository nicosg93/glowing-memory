using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1
{
    class Program
    {
        static void Main(string[] args)
        {
            int x1=0, x2=0, x3=0, y1=0, y2=0, y3=0;
            double resultado = 0;
            Console.WriteLine("Ingrese primer valor");
            Console.WriteLine("Ingrese valor en x");
            x1=ingresarNumeroEn(x1);
            Console.WriteLine("Ingrese valor en y");
            y1=ingresarNumeroEn(y1);
            Console.Clear();
            Console.WriteLine("Ingrese segundo valor");
            Console.WriteLine("Ingrese valor en x");
            x2=ingresarNumeroEn(x2);
            Console.WriteLine("Ingrese valor en y");
            y2=ingresarNumeroEn(y2);
            Console.Clear();
            Console.WriteLine("Ingrese tercer valor");
            Console.WriteLine("Ingrese valor en x");
            x3=ingresarNumeroEn(x3);
            Console.WriteLine("Ingrese valor en y");
            y3=ingresarNumeroEn(y3);
            Console.Clear();

            resultado += Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));
            resultado += Math.Sqrt(Math.Pow(x1 - x3, 2) + Math.Pow(y1 - y3, 2));
            resultado += Math.Sqrt(Math.Pow(x2 - x3, 2) + Math.Pow(y2 - y3, 2));

            Console.WriteLine("El promedio distancia de los 3 puntos es de \t" + resultado / 3);
            Console.WriteLine();
            Console.WriteLine("Ingrese una tecla para finalizar");
            Console.ReadKey();
        }

        private static int ingresarNumeroEn(int numero)
        {
            bool esEntero;
            string linea;
            linea = Console.ReadLine();
            esEntero = Int32.TryParse(linea, out numero);
            while (!esEntero)
            {
                Console.WriteLine("El dato ingresado no es un entero intente nuevamente");
                linea = Console.ReadLine();
                esEntero = Int32.TryParse(linea, out numero);
                if (esEntero)
                {
                    return int.Parse(linea);
                }
            }
            return int.Parse(linea);
        }
    }
}
