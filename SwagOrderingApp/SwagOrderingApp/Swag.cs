 using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SwagOrderingApp
{
    public class Swag
    {
        

        private string _name;
        private string _gender;
        private string _size;
        private DatePicker _date;
        private string _color;
        private string _address;
        public Swag( string name, string gender, string size,DatePicker date, string color,string address)
        {
            _name = name;
            _gender = gender;
            _size = size;
            _date = date;
            _color = color;
            _address = address;
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }

        public string Size
        {
            get { return _size; }
            set { _size = value; }
        }

        public DatePicker Date
        {
            get { return _date; }
            set { _date = value; }
        }

        public string Color
        {
            get { return _color; }
            set { _color = value; }
        }

        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }
    }
}
