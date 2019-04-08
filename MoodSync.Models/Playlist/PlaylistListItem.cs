using MoodSync.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodSync.Models.Playlist
{
    public class PlaylistListItem
    {
        [Key]
        public int PlaylistId { get; set; }
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public string PlaylistName { get; set; }
        [Required]
        public string SongList { get; set; }
        public virtual Song Song { get; set; }
    }
}
