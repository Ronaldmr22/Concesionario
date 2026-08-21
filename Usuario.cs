using System;
using System.Collections.Generic;

class Usuario
{
    private string nombre;
    private string cedula;
    private int telefono;

    public Usuario(string nombre, string cedula, int telefono)
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

class Cliente : Usuario
{
    private List<string> historialCompra;
    private double presupuesto;
    private bool licencia;
    private List<Vehiculo> vehiculosComprados;

    public Cliente(string nombre, string cedula, int telefono, double presupuesto, bool licencia)
        : base(nombre, cedula, telefono)
    {
        this.presupuesto = presupuesto;
        this.licencia = licencia;
        this.historialCompra = new List<string>();
        this.vehiculosComprados = new List<Vehiculo>();
    }

    public void ComprarVehiculo(Vehiculo vehiculo)
    {
        if (licencia == false)
        {
            Console.WriteLine("No puedes comprar un vehículo sin tener licencia");
            return;
        }

        double precio = vehiculo.GetPrecio();

        if (presupuesto < precio)
        {
            Console.WriteLine("El precio del vehículo es mayor al presupuesto, no puedes comprarlo");
            return;
        }

        presupuesto -= precio;
        vehiculosComprados.Add(vehiculo);
        historialCompra.Add($"Factura por {precio}");

        Console.WriteLine("Compra realizada con éxito.");
    }

    public override string MostrarInfo()
    {
        string infoBase = base.MostrarInfo();
        string infoPropia = $"Presupuesto: {presupuesto}\n" +
                             $"Licencia: {licencia}\n" +
                             $"Cantidad de vehículos comprados: {vehiculosComprados.Count}\n";

        foreach (Vehiculo v in vehiculosComprados)
        {
            infoPropia += "-- Vehículo --\n" + v.MostrarInfo();
        }

        return infoBase + infoPropia;
    }
}