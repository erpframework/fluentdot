/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using FluentDot.Builders.Graphs;

namespace FluentDot.Entities.Graphs
{
    /// <summary>
    /// A concrete implementation of a <see cref="IUndirectedGraph"/>.
    /// </summary>
    public class UndirectedGraph : AbstractGraph, IUndirectedGraph {

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="UndirectedGraph"/> class.
        /// </summary>
        public UndirectedGraph()
            : base(new GraphBuilder("graph"))
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UndirectedGraph"/> class.
        /// </summary>
        /// <param name="graphBuilder">The graph builder.</param>
        internal UndirectedGraph(IGraphBuilder graphBuilder)
            : base(graphBuilder)
        {

        }

        #endregion

        #region AbstractGraph Members

        /// <summary>
        /// Gets or sets the type of graph this instance represents.
        /// </summary>
        /// <value>The type of graph.</value>
        public override GraphType Type
        {
            get { return GraphType.Undirected; }
        }
       
        #endregion
    }
}