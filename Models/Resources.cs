using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Fretboard_Theory_Course.Models
{
    public class Resources
    {
        [Key]
        public int ResourcesId { get; set; }
        public string ResourceType { get; set; }
        public virtual List<ResourcesImages> Images { get; set; }
    }
}