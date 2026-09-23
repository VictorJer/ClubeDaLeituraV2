using ClubeLeitura.ConsoleApp.Dominio.Base;
using ClubeLeitura.ConsoleApp.Intraestrutura.Base;

namespace ClubeLeitura.ConsoleApp.Apresentacao.Base
{
    public abstract class TelaBase : ITela
    {
        public string nomeEntidade = string.Empty;
        private RepositorioBase repositorio;

        public TelaBase(string nomeEntidade, RepositorioBase repositorio)
        {
            this.nomeEntidade = nomeEntidade;
            this.repositorio = repositorio;
        }
        public string? ObterOpcaoMenu()
        {
            Console.Clear();
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Clube da Leitura");
            Console.WriteLine("---------------------------------");
            Console.WriteLine($"1 - Cadastrar {nomeEntidade}");
            Console.WriteLine($"2 - Editar {nomeEntidade}");
            Console.WriteLine($"3 - Excluir {nomeEntidade}");
            Console.WriteLine($"4 - Visualizar {nomeEntidade}s");
            Console.WriteLine("S - Sair");
            Console.WriteLine("---------------------------------");
            Console.Write("> ");
            string? opcaoMenuInterno = Console.ReadLine()?.ToUpper();

            return opcaoMenuInterno;
        }
        public void Cadastrar()
        {
            Cabesalho($"Cadastro de {nomeEntidade}");

            EntidadeBase Entidade = ObterDadosCadastrais();

            string[] erros = Entidade.Validar();

            if (erros.Length > 0)
            {
                for (int i = 0; i < erros.Length; i++)
                {
                    Console.WriteLine(erros[i]);
                }

                Console.WriteLine("Pressione ENTER para continuar...");
                Console.ReadLine();

                Cadastrar();
                return;
            }

            var result = repositorio.Cadastrar(Entidade);

            if (result)
            {
                ExibirMensagem($" {nomeEntidade} cadastrada com sucesso!");
            }
            else
            {
                ExibirMensagem("Não foi possível cadastrar");
            }
        }
        public void Editar()
        {
            Cabesalho($"Edição de {nomeEntidade}");
            string idSelecionado = string.Empty;

            VisualizarTodos(false);

            while (true)
            {
                Console.WriteLine($"Digite o ID da {nomeEntidade} que deseja editar: ");
                idSelecionado = Console.ReadLine() ?? string.Empty;

                if (string.IsNullOrWhiteSpace(idSelecionado))
                {
                    Console.WriteLine("O ID não pode ser vazio. Por favor, digite novamente.");
                    continue;
                }

                break;
            }

            EntidadeBase entidadeNova = ObterDadosCadastrais();

            string[] erros = entidadeNova.Validar();
            if (erros.Length > 0)
            {
                for (int i = 0; i < erros.Length; i++)
                {
                    Console.WriteLine(erros[i]);
                }

                Console.WriteLine("Pressione ENTER para continuar...");
                Console.ReadLine();

                Editar();
                return;
            }

            var result = repositorio.Editar(idSelecionado, entidadeNova);

            if (result)
            {
                ExibirMensagem($"{nomeEntidade} editada com sucesso!");
            }
            else
            {
                ExibirMensagem("Não foi possível editar a {nomeEntidade}");
            }
        }
        public void Excluir()
        {
            Cabesalho($"Exclusão de {nomeEntidade}");

            string idSelecionado = string.Empty;

            VisualizarTodos(false);

            while (true)
            {
                Console.WriteLine($"Digite o ID da {nomeEntidade} que deseja excluir: ");
                idSelecionado = Console.ReadLine() ?? string.Empty;

                if (string.IsNullOrWhiteSpace(idSelecionado))
                {
                    Console.WriteLine("O ID não pode ser vazio. Por favor, digite novamente.");
                    continue;
                }

                break;
            }

            var result = repositorio.Excluir(idSelecionado);

            if (result)
            {
                ExibirMensagem($"{nomeEntidade} excluída com sucesso!");
            }
            else
            {
                ExibirMensagem($"Não foi possível excluir a {nomeEntidade}");
            }
        }
        protected void Cabesalho(string titulo)
        {
            Console.Clear();
            Console.WriteLine("---------------------------------");
            Console.WriteLine($"Clube da {nomeEntidade}");
            Console.WriteLine("---------------------------------");
            Console.WriteLine(titulo);
            Console.WriteLine("---------------------------------");
        }
        protected void ExibirMensagem(string mensagem)
        {
            Console.WriteLine(mensagem);
            Console.WriteLine("Pressione ENTER para continuar...");
            Console.ReadLine();
        }
        protected abstract EntidadeBase ObterDadosCadastrais();
        public abstract void VisualizarTodos(bool Continuar);
    }
}