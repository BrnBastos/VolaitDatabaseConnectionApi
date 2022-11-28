using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VolaitDatabaseConnectionApi.Models.DAO;
using VolaitDatabaseConnectionApi.Models;

namespace VolaitDatabaseConnectionApi.Controllers
{
    public class CupomController : ApiController
    {
        // GET: api/Cupom
        [HttpGet]
        public IEnumerable Get()
        {
            var cupomDAO = new CupomDAO();
            var cupomList = cupomDAO.SelectAllCupomsAvailable();
            return cupomList;
        }

        // GET: api/Cupom/5
        [HttpGet]
        public Cupom Get(int id)
        {
            var cupomDAO = new CupomDAO();
            var cupom = cupomDAO.SelectCupomById(id);

            if (cupom == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));

            return cupom;
        }
    }
}
