using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace str_diff
{
    public class InDel
    {
        private IList<Edit> edits;

        public InDel(IList<Edit> edits)
        {
            this.edits = edits;
        }

        public IEnumerable<Edit> Edits()
        {
            return edits;
        }
    }
}
