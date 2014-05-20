﻿using System;
using System.IO;
using Cottle.Values;

namespace Cottle.Documents.Simple.Nodes
{
	class EchoNode : INode
	{
		#region Attributes

		private readonly IEvaluator	expression;

		#endregion

		#region Constructors

		public	EchoNode (IEvaluator expression)
		{
			this.expression = expression;
		}

		#endregion

		#region Methods

		public bool Render (IScope scope, TextWriter output, out Value result)
		{
			output.Write (this.expression.Evaluate (scope, output).AsString);

			result = VoidValue.Instance;

			return false;
		}

		public void Source (ISetting setting, TextWriter output)
		{
			string	source;

			source = this.expression.ToString ();

			output.Write (setting.BlockBegin);

			if (source.StartsWith ("echo", StringComparison.InvariantCulture))
				output.Write ("echo ");

			output.Write (source);
			output.Write (setting.BlockEnd);
		}

		#endregion
	}
}