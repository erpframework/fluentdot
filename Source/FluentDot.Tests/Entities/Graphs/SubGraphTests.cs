/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System;
using System.Linq.Expressions;
using FluentDot.Attributes.Graphs;
using FluentDot.Builders.Graphs;
using FluentDot.Entities.Edges;
using FluentDot.Entities.Graphs;
using FluentDot.Entities.Nodes;
using FluentDot.Tests.Util;
using NUnit.Framework;
using Rhino.Mocks;

namespace FluentDot.Tests.Entities.Graphs
{
    [TestFixture]
    public class SubGraphTests {
        
        #region Tests

        [Test]
        public void Constructor_Saves_Graph_Type()
        {
            var graph = new TestGraph();
            var edgeTracker = MockRepository.GenerateMock<IEdgeTracker>();
            var nodeTracker = MockRepository.GenerateMock<INodeTracker>();

            graph.Builder.Expect(x => x.EdgeLookup).Return(edgeTracker).Repeat.AtLeastOnce();
            graph.Builder.Expect(x => x.NodeLookup).Return(nodeTracker).Repeat.AtLeastOnce();
            
            Assert.AreEqual(new SubGraph(graph).Type, GraphType.Directed);
        }

        [Test]
        public void Rank_CanGetAndSet()
        {
            AssertPropertyValid(x => x.Rank, RankType.Same);
            AssertPropertyValid(x => x.Rank, null);
        }

        #endregion

        #region Private Members

        private static void AssertPropertyValid<T>(Expression<Func<ISubGraph, T>> propertyExpression, T testValue) {
            AssertPropertyValid(propertyExpression, null, testValue);
        }

        private static void AssertPropertyValid<T>(Expression<Func<ISubGraph, T>> propertyExpression, object defaultValue, T testValue) {
            var testGraph = new TestGraph(new GraphBuilder("aa"));
            PropertyTester.AssertPropertyValid(testGraph.AddSubGraph(), propertyExpression, defaultValue, testValue);
        }

        private class TestGraph : AbstractGraph {

            public TestGraph()
                : this(MockRepository.GenerateMock<IGraphBuilder>()) {

            }

            public TestGraph(IGraphBuilder builder)
                : base(builder) {
                
            }
            
            public override GraphType Type {
                get { return GraphType.Directed; }
            }
        }

        #endregion
    }
}