/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System;
using System.Drawing;
using System.Linq.Expressions;
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
    public class ClusterTests {

        #region Tests

        [Test]
        public void Constructor_Saves_Graph_Type()
        {
            var edgeTracker = MockRepository.GenerateMock<IEdgeTracker>();
            var nodeTracker = MockRepository.GenerateMock<INodeTracker>();

            var cluster = new TestCluster();
            cluster.Builder.Expect(x => x.EdgeLookup).Return(edgeTracker).Repeat.AtLeastOnce();
            cluster.Builder.Expect(x => x.NodeLookup).Return(nodeTracker).Repeat.AtLeastOnce();
            Assert.AreEqual(cluster.Type, GraphType.Directed);
        }
       

        [Test]
        public void Name_Should_Prepend_Cluster_To_Given_Name()
        {
            Assert.IsTrue(new TestCluster().Name.StartsWith("cluster"));
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Name_Should_Throw_For_Null()
        {
            new TestCluster().Name = null;
        }

        [Test]
        public void BackgroundColor_CanGetAndSet()
        {
            AssertPropertyValid(x => x.BackgroundColor, Color.Aqua);
            AssertPropertyValid(x => x.BackgroundColor, null);
        }

        #endregion

        #region Private Members

        private static void AssertPropertyValid<T>(Expression<Func<ICluster, T>> propertyExpression, T testValue) {
            AssertPropertyValid(propertyExpression, null, testValue);
        }

        private static void AssertPropertyValid<T>(Expression<Func<ICluster, T>> propertyExpression, object defaultValue, T testValue) {
            var testGraph = new TestCluster(new GraphBuilder("aa"));
            PropertyTester.AssertPropertyValid(testGraph, propertyExpression, defaultValue, testValue);
        }

        private class TestCluster : Cluster {

            public TestCluster() : this(MockRepository.GenerateMock<IGraphBuilder>())
            {

            }

            public TestCluster(IGraphBuilder builder)
                : base(new DirectedGraph(builder)) {
                
            }
            
            public override GraphType Type {
                get { return GraphType.Directed; }
            }
        }

        #endregion
    }
}