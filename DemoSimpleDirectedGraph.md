# Description #

An illustration of a simple directed graph.

# Graph #

![http://fluentdot.googlecode.com/svn/wiki/Images/DemoSimpleDirectedGraph.png](http://fluentdot.googlecode.com/svn/wiki/Images/DemoSimpleDirectedGraph.png)

# Code #

```
            return Fluently.CreateDirectedGraph()
                .Edges.Add(x =>
                               {
                                   x.FromNodeWithName("A").ToNodeWithName("B");
                                   x.FromNodeWithName("A").ToNodeWithName("C");
                                   x.FromNodeWithName("B").ToNodeWithName("C");
                                   x.FromNodeWithName("B").ToNodeWithName("D");
                               }
                );

```

# Dot Produced #

```
digraph "DirectedGraph" {
"A";
"B";
"C";
"D";
"A" -> "B";
"A" -> "C";
"B" -> "C";
"B" -> "D";
}
```