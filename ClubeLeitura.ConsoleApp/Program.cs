using ClubeLeitura.ConsoleApp.Apresentacao;
using ClubeLeitura.ConsoleApp.Apresentacao.Base;
using ClubeLeitura.ConsoleApp.Intraestrutura;

RepositorioAmigo repositorioAmigo = new RepositorioAmigo();
RepositorioCaixa repositorioCaixa = new RepositorioCaixa();
RepositorioRevista repositorioRevista = new RepositorioRevista();
RepositorioEmprestimo repositorioEmprestimo = new RepositorioEmprestimo();
RepositorioReserva repositorioReserva = new RepositorioReserva();

TelaPrincipal telaPrincipal = new TelaPrincipal(repositorioAmigo, repositorioCaixa, repositorioRevista, repositorioEmprestimo, repositorioReserva);

while (true)
{
    ITela? telaSelecionada = telaPrincipal.ApresentarMenuPrincipal();

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

        if (telaSelecionada is TelaBase telaBase)
        {
            if (opcaoMenuInterno == "1")
            {
                telaBase.Cadastrar();
            }
            else if (opcaoMenuInterno == "2")
            {
                telaBase.Editar();
            }
            else if (opcaoMenuInterno == "3")
            {
                telaBase.Excluir();
            }
            else if (opcaoMenuInterno == "4")
            {
                telaBase.VisualizarTodos(true);
            }
        }

        else if (telaSelecionada is TelaEmprestimo telaEmprestimo)
        {
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

        else if (telaSelecionada is TelaReserva telaReserva)
        {
            if (opcaoMenuInterno == "1")
            {
                telaReserva.Iniciar();
            }

            else if (opcaoMenuInterno == "2")
            {
                telaReserva.Concluir();
            }

            else if (opcaoMenuInterno == "3")
            {
                telaReserva.VisualizarTodos(deveExibirCabecalho: true);
            }
        }
    }
}