using Domain.Repositories;
using Intermedia_;
using Intermedia_.Repositories;
using SAP.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.ComrpasModels
{
    public class ListaEscaneosImportados
    {

        public int id { get; set; }
        public string codigoProducto { get; set; }
        public string nombreProdcuto { get; set; }
        public string usuario { get; set; }
        public double cantidad { get; set; }
        public DateTime fecha { get; set; }
        public bool eliminado { get; set; }
        public string numeroContenedor { get; set; }

        public bool matriculado { get; set; }

        private cbr_listaItemsRecepcionImportadosRepository listaEscaneosRepository {get; set;}

        private ItemSAPRepository itemSAPRepo { get; set; }




        public ListaEscaneosImportados() {
            listaEscaneosRepository = new cbr_listaItemsRecepcionImportadosRepository();
            itemSAPRepo = new ItemSAPRepository();


        }

        public ListaEscaneosImportados(int id)
        {
            listaEscaneosRepository = new cbr_listaItemsRecepcionImportadosRepository();
            itemSAPRepo = new ItemSAPRepository();

            obtenerEscaneoporID(id);
        }

        public ListaEscaneosImportados(ListaEscaneosImportados Escaneo)
        {
            this.codigoProducto = Escaneo.codigoProducto;
            this.nombreProdcuto = Escaneo.nombreProdcuto;
            this.usuario = Escaneo.usuario;
            this.cantidad = Escaneo.cantidad;
            this.fecha = Escaneo.fecha;
            this.eliminado = Escaneo.eliminado;
            this.numeroContenedor = Escaneo.numeroContenedor;
            itemSAPRepo = new ItemSAPRepository();
            setNombreProducto();
            listaEscaneosRepository = new cbr_listaItemsRecepcionImportadosRepository();
        }



        private void obtenerEscaneoporID(int id)
        {

            var Escaneo = listaEscaneosRepository.obtenerEscaneoPorID(id);
            this.id = Escaneo.id;
            this.codigoProducto = Escaneo.itemCode;
            this.usuario = Escaneo.usuario;
            this.cantidad = Escaneo.cantidad;
            this.fecha = Escaneo.fecha;
            this.eliminado = Escaneo.deleted;
            this.numeroContenedor = Escaneo.numeroContenedor;
            setNombreProducto();




        }


        public  void setNombreProducto() {

            var item = itemSAPRepo.ObtenerItemPorItemCode(codigoProducto);

            if (item == null)
            {

                nombreProdcuto = "N/A";
            }
            else {

                nombreProdcuto = item.ItemName;
            }


        }

      

        public int Anular()
        {
            
            if (this.eliminado)
                throw new Exception("Este escaneo ya fue elimiando");
          
            return listaEscaneosRepository.borrarEscaneo(this.id);
        }

        public ListaEscaneosImportados agreagar()
        {
            cbr_listaItemsRecepcionImportados escaneoIntermedia = new cbr_listaItemsRecepcionImportados();
            escaneoIntermedia.itemCode = this.codigoProducto;
            escaneoIntermedia.usuario = this.usuario;
            escaneoIntermedia.numeroContenedor = this.numeroContenedor;
            escaneoIntermedia.fecha = DateTime.Now;
            escaneoIntermedia.deleted = eliminado;
            escaneoIntermedia.deletedId = 0;
            escaneoIntermedia.cantidad = this.cantidad;
            

            listaEscaneosRepository.GuardarEscaneo(escaneoIntermedia);
            return this;
        }
    }
}
