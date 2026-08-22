using System;

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

        List<string> nombresClientes = concesionario.ObtenerNombresClientes();
        List<string> nombresVendedores = concesionario.ObtenerNombresVendedores();
        

        
        bool funcionando = true;
        Console.WriteLine("--BIENVENIDO AL CONCESIONARIO A TODO GAS--");
        Console.WriteLine("--Ingresa tu nombre--");
        string nombre = Console.ReadLine();
        while (funcionando){
            if (nombresClientes.Contains(nombre))
            {
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
                byte seleccion = byte.Parse(Console.ReadLine());

                switch (seleccion)
                {
                    case 1:
                        Console.WriteLine("Opción 1");
                        break;
                    case 2:
                        Console.WriteLine("Opción 2");
                        break;
                    case 3:
                        Console.WriteLine("Opción 3");
                        break;
                    case 4:
                        Console.WriteLine("Opción 4");
                        break;
                    case 5:
                        Console.WriteLine("Opción 5");
                        break;
                    case 6:
                        Console.WriteLine("Opción 6");
                        break;
                    case 7:
                        funcionando = false;
                        break;



                    default:
                        Console.WriteLine("Opción inválida");
                        break;

                }

            }
            if (nombresVendedores.Contains(nombre))
            {
                Console.WriteLine(
                    $"Hola {nombre}, Ingresa alguna opción\n" +
                    "1. Comprar carro\n" +
                    "2. Comprar moto\n" +
                    "3. Enviar a reparación\n" +
                    "4. Salir"
                );
                byte seleccion = byte.Parse(Console.ReadLine());

                switch (seleccion)
                {
                    case 1:
                        Console.WriteLine("Opción 1");
                        break;
                    case 2:
                        Console.WriteLine("Opción 2");
                        break;
                    case 3:
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