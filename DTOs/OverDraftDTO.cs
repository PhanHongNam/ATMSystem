/*
 * 
 * ATM System Project
 * Authors: 
 *  + Phan Hong Nam(Demons)
 *  + Ngo Van Son
 *  + Nguyen Huyen Trang
 *  + Vu Van Dung
 * Univestity: Ha Noi Univesity Of Industry
 * Over Draft Database Object
 *
*/

namespace DTOs
{
    class OverDraftDTO
    {
        private string _oDId;
        private int _value;

        public OverDraftDTO() { }

        public OverDraftDTO(string oDId, int value)
        {
            ODId = oDId;
            Value = value;
        }

        public string ODId { get => _oDId; set => _oDId = value; }
        public int Value { get => _value; set => _value = value; }
    }
}
