using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Newbee.Models
{
    public class M_Question
    {
        public int Num { get; set; }

        public string Content { get; set; }

        public string Pic { get; set; }

        public int Point { get; set; }

        public List<M_QuesOption> Options { get; set; }
    }
}