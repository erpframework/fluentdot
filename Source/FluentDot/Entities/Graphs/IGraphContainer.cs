/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using FluentDot.Attributes;
using FluentDot.Builders.Graphs;
using FluentDot.Common;
using FluentDot.Entities.Edges;
using FluentDot.Entities.Nodes;

namespace FluentDot.Entities.Graphs {

    /// <summary>
    /// A base interface for all types of graphs and sub graphs.
    /// </summary>
    public interface IGraphContainer : IDotElement {

        /// <summary>
        /// Gets or sets the name of the graph.
        /// </summary>
        /// <value>The name.</value>
        string Name { get; set; }

        /// <summary>
        /// Gets or sets the type of graph this instance represents.
        /// </summary>
        /// <value>The type of graph.</value>
        GraphType Type { get; }

        /// <summary>
        /// Adds the custom attribute to the graph.
        /// </summary>
        /// <param name="attribute">The attribute to add.</param>
        void AddCustomAttribute(IDotAttribute attribute);

        /// <summary>
        /// Adds the specified node to the graph.
        /// </summary>
        /// <param name="node">The node to add to the graph.</param>
        void AddNode(IGraphNode node);


        /// <summary>
        /// Adds the specified edge to the graph.
        /// </summary>
        /// <param name="edge">The edge to add to the graph.</param>
        void AddEdge(IEdge edge);

        /// <summary>
        /// Gets the graph builder.
        /// </summary>
        /// <value>The graph builder.</value>
        IGraphBuilder GraphBuilder { get; }
    }
}
