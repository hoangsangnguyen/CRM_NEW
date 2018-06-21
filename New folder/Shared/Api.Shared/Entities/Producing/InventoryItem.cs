using System.Text;

namespace Vino.Shared.Entities.Producing
{
    /// <summary>
    /// Nhap xuan ton kho dang don gian, dung trong quan ly vat tu MSX
    /// </summary>
    public class InventoryItem
    {
        public string MaterialName { get; set; }
        public string MaterialCode { get; set; }
        /// <summary>
        /// Ten cua don vi do luong
        /// </summary>
        public string Unit { get; set; }
        public double Input { get; set; }
        public double Output { get; set; }
        /// <summary>
        /// So luong trong kho
        /// </summary>
        public double Inventory { get; set; }
    }
}
