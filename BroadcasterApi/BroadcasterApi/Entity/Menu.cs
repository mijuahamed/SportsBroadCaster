using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entity
{
    public class Menu:BaseEntity
    {
        [Required]
        public int RootId { set; get; }
        [Required]
        public string Name { set; get; }
        public int Type { set; get; }
        [Required]
        public string Url { set; get; }
        public List<MenuRole> MenuRole { set; get; }
    }
}
