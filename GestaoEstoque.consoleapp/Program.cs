using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoEstoque

{

    #region Requisito 1
    /*Como funcionário, Junior quer ter a possibilidade de registrar equipamentos  
         •  Deve ter um nome com no mínimo 6 caracteres;  
         •  Deve ter um preço de aquisição;  
         •  Deve ter um número de série;  
         •  Deve ter uma data de fabricação;  
         •  Deve ter uma fabricante;   */
    #endregion

    #region Requisito 2 
    /*Como funcionário, Junior quer ter a possibilidade de visualizar todos os equipamentos registrados em seu inventário.  
         •  Deve mostrar o número;  
         •  Deve mostrar o nome;  
         •  Deve mostrar o preço; 
         •  Deve mostrar a fabricante;   
         •  Deve mostrar a data de fabricação; */
    #endregion

    #region Requisito 3
    /*Como funcionário, Junior quer ter a possibilidade de editar um equipamento, sendo que ele possa editar todos os campos.   
     •  Deve ter os mesmos critérios que o Requisito 1.*/
    #endregion

    #region Requisito 4
    /*Como funcionário, Junior quer ter a possibilidade de excluir um equipamento que esteja registrado. 
         •  A lista de equipamentos deve ser atualizada .*/
    #endregion

    #region Requisito 5
    /*Como funcionário Junior quer ter a possibilidade de registrar os chamados de manutenções que são efetuadas nos equipamentos registrados  
         •  Deve ter a título do chamado;  
         •  Deve ter a descrição do chamado;  
         •  Deve ter um equipamento;  
         •  Deve ter uma data de abertura;  */
    #endregion

    #region Requisito 6
    /*Como funcionário Junior quer ter a possibilidade de visualizar todos os chamados registrados para controle.   
         •  Deve mostrar o título do chamado;  
         •  Deve mostrar o equipamento;  
         •  Deve mostrar a data de abertura;  
         •  Número de dias que o chamado está aberto  */
    #endregion

    #region Requisito 7
    /*Como funcionário Junior quer ter a possibilidade de editar um chamado que esteja registrado, sendo que ele possa editar todos os campos.   
         •  Deve ter os mesmos critérios que o Requisito 5.  .*/
    #endregion

    #region Requisito 8
    /*Como funcionário Junior quer ter a possibilidade de excluir um chamado.
     * */
    #endregion
    class Program
    {
        static void Main(string[] args)
        {

            int opcao;

            Console.WriteLine("Gestão de Estoque para Materiais Diversos");

        GT:

            Console.Clear();

            opcao = MenuOpcao();

            if (opcao == 1)
            {
                DateTime[] data;
                string[] nome, fabricante;
                int contadorId;
                double[] preco;
                int[] serie;

                DadosProduto(out data, out nome, out fabricante, out contadorId, out preco, out serie);

                while (true)
                {
                    int opcaoEquipamento = eHOpcaoEquipamento(data, nome, fabricante, ref contadorId, preco, serie);

                    if (opcaoEquipamento == 4)

                        EhOpcaoVizualizarEquipamento(data, nome, fabricante, contadorId, preco, serie);

                    else if (opcaoEquipamento == 5)

                    {
                        goto GT;
                    }

                }
            }

            if (opcao == 2)

            {
                Console.Clear();

                DateTime[] data;
                string[] nome, descricao, equipamentos;
                int contadorId;
                Ehformulario(out data, out nome, out descricao, out equipamentos, out contadorId);

                while (true)

                {
                    Console.Clear();

                    int opcaoChamado;
                    opcaoChamado = MenudeChamados(data, nome, descricao, equipamentos, ref contadorId);

                    if (opcaoChamado == 4)

                    {
                        EhOpcaoListarChamados(data, nome, descricao, equipamentos, contadorId);
                    }

                    else if (opcaoChamado == 5)

                    {
                        goto GT;
                    }
                }
            }

            if (opcao == 3)

            {
                Environment.Exit(0);
            }

        }

        private static int eHOpcaoEquipamento(DateTime[] data, string[] nome, string[] fabricante, ref int contadorId, double[] preco, int[] serie)
        {
            int opcaoEquipamento = OpcaoDoMenuEquipamento();

            contadorId = CadastroProduto(data, nome, fabricante, contadorId, preco, serie, opcaoEquipamento);

            EhOpcaoEditarCadastro(data, nome, fabricante, contadorId, preco, serie, opcaoEquipamento);

            eHopcaoBuscaEquipamento(data, nome, fabricante, contadorId, preco, serie, opcaoEquipamento);
            return opcaoEquipamento;
        }

        private static int MenudeChamados(DateTime[] data, string[] nome, string[] descricao, string[] equipamentos, ref int contadorId)
        {
            int opcaoChamado;
            MenuOpcaoDosChamados();

            opcaoChamado = Convert.ToInt32(Console.ReadLine());

            contadorId = EhOpcaoAbrirChamados(data, nome, descricao, equipamentos, contadorId, opcaoChamado);
            EhOpcaoEditarChamados(data, nome, descricao, equipamentos, contadorId, opcaoChamado);

            EhopcaoDeletarChamados(data, nome, descricao, equipamentos, contadorId, opcaoChamado);
            return opcaoChamado;
        }

        private static void Ehformulario(out DateTime[] data, out string[] nome, out string[] descricao, out string[] equipamentos, out int contadorId)
        {
            data = new DateTime[100];
            nome = new string[100];
            descricao = new string[100];
            equipamentos = new string[100];
            contadorId = 0;
            Console.Clear();
        }

        private static void EhOpcaoListarChamados(DateTime[] data, string[] nome, string[] descricao, string[] equipamentos, int contadorId)
        {
            for (int i = 0; i < contadorId; i++)

            {
                string diasDif = (DateTime.Now - data[i]).ToString("dd");
                Console.WriteLine($"Título:{nome[i]} descrição: {descricao[i]} equipamento: {equipamentos[i]} dias em aberto: {diasDif}");
            }
            Console.ReadLine();
        }

        private static void EhopcaoDeletarChamados(DateTime[] data, string[] nome, string[] descricao, string[] equipamentos, int contadorId, int opcaoChamado)
        {
            if (opcaoChamado == 3)

            {
                Console.Clear();

                Console.WriteLine("Digite o nome para deletar: ");
                string titulo = Console.ReadLine();

                for (int i = 0; i < contadorId; i++)

                {
                    if (nome[i] == titulo)
                    {

                        nome[i] = "";
                        descricao[i] = "";
                        equipamentos[i] = "";
                        data[i] = Convert.ToDateTime("0000,00,00");
                    }
                }

            }
        }

        private static void EhOpcaoEditarChamados(DateTime[] data, string[] nome, string[] descricao, string[] equipamentos, int contadorId, int opcaoChamado)
        {
            if (opcaoChamado == 2)

            {
                Console.Clear();

                Console.WriteLine("Digite a titulo do chamado para editar: ");
                string titulo = Console.ReadLine();

                for (int i = 0; i < contadorId; i++)

                {
                    if (nome[i] == titulo)
                    {
                        Console.Clear();

                        Console.WriteLine("Digite título do chamado: ");
                        nome[i] = Console.ReadLine();

                        Console.WriteLine("Digite descricao do produto: ");
                        descricao[i] = Console.ReadLine();

                        Console.WriteLine("Digite equipamento: ");
                        equipamentos[i] = Console.ReadLine();

                        Console.WriteLine("Digite data:(YYYY,MM,DD)");
                        data[contadorId] = Convert.ToDateTime(Console.ReadLine());

                    }
                }

            }
        }

        private static int EhOpcaoAbrirChamados(DateTime[] data, string[] nome, string[] descricao, string[] equipamentos, int contadorId, int opcaoChamado)
        {
            if (opcaoChamado == 1)

            {
                Console.Clear();

                Console.WriteLine("Digite um título para o chamado : ");
                nome[contadorId] = Console.ReadLine();

                Console.WriteLine("Digite descricao do produto: ");
                descricao[contadorId] = Console.ReadLine();

                Console.WriteLine("Digite qual equipamento: ");
                equipamentos[contadorId] = Console.ReadLine();

                Console.WriteLine("Digite data:(YYYY,MM,DD)");
                data[contadorId] = Convert.ToDateTime(Console.ReadLine());

                contadorId++;

            }

            return contadorId;
        }

        private static void MenuOpcaoDosChamados()
        {
            Console.WriteLine("Digite a opção: ");

            Console.WriteLine("Digite a opção: 1 Para Abrir Chamado.");

            Console.WriteLine("2 Para editar Chamados.");

            Console.WriteLine("3 Para excluir Chamados.");

            Console.WriteLine("4 Para listar Chamados.");

            Console.WriteLine("5 Para sair.");
        }

        private static int MenuOpcao()
        {
            int opcao;
            Console.WriteLine("Digite a opção: 1 Para equipamentos.");

            Console.WriteLine("2 Para Chamados.");

            Console.WriteLine("3 Para Sair.");

            opcao = Convert.ToInt32(Console.ReadLine());
            return opcao;
        }

        private static void EhOpcaoVizualizarEquipamento(DateTime[] data, string[] nome, string[] fabricante, int contadorId, double[] preco, int[] serie)
        {
            for (int i = 0; i < contadorId; i++)
            {
                Console.WriteLine($"ID:{serie[i]} nome: {nome[i]} fabricante: {fabricante[i]} preco: {preco[i]} data: {data[i]}");
            }
            Console.ReadLine();
        }

        private static void eHopcaoBuscaEquipamento(DateTime[] data, string[] nome, string[] fabricante, int contadorId, double[] preco, int[] serie, int opcaoEquipamento)
        {
            if (opcaoEquipamento == 3)

            {
                Console.Clear();

                Console.WriteLine("Digite ID do produto para edição: ");
                int serieBusca = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < contadorId; i++)

                {
                    if (serie[i] == serieBusca)
                    {

                        serie[i] = 0;
                        nome[i] = "";
                        fabricante[i] = "";

                        preco[i] = 0;


                        data[i] = Convert.ToDateTime("0000,00,00");
                    }
                }
            }
        }

        private static void EhOpcaoEditarCadastro(DateTime[] data, string[] nome, string[] fabricante, int contadorId, double[] preco, int[] serie, int opcaoEquipamento)
        {
            if (opcaoEquipamento == 2)

            {
                Console.Clear();

                Console.WriteLine("Digite o ID do produto para editar: ");
                int serieBusca = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < contadorId; i++)
                {
                    if (serie[i] == serieBusca)
                    {
                        Console.WriteLine("Digite Numero de Série: ");
                        serie[i] = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Digite nome do produto: ");
                        nome[i] = Console.ReadLine();

                        Console.WriteLine("Digite fabricante do produto: ");
                        fabricante[i] = Console.ReadLine();

                        Console.WriteLine("Digite preço: ");
                        preco[i] = Convert.ToDouble(Console.ReadLine());

                        Console.WriteLine("Digite data:(YYYY,MM,DD)");
                        data[contadorId] = Convert.ToDateTime(Console.ReadLine());

                    }
                }

            }
        }

        private static int CadastroProduto(DateTime[] data, string[] nome, string[] fabricante, int contadorId, double[] preco, int[] serie, int opcaoEquipamento)
        {
            if (opcaoEquipamento == 1)
            {
                Console.Clear();

                Console.WriteLine("Digite Numero de Series: ");
                serie[contadorId] = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Digite nome do produto: ");
                nome[contadorId] = Console.ReadLine();

                Console.WriteLine("Digite fabricante do produto: ");
                fabricante[contadorId] = Console.ReadLine();

                Console.WriteLine("Digite preço: ");
                preco[contadorId] = Convert.ToDouble(Console.ReadLine());


                Console.WriteLine("Digite data:(DD,MM,YYYY)");
                data[contadorId] = Convert.ToDateTime(Console.ReadLine());

                contadorId++;

            }

            return contadorId;
        }

        private static int OpcaoDoMenuEquipamento()
        {
            Console.Clear();

            int opcaoEquipamento;
            Console.WriteLine("Digite a opção: 1 Para adicionar ");

            Console.WriteLine("Digite a opção: 2 Para Editar.");

            Console.WriteLine("3 Para Deletar.");

            Console.WriteLine("4 Para Vizualizar.");

            Console.WriteLine("5 Para sair.");

            opcaoEquipamento = Convert.ToInt32(Console.ReadLine());
            return opcaoEquipamento;
        }

        private static void DadosProduto(out DateTime[] data, out string[] nome, out string[] fabricante, out int contadorId, out double[] preco, out int[] serie)
        {
            Console.Clear();

            data = new DateTime[100];
            nome = new string[100];
            fabricante = new string[100];
            contadorId = 0;
            preco = new double[100];
            serie = new int[100];
            Console.Clear();
        }
    }
}