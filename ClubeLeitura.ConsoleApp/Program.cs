using ClubeLeitura.ConsoleApp.Apresentacao;
using ClubeLeitura.ConsoleApp.Intraestrutura;

RepositorioAmigo repositorioAmigo = new RepositorioAmigo();
RepositorioCaixa repositorioCaixa = new RepositorioCaixa();
RepositorioRevista repositorioRevista = new RepositorioRevista();
RepositorioEmprestimo repositorioEmprestimo = new RepositorioEmprestimo();

TelaCaixa telaCaixa = new TelaCaixa(repositorioCaixa);
TelaRevista telaRevista = new TelaRevista(repositorioRevista, telaCaixa, repositorioCaixa);
TelaAmigo telaAmigo = new TelaAmigo(repositorioAmigo);
TelaEmprestimo telaEmprestimo = new TelaEmprestimo(repositorioEmprestimo, repositorioAmigo, repositorioRevista);

while (true)
{
    Console.Clear();
    Console.WriteLine("---------------------------------");
    Console.WriteLine("Clube da Leitura");
    Console.WriteLine("---------------------------------");
    Console.WriteLine("1 - Gerenciar caixas de revistas");
    Console.WriteLine("2 - Gerenciar revistas");
    Console.WriteLine("3 - Gerenciar amigos");
    Console.WriteLine("4 - Gerenciar empréstimos");
    Console.WriteLine("S - Sair");
    Console.WriteLine("---------------------------------");
    Console.Write("> ");
    string? opcaoMenuPrincipal = Console.ReadLine()?.ToUpper();

    if (opcaoMenuPrincipal == "S")
    {
        Console.Clear();
        break;
    }

    while (true)
    {
        string? opcaoMenuInterno = string.Empty;

        if (opcaoMenuPrincipal == "1")
        {
            opcaoMenuInterno = telaCaixa.ObterOpcaoMenu();

            if (opcaoMenuInterno == "S")
                break;

            switch (opcaoMenuInterno)
            {
                case ("1")
                    :
                    telaCaixa.Cadastrar();
                    break;
                case ("2")
                    :
                    telaCaixa.Editar();
                    break;

                case ("3")
                    :
                    telaCaixa.Excluir();
                    break;

                case ("4")
                    :
                    telaCaixa.VisualizarTodos(true);
                    break;
            }
        }

        else if (opcaoMenuPrincipal == "2")
        {
            opcaoMenuInterno = telaRevista.ObterOpcaoMenu();

            if (opcaoMenuInterno == "S")
                break;

            switch (opcaoMenuInterno)
            {
                case ("1")
                    :
                    telaRevista.Cadastrar();
                    break;
                case ("2")
                    :
                    telaRevista.Editar();
                    break;

                case ("3")
                    :
                    telaRevista.Excluir();
                    break;

                case ("4")
                    :
                    telaRevista.VisualizarTodos(true);
                    break;
            }
        }

        else if (opcaoMenuPrincipal == "3")
        {
            opcaoMenuInterno = telaAmigo.ObterOpcaoMenu();

            if (opcaoMenuInterno == "S")
                break;

            switch (opcaoMenuInterno)
            {
                case ("1")
                    :
                    telaAmigo.Cadastrar();
                    break;
                case ("2")
                    :
                    telaAmigo.Editar();
                    break;

                case ("3")
                    :
                    telaAmigo.Excluir();
                    break;

                case ("4")
                    :
                    telaAmigo.VisualizarTodos(true);
                    break;
            }
        }

        else if (opcaoMenuPrincipal == "4")
        {
            opcaoMenuInterno = telaEmprestimo.ObterOpcaoMenu();

            if (opcaoMenuInterno == "S")
                break;

            switch (opcaoMenuInterno)
            {
                case ("1")
                    :
                    telaEmprestimo.AbrirEmprestimo();
                    break;
                case ("2")
                    :
                    telaEmprestimo.FecharEmprestimo();
                    break;

                case ("3")
                    :
                    telaEmprestimo.VisualizarTodos(continuar: true, exibirCabecalho: true);
                    break;
            }
        }
    }
}