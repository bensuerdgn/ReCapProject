using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
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
                new Car{CarId=1, BrandId=1, ColorId=3, DailyPrice=100, Description="first car"},
                new Car{CarId=2, BrandId=1, ColorId=3, DailyPrice=200, Description="second car"},
                new Car{CarId=3, BrandId=2, ColorId=1, DailyPrice=300, Description="third car"},
                new Car{CarId=4, BrandId=2, ColorId=1, DailyPrice=400, Description="fourth car"},
                new Car{CarId=5, BrandId=3, ColorId=2, DailyPrice=500, Description="fifth car"},
                new Car{CarId=6, BrandId=3, ColorId=2, DailyPrice=600, Description="sixth car"}
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = null;

            carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public int GetById(Car car)
        {
            Car carGetById = _cars.SingleOrDefault(c => c.CarId == car.CarId);

            return carGetById.CarId;
        }

        public void Update(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToDelete.DailyPrice = car.DailyPrice;
            carToDelete.Description = car.Description;


        }
    }
}
