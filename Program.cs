using System;

internal class Program
{
    static void Main(string[] args)
    {
        CuentaBancaria fariathna = new CuentaBancaria(1200000);
        fariathna.Depositar(5000);

        Console.WriteLine(fariathna.Retirar(120000000));
    }
}