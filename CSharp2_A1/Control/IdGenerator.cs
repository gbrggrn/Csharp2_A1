using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp2_A1.Control
{
    internal class IdGenerator
    {
        private int[] generatedIds;
        private int registrySize;
        private Random random;

        internal IdGenerator(int registrySizeIn)
        {
            registrySize = registrySizeIn;
            generatedIds = new int[registrySize];
            random = new Random();
        }

        internal string GenerateId()
        {
            int tryRandId = TryGenerateId();

            while (true)
            {
                if (generatedIds.Contains(tryRandId))
                {
                    tryRandId = TryGenerateId();
                }
                else
                {
                    generatedIds.Append(tryRandId);
                    break;
                }
            }

            return tryRandId.ToString();
        }

        internal void DeleteId(int idIn)
        {
            generatedIds[idIn] = 0;
        }

        internal int TryGenerateId()
        {
            return random.Next(registrySize);
        }
    }
}
