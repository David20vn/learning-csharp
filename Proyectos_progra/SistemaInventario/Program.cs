
using System.Runtime.InteropServices.Marshalling;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Reflection.Metadata.Ecma335;
using System.Text;

class Program
{

    static void Main(string[] args)
    {

        List<Producto> productos = new List<Producto>();
        Console.WriteLine("Actualizado");

        Operaciones(productos);

    }

    static void MostrarMenu()
    {

        Console.WriteLine("\n\n======Menu======\n");
        Console.WriteLine("1). Registrar producto");
        Console.WriteLine("2). Mostrar productos.");
        Console.WriteLine("3). Calcular total del inventario.");
        Console.WriteLine("4). Salir\n");
    }

    static void Operaciones(List<Producto> productos)
    {
        bool continuar = true;
        int opcion;

        while ( continuar )
        {
            MostrarMenu();
            Console.Write("Digite su opción: ");
            int.TryParse(Console.ReadLine(), out opcion);

            switch (opcion)
            {
                case 1:
                    RegistrarProducto( productos );
                    break;
                case 2:
                    MostrarProductos( productos );
                    break;
                case 3:
                    CalculoTotal( productos );
                    break;
                case 4:
                    continuar = false;
                    break;
            }
        }
    }

    static void RegistrarProducto(List<Producto> productos ) {

        Producto producto = new Producto();
        Categoria[] categorias = { Categoria.Manzana, Categoria.Pera, Categoria.Sandia, Categoria.Banano, Categoria.Fresa };

        producto.id = ObtenerInt("Id: ");
        producto.nombre = ObtenerString( "Nombre: ");
        producto.precio = ObtenerDecimal("Precio: ");
        producto.stock = ObtenerShort("Stock: ");

        int IndiceCategoria = ObtenerInt( $"Categoria: \nOpciones de categoria: \n1) {categorias[0]}.\n2) {categorias[1]}.\n3) {categorias[2]}.\n4) {categorias[3]}.\n5) {categorias[4]}.\nopcion: ", 1, 5 );
        producto.categoria = categorias[--IndiceCategoria];

        producto.activo = ObtenerBool("Activo: ");
        producto.codigoInterno = ObtenerChar("Codigo Interno: ");
        producto.peso = ObtenerFloat("Peso: ");

        productos.Add(producto);
         
    }

    static string ObtenerString ( string mensaje ){
        string nombre = string.Empty;
        do {
            Console.Write( mensaje );
            nombre = Console.ReadLine().Trim();
            Console.Write( nombre == string.Empty ? "El string no puede ser vacio.\n" : "" );
        } while ( nombre == string.Empty);

        return nombre;
    }

    static void MostrarProductos( List<Producto> productos ) {

        if ( productos.Count == 0 ){
            Console.WriteLine("No hay productos en la lista.");
            return;
        }

        StringBuilder sb = new StringBuilder();
        
        foreach( Producto producto in productos ) {
            sb.Append($"Id: {producto.id} - Nombre: {producto.nombre} -");
            sb.AppendFormat ("Precio: {0:C}", producto.precio );
            sb.AppendLine( $" - Stock: {producto.stock} - categoria: {producto.categoria} - Activo: {producto.activo} - Codigo interno: {producto.codigoInterno} - Peso: {producto.peso}.");
        }
       Console.WriteLine( sb.ToString());

    }

    static void CalculoTotal( List<Producto> productos ){

        decimal total = 0;

        foreach( Producto producto in productos ){
            total += producto.precio * producto.stock;
        }

        Console.WriteLine ( $"Total: {total:C}");
    }

    static int ObtenerInt(string mensaje, int? minimo = null, int? maximo = null){
        int valor;

        while (true) {
            Console.Write(mensaje);

            if (!int.TryParse(Console.ReadLine(), out valor)){
                Console.WriteLine("Entrada inválida.\n");
                continue;
            }

            if (minimo.HasValue && valor < minimo.Value) {
                Console.WriteLine($"El número debe ser mayor o igual a {minimo}.\n");
                continue;
            }

            if (maximo.HasValue && valor > maximo.Value) {
                Console.WriteLine($"El número debe ser menor o igual a {maximo}.\n");
                continue;
            }

            return valor;

        }
    }

    static decimal ObtenerDecimal(string mensaje) {
        decimal valor;
        while (true) {
            Console.Write(mensaje);
            if (decimal.TryParse(Console.ReadLine(), out valor))
                return valor;

            Console.WriteLine("Entrada inválida. Intente nuevamente.\n");
        }   
    }

    static short ObtenerShort(string mensaje)  {
        short valor;
        while (true) {
            Console.Write(mensaje);
            if (short.TryParse(Console.ReadLine(), out valor))
                return valor;

            Console.WriteLine("Entrada inválida. Intente nuevamente.\n");
        }
    }

    static float ObtenerFloat(string mensaje){
        float valor;
        while (true) {
            Console.Write(mensaje);
            if (float.TryParse(Console.ReadLine(), out valor))
                return valor;

            Console.WriteLine("Entrada inválida. Intente nuevamente.\n");
        }
    }

    static bool ObtenerBool(string mensaje) {
        while (true){
            Console.Write(mensaje);
            string? entrada = Console.ReadLine();

            if (bool.TryParse(entrada, out bool valor))
                return valor;

            if (entrada == "1") return true;
            if (entrada == "0") return false;

            Console.WriteLine("Ingrese true/false\n");
        }
    }

    static char ObtenerChar(string mensaje) {
        while (true){
            Console.Write(mensaje);
            string? entrada = Console.ReadLine();

            if (!string.IsNullOrEmpty(entrada) && entrada.Length == 1)
                return entrada[0];

            Console.WriteLine("Ingrese un solo carácter.\n");
        }
    }

}

