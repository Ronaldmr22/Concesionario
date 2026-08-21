class Vehiculo
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
}