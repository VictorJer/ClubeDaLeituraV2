using ClubeLeitura.ConsoleApp.Dominio;

namespace ClubeLeitura.ConsoleApp.Intraestrutura;

public class RepositorioRevista
{
    private Revista[] revistas = new Revista[100];

    public bool Cadastrar(Revista revista)
    {
        for (int i = 0; i < revistas.Length; i++)
        {
            if (revistas[i] == null)
            {
                revistas[i] = revista;
                return true;
            }
        }

        return false;
    }

    public bool Editar(string id, Revista revista)
    {
        for (int i = 0; i < revistas.Length; i++)
        {
            if (revistas[i] != null && revistas[i].Id == id)
            {
                revistas[i].Atualizar(revista);
                return true;
            }
        }

        return false;
    }

    internal bool Excluir(string idSelecionado)
    {
        for (int i = 0; i < revistas.Length; i++)
        {
            if (revistas[i] != null && revistas[i].Id == idSelecionado)
            {
                revistas[i] = null;
                return true;
            }
        }

        return false;
    }

    internal Revista[] SelecionarTodos()
    {
        return revistas;
    }
}