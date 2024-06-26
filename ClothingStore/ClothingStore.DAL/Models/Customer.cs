﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.DAL.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        [MinLength(9), MaxLength(11)]
        public string Phone { get; set; }
        public int SavePoints { get; set; }
    }
}
