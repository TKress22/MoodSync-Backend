using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodSync.Data
{
    public class Song
    {
        [Key]
        public int SongId { get; set; }
        [Required]
        public int GenreId { get; set; }
        [Required]
        public string SongName { get; set; }
        [Required]
        public string Artist { get; set; }
        [Required]
        public string Album { get; set; }
        [Required]
        public bool ChildFriendly { get; set; }
    }
}