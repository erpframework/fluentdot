# Description #

A demo of how dot can rotate a graph.

# Graph #

![http://fluentdot.googlecode.com/svn/wiki/Images/DemoLandscapeGraph.png](http://fluentdot.googlecode.com/svn/wiki/Images/DemoLandscapeGraph.png)

# Code #

```
            return Fluently.CreateDirectedGraph()
                .Edges.Add(edges =>
                               {
                                   edges.FromNodeWithName("a").ToNodeWithName("b");
                                   edges.FromNodeWithName("a").ToNodeWithName("c");
                                   edges.FromNodeWithName("a").ToNodeWithName("d");
                                   edges.FromNodeWithName("b").ToNodeWithName("c");
                                   edges.FromNodeWithName("b").ToNodeWithName("d");
                                   edges.FromNodeWithName("c").ToNodeWithName("d");
                               })
                .WithLabel("Landscape Graph")
                .RenderLandscape();

```

# Dot Produced #

```
digraph "DirectedGraph" {
graph [label="Landscape Graph", rotate=90];

"a";
"b";
"c";
"d";
"a" -> "b";
"a" -> "c";
"a" -> "d";
"b" -> "c";
"b" -> "d";
"c" -> "d";
}
```