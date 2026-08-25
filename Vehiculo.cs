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

    public string GetPlaca()
    {
        return placa;
    }

    public string GetMarca()
    {
        return marca;
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

    public virtual void UsarCarro()
    {
        Console.WriteLine("Usando Carro");
    }

    public override string MostrarInfo()
    {
        string infoBase = base.MostrarInfo();
        string infoPropia = $"Cantidad de puertas: {cantidadPuertas}\n";

        return infoBase + infoPropia;
    }

    
}

class CarroCombustible : Carro
{
    public CarroCombustible(string placa, string color, double precio, string marca)
        : base(placa, color, precio, marca)
    {
    }

    public override string MostrarInfo()
    {
        return base.MostrarInfo() + "Tipo de carro: Combustible\n";
    }

    public override void UsarCarro()
    {
        Console.WriteLine("Usando Carro de Combustible");
    }
}

class CarroElectrico : Carro
{
    public CarroElectrico(string placa, string color, double precio, string marca)
        : base(placa, color, precio, marca)
    {
    }

    public override string MostrarInfo()
    {
        return base.MostrarInfo() + "Tipo de carro: Eléctrico\n";
    }

    public override void UsarCarro()
    {
        Console.WriteLine("Usando Carro Eléctrico");
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