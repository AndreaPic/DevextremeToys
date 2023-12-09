using DevExtremeToys.Reflection;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DevExtremeToys.Visitors
{
    /// <summary>
    /// Information about current visiting node
    /// </summary>
    public class NodeInfo
    {
        /// <summary>
        /// Constructor with current info
        /// </summary>
        /// <param name="propertyName">Property analyzed (it could be null es. for root instance)</param>
        /// <param name="currentInstance">Current instance analyzed object</param>
        /// <param name="currentPropertyInfo">Property info that owns current instance (it could be null es. for root instance) </param>
        /// <param name="parentNode">Node info of current instance's parent object (it could be null es. for root instance)</param>
        public NodeInfo(string propertyName, object currentInstance, PropertyInfo currentPropertyInfo, NodeInfo parentNode)
        {
            PropertyName = propertyName;
            CurrentInstance = currentInstance;
            CurrentPropertyInfo = currentPropertyInfo;
            ParentNode = parentNode;
            if (parentNode?.CurrentPath != null) 
            {
                CurrentPath = $"{parentNode.CurrentPath}.";
            }
            if (PropertyName != null)
            {
                CurrentPath = CurrentPath + PropertyName;
            }
        }


        /// <summary>
        /// Property analyzed (it could be null es. for root instance)
        /// </summary>
        public string PropertyName { get; private set; }
        /// <summary>
        /// Current instance analyzed object
        /// </summary>
        public object CurrentInstance { get; private set; }
        /// <summary>
        /// Property info that owns current instance (it could be null es. for root instance) 
        /// </summary>
        public PropertyInfo CurrentPropertyInfo { get; private set; }
        /// <summary>
        /// Parent object instance (it could be null es. for root instance) 
        /// </summary>
        public object? ParentInstance 
        { 
            get
            {
                return ParentNode?.CurrentInstance;
            }
        }
        /// <summary>
        /// Navigation path of current node (it could be null es. for root instance) 
        /// </summary>
        public string CurrentPath { get; private set; }
        /// <summary>
        /// Parent object (it could be null es. for root instance) 
        /// </summary>
        public NodeInfo ParentNode { get; private set; }
        
        /// <summary>
        /// If set to true the analysis of current node stops (other nodes continue)
        /// </summary>
        public bool IsStopVisitCurrentNodeRequested { get; private set; }

        /// <summary>
        /// If set to true the analysis stops (on all nodes)
        /// </summary>
        public bool IsStopAllVisitsRequested { get; private set; }

        /// <summary>
        /// If set to true the analysis of current node stops (other nodes continue)
        /// </summary>
        public void StopVisitCurrentNode()
        {
            IsStopVisitCurrentNodeRequested = true;
        }
        
        /// <summary>
        /// If set to true the analysis of all nodes stops
        /// </summary>
        public void StopAllVisits()
        {
            IsStopAllVisitsRequested = true;
        }

    }

    /// <summary>
    /// Extension for object inspection
    /// </summary>
    public static class Visitor
    {

        /// <summary>
        /// Traverse object's property of class type awaiting inspectFunc param
        /// </summary>
        /// <param name="objectToInspect">Current extended object to analyze</param>
        /// <param name="inspectFunc">Async Task Function to invoke during traverse</param>
        public static async Task VisitAsync(this object objectToInspect, Func<NodeInfo,Task> inspectFunc)
        {
            if (objectToInspect == null)
            {
                return;
            }
            List<object> nodes = new List<object>();
            NodeInfo nodeInfo = new NodeInfo(null, objectToInspect, null, null);

            await VisitNodesAsync(nodeInfo, nodes, nodeInfo, inspectFunc);
        }

        /// <summary>
        /// Recursive visit implementation awaiting inspectFunc param
        /// </summary>
        /// <param name="currentNode">Node for action to invoke</param>
        /// <param name="nodes">traversed nodes</param>
        /// <param name="parentNode">last parent node</param>
        /// <param name="inspectFunc">Async Task Function to invoke during traverse</param>
        private static async Task VisitNodesAsync(NodeInfo currentNode, List<object> nodes, NodeInfo parentNode, Func<NodeInfo, Task> inspectFunc)
        {
            if (nodes.FirstOrDefault(n => object.ReferenceEquals(n, currentNode.CurrentInstance)) != null)
            {
                return;
            }
            else
            {
                await inspectFunc(currentNode);
                nodes.Add(currentNode.CurrentInstance);
                if (currentNode.IsStopVisitCurrentNodeRequested)
                {
                    return;
                }
            }

            var properties = currentNode.CurrentInstance.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy);
            var classProps = properties.Where(p => p.PropertyType.IsClass && p.PropertyType != typeof(string));
            foreach (var classProp in classProps)
            {
                var pValue = currentNode.CurrentInstance.GetPropertyValue(classProp.Name);
                if (pValue != null)
                {
                    NodeInfo childNode = new NodeInfo(classProp.Name, pValue, classProp, parentNode);
                    if (!(pValue is IEnumerable enumerable))
                    {
                        await VisitNodesAsync(childNode, nodes, currentNode, inspectFunc);
                        if (currentNode.IsStopAllVisitsRequested)
                        {
                            return;
                        }
                    }
                    else
                    {
                        NodeInfo enumerableNode = new NodeInfo(classProp.Name, pValue, classProp, parentNode);
                        if (nodes.FirstOrDefault(n => object.ReferenceEquals(n, pValue)) == null)
                        {
                            await inspectFunc(enumerableNode);
                            if (enumerableNode.IsStopAllVisitsRequested)
                            {
                                return;
                            }
                            if (enumerableNode.IsStopVisitCurrentNodeRequested)
                            {
                                break;
                            }
                        }

                        foreach (var item in enumerable)
                        {
                            NodeInfo itemNode = new NodeInfo("Current", item, classProp, childNode);
                            await VisitNodesAsync(itemNode, nodes, currentNode, inspectFunc);
                            if (currentNode.IsStopAllVisitsRequested)
                            {
                                return;
                            }
                        }
                    }
                }
            }
        }


        /// <summary>
        /// Traverse object's property of class type
        /// </summary>
        /// <param name="objectToInspect">Current extended object to analyze</param>
        /// <param name="inspectAction">Action to invoke during traverse</param>
        public static void Visit(this object objectToInspect, Action<NodeInfo> inspectAction)
        {
            if (objectToInspect == null)
            {
                return;
            }
            List<object> nodes = new List<object>();
            NodeInfo nodeInfo = new NodeInfo(null, objectToInspect, null, null);

            VisitNodes(nodeInfo, nodes, nodeInfo, inspectAction);
        }

        /// <summary>
        /// Recursive visit implementation
        /// </summary>
        /// <param name="currentNode">Node for action to invoke</param>
        /// <param name="nodes">traversed nodes</param>
        /// <param name="parentNode">last parent node</param>
        /// <param name="inspectAction">action to invoke</param>
        private static void VisitNodes(NodeInfo currentNode, List<object> nodes, NodeInfo parentNode, Action<NodeInfo> inspectAction)
        {
            if (nodes.FirstOrDefault(n => object.ReferenceEquals(n, currentNode.CurrentInstance)) != null)
            {
                return;
            }
            else
            {
                inspectAction(currentNode);
                nodes.Add(currentNode.CurrentInstance);
                if ( (currentNode.IsStopVisitCurrentNodeRequested) || (currentNode.IsStopAllVisitsRequested))
                {
                    return;
                }
            }

            var properties = currentNode.CurrentInstance.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy);
            var classProps = properties.Where(p => p.PropertyType.IsClass && p.PropertyType != typeof(string));
            foreach (var classProp in classProps)
            {
                var pValue = currentNode.CurrentInstance.GetPropertyValue(classProp.Name);
                if (pValue != null)
                {
                    NodeInfo childNode = new NodeInfo(classProp.Name, pValue, classProp, parentNode);
                    if (!(pValue is IEnumerable enumerable))
                    {
                        VisitNodes(childNode, nodes, currentNode, inspectAction);
                        if (childNode.IsStopAllVisitsRequested)
                        {
                            return;
                        }
                    }
                    else
                    {
                        NodeInfo enumerableNode = new NodeInfo(classProp.Name, pValue, classProp, parentNode);
                        if (nodes.FirstOrDefault(n => object.ReferenceEquals(n, pValue)) == null)
                        {
                            inspectAction(enumerableNode);
                            if (enumerableNode.IsStopAllVisitsRequested)
                            {
                                return;
                            }
                        }

                        foreach (var item in enumerable)
                        {
                            NodeInfo itemNode = new NodeInfo("Current", item, classProp, childNode);
                            VisitNodes(itemNode, nodes, currentNode, inspectAction);
                            if (itemNode.IsStopAllVisitsRequested)
                            {
                                return;
                            }
                        }
                    }
                }
            }
        }
    }
}
