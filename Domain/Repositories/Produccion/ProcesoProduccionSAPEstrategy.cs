﻿using Domain.Interfaces;
using Domain.Models.Produccion;
using Intermedia_.Repositories.Produccion;
using SAP.Models.Produccion;
using SAP.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories.Produccion
{
    public class ProcesoProduccionSAPEstrategy: IModelSAProcesos
    {
        public ProcesosModelSAP generarDocumentoSAP(ProcesosModelSAP procesosModelSAP)
        {

            ProduccionSAPEntity salidaMercanciaSAP = new ProduccionSAPEntity();
            ProduccionSAPEntity entradaMercanciaSAP = new ProduccionSAPEntity();

            SalidaMercanciaProduccionSAPRepo saliMercanciaRepo = new SalidaMercanciaProduccionSAPRepo();
            EntradaMercanciaSAPRepo entradaMercanciaSAPRepo = new EntradaMercanciaSAPRepo();

            ProduccionHeaderRepo produccionHeaderRepo = new ProduccionHeaderRepo();

            string almacenProduccion = produccionHeaderRepo.getAlmacenProduccion(procesosModelSAP.codigoTienda);
            var costoPonderado = Convert.ToDouble(saliMercanciaRepo.obtenerCostoPonderado(procesosModelSAP.codigoTienda, procesosModelSAP.codigoProducto));

            procesosModelSAP.establecerCuentaContable();
            procesosModelSAP.setCentroCosto();
            salidaMercanciaSAP.WhsCode = procesosModelSAP.codigoTienda;
            salidaMercanciaSAP.Comentario = procesosModelSAP.comentario;
            salidaMercanciaSAP.RemarkID = procesosModelSAP.remarkCode;
            salidaMercanciaSAP.Remark = procesosModelSAP.remark;
            salidaMercanciaSAP.UsuarioEncargado = procesosModelSAP.usuario;
            salidaMercanciaSAP.CuentaContable = procesosModelSAP.cuentaContable;
            salidaMercanciaSAP.Remark = procesosModelSAP.remark;
            salidaMercanciaSAP.CentroCosto = procesosModelSAP.centroCostoTienda;
            salidaMercanciaSAP.CentroCosto3 = procesosModelSAP.centroCosto3;
            salidaMercanciaSAP.itemCode = procesosModelSAP.codigoProducto;
            salidaMercanciaSAP.quantity = procesosModelSAP.cantidad;
            salidaMercanciaSAP.costoPonderado = costoPonderado;
            salidaMercanciaSAP.almacenProduccion = almacenProduccion;

            procesosModelSAP.docEntrySalida = saliMercanciaRepo.generarSalidaMercancia(salidaMercanciaSAP);

            salidaMercanciaSAP.costoTotalSalida = saliMercanciaRepo.obtenerCostoSalida(procesosModelSAP.docEntrySalida);

            produccionHeaderRepo.setSalidaDocEntry(procesosModelSAP.numero, procesosModelSAP.docEntrySalida);

            #region entradaMercancia

            decimal ventaTotalSuma = procesosModelSAP.entrys.Sum(i => i.ventaTotal);
            decimal costoTotalPonderado = Math.Round((saliMercanciaRepo.obtenerCostoPonderado(procesosModelSAP.codigoTienda, procesosModelSAP.codigoProducto) * (decimal)procesosModelSAP.cantidad), 8);


            procesosModelSAP.entrys.ForEach(i => {
                ProduccionSAPEntryEntity produccionSAPEntryEntity = new ProduccionSAPEntryEntity();

                decimal costoTotal = (Math.Round(i.ventaTotal, 8) / Math.Round(ventaTotalSuma, 8)) * costoTotalPonderado;
                decimal costoLibra = Math.Round(costoTotal, 8) / (decimal)i.cantidadEscaneada;

                produccionSAPEntryEntity.ItemCode = i.codigoProducto;
                produccionSAPEntryEntity.Cantidad = i.cantidadEscaneada;
                produccionSAPEntryEntity.costoLibra = Math.Round(costoLibra, 8);
                salidaMercanciaSAP.produccionEntryEntrada.Add(produccionSAPEntryEntity);

                procesosModelSAP.cantidadMerma = procesosModelSAP.cantidadMerma + i.cantidadEscaneada;
            });

            procesosModelSAP.cantidadMerma = procesosModelSAP.cantidadMerma - procesosModelSAP.cantidad;

            salidaMercanciaSAP.cantidadMerma = procesosModelSAP.cantidadMerma;
            double cantidadTotalEntrada = salidaMercanciaSAP.produccionEntryEntrada.Sum(i => i.Cantidad);
            salidaMercanciaSAP.WhsCode = almacenProduccion;

            procesosModelSAP.docEntryEntrada = entradaMercanciaSAPRepo.generarEntradaMercancia(salidaMercanciaSAP, procesosModelSAP.docEntrySalida);

            produccionHeaderRepo.setEntradaDocEntry(procesosModelSAP.numero, procesosModelSAP.docEntryEntrada);
            #endregion


            return procesosModelSAP;

        }


    }
}