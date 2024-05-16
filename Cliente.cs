class Cliente {
    public int DNI {get;set;}
    public string Apellido {get;set;}
    public string Nombre {get;set;}
    public DateTime FechaInscripcion {get;set;} 
    public int TipoEntrada {get;set;}
    public int Cantidad {get;set;}

    public Cliente(){}

    public Cliente(int dni, string apellido, string nombre, DateTime fechainscripcion, int tipoentrada, int cantidad)
    {
        DNI = dni;
        Apellido = apellido;
        Nombre = nombre;
        FechaInscripcion = fechainscripcion;
        TipoEntrada = tipoentrada;
        Cantidad = cantidad;
    }
}

