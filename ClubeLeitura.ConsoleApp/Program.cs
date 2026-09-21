using ClubeLeitura.ConsoleApp.Apresentacao;

RepositorioCaixa repositorioCaixa = new RepositorioCaixa();

TelaCaixa telaCaixa = new TelaCaixa();
telaCaixa.repositorioCaixa = repositorioCaixa;

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
                    telaCaixa.CadastrarCaixa();
                    break;
                case ("2")
                    :
                    telaCaixa.EditarCaixa();
                    break;

                case ("3")
                    :
                    telaCaixa.ExcluirCaixa();
                    break;

                case ("4")
                    :
                    telaCaixa.VisualizarCaixas();
                    break;
            }
        }

        else if (opcaoMenuPrincipal == "2")
        {

        }

        else if (opcaoMenuPrincipal == "3")
        {

        }

        else if (opcaoMenuPrincipal == "4")
        {

        }
    }
}