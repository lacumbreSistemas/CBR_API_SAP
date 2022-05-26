using Intermedia_.Repositories.Produccion;
using SAP;
using SAP.Repositories.Produccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Produccion
{
    public class ProduccionModelConsulta : ProduccionModelMaster
    {
        public int entradaDocEntry { get; set; }
        public int salidaDocEntry { get; set; }

        public string descripcionReceta { get; set;  }

        public List<ProduccionEntryResumenConsulta> entries { get; set; }


        public ProduccionModelConsulta() {
            entries = new List<ProduccionEntryResumenConsulta>();
        }

        public ProduccionModelConsulta(int numero) {
            entries = new List<ProduccionEntryResumenConsulta>();
            this.numero = numero;
            obtenerHeader();
        }


        public void obtenerHeader() {
            ProduccionHeaderRepo headerRepo = new ProduccionHeaderRepo();

            var documentoproducion = headerRepo.obtenerDocumentoIntermedioProduccion(numero);
            this.codigoTienda = documentoproducion.whsCode;
            this.codigoProducto = documentoproducion.codigoProducto;
            this.usuario = documentoproducion.usuario;
            this.comentario = documentoproducion.comentario;
            this.fechaCreacion = documentoproducion.fecha;
            this.remarkCode = documentoproducion.remarkId;
            this.cantidad = documentoproducion.cantidad; 
           

        
        }

        public void definirdescripcionReceta() {
            ListaMaterialRepoSAP listaMaterialRepoSAP = new  ListaMaterialRepoSAP();
           var listaMaterial =  listaMaterialRepoSAP.obtenerListaMaterialCabecera(codigoProducto);
            descripcionReceta = listaMaterial.Name;

        }

        public void setRemark()
        {
            RemarksRepo mermaModelSAP = new RemarksRepo();

            remark = mermaModelSAP.obterRemark(this.remarkCode);

        }

        public void resumenEntries(){
            ProduccionEntryRepo produccionEntryRepo = new ProduccionEntryRepo();
            produccionEntryRepo.obtenerEntriesPornumber(numero).Where(i=> !i.cancelado).GroupBy(i=> new { i.numero, i.itemcode}).ToList().ForEach(i=> {
                ProduccionEntryResumenConsulta produccionModelConsulta = new ProduccionEntryResumenConsulta(i.FirstOrDefault().itemcode);
                produccionModelConsulta.numero = this.numero;
                produccionModelConsulta.cantidadEscaneada = i.Sum(i => i.quantity);
                entries.Add(produccionModelConsulta);


            }); 


        }


    }
}
