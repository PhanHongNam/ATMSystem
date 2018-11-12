/*
 * 
 * ATM System Project
 * Authors: 
 *  + Phan Hong Nam(Demons)
 *  + Ngo Van Son
 *  + Nguyen Huyen Trang
 *  + Vu Van Dung
 * Univestity: Ha Noi Univesity Of Industry
 * Widthdraw Limit Database Object
 *
*/

namespace DTOs
{
    class WithdrawLimitDTO
    {
        private string _wDId;
        private int _value;

        public WithdrawLimitDTO() { }

        public string WDId { get => _wDId; set => _wDId = value; }
        public int Value { get => _value; set => _value = value; }
    }
}
