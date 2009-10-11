/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System.Collections.Generic;
using System;
using System.Collections.ObjectModel;
using FluentDot.Entities.Edges;
using FluentDot.Entities.Nodes;

namespace FluentDot.Conventions
{
    /// <summary>
    /// A concrete implementation of an <see cref="IConventionTracker"/>.
    /// </summary>
    public class ConventionTracker : IConventionTracker
    {
        #region Globals

        private readonly List<IConvention<IEdge>> edgeConventions = new List<IConvention<IEdge>>();
        private readonly List<IConvention<IGraphNode>> nodeConventions = new List<IConvention<IGraphNode>>();

        #endregion

        #region IConventionTracker Members

        /// <summary>
        /// Adds the specified convention to the tracker.
        /// </summary>
        /// <typeparam name="T">The type of entity the convention is applied to.</typeparam>
        /// <param name="convention">The convention to add.</param>
        public void AddConvention<T>(IConvention<T> convention)
        {
            if (convention == null) {
                throw new ArgumentNullException("convention");
            }

            var entityType = typeof(T);

            if (typeof(IConvention<IEdge>).IsAssignableFrom(entityType))
            {
                edgeConventions.Add(entityType as IConvention<IEdge>);
            } 
            else if (typeof(IConvention<IGraphNode>).IsAssignableFrom(entityType)) {
                edgeConventions.Add(entityType as IConvention<IEdge>);
            }
        }

        /// <summary>
        /// Applies the known conventions to the specified node.
        /// </summary>
        /// <param name="node">The node to apply the conventions to.</param>
        public void ApplyConventions(IGraphNode node)
        {
            for (int i = 0; i< nodeConventions.Count; i++)
            {
                var convention = nodeConventions[i];

                if (convention.ShouldApply(node))
                {
                    convention.Apply(node);
                }
            }
        }

        /// <summary>
        /// Applies the known conventions to the specified edge.
        /// </summary>
        /// <param name="edge">The edge to apply the conventions to.</param>
        public void ApplyConventions(IEdge edge)
        {
            for (int i = 0; i < edgeConventions.Count; i++)
            {
                var convention = edgeConventions[i];
                
                if (convention.ShouldApply(edge))
                {
                    convention.Apply(edge);
                }
            }
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Gets the edge conventions.
        /// </summary>
        /// <value>The edge conventions.</value>
        public IList<IConvention<IEdge>> EdgeConventions { get { return new ReadOnlyCollection<IConvention<IEdge>>(edgeConventions); } }

        /// <summary>
        /// Gets the node conventions.
        /// </summary>
        /// <value>The node conventions.</value>
        public IList<IConvention<IGraphNode>> NodeConventions { get { return new ReadOnlyCollection<IConvention<IGraphNode>>(nodeConventions); } }

        #endregion
    }
}