﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evans.Demo.Core.Tests.TestObjects
{
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
	public class UniqueAttribute : Attribute
	{
	}
}