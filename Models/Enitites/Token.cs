using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Enitites
{
    public class Token
    {
        [Key] 
        public int Id { get; set; }
        
        public int UserId { get; set; 
        [ForeignKey("UserId")]
        
        public User User { get; set; }
        
        public string BearerToken { get; set; }
        
    }
}
