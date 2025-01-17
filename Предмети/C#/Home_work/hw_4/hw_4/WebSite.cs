using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw_4
{
    public class WebSite(string name, string url,
        string ip, string description)
    {
        private string _name = name;
        private string _url = url;
        private string _ip = ip;
        private string _description = description;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Url
        {
            get { return _url; }
        }
        public string Ip
        {
            get { return _ip; }
        }
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        public override string ToString()
        {
            return $"Name: {_name} | Link: {_url}\n" +
                $"|IP: {_ip}|\n" +
                $"Description: {_description}"; 
        }
    }
}
