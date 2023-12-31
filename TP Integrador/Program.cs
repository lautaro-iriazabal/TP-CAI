﻿// Contiene la lógica principal
// Por ejemplo: pedir el input del usuario
// Realiza las validaciones de integridad de datos (las validaciones generales)
// Estas validaciones pueden estar en una carpeta aparte como en el ejemplo de Agenda
// Llama al método crearUsuario de la clase Usuario de la capa de Negocio
// Solo ve la capa de Negocio, no la de Modelo
using System;
using System.ComponentModel;
using Negocio;
using Utils;

namespace TPIntegrador 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool continuar = true;

            string menu = "1) Agregar usuario \nX) Salir";

            Console.WriteLine("Bienvenido. Elija una opción.");

            do 
            {
                Console.WriteLine(menu);
                
                try
                {
                    string opcionElegida = Console.ReadLine();

                    if (opcionElegida.ToUpper() == "X")
                    {
                        // Si elige X, termina la ejecución
                        continuar = false;
                        continue;
                    }

                    switch (opcionElegida)
                    {
                        case "1":
                            // Si elige 1, llama al método agregarUsuario
                            AgregarUsuario();
                            break;
                        default:
                            Console.WriteLine("Opción inválida.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error durante la ejecución del comando. Por favor intente nuevamente. Mensaje: " + ex.Message);
                }
                Console.WriteLine("Ingrese una tecla para continuar.");

                Console.ReadKey();
                Console.Clear();
            } 
            while (continuar);
            Console.WriteLine("Gracias por usar la app.");
        }

        private static void AgregarUsuario()
        {
            bool usuarioCreado = false;
            do
            {
                // Pedir los atributos que necesita el usuario para ser creado
                string nombre = ConsolaUtils.ValidarNombre("Ingrese el nombre");
                string apellido = ConsolaUtils.ValidarNombre("Ingrese el apellido");
                string direccion = ConsolaUtils.PedirString("Ingrese la dirección");
                string telefono = ConsolaUtils.PedirString("Ingrese el número de teléfono");
                // string emaiil = ConsolaUtils.validarEmail("Ingrese el email");
                DateTime fechaNacimiento = ConsolaUtils.ValidarFechaNacimiento("Ingrese la fecha de nacimiento");
                string usuario = ConsolaUtils.PedirString("Ingrese el nombre de usuario");
                int host = ConsolaUtils.PedirInt("Ingrese el número de host");
                int dni = ConsolaUtils.ValidarDni("Ingrese el DNI");
                // una vez solicitados los atributos, llamar al metodo CrearUsuario de la capa de negocio
                // Si el usuario se creo con exito, usuarioCreado = true
                usuarioCreado = true;

             
            } while (!usuarioCreado);
            
        }
    }
}
