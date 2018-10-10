using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebMVC.ViewModels
{
    public class Goal
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        [DisplayName("Target Name")]
        [DataType(DataType.Date)]
        public DateTime TargetDate { get; set; }
    }
}
