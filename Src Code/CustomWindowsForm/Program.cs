using System;
using System.Windows.Forms;

namespace CustomWindowsForm
{
	// Token: 0x0200000B RID: 11
	internal static class Program
	{
		// Token: 0x060000B3 RID: 179 RVA: 0x00009088 File Offset: 0x00007288
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new BlackForm());
		}
	}
}
