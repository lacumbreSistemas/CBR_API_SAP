using Domain.Models.ComrpasModels;
using Domain.Models.ContenedorListaModels;
using Intermedia_.Repositories;
using SAP.Repositories.ComprasInternacionales;
using SAP.Repositories.ComprasInternacionalesContenedor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
   public  class ContenedorListaModel
    {

       public string numeroContenedor { get; set; }
        public List<ContenedorListaModelEntry> contenedorListaModelEntry { get; set; }


   
        //private

        private cbr_listaItemsRecepcionImportadosRepository listaItemsRecepcionImportadosRepository  { get; set; }


        public ContenedorListaModel() { 
        
        }
        public ContenedorListaModel(string numeroContenedor,bool includeEntries = false) {
            this.numeroContenedor = numeroContenedor;
      
            contenedorListaModelEntry = new List<ContenedorListaModelEntry>();
    
            listaItemsRecepcionImportadosRepository = new cbr_listaItemsRecepcionImportadosRepository();


            if (includeEntries) {
                getContenedorListaEntry();
            }
           
        }

        public void  getContenedorListaEntry() {

            var entries = listaItemsRecepcionImportadosRepository.ObtenerEscaneosContenedor(this.numeroContenedor);
            List<ListaEscaneosImportados> escaneos = new List<ListaEscaneosImportados>();

            entries.ForEach(entrie=> {
                ListaEscaneosImportados escaneo = new ListaEscaneosImportados();
                escaneo.fecha = (DateTime)entrie.fecha;
                escaneo.codigoProducto = entrie.itemCode;
                escaneo.cantidad = (double) entrie.cantidad;
                escaneo.numeroContenedor = entrie.numeroContenedor;
                escaneo.usuario = entrie.usuario;
                escaneo.eliminado = (bool) entrie.deleted;

                escaneo.setNombreProducto();

                escaneos.Add(escaneo);

            });
            escaneos.GroupBy(i => new { i.numeroContenedor, i.codigoProducto }).ToList().ForEach(i => {
                var _codigoProducto = i.FirstOrDefault().codigoProducto;
                var _numeroContenedor = i.FirstOrDefault().numeroContenedor;

                ContenedorListaModelEntry entry = new ContenedorListaModelEntry();
                entry.codigoProducto = i.FirstOrDefault().codigoProducto; 
                entry.cantidadEscaneada = Convert.ToDouble(i.Sum(i=> i.cantidad));
                entry.nombreProducto = i.FirstOrDefault().nombreProdcuto;
                entry.numeroContenedor = i.FirstOrDefault().numeroContenedor;


                contenedorListaModelEntry.Add(entry);
            });

        }


  

    }

}
