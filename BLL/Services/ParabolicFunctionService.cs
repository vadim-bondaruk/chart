using BLL.Infrastructure;
using Common.Models;
using Common.ViewModels;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ParabolicFunctionService : BaseService, IParabolicFunctionService
    {
        public ParabolicFunctionService(IRepositoryFactory factory) : base(factory)
        {
        }

        public ICollection<CacheDataView> CalculateChart(ParamViewModel paramModel)
        {
            if (paramModel == null)
            {
                throw new ArgumentNullException("param");
            }

            //TODO: add automapper
            Param param = new Param
            {
                CoefficientA = paramModel.CoefficientA,
                CoefficientB = paramModel.CoefficientB,
                CoefficientC = paramModel.CoefficientC,
                Step = paramModel.Step,
                RangeFrom = paramModel.RangeFrom,
                RangeTo = paramModel.RangeTo
            };

            using (var paramRepository = Factory.GetParamRepository())
            {
                param.Points = new List<CacheData>();
                for (double i = param.RangeFrom; i <= param.RangeTo; i+=param.Step)
                {

                    param.Points.Add(new CacheData
                    {
                        PointX = i,
                        PointY = CalculatePointY(param.CoefficientA, param.CoefficientB, param.CoefficientC, i)
                    });

                }

                paramRepository.AddOrUpdate(param);
                paramRepository.SaveChanges();
            }

            return param.Points?.Select(cd => new CacheDataView { x = cd.PointX, y = cd.PointY })?.ToList();

        }

        public ICollection<CacheDataView> CalculateChartParallel(ParamViewModel paramModel)
        {
            if (paramModel == null)
            {
                throw new ArgumentNullException("param");
            }

            //TODO: add automapper
            Param param = new Param
            {
                CoefficientA = paramModel.CoefficientA,
                CoefficientB = paramModel.CoefficientB,
                CoefficientC = paramModel.CoefficientC,
                Step = paramModel.Step,
                RangeFrom = paramModel.RangeFrom,
                RangeTo = paramModel.RangeTo
            };

            int elementsCount= (int)((param.RangeTo - param.RangeFrom) / param.Step) + 1;

            var elements = new CacheData[elementsCount];

            Parallel.For(0, elementsCount, i => {
                var x = param.RangeFrom + param.Step * i;
                var y = CalculatePointY(param.CoefficientA, param.CoefficientB, param.CoefficientC, x);
                elements[i] = new CacheData { PointX = x, PointY = y };
            });

            using (var paramRepository = Factory.GetParamRepository())
            {
                param.Points = elements;
                paramRepository.AddOrUpdate(param);
                paramRepository.SaveChanges();
            }

            return elements.Select(cd => new CacheDataView { x = cd.PointX, y = cd.PointY })?.ToList();
        }

        public bool CheckIfStored(ParamViewModel paramModel, out ICollection<CacheDataView> data)
        {
            if (paramModel == null)
            {
                throw new ArgumentNullException("param");
            }

            using (var paramRepository = Factory.GetParamRepository())
            {
                var storedParam = paramRepository.GetAll(p =>
                                        p.CoefficientA == paramModel.CoefficientA &&
                                        p.CoefficientB == paramModel.CoefficientB &&
                                        p.CoefficientC == paramModel.CoefficientC &&
                                        p.Step == paramModel.Step &&
                                        p.RangeFrom == paramModel.RangeFrom &&
                                        p.RangeTo == paramModel.RangeTo
                                        
                                    )
                                    .FirstOrDefault();
                if(storedParam == null)
                {
                    data = null;
                    return false;
                }
                else
                {
                    using (var cacheDataRepository = Factory.GetCacheDataRepository())
                    {
                        data = cacheDataRepository.GetAll( cd => cd.ParamId == storedParam.Id)?.Select(cd => new CacheDataView { x = cd.PointX, y = cd.PointY })?.ToList();
                    }

                    return true;
                }
            }

        }

        private double CalculatePointY(double CoefficientA, double CoefficientB, double CoeffficientC, double x)
        {
            return CoefficientA * Math.Pow(x, 2) + CoefficientB * x + CoeffficientC;
        }
    }
}
