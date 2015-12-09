using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMO_MDS_Sample_Web_API.Models
{
    public class Allergy
    { 
        public int Id { get; set; }
        public string Name { get; set; }

        public Allergy(int a, string b)
        {
            this.Id = a;
            this.Name = b;
        }
    }
}