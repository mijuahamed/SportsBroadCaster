using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entity
{
    public class File : BaseEntity
    {
        
        [Required]
        public string Name { set; get; }
        [Required]
        public string Path { set; get; }
        [Required]
        public string Type { set; get; }
        public string Source { set; get; }

        public List<UserFile> UserFile { set; get; }
    }
}
