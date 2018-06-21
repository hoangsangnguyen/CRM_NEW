namespace Vino.Shared.Entities.Producing
{
    public class MaterialInOutItem
    {
        public string MaterialName { get; set; }
        public string MaterialCode { get; set; }
        /// <summary>
        /// Ten cua don vi do luong
        /// </summary>
        public string Unit { get; set; }
        public double Amount { get; set; }
	    public string Note { get; set; }
    }
}