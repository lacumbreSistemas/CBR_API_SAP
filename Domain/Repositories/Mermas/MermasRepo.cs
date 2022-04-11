using Domain.Models.Mermas;
using Intermedia_;
using Intermedia_.Repositories;
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

        public List<MermasModelConsulta> obtenerListaMermasIntermediaAbiertas(string WhsCode) {

            List<cbr_MermasHeader> documentoMermaIntermedio = new List<cbr_MermasHeader>();

            documentoMermaIntermedio = mermasHeaderRepo.obtenerDocumentoIntermedioMerma(WhsCode).ToList();

            List<MermasModelConsulta> documentosMermas = new List<MermasModelConsulta>();


            documentoMermaIntermedio.ForEach(i => {

                MermasModelConsulta merma = new MermasModelConsulta();

                merma.numero = i.number;

                merma.codigoProveedor = i.cardCode;
                merma.codigoTienda = i.whsCode;
                merma.fechaCreacion = i.fecha;
                merma.usuario = i.usuario;

                merma.setNombreProveedor();

                documentosMermas.Add(merma); 
            });

            return documentosMermas;

        }

        public MermasModelConsulta resumenDocumentoIntermedioMerma(int numero) {
            MermasModelConsulta mermaModelConsulta = new MermasModelConsulta(numero);
            mermaModelConsulta.resumenEntries();

            return mermaModelConsulta; 

        }

        public void anularEscaneosItemCodeNumero(MermasEntryResumenActualizar mermasEntryResumenActualizar)
        {

            mermasEntryResumenActualizar.anular();
        }

        public string cancelarMerma(int numero) {

            mermasHeaderRepo.cancelarDocumentoIntermedioMerma(numero); 
            return "Merma cancelado"; 
        }
    
    }
}
