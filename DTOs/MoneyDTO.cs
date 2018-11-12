/*
 * 
 * ATM System Project
 * Authors: 
 *  + Phan Hong Nam(Demons)
 *  + Ngo Van Son
 *  + Nguyen Huyen Trang
 *  + Vu Van Dung
 * Univestity: Ha Noi Univesity Of Industry
 * Money Database Object
 *
*/

namespace DTOs
{
    public class MoneyDTO
    {
        private string _moneyId;
        private int _value;

        public MoneyDTO() { }

        public MoneyDTO(string moneyId, int value)
        {
            MoneyId = moneyId;
            Value = value;
        }

        public string MoneyId { get => _moneyId; set => _moneyId = value; }
        public int Value { get => _value; set => _value = value; }
    }
}
