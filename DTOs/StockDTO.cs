/*
 * 
 * ATM System Project
 * Authors: 
 *  + Phan Hong Nam(Demons)
 *  + Ngo Van Son
 *  + Nguyen Huyen Trang
 *  + Vu Van Dung
 * Univestity: Ha Noi Univesity Of Industry
 * Stock Database Object
 * 
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    class StockDTO
    {
        private string _stockId;
        private int _quantity;
        private string _moneyId;
        private string _aTMId;

        public StockDTO() { }

        public StockDTO(string stockId, int quantity, string moneyId, string aTMId)
        {
            StockId = stockId;
            Quantity = quantity;
            MoneyId = moneyId;
            ATMId = aTMId;
        }

        public string StockId { get => _stockId; set => _stockId = value; }
        public int Quantity { get => _quantity; set => _quantity = value; }
        public string MoneyId { get => _moneyId; set => _moneyId = value; }
        public string ATMId { get => _aTMId; set => _aTMId = value; }
    }
}
