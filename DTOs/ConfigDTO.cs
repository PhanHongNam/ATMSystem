/*
 * 
 * ATM System Project
 * Authors: 
 *  + Phan Hong Nam(Demons)
 *  + Ngo Van Son
 *  + Nguyen Huyen Trang
 *  + Vu Van Dung
 * Univestity: Ha Noi Univesity Of Industry
 * Config Database Object
 * 
*/

using System;

namespace DTOs
{
    public class ConfigDTO
    {
        private string _configId;
        private int _minWithdraw;
        private int _maxWithdraw;
        private DateTime _dateModified;
        private int _numPerPage;

        public ConfigDTO() { }

        public ConfigDTO(string configId, int minWithdraw, int maxWithdraw, DateTime dateModified, int numPerPage)
        {
            ConfigId = configId;
            MinWithdraw = minWithdraw;
            MaxWithdraw = maxWithdraw;
            DateModified = dateModified;
            NumPerPage = numPerPage;
        }

        public string ConfigId { get => _configId; set => _configId = value; }
        public int MinWithdraw { get => _minWithdraw; set => _minWithdraw = value; }
        public int MaxWithdraw { get => _maxWithdraw; set => _maxWithdraw = value; }
        public DateTime DateModified { get => _dateModified; set => _dateModified = value; }
        public int NumPerPage { get => _numPerPage; set => _numPerPage = value; }
    }
}
