using Domain.Models.Produccion;
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
                documentoProduccion.entradaDocEntry = i.entradaDocEntry;
                documentoProduccion.salidaDocEntry = i.salidaDocEntry;
                documentoProduccion.comentario = i.comentario;
                documentoProduccion.cantidad = i.cantidad;
                documentoProduccion.remarkCode = i.remarkId;
                documentoProduccion.setRemark();
                documentoProduccion.definirdescripcionReceta();
                DocumentosIntermediosProduccion.Add(documentoProduccion);

            });

            return DocumentosIntermediosProduccion;
        }

        public ProduccionModelConsulta resumenDocumentoProduccion(int numero) {
            ProduccionModelConsulta produccionModelConsulta = new ProduccionModelConsulta(numero);

            produccionModelConsulta.resumenEntries();
            produccionModelConsulta.setRemark();
            produccionModelConsulta.definirdescripcionReceta();
            return produccionModelConsulta;
        }


        public string cancelarDocumento(int numero) {

            ProduccionHeaderRepo produccionHeaderRepo = new ProduccionHeaderRepo();
            produccionHeaderRepo.cancelarDocumento(numero);
            return "Solicitud cancelada";
        }

        public void anularEscaneosItemCodeNumero(ProduccionEntryResumenActualizar mermasEntryResumenActualizar)
        {

            mermasEntryResumenActualizar.Anular();
        }

        public ProduccionModelSAP generarSalidaSAP(int numero)
        {

            var DocumentoProduccionIntermedia = resumenDocumentoProduccion(numero);

            ProduccionModelSAP _produccionModelSAP = new ProduccionModelSAP();


            _produccionModelSAP.numero = DocumentoProduccionIntermedia.numero;

            _produccionModelSAP.codigoTienda = DocumentoProduccionIntermedia.codigoTienda;
            _produccionModelSAP.comentario = DocumentoProduccionIntermedia.comentario;
            _produccionModelSAP.usuario = DocumentoProduccionIntermedia.usuario;
            _produccionModelSAP.remarkCode = DocumentoProduccionIntermedia.remarkCode;
            _produccionModelSAP.remark = DocumentoProduccionIntermedia.remark;
            _produccionModelSAP.cantidad = DocumentoProduccionIntermedia.cantidad;
            _produccionModelSAP.codigoProducto = DocumentoProduccionIntermedia.codigoProducto;


            if (DocumentoProduccionIntermedia.entries.Count == 0)
                throw new Exception("No tiene items escaneados para subir");

            DocumentoProduccionIntermedia.entries.ForEach(i =>
            {
                ProduccionEntryResumenSAP produccionEntryResumenSAP = new ProduccionEntryResumenSAP();
                produccionEntryResumenSAP.cantidadEscaneada = i.cantidadEscaneada;
                produccionEntryResumenSAP.codigoProducto = i.codigoProducto;
                produccionEntryResumenSAP.descripcionProducto = i.descripcionProducto;
                produccionEntryResumenSAP.establecerPrecioVenta();
                _produccionModelSAP.entrys.Add(produccionEntryResumenSAP);

            });


            //if (DocumentoProduccionIntermedia.salidaDocEntry != 0)
            //    throw new Exception("Ya se generó un documento de salida en SAP para este documento intermedio ");



            return _produccionModelSAP.generarSalidaMercancia();

        }
    }
}
