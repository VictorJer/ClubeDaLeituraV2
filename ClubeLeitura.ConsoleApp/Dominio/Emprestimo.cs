using System.Security.Cryptography;
using ClubeLeitura.ConsoleApp.Dominio.Base;

namespace ClubeLeitura.ConsoleApp.Dominio;

public enum StatusEmprestimo
{
    Aberto,
    Fechado,
    Atrasado
}
public class Emprestimo
{
    public string Id { get; set; } = string.Empty;
    public Amigo Amigo { get; set; }
    public Revista Revista { get; set; }
    public DateTime DataEmprestimo { get; set; }
    public DateTime DataDevolucao
    {
        get
        {
            return DataEmprestimo.AddDays(Revista.Caixa.DiasEmprestimo);
        }
    }
    public StatusEmprestimo Status { get; set; } = StatusEmprestimo.Aberto;


    public Emprestimo(string id, Amigo amigo, Revista revista)
    {
        Id = Convert
            .ToHexString(RandomNumberGenerator.GetBytes(20))
            .ToLower()
            .Substring(0, 7);


        Amigo = amigo;
        Revista = revista;
    }

    public void AbrirEmprestimo()
    {
        Status = StatusEmprestimo.Aberto;
        DataEmprestimo = DateTime.Now;

        Revista.Emprestada();
        Amigo.AddEmprestimo(this);
    }

    public string[] Validar()
    {
        string erros = string.Empty;

        if (Amigo == null)
            erros += "O amigo não pode ser nulo.;";

        if (Revista == null)
            erros += "A revista não pode ser nula.;";

        return erros.Split(';', StringSplitOptions.RemoveEmptyEntries);
    }
}