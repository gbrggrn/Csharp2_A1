using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp2_A1.Control
{
    /// <summary>
    /// Class responsible for generating IDs and keeping track of them.
    /// </summary>
    internal class IdGenerator
    {
        private int[] generatedIds;
        private int registrySize;
        private Random random;

        /// <summary>
        /// Constructor initializes the instance variables.
        /// </summary>
        /// <param name="registrySizeIn"></param>
        internal IdGenerator(int registrySizeIn)
        {
            registrySize = registrySizeIn;
            generatedIds = new int[registrySize];
            random = new Random();
        }

        /// <summary>
        /// Generates IDs until a unique is found.
        /// Adds the unique ID to a list of generated IDs.
        /// </summary>
        /// <returns>The generated ID as a string</returns>
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

        /// <summary>
        /// Removes an ID from the list of generated IDs.
        /// </summary>
        /// <param name="idIn"></param>
        internal void DeleteId(int idIn)
        {
            generatedIds[idIn] = 0;
        }

        /// <summary>
        /// Generates a random number in the range of registrySize.
        /// </summary>
        /// <returns></returns>
        internal int TryGenerateId()
        {
            return random.Next(registrySize);
        }
    }
}
