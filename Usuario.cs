public class Usuario
{
    public string Nombre { get; set; }
    public string Contrasenia { get; set; }
    public Usuario(){
        
    }       
    public Usuario(string nombre, string contrasenia)
    {
        Nombre = nombre;
        Contrasenia = contrasenia;
    }
    
    
}