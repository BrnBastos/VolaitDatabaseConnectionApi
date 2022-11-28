using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using VolaitDatabaseConnectionApi.Data;

namespace VolaitDatabaseConnectionApi.Models.DAO
{
    public class CupomDAO
{
        private Database db;
      
        public List<Cupom> SelectAllCupomsAvailable()
        {
            using (db = new Database())
            {
                string selectAllQuery = "select * from tb_Cupom;";
                var reader = db.CommandRetuner(selectAllQuery);
                return ConvertingReaderToList(reader);
            }
}

        public Cupom SelectCupomById(int id)
        {
            using (db = new Database())
            {
                string selectByIdQuery = string.Format("select * from tb_Cupom WHERE cupomID = {0};", id);
                var reader = db.CommandRetuner(selectByIdQuery);
                return ConvertingReaderToList(reader).FirstOrDefault();
            }
        }

        public List<Cupom> ConvertingReaderToList(MySqlDataReader reader)
        {
            var cupoms = new List<Cupom>();
            //var groupblockDAO = new GroupBlockDAO();
            //var standardStateDAO = new StandardStateDAO();
            while (reader.Read())
            {
                var tempCupom = new Cupom()
                {
                    CupomID = int.Parse(reader["cupomid"].ToString()),
                    CupomCode = reader["cupomCode"].ToString(),
                    ValorDesconto = decimal.Parse(reader["valordesconto"].ToString()),
                    CupomValidade = DateTime.Parse(reader["cupomvalidade"].ToString())
                };
                cupoms.Add(tempCupom);
            }
            reader.Close();
            return cupoms;
        }
    }
}