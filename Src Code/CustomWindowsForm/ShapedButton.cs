using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CustomWindowsForm
{
	// Token: 0x0200000D RID: 13
	public class ShapedButton : Button
	{
		// Token: 0x17000019 RID: 25
		// (get) Token: 0x060000BA RID: 186 RVA: 0x00009174 File Offset: 0x00007374
		// (set) Token: 0x060000BB RID: 187 RVA: 0x0000918C File Offset: 0x0000738C
		public ShapedButton.ButtonsShapes ButtonShape
		{
			get
			{
				return this.buttonShape;
			}
			set
			{
				this.buttonShape = value;
				base.Invalidate();
			}
		}

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x060000BC RID: 188 RVA: 0x000091A0 File Offset: 0x000073A0
		// (set) Token: 0x060000BD RID: 189 RVA: 0x000091B8 File Offset: 0x000073B8
		public string ButtonText
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

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x060000BE RID: 190 RVA: 0x000091CC File Offset: 0x000073CC
		// (set) Token: 0x060000BF RID: 191 RVA: 0x000091E4 File Offset: 0x000073E4
		public int BorderWidth
		{
			get
			{
				return this.borderWidth;
			}
			set
			{
				this.borderWidth = value;
				base.Invalidate();
			}
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x000091F8 File Offset: 0x000073F8
		private void SetBorderColor(Color bdrColor)
		{
			int num = (int)(bdrColor.R - 40);
			int num2 = (int)(bdrColor.G - 40);
			int num3 = (int)(bdrColor.B - 40);
			if (num < 0)
			{
				num = 0;
			}
			if (num2 < 0)
			{
				num2 = 0;
			}
			if (num3 < 0)
			{
				num3 = 0;
			}
			this.buttonborder = Color.FromArgb(num, num2, num3);
		}

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x060000C1 RID: 193 RVA: 0x0000925C File Offset: 0x0000745C
		// (set) Token: 0x060000C2 RID: 194 RVA: 0x00009274 File Offset: 0x00007474
		public Color BorderColor
		{
			get
			{
				return this.borderColor;
			}
			set
			{
				this.borderColor = value;
				if (this.borderColor == Color.Transparent)
				{
					this.buttonborder = Color.FromArgb(220, 220, 220);
				}
				else
				{
					this.SetBorderColor(this.borderColor);
				}
			}
		}

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x060000C3 RID: 195 RVA: 0x000092D0 File Offset: 0x000074D0
		// (set) Token: 0x060000C4 RID: 196 RVA: 0x000092E8 File Offset: 0x000074E8
		public Color StartColor
		{
			get
			{
				return this.color1;
			}
			set
			{
				this.color1 = value;
				base.Invalidate();
			}
		}

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x060000C5 RID: 197 RVA: 0x000092FC File Offset: 0x000074FC
		// (set) Token: 0x060000C6 RID: 198 RVA: 0x00009314 File Offset: 0x00007514
		public Color EndColor
		{
			get
			{
				return this.color2;
			}
			set
			{
				this.color2 = value;
				base.Invalidate();
			}
		}

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x060000C7 RID: 199 RVA: 0x00009328 File Offset: 0x00007528
		// (set) Token: 0x060000C8 RID: 200 RVA: 0x00009340 File Offset: 0x00007540
		public Color MouseHoverColor1
		{
			get
			{
				return this.m_hovercolor1;
			}
			set
			{
				this.m_hovercolor1 = value;
				base.Invalidate();
			}
		}

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x060000C9 RID: 201 RVA: 0x00009354 File Offset: 0x00007554
		// (set) Token: 0x060000CA RID: 202 RVA: 0x0000936C File Offset: 0x0000756C
		public Color MouseHoverColor2
		{
			get
			{
				return this.m_hovercolor2;
			}
			set
			{
				this.m_hovercolor2 = value;
				base.Invalidate();
			}
		}

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x060000CB RID: 203 RVA: 0x00009380 File Offset: 0x00007580
		// (set) Token: 0x060000CC RID: 204 RVA: 0x00009398 File Offset: 0x00007598
		public Color MouseClickColor1
		{
			get
			{
				return this.clickcolor1;
			}
			set
			{
				this.clickcolor1 = value;
				base.Invalidate();
			}
		}

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x060000CD RID: 205 RVA: 0x000093AC File Offset: 0x000075AC
		// (set) Token: 0x060000CE RID: 206 RVA: 0x000093C4 File Offset: 0x000075C4
		public Color MouseClickColor2
		{
			get
			{
				return this.clickcolor2;
			}
			set
			{
				this.clickcolor2 = value;
				base.Invalidate();
			}
		}

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x060000CF RID: 207 RVA: 0x000093D8 File Offset: 0x000075D8
		// (set) Token: 0x060000D0 RID: 208 RVA: 0x000093F0 File Offset: 0x000075F0
		public int Transparent1
		{
			get
			{
				return this.color1Transparent;
			}
			set
			{
				this.color1Transparent = value;
				if (this.color1Transparent > 255)
				{
					this.color1Transparent = 255;
					base.Invalidate();
				}
				else
				{
					base.Invalidate();
				}
			}
		}

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x060000D1 RID: 209 RVA: 0x00009438 File Offset: 0x00007638
		// (set) Token: 0x060000D2 RID: 210 RVA: 0x00009450 File Offset: 0x00007650
		public int Transparent2
		{
			get
			{
				return this.color2Transparent;
			}
			set
			{
				this.color2Transparent = value;
				if (this.color2Transparent > 255)
				{
					this.color2Transparent = 255;
					base.Invalidate();
				}
				else
				{
					base.Invalidate();
				}
			}
		}

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x060000D3 RID: 211 RVA: 0x00009498 File Offset: 0x00007698
		// (set) Token: 0x060000D4 RID: 212 RVA: 0x000094B0 File Offset: 0x000076B0
		public int GradientAngle
		{
			get
			{
				return this.angle;
			}
			set
			{
				this.angle = value;
				base.Invalidate();
			}
		}

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x060000D5 RID: 213 RVA: 0x000094C4 File Offset: 0x000076C4
		// (set) Token: 0x060000D6 RID: 214 RVA: 0x000094DC File Offset: 0x000076DC
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

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x060000D7 RID: 215 RVA: 0x000094F0 File Offset: 0x000076F0
		// (set) Token: 0x060000D8 RID: 216 RVA: 0x00009508 File Offset: 0x00007708
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

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x060000D9 RID: 217 RVA: 0x0000951C File Offset: 0x0000771C
		// (set) Token: 0x060000DA RID: 218 RVA: 0x00009534 File Offset: 0x00007734
		public bool ShowButtontext
		{
			get
			{
				return this.showButtonText;
			}
			set
			{
				this.showButtonText = value;
				base.Invalidate();
			}
		}

		// Token: 0x060000DB RID: 219 RVA: 0x00009548 File Offset: 0x00007748
		public ShapedButton()
		{
			base.Size = new Size(100, 40);
			this.BackColor = Color.Transparent;
			base.FlatStyle = FlatStyle.Flat;
			base.FlatAppearance.BorderSize = 0;
			base.FlatAppearance.MouseOverBackColor = Color.Transparent;
			base.FlatAppearance.MouseDownBackColor = Color.Transparent;
			this.text = this.Text;
		}

		// Token: 0x060000DC RID: 220 RVA: 0x0000966B File Offset: 0x0000786B
		protected override void OnMouseEnter(EventArgs e)
		{
			base.OnMouseEnter(e);
			this.clr1 = this.color1;
			this.clr2 = this.color2;
			this.color1 = this.m_hovercolor1;
			this.color2 = this.m_hovercolor2;
		}

		// Token: 0x060000DD RID: 221 RVA: 0x000096A6 File Offset: 0x000078A6
		protected override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseLeave(e);
			this.color1 = this.clr1;
			this.color2 = this.clr2;
			this.SetBorderColor(this.borderColor);
		}

		// Token: 0x060000DE RID: 222 RVA: 0x000096D8 File Offset: 0x000078D8
		protected override void OnMouseDown(MouseEventArgs mevent)
		{
			base.OnMouseDown(mevent);
			this.color1 = this.clickcolor1;
			this.color2 = this.clickcolor2;
			this.buttonborder = this.borderColor;
			this.SetBorderColor(this.borderColor);
			base.Invalidate();
		}

		// Token: 0x060000DF RID: 223 RVA: 0x00009726 File Offset: 0x00007926
		protected override void OnMouseUp(MouseEventArgs mevent)
		{
			base.OnMouseUp(mevent);
			this.OnMouseLeave(mevent);
			this.color1 = this.clr1;
			this.color2 = this.clr2;
			this.SetBorderColor(this.borderColor);
			base.Invalidate();
		}

		// Token: 0x060000E0 RID: 224 RVA: 0x00009765 File Offset: 0x00007965
		protected override void OnLostFocus(EventArgs e)
		{
			base.OnLostFocus(e);
			this.color1 = this.clr1;
			this.color2 = this.clr2;
			base.Invalidate();
		}

		// Token: 0x060000E1 RID: 225 RVA: 0x0000978F File Offset: 0x0000798F
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			this.textX = base.Width / 3 - 1;
			this.textY = base.Height / 3 + 5;
		}

		// Token: 0x060000E2 RID: 226 RVA: 0x000097BC File Offset: 0x000079BC
		private void DrawCircularButton(Graphics g)
		{
			Color color = Color.FromArgb(this.color1Transparent, this.color1);
			Color color2 = Color.FromArgb(this.color2Transparent, this.color2);
			Brush brush = new LinearGradientBrush(base.ClientRectangle, color, color2, (float)this.angle);
			g.FillEllipse(brush, 5, 5, base.Width - 10, base.Height - 10);
			for (int i = 0; i < this.borderWidth; i++)
			{
				g.DrawEllipse(new Pen(new SolidBrush(this.buttonborder)), 5 + i, 5, base.Width - 10, base.Height - 10);
			}
			if (this.showButtonText)
			{
				Point p = new Point(this.textX, this.textY);
				SolidBrush brush2 = new SolidBrush(this.ForeColor);
				g.DrawString(this.text, this.Font, brush2, p);
			}
			brush.Dispose();
		}

		// Token: 0x060000E3 RID: 227 RVA: 0x000098BC File Offset: 0x00007ABC
		private void DrawRoundRectangularButton(Graphics g)
		{
			Color color = Color.FromArgb(this.color1Transparent, this.color1);
			Color color2 = Color.FromArgb(this.color2Transparent, this.color2);
			Brush brush = new LinearGradientBrush(base.ClientRectangle, color, color2, (float)this.angle);
			Region region = new Region(new Rectangle(5, 5, base.Width, base.Height));
			GraphicsPath graphicsPath = new GraphicsPath();
			graphicsPath.AddArc(5, 5, 40, 40, 180f, 90f);
			graphicsPath.AddLine(25, 5, base.Width - 25, 5);
			graphicsPath.AddArc(base.Width - 45, 5, 40, 40, 270f, 90f);
			graphicsPath.AddLine(base.Width - 5, 25, base.Width - 5, base.Height - 25);
			graphicsPath.AddArc(base.Width - 45, base.Height - 45, 40, 40, 0f, 90f);
			graphicsPath.AddLine(25, base.Height - 5, base.Width - 25, base.Height - 5);
			graphicsPath.AddArc(5, base.Height - 45, 40, 40, 90f, 90f);
			graphicsPath.AddLine(5, 25, 5, base.Height - 25);
			region.Intersect(graphicsPath);
			g.FillRegion(brush, region);
			for (int i = 0; i < this.borderWidth; i++)
			{
				g.DrawArc(new Pen(this.buttonborder), 5 + i, 5 + i, 40, 40, 180, 90);
				g.DrawLine(new Pen(this.buttonborder), 25, 5 + i, base.Width - 25, 5 + i);
				g.DrawArc(new Pen(this.buttonborder), base.Width - 45 - i, 5 + i, 40, 40, 270, 90);
				g.DrawLine(new Pen(this.buttonborder), 5 + i, 25, 5 + i, base.Height - 25);
				g.DrawLine(new Pen(this.buttonborder), base.Width - 5 - i, 25, base.Width - 5 - i, base.Height - 25);
				g.DrawArc(new Pen(this.buttonborder), base.Width - 45 - i, base.Height - 45 - i, 40, 40, 0, 90);
				g.DrawLine(new Pen(this.buttonborder), 25, base.Height - 5 - i, base.Width - 25, base.Height - 5 - i);
				g.DrawArc(new Pen(this.buttonborder), 5 + i, base.Height - 45 - i, 40, 40, 90, 90);
			}
			if (this.showButtonText)
			{
				Point p = new Point(this.textX, this.textY);
				SolidBrush brush2 = new SolidBrush(this.ForeColor);
				g.DrawString(this.text, this.Font, brush2, p);
			}
			brush.Dispose();
		}

		// Token: 0x060000E4 RID: 228 RVA: 0x00009BFC File Offset: 0x00007DFC
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			switch (this.buttonShape)
			{
			case ShapedButton.ButtonsShapes.RoundRect:
				this.DrawRoundRectangularButton(e.Graphics);
				break;
			case ShapedButton.ButtonsShapes.Circle:
				this.DrawCircularButton(e.Graphics);
				break;
			}
		}

		// Token: 0x04000075 RID: 117
		private Color clr1;

		// Token: 0x04000076 RID: 118
		private Color clr2;

		// Token: 0x04000077 RID: 119
		private Color color1 = Color.DodgerBlue;

		// Token: 0x04000078 RID: 120
		private Color color2 = Color.MidnightBlue;

		// Token: 0x04000079 RID: 121
		private Color m_hovercolor1 = Color.Turquoise;

		// Token: 0x0400007A RID: 122
		private Color m_hovercolor2 = Color.DarkSlateGray;

		// Token: 0x0400007B RID: 123
		private int color1Transparent = 250;

		// Token: 0x0400007C RID: 124
		private int color2Transparent = 250;

		// Token: 0x0400007D RID: 125
		private Color clickcolor1 = Color.Yellow;

		// Token: 0x0400007E RID: 126
		private Color clickcolor2 = Color.Red;

		// Token: 0x0400007F RID: 127
		private int angle = 90;

		// Token: 0x04000080 RID: 128
		private int textX = 100;

		// Token: 0x04000081 RID: 129
		private int textY = 25;

		// Token: 0x04000082 RID: 130
		private string text = "";

		// Token: 0x04000083 RID: 131
		public Color buttonborder = Color.FromArgb(220, 220, 220);

		// Token: 0x04000084 RID: 132
		public bool showButtonText = true;

		// Token: 0x04000085 RID: 133
		public int borderWidth = 2;

		// Token: 0x04000086 RID: 134
		public Color borderColor = Color.Transparent;

		// Token: 0x04000087 RID: 135
		private ShapedButton.ButtonsShapes buttonShape;

		// Token: 0x0200000E RID: 14
		public enum ButtonsShapes
		{
			// Token: 0x04000089 RID: 137
			RoundRect,
			// Token: 0x0400008A RID: 138
			Circle
		}
	}
}
