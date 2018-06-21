using System;
using System.Collections.Generic;
using System.Text;

namespace Vino.Shared.Entities.Producing
{
    public class SessionInOut
    {
	    public int Id { get; set; }
		public string Code { get; set; }
		public string Name { get; set; }
		/// <summary>
		/// San xuat trong noi bo
		/// </summary>
		public bool IsInternal { get; set; }
		/// <summary>
		/// internal lot
		/// </summary>
	    public string LotCode { get; set; }
	    public string LotName { get; set; }
	    public string ZoneName { get; set; }
		public string FarmerCode { get; set; }
	    public string FarmerName { get; set; }
	    public string BreedCode { get; set; }
	    public string BreedName { get; set; }
	    public string ProductCode{ get; set; }
	    public string ProductName { get; set; }
		public DateTime? NgayKhuLan { get; set; }

	    public DateTime? NgayThuPhan { get; set; }

	    public DateTime? NgayNhapKho { get; set; }
		/// <summary>
		/// dien tich lo dat, tai thoi diem tao
		/// </summary>
		public double Square { get; set; }
		/// <summary>
		/// Ngay lap ke hoach
		/// </summary>
		public DateTime? PlannedAt { get; set; }

	    public string PlannedByName { get; set; }

		public DateTime StartAt { get; set; }
		/// <summary>
		/// ngay thu hoach du kien
		/// </summary>
		public DateTime EstimateEndAt { get; set; }
		/// <summary>
		/// san luong du kien
		/// </summary>
		public double EstimatedOutput { get; set; }
		/// <summary>
		/// san luong thuc te
		/// </summary>
		public double ActualOutput { get; set; }
	}
}
