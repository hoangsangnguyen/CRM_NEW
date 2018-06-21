﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vino.Server.Data.Common;
using Vino.Server.Data.CRM;
using Vino.Server.Services.MainServices.BaseService;

namespace Vino.Server.Services.MainServices.CRM.Customer.Models
{
    public class CrmCustomerModel : BaseDto
    {
        [MaxLength(100)]
        [Index(IsUnique = true)]
        [Required]
        public string CustomerId { get; set; }

        /**
         * Name
         */
        [Required] public string Name { get; set; }
        /**
         * Full English Name
         */
        [Required] public string FullEngishName { get; set; }

        /**
        * Full Viet Nam Name
        */
        [Required] public string FullVietNamName { get; set; }

        /**
        * Address
        */
        [Required] public string Address { get; set; }

        /**
        * Contact
        */
        [Required] public int ContactId { get; set; }
        public string ContactName { get; set; }

        /**
       * Work phone
       */
        [Required] public string WorkPhone { get; set; }

        /**
       * Home Phone
       */
        public string HomePhone { get; set; }

        /**
       * Fax No
       */
        [Required] public string FaxNo { get; set; }

        /**
       *Location
       */
        [Required] public int LocationId { get; set; }
        public string LocationName { get; set; }

        /**
        * Taxcode
        */
        [Required] public string Taxcode { get; set; }

        /**
         *Category
         */
        [Required] public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        /**
         * Website
         */
        public string Website { get; set; }

        /**
         * Email
         */
        [EmailAddress]
        [Required]
        public string Email { get; set; }
    }
}
