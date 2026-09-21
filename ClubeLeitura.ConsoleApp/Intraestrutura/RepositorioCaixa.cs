using ClubeLeitura.ConsoleApp.Dominio;
using ClubeLeitura.ConsoleApp.Intraestrutura;

public class RepositorioCaixa : RepositorioBase
{
    private Caixa[] caixas = new Caixa[100];

    public bool Cadastrar(Caixa caixa)
    {
        for (int i = 0; i < caixas.Length; i++)
        {
            if (caixas[i] == null)
            {
                caixas[i] = caixa;
                return true;
            }
        }

        return false;
    }

    public bool Editar(string idSelecionado, Caixa caixaAtualizada)
    {
        var caixaExistente = SelecionarPorId(idSelecionado);

        if (caixaExistente != null)
        {
            caixaExistente.Atualizar(caixaAtualizada);
            return true;
        }

        return false;
    }

    public Caixa SelecionarPorId(string id)
    {
        for (int i = 0; i < caixas.Length; i++)
        {
            if (caixas[i] != null && caixas[i].Id == id)
            {
                return caixas[i];
            }
        }

        return null;
    }

    public Caixa[] SelecionarTodos()
    {
        return caixas;
    }

    internal void Excluir(string idSelecionado)
    {
        for (int i = 0; i < caixas.Length; i++)
        {
            if (caixas[i] != null && caixas[i].Id == idSelecionado)
            {
                caixas[i] = null;
                break;
            }
        }
    }
}