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

    public string[] Validar()
    {
        string erros = string.Empty;

        if (string.IsNullOrWhiteSpace(Etiqueta))
            erros += "A etiqueta da caixa não pode ser vazia.;";

        if (Etiqueta.Length < 3)
            erros += "A etiqueta da caixa deve ter pelo menos 3 caracteres.;";

        if (Etiqueta.Length > 50)
            erros += "A etiqueta da caixa não pode ter mais de 50 caracteres.;";

        if (string.IsNullOrWhiteSpace(Cor))
            erros += "A cor da caixa não pode ser vazia.;";

        if (DiasEmprestimo <= 0)
            erros += "O número de dias de empréstimo deve ser um valor positivo.;";

        if (DiasEmprestimo > 30)
            erros += "O número de dias de empréstimo não pode ser maior que 30.;";

        return erros.Split(";", StringSplitOptions.RemoveEmptyEntries);
    }
}