using CoreGeneralization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrameworkCommon.MethodParameters
{
    public class MenuMethodInput
    {
        public IAction Action { get; set; }
        public Module Module { get; set; }
        public ToolStripMenuItem MenuItem { get; set; }
    }
}
