using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Falcon.Web.Core.Helpers;
using Vino.Server.Data.Common;
using Vino.Server.Services.Database;
using Vino.Server.Services.MainServices.Common.Models;
using Vino.Shared.Constants.Warehouse;

namespace Vino.Server.Services.MainServices.Common
{
    public class OrderGenCodeService
    {
        private readonly DataContext _dataContext;

        public OrderGenCodeService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        #region Order Gen Code
        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderPrefix"><see cref="BookPrefixes"/></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public OrderGenCodeModel GetOrderGenCode(string orderPrefix, DateTime date)
        {
            var orderGenCode =
                _dataContext.OrderGenCodes.FirstOrDefault(f => f.CurrentDate == date && f.OrderPrefix == orderPrefix);
            if (orderGenCode == null)
            {
                orderGenCode = new OrderGenCode
                {
                    CurrentDate = date,
                    OrderPrefix = orderPrefix,
                    Begin = 0,
                    End = 999,
                    CurrentNumber = 0
                };
                _dataContext.OrderGenCodes.Add(orderGenCode);
                _dataContext.SaveChanges();
            }

            return orderGenCode.MapTo<OrderGenCodeModel>();
        }
        /// <summary>
        /// Cap nhat so hoa don
        /// </summary>
        /// <param name="model"></param>
        public void UpdateOrderGenCode(OrderGenCodeModel model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));
            var orderGenCode = _dataContext.OrderGenCodes.Find(model.Id);
            if (orderGenCode == null || orderGenCode.Deleted)
                return;
            model.MapTo(orderGenCode);

            _dataContext.SaveChanges();
        }
        #endregion
    }
}
