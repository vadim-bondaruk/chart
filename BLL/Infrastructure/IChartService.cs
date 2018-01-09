using Common.Models;
using Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Infrastructure
{
    public interface IParabolicFunctionService
    {
        /// <summary>
        /// Checking if input data have been cached
        /// </summary>
        /// <param name="param">Function coefficients</param>
        /// <param name="data">Points to plot chart</param>
        /// <returns></returns>
        bool CheckIfStored(ParamViewModel param, out ICollection<CacheDataView> data);

        /// <summary>
        /// Calculating points to plot chart
        /// </summary>
        /// <param name="param">Function coefficients</param>
        /// <returns>Points to plot chart</returns>
        ICollection<CacheDataView> CalculateChart(ParamViewModel param);

        /// <summary>
        /// Calculating points to plot chart in multiple threads
        /// </summary>
        /// <param name="param">Function coefficients</param>
        /// <returns>Points to plot chart</returns>
        ICollection<CacheDataView> CalculateChartParallel(ParamViewModel param);
        

    }
}
