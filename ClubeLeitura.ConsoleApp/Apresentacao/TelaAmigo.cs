using ClubeDaLeitura.ConsoleApp.Dominio;
using ClubeLeitura.ConsoleApp.Apresentacao.Base;
using ClubeLeitura.ConsoleApp.Dominio;
using ClubeLeitura.ConsoleApp.Dominio.Base;
using ClubeLeitura.ConsoleApp.Intraestrutura;

namespace ClubeLeitura.ConsoleApp.Apresentacao;

public class TelaAmigo : TelaBase
{
    private readonly RepositorioAmigo repositorioAmigo;

    public TelaAmigo(RepositorioAmigo repositorioAmigo) : base("Cadastro de Amigos", repositorioAmigo)
    {
        this.repositorioAmigo = repositorioAmigo;
    }

    public override void VisualizarTodos(bool Continuar)
    {
        Cabesalho("Visualização de Amigos");

        EntidadeBase?[] amigos = repositorioAmigo.SelecionarTodos();


        Console.WriteLine("Amigos Cadastrados:");
        Console.WriteLine("-------------------");
        Console.WriteLine("{0,-5} | {1,-20} | {2,-15} | {3,-30}",
                            "ID", "Nome", "Telefone", "Responsável");

        if (amigos.Length == 0)
        {
            Console.WriteLine("Nenhum amigo cadastrado.");
            Console.WriteLine("Pressione ENTER para continuar...");
            Console.ReadLine();
            return;
        }

        for (int i = 0; i < amigos.Length; i++)
        {
            Amigo? amigo = (Amigo?)amigos[i];

            if (amigo == null)
                continue;

            Console.WriteLine("{0,-5} | {1,-20} | {2,-15} | {3,-30}",
                                amigo.Id, amigo.Nome, amigo.Telefone, amigo.NomeResponsavel);
        }

        if (Continuar)
        {
            Console.WriteLine("Pressione ENTER para continuar...");
            Console.ReadLine();
        }
    }

    protected override EntidadeBase ObterDadosCadastrais()
    {
        string nome = string.Empty;
        string nomeResponsavel = string.Empty;
        string telefone = string.Empty;

        Console.Write("Digite o nome do amigo: ");
        nome = Console.ReadLine() ?? string.Empty;

        Console.Write("Digite o telefone do amigo: ");
        telefone = Console.ReadLine() ?? string.Empty;

        Console.Write("Digite o nome do responsável: ");
        nomeResponsavel = Console.ReadLine() ?? string.Empty;

        return new Amigo(nome, telefone, nomeResponsavel);
    }

    public void VisualizarMultas()
    {
        Amigo? amigoSelecionado = null;

        do
        {
            Console.WriteLine("Visualização de Multas de Amigo");
            Console.WriteLine("---------------------------------");


            VisualizarTodos(Continuar: false);

            Console.WriteLine("---------------------------------");

            string? idSelecionado;

            Console.Write("Digite o ID do registro que deseja visualizar (ou S para sair): ");
            idSelecionado = Console.ReadLine() ?? string.Empty;

            if (idSelecionado.ToUpper() == "S")
                return;

            if (!string.IsNullOrWhiteSpace(idSelecionado) && idSelecionado.Length == 7)
                amigoSelecionado = (Amigo?)repositorioAmigo.SelecionarPorId(idSelecionado);

            if (amigoSelecionado != null)
                break;
        } while (true);

        Console.WriteLine("---------------------------------");

        Console.WriteLine(
            "{0, -7} | {1, -12} | {2, -7} | {3, -20} | {4, -10}",
            "Id", "Ocorrência", "Valor", "Revista", "Status"
        );

        Multa?[] multas = amigoSelecionado.Multas;

        for (int i = 0; i < multas.Length; i++)
        {
            Multa? m = multas[i];

            if (m == null)
                continue;

            Console.WriteLine(
                "{0, -7} | {1, -12} | {2, -7} | {3, -20} | {4, -10}",
                m.Id,
                m.DataOcorrencia.ToShortDateString(),
                m.Valor.ToString("C2"),
                m.Emprestimo.Revista.Titulo,
                m.Status
            );
        }

        Console.WriteLine("---------------------------------");
        Console.WriteLine("Digite ENTER para continuar...");
        Console.ReadLine();
    }
}