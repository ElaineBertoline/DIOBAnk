using System;
using System.Collections.Generic;

namespace DIO.Bank
{
    class Program
    {
       // private const string ParamName = "Valor não encontrado";

        //armazenar em memoria as contas bancarias
        static List<Conta> listContas = new List<Conta>();
        //criando uma lista para armazenar os dados na memoria 

        
        static void Main(string[] args)
        {
           string opcaoUsuario = ObterOpcaoUsuario();

           while (opcaoUsuario.ToUpper() != "x")
           {
               switch (opcaoUsuario)
               {
                   case "1":
                         ListarContas();
                   break;
                   case "2":
                        InserirConta();
                   break;
                   case "3":
                        Transferir();
                   break;
                    case "4":
                        Sacar();
                   break;
                    case "5":
                        Depositar();
                   break;
                   case "C":
                   Console.Clear();
                   break;

                   default:
						throw new ArgumentOutOfRangeException();
                        
               }
               opcaoUsuario = ObterOpcaoUsuario();
           }
            Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
        }

         private static void InserirConta()
        {
            Console.WriteLine("Inserir nova Conta");

            Console.Write("Digite 1 para Conta Fisica ou 2 para Jurídica: ");
            int entradaTipoConta = int.Parse(Console.ReadLine());
            
            Console.Write("Digite o Nome do cliente : ");
            string entradaNome = Console.ReadLine();

            Console.Write("Digite o Saldo inicial : ");
            double entradaSaldo = double.Parse(Console.ReadLine());
            
            Console.Write("Digite o credito: ");
            double entradaCredito = double.Parse(Console.ReadLine());

           //criando um novo objeto, uma nova instancia do objeto conta
            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
                                         saldo: entradaSaldo,
                                         credito: entradaCredito,
                                         nome: entradaNome);
            listContas.Add(novaConta);                           

            
        }
        private static void Depositar()
        {
            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());
            
            Console.Write("Digite o valor a ser depositado ");
            double valorDeposito = double.Parse(Console.ReadLine());
        
        listContas[indiceConta].Depositar(valorDeposito);
        // conta indexada
        //retorna um objeto daquele indice 
     
        
        }
        private static void Sacar()
        {
            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());
            
            Console.Write("Digite o valor a ser sacado: ");
            double valorSaque = double.Parse(Console.ReadLine());
        
        listContas[indiceConta].Sacar(valorSaque);
        // conta indexada
        //retorna um objeto daquele indice 4

        
        }

       

        private static void Transferir()
		{
			Console.Write("Digite o número da conta de origem: ");
			int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.Write("Digite o número da conta de destino: ");
			int indiceContaDestino = int.Parse(Console.ReadLine());

			Console.Write("Digite o valor a ser transferido: ");
			double valorTransferencia = double.Parse(Console.ReadLine());

            listContas[indiceContaOrigem].Transferir(valorTransferencia, listContas[indiceContaDestino]);
		}

        

        private static void ListarContas()
        {
            Console.WriteLine("Listar contas");
            if (listContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada ");
                return;
            }
            for (int i = 0; i < listContas.Count; i++)
            {
                Conta conta = listContas[i];
                Console.Write("#{0} - ", i);
                Console.WriteLine(conta);
            }
        }

       

        private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("DIO Bank a seu dispor!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar contas");
			Console.WriteLine("2- Inserir nova conta");
			Console.WriteLine("3- Transferir");
			Console.WriteLine("4- Sacar");
			Console.WriteLine("5- Depositar");
            Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
    }
}
