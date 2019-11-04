using DataLayer;
using ServiceLayer.OrderService.Abstract;
using ServiceLayer.ProductService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceLayer.OrderService.Concrete
{
    public enum DeliveryPaymentOption
    {
        Delivery = 0,
        Payment
    }
    public class DeliveryPaymentDropdownService : IDeliveryPaymentDropdownService
    {
        private readonly EshopContext _db;

        public DeliveryPaymentDropdownService(EshopContext db)
        {
            _db = db;
        }

        public IEnumerable<DropdownTuple> GetDeliveryPaymentDropdown(DeliveryPaymentOption getOptionBy)
        {
            switch (getOptionBy)
            {
                case DeliveryPaymentOption.Delivery:
                    var result = _db.Deliveries
                        .OrderBy(x => x.DeliveryId)
                        .Select(x => new DropdownTuple
                        {
                            Value = x.DeliveryId.ToString(),
                            Text = x.DeliveryOption
                        }).ToList();
                    return result;

                case DeliveryPaymentOption.Payment:
                    var resultPayment = _db.Payments
                        .OrderBy(x => x.PaymentOption)
                        .Select(x => new DropdownTuple
                        {
                            Value = x.PaymentId.ToString(),
                            Text = x.PaymentOption
                        }).ToList();
                    return resultPayment;

                default:
                    throw new ArgumentOutOfRangeException(nameof(getOptionBy), getOptionBy, null);
            }
        }
    }
}
