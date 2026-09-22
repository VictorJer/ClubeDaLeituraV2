using ClubeLeitura.ConsoleApp.Apresentacao;
using ClubeLeitura.ConsoleApp.Intraestrutura;

RepositorioCaixa repositorioCaixa = new RepositorioCaixa();
RepositorioRevista repositorioRevista = new RepositorioRevista();

TelaCaixa telaCaixa = new TelaCaixa(repositorioCaixa);
TelaRevista telaRevista = new TelaRevista(repositorioRevista, telaCaixa, repositorioCaixa);

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

        }

        else if (opcaoMenuPrincipal == "4")
        {

        }
    }
}