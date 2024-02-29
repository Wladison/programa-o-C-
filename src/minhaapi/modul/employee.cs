using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace minhaapi.modulo
{
    [Table("employee")]
    public class Employee
    {
        [Key]
        public int id { get; private set; }
        public string nome { get; private set; }
        public int age { get; private set; }
        public string? photo { get; private set; }
        public Employee(string nome,int  age,string photo) 
        {
            this.nome = nome ?? throw new ArgumentNullException (nameof(nome));
            this.age = age;
            this.photo = photo;
        
        }
    }
}
