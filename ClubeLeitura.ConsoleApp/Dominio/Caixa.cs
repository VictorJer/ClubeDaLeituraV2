using System.Security.Cryptography;
using ClubeLeitura.ConsoleApp.Dominio.Base;

namespace ClubeLeitura.ConsoleApp.Dominio;

public class Caixa : EntidadeBase
{

    public string Etiqueta { get; set; } = string.Empty;
    public string Cor { get; set; } = string.Empty;
    public int DiasEmprestimo { get; set; } = 7;

    public Caixa(string etiqueta, string cor, int diasEmprestimo)
    {
        Etiqueta = etiqueta;
        Cor = cor;
        DiasEmprestimo = diasEmprestimo;
    }

    public override void Atualizar(EntidadeBase entidadeAtualizada)
    {
        Caixa caixaAtualizada = (Caixa)entidadeAtualizada;

        Etiqueta = caixaAtualizada.Etiqueta;
        Cor = caixaAtualizada.Cor;
        DiasEmprestimo = caixaAtualizada.DiasEmprestimo;
    }

    public override string[] Validar()
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