using System;

internal class Program
{
    static void Main(string[] args)
    {    
        Cliente cliente1= new Cliente("Fariathna","119800557",64603653,8000000,true);
        //Console.WriteLine (cliente1.MostrarInfo());
        Vehiculo carro1 = new Vehiculo("EU29H","Azul",12000000,"Toyota");
        //Console.WriteLine (vehiculo1.MostrarInfo());
        Vehiculo moto1 = new Vehiculo("MTX456", "Negra", 7000000, "Yamaha");
        cliente1.ComprarVehiculo(moto1);
        Console.WriteLine (cliente1.MostrarInfo());

        
    }
}