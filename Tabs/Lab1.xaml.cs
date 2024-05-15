using System;
using System.Collections.Generic;
using System.Collections;
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
    public partial class Lab1 : UserControl
    {
        public ICommand HideButtonCommand { get; set; }   
        public Lab1()
        {
            HideButtonCommand = new ActionCommand((obj) =>
                {
                    var button = obj as Button;

                    if(button == null)
                        return;

                    button.IsEnabled = false;
                });
            InitializeComponent();
            this.DataContext = this;
        }

        private void HideButton(object sender, RoutedEventArgs e)
        {
            HideButtonCommand.Execute(sender);
        }

        private void Grid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            var buttons = App.FindVisualChildren<Button>(this);

            foreach (var child in buttons)
            {
                child.IsEnabled = true;
            }
        }

       
    }
}
