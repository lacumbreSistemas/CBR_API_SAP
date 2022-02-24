using Microsoft.AspNetCore.Mvc;
using SAP.Repositories;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TEST.Filtros;

namespace TEST.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ItemController : Controller
    {
       private  ItemAppRepository item = new ItemAppRepository();
        private Response response = new Response();



        //[ServiceFilter(typeof(FiltroResponse))]
        [HttpGet("{ItemCode}")]
        public IActionResult Get(string ItemCode)
        {
            var Item =  item.obtenerItem(ItemCode);
            response.status = 1;
            response.mensaje = "Item " + Item.descripcion + "con código" + Item.itemloockupcode;
            response.data = Item;
           
            return Ok(response);
        }
    }
}
