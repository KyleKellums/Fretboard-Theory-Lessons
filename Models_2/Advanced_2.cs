using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGeneration.Design;

namespace Fretboard_Theory_Course.Models
{
    public class Advanced_2
    {
        [Key]
        public int AdvancedId { get; set; }
        public string LessonName { get; set; }
        public List<string> Images { get; set; }
    }
}