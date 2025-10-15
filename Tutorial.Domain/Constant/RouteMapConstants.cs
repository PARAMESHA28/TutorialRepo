﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorial.Domain.Constant
{
    public static class RouteMapConstants
    {
        public const string BaseRoute = "api/v1";
        public const string BaseControllerRoute = BaseRoute + "/[controller]";
    }
}
