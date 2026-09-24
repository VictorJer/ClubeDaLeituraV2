using System.Security.Cryptography;
using ClubeLeitura.ConsoleApp.Dominio;

namespace ClubeDaLeitura.ConsoleApp.Dominio;

public class Multa
{
    public string Id { get; private set; } = string.Empty;
    public Emprestimo Emprestimo { get; private set; }
    public int DiasDeAtraso { get; private set; }
    public StatusMulta Status { get; private set; }
    public DateTime DataOcorrencia { get; private set; }
    public decimal Valor
    {
        get
        {
            return 2 * DiasDeAtraso;
        }
    }

    public Multa(Emprestimo emprestimo, DateTime dataConclusaoEmprestimo)
    {
        Id = Convert
            .ToHexString(RandomNumberGenerator.GetBytes(4))
            .ToLower()
            .Substring(0, 7);

        Emprestimo = emprestimo;
        DiasDeAtraso = emprestimo.ObterQuantidadeDiasAtraso(dataConclusaoEmprestimo);
        DataOcorrencia = DateTime.Now;
    }

    public void Quitar()
    {
        Status = StatusMulta.Quitada;
    }
}