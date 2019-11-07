﻿using System;
using System.Collections.Generic;

namespace ConceirgeDiningDAL.Models
{
    public partial class LoginInfo
    {
        public string SessionId { get; set; }
        public string UserId { get; set; }
        public long LoyaltyPoints { get; set; }
        public string Bank { get; set; }
        public string Locale { get; set; }
        public DateTimeOffset Timestamp { get; set; }
    }
}
