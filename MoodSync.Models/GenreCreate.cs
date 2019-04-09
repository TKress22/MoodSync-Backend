﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodSync.Models
{
    public class GenreCreate
    {
        [Key]
        public int GenreId { get; set; }
        [Required]
        public string GenreName { get; set; }
    }
}
