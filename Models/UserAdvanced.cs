using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Fretboard_Theory_Course.Models
{
    public class UserAdvanced
    {
        [Key]
        public int UserAdvancedId { get; set; }

        public int AdvancedId { get; set; }

        public bool IsCompleted { get; set; }

        [Required]
        public virtual ApplicationUser User { get; set; }   
    }
}