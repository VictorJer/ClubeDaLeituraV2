using ClubeLeitura.ConsoleApp.Dominio;

namespace ClubeLeitura.ConsoleApp.Intraestrutura;

public abstract class RepositorioBase
{
    protected EntidadeBase?[] registros = new EntidadeBase[100];

    public bool Cadastrar(EntidadeBase entidade)
    {
        for (int i = 0; i < registros.Length; i++)
        {
            if (registros[i] == null)
            {
                registros[i] = entidade;
                return true;
            }
        }

        return false;
    }

    public bool Editar(string idSelecionado, EntidadeBase entidadeAtualizada)
    {
        var entidadeSelecionada = SelecionarPorId(idSelecionado);

        if (entidadeSelecionada != null)
        {
            entidadeSelecionada.Atualizar(entidadeAtualizada);
            return true;
        }

        return false;
    }

    public bool Excluir(string idSelecionado)
    {
        for (int i = 0; i < registros.Length; i++)
        {
            if (registros[i] != null && registros[i].Id == idSelecionado)
            {
                registros[i] = null;
                return true;
            }
        }

        return false;
    }

    public EntidadeBase? SelecionarPorId(string id)
    {
        for (int i = 0; i < registros.Length; i++)
        {
            if (registros[i] != null && registros[i].Id == id)
            {
                return registros[i];
            }
        }

        return null;
    }

    public EntidadeBase?[] SelecionarTodos()
    {
        return registros;
    }
}