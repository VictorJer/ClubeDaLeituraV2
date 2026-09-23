using ClubeLeitura.ConsoleApp.Apresentacao.Base;
using ClubeLeitura.ConsoleApp.Dominio;
using ClubeLeitura.ConsoleApp.Dominio.Base;
using ClubeLeitura.ConsoleApp.Intraestrutura;

namespace ClubeLeitura.ConsoleApp.Apresentacao;

public class TelaEmprestimo : ITela
{
    private RepositorioEmprestimo repositorioEmprestimo;
    private RepositorioAmigo repositorioAmigo;
    private RepositorioRevista repositorioRevista;

    public TelaEmprestimo(RepositorioEmprestimo repositorioEmprestimo, RepositorioAmigo repositorioAmigo, RepositorioRevista repositorioRevista)
    {
        this.repositorioEmprestimo = repositorioEmprestimo;
        this.repositorioAmigo = repositorioAmigo;
        this.repositorioRevista = repositorioRevista;
    }
    public string ObterOpcaoMenu()
    {
        Console.Clear();
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Clube da Leitura");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("1 - Abrir empréstimo");
        Console.WriteLine("2 - Fechar empréstimo");
        Console.WriteLine("3 - Visualizar empréstimos");
        Console.WriteLine("S - Sair");
        Console.WriteLine("---------------------------------");
        Console.Write("> ");
        string? opcaoMenuPrincipal = Console.ReadLine()?.ToUpper();

        return opcaoMenuPrincipal;
    }
    public void AbrirEmprestimo()
    {
        Emprestimo emprestimo = ObterDadosCadastrais();

        string[] erros = emprestimo.Validar();
        if (erros.Length > 0)
        {
            Console.WriteLine("Não foi possível abrir o empréstimo devido aos seguintes erros:");
            for (int i = 0; i < erros.Length; i++)
            {
                Console.WriteLine(erros[i]);
            }
            AbrirEmprestimo();
            return;
        }

        emprestimo.AbrirEmprestimo();

        repositorioEmprestimo.Cadastrar(emprestimo);
        Console.WriteLine("Empréstimo aberto com sucesso!");
        Console.WriteLine("Pressione ENTER para continuar...");
        Console.ReadLine();
    }

    public void FecharEmprestimo()
    {
        Console.Clear();
        Console.WriteLine("Fechamento de Empréstimos");
        Console.WriteLine("-------------------------");
        VisualizarTodos(continuar: false, exibirCabecalho: false);

        do
        {
            Console.Write("Digite o ID do empréstimo que deseja fechar: ");
            string idEmprestimo = Console.ReadLine() ?? string.Empty;

            Emprestimo? emprestimoSelecionado = repositorioEmprestimo.SelecionarPorId(idEmprestimo);

            if (emprestimoSelecionado != null)
            {
                emprestimoSelecionado.FecharEmprestimo();
                Console.WriteLine("Empréstimo fechado com sucesso!");
                Console.WriteLine("Pressione ENTER para continuar...");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("Empréstimo não encontrado. Tente novamente.");
        } while (true);
    }

    public void VisualizarTodos(bool continuar, bool exibirCabecalho)
    {
        Console.Clear();
        if (exibirCabecalho)
        {
            Console.WriteLine("Visualização de Empréstimos");
            Console.WriteLine("---------------------------");
        }

        Console.WriteLine("{0,-7} | {1,-20} | {2,-20} | {3,-15} | {4,-15} | {5,-10}",
                            "ID", "Amigo", "Revista", "Data Empréstimo", "Data Devolução", "Status");

        Emprestimo?[] emprestimos = repositorioEmprestimo.SelecionarTodos();

        for (int i = 0; i < emprestimos.Length; i++)
        {
            if (emprestimos[i] == null)
                continue;

            if (emprestimos[i] != null)
            {
                if (emprestimos[i].EstaAtrasado)
                {
                    emprestimos[i].Status = StatusEmprestimo.Atrasado;
                }

                Console.WriteLine("{0,-7} | {1,-20} | {2,-20} | {3,-15} | {4,-15} | {5,-10}",
                                    emprestimos[i].Id, emprestimos[i].Amigo.Nome, emprestimos[i].Revista.Titulo, emprestimos[i].DataEmprestimo.ToShortDateString(), emprestimos[i].DataDevolucao.ToShortDateString() ?? "", emprestimos[i].Status);
            }
        }

        if (continuar)
        {
            Console.WriteLine("Pressione ENTER para continuar...");
            Console.ReadLine();
        }
    }

    private Emprestimo ObterDadosCadastrais()
    {
        Revista revista = SelecionarRevista();
        Amigo amigo = SelecionarAmigo();

        return new Emprestimo(amigo, revista);
    }

    private Revista SelecionarRevista()
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

        string idRevista = string.Empty;
        while (true)
        {
            Console.Write("Digite o ID da revista: ");
            idRevista = Console.ReadLine() ?? string.Empty;

            EntidadeBase? revistaSelecionada = repositorioRevista.SelecionarPorId(idRevista);

            if (revistaSelecionada != null)
                return (Revista)revistaSelecionada;

            Console.WriteLine("Revista não encontrada. Tente novamente.");
        }
    }

    private Amigo SelecionarAmigo()
    {
        Console.Clear();
        Console.WriteLine("{0,-5} | {1,-20} | {2,-15} | {3,-30}",
                            "ID", "Nome", "Telefone", "Responsável");

        EntidadeBase?[] amigos = repositorioAmigo.SelecionarTodos();

        for (int i = 0; i < amigos.Length; i++)
        {
            Amigo? amigo = (Amigo?)amigos[i];

            if (amigos[i] != null)
            {
                Console.WriteLine("{0,-5} | {1,-20} | {2,-15} | {3,-30}",
                                    amigo.Id, amigo.Nome, amigo.Telefone, amigo.NomeResponsavel);
            }
        }

        string idAmigo = string.Empty;
        while (true)
        {
            Console.Write("Digite o ID do amigo: ");
            idAmigo = Console.ReadLine() ?? string.Empty;

            EntidadeBase? amigoSelecionado = repositorioAmigo.SelecionarPorId(idAmigo);

            if (amigoSelecionado != null)
                return (Amigo)amigoSelecionado;

            Console.WriteLine("Amigo não encontrado. Tente novamente.");
        }
    }

}