using System;

namespace CodeStyles
{
	public class CodeStyleException : Exception
	{
		public String Class { get; private set; }
		public String Method { get; private set; }
		public String Error { get; private set; }
		public CodeStyleException(String className, String method, String error)
		{
			this.Class = className;
			this.Method = method;
			this.Error = error;
		}

		public override string Message
		{
			get
			{
				return "The method " + Method + " in the class " + Class + " has the following problem :" + Error;
			}
		}
	}
}
