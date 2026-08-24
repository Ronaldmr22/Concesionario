using System;
using System.Collections.Generic;

internal class Program
{
    static void Main(string[] args)
    {    

        Concesionario concesionario = new Concesionario("A TODO GAS");
        concesionario.CrearCliente("Ronald", "120050512", 71318181, 1000, true);
        concesionario.CrearCliente("Fariathna", "119800557", 64603653, 2000, false);
        concesionario.CrearCliente("A", "123", 123,3000, true);
        concesionario.CrearCliente("B", "456", 456,4000, true);
        concesionario.CrearCliente("C", "789", 789,5000, false);

        concesionario.CrearVendedor("Sonia", "156932", 693524, "Manager", 1200);

        concesionario.CrearVehiculo("combustible", "PLC-001", "Rojo", 800, "Toyota");
        concesionario.CrearVehiculo("combustible", "PLC-002", "Negro", 1500, "Honda");
        concesionario.CrearVehiculo("electrico", "PLC-003", "Blanco", 2500, "Tesla");
        concesionario.CrearVehiculo("electrico", "PLC-004", "Gris", 2200, "Nissan");
        concesionario.CrearVehiculo("moto", "MOT-001", "Azul", 500, "Yamaha");
        concesionario.CrearVehiculo("moto", "MOT-002", "Blanco", 900, "Suzuki");

        List<string> nombresClientes = concesionario.ObtenerNombresClientes();
        List<string> nombresVendedores = concesionario.ObtenerNombresVendedores();
        


        bool funcionando = true;
        Console.WriteLine("--BIENVENIDO AL CONCESIONARIO A TODO GAS--");
        Console.WriteLine("--Ingresa tu nombre--");
        string nombre = Console.ReadLine()!;
        while (funcionando){
            if (nombresClientes.Contains(nombre))
            {
                Cliente cliente = concesionario.BuscarCliente(nombre)!;

                Console.WriteLine(
                    $"Hola {nombre}, Ingresa alguna opción\n" +
                    "1. Comprar carro\n" +
                    "2. Comprar moto\n" +
                    "3. Enviar a reparación\n" +
                    "4. Usar Carro\n" +
                    "5. Usar Moto\n" +
                    "6. Solicitar presupuesto\n" +
                    "7. Salir"
                );
                byte seleccion = byte.Parse(Console.ReadLine()!);

                switch (seleccion)
                {
                    case 1:
                        concesionario.ComprarVehiculo(cliente, "carro");
                        break;
                    case 2:
                        concesionario.ComprarVehiculo(cliente, "moto");
                        break;
                    case 3:
                        Console.WriteLine("Ingresa la placa del vehículo a reparar:");
                        string placaReparar = Console.ReadLine()!;
                        concesionario.EnviarReparacion(placaReparar);
                        break;
                    case 4:
                        concesionario.UsarVehiculo(cliente, "carro");
                        break;
                    case 5:
                        concesionario.UsarVehiculo(cliente, "moto");
                        break;
                    case 6:
                        concesionario.SolicitarPresupuesto(cliente);
                        break;
                    case 7:
                        funcionando = false;
                        break;



                    default:
                        Console.WriteLine("Opción inválida");
                        break;

                }

            }
            else if (nombresVendedores.Contains(nombre))
            {
                Vendedor vendedor = concesionario.BuscarVendedor(nombre)!;

                Console.WriteLine(
                    $"Hola {nombre}, Ingresa alguna opción\n" +
                    "1. Comprar carro\n" +
                    "2. Comprar moto\n" +
                    "3. Enviar a reparación\n" +
                    "4. Salir"
                );
                byte seleccion = byte.Parse(Console.ReadLine()!);

                switch (seleccion)
                {
                    case 1:
                        concesionario.RegistrarVentaVendedor(vendedor, "carro");
                        break;
                    case 2:
                        concesionario.RegistrarVentaVendedor(vendedor, "moto");
                        break;
                    case 3:
                        Console.WriteLine("Ingresa la placa del vehículo a reparar:");
                        string placaReparar = Console.ReadLine()!;
                        concesionario.EnviarReparacion(placaReparar);
                        break;
                    case 4:
                        funcionando = false;
                        break;



                    default:
                        Console.WriteLine("Opción inválida");
                        break;
                }
            }
            else
            {
                Console.WriteLine("No encontrado");
                continue;
            }

        }
    }
}