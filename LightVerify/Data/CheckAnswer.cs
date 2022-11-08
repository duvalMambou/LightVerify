using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightVerify.Data
{
    public class Answer
    {
        public int Id { get; set; }

        public string Date { get; set; }

        public string Time { get; set; }

        public DateTime DateSent { get; set; }

        public string Status { get; set; }
    }

}
