using System.Collections.Generic;

static class Tiquetera
{
    
    const int ENTRADA1 = 45000;
    const int ENTRADA2 = 60000;
    const int ENTRADA3 = 30000;
    const int ENTRADA4 = 100000;
    public static Dictionary <int,Cliente>  DicClientes = new Dictionary<int, Cliente>();
    private static int UltimoIDEntrada = 0;
    public static int DevolverUltimoID()
    {
        return UltimoIDEntrada;
    }
    public static int BuscarCliente(int ID)
    {
        return ID--;
    }
    public static int AgregarCliente(Cliente cliente)
    { 
        UltimoIDEntrada++;
        DicClientes.Add(UltimoIDEntrada, cliente);
        Console.WriteLine("Cliente creado, su ID es " + DevolverUltimoID());
        return UltimoIDEntrada;
    }
    
    public static bool CambiarEntrada(int id, int tipo, int cantidad)
    {
        bool cambioentrada = false;
        
        int precioentradanuevo = 0, precioentradaactual = 0;
        
            do{  
                if (tipo == 1) precioentradaactual = ENTRADA1;
                else if (tipo == 2) precioentradaactual = ENTRADA2;
                else if (tipo == 3) precioentradaactual = ENTRADA3;
                else precioentradanuevo = ENTRADA4;

                if (DicClientes[id].TipoEntrada == 1) precioentradaactual = ENTRADA1;
                else if (DicClientes[id].TipoEntrada == 2) precioentradaactual = ENTRADA2;
                else if (DicClientes[id].TipoEntrada == 3) precioentradaactual = ENTRADA3;
                else precioentradaactual = ENTRADA4;
            }while(precioentradanuevo < precioentradaactual && tipo > 4);
            DicClientes[id].Cantidad = cantidad;
           
            
            if(id > 0)
            {
                DicClientes[id].TipoEntrada = tipo;  
                cambioentrada = true;
            }
        
        return cambioentrada;
    }
       
    public static List<int> EstadisticasTicketera()
    {
        Console.WriteLine("estadisticas ticketera");
        List<int> Valores = new List<int>();  
        Console.WriteLine(UltimoIDEntrada);
        if(UltimoIDEntrada > 0)
        {
            int totalentradas = 0, totalRec = 0;
            int cantentradas1 = 0, cantclientes1 = 0, rec1 = 0;
            int cantentradas2 = 0, cantclientes2 = 0, rec2 = 0;
            int cantentradas3 = 0, cantclientes3 = 0, rec3 = 0;
            int cantentradas4 = 0, cantclientes4 = 0, rec4 = 0;
            int por1 = 0, por2 = 0, por3 = 0, por4 = 0;

            
            // Cantidad de Clientes que compraron cada entrada.
            foreach(Cliente cl in DicClientes.Values)
            {
                totalentradas += cl.Cantidad;
                if(cl.TipoEntrada== 1) {cantclientes1++; cantentradas1+=cl.Cantidad;  }
                else if(cl.TipoEntrada == 2) {cantclientes1++; cantentradas2+=cl.Cantidad;}
                else if(cl.TipoEntrada == 3) {cantclientes1++; cantentradas3+=cl.Cantidad;}
                else {cantclientes1++; cantentradas1+=cl.Cantidad;}
            }
            por1 = (totalentradas * cantentradas1) / 100;
            por2 = (totalentradas * cantentradas2) / 100;
            por3 = (totalentradas * cantentradas3) / 100;
            por4 = (totalentradas * cantentradas4) / 100;

            rec1 = cantentradas1 * 45000;
            rec2 = cantentradas2 * 60000;
            rec3 = cantentradas3 * 30000;
            rec4 = cantentradas4 * 100000;

            totalRec = rec1 + rec2 + rec3 + rec4;
            Valores.Add(UltimoIDEntrada);
            Valores.Add(cantclientes1);
            Valores.Add(cantclientes2);
            Valores.Add(cantclientes3);
            Valores.Add(cantclientes4);
            Valores.Add(por1);
            Valores.Add(por2);
            Valores.Add(por3);
            Valores.Add(por4);
            Valores.Add(rec1);
            Valores.Add(rec2);
            Valores.Add(rec3);
            Valores.Add(rec4);
            Valores.Add(totalRec);
        }
        return Valores;
    }
    
}