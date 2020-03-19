# how-to-restrict-drag-drop-of-treeview-node-from-one-parent-node-to-another-parent-in-wpf-treeview
This sample demonstrates how to restrict drag drop of treeview node from one parent node to another parent in WPF TreeView (TreeViewAdv).?

This article will Explain us how to restrict drag and drop of a parent node into another parent node, where it will allow only reordering the nodes in wpf TreeViewAdv.

The following code example demonstrates the same.

Model: 

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


ViewModel: 

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
         Model root = new Model() { Header = "Node1" };
         TreeItems.Add(root);
         Model root1 = new Model() { Header = "Node2" };
         TreeItems.Add(root1);
         Model root2 = new Model() { Header = "Node3" };
         TreeItems.Add(root2);
         Model root3 = new Model() { Header = "Node4" };
         TreeItems.Add(root3);
         Model root4 = new Model() { Header = "Node5" };
         TreeItems.Add(root4);
         Model root5 = new Model() { Header = "Node6" };
         TreeItems.Add(root5);
         Model root6= new Model() { Header = "Node7" };
         TreeItems.Add(root6);
         Model root7 = new Model() { Header = "Node8" };
         TreeItems.Add(root7);
         Model root8 = new Model() { Header = "Node9" };
         TreeItems.Add(root8);
         Model root9 = new Model() { Header = "Node10" };
         TreeItems.Add(root9);
         Model root10 = new Model() { Header = "Node11" };
         TreeItems.Add(root10);
         
       Model root11 = new Model() { Header = "Node12" };
       TreeItems.Add(root11);
       Model root12 = new Model() { Header = "Node13" };
       TreeItems.Add(root12);
       Model root13 = new Model() { Header = "Node14" };
       TreeItems.Add(root13);
       Model root14 = new Model() { Header = "Node15" };
       TreeItems.Add(root14);
    } 
}


MainWindow.xaml

    <Grid>        
        <syncfusion:TreeViewAdv Margin="10" x:Name="tree"   AllowDragDrop="True" ItemsSource="{Binding TreeItems}">
            <syncfusion:TreeViewAdv.ItemTemplate>
                <HierarchicalDataTemplate ItemsSource="{Binding SubItems}">
                    <TextBlock Text="{Binding Header}" />
                    <HierarchicalDataTemplate.ItemTemplate>
                        <HierarchicalDataTemplate ItemsSource="{Binding SubItems}">
                            <TextBlock Text="{Binding Header}" />
                        </HierarchicalDataTemplate>
                    </HierarchicalDataTemplate.ItemTemplate>
                </HierarchicalDataTemplate>
            </syncfusion:TreeViewAdv.ItemTemplate>
        </syncfusion:TreeViewAdv>       
    </Grid>



MainWindow.xaml.cs

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

