using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Fretboard_Theory_Course.Models
{
    public class IntermediateImages
    {
        [Key]
        public int ImageId { get; set; }
        public string Path { get; set; }
        public int IntermediateId { get; set; }    
        public Intermediate Intermediate { get; set; }
    }
}