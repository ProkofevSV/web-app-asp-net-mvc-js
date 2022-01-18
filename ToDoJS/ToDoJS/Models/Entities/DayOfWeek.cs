﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToDoJS.Extensions;
using ToDoJS.Models.Attributes;

namespace ToDoJS.Models
{
    public class DayOfWeek
    {
        /// <summary>
        /// Id
        /// </summary> 
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        /// <summary>
        /// Название дня недели
        /// </summary>    
        [Required]
        [Display(Name = "День недели", Order = 5)]
        public string DayOfWeekName { get; set; }
                
        /// <summary>
        /// Дела
        /// </summary> 
        [ScaffoldColumn(false)]
        public virtual ICollection<Task> Tasks { get; set; }

    }
}