/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using FluentDot.Conventions;
using FluentDot.Entities.Edges;
using FluentDot.Entities.Graphs;
using FluentDot.Entities.Nodes;
using FluentDot.Expressions.Conventions;
using NUnit.Framework;
using Rhino.Mocks;

namespace FluentDot.Tests.Expressions.Conventions
{
    [TestFixture]
    public class ConventionCollectionSetupExpressionTests
    {
        #region Tests
        
        [Test]
        public void Add_Should_Create_Instance_And_Add_It_To_The_Tracker() {
            var graph = MockRepository.GenerateMock<IGraph>();
            var expression = new ConventionCollectionSetupExpression(graph);

            var convention1 = new TestNodeConvention();
            var convention2 = new TestEdgeConvention();

            graph.Expect(x => x.AddConvention(convention1)).Repeat.Once();
            graph.Expect(x => x.AddConvention(convention2)).Repeat.Once();

            expression.Add(convention1);
            expression.Add(convention2);
            
            graph.VerifyAllExpectations();
        }

        #endregion

        #region Private Members
        
        private class TestNodeConvention : INodeConvention
        {
            #region INodeConvention Members

            public bool ShouldApply(IGraphNode nodeInfo)
            {
                throw new System.NotImplementedException();
            }

            public void Apply(IGraphNode nodeInfo)
            {
                throw new System.NotImplementedException();
            }

            #endregion
        }

        private class TestEdgeConvention : IEdgeConvention
        {
            #region IEdgeConvention Members

            public bool ShouldApply(IEdge nodeInfo)
            {
                throw new System.NotImplementedException();
            }

            public void Apply(IEdge edgeInfo)
            {
                throw new System.NotImplementedException();
            }

            #endregion
        }

        #endregion
    }
}
