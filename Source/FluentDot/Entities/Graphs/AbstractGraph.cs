/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System;
using System.Drawing;
using FluentDot.Attributes;
using FluentDot.Attributes.Graphs;
using FluentDot.Attributes.Shared;
using FluentDot.Builders.Graphs;

namespace FluentDot.Entities.Graphs {

    /// <summary>
    /// An abstract base class for graphs.
    /// </summary>
    public abstract class AbstractGraph : IGraph {

        #region Globals

        private readonly IGraphBuilder graphBuilder;

        #endregion

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="AbstractGraph"/> class.
        /// </summary>
        /// <param name="graphBuilder">The graph builder.</param>
        internal AbstractGraph(IGraphBuilder graphBuilder)
        {
            this.graphBuilder = graphBuilder;
        }

        #endregion

        #region IGraph Members

        /// <summary>
        /// Gets or sets the name of the graph.
        /// </summary>
        /// <value>The name.</value>
        public string Name
        {
            get { return graphBuilder.Name; }
            set { graphBuilder.Name = value; }
        }

        /// <summary>
        /// Gets or sets the type of graph this instance represents.
        /// </summary>
        /// <value>The type of graph.</value>
        public abstract GraphType Type {
            get;
        }

        /// <summary>
        /// Sets the url property on the graph.
        /// </summary>
        /// <value>The URL to set on the graph.</value>
        public string Url
        {
            get { return GetAttributeValue<LabelAttribute, string>(); }
            set { SetAttribute(value, () => new LabelAttribute(value)); }
        }

        /// <summary>
        /// Sets the background color of the graph.
        /// </summary>
        /// <value>The color to set the background to.</value>
        public Color? BackgroundColor
        {
            get { return GetAttributeValue<BackgroundColorAttribute, Color?>(); }
            set { SetAttribute(value, () => new BackgroundColorAttribute(value.Value));}
        }

        /// <summary>
        /// Sets the graph as concentrated - that is, to use edge concentrators.
        /// </summary>
        /// <value><c>true</c> if concentrate; otherwise, <c>false</c>.</value>
        public bool Concentrate
        {
            get { return GetAttributeValue<ConcentrateAttribute, bool>(false); }
            set { SetAttribute(value, false, () => new ConcentrateAttribute(value)); }
        }

        /// <summary>
        /// Sets whether the the graph should be centered on the canvase.  The default is <c>false</c>.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if the graph should be centered on the canvas; otherwise, <c>false</c>.
        /// </value>
        public bool CenterOnCanvas {
            get { return GetAttributeValue<CenterAttribute, bool>(false); }
            set { SetAttribute(value, false, () => new CenterAttribute(value)); }
        }

        /// <summary>
        /// Sets the font name that is used to label the graph.
        /// </summary>
        /// <value></value>
        /// <param name="value">Name of the font to use.</param>
        public string FontName
        {
            get { return GetAttributeValue<FontNameAttribute, string>(); }
            set { SetAttribute(value, () => new FontNameAttribute(value)); }
        }

        /// <summary>
        /// Sets the font size that is used to label the graph.
        /// </summary>
        /// <value>The size of the font.</value>
        public double? FontSize
        {
            get { return GetAttributeValue<FontSizeAttribute, double?>(); }
            set { SetAttribute(value, () => new FontSizeAttribute(value.Value)); }
        }

        /// <summary>
        /// Sets the font color that is used to label the graph.
        /// </summary>
        /// <value>Color of the font to use.</value>
        public Color? FontColor
        {
            get { return GetAttributeValue<FontColorAttribute, Color?>(); }
            set { SetAttribute(value, () => new FontColorAttribute(value.Value)); }
        }

        /// <summary>
        /// Sets the label displayed on the graph.
        /// </summary>
        /// <value>The label of the graph.</value>
        public string Label
        {
            get { return GetAttributeValue<LabelAttribute, string>(); }
            set { SetAttribute(value, () => new LabelAttribute(value)); }
        }

        /// <summary>
        /// Sets the justification of the graph label.
        /// </summary>
        /// <value>The justification of the graph label.</value>
        public Justification LabelJustification
        {
            get { return GetAttributeValue<LabelJustificationAttribute, Justification>(); }
            set { SetAttribute(value, () => new LabelJustificationAttribute(value)); }
        }

        /// <summary>
        /// Sets the label location (top or bottom) of the graph label.
        /// </summary>
        /// <value>The location of the graph label.</value>
        public Location LabelLocation
        {
            get { return GetAttributeValue<LabelLocationAttribute, Location>(); }
            set { SetAttribute(value, () => new LabelLocationAttribute(value)); }
        }

        /// <summary>
        /// Adds the custom attribute to the graph.
        /// </summary>
        /// <param name="attribute">The attribute to add.</param>
        public void AddCustomAttribute(IDotAttribute attribute)
        {
            graphBuilder.Attributes.AddAttribute(attribute);
        }

        /// <summary>
        /// Gets or sets the margin for the graph.
        /// </summary>
        /// <value>The margin represented as a point value.</value>
        public PointValue Margin
        {
            get { return GetAttributeValue<MarginAttribute, PointValue>(); }
            set { SetAttribute(value, () => new MarginAttribute(value)); }
        }

        /// <summary>
        /// Specifies the edge ordering in the graph.
        /// </summary>
        /// <value>The ordering of edges to apply to the graph.</value>
        public Ordering EdgeOrdering
        {
            get { return GetAttributeValue<OrderingAttribute, Ordering>(); }
            set { SetAttribute(value, () => new OrderingAttribute(value)); }
        }

        /// <summary>
        /// Gets or sets the graph rotation.
        /// </summary>
        /// <value>The graph rotation, in degrees.</value>
        public double? Rotation
        {
            get { return GetAttributeValue<RotateAttribute, double?>(); }
            set { SetAttribute(value, () => new RotateAttribute(value.Value)); }
        }

        /// <summary>
        /// Gets or sets the minimum node seperation.
        /// </summary>
        /// <value>The minimum node seperation, in inches.</value>
        public double? MinimumNodeSeperation
        {
            get { return GetAttributeValue<NodeSeperationAttribute, double?>(); }
            set { SetAttribute(value, () => new NodeSeperationAttribute(value.Value)); }
        }

        /// <summary>
        /// Sets justification for multi-line labels off in the global context of the graph.
        /// </summary>
        /// <value><c>true</c> if justification is off; otherwise, <c>false</c>.</value>
        public bool NoJustify
        {
            get { return GetAttributeValue<NoJustifyAttribute, bool>(false); }
            set { SetAttribute(value, false, () => new NoJustifyAttribute(value)); }
        }

        /// <summary>
        /// Specifies the output order of thr graph.
        /// </summary>
        /// <value>The output mode the graph should use.</value>
        public OutputMode OutputOrder
        {
            get { return GetAttributeValue<OutputOrderAttribute, OutputMode>(); }
            set { SetAttribute(value, () => new OutputOrderAttribute(value)); }
        }

        /// <summary>
        /// Specifies the padding, in inches, to extend the drawing area around the graph.
        /// </summary>
        /// <value>The padding in inches, represented as a point value.</value>
        public PointValue Padding
        {
            get { return GetAttributeValue<PadAttribute, PointValue>(); }
            set { SetAttribute(value, () => new PadAttribute(value)); }
        }

        /// <summary>
        /// Sets the output of the graph to split among pages with the specified width and height.
        /// Pages will be output in the direction set by the page direction.
        /// </summary>
        /// <value>The size of the page.</value>
        /// <remarks>Only applicable for PostScript.</remarks>
        public PointValue PageSize
        {
            get { return GetAttributeValue<PageAttribute, PointValue>(); }
            set { SetAttribute(value, () => new PageAttribute(value)); }
        }

        /// <summary>
        /// If the graph is set as paged, this specifies the order in which pages are emitted.
        /// </summary>
        /// <value>The page direction in which pages are emitted.</value>
        public PageDirection PageDirection
        {
            get { return GetAttributeValue<PageDirectionAttribute, PageDirection>(); }
            set { SetAttribute(value, () => new PageDirectionAttribute(value)); }
        }

        /// <summary>
        /// Sets the ratio behaviour of the graph.
        /// </summary>
        /// <value>The ratio of the graph.</value>
        public RatioType Ratio
        {
            get { return GetAttributeValue<RatioAttribute, RatioType>(); }
            set { SetAttribute(value, () => new RatioAttribute(value)); }
        }

        /// <summary>
        /// Sets the comment on the graph.
        /// </summary>
        /// <value>The comment to include in the output.</value>
        public string Comment
        {
            get { return GetAttributeValue<CommentAttribute, string>(); }
            set { SetAttribute(value, () => new CommentAttribute(value)); }
        }

        /// <summary>
        /// Specifies the aspect of the graph.
        /// </summary>
        /// <value>The aspect to apply to the graph.</value>
        /// <returns>The current expression instance.</returns>
        public AspectValue Aspect
        {
            get { return GetAttributeValue<AspectAttribute, AspectValue>(); }
            set { SetAttribute(value, () => new AspectAttribute(value)); }
        }

        /// <summary>
        /// Specifies the rank direction the graph should use in layout.
        /// </summary>
        /// <value>The rank direction.</value>
        public RankDirection RankDirection
        {
            get { return GetAttributeValue<RankDirectionAttribute, RankDirection>(); }
            set { SetAttribute(value, () => new RankDirectionAttribute(value)); }
        }

        /// <summary>
        /// Sets the cluster rank mode on this graph.
        /// </summary>
        /// <value>The cluster rank mode.</value>
        public ClusterMode ClusterRankMode
        {
            get { return GetAttributeValue<ClusterRankAttribute, ClusterMode>(); }
            set { SetAttribute(value, () => new ClusterRankAttribute(value)); }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="IGraph"/> is compounded.
        /// </summary>
        /// <value><c>true</c> if compounded; otherwise, <c>false</c>.</value>
        public bool Compound
        {
            get { return GetAttributeValue<CompoundAttribute, bool>(false); }
            set { SetAttribute(value, false, () => new CompoundAttribute(value)); }
        }

        /// <summary>
        /// Specifies the rank seperation for ranks.
        /// </summary>
        /// <value>The rank seperation.</value>
        public RankSeperation RankSeperation
        {
            get { return GetAttributeValue<RankSeperationAttribute, RankSeperation>(); }
            set { SetAttribute(value, () => new RankSeperationAttribute(value)); }
        }

        #endregion

        #region IDotElement Members

        /// <summary>
        /// Creates a textual Dot representation of this element.
        /// </summary>
        /// <returns>
        /// A textual Dot representation of this element.
        /// </returns>
        public string ToDot() {
            return graphBuilder.ToDot();
        }

        #endregion

        #region Private Members
        
        /// <summary>
        /// Sets the attribute on the builder.
        /// </summary>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <typeparam name="TAttribute">The type of the attribute.</typeparam>
        /// <param name="value">The attribute to set.</param>
        /// <param name="attribute">The attribute.</param>
        private void SetAttribute<TValue, TAttribute>(TValue value, Func<TAttribute> attribute) where TAttribute : IDotAttribute
        {
            SetAttribute(value, null, attribute);
        }

        /// <summary>
        /// Sets the attribute on the builder.
        /// </summary>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <typeparam name="TAttribute">The type of the attribute.</typeparam>
        /// <param name="value">The attribute to set.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <param name="attribute">The attribute.</param>
        private void SetAttribute<TValue, TAttribute>(TValue value, object defaultValue, Func<TAttribute> attribute) where TAttribute : IDotAttribute {
            if (Equals(value, defaultValue)) 
            {
                graphBuilder.Attributes.Remove<TAttribute>();
            } 
            else 
            {
                graphBuilder.Attributes.AddAttribute(attribute());
            }
        }
        
        private V GetAttributeValue<T, V>() where T: class, IDotAttribute
        {
            return GetAttributeValue<T, V>(default(V));
        }

        private V GetAttributeValue<T, V>(V defaultValue) where T : class, IDotAttribute {
            var attribute = graphBuilder.Attributes.GetAttribute<T>();
            return attribute != null ? (V)attribute.Value : defaultValue;
        }

        #endregion
    }
}
