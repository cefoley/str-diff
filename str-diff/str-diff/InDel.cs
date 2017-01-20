using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace str_diff
{
    public class InDel
    {
        private IEnumerable<Edit> edits;

        public InDel(IEnumerable<Edit> edits)
        {
            this.edits = edits;
        }

        public IEnumerable<Edit> Edits()
        {
            return edits;
        }
    }
}
