# Description #

A demo of how disabling of the edge head and tail clipping affects the rendered graph.

# Graph #

![http://fluentdot.googlecode.com/svn/wiki/Images/DemoEdgeClipping.png](http://fluentdot.googlecode.com/svn/wiki/Images/DemoEdgeClipping.png)

# Code #

```
            return Fluently.CreateDirectedGraph()
                .TheDefaults.ForEdges.Are(x =>
                                              {
                                                  x.DoNotClipTail();
                                                  x.DoNotClipHead();
                                              }
                )
                .Edges.Add(edges =>
                {
                    edges.FromNodeWithName("a").ToNodeWithName("b");
                    edges.FromNodeWithName("a").ToNodeWithName("c");
                    edges.FromNodeWithName("b").ToNodeWithName("c");
                    edges.FromNodeWithName("c").ToNodeWithName("d");
                    edges.FromNodeWithName("b").ToNodeWithName("e");
                    edges.FromNodeWithName("e").ToNodeWithName("f");
                    edges.FromNodeWithName("e").ToNodeWithName("g");
                }
                )
                .WithMinimumNodeSeperation(2);

```

# Dot Produced #

```
digraph "DirectedGraph" {
graph [nodesep=2];

edge [tailclip="false", headclip="false"];
"a";
"b";
"c";
"d";
"e";
"f";
"g";
"a" -> "b";
"a" -> "c";
"b" -> "c";
"c" -> "d";
"b" -> "e";
"e" -> "f";
"e" -> "g";
}
```