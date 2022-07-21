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

        

        public ProcesosModelBuild crearDocumentoProduccionIntermedia(ProcesosModelBuild documentoIntermedioProduccion, string WhsCode) {


            ProcesoProduccionHeaderBuildEstrategy estrategy = new ProcesoProduccionHeaderBuildEstrategy();

            ProcesosModelBuild nuevoDocumentoIntermedioProduccion = new ProcesosModelBuild(documentoIntermedioProduccion, estrategy);
            nuevoDocumentoIntermedioProduccion.codigoTienda = WhsCode;
            nuevoDocumentoIntermedioProduccion.guardar();
            return nuevoDocumentoIntermedioProduccion.numero == 0 ? throw new Exception("No se creó documento intermedio de producción") : nuevoDocumentoIntermedioProduccion;

        }



        public List<ProcesosModelConsulta> obtenerListaDocumentosIntermediosProduccion(string WhsCode)
        {
         ProduccionHeaderRepo produccionHeaderRepo = new ProduccionHeaderRepo();
            ProcesoProduccionHeaderConsultaEstrategy estrategy = new ProcesoProduccionHeaderConsultaEstrategy();

            List<cbr_ProduccionHeader> DocumentosIntermediosProduccionEntity = new List<cbr_ProduccionHeader>();

            DocumentosIntermediosProduccionEntity = produccionHeaderRepo.obtenerDocumentoIntermedioProduccion(WhsCode).ToList();

            List<ProcesosModelConsulta> DocumentosIntermediosProduccion = new List<ProcesosModelConsulta>();

            DocumentosIntermediosProduccionEntity.ForEach(i =>
            {
                ProcesosModelConsulta documentoProduccion = new ProcesosModelConsulta(estrategy);
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

        public ProcesosModelConsulta resumenDocumentoProduccion(int numero) {

            ProcesoProduccionHeaderConsultaEstrategy estrategy = new ProcesoProduccionHeaderConsultaEstrategy();
            ProcesosModelConsulta produccionModelConsulta = new ProcesosModelConsulta(numero, estrategy);

            produccionModelConsulta.resumenEntries();
            produccionModelConsulta.setRemark();
            produccionModelConsulta.definirdescripcionReceta();
            return produccionModelConsulta;
        }


        public string cancelarDocumento(int numero) {

            ProduccionHeaderRepo produccionHeaderRepo = new ProduccionHeaderRepo();
            produccionHeaderRepo.cancelarDocumento(numero);
            return "Documento cancelado";
        }

        public void anularEscaneosItemCodeNumero(ProcesosEntryResumenActualizar mermasEntryResumenActualizar)
        {

            ProcesoProduccionEntryResumenActualizarEstrategy estrategy = new ProcesoProduccionEntryResumenActualizarEstrategy();
            mermasEntryResumenActualizar.Estrategia = estrategy;
            mermasEntryResumenActualizar.Anular();
        }

        public ProcesosModelSAP generarSalidaSAP(int numero)
        {

            var DocumentoProduccionIntermedia = resumenDocumentoProduccion(numero);


            ProcesoProduccionSAPEstrategy estrategia = new ProcesoProduccionSAPEstrategy();

            ProcesosModelSAP _produccionModelSAP = new ProcesosModelSAP(estrategia);


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
                ProcesosEntryResumenSAP produccionEntryResumenSAP = new ProcesosEntryResumenSAP();
                produccionEntryResumenSAP.cantidadEscaneada = i.cantidadEscaneada;
                produccionEntryResumenSAP.codigoProducto = i.codigoProducto;
                produccionEntryResumenSAP.descripcionProducto = i.descripcionProducto;
                produccionEntryResumenSAP.establecerPrecioVenta();
                _produccionModelSAP.entrys.Add(produccionEntryResumenSAP);

            });


            //if (DocumentoProduccionIntermedia.salidaDocEntry != 0)
            //    throw new Exception("Ya se generó un documento de salida en SAP para este documento intermedio ");



            return _produccionModelSAP.generarDocumentoSAP();

        }
    }
}
