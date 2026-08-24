class Concesionario
{
    private string nombre;
    private List<Cliente> clientes;
    private List<Vendedor> vendedores;
    private List<Vehiculo> vehiculos;

    public Concesionario(string nombre){
        this.nombre = nombre;
        clientes = new List<Cliente>();
        vendedores = new List<Vendedor>();
        vehiculos = new List<Vehiculo>();

    }

    public void CrearVehiculo(string tipo, string placa, string color, double precio, string marca)
    {
        Vehiculo vehiculo;

        if (tipo.Equals("combustible", StringComparison.OrdinalIgnoreCase))
        {
            vehiculo = new CarroCombustible(placa, color, precio, marca);
        }
        else if (tipo.Equals("electrico", StringComparison.OrdinalIgnoreCase))
        {
            vehiculo = new CarroElectrico(placa, color, precio, marca);
        }
        else if (tipo.Equals("carro", StringComparison.OrdinalIgnoreCase))
        {
            vehiculo = new Carro(placa, color, precio, marca);
        }
        else if (tipo.Equals("moto", StringComparison.OrdinalIgnoreCase))
        {
            vehiculo = new Moto(placa, color, precio, marca);
        }
        else
        {
            Console.WriteLine("Tipo de vehículo inválido, debe ser 'carro', 'moto', 'combustible' o 'electrico'");
            return;
        }

        vehiculos.Add(vehiculo);
    }

    public void CrearCliente(string nombre, string cedula, int telefono, double presupuesto, bool licencia){
        Cliente cliente = new Cliente(nombre, cedula, telefono, presupuesto, licencia);
        clientes.Add(cliente);
    }

    public void CrearVendedor(string nombre, string cedula, int telefono, string puesto, double salario){
        Vendedor vendedor = new Vendedor(nombre, cedula, telefono, puesto, salario);
        vendedores.Add(vendedor);
    }

    public void MostrarClientes()
    {
        foreach (Cliente cliente in clientes)
        {
        Console.WriteLine(cliente.MostrarInfo());
        }
    }

    public List<string> ObtenerNombresClientes()
    {
        List<string> nombres = new List<string>();
        foreach (Cliente cliente in clientes)
        {
            nombres.Add(cliente.GetNombre());
        }
        return nombres;
    }
    public List<string> ObtenerNombresVendedores()
    {
        List<string> nombres = new List<string>();
        foreach (Vendedor vendedor in vendedores)
        {
            nombres.Add(vendedor.GetNombre());
        }
        return nombres;
    }

    public Cliente? BuscarCliente(string nombre)
    {
        foreach (Cliente cliente in clientes)
        {
            if (cliente.GetNombre() == nombre) return cliente;
        }
        return null;
    }

    public Vendedor? BuscarVendedor(string nombre)
    {
        foreach (Vendedor vendedor in vendedores)
        {
            if (vendedor.GetNombre() == nombre) return vendedor;
        }
        return null;
    }

    private Vehiculo? BuscarVehiculoEnCatalogo(string placa)
    {
        foreach (Vehiculo vehiculo in vehiculos)
        {
            if (vehiculo.GetPlaca() == placa) return vehiculo;
        }
        return null;
    }

    public void MostrarCatalogoVehiculos(string tipo)
    {
        List<Vehiculo> coincidencias = vehiculos.FindAll(vehiculo =>
            (tipo == "carro" && vehiculo is Carro) ||
            (tipo == "moto" && vehiculo is Moto));

        if (coincidencias.Count == 0)
        {
            Console.WriteLine($"No hay {tipo}s en el catálogo en este momento.");
            return;
        }

        foreach (Vehiculo vehiculo in coincidencias)
        {
            Console.WriteLine(vehiculo.MostrarInfo());
        }
    }

    public void ComprarVehiculo(Cliente cliente, string tipo)
    {
        MostrarCatalogoVehiculos(tipo);
        Console.WriteLine("Ingresa la placa del vehículo que deseas comprar:");
        string placa = Console.ReadLine() ?? "";

        Vehiculo? vehiculo = BuscarVehiculoEnCatalogo(placa);
        if (vehiculo == null)
        {
            Console.WriteLine("No existe un vehículo con esa placa en el catálogo.");
            return;
        }

        cliente.ComprarVehiculo(vehiculo);
    }

    public void RegistrarVentaVendedor(Vendedor vendedor, string tipo)
    {
        Console.WriteLine("¿A qué cliente le vendiste el vehículo? Ingresa su nombre:");
        string nombreCliente = Console.ReadLine() ?? "";
        Cliente? cliente = BuscarCliente(nombreCliente);
        if (cliente == null)
        {
            Console.WriteLine("Cliente no encontrado.");
            return;
        }

        MostrarCatalogoVehiculos(tipo);
        Console.WriteLine("Ingresa la placa del vehículo vendido:");
        string placa = Console.ReadLine() ?? "";

        Vehiculo? vehiculo = BuscarVehiculoEnCatalogo(placa);
        if (vehiculo == null)
        {
            Console.WriteLine("No existe un vehículo con esa placa en el catálogo.");
            return;
        }

        bool ventaExitosa = cliente.ComprarVehiculo(vehiculo);
        if (ventaExitosa)
        {
            vendedor.RegistrarVenta($"Vendió un {vehiculo.GetMarca()} (placa {vehiculo.GetPlaca()}) a {cliente.GetNombre()}");
        }
    }

    public void EnviarReparacion(string placa)
    {
        foreach (Vehiculo vehiculo in vehiculos)
        {
            if (vehiculo.GetPlaca() == placa)
            {
                vehiculo.EnviarReparacion();
                return;
            }
        }
        Console.WriteLine("No se encontró un vehículo con esa placa.");
    }

    public void SolicitarPresupuesto(Cliente cliente)
    {
        Console.WriteLine($"Tu presupuesto actual es de: {cliente.GetPresupuesto():C}");
    }

    public void UsarVehiculo(Cliente cliente, string tipo)
    {
        List<Vehiculo> propios = cliente.GetVehiculosComprados()
            .FindAll(vehiculo => (tipo == "carro" && vehiculo is Carro) ||
                                  (tipo == "moto" && vehiculo is Moto));

        if (propios.Count == 0)
        {
            Console.WriteLine($"No tienes ningún {tipo} comprado todavía.");
            return;
        }

        Console.WriteLine($"Estos son tus {tipo}s:");
        foreach (Vehiculo vehiculo in propios)
        {
            Console.WriteLine(vehiculo.MostrarInfo());
        }

        Console.WriteLine("Ingresa la placa del vehículo que quieres usar:");
        string placa = Console.ReadLine() ?? "";

        Vehiculo? elegido = propios.Find(vehiculo => vehiculo.GetPlaca() == placa);
        if (elegido == null)
        {
            Console.WriteLine("Esa placa no está entre tus vehículos.");
            return;
        }

        Console.WriteLine($"Usando tu {elegido.GetMarca()}:");
        Console.WriteLine(elegido.MostrarInfo());

        if (elegido is CarroElectrico carroElectrico)
        {
            carroElectrico.UsarCarro();
        }
        else if (elegido is CarroCombustible carroCombustible)
        {
            carroCombustible.UsarCarro();
        }
    }
}