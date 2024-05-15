using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Labs.Tabs
{
    /// <summary>
    /// Логика взаимодействия для Lab5.xaml
    /// </summary>
    public partial class Lab5 : UserControl
    {

        public ICommand AddCommand { get; set; }
        public ICommand ResizeCommand { get; set; }

        public Lab5()
        {
            AddCommand = new ActionCommand((obj) =>
            {
                var newTextBlock = new TextBox() 
                { 
                    Text = DateTime.Now.ToString() ,
                    IsEnabled = false ,
                };
                Container.Children.Add(newTextBlock);
            });
            ResizeCommand = new ActionCommand((obj) =>
            {

                var textBlocks = App.FindVisualChildren<TextBox>(Container);
                foreach (var item in textBlocks)
                {
                    item.Height = item.ActualHeight * 2;
                }
            });

            InitializeComponent();
            this.DataContext = this;
        }
    }
}
