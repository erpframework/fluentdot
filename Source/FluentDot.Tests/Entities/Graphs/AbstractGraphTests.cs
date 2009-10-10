/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System;
using FluentDot.Builders.Graphs;
using FluentDot.Entities.Graphs;
using NUnit.Framework;
using Rhino.Mocks;
using System.Linq.Expressions;
using System.Reflection;
using System.Drawing;

namespace FluentDot.Tests.Entities.Graphs {

    [TestFixture]
    public class AbstractGraphTests {

        #region Tests

        [Test]
        public void ToDot_Should_Call_Builders_ToDot()
        {
            var graph = new TestGraph();
            graph.GraphBuilder.Expect(x => x.ToDot()).Return("SampleDot");

            var result = graph.ToDot();

            graph.GraphBuilder.VerifyAllExpectations();
            Assert.AreEqual(result, "SampleDot");
        }

        [Test]
        public void Url_CanGetAndSet()
        {
            AssertPropertyValid(x => x.Url, "bla");
        }

        [Test]
        public void BackgroundColor_CanGetAndSet()
        {
            AssertPropertyValid(x => x.BackgroundColor, Color.DarkBlue);
            AssertPropertyValid(x => x.BackgroundColor, null);
        }

        [Test]
        public void Concentrate_CanGetAndSet()
        {
            AssertPropertyValid(x => x.Concentrate, false, true);
            AssertPropertyValid(x => x.Concentrate, false, false);
        }

        [Test]
        public void CenterOnCanvas_CanGetAndSet() {
            AssertPropertyValid(x => x.CenterOnCanvas, false, true);
            AssertPropertyValid(x => x.CenterOnCanvas, false, false);
        }

        [Test]
        public void FontName_CanGetAndSet() {
            AssertPropertyValid(x => x.FontName, "ss");
            AssertPropertyValid(x => x.FontName, null);
        }

        [Test]
        public void FontSize_CanGetAndSet() {
            AssertPropertyValid(x => x.FontSize, 3.2);
            AssertPropertyValid(x => x.FontSize, null);
        }

        #endregion

        #region Private Members

        private static void AssertPropertyValid<T>(Expression<Func<IGraph, T>> propertyExpression, T testValue)
        {
            AssertPropertyValid(propertyExpression, null, testValue);
        }

        private static void AssertPropertyValid<T>(Expression<Func<IGraph, T>> propertyExpression, object defaultValue, T testValue)
        {
            MemberExpression memberExpression = null;
            
            if (propertyExpression.Body.NodeType == ExpressionType.MemberAccess) {
                memberExpression = propertyExpression.Body as MemberExpression;
            }
            
            if (memberExpression == null)
            {
                Assert.Fail("Could not determine property member.");
            }

            var propertyInfo = (PropertyInfo)memberExpression.Member;
            var testGraph = new TestGraph(new GraphBuilder("aa"));

            Assert.AreEqual(propertyInfo.GetValue(testGraph, null), defaultValue);
            propertyInfo.SetValue(testGraph, testValue, null);
            Assert.AreEqual(propertyInfo.GetValue(testGraph, null), testValue);
        }

        private class TestGraph : AbstractGraph {

            public TestGraph() : this(MockRepository.GenerateMock<IGraphBuilder>())
            {
               
            }

            public TestGraph(IGraphBuilder builder)  : base(builder) {
                GraphBuilder = builder;
            }

            public IGraphBuilder GraphBuilder { get; private set; }

            public override GraphType Type {
                get { return GraphType.Directed; }
            }
        }

        #endregion
    }
}
