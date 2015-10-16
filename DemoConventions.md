# Description #

An illustration of how conventions can simplify decision making in graph formatting.

# Graph #

![http://fluentdot.googlecode.com/svn/wiki/Images/DemoConventions.png](http://fluentdot.googlecode.com/svn/wiki/Images/DemoConventions.png)

# Code #

```
            return Fluently.CreateDirectedGraph()
                .Conventions.Setup(x => {
                                            x.AddType<EvenNodeColouringConvention>();
                                            x.AddType<OddNodeColouringConvention>();
                                            x.AddType<NodeTagLabelConvention>();
                                            x.AddType<EvenToOddEdgeConvention>();
                                            x.AddType<OddToEvenEdgeConvention>();
                })
                .Nodes.Add(x =>
                               {
                                   x.WithName("a").WithTag(1);
                                   x.WithName("b").WithTag(2);
                                   x.WithName("c").WithTag(3);
                                   x.WithName("d").WithTag(4);
                                   x.WithName("e").WithTag(5);
                               })
                .Edges.Add(x =>
                               {
                                   x.FromNodeWithName("a").ToNodeWithName("b");
                                   x.FromNodeWithName("a").ToNodeWithName("c");
                                   x.FromNodeWithName("c").ToNodeWithName("d").WithLabel("Label Override");
                                   x.FromNodeWithName("b").ToNodeWithName("d");
                                   x.FromNodeWithName("d").ToNodeWithName("e");
                               })
                .WithLabel(@"Conventions\nEven and odd numbered nodes are coloured differently\nEven to odd and odd to even edges are marked\nThe labels of all nodes are the tags of the nodes");

```

# Dot Produced #

```
digraph "DirectedGraph" {
graph [label="Conventions\nEven and odd numbered nodes are coloured differently\nEven to odd and odd to even edges are marked\nThe labels of all nodes are the tags of the nodes"];

"a" [fillcolor="#b0c4de", style="filled", label="1"];
"b" [fillcolor="#dcdcdc", style="filled", label="2"];
"c" [fillcolor="#b0c4de", style="filled", label="3"];
"d" [fillcolor="#dcdcdc", style="filled", label="4"];
"e" [fillcolor="#b0c4de", style="filled", label="5"];
"a" -> "b" [label="Odd to Even", color="#0000ff"];
"a" -> "c";
"c" -> "d" [label="Label Override", color="#0000ff"];
"b" -> "d";
"d" -> "e" [label="Even to Odd", color="#ff0000"];
}
```