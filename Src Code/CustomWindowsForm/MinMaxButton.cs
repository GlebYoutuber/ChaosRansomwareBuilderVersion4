using System;
using System.Drawing;
using System.Windows.Forms;

namespace CustomWindowsForm
{
	// Token: 0x02000009 RID: 9
	public class MinMaxButton : Button
	{
		// Token: 0x1700000E RID: 14
		// (get) Token: 0x0600009F RID: 159 RVA: 0x00008CAC File Offset: 0x00006EAC
		// (set) Token: 0x060000A0 RID: 160 RVA: 0x00008CC4 File Offset: 0x00006EC4
		public MinMaxButton.CustomFormState CFormState
		{
			get
			{
				return this._customFormState;
			}
			set
			{
				this._customFormState = value;
				base.Invalidate();
			}
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x060000A1 RID: 161 RVA: 0x00008CD8 File Offset: 0x00006ED8
		// (set) Token: 0x060000A2 RID: 162 RVA: 0x00008CF0 File Offset: 0x00006EF0
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

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x060000A3 RID: 163 RVA: 0x00008D04 File Offset: 0x00006F04
		// (set) Token: 0x060000A4 RID: 164 RVA: 0x00008D1C File Offset: 0x00006F1C
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

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x060000A5 RID: 165 RVA: 0x00008D30 File Offset: 0x00006F30
		// (set) Token: 0x060000A6 RID: 166 RVA: 0x00008D48 File Offset: 0x00006F48
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

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x060000A7 RID: 167 RVA: 0x00008D5C File Offset: 0x00006F5C
		// (set) Token: 0x060000A8 RID: 168 RVA: 0x00008D74 File Offset: 0x00006F74
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

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x060000A9 RID: 169 RVA: 0x00008D88 File Offset: 0x00006F88
		// (set) Token: 0x060000AA RID: 170 RVA: 0x00008DA0 File Offset: 0x00006FA0
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

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x060000AB RID: 171 RVA: 0x00008DB4 File Offset: 0x00006FB4
		// (set) Token: 0x060000AC RID: 172 RVA: 0x00008DCC File Offset: 0x00006FCC
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

		// Token: 0x060000AD RID: 173 RVA: 0x00008DE0 File Offset: 0x00006FE0
		public MinMaxButton()
		{
			base.Size = new Size(31, 24);
			this.ForeColor = Color.White;
			base.FlatStyle = FlatStyle.Flat;
			this.Text = "_";
			this.text = this.Text;
		}

		// Token: 0x060000AE RID: 174 RVA: 0x00008E8B File Offset: 0x0000708B
		protected override void OnMouseEnter(EventArgs e)
		{
			base.OnMouseEnter(e);
			this.clr1 = this.color;
			this.color = this.m_hovercolor;
		}

		// Token: 0x060000AF RID: 175 RVA: 0x00008EAE File Offset: 0x000070AE
		protected override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseLeave(e);
			this.color = this.clr1;
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x00008EC5 File Offset: 0x000070C5
		protected override void OnMouseDown(MouseEventArgs mevent)
		{
			base.OnMouseDown(mevent);
			this.color = this.clickcolor;
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x00008EDC File Offset: 0x000070DC
		protected override void OnMouseUp(MouseEventArgs mevent)
		{
			base.OnMouseUp(mevent);
			this.color = this.clr1;
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x00008EF4 File Offset: 0x000070F4
		protected override void OnPaint(PaintEventArgs pe)
		{
			base.OnPaint(pe);
			switch (this._customFormState)
			{
			case MinMaxButton.CustomFormState.Normal:
				pe.Graphics.FillRectangle(new SolidBrush(this.color), base.ClientRectangle);
				for (int i = 0; i < 2; i++)
				{
					pe.Graphics.DrawRectangle(new Pen(this.ForeColor), this.textX + i + 1, this.textY, 10, 10);
					pe.Graphics.FillRectangle(new SolidBrush(this.ForeColor), this.textX + 1, this.textY - 1, 12, 4);
				}
				break;
			case MinMaxButton.CustomFormState.Maximize:
				pe.Graphics.FillRectangle(new SolidBrush(this.color), base.ClientRectangle);
				for (int i = 0; i < 2; i++)
				{
					pe.Graphics.DrawRectangle(new Pen(this.ForeColor), this.textX + 5, this.textY, 8, 8);
					pe.Graphics.FillRectangle(new SolidBrush(this.ForeColor), this.textX + 5, this.textY - 1, 9, 4);
					pe.Graphics.DrawRectangle(new Pen(this.ForeColor), this.textX + 2, this.textY + 5, 8, 8);
					pe.Graphics.FillRectangle(new SolidBrush(this.ForeColor), this.textX + 2, this.textY + 4, 9, 4);
				}
				break;
			}
		}

		// Token: 0x04000068 RID: 104
		private Color clr1;

		// Token: 0x04000069 RID: 105
		private Color color = Color.Gray;

		// Token: 0x0400006A RID: 106
		private Color m_hovercolor = Color.FromArgb(180, 200, 240);

		// Token: 0x0400006B RID: 107
		private Color clickcolor = Color.FromArgb(160, 180, 200);

		// Token: 0x0400006C RID: 108
		private int textX = 6;

		// Token: 0x0400006D RID: 109
		private int textY = -20;

		// Token: 0x0400006E RID: 110
		private string text = "_";

		// Token: 0x0400006F RID: 111
		private MinMaxButton.CustomFormState _customFormState;

		// Token: 0x0200000A RID: 10
		public enum CustomFormState
		{
			// Token: 0x04000071 RID: 113
			Normal,
			// Token: 0x04000072 RID: 114
			Maximize
		}
	}
}
