using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WmBlazor.Shared
{
    public class User
    {
        [Key]
        public string Username { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        
        public virtual Role Role { get; set; }
        public int RoleId { get; set; }
    }
}
