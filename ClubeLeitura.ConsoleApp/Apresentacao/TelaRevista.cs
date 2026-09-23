using ClubeLeitura.ConsoleApp.Apresentacao.Base;
using ClubeLeitura.ConsoleApp.Dominio;
using ClubeLeitura.ConsoleApp.Dominio.Base;
using ClubeLeitura.ConsoleApp.Intraestrutura;
namespace ClubeLeitura.ConsoleApp.Apresentacao;

public class TelaRevista : TelaBase
{
    RepositorioCaixa repositorioCaixa;
    private RepositorioRevista repositorioRevista;

    public TelaRevista(RepositorioRevista repositorioRevista, RepositorioCaixa repositorioCaixa) : base("Revista", repositorioRevista)
    {
        this.repositorioRevista = repositorioRevista;
        this.repositorioCaixa = repositorioCaixa;
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


        string idCaixa = SelecionarCaixa();

        EntidadeBase? caixaSelecionada = repositorioCaixa.SelecionarPorId(idCaixa);

        Caixa caixa = (Caixa?)caixaSelecionada;

        return new Revista(titulo, numeroEdicao, dataPublicacao, caixa);
    }
    private string SelecionarCaixa()
    {
        Console.WriteLine("---------------------------------");

        Console.WriteLine(
          "{0, -7} | {1, -20} | {2, -10} | {3, -20}",
          "Id", "Etiqueta", "Cor", "Tempo de Empréstimo"
      );

        EntidadeBase?[] caixas = repositorioCaixa.SelecionarTodos();

        for (int i = 0; i < caixas.Length; i++)
        {
            Caixa? c = (Caixa?)caixas[i];

            if (c == null)
                continue;

            string corSelecionada = c.Cor;

            if (corSelecionada == "Vermelho")
                Console.ForegroundColor = ConsoleColor.Red;

            else if (corSelecionada == "Verde")
                Console.ForegroundColor = ConsoleColor.Green;

            else if (corSelecionada == "Azul")
                Console.ForegroundColor = ConsoleColor.Blue;

            Console.WriteLine(
                "{0, -7} | {1, -20} | {2, -10} | {3, -20}",
                c.Id, c.Etiqueta, c.Cor, c.DiasEmprestimo
            );
        }

        Console.ResetColor();

        Console.WriteLine("---------------------------------");

        string? idSelecionado;

        do
        {
            Console.Write("Digite o ID da caixa em que deseja guardar a revista: ");
            idSelecionado = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(idSelecionado) && idSelecionado.Length == 7)
                break;
        } while (true);

        return idSelecionado;
    }
}