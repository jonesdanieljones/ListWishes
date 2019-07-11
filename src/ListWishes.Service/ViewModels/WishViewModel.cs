using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ListWishes.Application.ViewModels
{
    public class WishViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The Userid is Required")]
        [EmailAddress]        
        [DisplayName("UserId")]
        public int UserId { get; set; }
    }
}
