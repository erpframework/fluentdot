using System;
using System.Linq.Expressions;
using FluentDot.Attributes;
using FluentDot.Builders.Graphs;
using FluentDot.Tests.Util;
using NUnit.Framework;
using FluentDot.Entities.Graphs;
using Rhino.Mocks;

namespace FluentDot.Tests.Entities.Graphs {
    
    [TestFixture]
    public class AbstractGraphContainerTests {

        #region Tests

        [Test]
        public void ToDot_Should_Call_Builders_ToDot() {
            var graph = new TestGraph();
            graph.GraphBuilder.Expect(x => x.ToDot()).Return("SampleDot");

            var result = graph.ToDot();

            graph.GraphBuilder.VerifyAllExpectations();
            Assert.AreEqual(result, "SampleDot");
        }

        [Test]
        public void AddCustomAttribute_Adds_Attribute_To_Builder() {
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

        private static void AssertPropertyValid<T>(Expression<Func<IGraphContainer, T>> propertyExpression, T testValue) {
            AssertPropertyValid(propertyExpression, null, testValue);
        }

        private static void AssertPropertyValid<T>(Expression<Func<IGraphContainer, T>> propertyExpression, object defaultValue, T testValue) {
            var testGraph = new TestGraph(new GraphBuilder("aa"));
            PropertyTester.AssertPropertyValid(testGraph, propertyExpression, defaultValue, testValue);
        }

        private class TestGraph : AbstractGraphContainer {

            public TestGraph()
                : this(MockRepository.GenerateMock<IGraphBuilder>()) {

            }

            public TestGraph(IGraphBuilder builder)
                : base(builder) {
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
