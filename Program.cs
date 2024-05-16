using System.Collections.Generic;
string eleccion ="";
do
{
    do
    {
        Console.WriteLine("i.   Nueva Inscripción");
        Console.WriteLine("ii.  Obtener Estadísticas del Evento");
        Console.WriteLine("iii. Buscar Cliente");
        Console.WriteLine("iv.  Cambiar entrada de un Cliente");
        Console.WriteLine("v.   Salir");
        eleccion = Console.ReadLine();
    } while(eleccion != "i" && eleccion != "ii" && eleccion != "iii" && eleccion != "iv" && eleccion != "v");


    switch(eleccion)
    { 
        case "i":
            Cliente clientenuevo = AgregarCliente();
            Tiquetera.AgregarCliente(clientenuevo);
            break;

        case "ii":
           
          
            List<int> Estadisticas = Tiquetera.EstadisticasTicketera();
            if (Estadisticas.Count==0)
            {
                Console.WriteLine("No hay clientes");
                
            }
            else
            {            
                
                Console.WriteLine("La cantidad de clientes inscriptos es de: " + Estadisticas[0]);
                Console.WriteLine("La cantidad de clientes que comparaon la entrada 1 es de: " + Estadisticas[1]);
                Console.WriteLine("La cantidad de clientes que compraron la entrada 2 es de: " + Estadisticas[2]);
                Console.WriteLine("La cantidad de clientes que compraron la entrada 3 es de: " + Estadisticas[3]);
                Console.WriteLine("La cantidad de clientes que compraron la entrada 4 es de: " + Estadisticas[4]);
                Console.WriteLine("El porcentaje de entradas tipo 1 vendidas es de: " + Estadisticas[5]);
                Console.WriteLine("El porcentaje de entradas tipo 2 vendidas es de: " + Estadisticas[6]);
                Console.WriteLine("El porcentaje de entradas tipo 3 vendidas es de: " + Estadisticas[7]);
                Console.WriteLine("El porcentaje de entradas tipo 4 vendidas es de: " + Estadisticas[8]);
                Console.WriteLine("La recaudacion total del tipo 1 es de: " + Estadisticas[9]);
                Console.WriteLine("La recaudacion total del tipo 2 es de: " + Estadisticas[10]);
                Console.WriteLine("La recaudacion total del tipo 3 es de: " + Estadisticas[11]);
                Console.WriteLine("La recaudacion total del tipo 4 es de: " + Estadisticas[12]);
                Console.WriteLine("La recaudacion total es de: " + Estadisticas[13]);
            }
        break;

        case "iii":
            
            BuscarCliente();
        break;

        case "iv":
            Console.WriteLine(CambiarEntrada());
        break;

        default:
        break;
    }
}while(eleccion != "v");

Cliente AgregarCliente()
{
    
    Cliente NuevoCliente = new Cliente();
    DateTime inscripcion = NuevoCliente.FechaInscripcion;
        do
        {
        Console.WriteLine("Ingrese el DNI: ");
        NuevoCliente.DNI = int.Parse(Console.ReadLine());
        }
        
        while(NuevoCliente.DNI < 0);

        Console.WriteLine("Ingrese el Nombre: ");

        NuevoCliente.Nombre = Console.ReadLine();

        Console.WriteLine("Ingrese el Apellido: ");

        NuevoCliente.Apellido = Console.ReadLine();

        string entradaFecha;
        do
        {
            Console.WriteLine("Ingrese la fecha de inscripcion: ");
            entradaFecha = Console.ReadLine();
        } 
        
        while(!DateTime.TryParse(entradaFecha, out inscripcion));
        
        do
        {
            Console.WriteLine("Ingrese el Tipo de entrada: ");
            NuevoCliente.TipoEntrada = int.Parse(Console.ReadLine());
        }
        while(NuevoCliente.TipoEntrada < 0 || NuevoCliente.TipoEntrada > 4);
            
        do
        {
            Console.WriteLine("Ingrese la cantidad de entradas que va a comprar: ");
            NuevoCliente.Cantidad = int.Parse(Console.ReadLine());
        }
        while(NuevoCliente.Cantidad < 0);

        return NuevoCliente;
}

string CambiarEntrada()
{
    bool cambioentrada;
    int ID = 0;
    do
    {
    Console.WriteLine("Ingrese el ID del cliente a cambiar la entrada: ");
    ID = int.Parse(Console.ReadLine());
    }while(ID < Tiquetera.DevolverUltimoID());
    
        Console.WriteLine("Ingrese el tipo de entrada nueva del cliente: ");
        Tiquetera.DicClientes[ID].TipoEntrada = int.Parse(Console.ReadLine());
    

    DateTime inscripcion = Tiquetera.DicClientes[ID].FechaInscripcion;
    string entradaFecha;
    int CantEntradas = Tiquetera.DicClientes[ID].Cantidad;
    do
    {
            Console.WriteLine("Ingrese la cantidad de entradas que va a comprar: ");
            CantEntradas = int.Parse(Console.ReadLine());
    }while(CantEntradas <= 0);

    do{
        Console.WriteLine("Ingrese la nueva fecha de inscripcion: ");
        entradaFecha = Console.ReadLine();
    }while(!DateTime.TryParse(entradaFecha, out inscripcion));
    cambioentrada = Tiquetera.CambiarEntrada(ID,Tiquetera.DicClientes[ID].TipoEntrada,CantEntradas);
    if(cambioentrada == true) return "Se cambio la entrada correctamente";
    else return "No se pudo cambiar la entrada";
}

void BuscarCliente()
{
    int IDEntrada, posicionDic = 0;
    do
    {
        Console.WriteLine("Ingrese el ID de la entrada del cliente");
        IDEntrada = int.Parse(Console.ReadLine()); 
    }while(IDEntrada > Tiquetera.DevolverUltimoID());
    posicionDic = Tiquetera.BuscarCliente(IDEntrada);
        Console.WriteLine("Nombre: " + Tiquetera.DicClientes[posicionDic].Nombre);
        Console.WriteLine("Apellido: " + Tiquetera.DicClientes[posicionDic].Apellido);
        Console.WriteLine("DNI: " + Tiquetera.DicClientes[posicionDic].DNI);
        Console.WriteLine("Fecha de inscripcion: " + Tiquetera.DicClientes[posicionDic].FechaInscripcion);
        Console.WriteLine("Tipo de entrada: " + Tiquetera.DicClientes[posicionDic].TipoEntrada);
        Console.WriteLine("Cantidad de entradas: " + Tiquetera.DicClientes[posicionDic].Cantidad);

}