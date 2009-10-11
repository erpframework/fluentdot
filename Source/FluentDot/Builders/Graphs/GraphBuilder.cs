/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System;
using System.Collections.Generic;
using System.Text;
using FluentDot.Entities;
using FluentDot.Entities.Edges;
using FluentDot.Entities.Graphs;
using FluentDot.Entities.Nodes;
using FluentDot.Conventions;

namespace FluentDot.Builders.Graphs
{
    /// <summary>
    /// A concrete implementation of a <see cref="IGraphBuilder"/>.
    /// </summary>
    internal class GraphBuilder : AttributeBasedEntity, IGraphBuilder {

        #region Globals

        private readonly INodeTracker nodeTracker;
        private readonly IEdgeTracker edgeTracker;
        private readonly ISubGraphTracker subGraphTracker;
        private readonly IConventionTracker conventionTracker = new ConventionTracker();
        private IEntityDefaults nodeDefaults;
        private IEntityDefaults edgeDefaults;

        private readonly List<IGraphNode> nodes = new List<IGraphNode>();
        private readonly List<IEdge> edges = new List<IEdge>();
        
        #endregion

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="GraphBuilder"/> class.
        /// </summary>
        public GraphBuilder(string graphIndicator) : this(graphIndicator, new NodeTracker(), new EdgeTracker(), new SubGraphTracker())
        {
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GraphBuilder"/> class.
        /// </summary>
        /// <param name="graphIndicator">The graph indicator.</param>
        /// <param name="nodeTracker">The node tracker.</param>
        /// <param name="edgeTracker">The edge tracker.</param>
        /// <param name="subGraphTracker">The sub graph tracker.</param>
        public GraphBuilder(string graphIndicator, INodeTracker nodeTracker, IEdgeTracker edgeTracker, ISubGraphTracker subGraphTracker)
        {
            if (edgeTracker == null) {
                throw new ArgumentException("Invalid edge tracker specified.", "edgeTracker");
            }

            if (nodeTracker == null) {
                throw new ArgumentException("Invalid node tracker specified.", "nodeTracker");
            }

            this.nodeTracker = nodeTracker;
            this.edgeTracker = edgeTracker;
            this.subGraphTracker = subGraphTracker;
            GraphIndicator = graphIndicator;
        }

        #endregion

        #region IGraphBuilder Members

        /// <summary>
        /// Gets or sets the name of the graph.
        /// </summary>
        /// <value>The name of the graph.</value>
        public virtual string Name { get; set; }

        /// <summary>
        /// Gets a readonly collection of the nodes currently in the graph.
        /// </summary>
        /// <value>The nodes in the graph.</value>
        public IEnumerable<IGraphNode> Nodes {
            get { return nodes; }
        }

        /// <summary>
        /// Gets the node lookup.
        /// </summary>
        /// <value>The node lookup.</value>
        public INodeTracker NodeLookup
        {
            get { return nodeTracker; }
        }

        /// <summary>
        /// Adds the specified node to the grpah.
        /// </summary>
        /// <param name="node">The node to add to the graph.</param>
        public void AddNode(IGraphNode node) {

            if (node == null)
            {
                throw new ArgumentException("Invalid graph node specified.", "node");
            }

            nodeTracker.AddNode(node);
            nodes.Add(node);
        }

        /// <summary>
        /// Gets a readonly collection of the edges currently in the graph.
        /// </summary>
        /// <value>The edges in the graph.</value>
        public IEnumerable<IEdge> Edges
        {
            get { return edges; }
        }

        /// <summary>
        /// Adds the specified edge to the graph.
        /// </summary>
        /// <param name="edge">The edge to add to the graph.</param>
        public void AddEdge(IEdge edge)
        {
            if (edge == null)
            {
                throw new ArgumentException("Invalid edge specified.", "edge");
            }

            edgeTracker.AddEdge(edge);
            edges.Add(edge);
        }

        /// <summary>
        /// Gets the edge lookup.
        /// </summary>
        /// <value>The edge lookup.</value>
        public IEdgeTracker EdgeLookup
        {
            get { return edgeTracker; }
        }

        /// <summary>
        /// Adds the sub graph to the graph.
        /// </summary>
        /// <param name="subGraph">The sub graph to add.</param>
        public void AddSubGraph(ISubGraph subGraph)
        {
            subGraphTracker.AddSubGraph(subGraph);
        }

        /// <summary>
        /// Gets the cluster lookup.
        /// </summary>
        /// <value>The cluster lookup.</value>
        public ISubGraphTracker SubGraphLookup
        {
            get { return subGraphTracker; }
        }

        /// <summary>
        /// Gets or sets the node defaults.
        /// </summary>
        /// <value>The node defaults.</value>
        public IEntityDefaults NodeDefaults {
            get { return nodeDefaults; }
        }

        /// <summary>
        /// Gets or sets the edge defaults.
        /// </summary>
        /// <value>The edge defaults.</value>
        public IEntityDefaults EdgeDefaults {
            get { return edgeDefaults; }
        }

        /// <summary>
        /// Gets the conventions.
        /// </summary>
        /// <value>The conventions.</value>
        public IConventionTracker Conventions {
            get { return conventionTracker; }
        }

        /// <summary>
        /// Sets the node defaults.
        /// </summary>
        /// <param name="template">The template.</param>
        public void SetNodeDefaults(IGraphNode template)
        {
            nodeDefaults = new NodeDefaults(template);
        }

        /// <summary>
        /// Sets the edge defaults.
        /// </summary>
        /// <param name="template">The template.</param>
        public void SetEdgeDefaults(IEdge template)
        {
            edgeDefaults = new EdgeDefaults(template);
        }

        /// <summary>
        /// Gets the graph indicator.
        /// </summary>
        /// <value>The graph indicator.</value>
        public string GraphIndicator {
            get;
            private set;
        }

        #endregion

        #region IDotElement Members

        /// <summary>
        /// Creates a textual Dot representation of this element.
        /// </summary>
        /// <returns>
        /// A textual Dot representation of this element.
        /// </returns>
        public virtual string ToDot()
        {
            var sb = new StringBuilder();

            sb.Append(GraphIndicator).Append(" \"").Append(Name).Append("\"");

            sb.AppendLine(" {");

            var attributes = Attributes;

            if (attributes.CurrentAttributes.Count > 0) {
                sb.Append("graph ").Append(attributes.ToDot()).AppendLine(";").AppendLine();
            }

            WriteDefaults(sb);
            WriteClusters(sb);
            WriteNodes(sb);
            WriteEdges(sb);
            sb.Append("}");

            return sb.ToString();
        }
        
        #endregion

        #region Private Members

        private void WriteDefaults(StringBuilder sb) {
            if ((nodeDefaults != null) && (nodeDefaults.AttributeCount > 0))
            {
                sb.Append(nodeDefaults.ToDot()).AppendLine(";");
            }

            if ((edgeDefaults != null) && (edgeDefaults.AttributeCount > 0))
            {
                sb.Append(edgeDefaults.ToDot()).AppendLine(";");
            }
        }

        private void WriteClusters(StringBuilder sb) {
            foreach (var cluster in subGraphTracker.Clusters) {
                sb.AppendLine(cluster.ToDot());
            }
        }

        private void WriteNodes(StringBuilder sb) {
            foreach (var node in nodes) {
                conventionTracker.ApplyConventions(node);
                sb.Append(node.ToDot()).AppendLine(";");
            }
        }

        private void WriteEdges(StringBuilder sb) {
            foreach (var edge in edges) {
                conventionTracker.ApplyConventions(edge);
                sb.Append(edge.ToDot()).AppendLine(";");
            }
        }

        #endregion
    }
}