using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ConstrustionAnalyser.Models
{
    public class DailyExpences
    {
        [Display(Name = "ID")]
        public int DailyExpencesId { get; set; }

        [Required(ErrorMessage = "Amount is required.")]
        public double expencesAmount { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        public string expenceDescription { get; set; }

        [Required(ErrorMessage = "Date is required.")]
        public DateTime expenceDate { get; set; }

        public string remark { get; set; }
    }
}