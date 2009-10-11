/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using FluentDot.Attributes.Graphs;

namespace FluentDot.Entities.Graphs
{
    /// <summary>
    /// A subgraph that is contained within a graph.
    /// </summary>
    public interface ISubGraph : IGraphContainer
    {
        /// <summary>
        /// Gets the parent of the sub graph.
        /// </summary>
        /// <value>The parent of the sub graph.</value>
        IGraph Parent { get; }

        /// <summary>
        /// Specifies the rank type for this subgraph.
        /// </summary>
        /// <value>The rank of the subgraph.</value>
        RankType Rank { get; set; }
    }
}
