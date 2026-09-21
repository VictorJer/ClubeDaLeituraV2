using ClubeLeitura.ConsoleApp.Intraestrutura;
namespace ClubeLeitura.ConsoleApp.Apresentacao;

public class TelaRevista
{
    private RepositorioRevista repositorioRevista;
    private TelaCaixa telaCaixa;

    public TelaRevista(RepositorioRevista repositorioRevista, TelaCaixa telaCaixa)
    {
        this.repositorioRevista = repositorioRevista;
        this.telaCaixa = telaCaixa;
    }

    //=====================================================================

    public string ObterOpcaoMenu()
    {
        Console.Clear();
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Clube da Leitura");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("1 - Cadastrar revista");
        Console.WriteLine("2 - Editar revista");
        Console.WriteLine("3 - Excluir revista");
        Console.WriteLine("4 - Visualizar revistas");
        Console.WriteLine("S - Sair");
        Console.WriteLine("---------------------------------");
        Console.Write("> ");
        string? opcaoMenuPrincipal = Console.ReadLine()?.ToUpper();

        return opcaoMenuPrincipal;
    }

    public void CadastrarRevista()
    {
        throw new NotImplementedException();
    }

    public void EditarRevista()
    {
        throw new NotImplementedException();
    }

    public void ExcluirRevista()
    {
        throw new NotImplementedException();
    }

    public void VisualizarRevistas(bool Continuar)
    {
        throw new NotImplementedException();
    }
}