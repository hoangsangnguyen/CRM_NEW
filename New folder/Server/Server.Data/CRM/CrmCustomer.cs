using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Falcon.Web.Core.Auth;
using Falcon.Web.Core.Data;
using Vino.Server.Data.Common;

namespace Vino.Server.Data.CRM
{
    public class CrmCustomer : BaseEntity
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
        public string FullEngishName { get; set; }

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
        public virtual CrmContact Contact { get; set; }

        /**
       * Work phone
       */
        public string WorkPhone { get; set; }

        /**
       * Home Phone
       */
        public string HomePhone { get; set; }

        /**
       * Fax No
       */
       public string FaxNo { get; set; }

       /**
      *Location
      */
        [Required] public int LocationId { get; set; }
        public virtual Lookup Location { get; set; }

         /**
         * Taxcode
         */
        public string Taxcode { get; set; }

        /**
         *Category
         */
        public int? CategoryId { get; set; }
        public virtual Lookup Category { get; set; }

        /**
         * Website
         */
        public string Website { get; set; }

        /**
         * Email
         */
        [EmailAddress]
        public string Email { get; set; }

        public string UpdateName { get; set; }

        public DateTimeOffset? UpdateAt { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public int? CreatorId { get; set; }
        public virtual User Creator { get; set; }

        #region Map to Hbl Lcl

        public ICollection<HblLclExp> Consignees { get; set; }
        public ICollection<HblLclExp> Shippers { get; set; }
        public ICollection<HblLclExp> NotifyParties { get; set; }
        public ICollection<HblLclExp> DeliveryOfGoods { get; set; }

        #endregion

        #region Map to Hbl Fcl

        public ICollection<HblFclExp> FclConsignees { get; set; }
        public ICollection<HblFclExp> FclShippers { get; set; }
        public ICollection<HblFclExp> FclNotifyParties { get; set; }
        public ICollection<HblFclExp> FclDeliveryOfGoods { get; set; }

        #endregion
    }
}
