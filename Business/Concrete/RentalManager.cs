using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        public IResult Add(Rental rental)
        {
            return new SuccessResult(Messages.Success);
        }

        public IResult Delete(Rental rental)
        {
            return new SuccessResult(Messages.Success);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.Success);
        }

        public IDataResult<List<RentalDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetCarDetails());
        }

        public IResult Update(Rental rental)
        {
            return new SuccessResult(Messages.Success);
        }
    }
}
