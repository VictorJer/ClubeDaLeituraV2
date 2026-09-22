using ClubeLeitura.ConsoleApp.Dominio;

namespace ClubeLeitura.ConsoleApp.Apresentacao;

public class TelaCaixa : TelaBase
{
    private RepositorioCaixa repositorioCaixa;

    public TelaCaixa(RepositorioCaixa repositorioCaixa)
    {
        this.repositorioCaixa = repositorioCaixa;
    }
    public string ObterOpcaoMenu()
    {
        Console.Clear();
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Clube da Leitura");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("1 - Cadastrar caixa de revista");
        Console.WriteLine("2 - Editar caixa de revista");
        Console.WriteLine("3 - Excluir caixa de revista");
        Console.WriteLine("4 - Visualizar caixas de revistas");
        Console.WriteLine("S - Sair");
        Console.WriteLine("---------------------------------");
        Console.Write("> ");
        string? opcaoMenuPrincipal = Console.ReadLine()?.ToUpper();

        return opcaoMenuPrincipal;
    }

    public void CadastrarCaixa()
    {
        Cabesalho("Cadastro de caixa de revista");

        Caixa novaCaixa = ObterDadosCadastrais();

        string[] erros = novaCaixa.Validar();

        if (erros.Length > 0)
        {
            for (int i = 0; i < erros.Length; i++)
            {
                Console.WriteLine(erros[i]);
            }

            Console.WriteLine("Pressione ENTER para continuar...");
            Console.ReadLine();
            CadastrarCaixa();
            return;
        }

        var result = repositorioCaixa.Cadastrar(novaCaixa);

        if (result)
        {
            ExibirMensagem("Caixa cadastrada com sucesso!");
        }
        else
        {
            ExibirMensagem("Não foi possível cadastrar a caixa. ID já existente.");
        }
    }

    public void EditarCaixa()
    {
        Cabesalho("Edição de caixa de revista");
        string idSelecionado = string.Empty;

        VisualizarCaixas(false);
        while (true)
        {
            Console.WriteLine("Digite o ID da caixa que deseja editar: ");
            idSelecionado = Console.ReadLine() ?? string.Empty;

            if (string.IsNullOrWhiteSpace(idSelecionado))
            {
                Console.WriteLine("O ID não pode ser vazio. Por favor, digite novamente.");
                continue;
            }

            break;
        }

        Caixa caixaAtualizada = ObterDadosCadastrais();

        string[] erros = caixaAtualizada.Validar();
        if (erros.Length > 0)
        {
            for (int i = 0; i < erros.Length; i++)
            {
                Console.WriteLine(erros[i]);
            }

            Console.WriteLine("Pressione ENTER para continuar...");
            Console.ReadLine();
            EditarCaixa();
            return;
        }

        var result = repositorioCaixa.Editar(idSelecionado, caixaAtualizada);

        if (result)
        {
            ExibirMensagem("Caixa editada com sucesso!");
        }
        else
        {
            ExibirMensagem("Não foi possível editar a caixa. ID não encontrado.");
        }
    }

    public void ExcluirCaixa()
    {
        Cabesalho("Exclusão de caixa de revista");

        string idSelecionado = string.Empty;

        VisualizarCaixas(false);

        while (true)
        {
            Console.WriteLine("Digite o ID da caixa que deseja excluir: ");
            idSelecionado = Console.ReadLine() ?? string.Empty;

            if (string.IsNullOrWhiteSpace(idSelecionado))
            {
                Console.WriteLine("O ID não pode ser vazio. Por favor, digite novamente.");
                continue;
            }

            break;
        }

        var result = repositorioCaixa.Excluir(idSelecionado);

        if (result)
        {
            ExibirMensagem("Caixa excluída com sucesso!");
        }
        else
        {
            ExibirMensagem("Não foi possível excluir a caixa. ID não encontrado.");
        }
    }

    public void VisualizarCaixas(bool aguardar)
    {
        Cabesalho("Visualização de caixas de revistas");

        EntidadeBase?[] caixas = repositorioCaixa.SelecionarTodos();

        if (caixas.Length == 0)
        {
            Console.WriteLine("Nenhuma caixa cadastrada.");
            Console.WriteLine("Pressione ENTER para continuar...");
            Console.ReadLine();
            return;
        }

        Console.WriteLine("{0,-10} | {1,-20} | {2,-10} | {3,-15}",
                             "ID", "Etiqueta", "Cor", "Dias de Empréstimo");

        for (int i = 0; i < caixas.Length; i++)
        {
            Caixa caixa = (Caixa?)caixas[i];

            if (caixas[i] == null)
                continue;

            Console.WriteLine("{0,-10} | {1,-20} | {2,-10} | {3,-15}",
                              caixa.Id, caixa.Etiqueta, caixa.Cor, caixa.DiasEmprestimo);
        }

        if (aguardar)
        {
            Console.WriteLine("Pressione ENTER para continuar...");
            Console.ReadLine();
        }
    }

    private Caixa ObterDadosCadastrais()
    {
        string Etiqueta = string.Empty;
        string Cor = string.Empty;
        int diasEmprestimo = 7;

        while (true)
        {
            Console.Write("Digite a etiqueta da caixa: ");
            Etiqueta = Console.ReadLine() ?? string.Empty;

            if (string.IsNullOrWhiteSpace(Etiqueta))
            {
                Console.WriteLine("A etiqueta não pode ser vazia. Por favor, digite novamente.");
                continue;
            }

            break;
        }

        while (true)
        {
            Console.WriteLine("1 - Azul");
            Console.WriteLine("2 - Vermelho");
            Console.WriteLine("3 - Verde");
            Console.WriteLine("4 - Branco");
            Console.Write("Escolha a cor da caixa (1-4): ");
            Cor = Console.ReadLine() ?? string.Empty;

            if (string.IsNullOrWhiteSpace(Cor))
            {
                Console.WriteLine("A cor não pode ser vazia. Por favor, digite novamente.");
                continue;
            }

            if (Cor != "1" && Cor != "2" && Cor != "3" && Cor != "4")
            {
                Console.WriteLine("Opção inválida. Por favor, digite novamente.");
                continue;
            }

            if (Cor == "1")
                Cor = "Azul";
            else if (Cor == "2")
                Cor = "Vermelho";
            else if (Cor == "3")
                Cor = "Verde";
            else if (Cor == "4")
                Cor = "Branco";

            break;
        }

        while (true)
        {
            Console.WriteLine("Digite a quantidade de dias para empréstimo (padrão é 7): ");
            diasEmprestimo = Convert.ToInt32(Console.ReadLine());
            if (diasEmprestimo <= 0)
            {
                Console.WriteLine("A quantidade de dias de empréstimo deve ser um número inteiro positivo. Por favor, digite novamente.");
                continue;
            }
            break;
        }

        Caixa novaCaixa = new Caixa(Etiqueta, Cor, diasEmprestimo);
        return novaCaixa;
    }


}