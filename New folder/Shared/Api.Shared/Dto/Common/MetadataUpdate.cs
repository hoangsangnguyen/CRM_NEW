using System;
using Vino.Shared.Constants;

namespace Vino.Shared.Dto.Common
{
    public class MetadataUpdate
    {
        /// <summary>
        /// <see cref="DataTypes"/>
        /// Truoc mat:
        /// 1. Danh sach chi so do 
        /// 2. Danh sach ao nuoi, dia diem
        /// 
        /// Sau nay:
        /// 2. Lookups (lua chon trong combobox)
        /// 3. Ngon ngu 
        /// 3. Version moi
        /// </summary>
        public string DataType { get; set; }
        public DateTimeOffset Latest { get; set; }
    }
}