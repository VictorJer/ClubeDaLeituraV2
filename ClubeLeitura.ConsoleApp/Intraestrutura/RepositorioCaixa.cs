using ClubeLeitura.ConsoleApp.Dominio;

public class RepositorioCaixa
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
        for (int i = 0; i < caixas.Length; i++)
        {
            if (caixas[i] != null && caixas[i].Id == idSelecionado)
            {
                caixas[i] = caixaAtualizada;
                return true;
            }
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
}