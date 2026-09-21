using ClubeLeitura.ConsoleApp.Dominio;
using ClubeLeitura.ConsoleApp.Intraestrutura;
namespace ClubeLeitura.ConsoleApp.Apresentacao;

public class TelaRevista
{
    RepositorioCaixa repositorioCaixa;
    private RepositorioRevista repositorioRevista;
    private TelaCaixa telaCaixa;

    public TelaRevista(RepositorioRevista repositorioRevista, TelaCaixa telaCaixa, RepositorioCaixa repositorioCaixa)
    {
        this.repositorioRevista = repositorioRevista;
        this.telaCaixa = telaCaixa;
        this.repositorioCaixa = repositorioCaixa;
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
        Revista revista = ObterDadosCadastrais();

        var erros = revista.Validar();

        if (erros.Length > 0)
        {
            for (int i = 0; i < erros.Length; i++)
            {
                Console.WriteLine(erros[i]);
            }

            Console.WriteLine("Pressione ENTER para continuar...");
            Console.ReadLine();
            CadastrarRevista();
            return;
        }

        var result = repositorioRevista.Cadastrar(revista);

        if (result)
        {
            Console.WriteLine("Revista cadastrada com sucesso!");
            Console.WriteLine("Pressione ENTER para continuar...");
            Console.ReadLine();
        }
        else
        {
            Console.WriteLine("Não foi possível cadastrar a revista. Limite atingido.");
            Console.WriteLine("Pressione ENTER para continuar...");
            Console.ReadLine();
        }
    }

    public void EditarRevista()
    {
        Revista revista = ObterDadosCadastrais();

        var erros = revista.Validar();

        if (erros.Length > 0)
        {
            for (int i = 0; i < erros.Length; i++)
            {
                Console.WriteLine(erros[i]);
            }

            Console.WriteLine("Pressione ENTER para continuar...");
            Console.ReadLine();
            EditarRevista();
            return;
        }

        var result = repositorioRevista.Editar(revista.Id, revista);

        if (result)
        {
            Console.WriteLine("Revista editada com sucesso!");
            Console.WriteLine("Pressione ENTER para continuar...");
            Console.ReadLine();
        }
        else
        {
            Console.WriteLine("Não foi possível editar a revista.");
            Console.WriteLine("Pressione ENTER para continuar...");
            Console.ReadLine();
        }

    }

    public void ExcluirRevista()
    {
        throw new NotImplementedException();
    }

    public void VisualizarRevistas(bool Continuar)
    {
        throw new NotImplementedException();
    }

    public Revista ObterDadosCadastrais()
    {
        string titulo = string.Empty;
        string numeroEdicao = string.Empty;
        string dataPublicacao = string.Empty;
        string valor = string.Empty;

        Console.Write("Título: ");
        titulo = Console.ReadLine() ?? string.Empty;

        Console.Write("Número da edição: ");
        numeroEdicao = Console.ReadLine() ?? string.Empty;

        Console.Write("Data de publicação: ");
        dataPublicacao = Console.ReadLine() ?? string.Empty;

        telaCaixa.VisualizarCaixas(false);
        Console.Write("ID da caixa: ");
        string idCaixa = Console.ReadLine() ?? string.Empty;

        Caixa caixa = repositorioCaixa.SelecionarPorId(idCaixa);

        return new Revista(titulo, numeroEdicao, dataPublicacao, caixa);
    }
}