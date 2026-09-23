using ClubeLeitura.ConsoleApp.Apresentacao;
using ClubeLeitura.ConsoleApp.Apresentacao.Base;
using ClubeLeitura.ConsoleApp.Intraestrutura;

RepositorioAmigo repositorioAmigo = new RepositorioAmigo();
RepositorioCaixa repositorioCaixa = new RepositorioCaixa();
RepositorioRevista repositorioRevista = new RepositorioRevista();
RepositorioEmprestimo repositorioEmprestimo = new RepositorioEmprestimo();

TelaPrincipal telaPrincipal = new TelaPrincipal(repositorioAmigo, repositorioCaixa, repositorioRevista, repositorioEmprestimo);

while (true)
{
    TelaBase? telaSelecionada = telaPrincipal.ApresentarMenuPrincipal();

    if (telaSelecionada == null)
    {
        Console.Clear();
        break;
    }

    while (true)
    {
        string? opcaoMenuInterno = telaSelecionada.ObterOpcaoMenu();

        if (opcaoMenuInterno == "S")
            break;

        if (opcaoMenuInterno == "1")
        {
            telaSelecionada.Cadastrar();
        }
        else if (opcaoMenuInterno == "2")
        {
            telaSelecionada.Editar();
        }
        else if (opcaoMenuInterno == "3")
        {
            telaSelecionada.Excluir();
        }
        else if (opcaoMenuInterno == "4")
        {
            telaSelecionada.VisualizarTodos(true);
        }


        // else if (opcaoMenuPrincipal == "4")
        // {
        //     opcaoMenuInterno = telaEmprestimo.ObterOpcaoMenu();

        //     if (opcaoMenuInterno == "S")
        //         break;

        //     if (opcaoMenuInterno == "1")
        //     {
        //         telaEmprestimo.AbrirEmprestimo();
        //     }
        //     else if (opcaoMenuInterno == "2")
        //     {
        //         telaEmprestimo.FecharEmprestimo();
        //     }
        //     else if (opcaoMenuInterno == "3")
        //     {
        //         telaEmprestimo.VisualizarTodos(continuar: true, exibirCabecalho: true);
        //     }

        // }
    }
}