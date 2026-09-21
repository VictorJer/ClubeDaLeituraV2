using ClubeLeitura.ConsoleApp.Dominio;

namespace ClubeLeitura.ConsoleApp.Apresentacao;

public class TelaCaixa
{
    public RepositorioCaixa repositorioCaixa;
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

        string Etiqueta = string.Empty;
        string Cor = string.Empty;

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

        Caixa caixa = new Caixa(Etiqueta, Cor);


    }

    public void EditarCaixa()
    {
        Cabesalho("Edição de caixa de revista");
    }

    public void ExcluirCaixa()
    {
        Cabesalho("Exclusão de caixa de revista");
    }

    public void VisualizarCaixas()
    {
        Cabesalho("Visualização de caixas de revistas");
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