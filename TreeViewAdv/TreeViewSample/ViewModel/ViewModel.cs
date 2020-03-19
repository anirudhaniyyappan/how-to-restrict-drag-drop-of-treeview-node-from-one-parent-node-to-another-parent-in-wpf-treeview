using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace TreeViewSample
{
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
}
