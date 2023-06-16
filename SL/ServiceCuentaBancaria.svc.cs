using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServiceCuentaBancaria" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServiceCuentaBancaria.svc o ServiceCuentaBancaria.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServiceCuentaBancaria : IServiceCuentaBancaria
    {
        public ML.Result Depositar(ML.CuentaBancaria cuentaBancaria)
        {
            ML.Result result = BL.CuentaBancaria.Depositar(cuentaBancaria);
            if (result.Correct)
            {
                return result;
            }
            else
            {
                return null;
            }
        }
        public ML.Result Retirar(string NumeroCuenta, decimal Saldo, decimal SaldoARetirar)
        {
            ML.Result result = BL.CuentaBancaria.Retirar(NumeroCuenta, Saldo, SaldoARetirar);
            if (result.Correct)
            {
                return result;
            }
            else
            {
                return null;
            }
        }
        public ML.Result ConsultarSaldo()
        {
            ML.Result result = BL.CuentaBancaria.ConsultarSaldo();
            if (result.Correct)
            {
                return result;
            }
            else
            {
                return null;
            }
        }
    }
}
