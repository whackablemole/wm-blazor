using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WmBlazor.Shared
{
    public class Tag
    {
        // Tag must be unique
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;

        // So we can find games that have this tag
        public ICollection<Game> ?Games { get; set; }
    }
}
