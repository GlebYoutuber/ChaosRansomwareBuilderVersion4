using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CustomWindowsForm
{
	// Token: 0x02000008 RID: 8
	public partial class Form2 : Form
	{
		// Token: 0x06000097 RID: 151 RVA: 0x00008341 File Offset: 0x00006541
		public Form2()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000098 RID: 152 RVA: 0x0000835A File Offset: 0x0000655A
		private void buttonZ1_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x06000099 RID: 153 RVA: 0x00008364 File Offset: 0x00006564
		private void panel1_Paint(object sender, PaintEventArgs e)
		{
		}

		// Token: 0x0600009A RID: 154 RVA: 0x00008367 File Offset: 0x00006567
		private void panel1_MouseDown(object sender, MouseEventArgs e)
		{
			this.mouseDown = true;
			this.lastLocation = e.Location;
		}

		// Token: 0x0600009B RID: 155 RVA: 0x00008380 File Offset: 0x00006580
		private void panel1_MouseMove(object sender, MouseEventArgs e)
		{
			if (this.mouseDown)
			{
				base.Location = new Point(base.Location.X - this.lastLocation.X + e.X, base.Location.Y - this.lastLocation.Y + e.Y);
				base.Update();
			}
		}

		// Token: 0x0600009C RID: 156 RVA: 0x000083F2 File Offset: 0x000065F2
		private void panel1_MouseUp(object sender, MouseEventArgs e)
		{
			this.mouseDown = false;
		}

		// Token: 0x0400005C RID: 92
		private bool mouseDown;

		// Token: 0x0400005D RID: 93
		private Point lastLocation;
	}
}
