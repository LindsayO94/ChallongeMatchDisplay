﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Fizzi.Applications.ChallongeVisualization.View
{
	/// <summary>
	/// Interaction logic for apiWarning.xaml
	/// </summary>
	public partial class ApiWarning : Window
	{
		public ApiWarning()
		{
			InitializeComponent();
		}

		private void okClick(object sender, RoutedEventArgs e)
		{
			DialogResult = true;
		}
	}
}
