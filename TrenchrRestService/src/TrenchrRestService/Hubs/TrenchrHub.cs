﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace TrenchrRestService.Hubs
{
    [HubName("trenchrhub")]
    public class TrenchrHub : Hub
    { }
}