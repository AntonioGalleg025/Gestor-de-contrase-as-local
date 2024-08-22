public class Gestor
{
    public string Nombre {get; set;}
    public string Contrasenia {get; set;}
    public List<Usuario> ListaUsuarios = new List<Usuario>();

    public int Id = 0;

    public List<Contrasenias> ListaContrasenias = new List<Contrasenias>();
    public Gestor()
    {
        
    }

    public Gestor(string nombre, string contrasenia, List<Usuario> listaUsuarios){
        Nombre = nombre;
        Contrasenia = contrasenia;
        ListaUsuarios = listaUsuarios;
    }

    public void Menu(){
        try{
            CargarFicheroContrasenias();
            int opcion = 0;
            Console.WriteLine("Selecciona una de las opciones del menu: ");
            System.Threading.Thread.Sleep(3000);
            do{
                Console.Clear();
                Console.WriteLine("────────────────████");
                Console.WriteLine("───────────────█░░███");
                Console.WriteLine("───────────────█░░████");
                Console.WriteLine("────────────────███▒██─────████████");
                Console.WriteLine("──────████████─────█▒█──████▒▒▒▒▒▒████");
                Console.WriteLine("────███▒▒▒▒▒▒████████████░░████▒▒▒▒▒███");
                Console.WriteLine("──██▒▒▒▒░▒▒████░░██░░░░██░░░░░█▒▒▒▒▒▒▒███");
                Console.WriteLine("─██▒▒░░░░▒██░░░░░█▒░░░░░██▒░░░░░░░▒▒▒▒▒▒█");
                Console.WriteLine("██▒░░░░░▒░░░░░░░░░▒░░░░░░░▒▒░░░░░░░▒▒▒▒▒██");
                Console.WriteLine("█░░░░░░▒░░░██░░░░░░░░░░░░░██░░░░░░░░▒▒▒▒▒█");
                Console.WriteLine("█░░░░░░░░█▒▒███░░░░░░░░░█▒▒███░░░░░░░▒▒▒▒█");
                Console.WriteLine("█░░░░░░░████████░░░░░░░████████░░░░░░▒▒▒▒█");
                Console.WriteLine("█░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▒▒█");
                Console.WriteLine("██░░░█░░░░░░░░░░░░░░░░░░░░░░░░░░░░░█░▒▒▒▒█");
                Console.WriteLine("─█░░░░██░█░░░░░░░░░░░░░░░░░░░░░░░███▒▒▒▒▒█");
                Console.WriteLine("─█▒▒░░░░█████░░░█░░░░██░░░██░░████░▒▒▒▒▒▒█");
                Console.WriteLine("─██▒▒░░░░░█████████████████████░░░▒▒▒▒▒▒██");
                Console.WriteLine("──██▒▒▒▒░░░░░██░░░███░░░██░░░█░░░▒▒▒▒▒▒██");
                Console.WriteLine("───███▒▒▒░░░░░░░░░░░░░░░░░░░░░░▒▒▒▒█████");
                Console.WriteLine("─────███▒▒▒▒▒▒░░░░░░░░░░░░░▒▒▒▒▒▒████");
                Console.WriteLine("────────██████████████████████████");
                Console.WriteLine("\n\n1-Agregar una nueva contraseña al gestor");
                Console.WriteLine("2-Borrar una contraseña");
                Console.WriteLine("3-Modificar el contenido de una contraseña");
                Console.WriteLine("4-Listar todas mis contraseñas");
                Console.WriteLine("5-Salir del programa");
                Console.WriteLine("Selecciona una opcion: ");
                opcion = int.Parse(Console.ReadLine());
                switch (opcion){
                    case 1: 
                        AddContrasenia();
                        break;

                    case 2:
                        BorrarContrasenia();
                        break;

                    case 3: 
                        ModificarContrasenia();
                        break;

                    case 4: 
                        ListarContrasenias();
                        break;
                    default:
                        Console.WriteLine("Opcion introducida no valida, pulse una tecla para continuar");
                        Console.ReadKey();
                        break;
                }

            }while(opcion != 5);

            if(opcion == 5){
                Console.WriteLine("Cerrando Sesion...");
                System.Threading.Thread.Sleep(1000);
                GuardarFicheroContrasenias();

            }
        }catch(Exception ex){
            Console.WriteLine(ex.Message);
            Console.WriteLine("Ha ocurrido un error, pulse una tecla para continuar");
            Console.ReadKey();
        }
    }
    public void CargarFicheroContrasenias(){
        FileStream fs = new FileStream($"Contrasenias{Nombre}",FileMode.OpenOrCreate, FileAccess.Read);
        StreamReader sr = new StreamReader(fs);
        while(sr.Peek() != -1){
            string textoAContrasenia = sr.ReadLine();
            string[] textoSeparado = textoAContrasenia.Split('|');
            Contrasenias contrasenia = new Contrasenias(int.Parse(textoSeparado[0]), textoSeparado[1], textoSeparado[2], textoSeparado[3]);
            ListaContrasenias.Add(contrasenia);
        }
        sr.Close();
    }

    public void GuardarFicheroContrasenias(){
        FileStream fs = new FileStream($"Contrasenias{Nombre}",FileMode.Open, FileAccess.Write);
        StreamWriter sw = new StreamWriter(fs);
        foreach(Contrasenias contrasenias in ListaContrasenias){
            sw.WriteLine($"{contrasenias.Id}|{contrasenias.Titulo}|{contrasenias.Correo}|{contrasenias.Passwd}");
        }
        sw.Close();
    }

    public void BorrarContrasenia(){
        try{
            bool verificar = false;
            Console.Clear();    
            Console.WriteLine("Vamos a borrar una contraseña, pulsa una tecla para continuar");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Introduce el titulo de la contraseña que desea borrar: ");
            string TituloBorrar = Console.ReadLine();
            foreach(Contrasenias contrasenias in ListaContrasenias){

                if(contrasenias.Titulo == TituloBorrar){
                    ListaContrasenias.Remove(contrasenias);
                    Console.WriteLine("Contraseña borrada con exito, pulse cualquier tecla para continuar");
                    Console.ReadKey();
                    verificar = true;
                    break;
                }
            }

            if(verificar == false){
                Console.WriteLine("No existe ninguna contraseña con ese titulo o ha introducido un titulo incorrecto, pulse un tecla para continuar");
                Console.ReadKey();
            }

        }catch(Exception ex){
            Console.WriteLine(ex.Message);
            Console.WriteLine("Ha ocurrido un error, pulse una tecla para continuar");
            Console.ReadKey();
        }
    }
    public void AddContrasenia(){

        try{
            Console.Clear();
            Console.WriteLine("Vamos a agregar una contraseña, pulse una tecla para continuar");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Introduce el titulo de la contraseña: ");
            string titulo = Console.ReadLine();
            Console.WriteLine("Introduce el identificador para el servicio indicado: ");
            string identificador = Console.ReadLine();
            Console.WriteLine("Introduce la contraseña para dicho servicio: ");
            string passwd = ReadPassword();
            Id += Id;
            Contrasenias contrasenia = new Contrasenias(Id, titulo, identificador, passwd);
            ListaContrasenias.Add(contrasenia);

            Console.WriteLine("Contraseña agregada con exito, pulse una tecla para continuar");
            Console.ReadKey();

        }catch(Exception ex){
            Console.WriteLine(ex.Message);
            Console.WriteLine("Ha ocurrido un error, pulse una tecla para continuar");
            Console.ReadKey();
        }

    }

    public void ListarContrasenias(){

        Console.Clear();
        Console.WriteLine("Vamos a listar todas las contrasenias que tiene, pulse una tecla para continuar");
        Console.ReadKey();
        Console.Clear();
        if(ListaContrasenias.Count == 0){
            Console.WriteLine("No tiene contraseñas, pulse una tecla para continuar");
            Console.ReadKey();

        }else{
            foreach(Contrasenias contrasenias in ListaContrasenias){
                Console.WriteLine("\n-----------------------------------");
                Console.WriteLine($"Contraseña numero: {contrasenias.Id}");
                Console.WriteLine($"\nTitulo: {contrasenias.Titulo}");
                Console.WriteLine($"\nIdentificador del servicio: {contrasenias.Correo}");
                Console.WriteLine($"\nContraseña del servicio: {contrasenias.Passwd}");
                Console.WriteLine("\n-----------------------------------");
            }
            Console.WriteLine("\n\nSe han listado todas las contraseñas, pulse una tecla para continuar");
            Console.ReadKey();
        }
    }

    public void ModificarContrasenia(){
        
        try{
            bool verificar = false;
            int opcion = 0;
            Console.Clear();    
            Console.WriteLine("Vamos a modificar una contraseña, pulsa una tecla para continuar");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Introduce el titulo de la contraseña que desea modificar: ");
            string TituloModificar = Console.ReadLine();
            foreach(Contrasenias contrasenias in ListaContrasenias){

                if(contrasenias.Titulo == TituloModificar){
                    do{
                        Console.Clear();
                        Console.WriteLine("Selecciona cual de los campos desea modificar");
                        Console.WriteLine("1-Modificar el titulo");
                        Console.WriteLine("2-Modificar identificador");
                        Console.WriteLine("3-Modificar contraseña");
                        Console.WriteLine("4-Salir del menu de modificacion");
                        Console.WriteLine("Introduce una opcion: ");
                        opcion = int.Parse(Console.ReadLine());
                        switch(opcion){
                            case 1:
                                Console.WriteLine("Introduce el nuevo titulo de la contraseña: ");
                                string tituloAModificar = Console.ReadLine();
                                contrasenias.Titulo = tituloAModificar;
                                break;

                            case 2:
                                Console.WriteLine("Introduce el nuevo identificador: ");
                                string identificadorAModificar = Console.ReadLine();
                                contrasenias.Correo = identificadorAModificar;
                                break;

                            case 3:
                                Console.WriteLine("Introduce la nueva contraseña: ");
                                string ContraseniaAModificar = ReadPassword();
                                contrasenias.Passwd = ContraseniaAModificar;
                                break;

                            case 4:
                                break;
                        }

                    }while(opcion != 4);

                    if(opcion == 4){
                        Console.WriteLine("Se han realizado todas las modificaciones exitosamente, pulse una tecla para continuar");
                        Console.ReadKey();
                    }
                }
            }

            if(verificar == false){
                Console.WriteLine("No existe ninguna contraseña con ese titulo o ha introducido un titulo incorrecto, pulse un tecla para continuar");
                Console.ReadKey();
            }
        }
        catch(Exception ex){
            Console.WriteLine(ex.Message);
            Console.WriteLine("Ha ocurrido un error, pulse una tecla para continuar");
            Console.ReadKey();
        }
    }
    public string ReadPassword()
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