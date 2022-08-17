using System.Text.Json.Serialization;
namespace W1.Models{
    public class todoitem{
        [JsonIgnore]
        public int id{get;set;}
        public item i1{get;set;}
    }
}