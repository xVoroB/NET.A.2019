using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Interfaces
{
    /// <summary>
    /// Interface for account number generator classes
    /// </summary>
    public interface IAccountNumberService
    {
        /// <summary>
        /// Generates number
        /// </summary>
        /// <param name="number">Given number</param>
        /// <returns>Generated number</returns>
        int GenerateNumber(int number);
    }
}
