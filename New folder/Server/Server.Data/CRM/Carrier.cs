using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Falcon.Web.Core.Auth;
using Falcon.Web.Core.Data;

namespace Vino.Server.Data.CRM
{
    public class Carrier : BaseEntity
    {
        [Required]
        public string Code { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string FullEnglishName { get; set; }

        public string Contact { get; set; }

        public string Cell { get; set; }

        public int CountryId { get; set; }

        public string UpdateName { get; set; }

        public DateTimeOffset? UpdateAt { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public int CreatorId { get; set; }
        public virtual User Creator { get; set; }

        #region Air Exp
        public ICollection<AirExp> Carriers { get; set; }
        public ICollection<AirExp> Agents { get; set; }

        #endregion

        #region Fcl Exp
        public ICollection<FclExp> FclExpSlines{ get; set; }
        public ICollection<FclExp> FclExpAgents { get; set; }
        #endregion

        #region Map to LclExp
        public ICollection<LclExp> LclExpCoLoaders { get; set; }
        public ICollection<LclExp> LclExpAgents { get; set; }

        #endregion

        #region Fcl Exp
        public ICollection<AirImp> AirImpAirlines { get; set; }
        public ICollection<AirImp> AirImpAgents { get; set; }
        #endregion

        #region Fcl Imp
        public ICollection<FclImp> FclImpSlines { get; set; }
        public ICollection<FclImp> FclImpAgents { get; set; }
        #endregion

        #region Lcl Imp
        public ICollection<LclImp> LclImpSlines { get; set; }
        public ICollection<LclImp> LclImpAgents { get; set; }
        #endregion
    }
}
