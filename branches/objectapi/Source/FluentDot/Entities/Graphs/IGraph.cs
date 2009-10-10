/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System.Drawing;
using FluentDot.Common;

namespace FluentDot.Entities.Graphs {

    /// <summary>
    /// A representation of a graph.
    /// </summary>
    public interface IGraph : IDotElement {

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
        /// Sets the url property on the graph.
        /// </summary>
        /// <value>The URL to set on the graph.</value>
        string Url { get; set; }

        /// <summary>
        /// Sets the background color of the graph.
        /// </summary>
        /// <value>The color to set the background to.</value>
        Color? BackgroundColor { get; set; }

        /// <summary>
        /// Sets the graph as concentrated - that is, to use edge concentrators.  The default is <c>false</c>.
        /// </summary>
        /// <value><c>true</c> if concentrate; otherwise, <c>false</c>.</value>
        bool Concentrate { get; set; }

        /// <summary>
        /// Sets whether the the graph should be centered on the canvase.  The default is <c>false</c>.
        /// </summary>
        /// <value><c>true</c> if the graph should be centered on the canvas; otherwise, <c>false</c>.</value>
        bool CenterOnCanvas { get; set; }

        /// <summary>
        /// Sets the font name that is used to label the graph.
        /// </summary>
        /// <param name="value">Name of the font to use.</param>
        string FontName { get; set; }

        /// <summary>
        /// Sets the font size that is used to label the graph.
        /// </summary>
        /// <value>The size of the font.</value>
        double? FontSize { get; set; }
    }
}
