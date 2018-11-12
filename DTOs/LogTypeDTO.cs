/*
 * 
 * ATM System Project
 * Authors: 
 *  + Phan Hong Nam(Demons)
 *  + Ngo Van Son
 *  + Nguyen Huyen Trang
 *  + Vu Van Dung
 * Univestity: Ha Noi Univesity Of Industry
 * Log Type Database Object
 * 
*/

namespace DTOs
{
    public class LogTypeDTO
    {
        private string _logTypeId;
        private string _description;

        public LogTypeDTO() { }

        public LogTypeDTO(string logTypeId, string description)
        {
            LogTypeId = logTypeId;
            Description = description;
        }

        public string LogTypeId { get => _logTypeId; set => _logTypeId = value; }
        public string Description { get => _description; set => _description = value; }
    }
}
