using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WmBlazor.Shared
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        [Column(TypeName = "decimal(8,2)")]
        public decimal ?PriceGb { get; set; }
        public int DeveloperId { get; set; }
        public int PublisherId { get; set; }

        public virtual Developer Developer { get; set; }
        public virtual Publisher Publisher { get; set; }
    }
}
