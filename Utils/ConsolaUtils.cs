// Parte de la capa de Presentación
// Contiene las validaciones generales

using System.Globalization;
using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;

namespace Utils
{
    public class ConsolaUtils
    {
        public static string PedirString(string msg)
        {
            // Método para pedir un string
            Console.WriteLine(msg);
            string valor = Console.ReadLine();


            return valor;
        }

        public static int PedirInt(string msg)
        {
            // Método para pedir un int y verificar que sea un int
            int valor;
            bool esNumero;
            do
            {
                Console.WriteLine(msg);
                esNumero = int.TryParse(Console.ReadLine(), out valor);
                if (!esNumero)
                {
                    Console.WriteLine("Por favor ingrese un número.");
                }
            } while (!esNumero);
            
            return valor;
        }

        public static DateTime PedirFecha(string msg)
        {
            // Méotodo para pedir una fecha y verificar que esté en formato fecha
            DateTime valor;
            bool esFechaValida;

            do
            {
                Console.WriteLine(msg + " con el formato dd/MM/yyyy");
                esFechaValida = DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out valor);
                
                if(!esFechaValida)
                {
                    Console.WriteLine("Fecha no válida.");
                }
            } while(!esFechaValida);
            

            //Validaciones
            return valor;
        }

        public static string ValidarNombre(string msg)
        {
            string nombre;
            bool nombreValido;
            do
            {
                nombre = PedirString(msg);
                // Chequear que el nombre tenga más de 2 caracteres y solo contenga letras
                nombreValido = nombre.Length > 2 && Regex.IsMatch(nombre, @"^[a-zA-Z]+$");
                if(!nombreValido)
                {
                    Console.WriteLine("Nombre inválido");
                }
            } while(!nombreValido);

            // Convertir la primera letra a mayúscula y las demas a minúscula
            nombre = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(nombre.ToLower());

            return nombre;
        }

        public static int ValidarDni(string msg)
        {
            int dni;
            bool dniValido;
            do
            {
                dni = PedirInt(msg);
                // Verificar que el DNI tenga 8 números
                dniValido = dni.ToString().Length <= 8;
                if(!dniValido)
                {
                    Console.WriteLine("DNI inválido.");
                }
            } while(!dniValido);

            return dni;
        }

        public static DateTime ValidarFechaNacimiento(string msg)
        {
            DateTime fechaNacimiento;
            bool fechaNacimientoValido;
            do
            {
                fechaNacimiento = PedirFecha(msg);
                // Verificar que la fecha de nacimiento no sea antes del 1/1/1999 y no sea después de la fecha de hoy menos 10 años.
                DateTime fechaMinima = new DateTime(1900, 1, 1);
                DateTime fechaHoy = DateTime.Now;
                DateTime fechaMaxima = fechaHoy.AddYears(-10); // Restarle 10 años a la fecha de hoy
                fechaNacimientoValido = fechaNacimiento >= fechaMinima && fechaNacimiento < fechaMaxima;
                if(!fechaNacimientoValido)
                {
                    Console.WriteLine("Fecha de nacimiento inválida");
                }
            } while(!fechaNacimientoValido);

            return fechaNacimiento;
        }

        // Falta el método ValidarEmail
       
    }
}