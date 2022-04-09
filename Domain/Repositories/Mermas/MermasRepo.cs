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

        public List<MermaModelConsulta> obtenerListaMermasIntermediaAbiertas(string WhsCode) {

            List<cbr_MermasHeader> documentoMermaIntermedio = new List<cbr_MermasHeader>();

            documentoMermaIntermedio = mermasHeaderRepo.obtenerDocumentoIntermedioMerma(WhsCode).ToList();

            List<MermaModelConsulta> documentosMermas = new List<MermaModelConsulta>();


            documentoMermaIntermedio.ForEach(i => {

                MermaModelConsulta merma = new MermaModelConsulta();

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

        public MermaModelConsulta resumenDocumentoIntermedioMerma(int numero) {
            MermaModelConsulta mermaModelConsulta = new MermaModelConsulta(numero);
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
