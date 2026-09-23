using System.Security.Cryptography;
using ClubeLeitura.ConsoleApp.Dominio.Base;

namespace ClubeLeitura.ConsoleApp.Dominio;

public enum StatusRevista
{
    Disponivel,
    Emprestada
}

public class Revista : EntidadeBase
{
    public string Titulo { get; set; } = string.Empty;
    public string NumeroEdicao { get; set; } = string.Empty;
    public string AnoPublicacao { get; set; } = string.Empty;
    public Caixa Caixa { get; set; }
    public StatusRevista Status { get; set; }

    public Revista(string titulo, string numeroEdicao, string anoPublicacao, Caixa caixa)
    {
        Titulo = titulo;
        NumeroEdicao = numeroEdicao;
        AnoPublicacao = anoPublicacao;
        Caixa = caixa;
    }

    public void Emprestada()
    {
        Status = StatusRevista.Emprestada;
    }
    public void Devolver()
    {
        Status = StatusRevista.Disponivel;
    }

    public override void Atualizar(EntidadeBase entidadeAtualizada)
    {
        Revista revistaAtualizada = (Revista)entidadeAtualizada;

        Titulo = revistaAtualizada.Titulo;
        NumeroEdicao = revistaAtualizada.NumeroEdicao;
        AnoPublicacao = revistaAtualizada.AnoPublicacao;
        Caixa = revistaAtualizada.Caixa;
    }

    public override string[] Validar()
    {
        string erros = string.Empty;

        if (string.IsNullOrWhiteSpace(Titulo))
            erros += "O título da revista não pode ser vazio.;";

        if (Titulo.Length < 3)
            erros += "O título da revista deve ter pelo menos 3 caracteres.;";

        if (Titulo.Length > 50)
            erros += "O título da revista não pode ter mais de 50 caracteres.;";

        if (string.IsNullOrWhiteSpace(NumeroEdicao))
            erros += "O número da edição da revista não pode ser vazio.;";

        if (string.IsNullOrWhiteSpace(AnoPublicacao))
            erros += "O ano de publicação da revista não pode ser vazio.;";

        return erros.Split(";", StringSplitOptions.RemoveEmptyEntries);
    }


}