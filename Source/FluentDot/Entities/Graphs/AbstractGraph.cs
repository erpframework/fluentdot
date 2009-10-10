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
            get { return GetAttributeValue<FontSizeAttribute, double>(); }
            set { SetAttribute(value, () => new FontSizeAttribute(value.Value)); }
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
