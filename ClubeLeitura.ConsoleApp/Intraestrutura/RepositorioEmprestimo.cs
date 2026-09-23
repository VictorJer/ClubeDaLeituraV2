using ClubeLeitura.ConsoleApp.Dominio;

public class RepositorioEmprestimo
{
    private Emprestimo?[] emprestimos = new Emprestimo[100];
    public void Cadastrar(Emprestimo emprestimo)
    {
        for (int i = 0; i < emprestimos.Length; i++)
        {
            if (emprestimos[i] == null)
            {
                emprestimos[i] = emprestimo;
                break;
            }
        }
    }

    public Emprestimo?[] SelecionarTodos()
    {
        return emprestimos;
    }

    internal Emprestimo? SelecionarPorId(string idEmprestimo)
    {
        for (int i = 0; i < emprestimos.Length; i++)
        {
            if (emprestimos[i] == null)
                continue;

            if (emprestimos[i].Id == idEmprestimo)
            {
                return emprestimos[i];
            }
        }

        return null;
    }
}