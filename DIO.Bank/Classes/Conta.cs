using System;  
//para usar as funçoes do console

namespace DIO.Bank
{
    public class Conta
    {
        //propriedades 3
        private TipoConta TipoConta { get; set; }
//enum= valores predefinidos que posso ter na aplicação, valores enumerados 
         private double Saldo { get; set; }
          private double Credito { get; set; }
           private string Nome { get; set; }
    
  //encapsulamento 
  //método construtor = chamado no momento que é criado meu objeto
   public Conta(TipoConta tipoConta, double saldo, double credito, string nome)
   {

       //this- altera apenas aquela instancia 
       this.TipoConta = tipoConta;
       this.Saldo = saldo;
       this.Credito = credito;
       this.Nome = nome;
        }     
   //vamos criar os metodos com as acoes que teremos na conta 
   //metodo sacae precisa ter o valor , se conseguir retorna true
  //metodo sacar
   public bool Sacar(double valorSaque)
   {
       if (this.Saldo - valorSaque < (this.Credito *-1)){
           Console.WriteLine("Saldo insuficiente!");
           return false;
       }
       this.Saldo -= valorSaque;
       Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);
   
    return true;
     }
      public void Depositar(double valorDeposito)
   {
      this.Saldo += valorDeposito;
     
       Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);
   }
   public void Transferir(double valorTransferencia, Conta contaDestino)
		{
			if (this.Sacar(valorTransferencia)){
                contaDestino.Depositar(valorTransferencia);
            }
		}
        
    //geralmente usado parab logs ou representar no console esta instancia 
    //gravar log 
        public override string ToString()
        {
            string retorno = "";
            retorno += "TipoConta" + this.TipoConta + " | ";
            retorno += "Nome" + this.Nome + " | ";
            retorno += "Saldo" + this.Saldo + " | ";
            retorno += "Credito" + this.Credito ;
            return retorno;
         }
    }
}
