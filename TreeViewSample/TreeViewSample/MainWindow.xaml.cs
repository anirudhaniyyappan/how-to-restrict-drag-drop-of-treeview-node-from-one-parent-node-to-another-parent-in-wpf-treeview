using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using Syncfusion.Windows.Tools.Controls;
using Syncfusion.Windows.Shared;

namespace TreeViewSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        TreeViewItemAdv drag = null;
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            tree.DataContext = new ViewModel();
            this.tree.DragStart += new Syncfusion.Windows.Tools.Controls.DragTreeViewItemAdvHandler(tree_DragStart);
               
            this.tree.DragEnd += new DragTreeViewItemAdvHandler(tree_DragEnd);
           
        }

        void tree_DragEnd(object sender, DragTreeViewItemAdvEventArgs e)
        {
            e.Cancel = false;

            TreeViewItemAdv drop = e.TargetDropItem as TreeViewItemAdv;
            if (drag != null && drop!=null && drag.ParentItemsControl == drop.ParentItemsControl)
            {
                e.Cancel = true;
            }

            if(!e.Cancel)
            {
                string items = string.Empty;
                foreach (var item in e.DraggingItems)
                {
                    items += (item.Header as Model).Header.ToString() + "\n";
                }
                if (System.Windows.MessageBox.Show("Need to drop the Following Items? \n" + items, "TreeView Drop Items", MessageBoxButton.YesNo) == MessageBoxResult.No)
                {
                    e.Cancel = true;
                }
                else
                    e.Cancel = false;
            }
        }

     

        void tree_DragStart(object sender, Syncfusion.Windows.Tools.Controls.DragTreeViewItemAdvEventArgs e)
        {

            drag = (sender as TreeViewAdv).SelectedContainer;
           
        }
    }

    public class ViewModel
    {

        public ViewModel()
        {
            TreeItems = new ObservableCollection<Model>();

            PopulateData();
          

        }

        public ObservableCollection<Model> TreeItems { get; set; }

       
        private void PopulateData()
        {
            
                Model root = new Model() { Header = "Visual Basic" };

                PopulateSubItems(root);

                TreeItems.Add(root);
                Model root1 = new Model() { Header = "Visual C#" };

                PopulateSubItems(root1);

                TreeItems.Add(root1);
                Model root2 = new Model() { Header = "Visual C++" };

                PopulateSubItems(root2);

                TreeItems.Add(root2);
        }



        private void PopulateSubItems(Model Root)
        {
            
                Model SubItem = new Model() { Header = "StoreApps" };
                PopulateStoreAppsItems(SubItem);
                Root.SubItems.Add(SubItem);

                Model SubItem1 = new Model() { Header = "Web" };
                PopulateWebItems(SubItem1);
                Root.SubItems.Add(SubItem1);

                Model SubItem2 = new Model() { Header = "Office/SharePoint" };
                PopulateOfficeItems(SubItem2);
                Root.SubItems.Add(SubItem2);
        }

        private void PopulateOfficeItems(Model SubItem2)
        {
            Model InnerSubItem = new Model() { Header = "Apps" };
            SubItem2.SubItems.Add(InnerSubItem);
            Model InnerSubItem1 = new Model() { Header = "Office Add-ins" };
            SubItem2.SubItems.Add(InnerSubItem1);
            Model InnerSubItem2 = new Model() { Header = "SharePoint Solution" };
            SubItem2.SubItems.Add(InnerSubItem2);
        }

        private void PopulateWebItems(Model SubItem1)
        {
            Model InnerSubItem = new Model() { Header = "Visual Studio" };
            SubItem1.SubItems.Add(InnerSubItem);
            
        }

        private void PopulateStoreAppsItems(Model SubItem)
        {
            Model InnerSubItem = new Model() { Header = "Window Apps" };
            SubItem.SubItems.Add(InnerSubItem);
            Model InnerSubItem1 = new Model() { Header = "Window Phone Apps" };
            SubItem.SubItems.Add(InnerSubItem1);
        }


    }

    public class Model
    {
        public Model()
        {
            SubItems = new ObservableCollection<Model>();
        }
        public string Header { get; set; }

        public bool IsCheckable { get; set; }

        public ObservableCollection<Model> SubItems { get; set; }
    }

  
}
