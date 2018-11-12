/*
 * 
 * ATM System Project
 * Authors: 
 *  + Phan Hong Nam(Demons)
 *  + Ngo Van Son
 *  + Nguyen Huyen Trang
 *  + Vu Van Dung
 * Univestity: Ha Noi Univesity Of Industry
 * ATM Database Object
 *
*/

namespace DTOs
{
    class ATMDTO
    {
        private string _aTMId;
        private string _brand;
        private string _address;

        public ATMDTO() { }

        public ATMDTO(string aTMId, string brand, string address)
        {
            ATMId = aTMId;
            Brand = brand;
            Address = address;
        }

        public string ATMId { get => _aTMId; set => _aTMId = value; }
        public string Brand { get => _brand; set => _brand = value; }
        public string Address { get => _address; set => _address = value; }
    }
}
