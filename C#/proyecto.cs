using System;
using System.IO;

class Program
{
    static void Main()
    {
        Console.WriteLine("Área y Perímetro de un Rectángulo");

        Console.Write("Ingrese la medida de la base del rectángulo: ");
        double ancho = Convert.ToDouble(Console.ReadLine());

        Console.Write("Ingrese la altura del rectángulo: ");
        double altura = Convert.ToDouble(Console.ReadLine());

        Rectangulo rectangulo = new Rectangulo(ancho, altura);

        // Guardar los datos en un archivo
        GuardarRectanguloEnArchivo("rectangulo.txt", rectangulo);

        // Recuperar los datos desde el archivo
        Rectangulo rectanguloRecuperado = ObtenerRectanguloDesdeArchivo("rectangulo.txt");

        Console.WriteLine("Área del rectángulo: " + rectanguloRecuperado.Area());
        Console.WriteLine("Perímetro del rectángulo: " + rectanguloRecuperado.Perimetro());
    }

    static void GuardarRectanguloEnArchivo(string archivo, Rectangulo rectangulo)
    {
        // Escribir los datos del rectángulo en el archivo
        using (StreamWriter writer = new StreamWriter(archivo))
        {
            writer.WriteLine(rectangulo.Ancho);
            writer.WriteLine(rectangulo.Altura);
        }
    }

    static Rectangulo ObtenerRectanguloDesdeArchivo(string archivo)
    {
        // Leer los datos del rectángulo desde el archivo
        double ancho, altura;
        using (StreamReader reader = new StreamReader(archivo))
        {
            ancho = Convert.ToDouble(reader.ReadLine());
            altura = Convert.ToDouble(reader.ReadLine());
        }

        return new Rectangulo(ancho, altura);
    }
}

class Rectangulo
{
    public double Ancho { get; set; }
    public double Altura { get; set; }

    public Rectangulo(double ancho, double altura)
    {
        Ancho = ancho;
        Altura = altura;
    }

    public double Area()
    {
        return Ancho * Altura;
    }

    public double Perimetro()
    {
        return 2 * (Ancho + Altura);
    }
}