/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using FluentDot.Conventions;
using FluentDot.Entities.Graphs;

namespace FluentDot.Expressions.Conventions
{
    /// <summary>
    /// A concrete implementation of a <see cref="IConventionCollectionSetupExpression"/>.
    /// </summary>
    public class ConventionCollectionSetupExpression : IConventionCollectionSetupExpression
    {
        #region Globals

        private readonly IGraph graph;

        #endregion

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="ConventionCollectionSetupExpression"/> class.
        /// </summary>
        /// <param name="graph">The graph.</param>
        public ConventionCollectionSetupExpression(IGraph graph)
        {
            this.graph = graph;
        }

        #endregion

        #region IConventionCollectionSetupExpression Members
        
        /// <summary>
        /// Adds the specified convention instance to the collection.
        /// </summary>
        /// <typeparam name="T">The type of convention to add.</typeparam>
        /// <param name="instance">The instance of the convention to add.</param>
        /// <returns>The current expression instance.</returns>
        public IConventionCollectionSetupExpression Add<T>(IConvention<T> instance)
        {
            graph.AddConvention(instance);
            return this;
        }

        #endregion
    }
}