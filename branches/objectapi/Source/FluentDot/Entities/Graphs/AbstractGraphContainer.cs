using System;
using FluentDot.Attributes;
using FluentDot.Builders.Graphs;
using FluentDot.Entities.Edges;
using FluentDot.Entities.Nodes;

namespace FluentDot.Entities.Graphs {

    /// <summary>
    /// An abstract base class for all graphs and sub graphs.
    /// </summary>
    public abstract class AbstractGraphContainer : IGraphContainer {
        
        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="AbstractGraphContainer"/> class.
        /// </summary>
        /// <param name="graphBuilder">The graph builder.</param>
        internal AbstractGraphContainer(IGraphBuilder graphBuilder)
        {
            GraphBuilder = graphBuilder;
        }

        #endregion

        #region IGraphContainer Members

        /// <summary>
        /// Gets or sets the name of the graph.
        /// </summary>
        /// <value>The name.</value>
        public virtual string Name {
            get { return GraphBuilder.Name; }
            set { GraphBuilder.Name = value; }
        }

        /// <summary>
        /// Gets or sets the type of graph this instance represents.
        /// </summary>
        /// <value>The type of graph.</value>
        public abstract GraphType Type {
            get;
        }

        /// <summary>
        /// Adds the custom attribute to the graph.
        /// </summary>
        /// <param name="attribute">The attribute to add.</param>
        public void AddCustomAttribute(IDotAttribute attribute) {
            GraphBuilder.Attributes.AddAttribute(attribute);
        }

        /// <summary>
        /// Adds the specified node to the graph.
        /// </summary>
        /// <param name="node">The node to add to the graph.</param>
        public void AddNode(IGraphNode node) {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Adds the specified edge to the graph.
        /// </summary>
        /// <param name="edge">The edge to add to the graph.</param>
        public void AddEdge(IEdge edge) {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the graph builder.
        /// </summary>
        /// <value>The graph builder.</value>
        public IGraphBuilder GraphBuilder {
            get;
            private set;
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
            return GraphBuilder.ToDot();
        }

        #endregion

        #region Protected Members

        /// <summary>
        /// Sets the attribute on the builder.
        /// </summary>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <typeparam name="TAttribute">The type of the attribute.</typeparam>
        /// <param name="value">The attribute to set.</param>
        /// <param name="attribute">The attribute.</param>
        protected void SetAttribute<TValue, TAttribute>(TValue value, Func<TAttribute> attribute) where TAttribute : IDotAttribute {
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
        protected void SetAttribute<TValue, TAttribute>(TValue value, object defaultValue, Func<TAttribute> attribute) where TAttribute : IDotAttribute {
            if (Equals(value, defaultValue)) {
                GraphBuilder.Attributes.Remove<TAttribute>();
            } else {
                GraphBuilder.Attributes.AddAttribute(attribute());
            }
        }

        protected V GetAttributeValue<T, V>() where T : class, IDotAttribute {
            return GetAttributeValue<T, V>(default(V));
        }

        protected V GetAttributeValue<T, V>(V defaultValue) where T : class, IDotAttribute {
            var attribute = GraphBuilder.Attributes.GetAttribute<T>();
            return attribute != null ? (V)attribute.Value : defaultValue;
        }

        #endregion
    }
}
