/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System;
using FluentDot.Attributes.Graphs;
using FluentDot.Builders.Graphs;

namespace FluentDot.Entities.Graphs
{
    /// <summary>
    /// An implementation of a subgraph.
    /// </summary>
    public class SubGraph : AbstractGraphContainer, ISubGraph
    {
        #region Globals

        private readonly GraphType subGraphType = GraphType.Undirected;
        private readonly IGraph parentGraph;

        #endregion

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="Cluster"/> class.
        /// </summary>
        /// <param name="parentGraph">The parent graph.</param>
        internal SubGraph(IGraph parentGraph)
            : base( 
            new GraphBuilder( 
                "subgraph",  
                parentGraph.GraphBuilder.NodeLookup,
                parentGraph.GraphBuilder.EdgeLookup, 
                new SubGraphTracker()))
        {
            subGraphType = parentGraph.Type;
            Name = Guid.NewGuid().ToString("N");
            this.parentGraph = parentGraph;
        }
        
        #endregion

        #region ISubGraph Members

        /// <summary>
        /// Gets or sets the type of graph this instance represents.
        /// </summary>
        /// <value>The type of graph.</value>
        public override GraphType Type
        {
            get { return subGraphType; }
        }

        #endregion

        #region Public members

        /// <summary>
        /// Gets the parent graph.
        /// </summary>
        /// <value>The parent graph.</value>
        public IGraph Parent {
            get { return parentGraph; }
        }

        /// <summary>
        /// Gets or sets the rank.
        /// </summary>
        /// <value>The rank.</value>
        public RankType Rank
        {
            get { return GetAttributeValue<RankAttribute, RankType>(); }
            set { SetAttribute(value, () => new RankAttribute(value)); }
        }

        #endregion
    }
}