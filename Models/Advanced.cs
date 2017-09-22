using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Fretboard_Theory_Course.Models
{
    public class Advanced
    {
        [Key]
        public int AdvancedId { get; set; }
        public string LessonName { get; set; }
        public virtual List<AdvancedImages> Images { get; set; }
    }
}