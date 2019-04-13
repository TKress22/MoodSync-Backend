using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodSync.Models
{
    public class SongCreate
    {
        public int SongId { get; set; }
        public int GenreId { get; set; }
        public string SongName { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }
        public bool ChildFriendly { get; set; }
    }
}