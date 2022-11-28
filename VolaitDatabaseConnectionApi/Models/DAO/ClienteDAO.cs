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
            //var updateQuery = "";
            //updateQuery += "update tbCliente SET ";
            //updateQuery += string.Format("symbol = '{1}', " +
            //                             "name = '{2}', " +
            //                             "atomicMass = '{3}', " +
            //                             "yearDiscovered = '{4}', " +
            //                             "cpkHexColor = '{5}', " +
            //                             "period = {6}, " +
            //                             "groupfamily = {7}, " +
            //                             "favorited = {8}, " +
            //                             "FK_groupblock = {9}, " +
            //                             "FK_standardState = {10} " +
            //                             "WHERE atomicNumber = {0};",
            //    cliente.atomicNumber,                            //0 
            //    cliente.symbol,                                  //1 ''
            //    cliente.name,                                    //2 ''
            //    cliente.atomicMass,                              //3 ''
            //    cliente.yearDiscovered.ToString("yyyy-MM-dd"),   //4 ''
            //    cliente.cpkHexColor,                             //5 ''
            //    cliente.period,                                  //6
            //    cliente.group,                                   //7
            //    cliente.favorited,                               //8
            //    cliente.groupBlock.groupblockID,                 //9
            //    cliente.standardState.standardStateID);          //10 

            //using (db = new Database())
            //{
            //    db.CommandExecuter(updateQuery);
            //}
        }

        // public Cliente LoginCliente(Cliente clienteLogin)
        // {
        //     using (db = new Database())
        //     {           
        //         string selectByIdQuery = string.Format("call spLoginClienteApp('{0}');", clienteLogin.LoginCliente);
        //         var reader = db.CommandRetuner(selectByIdQuery);
        //         return ConvertingReaderToList(reader).FirstOrDefault();
        //     }
        // }

        public Cliente ConsultarCliente(string login)
        {
            using (db = new Database())
            {
                string selectByLogin = string.Format("CALL spSelectCli('{0}');", login);
                var reader = db.CommandRetuner(selectByLogin);
                return ConvertingReaderToList(reader).FirstOrDefault();
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
                return ConvertingReaderToList(reader);
            }
        }

        public Cliente SelectClienteById(int id)
        {
            using (db = new Database())
            {
                string selectByIdQuery = string.Format("select * from tb_Cliente WHERE cpfcliente = {0};", id);
                var reader = db.CommandRetuner(selectByIdQuery);
                return ConvertingReaderToList(reader).FirstOrDefault();
            }
        }

        public List<Cliente> ConvertingReaderToList(MySqlDataReader reader)
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