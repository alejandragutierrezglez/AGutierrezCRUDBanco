using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class CuentaBancariaController : Controller
    {
        // GET: CuentaBancaria
        public ActionResult ConsultarSaldo()
        {
            ML.Result result = new ML.Result();
            ML.CuentaBancaria cuentaBancaria = new ML.CuentaBancaria();
            ML.Result resultCuentasBancarias = BL.CuentaBancaria.ConsultarSaldo();
            cuentaBancaria.SumaSaldo = BL.CuentaBancaria.SumaSaldo();


            ServiceReferenceCuentaBancaria.ServiceCuentaBancariaClient cuentaBancariaClient = new ServiceReferenceCuentaBancaria.ServiceCuentaBancariaClient();
            result = cuentaBancariaClient.ConsultarSaldo();
            if (result.Correct)
            {
                cuentaBancaria.CuentasBancarias = resultCuentasBancarias.Objects;

                return View(cuentaBancaria);
            }
            else
            {
                return View(cuentaBancaria);
            }
        }

        [HttpGet]
        public ActionResult Form(int? IdCuentaBancaria)
        {
            ML.CuentaBancaria cuentaBancaria = new ML.CuentaBancaria();

            ML.Result resultCuentaBancaria = BL.CuentaBancaria.ConsultarSaldo();

            if (IdCuentaBancaria == null)
            {
                cuentaBancaria.CuentasBancarias = resultCuentaBancaria.Objects;
                return View(cuentaBancaria);
            }
            else
            {
                return View(cuentaBancaria);
            }
        }
        [HttpPost]
        public ActionResult Form(ML.CuentaBancaria cuentaBancaria)
        {
            ML.Result result = new ML.Result();
            ML.Result resultAlumnos = BL.CuentaBancaria.ConsultarSaldo();

            ServiceReferenceCuentaBancaria.ServiceCuentaBancariaClient cuentaBancariaClient = new ServiceReferenceCuentaBancaria.ServiceCuentaBancariaClient();
            result = cuentaBancariaClient.Depositar(cuentaBancaria);

            if (result.Correct)
            {
                cuentaBancaria.CuentasBancarias = resultAlumnos.Objects;
                return View(cuentaBancaria);

            }
            else
            {

                return View(cuentaBancaria);
            }
        }
        public ActionResult Retirar(int? IdCuentaBancaria)
        {
            ML.CuentaBancaria cuentaBancaria = new ML.CuentaBancaria();
            return View(cuentaBancaria);
        }
        [HttpPost]
        public ActionResult Retirar(string NumeroDeCuenta, decimal Saldo, decimal SaldoARetirar)

        {
            ML.CuentaBancaria cuentaBancaria = new ML.CuentaBancaria();
            ML.Result result = new ML.Result();
            result = BL.CuentaBancaria.Retirar(NumeroDeCuenta, Saldo, SaldoARetirar);


            if (result.Correct)
            {
                ViewBag.Message = "Se ha realizado con exito el retiro";
                return PartialView("Modal");
            }
            else
            {
                ViewBag.Message = "Error al realizar retiro";
                return PartialView("Modal");
            }

        }
    }
}
