using System;
using System.Collections.Generic;

namespace Vino.Shared.Entities.Producing
{
    public class MaterialInOut
    {
        public DateTimeOffset UpdatedAt { get; set; }
        public string Code { get; set; }
        /// <summary>
        /// EmployeeId
        /// </summary>
        public int UpdatedById { get; set; }

	    public string BillType { get; set; }
	    public string WarehouseName { get; set; }
	    public string BillStatus { get; set; }
        public string Note { get; set; }
        public List<MaterialInOutItem> Items { get; set; }
    }
}