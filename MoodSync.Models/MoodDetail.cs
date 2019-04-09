using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodSync.Models
{
    public class MoodDetail
    {
        [Key]
        public int MoodId { get; set; }
        [Required]
        public string MoodName { get; set; }
    }
}
