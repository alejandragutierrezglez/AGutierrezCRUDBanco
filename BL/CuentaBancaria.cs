using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class CuentaBancaria
    {
        public static ML.Result Depositar(ML.CuentaBancaria cuentaBancaria)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.AGutierrezCRUDBancoEntities context = new DL.AGutierrezCRUDBancoEntities())
                {
                    var query = context.CuentaBancariaAddRealizarDeposito(cuentaBancaria.NumeroDeCuenta, cuentaBancaria.Saldo, cuentaBancaria.Titular);
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {

                        result.Correct = false;
                    }

                }
            }
            catch (Exception Ex)
            {
                result.Correct = false;
                result.ErrorMessage = Ex.Message;
                result.Ex = Ex;
            }
            return result;
        }
        public static ML.Result Retirar(string NumeroCuenta, decimal Saldo, decimal SaldoARetirar)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.AGutierrezCRUDBancoEntities context = new DL.AGutierrezCRUDBancoEntities())
                {
                    var query = context.RetirarDeposito(NumeroCuenta, Saldo, SaldoARetirar);
                    if (query != null)
                    {
                        ML.CuentaBancaria cuentaBancaria = new ML.CuentaBancaria();
                        cuentaBancaria.NumeroDeCuenta = NumeroCuenta;
                        cuentaBancaria.Saldo= Saldo;
                        cuentaBancaria.SaldoARetirar = SaldoARetirar;

                        result.Object= cuentaBancaria;
                        result.Correct = true;
                    }
                    else
                    {

                        result.Correct = false;
                    }
                }
            }
            catch (Exception Ex)
            {
                result.Correct = false;
                result.ErrorMessage = Ex.Message;
                result.Ex = Ex;
            }
            return result;
        }
        public static ML.Result ConsultarSaldo()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.AGutierrezCRUDBancoEntities context = new DL.AGutierrezCRUDBancoEntities())
                {
                    var query = context.CuentaBancariaGetAllConsultaSaldo().ToList();
                    if (query != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var item in query)
                        {
                            ML.CuentaBancaria cuentaBancaria = new ML.CuentaBancaria();
                            cuentaBancaria.IdCuentaBancaria = item.IdCuentaBancaria;
                            cuentaBancaria.NumeroDeCuenta = item.NumeroDeCuenta;
                            cuentaBancaria.Saldo = item.Saldo.Value;
                            cuentaBancaria.Titular = item.Titular;

                            result.Objects.Add(cuentaBancaria);
                            result.Correct = true;
                        }

                    }

                }
            }
            catch (Exception Ex)
            {
                result.Correct = false;
                result.ErrorMessage = Ex.Message;
                result.Ex = Ex;
            }
            return result;
        }
        public static decimal SumaSaldo()
        {
            ML.Result result = new ML.Result();
            decimal sumaSaldo = 0;
            try
            {
                using (DL.AGutierrezCRUDBancoEntities context = new DL.AGutierrezCRUDBancoEntities())
                {
                    var query = context.SumaSaldo().FirstOrDefault();
                    sumaSaldo = query.Value;
                    if (query != null)
                    {
                        result.Correct = true;

                    }
                    else
                    {

                        result.Correct = false;
                    }

                }
            }
            catch (Exception Ex)
            {
                result.ErrorMessage = Ex.Message;
                result.Correct = false;
                result.Ex = Ex;
            }
            return sumaSaldo;
        }

    }
}

