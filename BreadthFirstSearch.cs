using System;
using System.Collections.Generic;
using Graphs.Models;

namespace Graphs
{
    public class BreadthFirstSearch
    {
        #region Graphs
        GraphModel you = new("You");
        GraphModel alice = new("Alice");
        GraphModel bob = new("Bob");
        GraphModel claire = new("Claire");
        GraphModel anju = new("Anju");
        GraphModel peggy = new("Peggy");
        GraphModel thom = new("Thom");
        GraphModel jonny = new("Jonny");
        #endregion

        public bool Start(string GraphName)
        {
            Dictionary<GraphModel, List<GraphModel>> graphsDictionary = CreateGraphDictionary();
            Queue<KeyValuePair<GraphModel, List<GraphModel>>> GraphsQueue = new();

            GraphsQueue.Enqueue(graphsDictionary.Where(x => x.Key.GraphName == GraphName).First());
            
            while (GraphsQueue.Count() != 0)
            {
                var person = GraphsQueue.Select(x => x).First();
                if (person.Key.IsChecked == false)
                {
                    if (SimpleCheck(person.Key.GraphName))
                    {   
                        Console.WriteLine($"Result: {person.Key.GraphName}");
                        return true;
                    }
                    else
                    {
                        foreach(var item in person.Value)
                        {
                            GraphsQueue.Enqueue(graphsDictionary.Where(x => x.Key.GraphName == item.GraphName).First());
                        }
                    }
                }
                GraphsQueue.Dequeue();
            }
            return false;
        }
        
        private Dictionary<GraphModel, List<GraphModel>> CreateGraphDictionary()
        {
            return new Dictionary<GraphModel, List<GraphModel>>()
            {
                { you, new List<GraphModel>() {alice, bob, claire } },
                { alice, new List<GraphModel>() {peggy } },
                { bob, new List<GraphModel>() {anju, peggy} },
                { claire, new List<GraphModel>() {thom, jonny} },
                {thom, new List<GraphModel>() {} },
                {jonny, new List<GraphModel>() {} },
                {anju, new List<GraphModel>() {} },
                {peggy, new List<GraphModel>() {} },
            };
        }

        //You can modify this method.
        private bool SimpleCheck(string name)
        {
            if (name.Contains('T'))
                return true;
            return false;
        }

    }
}
