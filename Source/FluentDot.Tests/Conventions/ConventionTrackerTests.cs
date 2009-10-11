/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System;
using FluentDot.Conventions;
using FluentDot.Entities.Edges;
using FluentDot.Entities.Nodes;
using NUnit.Framework;
using Rhino.Mocks;
using Rhino.Mocks.Constraints;

namespace FluentDot.Tests.Conventions
{
    [TestFixture]
    public class ConventionTrackerTests
    {
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddConvention_Should_Throw_Exception_If_Convention_Is_Null()
        {
            new ConventionTracker().AddConvention((IEdgeConvention)null);
        }

        [Test]
        public void ApplyConventions_Should_Apply_Conventions_To_Nodes()
        {
            var conventionTracker = new ConventionTracker();
            var convention = MockRepository.GenerateMock<INodeConvention>();
            var graphNode = new GraphNode("a");

            convention.Expect(x => x.ShouldApply(graphNode))
                .IgnoreArguments()
                .Constraints(Is.Matching<IGraphNode>(x => x.Name == "a"))
                .Return(true)
                .Repeat.Once();

            convention.Expect(x => x.Apply(graphNode)).Repeat.Once();
            
            conventionTracker.AddConvention(convention);
            conventionTracker.ApplyConventions(graphNode);

            convention.VerifyAllExpectations();
        }

        [Test]
        public void ApplyConventions_Should_Not_Apply_Conventions_To_Nodes_When_Should_Apply_Is_False()
        {
            var conventionTracker = new ConventionTracker();
            var convention = MockRepository.GenerateMock<INodeConvention>();
            var graphNode = new GraphNode("a");

            convention.Expect(x => x.ShouldApply(graphNode))
                .IgnoreArguments()
                .Return(false)
                .Repeat.Once();

            convention.Expect(x => x.Apply(graphNode)).IgnoreArguments().Repeat.Never();
                
            conventionTracker.AddConvention(convention);
            conventionTracker.ApplyConventions(graphNode);

            convention.VerifyAllExpectations();
        }

        [Test]
        public void ApplyConventions_Edge_Should_Apply_Conventions()
        {
            var conventionTracker = new ConventionTracker();
            var convention = MockRepository.GenerateMock<IEdgeConvention>();
            var fromNode = new GraphNode("a");
            var toNode = new GraphNode("b");
            var edge = new DirectedEdge(new NodeTarget(fromNode), new NodeTarget(toNode));

            convention.Expect(x => x.ShouldApply(edge))
                .Return(true)
                .Repeat.Once();

            convention.Expect(x => x.Apply(edge)).Repeat.Once();

            conventionTracker.AddConvention(convention);
            conventionTracker.ApplyConventions(edge);
            convention.VerifyAllExpectations();
        }

        [Test]
        public void ApplyConventions_Edge_Should_Not_Apply_Conventions_When_Should_Apply_Is_False()
        {
            var conventionTracker = new ConventionTracker();
            var convention = MockRepository.GenerateMock<IEdgeConvention>();
            var fromNode = new GraphNode("a");
            var toNode = new GraphNode("b");
            var edge = new DirectedEdge(new NodeTarget(fromNode), new NodeTarget(toNode));

            convention.Expect(x => x.ShouldApply(edge)).Return(false).Repeat.Once();

            convention.Expect(x => x.Apply(edge))
                .IgnoreArguments()
                .Repeat.Never();

            conventionTracker.AddConvention(convention);
            conventionTracker.ApplyConventions(new DirectedEdge(new NodeTarget(fromNode), new NodeTarget(toNode)));
            convention.VerifyAllExpectations();
        }
    }
}
