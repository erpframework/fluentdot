/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System;
using System.Drawing;
using System.Linq.Expressions;
using FluentDot.Attributes.Graphs;
using FluentDot.Attributes.Shared;
using FluentDot.Builders.Graphs;
using FluentDot.Conventions;
using FluentDot.Entities.Graphs;
using FluentDot.Tests.Util;
using NUnit.Framework;
using Rhino.Mocks;
using Rhino.Mocks.Constraints;

namespace FluentDot.Tests.Entities.Graphs {

    [TestFixture]
    public class AbstractGraphTests {

        #region Tests

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
        public void AddConvention_Adds_Convention_To_Builder()
        {
            var conventionTracker = MockRepository.GenerateMock<IConventionTracker>();
            var convention = MockRepository.GenerateMock<IEdgeConvention>();

            var graph = new TestGraph();
            graph.Builder.Expect(x => x.Conventions).Return(conventionTracker);
            conventionTracker.Expect(x => x.AddConvention(convention));

            graph.AddConvention(convention);

            conventionTracker.VerifyAllExpectations();
        }

        [Test]
        public void AddSubGraph_Should_Create_And_Add_SubGraph()
        {
            var graph = new TestGraph();
            var subgraphTracker = MockRepository.GenerateMock<ISubGraphTracker>();

            graph.Builder.Expect(x => x.SubGraphLookup).Return(subgraphTracker);
            subgraphTracker.Expect(x => x.AddSubGraph(null)).Constraints(Is.NotNull());

            ISubGraph subgraph = graph.AddSubGraph();
            Assert.IsNotNull(subgraph);
            Assert.AreSame(subgraph.Parent, graph);
        }

        [Test]
        public void AddCluster_Should_Create_And_Add_Cluster()
        {
            var graph = new TestGraph();
            var subgraphTracker = MockRepository.GenerateMock<ISubGraphTracker>();

            graph.Builder.Expect(x => x.SubGraphLookup).Return(subgraphTracker);
            subgraphTracker.Expect(x => x.AddSubGraph(null)).Constraints(Is.NotNull());

            ICluster cluster = graph.AddCluster();
            Assert.IsNotNull(cluster);
            Assert.AreSame(cluster.Parent, graph);
        }

        #endregion

        #region Private Members

        private static void AssertPropertyValid<T>(Expression<Func<IGraph, T>> propertyExpression, T testValue)
        {
            AssertPropertyValid(propertyExpression, null, testValue);
        }

        private static void AssertPropertyValid<T>(Expression<Func<IGraph, T>> propertyExpression, object defaultValue, T testValue)
        {
            var testGraph = new TestGraph(new GraphBuilder("aa"));
            PropertyTester.AssertPropertyValid(testGraph, propertyExpression, defaultValue, testValue);
        }

        private class TestGraph : AbstractGraph {

            public TestGraph() : this(MockRepository.GenerateMock<IGraphBuilder>())
            {
               
            }

            public TestGraph(IGraphBuilder builder)  : base(builder) {
                
            }
            
            public override GraphType Type {
                get { return GraphType.Directed; }
            }
        }

        #endregion
    }
}
