using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FSEFinalTaskBusiness;
using Microsoft.AspNetCore.Mvc;

namespace FSEFinalTaskService.Controllers
{
    [Produces("application/json")]
    [Route("api/MyData")]
    
    public class MyDataController : Controller
    {
        private readonly MyDataTask _myDataTask;
        public MyDataController(MyDataTask myDataTask)
        {
            _myDataTask = myDataTask;

        }
        [HttpGet]
        [Route("Get")]
       public List<MyDataModel> Get()
        {
            var mydataList = _myDataTask.GetMyData();
            return mydataList;

        }
        [HttpPost]
        [Route("Insert")]
        public IActionResult Create([FromBody] MyDataModel myDataModel)
        {
             _myDataTask.CreateMyData(myDataModel);
            return Created(Request.Path, myDataModel);

        }


        [HttpPut]
        [Route("Update")]
        public IActionResult Update([FromBody] MyDataModel myDataModel)
        {
            _myDataTask.UpdateMyData(myDataModel);
            return NoContent();
        }

        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete(int applicationCode)
        {
            _myDataTask.DeleteMyData(applicationCode);
            return NoContent();
        }
    }
}