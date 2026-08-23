abstract class Vehiculo
{
    protected string placa;
    protected string color;
    protected double precio;
    protected string marca;

    public Vehiculo(string placa, string color, double precio, string marca)
    {
        this.placa = placa;
        this.color = color;
        this.precio = precio;
        this.marca = marca;
    }

    public double GetPrecio()
    {
        return precio;
    
    }

    public virtual string MostrarInfo()
    {
        return $"Placa: {placa}\n" +
               $"Color: {color}\n" +
               $"Precio: {precio:C}\n" +
               $"Marca: {marca}\n";
    }

    public void EnviarReparacion()
    {
        Console.WriteLine($"El vehículo con placa {placa} ha sido enviado a reparación.");
    }
}

class Carro : Vehiculo
{
    protected int cantidadPuertas = 4;
    public Carro(string placa, string color, double precio, string marca)
        : base(placa, color, precio, marca)
    {
    }

    public override string MostrarInfo()
    {
        string infoBase = base.MostrarInfo();
        string infoPropia = $"Cantidad de puertas: {cantidadPuertas}\n";

        return infoBase + infoPropia;
    }
}

class Moto : Vehiculo
{
      protected int cantidadLlantas = 2;

      public Moto(string placa, string color, double precio, string marca)
          : base(placa, color, precio, marca)
      {
      }

        public override string MostrarInfo()
        {
            string infoBase = base.MostrarInfo();
            string infoPropia = $"Cantidad de llantas: {cantidadLlantas}\n";

            return infoBase + infoPropia;
        }
 }