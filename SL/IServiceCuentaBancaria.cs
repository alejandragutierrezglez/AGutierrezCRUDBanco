using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IServiceCuentaBancaria" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServiceCuentaBancaria
    {
        [OperationContract]
        ML.Result Depositar(ML.CuentaBancaria cuentaBancaria);

        [OperationContract]
        ML.Result Retirar(string NumeroCuenta, decimal Saldo, decimal SaldoARetirar);

        [OperationContract]
        [ServiceKnownType(typeof(ML.CuentaBancaria))]
        ML.Result ConsultarSaldo();
    }
}
