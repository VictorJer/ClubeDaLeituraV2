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

        VisualizarRevistas(false);
        Console.Write("Digite o ID da revista que deseja editar: ");
        string idSelecionado = Console.ReadLine() ?? string.Empty;

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

        var result = repositorioRevista.Editar(idSelecionado, revista);

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
        VisualizarRevistas(false);
        Console.Write("Digite o ID da revista que deseja excluir: ");
        string idSelecionado = Console.ReadLine() ?? string.Empty;

        var result = repositorioRevista.Excluir(idSelecionado);

        if (result)
        {
            Console.WriteLine("Revista excluída com sucesso!");
            Console.WriteLine("Pressione ENTER para continuar...");
            Console.ReadLine();
        }
        else
        {
            Console.WriteLine("Não foi possível excluir a revista.");
            Console.WriteLine("Pressione ENTER para continuar...");
            Console.ReadLine();
        }
    }

    public void VisualizarRevistas(bool Continuar)
    {
        Console.Clear();
        Console.WriteLine("{0,-10} | {1,-20} | {2,-15} | {3,-15} | {4,-10}",
                        "ID", "Título", "Número Edição", "Ano Publicação", "Caixa");

        EntidadeBase?[] revistas = repositorioRevista.SelecionarTodos();

        for (int i = 0; i < revistas.Length; i++)
        {
            Revista? revista = (Revista?)revistas[i];

            if (revistas[i] != null)
            {
                Console.WriteLine("{0,-10} | {1,-20} | {2,-15} | {3,-15} | {4,-10}",
                            revista.Id, revista.Titulo, revista.NumeroEdicao, revista.AnoPublicacao, revista.Caixa.Etiqueta);
            }
        }

        if (Continuar)
        {
            Console.WriteLine("Pressione ENTER para continuar...");
            Console.ReadLine();
        }
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

        EntidadeBase? caixaSelecionada = repositorioCaixa.SelecionarPorId(idCaixa);

        Caixa caixa = (Caixa?)caixaSelecionada;

        return new Revista(titulo, numeroEdicao, dataPublicacao, caixa);
    }
}