using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Fretboard_Theory_Course.Models
{
    public class Foundations
    {
        [Key]
        public int FoundationsId { get; set; }
        public string LessonName { get; set; }
        public virtual List<FoundationsImages> Images { get; set; }
    }
}