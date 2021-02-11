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
                var query = from ca in context.Cars
                            join b in context.Brands
                            on ca.BrandId equals b.Id
                            join co in context.Colors
                            on ca.ColorId equals co.Id
                            select new CarDetailDto
                            {
                                Id = ca.Id,
                                DailyPrice = ca.DailyPrice,
                                BrandName = b.BrandName.Trim(),
                                ColorName = co.ColorName.Trim()
                            };
                
                return query.ToList();

            }
        }
    }
}
