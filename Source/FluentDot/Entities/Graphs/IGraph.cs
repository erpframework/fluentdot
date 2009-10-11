/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System.Drawing;
using FluentDot.Common;
using FluentDot.Attributes.Graphs;
using FluentDot.Attributes.Shared;
using FluentDot.Attributes;

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

        /// <summary>
        /// Sets the font color that is used to label the graph.
        /// </summary>
        /// <value>Color of the font to use.</value>
        Color? FontColor { get; set; }

        /// <summary>
        /// Sets the label displayed on the graph.
        /// </summary>
        /// <value>The label of the graph.</value>
        string Label { get; set; }

        /// <summary>
        /// Sets the justification of the graph label.
        /// </summary>
        /// <value>The justification of the graph label.</value>
        Justification LabelJustification { get; set; }

        /// <summary>
        /// Sets the label location (top or bottom) of the graph label.
        /// </summary>
        /// <value>The location of the graph label.</value>
        Location LabelLocation { get; set; }

        /// <summary>
        /// Adds the custom attribute to the graph.
        /// </summary>
        /// <param name="attribute">The attribute to add.</param>
        void AddCustomAttribute(IDotAttribute attribute);

        /// <summary>
        /// Gets or sets the margin for the graph.
        /// </summary>
        /// <value>The margin represented as a point value.</value>
        PointValue Margin { get; set; }

        /// <summary>
        /// Specifies the edge ordering in the graph.
        /// </summary>
        /// <value>The ordering of edges to apply to the graph.</value>
        Ordering EdgeOrdering { get; set; }

        /// <summary>
        /// Gets or sets the graph rotation.
        /// </summary>
        /// <value>The graph rotation, in degrees.</value>
        double? Rotation { get; set; }

        /// <summary>
        /// Gets or sets the minimum node seperation.
        /// </summary>
        /// <value>The minimum node seperation.</value>
        double? MinimumNodeSeperation { get; set; }

        /// <summary>
        /// Sets justification for multi-line labels off in the global context of the graph.
        /// </summary>
        /// <value><c>true</c> if justification is off; otherwise, <c>false</c>.</value>
        bool NoJustify { get; set; }

        /// <summary>
        /// Specifies the output order of thr graph.
        /// </summary>
        /// <value>The output mode the graph should use.</value>
        OutputMode OutputOrder { get; set; }

        /// <summary>
        /// Specifies the padding, in inches, to extend the drawing area around the graph.
        /// </summary>
        /// <value>The padding in inches, represented as a point value.</value>
        PointValue Padding { get; set; }

        /// <summary>
        /// Sets the output of the graph to split among pages with the specified width and height.
        /// Pages will be output in the direction set by the page direction.
        /// </summary>
        /// <value>The size of the page.</value>
        /// <remarks>Only applicable for PostScript.</remarks>
        PointValue PageSize { get; set; }

        /// <summary>
        /// If the graph is set as paged, this specifies the order in which pages are emitted.
        /// </summary>
        /// <value>The page direction in which pages are emitted.</value>
        PageDirection PageDirection { get; set; }

        /// <summary>
        /// Sets the ratio behaviour of the graph.
        /// </summary>
        /// <value>The ratio of the graph.</value>
        RatioType Ratio { get; set; }

        /// <summary>
        /// Sets the comment on the graph.
        /// </summary>
        /// <value>The comment to include in the output.</value>
        string Comment { get; set; }

        /// <summary>
        /// Specifies the aspect of the graph.
        /// </summary>
        /// <value>The aspect to apply to the graph.</value>
        /// <returns>The current expression instance.</returns>
        AspectValue Aspect { get; set; }

        /// <summary>
        /// Specifies the rank direction the graph should use in layout.
        /// </summary>
        /// <value>The rank direction.</value>
        RankDirection RankDirection { get; set; }

        /// <summary>
        /// Sets the cluster rank mode on this graph.
        /// </summary>
        /// <value>The cluster rank mode.</value>
        ClusterMode ClusterRankMode { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="IGraph"/> is compounded.
        /// </summary>
        /// <value><c>true</c> if compounded; otherwise, <c>false</c>.</value>
        bool Compound { get; set; }

        /// <summary>
        /// Specifies the rank seperation for ranks.
        /// </summary>
        /// <value>The rank seperation.</value>
        RankSeperation RankSeperation { get; set; }
    }
}
