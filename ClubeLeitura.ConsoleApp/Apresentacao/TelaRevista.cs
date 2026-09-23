using ClubeLeitura.ConsoleApp.Apresentacao.Base;
using ClubeLeitura.ConsoleApp.Dominio;
using ClubeLeitura.ConsoleApp.Dominio.Base;
using ClubeLeitura.ConsoleApp.Intraestrutura;
namespace ClubeLeitura.ConsoleApp.Apresentacao;

public class TelaRevista : TelaBase
{
    RepositorioCaixa repositorioCaixa;
    private RepositorioRevista repositorioRevista;
    private TelaCaixa telaCaixa;

    public TelaRevista(RepositorioRevista repositorioRevista, TelaCaixa telaCaixa, RepositorioCaixa repositorioCaixa) : base("Revista", repositorioRevista)
    {
        this.repositorioRevista = repositorioRevista;
        this.telaCaixa = telaCaixa;
        this.repositorioCaixa = repositorioCaixa;
        this.telaCaixa = telaCaixa;
    }

    //=====================================================================


    public override void VisualizarTodos(bool Continuar)
    {
        Console.Clear();
        Console.WriteLine("{0,-10} | {1,-20} | {2,-15} | {3,-15} | {4,-10} | {5,-10}",
                        "ID", "Título", "Número Edição", "Ano Publicação", "Caixa", "Status");

        EntidadeBase?[] revistas = repositorioRevista.SelecionarTodos();

        for (int i = 0; i < revistas.Length; i++)
        {
            Revista? revista = (Revista?)revistas[i];

            if (revistas[i] != null)
            {
                Console.WriteLine("{0,-10} | {1,-20} | {2,-15} | {3,-15} | {4,-10} | {5,-10}",
                            revista.Id, revista.Titulo, revista.NumeroEdicao, revista.AnoPublicacao, revista.Caixa.Etiqueta, revista.Status.ToString());
            }
        }

        if (Continuar)
        {
            Console.WriteLine("Pressione ENTER para continuar...");
            Console.ReadLine();
        }
    }

    protected override EntidadeBase ObterDadosCadastrais()
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

        telaCaixa.VisualizarTodos(false);
        Console.Write("ID da caixa: ");
        string idCaixa = Console.ReadLine() ?? string.Empty;

        EntidadeBase? caixaSelecionada = repositorioCaixa.SelecionarPorId(idCaixa);

        Caixa caixa = (Caixa?)caixaSelecionada;

        return new Revista(titulo, numeroEdicao, dataPublicacao, caixa);
    }
}