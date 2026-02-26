using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerse.BL.DTOS.CategoryDTOS
{
    public class CategoryUpdateDto
    {
        [Required(ErrorMessage = "Ad mütləq daxil edilməlidir.")]
        [MaxLength(50, ErrorMessage = "Ad ən çox 50 simvol ola bilər.")]
        public string Name { get; set; }
    }
}
