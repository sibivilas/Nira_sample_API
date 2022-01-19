using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nira_SampleProject.Models
{
    public class MesssageModel
    {
        public string message { get; set; } // success or failed
        public bool status { get; set; }     // True or false 
        public object datas { get; set; }
    }
}