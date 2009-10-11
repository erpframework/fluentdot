﻿/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System;

namespace FluentDot.Attributes.Shared
{
    /// <summary>
    /// An attribute that sets the margin around the graph or the label of a node.  Nothing is drawn in the margin - if you want to extend the
    /// background of the graph, use the <see cref="FluentDot.Attributes.Graphs.PadAttribute"/>.
    /// </summary>
    public class MarginAttribute : AbstractDotAttribute<PointValue> {

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="MarginAttribute"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        public MarginAttribute(PointValue value)
            : base("margin", value , true)
        {
            if (value.X < 0) {
                throw new ArgumentOutOfRangeException("value", "Margin width can be less than 0.");
            }

            if (value.Y < 0) {
                throw new ArgumentOutOfRangeException("value", "Margin height can not be less than 0.");
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MarginAttribute"/> class.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        public MarginAttribute(float width, float height) :this(new PointValue(width, height))
        {
           
        }

        #endregion
    }
}