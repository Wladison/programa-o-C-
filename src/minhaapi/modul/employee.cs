using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace minhaapi.modulo
{
    [Table("employee")]
    public class Employee
    {
        [Key]
        public int Id { get; private set; }
        public string descricao { get; private set; }
        public int status { get; private set; }
        public Employee(int id, string descricao,int  status) 
        {
            this.Id = id;
            this.descricao = descricao ?? throw new ArgumentNullException (descricao);
            this.status = status;
        
        }
    }
}
