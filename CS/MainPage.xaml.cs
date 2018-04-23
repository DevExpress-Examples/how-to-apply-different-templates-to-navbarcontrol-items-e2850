using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using DevExpress.Xpf.NavBar;

namespace SilverlightApplication1 {
	public partial class MainPage: UserControl {
		public MainPage() {
			InitializeComponent();
			navbar.Groups[0].ItemTemplateSelector = new CustomItemTemplateSelector() { NavBar = navbar };
		}
	}

	public class CustomItemTemplateSelector: DataTemplateSelector {
		public NavBarControl NavBar { get; set; }
		public override DataTemplate SelectTemplate(object item, DependencyObject container) {
			NavBarObjectInfo info = item as NavBarObjectInfo;
			if (info == null)
				return base.SelectTemplate(item, container);
			NavBarItem navBarItem = info.Element as NavBarItem;
			if (navBarItem == null)
				return base.SelectTemplate(item, container);
			switch (navBarItem.Content.ToString()) {
				case "Item Red":
					return (DataTemplate)NavBar.Resources["RedContentTemplate"];
				case "Item Green":
					return (DataTemplate)NavBar.Resources["GreenContentTemplate"];
				case "Item Blue":
					return (DataTemplate)NavBar.Resources["BlueContentTemplate"];
				default:
					return null;
			}
		}
	}
}