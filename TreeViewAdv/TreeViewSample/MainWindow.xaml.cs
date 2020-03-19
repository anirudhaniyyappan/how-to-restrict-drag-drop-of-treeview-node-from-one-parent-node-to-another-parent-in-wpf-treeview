using Syncfusion.Windows.Tools.Controls;
using System.Windows;

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
            tree.DragStart += new Syncfusion.Windows.Tools.Controls.DragTreeViewItemAdvHandler(tree_DragStart);
            tree.DragEnd += new DragTreeViewItemAdvHandler(tree_DragEnd);
        }
        void tree_DragEnd(object sender, DragTreeViewItemAdvEventArgs e)
        {
            e.Cancel = false;
            TreeViewItemAdv drop = e.TargetDropItem as TreeViewItemAdv;
            if (drag != null && drop != null && drag.ParentItemsControl == drop.ParentItemsControl)
            {
                e.Cancel = true;
            }
            if (!e.Cancel)
            {
                string items = string.Empty;
                foreach (var item in e.DraggingItems)
                {
                    items += (item.Header as Model).Header.ToString() + "\n";
                }
            }
        }
        void tree_DragStart(object sender, Syncfusion.Windows.Tools.Controls.DragTreeViewItemAdvEventArgs e)
        {
            drag = (sender as TreeViewAdv).SelectedContainer;
        }
    }
}
