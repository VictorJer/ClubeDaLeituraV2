using System.Security.Cryptography;
using ClubeLeitura.ConsoleApp.Dominio.Base;

namespace ClubeLeitura.ConsoleApp.Dominio;

public class Emprestimo
{
    public string Id { get; set; } = string.Empty;
    public Amigo Amigo { get; set; }
    public Revista Revista { get; set; }
    public Emprestimo(string id, Amigo amigo, Revista revista)
    {
        Id = Convert
            .ToHexString(RandomNumberGenerator.GetBytes(20))
            .ToLower()
            .Substring(0, 7);


        Amigo = amigo;
        Revista = revista;
    }
    public string[] Validar()
    {
        throw new NotImplementedException();
    }
}