﻿using Certes.Acme.Resource;
using System;
using Xunit;

namespace Certes.Tests.Acme.Resource
{
    public class OrderListTests
    {
        [Fact]
        public void CanGetSetProperties()
        {
            var entity = new OrderList();
            entity.VerifyGetterSetter(a => a.Orders, new[] { new Uri("http://certes.is.working") });
        }
    }
}
