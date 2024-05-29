﻿namespace bytebank.Modelos.Conta
{
	public class ContaCorrente:IComparable<ContaCorrente>
	{
		private int _numero_agencia;

		private string _conta;

		private double saldo;

		public Cliente Titular { get; set; }

		public string Nome_Agencia { get; set; }

		public int Numero_agencia
		{
			get
			{
				return _numero_agencia;
			}
			set
			{
				if (value > 0)
				{
					_numero_agencia = value;
				}
			}
		}

		public string Conta
		{
			get
			{
				return _conta;
			}
			set
			{
				if (value != null)
				{
					_conta = value;
				}
			}
		}

		public double Saldo
		{
			get
			{
				return saldo;
			}
			set
			{
				if (!(value < 0.0))
				{
					saldo = value;
				}
			}
		}

		public static int TotalDeContasCriadas { get; set; }

		public bool Sacar(double valor)
		{
			if (saldo < valor)
			{
				return false;
			}
			if (valor < 0.0)
			{
				return false;
			}
			saldo -= valor;
			return true;
		}

		public void Depositar(double valor)
		{
			if (!(valor < 0.0))
			{
				saldo += valor;
			}
		}

		public bool Transferir(double valor, ContaCorrente destino)
		{
			if (saldo < valor)
			{
				return false;
			}
			if (valor < 0.0)
			{
				return false;
			}
			saldo -= valor;
			destino.saldo += valor;
			return true;
		}

		//public ContaCorrente(int numero_agencia,string conta)
		//{
		//	Numero_agencia = numero_agencia;
		//	Conta = conta;
		//	Titular = new Cliente();
		//	TotalDeContasCriadas++;
		//}
        public ContaCorrente(int numero_agencia)
        {
            Numero_agencia = numero_agencia;
			Conta = Guid.NewGuid().ToString().Substring(0,8);
			Titular = new Cliente();
			TotalDeContasCriadas++;

        }

        public override string ToString()
		{

			return $" === DADOS DA CONTA === \n" +
				   $"Número da Conta : {this.Conta} \n" +
				   $"Número da Agência : {this.Numero_agencia} \n" +
				   $"Saldo da Conta : {this.Saldo}\n" +
				   $"Titular da Conta: {this.Titular.Nome} \n" +
				   $"CPF do Titular  : {this.Titular.Cpf} \n" +
				   $"Profissão do Titular: {this.Titular.Profissao}\n";
				 
		}
		//método que permite que a classe conta corrente seja ordenada
		//pode receber um valor nulo, logo, fazer a verificação
        public int CompareTo(ContaCorrente? outro)
        {
			//verificação para saber ce é nulo
			if (outro == null)
			{
				return 1;
			}
			else
			{
				//fazer a comparação, vai ordenar pelo número da agencia.
				return this.Numero_agencia.CompareTo(outro.Numero_agencia);
			}
        }
    }

}