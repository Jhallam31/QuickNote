﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickNote.Models.CategoryModels
{
    public class CategoryCreate
    {
        [Display(Name= "Category Name")]
        public string CategoryName { get; set; }
    }
}
