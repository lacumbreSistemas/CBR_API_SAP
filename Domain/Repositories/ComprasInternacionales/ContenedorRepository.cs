using Domain.Models;
using Domain.Models.ComrpasModels;
using SAP.Repositories.ComprasInternacionalesContenedor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories.ComprasInternacionales
{
    public class ContenedorRepository
    {
        private ComprasInternacionalesContenedorRepository comprasContenedoresRepo = new ComprasInternacionalesContenedorRepository();
        private EscaneoImportadosRepository escaneoRespository = new EscaneoImportadosRepository();



        public List<ContenedorModel> contenedoresAbiertos(string WhsCode) {

            List<ContenedorModel> contenedores = new List<ContenedorModel>();

            var contenedoresAbiertos = comprasContenedoresRepo.obtenerContenedorAbierto(WhsCode);

            contenedoresAbiertos.ForEach(numeroContenedor =>
            {
                ContenedorModel contenedor = new ContenedorModel(numeroContenedor);

                contenedores.Add(contenedor);
            });

        
            return contenedores;
        }



        public EscaneoBuildModel agregar(EscaneoBuildModel escaneo , string numeroContenedor) {

           var numeroOrdenCompra= comprasContenedoresRepo.obtenerNumeroOrdenDecompraPorArtículo(escaneo.codigoProducto, numeroContenedor);
            escaneo.ordenCompraDocEntry = numeroOrdenCompra;
            return escaneoRespository.Agregar(escaneo);

        }


    }
}
