using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Falcon.Web.Core.Data;
using Vino.Server.Data.CRM;
using Vino.Shared.Constants;
using Vino.Shared.Constants.Common;


namespace Vino.Server.Data.Common
{
    public class Lookup : BaseEntity
    {
        public LookupTypes Type { get; set; }
        /// <summary>
        /// Dung lam khoa de so sanh member trong 1 type, thay cho Id
        /// </summary>
        [MaxLength(32)]
        [Required]
        public string Code { get; set; }
        public int Order { get; set; }
        [MaxLength(256)]
        public string Title { get; set; }
        [MaxLength(3)]
        public string App { get; set; }

        #region Map to Customer

        public ICollection<CrmCustomer> Locations { get; set; }
        public ICollection<CrmCustomer> Categories { get; set; }

        #endregion
    }
}