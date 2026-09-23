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

TelaPrincipal telaPrincipal = new TelaPrincipal();

while (true)
{
    string? opcaoMenuPrincipal = telaPrincipal.ApresentarMenuPrincipal();

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

            if (opcaoMenuInterno == "1")
            {
                telaCaixa.Cadastrar();
            }
            else if (opcaoMenuInterno == "2")
            {
                telaCaixa.Editar();
            }
            else if (opcaoMenuInterno == "3")
            {
                telaCaixa.Excluir();
            }
            else if (opcaoMenuInterno == "4")
            {
                telaCaixa.VisualizarTodos(true);
            }

        }

        else if (opcaoMenuPrincipal == "2")
        {
            opcaoMenuInterno = telaRevista.ObterOpcaoMenu();

            if (opcaoMenuInterno == "S")
                break;

            if (opcaoMenuInterno == "1")
                telaRevista.Cadastrar();

            else if (opcaoMenuInterno == "2")
                telaRevista.Editar();

            else if (opcaoMenuInterno == "3")
                telaRevista.Excluir();

            else if (opcaoMenuInterno == "4")
                telaRevista.VisualizarTodos(Continuar: true);
        }

        else if (opcaoMenuPrincipal == "3")
        {
            opcaoMenuInterno = telaAmigo.ObterOpcaoMenu();

            if (opcaoMenuInterno == "S")
                break;

            if (opcaoMenuInterno == "1")
                telaAmigo.Cadastrar();

            else if (opcaoMenuInterno == "2")
                telaAmigo.Editar();

            else if (opcaoMenuInterno == "3")
                telaAmigo.Excluir();

            else if (opcaoMenuInterno == "4")
                telaAmigo.VisualizarTodos(Continuar: true);
        }

        else if (opcaoMenuPrincipal == "4")
        {
            opcaoMenuInterno = telaEmprestimo.ObterOpcaoMenu();

            if (opcaoMenuInterno == "S")
                break;

            if (opcaoMenuInterno == "1")
            {
                telaEmprestimo.AbrirEmprestimo();
            }
            else if (opcaoMenuInterno == "2")
            {
                telaEmprestimo.FecharEmprestimo();
            }
            else if (opcaoMenuInterno == "3")
            {
                telaEmprestimo.VisualizarTodos(continuar: true, exibirCabecalho: true);
            }

        }
    }
}