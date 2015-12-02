using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMO_MDS_Sample_Web_API.Models
{
    public class Medication
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Medication(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}

