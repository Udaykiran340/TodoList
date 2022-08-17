using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;
namespace W1.Models{
    public class todoitem{
        public int id{get;set;}
        public int itemid{get;set;}
    public todoitem.item _item { get; set; }
    public class item{
            public int itemid{get;set;}
            public string desc{get;set;}
        }
    }

}