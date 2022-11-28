using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VolaitDatabaseConnectionApi.Models
{
    public class Cupom
    {
        public int CupomID { get; set; }
        public string CupomCode { get; set; }
        public decimal ValorDesconto { get; set; }
        public DateTime CupomValidade { get; set; }

        public Cupom(int CupomID_, string CupomCode_, decimal ValorDesconto_, DateTime CupomValidade_)
        {
            this.CupomID = CupomID_;
            this.CupomCode = CupomCode_;
            this.ValorDesconto = ValorDesconto_;
            this.CupomValidade = CupomValidade_;
        }
    
        public Cupom()
        {

        }
    }
}