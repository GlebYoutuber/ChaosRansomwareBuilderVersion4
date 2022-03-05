using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CustomWindowsForm;
using Ryuk.Net.Properties;

namespace Ryuk.Net
{
	// Token: 0x02000007 RID: 7
	public partial class extensions : Form
	{
		// Token: 0x0600008B RID: 139 RVA: 0x00007BCC File Offset: 0x00005DCC
		public extensions()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600008C RID: 140 RVA: 0x00007BE5 File Offset: 0x00005DE5
		private void _CloseButton_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x0600008D RID: 141 RVA: 0x00007BEF File Offset: 0x00005DEF
		private void button1_Click(object sender, EventArgs e)
		{
			Settings.Default.extensions = this.textBox1.Text;
			MessageBox.Show("Saved successfully");
		}

		// Token: 0x0600008E RID: 142 RVA: 0x00007C13 File Offset: 0x00005E13
		private void extensions_Load(object sender, EventArgs e)
		{
			this.textBox1.Text = Settings.Default.extensions;
		}

		// Token: 0x0600008F RID: 143 RVA: 0x00007C2C File Offset: 0x00005E2C
		private void extensions_MouseDown(object sender, MouseEventArgs e)
		{
			this.mouseDown = true;
			this.lastLocation = e.Location;
		}

		// Token: 0x06000090 RID: 144 RVA: 0x00007C42 File Offset: 0x00005E42
		private void extensions_MouseUp(object sender, MouseEventArgs e)
		{
			this.mouseDown = false;
		}

		// Token: 0x06000091 RID: 145 RVA: 0x00007C4C File Offset: 0x00005E4C
		private void extensions_MouseMove(object sender, MouseEventArgs e)
		{
			if (this.mouseDown)
			{
				base.Location = new Point(base.Location.X - this.lastLocation.X + e.X, base.Location.Y - this.lastLocation.Y + e.Y);
				base.Update();
			}
		}

		// Token: 0x06000092 RID: 146 RVA: 0x00007CBE File Offset: 0x00005EBE
		private void panel1_MouseDown(object sender, MouseEventArgs e)
		{
			this.mouseDown = true;
			this.lastLocation = e.Location;
		}

		// Token: 0x06000093 RID: 147 RVA: 0x00007CD4 File Offset: 0x00005ED4
		private void panel1_MouseUp(object sender, MouseEventArgs e)
		{
			this.mouseDown = false;
		}

		// Token: 0x06000094 RID: 148 RVA: 0x00007CE0 File Offset: 0x00005EE0
		private void panel1_MouseMove(object sender, MouseEventArgs e)
		{
			if (this.mouseDown)
			{
				base.Location = new Point(base.Location.X - this.lastLocation.X + e.X, base.Location.Y - this.lastLocation.Y + e.Y);
				base.Update();
			}
		}

		// Token: 0x04000054 RID: 84
		private bool mouseDown;

		// Token: 0x04000055 RID: 85
		private Point lastLocation;
	}
}
