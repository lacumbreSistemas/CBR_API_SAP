﻿using Domain.Models.Produccion;
using Intermedia_;
using Intermedia_.Repositories.Produccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories.Produccion
{
    public class ProduccionRepo
    {

    

        public ProduccionModelBuild crearDocumentoProduccionIntermedia(ProduccionModelBuild documentoIntermedioProduccion, string WhsCode) {

            ProduccionModelBuild nuevoDocumentoIntermedioProduccion = new ProduccionModelBuild(documentoIntermedioProduccion);
            nuevoDocumentoIntermedioProduccion.codigoTienda = WhsCode;
            nuevoDocumentoIntermedioProduccion.guardar();
            return nuevoDocumentoIntermedioProduccion.numero == 0 ? throw new Exception("No se creó solicitud de devolución") : nuevoDocumentoIntermedioProduccion;

        }



        public List<ProduccionModelConsulta> obtenerListaDocumentosIntermediosProduccion(string WhsCode)
        {
         ProduccionHeaderRepo produccionHeaderRepo = new ProduccionHeaderRepo();


        List<cbr_ProduccionHeader> DocumentosIntermediosProduccionEntity = new List<cbr_ProduccionHeader>();

            DocumentosIntermediosProduccionEntity = produccionHeaderRepo.obtenerDocumentoIntermedioProduccion(WhsCode).ToList();

            List<ProduccionModelConsulta> DocumentosIntermediosProduccion = new List<ProduccionModelConsulta>();

            DocumentosIntermediosProduccionEntity.ForEach(i =>
            {
                ProduccionModelConsulta documentoProduccion = new ProduccionModelConsulta();
                //solicitudDevolucion.id = i.id;
                documentoProduccion.numero = i.numero;
                documentoProduccion.codigoProducto = i.codigoProducto;
                documentoProduccion.codigoTienda = i.whsCode;
                documentoProduccion.fechaCreacion = i.fecha;
                documentoProduccion.usuario = i.usuario;
                DocumentosIntermediosProduccion.Add(documentoProduccion);

            });

            return DocumentosIntermediosProduccion;
        }



    }
}
