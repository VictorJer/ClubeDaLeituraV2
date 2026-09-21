using ClubeLeitura.ConsoleApp.Dominio;

namespace ClubeLeitura.ConsoleApp.Apresentacao;

public class TelaCaixa
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

        var result = repositorioCaixa.Cadastrar(novaCaixa);

        if (result)
        {
            Console.WriteLine("Caixa cadastrada com sucesso!");
            Console.WriteLine("Pressione ENTER para continuar...");
            Console.ReadLine();
        }
        else
        {
            Console.WriteLine("Não foi possível cadastrar a caixa. Limite de caixas atingido.");
            Console.WriteLine("Pressione ENTER para continuar...");
            Console.ReadLine();
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


        var result = repositorioCaixa.Editar(idSelecionado, caixaAtualizada);

        if (result)
        {
            Console.WriteLine("Caixa editada com sucesso!");
            Console.WriteLine("Pressione ENTER para continuar...");
            Console.ReadLine();
        }
        else
        {
            Console.WriteLine("Não foi possível editar a caixa. ID não encontrado.");
            Console.WriteLine("Pressione ENTER para continuar...");
            Console.ReadLine();
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

        repositorioCaixa.Excluir(idSelecionado);
    }

    public void VisualizarCaixas(bool aguardar)
    {
        Cabesalho("Visualização de caixas de revistas");

        Caixa[] caixas = repositorioCaixa.SelecionarTodos();

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
            if (caixas[i] == null)
                continue;

            Console.WriteLine("{0,-10} | {1,-20} | {2,-10} | {3,-15}",
                              caixas[i].Id, caixas[i].Etiqueta, caixas[i].Cor, caixas[i].DiasEmprestimo);
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

    public void Cabesalho(string titulo)
    {
        Console.Clear();
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Clube da Leitura");
        Console.WriteLine("---------------------------------");
        Console.WriteLine(titulo);
        Console.WriteLine("---------------------------------");
    }
}