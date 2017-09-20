using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Fretboard_Theory_Course.Models
{
    public class UserIntermediate
    {
        [Key]
        public int UserIntermediateId { get; set; }

        public int IntermediateId { get; set; }

        public bool IsCompleted { get; set; }

        [Required]
        public virtual ApplicationUser User { get; set; }
    }
}