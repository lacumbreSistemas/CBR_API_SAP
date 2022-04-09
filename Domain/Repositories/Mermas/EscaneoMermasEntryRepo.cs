using Domain.Models.Mermas;
using Intermedia_.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories.Mermas
{
    public class EscaneoMermasEntryRepo
    {
     

        private MermasEntryRepo mermasEntryRepo {get; set;}
        public EscaneoMermasEntryRepo() {
            mermasEntryRepo = new MermasEntryRepo(); 
        }


        public MermasEntryModelBuild crearMermaEntry(MermasEntryModelBuild mermas) {
            MermasEntryModelBuild mermasEntryModelBuild = new MermasEntryModelBuild(mermas);
            return mermasEntryModelBuild.guardar();

        }

        public List<MermasEntryModelConsulta> historielEntries(int number, string itemCode) {

            List<MermasEntryModelConsulta> historialEntries = new List<MermasEntryModelConsulta>();

            mermasEntryRepo.obtenerItemsPorNumberItemCode(number, itemCode).ForEach(i=> {

                MermasEntryModelConsulta entrie = new MermasEntryModelConsulta();

                entrie.cantidad = (double)i.quantity;
                entrie.deleted = i.deleted;
                entrie.deletedId = i.deletedid;
                entrie.fecha = i.fecha;
                entrie.id = i.id;
                entrie.codigoProducto = i.itemCode;
                entrie.numero = (int)i.number;
                entrie.usuario = i.usuario;


                historialEntries.Add(entrie); 

            });

            return historialEntries;
        }

        public MermasEntryModelConsulta anularEscane(MermasEntryModelConsulta mermasEntryModelConsulta) {

            return mermasEntryModelConsulta.anular();


        }

    }
}
