using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapProjectContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from ca in context.Cars
                             join b in context.Brands on ca.BrandId equals b.Id
                             join co in context.Colors on ca.ColorId equals co.Id
                             join ci in context.CarImages on ca.Id equals ci.Id
                             select new CarDetailDto
                             {
                                 CarId = ca.Id,
                                 CarName = b.BrandName,
                                 BrandName = b.BrandName,
                                 ColorName = co.ColorName,
                                 ImagePath = ci.ImagePath,
                                 DailyPrice = ca.DailyPrice,
                                 ModelYear = ca.ModelYear,
                                 Description = ca.Description
                             };

                return result.ToList();

            }
        }
    }
}
