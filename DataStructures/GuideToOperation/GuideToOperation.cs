using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingForAgriculturalTax
{
    public class GuideToOperation
    {
        int internalIndex;

        public int GetInternalIndex()
        {
            return internalIndex;
        }

        public void SetInternalIndex(int internalIndex)
        {
            this.internalIndex = internalIndex;
        }

        public string Name { get; set; }

        public GuideToOperation(string name)
        {
            Name = name;
        }
    }
}
