using ClubeLeitura.ConsoleApp.Apresentacao.Base;
using ClubeLeitura.ConsoleApp.Intraestrutura;

namespace ClubeLeitura.ConsoleApp.Apresentacao;

public class TelaPrincipal
{
    private RepositorioAmigo repositorioAmigo;
    private RepositorioCaixa repositorioCaixa;
    private RepositorioRevista repositorioRevista;
    private RepositorioEmprestimo repositorioEmprestimo;
    private RepositorioReserva repositorioReserva;

    public TelaPrincipal(RepositorioAmigo repositorioAmigo, RepositorioCaixa repositorioCaixa, RepositorioRevista repositorioRevista, RepositorioEmprestimo repositorioEmprestimo, RepositorioReserva repositorioReserva)
    {
        this.repositorioAmigo = repositorioAmigo;
        this.repositorioCaixa = repositorioCaixa;
        this.repositorioRevista = repositorioRevista;
        this.repositorioEmprestimo = repositorioEmprestimo;
        this.repositorioReserva = repositorioReserva;
    }

    public ITela? ApresentarMenuPrincipal()
    {
        Console.Clear();
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Clube da Leitura");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("1 - Gerenciar caixas de revistas");
        Console.WriteLine("2 - Gerenciar revistas");
        Console.WriteLine("3 - Gerenciar amigos");
        Console.WriteLine("4 - Gerenciar empréstimos");
        Console.WriteLine("5 - Gerenciar reservas");
        Console.WriteLine("S - Sair");
        Console.WriteLine("---------------------------------");
        Console.Write("> ");
        string? opcaoMenuPrincipal = Console.ReadLine()?.ToUpper();

        if (opcaoMenuPrincipal == "1")
            return new TelaCaixa(repositorioCaixa);

        else if (opcaoMenuPrincipal == "2")
            return new TelaRevista(repositorioRevista, repositorioCaixa);

        else if (opcaoMenuPrincipal == "3")
            return new TelaAmigo(repositorioAmigo);

        else if (opcaoMenuPrincipal == "4")
            return new TelaEmprestimo(repositorioEmprestimo, repositorioAmigo, repositorioRevista);

        else if (opcaoMenuPrincipal == "5")
            return new TelaReserva(repositorioRevista, repositorioReserva, repositorioAmigo);

        return null;
    }
}