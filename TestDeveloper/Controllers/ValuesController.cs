using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace TestDeveloper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        DB db = new DB();
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            string query = @";with trialbalance(acc_number,acc_parent,balance) 
                            as (
                           select Acc_Number, ACC_Parent, Balance from Accounts 
                           

                              Union All 

                            select A.Acc_Number,A.ACC_Parent , T.balance 
                            from Accounts A  Inner Join trialbalance T on A.Acc_Number=T.acc_parent
                              )
                            select Acc_number top_Level_Account,sum(balance) top_balance  from trialbalance where acc_parent is null
							Group by Acc_number";
            DataTable dt = db.GetData(query);
            var result = new ObjectResult(dt);
            return result;


            
        }
     
        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {

            string query = @";with  y
as (
                            select * from Accounts 
                            where acc_number ="+id+ @"
					        

                              union All 

                            select x.*
                            from Accounts x INNER JOIN y hany ON  x.acc_parent = hany.acc_number
                              )



                            select  b.ACC_Number acc_number,SUM(b.Balance) Balance
							from y a , y b
							where a.Acc_Number=b.ACC_Parent
							group by b.ACC_Number";

            DataTable dt = db.GetData(query);
            var result = new ObjectResult(dt);
            return result;


        }

        
        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
