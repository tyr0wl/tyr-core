using System;
using System.Collections.Generic;

namespace tyr.Core.Events
{
    public class Subscriptions : Dictionary<Type, List<Delegate>>
    {
    }
}