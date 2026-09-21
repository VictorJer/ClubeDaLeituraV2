using System.Security.Cryptography;

namespace ClubeLeitura.ConsoleApp.Dominio;

public class Caixa
{
    public string Id { get; set; }
    public string Etiqueta { get; set; } = string.Empty;
    public string Cor { get; set; } = string.Empty;
    public int DiasEmprestimo { get; set; } = 7;

    public Caixa(string etiqueta, string cor, int diasEmprestimo)
    {
        Id = Convert
        .ToHexString(RandomNumberGenerator.GetBytes(20))
        .ToLower()
        .Substring(0, 7);

        Etiqueta = etiqueta;
        Cor = cor;
        DiasEmprestimo = diasEmprestimo;
    }

    public void AtualizarCaixa(Caixa caixaAtualizada)
    {
        Etiqueta = caixaAtualizada.Etiqueta;
        Cor = caixaAtualizada.Cor;
        DiasEmprestimo = caixaAtualizada.DiasEmprestimo;
    }
}