using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp2_A1.Control
{
    internal class IdGenerator
    {
        private string generatedId;

        internal IdGenerator()
        {
            generatedId = string.Empty;
        }

        internal string GenerateId()
        {
            generatedId = Guid.NewGuid().ToString();

            return generatedId;
        }
    }
}
