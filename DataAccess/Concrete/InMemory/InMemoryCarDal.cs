﻿using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{Id=1, BrandId=1, ColorId=3, DailyPrice=100, Description="first car"},
                new Car{Id=2, BrandId=1, ColorId=3, DailyPrice=200, Description="second car"},
                new Car{Id=3, BrandId=2, ColorId=1, DailyPrice=300, Description="third car"},
                new Car{Id=4, BrandId=2, ColorId=1, DailyPrice=400, Description="fourth car"},
                new Car{Id=5, BrandId=3, ColorId=2, DailyPrice=500, Description="fifth car"},
                new Car{Id=6, BrandId=3, ColorId=2, DailyPrice=600, Description="sixth car"}
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = null;

            carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public int GetById(Car car)
        {
            Car carGetById = _cars.SingleOrDefault(c => c.Id == car.Id);

            return carGetById.Id;
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToDelete.DailyPrice = car.DailyPrice;
            carToDelete.Description = car.Description;


        }
    }
}
