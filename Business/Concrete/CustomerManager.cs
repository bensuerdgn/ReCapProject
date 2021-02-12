using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;
        public CustomerManager(ICustomerDal customerDal )
        {
            _customerDal = customerDal;
        }
        public IResult Add(Customer customer)
        {
            return new SuccessResult(Messages.Success);
        }

        public IResult Delete(Customer customer)
        {
            return new SuccessResult(Messages.Success);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(), Messages.Success);
        }

        public IResult Update(Customer customer)
        {
            return new SuccessResult(Messages.Success);
        }
    }
}
