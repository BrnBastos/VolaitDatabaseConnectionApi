using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using VolaitDatabaseConnectionApi.Data;

namespace VolaitDatabaseConnectionApi.Models.DAO
{
    public class ClienteDAO
    {
        private Database db;

        public void SaveCliente(Cliente cliente)
        {
            var insertQuery = "";
            insertQuery += "call spInsertCli";
            insertQuery += string.Format("({0}, '{1}', '{2}', '{3}', '{4}', '{5}');",
                cliente.CPFCliente,                               //0 
                cliente.NomeCliente,                              //1 ''
                cliente.NomeSocialCliente,                        //2 ''
                cliente.LoginCliente,                             //3 ''
                cliente.TelefoneCliente,                          //4 ''
                cliente.SenhaCliente);                            //5 ''

            using (db = new Database())
            {
                db.CommandExecuter(insertQuery);
            }
        }

        public void UpdateCliente(Cliente cliente)
        {
            var updateQuery = "";
            updateQuery += "call spAlterCli ";
            updateQuery += string.Format("({0}, '{1}', '{2}', '{3}', '{4}', '{5}')",
                cliente.CPFCliente,                    //0 
                cliente.NomeCliente,                   //1 ''
                cliente.NomeSocialCliente,             //2 ''
                cliente.LoginCliente,                  //3 ''
                cliente.TelefoneCliente,               //4 ''
                cliente.SenhaCliente);                 //5 ''

            using (db = new Database())
            {
                db.CommandExecuter(updateQuery);
            }
        }

        public Cliente ConsultarCliente(string login)
        {
            using (db = new Database())
            {
                string selectByLogin = string.Format("CALL spSelectCli('{0}');", login);
                var reader = db.CommandRetuner(selectByLogin);
                return ConvertingClienteReaderToList(reader).FirstOrDefault();
            }
            
        }

        public void DeleteCliente(int id)
        {
            var deleteQuery = "";
            deleteQuery += string.Format("delete from  tbcliente where cpfcliente = {0};", id);

            using (db = new Database())
            {
                db.CommandExecuter(deleteQuery);
            }
        }

        public List<Cliente> SelectAllClientes()
        {
            using (db = new Database())
            {
                string selectAllQuery = "select * from tb_Cliente;";
                var reader = db.CommandRetuner(selectAllQuery);
                return ConvertingClienteReaderToList(reader);
            }
        }

        public Cliente SelectClienteById(int id)
        {
            using (db = new Database())
            {
                string selectByIdQuery = string.Format("select * from tb_Cliente WHERE cpfcliente = {0};", id);
                var reader = db.CommandRetuner(selectByIdQuery);
                return ConvertingClienteReaderToList(reader).FirstOrDefault();
            }
        }

        public List<Cliente> ConvertingClienteReaderToList(MySqlDataReader reader)
        {
            var clientes = new List<Cliente>();
            while (reader.Read())
            {
                var tempCliente = new Cliente()
                {
                    CPFCliente = long.Parse(reader["CPFCliente"].ToString()),
                    NomeCliente = reader["NomeCliente"].ToString(),
                    NomeSocialCliente = reader["NomeSocialCliente"].ToString(),
                    LoginCliente = reader["LoginCliente"].ToString(),
                    TelefoneCliente = reader["TelefoneCliente"].ToString(),
                    SenhaCliente = reader["SenhaCliente"].ToString()
                };
                clientes.Add(tempCliente);
            }
            reader.Close();
            return clientes;
        }
    }
}