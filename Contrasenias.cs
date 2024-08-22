public class Contrasenias
{

    public int Id {get; set;}
    public string Titulo {get; set;}

    public string Correo {get; set;}

    public string Passwd {get; set;}
    public Contrasenias(){

    }
    public Contrasenias(int id, string titulo, string correo, string passwd) { Id = id; Titulo = titulo; Correo = correo; Passwd = passwd; }
    



}