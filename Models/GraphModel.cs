using System;
namespace Graphs.Models
{
    public class GraphModel
    {
        public GraphModel(string name)
        {
            this.GraphName = name;
        }
        public string GraphName { get; set; }
        public bool IsChecked { get; set; } = false;
    }
}

