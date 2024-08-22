using System;

namespace GestorContrasenias
{
    class Program
    {
        static List<Usuario> ListaUsuarios = new List<Usuario>();
        static bool comprobacion;
        static void Main(string[] args)
        {
            try{
                do{
                    Console.Clear();
                    CargarFicheroUsuarios();
                    comprobacion = false;
                    Console.WriteLine("▒▒▒▒▒▒▒▒▒▒▒▄▄▄▄░▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
                    Console.WriteLine("▒▒▒▒▒▒▒▒▒▄██████▒▒▒▒▒▄▄▄█▄▒▒▒▒▒▒▒▒▒▒");
                    Console.WriteLine("▒▒▒▒▒▒▒▄██▀░░▀██▄▒▒▒▒████████▄▒▒▒▒▒▒");
                    Console.WriteLine("▒▒▒▒▒▒███░░░░░░██▒▒▒▒▒▒█▀▀▀▀▀██▄▄▒▒▒");
                    Console.WriteLine("▒▒▒▒▒▄██▌░░░░░░░██▒▒▒▒▐▌▒▒▒▒▒▒▒▒▀█▄▒");
                    Console.WriteLine("▒▒▒▒▒███░░▐█░█▌░██▒▒▒▒█▌▒▒▒▒▒▒▒▒▒▒▀▌");
                    Console.WriteLine("▒▒▒▒████░▐█▌░▐█▌██▒▒▒██▒▒▒▒▒▒▒▒▒▒▒▒▒");
                    Console.WriteLine("▒▒▒▐████░▐░░░░░▌██▒▒▒█▌▒▒▒▒▒▒▒▒▒▒▒▒▒");
                    Console.WriteLine("▒▒▒▒████░░░▄█░░░██▒▒▐█▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
                    Console.WriteLine("▒▒▒▒████░░░██░░██▌▒▒█▌▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
                    Console.WriteLine("▒▒▒▒████▌░▐█░░███▒▒▒█▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
                    Console.WriteLine("▒▒▒▒▐████░░▌░███▒▒▒██▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
                    Console.WriteLine("▒▒▒▒▒████░░░███▒▒▒▒█▌▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
                    Console.WriteLine("▒▒▒██████▌░████▒▒▒██▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
                    Console.WriteLine("▒▐████████████▒▒███▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
                    Console.WriteLine("▒█████████████▄████▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
                    Console.WriteLine("██████████████████▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
                    Console.WriteLine("██████████████████▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
                    Console.WriteLine("█████████████████▀▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
                    Console.WriteLine("█████████████████▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
                    Console.WriteLine("████████████████▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
                    Console.WriteLine("████████████████▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
                    Console.WriteLine("\n\nBienvenido a su gestor de contraseñas en termianl");
                    Console.WriteLine("Por favor, ingrese su nombre de usuario");
                    string nombre = Console.ReadLine();
                    Console.WriteLine("Introduzca una contraseña: ");
                    string contrasenia = ReadPassword();

                    foreach(Usuario usuario in ListaUsuarios){

                        if(nombre == usuario.Nombre && contrasenia == usuario.Contrasenia){
                            comprobacion = true;

                        }else{
                            comprobacion = false;
                        }

                    }

                    if(comprobacion == false){
                        Console.WriteLine("Usuario introducido incorrecto, pulsa una tecla para continuar");
                        Console.ReadKey();

                    }else{
                        Gestor gestor = new Gestor(nombre, contrasenia, ListaUsuarios);
                        gestor.Menu();
                        GuardarFicheroUsuarios();
                    }
                }while(comprobacion != true);

            }catch(Exception ex){

                Console.WriteLine(ex.Message);
                Console.WriteLine("Ha ocurrido un error, pulse una tecla para continuar");
                Console.ReadKey();
            }
        }

        static void CargarFicheroUsuarios(){
            FileStream fs = new FileStream("Usuarios",FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            while(sr.Peek() != -1){
                string linea = sr.ReadLine();
                string[] lineaSeparada = linea.Split('|');
                Usuario usuario = new Usuario(lineaSeparada[0], lineaSeparada[1]);
                ListaUsuarios.Add(usuario);
            }
            sr.Close();
        }

        static void GuardarFicheroUsuarios(){
            FileStream fs = new FileStream("Usuarios",FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            foreach(Usuario usuario in ListaUsuarios){
                sw.WriteLine($"{usuario.Nombre}|{usuario.Contrasenia}");
            }
            sw.Close();

        }
        static string ReadPassword()
        {
            string password = "";
            ConsoleKey key;

            do
            {
                var keyInfo = Console.ReadKey(intercept: true);  // Captura la tecla, pero no la muestra
                key = keyInfo.Key;

                if (key == ConsoleKey.Backspace && password.Length > 0)
                {
                    // Si se presiona Backspace, elimina el último carácter
                    password = password.Substring(0, password.Length - 1);
                    Console.Write("\b \b");  // Borra el carácter de la consola
                }
                else if (!char.IsControl(keyInfo.KeyChar))
                {
                    // Agrega el carácter a la contraseña y muestra un asterisco
                    password += keyInfo.KeyChar;
                    Console.Write("*");
                }
            } while (key != ConsoleKey.Enter);  // Termina cuando se presiona Enter

            Console.WriteLine();  // Para pasar a la siguiente línea
            return password;
        }
    }
}
