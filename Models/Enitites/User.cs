using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models.Enitites
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public  string Password { get; set; }
        public string Name { get; set; }
        
        public virtual IEnumerable<Token> Tokens { get; set; }
        
    }
    
}
