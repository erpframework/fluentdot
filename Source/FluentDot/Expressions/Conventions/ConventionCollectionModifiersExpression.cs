/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using FluentDot.Entities.Graphs;

namespace FluentDot.Expressions.Conventions
{
    /// <summary>
    /// A concrete implementation of a <see cref="IConventionCollectionModifiersExpression{T}"/>.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ConventionCollectionModifiersExpression<T> : IConventionCollectionModifiersExpression<T>
    {
        #region Globals

        private readonly T parent;
        private readonly IGraph graph;

        #endregion

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="ConventionCollectionModifiersExpression&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <param name="graph">The graph.</param>
        public ConventionCollectionModifiersExpression(T parent, IGraph graph)
        {
            this.parent = parent;
            this.graph = graph;
        }

        #endregion

        #region IConventionCollectionModifiersExpression<T> Members

        /// <summary>
        /// Adds the conventions configured by the specified add expression.
        /// </summary>
        /// <param name="setupExpression">The setup expression.</param>
        /// <returns>The parent expression instance.</returns>
        public T Setup(System.Action<IConventionCollectionSetupExpression> setupExpression)
        {
            if (setupExpression != null)
            {
                setupExpression(new ConventionCollectionSetupExpression(graph));
            }

            return parent;
        }

        #endregion
    }
}