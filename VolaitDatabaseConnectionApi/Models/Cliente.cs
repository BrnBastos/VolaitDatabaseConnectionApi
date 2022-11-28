using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VolaitDatabaseConnectionApi.Models
{
	public class Cliente
	{
		public long CPFCliente { get; set; }
		public string NomeCliente { get; set; }
		public string NomeSocialCliente { get; set; }
		public string LoginCliente { get; set; }
		public string TelefoneCliente { get; set; }
		public string SenhaCliente { get; set; }

		public Cliente(long CPFCliente_, string NomeCliente_, string NomeSocialCliente_, string LoginCliente_, string TelefoneCliente_, string SenhaCliente_)
		{
			this.CPFCliente = CPFCliente_;
			this.NomeCliente = NomeCliente_;
			this.NomeSocialCliente = NomeSocialCliente_;
			this.LoginCliente = LoginCliente_;
			this.TelefoneCliente = TelefoneCliente_;
			this.SenhaCliente = SenhaCliente_;
		}

        public Cliente()
        {
        }
    }
}