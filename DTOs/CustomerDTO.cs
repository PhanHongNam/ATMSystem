/*
 * 
 * ATM System Project
 * Authors: 
 *  + Phan Hong Nam(Demons)
 *  + Ngo Van Son
 *  + Nguyen Huyen Trang
 *  + Vu Van Dung
 * Univestity: Ha Noi Univesity Of Industry
 * Customer Database Object
 *
*/

namespace DTOs
{
    public class CustomerDTO
    {
        private string _custId;
        private string _name;
        private string _email;
        private string _phone;
        private string _addr;

        public CustomerDTO() { }

        public CustomerDTO(string custId, string name, 
                            string email, string phone, string addr)
        {
            CustId = custId;
            Name = name;
            Email = email;
            Phone = phone;
            Addr = addr;
        }

        public string CustId { get => _custId; set => _custId = value; }
        public string Name { get => _name; set => _name = value; }
        public string Email { get => _email; set => _email = value; }
        public string Phone { get => _phone; set => _phone = value; }
        public string Addr { get => _addr; set => _addr = value; }
    }
}
