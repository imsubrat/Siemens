using System;
using System.Collections.Generic;
using System.Linq;
using Siemens.Entity;
using Siemens.Helper;
using Siemens.Model;

namespace Siemens.Service
{
    public interface IDiscountService
    {
        PriceModel Calculate(PriceModel input);
    }

    public class DiscountService : IDiscountService
    {
        private DataContext _context;

        public DiscountService(DataContext context)
        {
            _context = context;
        }

        public PriceModel Calculate(PriceModel input)
        {
             
            double discount = _context.Prices.Where(s=>s.userType==input.userType).Select(s=>s.discount).FirstOrDefault();
            input.total=(input.pricePerGm*input.weight)*(100-discount)/100;

            return input;
        }
    }
}