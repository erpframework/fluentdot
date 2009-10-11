/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System;
using System.Drawing;
using FluentDot.Attributes.Graphs;

namespace FluentDot.Entities.Graphs
{
    /// <summary>
    /// An implementation of a cluster.
    /// </summary>
    public class Cluster : SubGraph, ICluster {

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="Cluster"/> class.
        /// </summary>
        /// <param name="parentGraph">The parent graph.</param>
        public Cluster(AbstractGraph parentGraph)
            : base(parentGraph)
        {
            
        }

        #endregion

        #region AbstractGraph Members

        /// <summary>
        /// Gets or sets the name of the graph.
        /// </summary>
        /// <value>The name of the graph.</value>
        public override sealed string Name {
            get { return base.Name; }
            set {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("value");
                }

                if (value.StartsWith("cluster")) 
                {
                    base.Name = value;
                } 
                else 
                {
                    base.Name = "cluster" + value;
                }
            }
        }

        #endregion

        #region ICluster Members

        /// <summary>
        /// Gets or sets the color of the background.
        /// </summary>
        /// <value>The color of the background.</value>
        public Color? BackgroundColor {
            get { return GetAttributeValue<BackgroundColorAttribute, Color?>(); }
            set { SetAttribute(value, () => new BackgroundColorAttribute(value.Value)); }
        }

        #endregion
    }
}