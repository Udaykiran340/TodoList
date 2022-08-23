using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using W1.Models;
using System.Text.Json;
//This are the changes that i have made
namespace W1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly TodoContext _context;
        public TodoController(TodoContext context){
             _context = context;              
        }
        [HttpGet] 
        public string GetAll() 
        {     
            var opt=new JsonSerializerOptions{WriteIndented=true};
            string a="Task list \n" + JsonSerializer.Serialize(_context.TodoItems,opt); 
            Console.WriteLine(a);
        return a; 
        } 
        
        [HttpGet("{id}", Name = "GetTodo")] 
        public string GetById(int id) 
        {        
        var he=_context.TodoItems.Find(id);
        var hu =_context.items.Find(id);
        if (hu == null)    
        {         
            string b="NotFound2";
            return b; 
        } 
        var opt=new JsonSerializerOptions{WriteIndented=true};
            string a="Task list \n" + JsonSerializer.Serialize(he,opt); 
            if (he == null)    
        {         
            string b="NotFound1";
            return b; 
        }    
        Console.WriteLine(a);
            return a;
        }
        [HttpPost]
        public todoitem Post([FromBody] todoitem t1){
            _context.TodoItems.Add(t1);
            _context.items.Add(t1._item);
            _context.SaveChanges(); 
            
            return t1;
        }
        [HttpPut("{id}")]
    public ActionResult Update(int id,todoitem item)
    {
        if (item == null)
        {
            return BadRequest();
        }

        var supplier = _context.TodoItems.Find(id);
        if (supplier == null)
        {
            return NotFound();
        }

        supplier._item.desc = item._item.desc;

        _context.TodoItems.Update(supplier);
        _context.SaveChanges();
        return Ok();
    }
    }
}
