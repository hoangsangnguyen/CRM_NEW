using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vino.Server.Services.MainServices.Common.Models;
using Vino.Shared.Constants.Common;

namespace Vino.Server.Web.Api
{
    public class NewsItemTypesApiController : BaseApiController
    {
        public List<NameValueModel> GetNewsTypes()
        {
            return new List<NameValueModel>()
            {
                new NameValueModel()
                {
                    Name = NewsItemTypes.Market_News,
                    Value = NewsItemTypes.Market_News
                },
                new NameValueModel()
                {
                    Name = NewsItemTypes.Bussiness_Operations,
                    Value = NewsItemTypes.Bussiness_Operations
                }

            };

        }
    }
}