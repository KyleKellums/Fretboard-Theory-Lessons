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
    public class UserFoundations
    {
        [Key]
        public int UserFoundationsId { get; set; }

        public int FoundationsId { get; set; }

        public bool IsCompleted { get; set; }

        [Required]
        public virtual ApplicationUser User { get; set; }
    }
}