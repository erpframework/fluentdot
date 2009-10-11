﻿/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System.Collections.Generic;
using FluentDot.Entities.Graphs;

namespace FluentDot.Builders.Graphs
{
    /// <summary>
    /// Provides tracking for sub graphs.
    /// </summary>
    public interface ISubGraphTracker {

        /// <summary>
        /// Gets the subgraphs tracked by this instance.
        /// </summary>
        /// <value>The subgraphs tracked by this instance.</value>
        IEnumerable<ISubGraph> SubGraphs { get; }

        /// <summary>
        /// Adds the sub graph to the collection of sub graphs.
        /// </summary>
        /// <param name="subGraph">The sub graph to add to the collection.</param>
        void AddSubGraph(ISubGraph subGraph);
    }
}