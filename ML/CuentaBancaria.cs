using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class CuentaBancaria
    {
        public int IdCuentaBancaria { get; set; }
        public string NumeroDeCuenta { get; set; }
        public decimal Saldo { get; set; }
        public string Titular { get; set; }
        public decimal SumaSaldo { get; set; }
        public decimal SaldoARetirar { get; set; }
        public List<object> CuentasBancarias { get; set; }
    }
}
