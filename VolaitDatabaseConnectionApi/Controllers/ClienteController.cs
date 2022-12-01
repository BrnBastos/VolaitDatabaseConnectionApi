using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VolaitDatabaseConnectionApi.Models;
using VolaitDatabaseConnectionApi.Models.DAO;
using VolaitDatabaseConnectionApi.Utils;

namespace VolaitDatabaseConnectionApi.Controllers
{
    public class ClienteController : ApiController
    {
        // GET: api/Cliente
        public List<Cliente> Get()
        {
            var clienteDAO = new ClienteDAO();
            var clienteList = clienteDAO.SelectAllClientes();
            return clienteList;
        }

        // POST: api/Cliente
        [HttpPost]
        public void Post([FromBody] Cliente cliente)
        {
            var clienteDAO = new ClienteDAO();
            clienteDAO.SaveCliente(cliente);
        }

        [HttpGet]
        public Cliente ConsultarCliente(string login)
        {
            ClienteDAO dao = new ClienteDAO();
            var cliente = dao.ConsultarCliente(login);
            return cliente;
        }

        // EDITAR USUÁRIO
        [HttpPut]
        public void UpdateCliente([FromBody] Cliente cliente)
        {
            if (cliente == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));

            ClienteDAO dao = new ClienteDAO();
            dao.UpdateCliente(cliente);
        }

        // POST: api/Cliente
        //[HttpPost]
        //public Cliente Login([FromBody]Cliente clienteUsuario)
        //{
        //    ClienteDAO clientedao = new ClienteDAO();
        //    var cliente = clientedao.LoginCliente(clienteUsuario);

        //    if (cliente == null | cliente.LoginCliente != clienteUsuario.LoginCliente)
        //    {
        //        //return "Login incorreta";

        //    }

        //    if (cliente.SenhaCliente != Hash.GerarHash(clienteUsuario.SenhaCliente))
        //    {
        //        cliente.SenhaCliente = "erro meno";
        //        return cliente;
        //    }
        //    return cliente;
        //}
    }
}
