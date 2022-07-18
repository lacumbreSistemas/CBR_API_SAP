﻿using Domain.Models.Produccion;
using Intermedia_.Repositories.Produccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories.Produccion
{
    public class EscaneoProduccionRepo
    {
        private ProduccionEntryRepo produccionEntryRepo = new ProduccionEntryRepo();

        public ProcesosEntryModelBuild crearEntryProduccion(ProcesosEntryModelBuild newproduccionEntryModelBuild) {
            ProcesoProduccionEntryBuildEstrategy estrategia = new ProcesoProduccionEntryBuildEstrategy();
            ProcesosEntryModelBuild produccionEntryModelBuild = new ProcesosEntryModelBuild(newproduccionEntryModelBuild,estrategia);


            return produccionEntryModelBuild.guardar();
        }
        public List<ProcesosEntryModelConsulta> historialEntries(int number, string itemCode)
        {

            List<ProcesosEntryModelConsulta> historialEntries = new List<ProcesosEntryModelConsulta>();

            produccionEntryRepo.obtenerEntriesPorNumberItemCode(number, itemCode).ForEach(i => {

                ProcesosEntryModelConsulta entrie = new ProcesosEntryModelConsulta();

                entrie.cantidad = (double)i.quantity;
                entrie.deleted = i.deleted;
                entrie.deletedId = i.deletedId;
                entrie.fecha = i.fecha;
                entrie.id = i.id;
                entrie.codigoProducto = i.itemcode;
                entrie.numero = (int)i.numero;
                entrie.usuario = i.usuario;
                entrie.setNombreProducto();

                historialEntries.Add(entrie);

            });

            return historialEntries;
        }

        public ProcesosEntryModelConsulta anularEscaneo(ProcesosEntryModelConsulta procesoEntryModelConsulta)
        {
            ProcesoProduccionEntryConsultaEstrategy estrategia = new ProcesoProduccionEntryConsultaEstrategy();
            ProcesosEntryModelConsulta escaneo = new ProcesosEntryModelConsulta(estrategia);
            escaneo = procesoEntryModelConsulta;
            return escaneo.anular();

        }


    }
}
