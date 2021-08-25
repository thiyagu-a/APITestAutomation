using System;
using System.Collections.Generic;
using System.Text;

namespace APIFramework.DTO
{

    public partial class UpdateBookingDTO
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public long Totalprice { get; set; }
        public bool Depositpaid { get; set; }
        public UpdatedBookingdates Bookingdates { get; set; }
        public string Additionalneeds { get; set; }
    }

    public partial class UpdatedBookingdates
    {
        public DateTimeOffset Checkin { get; set; }
        public DateTimeOffset Checkout { get; set; }
    }

}