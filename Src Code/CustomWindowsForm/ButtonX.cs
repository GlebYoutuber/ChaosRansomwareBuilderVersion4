using System;
using System.Drawing;
using System.Windows.Forms;

namespace CustomWindowsForm
{
	// Token: 0x02000004 RID: 4
	public class ButtonX : Button
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000064 RID: 100 RVA: 0x0000735C File Offset: 0x0000555C
		// (set) Token: 0x06000065 RID: 101 RVA: 0x00007374 File Offset: 0x00005574
		public string DisplayText
		{
			get
			{
				return this.text;
			}
			set
			{
				this.text = value;
				base.Invalidate();
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000066 RID: 102 RVA: 0x00007388 File Offset: 0x00005588
		// (set) Token: 0x06000067 RID: 103 RVA: 0x000073A0 File Offset: 0x000055A0
		public Color BZBackColor
		{
			get
			{
				return this.color;
			}
			set
			{
				this.color = value;
				base.Invalidate();
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000068 RID: 104 RVA: 0x000073B4 File Offset: 0x000055B4
		// (set) Token: 0x06000069 RID: 105 RVA: 0x000073CC File Offset: 0x000055CC
		public Color MouseHoverColor
		{
			get
			{
				return this.m_hovercolor;
			}
			set
			{
				this.m_hovercolor = value;
				base.Invalidate();
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x0600006A RID: 106 RVA: 0x000073E0 File Offset: 0x000055E0
		// (set) Token: 0x0600006B RID: 107 RVA: 0x000073F8 File Offset: 0x000055F8
		public Color MouseClickColor1
		{
			get
			{
				return this.clickcolor;
			}
			set
			{
				this.clickcolor = value;
				base.Invalidate();
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600006C RID: 108 RVA: 0x0000740C File Offset: 0x0000560C
		// (set) Token: 0x0600006D RID: 109 RVA: 0x00007424 File Offset: 0x00005624
		public bool ChangeColorMouseHC
		{
			get
			{
				return this.isChanged;
			}
			set
			{
				this.isChanged = value;
				base.Invalidate();
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600006E RID: 110 RVA: 0x00007438 File Offset: 0x00005638
		// (set) Token: 0x0600006F RID: 111 RVA: 0x00007450 File Offset: 0x00005650
		public int TextLocation_X
		{
			get
			{
				return this.textX;
			}
			set
			{
				this.textX = value;
				base.Invalidate();
			}
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000070 RID: 112 RVA: 0x00007464 File Offset: 0x00005664
		// (set) Token: 0x06000071 RID: 113 RVA: 0x0000747C File Offset: 0x0000567C
		public int TextLocation_Y
		{
			get
			{
				return this.textY;
			}
			set
			{
				this.textY = value;
				base.Invalidate();
			}
		}

		// Token: 0x06000072 RID: 114 RVA: 0x00007490 File Offset: 0x00005690
		public ButtonX()
		{
			base.Size = new Size(31, 24);
			this.ForeColor = Color.White;
			base.FlatStyle = FlatStyle.Flat;
			this.Font = new Font("Microsoft YaHei UI", 20.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.Text = "_";
			this.text = this.Text;
		}

		// Token: 0x06000073 RID: 115 RVA: 0x00007553 File Offset: 0x00005753
		protected override void OnMouseEnter(EventArgs e)
		{
			base.OnMouseEnter(e);
			this.clr1 = this.color;
			this.color = this.m_hovercolor;
		}

		// Token: 0x06000074 RID: 116 RVA: 0x00007578 File Offset: 0x00005778
		protected override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseLeave(e);
			if (this.isChanged)
			{
				this.color = this.clr1;
			}
		}

		// Token: 0x06000075 RID: 117 RVA: 0x000075AC File Offset: 0x000057AC
		protected override void OnMouseDown(MouseEventArgs mevent)
		{
			base.OnMouseDown(mevent);
			if (this.isChanged)
			{
				this.color = this.clickcolor;
			}
		}

		// Token: 0x06000076 RID: 118 RVA: 0x000075E0 File Offset: 0x000057E0
		protected override void OnMouseUp(MouseEventArgs mevent)
		{
			base.OnMouseUp(mevent);
			if (this.isChanged)
			{
				this.color = this.clr1;
			}
		}

		// Token: 0x06000077 RID: 119 RVA: 0x00007614 File Offset: 0x00005814
		protected override void OnPaint(PaintEventArgs pe)
		{
			base.OnPaint(pe);
			this.text = this.Text;
			if (this.textX == 100 && this.textY == 25)
			{
				this.textX = base.Width / 3 + 10;
				this.textY = base.Height / 2 - 1;
			}
			Point p = new Point(this.textX, this.textY);
			pe.Graphics.FillRectangle(new SolidBrush(this.color), base.ClientRectangle);
			pe.Graphics.DrawString(this.text, this.Font, new SolidBrush(this.ForeColor), p);
		}

		// Token: 0x04000045 RID: 69
		private Color clr1;

		// Token: 0x04000046 RID: 70
		private Color color = Color.Teal;

		// Token: 0x04000047 RID: 71
		private Color m_hovercolor = Color.FromArgb(0, 0, 140);

		// Token: 0x04000048 RID: 72
		private Color clickcolor = Color.FromArgb(160, 180, 200);

		// Token: 0x04000049 RID: 73
		private int textX = 6;

		// Token: 0x0400004A RID: 74
		private int textY = -20;

		// Token: 0x0400004B RID: 75
		private string text = "_";

		// Token: 0x0400004C RID: 76
		private bool isChanged = true;
	}
}
