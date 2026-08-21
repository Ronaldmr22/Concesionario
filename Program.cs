using System;

internal class Program
{
    static void Main(string[] args)
    {
        Cliente usuario1= new Cliente("Fariathna","119800557",64603653,800000,true);
        Console.WriteLine (usuario1.MostrarInfo());
    }
}