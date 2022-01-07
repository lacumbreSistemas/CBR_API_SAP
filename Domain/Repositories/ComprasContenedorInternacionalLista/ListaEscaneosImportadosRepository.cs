using Domain.Models;
using Domain.Models.ComrpasModels;
using Intermedia_.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public class ListaEscaneosImportadosRepository
    {
        ListaEscaneosImportados escaneoModel { get; set; }
        cbr_listaItemsRecepcionImportadosRepository escaneoRepository { get; set; }




           public  ListaEscaneosImportadosRepository() {
                escaneoModel = new ListaEscaneosImportados();
                escaneoRepository = new cbr_listaItemsRecepcionImportadosRepository();
           }

            public List<ListaEscaneosImportados> getHistorial(string itemCode, string numeroContenedor) {
                
                List<ListaEscaneosImportados> listaEscaneosImportados = new List<ListaEscaneosImportados>();




              var escaneos = escaneoRepository.ObtenerHistorialDeEscaneos(itemCode, numeroContenedor);

            escaneos.ForEach(i=> {
                ListaEscaneosImportados listaEscaneosImportado = new ListaEscaneosImportados();

                listaEscaneosImportado.cantidad = i.cantidad;
                listaEscaneosImportado.codigoProducto = i.itemCode;
                listaEscaneosImportado.setNombreProducto(); 
                listaEscaneosImportado.fecha = i.fecha;
                listaEscaneosImportado.id = i.id;
                listaEscaneosImportado.eliminado = i.deleted;
                listaEscaneosImportado.numeroContenedor = i.numeroContenedor;

                listaEscaneosImportados.Add(listaEscaneosImportado);

            });    



                return listaEscaneosImportados;
            }


        public ListaEscaneosImportados Agregar(ListaEscaneosImportados escaneo)
        {

            ListaEscaneosImportados Escaneo = new ListaEscaneosImportados(escaneo);
            return Escaneo.agreagar();

        }

        public ListaEscaneosImportados anularEscaneo(int escaneo)
        {

            ListaEscaneosImportados es = new ListaEscaneosImportados(escaneo);

            ListaEscaneosImportados anulado = new ListaEscaneosImportados(es.Anular());

            return anulado;


        }

      

    }
}
