using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyG02.DAL.Models
{
    public class Deaprtment
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="name is requird")]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required(ErrorMessage = "code is requird")]
      
        public string Code { get; set; }
        public DateTime DateOfcreation { get; set; }
        public ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
    }
}
