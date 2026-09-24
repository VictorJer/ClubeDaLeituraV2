using ClubeDaLeitura.ConsoleApp.Dominio;
using ClubeLeitura.ConsoleApp.Dominio.Base;

namespace ClubeLeitura.ConsoleApp.Dominio;

public class Amigo : EntidadeBase
{
    public string Nome { get; set; } = string.Empty;
    public string NomeResponsavel { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
    public Emprestimo?[] Emprestimos { get; set; } = new Emprestimo[100];
    public Multa?[] Multas { get; set; } = new Multa[100];
    public bool ContemEmprestimoAberto
    {
        get
        {
            for (int i = 0; i < Emprestimos.Length; i++)
            {
                Emprestimo? e = Emprestimos[i];

                if (e?.Status == StatusEmprestimo.Aberto)
                    return true;
            }

            return false;
        }
    }
    public bool ContemMultaAtiva
    {
        get
        {
            for (int i = 0; i < Multas.Length; i++)
            {
                Multa? multa = Multas[i];

                if (multa?.Status == StatusMulta.Ativa)
                    return true;
            }

            return false;
        }
    }




    public Amigo(string nome, string nomeResponsavel, string telefone)
    {
        Nome = nome;
        NomeResponsavel = nomeResponsavel;
        Telefone = telefone;
    }

    public void AddEmprestimo(Emprestimo emprestimo)
    {
        for (int i = 0; i < Emprestimos.Length; i++)
        {
            if (Emprestimos[i] == null)
            {
                Emprestimos[i] = emprestimo;
                break;
            }
        }
    }

    public void AddMulta(Multa multa)
    {
        for (int i = 0; i < Multas.Length; i++)
        {
            if (Multas[i] == null)
            {
                Multas[i] = multa;
                break;
            }
        }
    }

    public override void Atualizar(EntidadeBase entidadeAtualizada)
    {
        Amigo amigoAtualizado = (Amigo)entidadeAtualizada;

        Nome = amigoAtualizado.Nome;
        NomeResponsavel = amigoAtualizado.NomeResponsavel;
        Telefone = amigoAtualizado.Telefone;
    }

    public override string[] Validar()
    {
        string erros = string.Empty;

        if (string.IsNullOrWhiteSpace(Nome))
            erros += "O nome do amigo não pode ser vazio.;";

        else if (Nome.Length < 3)
            erros += "O nome do amigo deve ter pelo menos 3 caracteres.;";

        else if (Nome.Length > 100)
            erros += "O nome do amigo não pode ter mais de 100 caracteres.;";

        if (string.IsNullOrWhiteSpace(NomeResponsavel))
            erros += "O nome do responsável não pode ser vazio.;";

        else if (NomeResponsavel.Length < 3)
            erros += "O nome do responsável deve ter pelo menos 3 caracteres.;";

        else if (NomeResponsavel.Length > 100)
            erros += "O nome do responsável não pode ter mais de 100 caracteres.;";

        if (string.IsNullOrWhiteSpace(Telefone))
            erros += "O telefone não pode ser vazio.;";

        int contadorDigitos = 0;
        bool temCaracteresInvalidos = false;

        string telefoneEncurtado = Telefone.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "");


        for (int i = 0; i < telefoneEncurtado.Length; i++)
        {
            char caractere = telefoneEncurtado[i];

            if (char.IsDigit(caractere))
                contadorDigitos++;
            else
                temCaracteresInvalidos = true;
        }

        if (temCaracteresInvalidos)
            erros += "O telefone deve conter apenas números.;";

        if (contadorDigitos < 10)
            erros += "O telefone deve ter pelo menos 10 dígitos.;";

        else if (contadorDigitos > 11)
            erros += "O telefone não pode ter mais de 11 dígitos.;";


        return erros.Split(";", StringSplitOptions.RemoveEmptyEntries);
    }
    public Multa? ObterMultaAtiva()
    {
        for (int i = 0; i < Multas.Length; i++)
        {
            Multa? m = Multas[i];

            if (m == null)
                continue;

            if (m.Status == StatusMulta.Ativa)
                return m;
        }

        return null;
    }
}