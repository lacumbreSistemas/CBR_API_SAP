using Domain.Models.Produccion;
using Domain.Repositories.Produccion;
using Intermedia_;
using Intermedia_.Repositories.Transformaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories.Transformaciones
{
    public class TransformacionesRepo
    {


        public ProcesosModelBuild crearDocumentoProduccionIntermedia(ProcesosModelBuild documentoIntermedioProduccion, string WhsCode)
        {


            ProcesosTransformacionesHeaderBuildEstrategy estrategy = new ProcesosTransformacionesHeaderBuildEstrategy();

            ProcesosModelBuild nuevoDocumentoIntermedioProduccion = new ProcesosModelBuild(documentoIntermedioProduccion, estrategy);
            nuevoDocumentoIntermedioProduccion.codigoTienda = WhsCode;
            nuevoDocumentoIntermedioProduccion.guardar();
            return nuevoDocumentoIntermedioProduccion.numero == 0 ? throw new Exception("No se creó documento intermedio de producción") : nuevoDocumentoIntermedioProduccion;

        }


        public List<ProcesosModelConsulta> obtenerListaDocumentosIntermediosTransformacion(string WhsCode)
        {
            TransformacionesHeaderRepo transformacionesHeaderRepo = new TransformacionesHeaderRepo();
            ProcesosTransformacionesHeaderConsultaEstrategy estrategy = new ProcesosTransformacionesHeaderConsultaEstrategy();

            List<cbr_transformacionesHeader> DocumentosIntermediosTransformacionesEntity = new List<cbr_transformacionesHeader>();

            DocumentosIntermediosTransformacionesEntity = transformacionesHeaderRepo.obtenerDocumentoIntermedioTransformacion(WhsCode).ToList();

            List<ProcesosModelConsulta> DocumentosIntermediosProduccion = new List<ProcesosModelConsulta>();

            DocumentosIntermediosTransformacionesEntity.ForEach(i =>
            {
                ProcesosModelConsulta documentoTransformacion = new ProcesosModelConsulta(estrategy);
                //solicitudDevolucion.id = i.id;
                documentoTransformacion.numero = i.numero;
                documentoTransformacion.codigoProducto = i.codigoProducto;
                documentoTransformacion.codigoTienda = i.whsCode;
                documentoTransformacion.fechaCreacion = (DateTime)i.fecha;
                documentoTransformacion.usuario = i.usuario;
                documentoTransformacion.entradaDocEntry = i.entradaDocEntry;
                documentoTransformacion.salidaDocEntry = i.salidaDocEntry;
                documentoTransformacion.comentario = i.comentario;
                documentoTransformacion.cantidad = i.cantidad;
                documentoTransformacion.remarkCode = i.remarkId;
                documentoTransformacion.setRemark();
                documentoTransformacion.definirdescripcionReceta();
                DocumentosIntermediosProduccion.Add(documentoTransformacion);

            });

            return DocumentosIntermediosProduccion;
        }


        public ProcesosModelConsulta resumenDocumentoTransformacion(int numero)
        {

            ProcesosTransformacionesHeaderConsultaEstrategy estrategy = new ProcesosTransformacionesHeaderConsultaEstrategy();
            ProcesosModelConsulta produccionModelConsulta = new ProcesosModelConsulta(numero, estrategy);

            produccionModelConsulta.resumenEntries();
            produccionModelConsulta.setRemark();
            produccionModelConsulta.definirdescripcionReceta();
            return produccionModelConsulta;
        }


        public string cancelarDocumento(int numero)
        {

            TransformacionesHeaderRepo transformacionHeaderRepo = new TransformacionesHeaderRepo();
            transformacionHeaderRepo.cancelarDocumento(numero);
            return "Documento cancelado";
        }

        public void anularEscaneosItemCodeNumero(ProcesosEntryResumenActualizar mermasEntryResumenActualizar)
        {
            ProcesoTransformacionEntryResumenActualizarEstrategy estrategy = new ProcesoTransformacionEntryResumenActualizarEstrategy();
            mermasEntryResumenActualizar.Estrategia = estrategy;
            mermasEntryResumenActualizar.Anular();
        }

        public ProcesosModelSAP generarSalidaSAP(int numero)
        {

            var DocumentoTransformacionIntermedia = resumenDocumentoTransformacion(numero);

            ProcesosModelSAP _transformacionModelSAP = new ProcesosModelSAP();


            _transformacionModelSAP.numero = DocumentoTransformacionIntermedia.numero;

            _transformacionModelSAP.codigoTienda = DocumentoTransformacionIntermedia.codigoTienda;
            _transformacionModelSAP.comentario = DocumentoTransformacionIntermedia.comentario;
            _transformacionModelSAP.usuario = DocumentoTransformacionIntermedia.usuario;
            _transformacionModelSAP.remarkCode = DocumentoTransformacionIntermedia.remarkCode;
            _transformacionModelSAP.remark = DocumentoTransformacionIntermedia.remark;
            _transformacionModelSAP.cantidad = DocumentoTransformacionIntermedia.cantidad;
            _transformacionModelSAP.codigoProducto = DocumentoTransformacionIntermedia.codigoProducto;


            if (DocumentoTransformacionIntermedia.entries.Count == 0)
                throw new Exception("No tiene items escaneados para subir");

            DocumentoTransformacionIntermedia.entries.ForEach(i =>
            {
                ProcesosEntryResumenSAP produccionEntryResumenSAP = new ProcesosEntryResumenSAP();
                produccionEntryResumenSAP.cantidadEscaneada = i.cantidadEscaneada;
                produccionEntryResumenSAP.codigoProducto = i.codigoProducto;
                produccionEntryResumenSAP.descripcionProducto = i.descripcionProducto;
                produccionEntryResumenSAP.establecerPrecioVenta();
                _transformacionModelSAP.entrys.Add(produccionEntryResumenSAP);

            });


            //if (DocumentoProduccionIntermedia.salidaDocEntry != 0)
            //    throw new Exception("Ya se generó un documento de salida en SAP para este documento intermedio ");



            return _transformacionModelSAP.generarSalidaMercancia();

        }
    }
}
