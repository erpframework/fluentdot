/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentDot.Attributes
{
    /// <summary>
    /// A concrete implementation of a <see cref="IAttributeCollection"/>.
    /// </summary>
    public class AttributeCollection : IAttributeCollection {

        #region Globals

        private readonly Dictionary<Type, IDotAttribute> attributes = new Dictionary<Type, IDotAttribute>();

        #endregion

        #region IAttributeCollection Members

        /// <summary>
        /// Adds the attribute to the collection;
        /// </summary>
        /// <param name="attribute">The attribute.</param>
        public void AddAttribute(IDotAttribute attribute) {
            var attributeType = attribute.GetType();

            if (!attributes.ContainsKey(attributeType))
            {
                attributes.Add(attributeType, attribute);
            }
        }

        /// <summary>
        /// Gets the current attributes.
        /// </summary>
        /// <value>The current attributes.</value>
        public IList<IDotAttribute> CurrentAttributes {
            get { return attributes.Values.ToList(); }
        }

        /// <summary>
        /// Gets the attribute by type.
        /// </summary>
        /// <typeparam name="T">The type of attribute.</typeparam>
        /// <returns>
        /// The attribute instance, if found, else null.
        /// </returns>
        public T GetAttribute<T>() where T : IDotAttribute
        {
            IDotAttribute attribute;
            
            if (attributes.TryGetValue(typeof(T), out attribute)) {
                return (T) attribute;
            }

            return default(T);
        }

        /// <summary>
        /// Removes an attribute of this type, if found.
        /// </summary>
        /// <typeparam name="T">The type of attirbute to remove.</typeparam>
        public void Remove<T>() where T : IDotAttribute
        {
            Type type = typeof(T);

            if (attributes.ContainsKey(type))
            {
                attributes.Remove(type);
            }
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
            
            if (attributes.Count == 0)
            {
                return string.Empty;
            }

            var sb = new StringBuilder("[");
            
            foreach (var attribute in attributes.Values) {
                sb.Append(attribute.ToDot()).Append(", ");
            }

            // Remove our last comma and space
            sb.Remove(sb.Length - 2, 2);
            sb.Append("]");

            return sb.ToString();
        }

        #endregion
    }
}