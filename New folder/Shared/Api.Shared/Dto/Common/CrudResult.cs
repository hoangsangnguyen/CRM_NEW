using Vino.Shared.Constants.Common;

namespace Vino.Shared.Dto.Common
{
    public class CrudResult
    {
        public CrudResult()
        {
            ErrorDescription = "Error";
        }
        public bool IsOk { get; set; }
        /// <summary>
        /// Id cua entity sau khi thuc hien, neu co
        /// </summary>
        public int ReturnId { get; set; }
        /// <summary>
        /// Code cua entity sau khi thuc hien, neu co
        /// </summary>
        public string ReturnCode { get; set; }
        public CommonErrorStatus ErrorCode { get; set; }
        public string ErrorDescription { get; set; }

        public static CrudResult Ok(int returnId = 0, string returnCode = null)
        {
            return new CrudResult {IsOk = true, ReturnId = returnId, ReturnCode = returnCode};
        }
    }
}
