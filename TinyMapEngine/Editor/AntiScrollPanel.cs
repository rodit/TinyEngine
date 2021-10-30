using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;

namespace TinyMapEngine.Editor
{
	public class AntiScrollPanel : Panel
	{
		protected override Point ScrollToControl(Control activeControl)
		{
			return DisplayRectangle.Location;
		}
	}
}
