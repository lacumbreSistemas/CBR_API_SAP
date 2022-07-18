using Domain.Interfaces;
using Intermedia_;
using Intermedia_.Repositories.Produccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Produccion
{
    public class ProcesosEntryModelBuild:ProduccionEntryModelMaster
    {
        IModelEntryBuildProcesos Estrategia;
        public ProcesosEntryModelBuild() { 
        
        
        }

        public ProcesosEntryModelBuild(IModelEntryBuildProcesos estrategia)
        {

            Estrategia = estrategia;
        }

        public ProcesosEntryModelBuild(ProcesosEntryModelBuild produccionEntryModelBuild, IModelEntryBuildProcesos estrategia)
        {
            codigoProducto = produccionEntryModelBuild.codigoProducto;
            this.cantidad = produccionEntryModelBuild.cantidad;
            this.deleted = produccionEntryModelBuild.deleted;
            this.deletedId = produccionEntryModelBuild.deletedId;
            this.descripcionProducto = produccionEntryModelBuild.descripcionProducto;
            this.fecha = produccionEntryModelBuild.fecha;
            this.numero = produccionEntryModelBuild.numero;
            this.usuario = produccionEntryModelBuild.usuario;
            this.cantidad = cantidad;
            setNombreProducto();
            Estrategia = estrategia;
        }

        public ProcesosEntryModelBuild guardar() {


            return Estrategia.guardar(this); 
        }
    }
}
