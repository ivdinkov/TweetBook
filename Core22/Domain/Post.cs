using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core22.Domain
{
    public class Post
    {
        [Key]
        public Guid ID { get; set; }
        public string Name { get; set; }
    }
}
