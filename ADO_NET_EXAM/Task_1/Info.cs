using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    [Table("TableExchangeRate")]
    public class Information
    {
 
        [Key]
       

            public string title { get; set; }
            public string pubDate { get; set; }
            public string description { get; set; }
            public string quant { get; set; }

      

       

    }
}
