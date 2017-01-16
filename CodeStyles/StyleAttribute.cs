using System;

namespace CodeStyles
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = false, AllowMultiple = true)]
	public sealed class StyleAttribute : Attribute { }
}
