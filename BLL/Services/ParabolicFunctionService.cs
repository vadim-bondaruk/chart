using BLL.Infrastructure;
using Common.Models;
using Common.ViewModels;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    public class ParabolicFunctionService : BaseService, IParabolicFunctionService
    {
        protected ParabolicFunctionService(IRepositoryFactory factory) : base(factory)
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
                CoeffficientC = paramModel.CoeffficientC,
                Step = paramModel.Step,
                RangeFrom = paramModel.RangeFrom,
                RangeTo = paramModel.RangeTo
            };

            using (var paramRepository = Factory.GetParamRepository())
            {
                for (double i = param.RangeFrom; i <= param.RangeTo; i+=param.Step)
                {
                    param.Points.Add(new CacheData
                    {
                        PointX = i,
                        PointY = CalculatePointY(param.CoefficientA, param.CoefficientB, param.CoeffficientC, i)
                    });

                    paramRepository.AddOrUpdate(param);
                    paramRepository.SaveChanges();
                }
            }

            return param.Points.Select(cd => new CacheDataView { X = cd.PointX, Y = cd.PointY }).ToList();

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
                                        p.CoeffficientC == paramModel.CoeffficientC &&
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
                    data = storedParam.Points.Select(cd => new CacheDataView { X = cd.PointX, Y = cd.PointY }).ToList();
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
