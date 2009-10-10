/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System.Collections.Generic;
using FluentDot.Common;

namespace FluentDot.Attributes
{
    /// <summary>
    /// A collection of DOT attributes.
    /// </summary>
    public interface IAttributeCollection : IDotElement {

        /// <summary>
        /// Adds the attribute to the collection;
        /// </summary>
        /// <param name="attribute">The attribute.</param>
        void AddAttribute(IDotAttribute attribute);

        /// <summary>
        /// Gets the current attributes.
        /// </summary>
        /// <value>The current attributes.</value>
        IList<IDotAttribute> CurrentAttributes { get; }

        /// <summary>
        /// Gets the attribute by type.
        /// </summary>
        /// <typeparam name="T">The type of attribute.</typeparam>
        /// <returns>The attribute instance, if found, else null.</returns>
        T GetAttribute<T>() where T : IDotAttribute;

        /// <summary>
        /// Removes an attribute of this type, if found.
        /// </summary>
        /// <typeparam name="T">The type of attirbute to remove.</typeparam>
        void Remove<T>() where T : IDotAttribute;
    }
}