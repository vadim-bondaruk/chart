using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    /// <summary>
    /// The common service.
    /// </summary>
    public abstract class BaseService
    {
        /// <summary>
        /// The repository factory to access the repositories.
        /// </summary>
        protected readonly IRepositoryFactory Factory; 

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseService"/> class.
        /// </summary>
        /// <param name="factory">
        /// The repository factory to access to the repositories.
        /// </param>
        protected BaseService(IRepositoryFactory factory)
        {
            Factory = factory;
        }
    }
}
