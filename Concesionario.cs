class Concesionario
{
    private string nombre;
    private List<Cliente> clientes;
    private List<Vendedor> vendedores;

    public Concesionario(string nombre){
        this.nombre = nombre;
        clientes = new List<Cliente>();
        vendedores = new List<Vendedor>();

    }

    public void CrearVehiculo(string nombre){


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
    
}