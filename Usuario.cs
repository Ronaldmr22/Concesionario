class Usuario
{
    private string nombre;
    private string cedula;
    private int telefono;

    public Usuario (string nombre,string cedula, int telefono)
    {
        this.nombre = nombre;
        this.cedula = cedula;
        this.telefono = telefono;
    }

    public virtual string MostrarInfo() 
    {
        return $"Nombre: {nombre}\n" +
               $"Cédula: {cedula}\n" +
               $"Teléfono: {telefono}\n";
    }
}

class Cliente: Usuario
{
    private List<string> historialCompra;
    private int presupuesto;
    private bool licencia;

    public Cliente(string nombre, string cedula, int telefono, int presupuesto, bool licencia): base(nombre, cedula, telefono)
    {
    this.presupuesto = presupuesto;
    this.licencia = licencia;
    this.historialCompra = new List<string>();
    }

    public override string MostrarInfo()
    {
    string infoBase = base.MostrarInfo();
    return infoBase + $"Presupuesto:{presupuesto}\n" +
                       $"Licencia: {licencia}\n";
    }
}
 class Vendedor : Usuario
{
    private List<string> historialVentas;.
    private string puesto;
    private bool salario;
}