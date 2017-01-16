using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Xamarin.Forms;

namespace CodeStyles
{
	public static class ApplicationExtensions
	{
		static readonly Type styleAttrType = typeof(StyleAttribute);
		static readonly Type styleType = typeof(Style);

		public static void SetCodeStyles(this Application app)
		{
			app.SetCodeStylesOf(app.GetType().GetTypeInfo().Assembly);
		}

		public static void SetCodeStylesOf(this Application app, Assembly assembly)
		{
			List<Style> styles = new List<Style>();

			var styleMethods = assembly.DefinedTypes
				.Where(d => d.CustomAttributes.Any(a => a.AttributeType == styleAttrType))
				.SelectMany(d => d.DeclaredMethods.Where(m => m.CustomAttributes.Any(a => a.AttributeType == styleAttrType)));

			foreach (var method in styleMethods)
			{
				if (!method.IsStatic) throw new CodeStyleException(method.DeclaringType.FullName, method.Name, "is not static");
				object result = method.Invoke(null, null);
				if (method.ReturnType == styleType)
				{
					styles.Add(result as Style);
				}
				else 
				{
					var resultEnumerable = result as IEnumerable<Style>;
					if (resultEnumerable == null) throw new CodeStyleException(method.DeclaringType.FullName, method.Name, "does not return one or more styles, please ensure this method returns Style or IEnumerable<Style>");
					styles.AddRange(resultEnumerable);
				}
			}

			if (app.Resources == null) app.Resources = new ResourceDictionary();

			foreach (var style in styles)
			{
				app.Resources.Add(style);
			}
		}
	}
}
