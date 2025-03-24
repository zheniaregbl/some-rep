using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam25
{
    public class ContractorType
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public ContractorType(long id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
