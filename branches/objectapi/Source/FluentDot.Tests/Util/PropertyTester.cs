/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System;
using System.Linq.Expressions;
using System.Reflection;
using NUnit.Framework;

namespace FluentDot.Tests.Util {
    
    public static class PropertyTester {

        public static void AssertPropertyValid<T, I>(I instance, Expression<Func<I, T>> propertyExpression, T testValue) {
            AssertPropertyValid(instance, propertyExpression, null, testValue);
        }

        public static void AssertPropertyValid<T, I>(I instance, Expression<Func<I, T>> propertyExpression, object defaultValue, T testValue) {
            MemberExpression memberExpression = null;

            if (propertyExpression.Body.NodeType == ExpressionType.MemberAccess) {
                memberExpression = propertyExpression.Body as MemberExpression;
            }

            if (memberExpression == null) {
                Assert.Fail("Could not determine property member.");
            }

            var propertyInfo = (PropertyInfo)memberExpression.Member;
            
            Assert.AreEqual(propertyInfo.GetValue(instance, null), defaultValue);
            propertyInfo.SetValue(instance, testValue, null);
            Assert.AreEqual(propertyInfo.GetValue(instance, null), testValue);
        }
    }
}
