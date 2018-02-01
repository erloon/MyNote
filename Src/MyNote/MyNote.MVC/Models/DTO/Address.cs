using System;
using System.Collections.Generic;

namespace MyNote.MVC.Models.DTO
{
    public class Address
    {
        public string Country { get; protected set; }
        public string City { get; protected set; }
        public string Street { get; protected set; }
        public string Number { get; protected set; }

        public Address()
        {
        }
    }
}