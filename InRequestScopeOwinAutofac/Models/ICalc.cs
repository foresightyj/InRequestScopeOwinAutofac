﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InRequestScopeOwinAutofac.Models
{
    public interface ICalc
    {
        int Id { get; }

        int Add(int a, int b);
    }
}