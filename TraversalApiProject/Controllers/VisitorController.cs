using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TraversalApiProject.DAL.Context;
using TraversalApiProject.DAL.Entities;

namespace TraversalApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitorController : ControllerBase
    {

        //private readonly VisitorContext _visitorContext;

        //public VisitorController(VisitorContext visitorContext)
        //{
        //    _visitorContext = visitorContext;
        //}


        [HttpGet]
        public IActionResult VisitorList()
        {
            using (var context = new VisitorContext())
            {
                var values = context.Visitors.ToList();

                return Ok(values);

            }
        }
        [HttpPost]

        public IActionResult VisitorAdd(Visitor visitor)
        {
            using (var context = new VisitorContext())
            {
                context.Visitors.Add(visitor);
                context.SaveChanges();
                return Ok();


            }

        }
        [HttpGet("id")]

        public IActionResult VisitorGetById(int id)
        {
            using (var context = new VisitorContext())
            {
                var values = context.Visitors.Find(id);

                if (values == null)
                {
                    return NotFound();

                }
                else
                {
                    return Ok(values);
                }


            }


        }


        [HttpDelete]

        public IActionResult VisitorDelete(int id)
        {
            using (var context = new VisitorContext())
            {
                var values = context.Visitors.Find(id);
                if (values == null)
                {
                    return NotFound();

                }
                else
                {
                    context.Remove(values);
                    context.SaveChanges();
                    return Ok();
                }

            }
        }
        [HttpPut("id")]

        public IActionResult VisitorUpdate(Visitor  visitor)
        {
            using (var context = new VisitorContext())
            {
                var values =context.Find<Visitor>(visitor.VisitorID);
                if (values==null)
                {
                    return NotFound();  

                }
                else
                {
                    values.Name = visitor.Name;
                    values.SurName = visitor.SurName;
                    values.City=visitor.City;
                    values.Country=visitor.Country; 
                    values.Mail=visitor.Mail;

                    context.Update(values);
                    context.SaveChanges() ; 
                    return Ok();
               

                }

            }

        }

    }
}

