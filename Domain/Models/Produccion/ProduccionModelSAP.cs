﻿using HQ.Repositories;
using Intermedia_.Repositories.Produccion;
using SAP;
using SAP.Models.Mermas;
using SAP.Models.Produccion;
using SAP.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Produccion
{
    public class ProduccionModelSAP : ProduccionModelMaster

    {

        public int docEntrySalida { get; set; }

        public int docEntryEntrada { get; set; }

        public int docNumSalida { get; set; }

        public int docNumEntrada { get; set; }


        public string cuentaContable { get; set; }

        public string centroCostoTienda { get; set; }
        public string centroCosto3 { get; set; }

   

        public List<ProduccionEntryResumenSAP> entrys { get; set; }


        public ProduccionModelSAP() {
            entrys = new List<ProduccionEntryResumenSAP>();
        }
        private void establecerCuentaContable() {
            RemarksRepo remarksRepo = new RemarksRepo();
            cuentaContable = remarksRepo.obgenerCuentaContable(remarkCode);

        }

        private void setCentroCosto()
        {
            RemarksRepo remarksRepo = new RemarksRepo();
            Intermedia_.Repositories.CentroCostoRepository centroCostoRepository = new Intermedia_.Repositories.CentroCostoRepository();
            centroCostoTienda = centroCostoRepository.obtenerCentroCostoTienda(codigoTienda);
            centroCosto3 = remarksRepo.obtenerCentroCosto(remarkCode);
        }


        public ProduccionModelSAP generarSalidaMercancia()
        {
         
            ProduccionSAPEntity salidaMercanciaSAP = new ProduccionSAPEntity();
            ProduccionSAPEntity entradaMercanciaSAP = new ProduccionSAPEntity();

            SalidaMercanciaSAPRepo saliMercanciaRepo = new SalidaMercanciaSAPRepo();
            EntradaMercanciaSAPRepo entradaMercanciaSAPRepo = new EntradaMercanciaSAPRepo();

            ProduccionHeaderRepo produccionHeaderRepo = new ProduccionHeaderRepo();
            establecerCuentaContable();
            setCentroCosto();
            salidaMercanciaSAP.WhsCode = codigoTienda;
            salidaMercanciaSAP.Comentario = comentario;
            salidaMercanciaSAP.RemarkID = remarkCode;
            salidaMercanciaSAP.Remark = remark;
            salidaMercanciaSAP.UsuarioEncargado = usuario;
            salidaMercanciaSAP.CuentaContable = cuentaContable;
            salidaMercanciaSAP.Remark = remark;
            salidaMercanciaSAP.CentroCosto = centroCostoTienda;
            salidaMercanciaSAP.CentroCosto3 = centroCosto3;
            salidaMercanciaSAP.itemCode = codigoProducto;
            salidaMercanciaSAP.quantity = cantidad;


            docEntrySalida = saliMercanciaRepo.generarSalidaMercancia(salidaMercanciaSAP);

            produccionHeaderRepo.setSalidaDocEntry(numero, docEntrySalida);


            #region entradaMercancia
        

            decimal ventaTotalSuma = entrys.Sum(i=> i.ventaTotal);
            decimal costoTotalPonderado = saliMercanciaRepo.obtenerCostoPonderado(codigoTienda, codigoProducto) * (decimal)cantidad;
            entrys.ForEach(i=> {
                ProduccionSAPEntryEntity produccionSAPEntryEntity = new ProduccionSAPEntryEntity();

             

                decimal costoTotal = (i.ventaTotal / ventaTotalSuma)* costoTotalPonderado;
                decimal costoLibra = costoTotal / (decimal)i.cantidadEscaneada;

                produccionSAPEntryEntity.ItemCode = i.codigoProducto;
                produccionSAPEntryEntity.Cantidad = i.cantidadEscaneada;
                produccionSAPEntryEntity.costoLibra = costoLibra;
                salidaMercanciaSAP.produccionEntryEntrada.Add(produccionSAPEntryEntity);



            });

            
            double cantidadTotalEntrada =  salidaMercanciaSAP.produccionEntryEntrada.Sum(i=> i.Cantidad);




            //if (this.cantidad > cantidadTotalEntrada)
            //    throw new Exception("La cantidad a ingresar es menor a la cantidad del producto de la receta ");
            //if (this.cantidad < cantidadTotalEntrada)
            //    throw new Exception("La cantidad a ingresar es mayor a la cantidad del producto de la receta ");


            //if (Math.Round(costoTotalPonderado) > Math.Round(costoTotalEntrada))
            //    throw new Exception("El costo de la entrada  es menor al costo del producto de la receta ");
            //if (Math.Round(costoTotalPonderado) < Math.Round(costoTotalEntrada))
            //    throw new Exception("El costo de la entrada  es mayor al costo del producto de la receta ");

            docEntryEntrada = entradaMercanciaSAPRepo.generarEntradaMercancia(salidaMercanciaSAP, docEntrySalida);
            #endregion




            return this;

        }






    }
}