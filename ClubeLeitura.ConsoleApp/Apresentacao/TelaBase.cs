public abstract class TelaBase
{
    public string nomeEntidade = string.Empty;

    public TelaBase(string nomeEntidade)
    {
        this.nomeEntidade = nomeEntidade;
    }

    protected void Cabesalho(string titulo)
    {
        Console.Clear();
        Console.WriteLine("---------------------------------");
        Console.WriteLine($"Clube da {nomeEntidade}");
        Console.WriteLine("---------------------------------");
        Console.WriteLine(titulo);
        Console.WriteLine("---------------------------------");
    }

    protected void ExibirMensagem(string mensagem)
    {
        Console.WriteLine(mensagem);
        Console.WriteLine("Pressione ENTER para continuar...");
        Console.ReadLine();
    }
}