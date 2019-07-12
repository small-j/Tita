﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Tita
{
    /// <summary>
    /// Scaffold.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Scaffold : Window
    {
        public Scaffold()
        {
            InitializeComponent();
            Sample.Info = TestData.GetClassInfos()[0];
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Sample.Info = TestData.GetClassInfos()[0];
            ClassGroup group = new ClassGroup();
            ClassInfoPlus info = new ClassInfoPlus(Sample.Info);
            group.AddGroup(info);

            
        }

        private void Sample_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void ClassInfoInputControl_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void TimeSelectControl_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
