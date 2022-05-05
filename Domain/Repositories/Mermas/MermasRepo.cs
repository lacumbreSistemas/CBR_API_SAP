using Domain.Models;
using Domain.Models.Mermas;
using Intermedia_;
using Intermedia_.Repositories;
using SAP;
using SAP.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories.Mermas
{
    public class MermasRepo
    {
        private MermasHeaderRepo mermasHeaderRepo = new MermasHeaderRepo();

        public MermasModelBuild crearDocumentoIntermedioMerma(MermasModelBuild merma, string WhsCode)
        {
            MermasModelBuild nuevoDocumentoIntermedioMerma = new MermasModelBuild(merma);
            nuevoDocumentoIntermedioMerma.codigoTienda = WhsCode;

            nuevoDocumentoIntermedioMerma.guardar();
            return nuevoDocumentoIntermedioMerma.numero == 0 ? throw new Exception("No se creó solicitud de devolución") : nuevoDocumentoIntermedioMerma;
        }

        public List<MermasModelConsulta> obtenerListaMermasIntermediaAbiertas(string WhsCode)
        {

            List<cbr_MermasHeader> documentoMermaIntermedio = new List<cbr_MermasHeader>();

            documentoMermaIntermedio = mermasHeaderRepo.obtenerDocumentoIntermedioMerma(WhsCode).ToList();

            List<MermasModelConsulta> documentosMermas = new List<MermasModelConsulta>();


            documentoMermaIntermedio.ForEach(i =>
            {

                MermasModelConsulta merma = new MermasModelConsulta();

                merma.numero = i.number;

                //merma.codigoProveedor = i.cardCode;
                merma.codigoTienda = i.whsCode;
                merma.fechaCreacion = i.fecha;
                merma.usuario = i.usuario;
                merma.comentario = i.comentario;
                merma.remarkCode = i.remarkId;
                merma.setRemark();

                documentosMermas.Add(merma);
            });

            return documentosMermas;

        }

        public MermasModelConsulta resumenDocumentoIntermedioMerma(int numero)
        {
            MermasModelConsulta mermaModelConsulta = new MermasModelConsulta(numero);
            mermaModelConsulta.resumenEntries();
            mermaModelConsulta.setRemark();
            return mermaModelConsulta;

        }

        public void anularEscaneosItemCodeNumero(MermasEntryResumenActualizar mermasEntryResumenActualizar)
        {

            mermasEntryResumenActualizar.anular();
        }

        public string cancelarMerma(int numero)
        {

            mermasHeaderRepo.cancelarDocumentoIntermedioMerma(numero);
            return "Merma cancelado";
        }


     
        public MermaModelSAP generarMermaSAP(int numero)
        {

            var MermaIntermedia = resumenDocumentoIntermedioMerma(numero);
         
            MermaModelSAP MermaSAP = new MermaModelSAP();


            MermaSAP.numero = MermaIntermedia.numero;
     
            MermaSAP.codigoTienda = MermaIntermedia.codigoTienda;
            MermaSAP.comentario = MermaIntermedia.comentario;
            MermaSAP.usuario = MermaIntermedia.usuario;
            MermaSAP.remarkCode = MermaIntermedia.remarkCode;
            MermaSAP.remark = MermaIntermedia.remark;
            


            if (MermaIntermedia.entries.Count == 0)
                throw new Exception("No tiene items escaneados para subir");

            MermaIntermedia.entries.ForEach(i =>
            {
                MermaSAP.mermasEntryList.Add(i);

            });


            if (MermaIntermedia.ifSAP)
                throw new Exception("Ya se generó un documento de SAP para esta devolucion");



            return MermaSAP.generarMermaDevolucion();

        }

       

        public List<RemarkModel> obtenerRemarks() {

            RemarksRepo MermasDevolucionesRepo = new RemarksRepo();
            List<RemarkModel> remarks = new List<RemarkModel>();

            MermasDevolucionesRepo.obtenerRemarks().ForEach(i=> {
                RemarkModel remark = new RemarkModel();

                remark.code = i.code;
                remark.remark = i.remark;
              

                remarks.Add(remark);
                    
            });


            return remarks;
        }

    }
    }

