using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //test();
            //test2();
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.GetAll();
        }

        private static void test2()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();
            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.BrandName + "/" + car.ColorName + "/" + car.DailyPrice.ToString());
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void test()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var car in carManager.GetCarDetails().Data)
            {

                Console.WriteLine(car.BrandName + "/" + car.ColorName + "/" + car.DailyPrice.ToString());
            }
        }
    }
}
