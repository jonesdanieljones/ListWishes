using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ListWishes.Application.ViewModels
{
    public class ItemsProductViewModel
    {
        [Key]
        public Guid Id { get; set; }
    }
}
