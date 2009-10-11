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
using FluentDot.Attributes.Graphs;
using FluentDot.Attributes.Shared;
using FluentDot.Attributes;

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
            AssertPropertyValid(x => x.Url, null);
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

        [Test]
        public void FontColor_CanGetAndSet()
        {
            AssertPropertyValid(x => x.FontColor, Color.Beige);
            AssertPropertyValid(x => x.FontColor, null);
        }

        [Test]
        public void Label_CanGetAndSet() {
            AssertPropertyValid(x => x.Label, "label");
            AssertPropertyValid(x => x.Label, null);
        }

        [Test]
        public void LabelJustification_CanGetAndSet()
        {
            AssertPropertyValid(x => x.LabelJustification, Justification.Center);
            AssertPropertyValid(x => x.LabelJustification, null);
        }

        [Test]
        public void LabelLocation_CanGetAndSet()
        {
            AssertPropertyValid(x => x.LabelLocation, Location.Bottom);
            AssertPropertyValid(x => x.LabelLocation, null);
        }

        [Test]
        public void Margin_CanGetAndSet()
        {
            AssertPropertyValid(x => x.Margin, new PointValue(10, 15));
            AssertPropertyValid(x => x.Margin, null);
        }

        [Test]
        public void EdgeOrdering_CanGetAndSet()
        {
            AssertPropertyValid(x => x.EdgeOrdering, Ordering.In);
            AssertPropertyValid(x => x.EdgeOrdering, null);
        }

        [Test]
        public void Rotation_CanGetAndSet()
        {
            AssertPropertyValid(x => x.Rotation, 180);
            AssertPropertyValid(x => x.Rotation, null);
        }

        [Test]
        public void MinimumNodeSeperation_CanGetAndSet()
        {
            AssertPropertyValid(x => x.MinimumNodeSeperation, 1.1);
            AssertPropertyValid(x => x.MinimumNodeSeperation, null);
        }

        [Test]
        public void NoJustify_CanGetAndSet()
        {
            AssertPropertyValid(x => x.NoJustify, true);
            AssertPropertyValid(x => x.NoJustify, false);
        }

        [Test]
        public void OutputOrder_CanGetAndSet()
        {
            AssertPropertyValid(x => x.OutputOrder, OutputMode.BreadthFirst);
            AssertPropertyValid(x => x.OutputOrder, null);
        }

        [Test]
        public void PageSize_CanGetAndSet()
        {
            AssertPropertyValid(x => x.PageSize, new PointValue(3, 4));
            AssertPropertyValid(x => x.PageSize, null);
        }

        [Test]
        public void PageDirection_CanGetAndSet()
        {
            AssertPropertyValid(x => x.PageDirection, PageDirection.BottomToTopRightToLeft);
            AssertPropertyValid(x => x.PageDirection, null);
        }

        [Test]
        public void Ratio_CanGetAndSet()
        {
            AssertPropertyValid(x => x.Ratio, new RatioType(3));
            AssertPropertyValid(x => x.Ratio, null);
        }

        [Test]
        public void Comment_CanGetAndSet()
        {
            AssertPropertyValid(x => x.Comment, "aa");
            AssertPropertyValid(x => x.Comment, null);
        }

        [Test]
        public void Aspect_CanGetAndSet() {
            AssertPropertyValid(x => x.Aspect, new AspectValue(4));
            AssertPropertyValid(x => x.Aspect, null);
        }

        [Test]
        public void RankDirection_CanGetAndSet()
        {
            AssertPropertyValid(x => x.RankDirection, RankDirection.BottomToTop);
            AssertPropertyValid(x => x.RankDirection, null);
        }

        [Test]
        public void Compound_CanGetAndSet()
        {
            AssertPropertyValid(x => x.Compound, true);
            AssertPropertyValid(x => x.Compound, false);
        }

        [Test]
        public void RankSeperation_CanGetAndSet()
        {
            AssertPropertyValid(x => x.RankSeperation, new RankSeperation(2.0, true));
            AssertPropertyValid(x => x.RankSeperation, null);
        }

        [Test]
        public void AddCustomAttribute_Adds_Attribute_To_Builder()
        {
            var attribute = MockRepository.GenerateMock<IDotAttribute>();
            var attributeCollection = MockRepository.GenerateMock<IAttributeCollection>();
            
            var graph = new TestGraph();
            graph.GraphBuilder.Expect(x => x.Attributes).Return(attributeCollection);
            attributeCollection.Expect(x => x.AddAttribute(attribute));

            graph.AddCustomAttribute(attribute);

            attributeCollection.VerifyAllExpectations();
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
