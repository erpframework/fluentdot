/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

namespace FluentDot.Conventions
{
    /// <summary>
    /// A marker interface for conventions.
    /// </summary>
    public interface IConvention<T>
    {
        /// <summary>
        /// Determines whether the configuration in the Apply method should be applied to this entity instance.
        /// </summary>
        /// <param name="entity">The entity currently being inspected.</param>
        /// <returns>An indication of whether we should proceed with configuring this entity instance.</returns>
        bool ShouldApply(T entity);

        /// <summary>
        /// Applies the specified configuration to the entity in question.
        /// </summary>
        /// <param name="entity">The entity to which the configuration should be applied to.</param>
        void Apply(T entity);
    }
}
