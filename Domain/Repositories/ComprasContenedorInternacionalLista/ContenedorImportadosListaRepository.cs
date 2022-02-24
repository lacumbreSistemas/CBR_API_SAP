using Domain.Models;
using Intermedia_.Repositories;
using SAP.Repositories.ComprasInternacionales;
using SAP.Repositories.ComprasInternacionalesContenedor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories.ComprasContenedorInternacionalLista
{
   public  class ContenedorImportadosListaRepository
    {

        private ComprasInternacionalesContenedorRepository comprasInternacionalesContenedorRepository { get; set; }
      
        public ContenedorImportadosListaRepository() {
            comprasInternacionalesContenedorRepository = new ComprasInternacionalesContenedorRepository();
        }


        public ContenedorListaModel obtenerContenedor(string numeroContenedor,bool includeEntries= false) {

            ContenedorListaModel contenedor = new ContenedorListaModel(numeroContenedor, includeEntries);

            return contenedor;
        }



        public List<ContenedorListaModel> obtenercontenedoresAbiertos(string WhsCode)
        {

            List<ContenedorListaModel> contenedores = new List<ContenedorListaModel>();
            cbr_contenedoresInternacionalesCerradosRepo contenedoresInternacionalesCerradosRepo = new cbr_contenedoresInternacionalesCerradosRepo();

            var contenedoresAbiertos = comprasInternacionalesContenedorRepository.obtenerContenedorAbierto(WhsCode);

            contenedoresAbiertos.ForEach(numeroContenedor =>
            {
                if (!contenedoresInternacionalesCerradosRepo.siContenedorCerrado(numeroContenedor))
                {
                    ContenedorListaModel ContenedorList = new ContenedorListaModel(numeroContenedor);

                    contenedores.Add(ContenedorList);

                }

               

            });


            return contenedores;
        }

    }
}
