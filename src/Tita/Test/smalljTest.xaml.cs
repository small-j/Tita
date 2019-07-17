﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// smalljTest.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class smalljTest : Window
    {
        public smalljTest()
        {
            InitializeComponent();
        }

        private Point startPoint;

        private void Small_Loaded(object sender, RoutedEventArgs e)
        {
            
            DataFile file = new DataFile("subjects.xml");
            ClassInfoList lst = file.LoadClassInfo();
            Console.WriteLine(lst.Groups);
            ClassGroup gone = new ClassGroup();
            ClassGroup gtwo = new ClassGroup();
            ClassGroup group = new ClassGroup();

            foreach(ClassInfo i in lst.Groups["컴퓨터정보공학부"])
            {
                gone.AddGroup(new ClassInfoPlus(i));
            }
            foreach (ClassInfo i in lst.Groups["자교"])
            {
                gtwo.AddGroup(new ClassInfoPlus(i));
            }

            group.AddGroup(gone);
            group.AddGroup(gtwo);

            ClassGroupBoxControl gbox = new ClassGroupBoxControl(group);
            main.Children.Add(gbox);
            


            ClassInfo info = new ClassInfo("객체지향패러다임", 0, new ClassTime(new ClassTimeItem(DayOfWeek.Monday, 1, 3)), "오재원", 3);
            DragSubject.Children.Add(new ClassInfoControl(info));
        }

        private void DragSubject_DragOver(object sender, DragEventArgs e)
        {
            if(e.Data.GetDataPresent(nameof(ClassInfo)))
            {
                e.Effects = DragDropEffects.Move;
            }
        }

        private void Data_Drop(object sender, DragEventArgs e)
        {
            if(e.Handled == false)
            {
                StackPanel panel = sender as StackPanel;
                ClassInfo curinfo = e.Data.GetData(nameof(ClassInfo)) as ClassInfo;
                ClassInfoPlus infoplus = new ClassInfoPlus(curinfo);
                if (panel != null && curinfo != null)
                {
                    
                    ClassInfoControl curcontrol = new ClassInfoControl(infoplus);
                    curcontrol.AllowDrop = false;
                    panel.Children.Add(curcontrol);
                    e.Effects = DragDropEffects.Move;
                }

            }
        }
    }
}
