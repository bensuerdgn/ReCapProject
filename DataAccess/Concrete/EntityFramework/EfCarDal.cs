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
                             join co in context.Colors
                             on ca.ColorId equals co.Id
                             join b in context.Brands
                             on ca.BrandId equals b.Id
                             select new CarDetailDto
                             {
                                 Id = ca.Id,
                                 BrandId = b.Id,
                                 ColorId = co.Id,
                                 BrandName = b.BrandName.Trim(),
                                 ColorName = co.ColorName.Trim(),
                                 DailyPrice = ca.DailyPrice,
                                 ModelYear = ca.ModelYear.Trim(),
                                 Description = ca.Description.Trim()
                             };

                return result.ToList();

            }
        }
    }
}
