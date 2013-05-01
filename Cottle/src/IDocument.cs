﻿using System.IO;

using Cottle.Settings;

namespace	Cottle
{
	public interface	IDocument
	{
		#region Methods

		Value	Render (IScope scope, TextWriter writer);

		string	Render (IScope scope);

		void	Source (TextWriter writer);

		string	Source ();

		#endregion
	}
}