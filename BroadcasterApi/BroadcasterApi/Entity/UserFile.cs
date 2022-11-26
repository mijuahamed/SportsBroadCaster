using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entity
{
    public class UserFile : BaseEntity
    {
        [ForeignKey("File")]
        public int FileId { set; get; }
        public File File { set; get; }
        public string UserId { set; get; }
    }
}
