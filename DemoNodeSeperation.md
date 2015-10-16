# Description #

A demo of setting the mimimum node seperation.

# Graph #

![http://fluentdot.googlecode.com/svn/wiki/Images/DemoNodeSeperation.png](http://fluentdot.googlecode.com/svn/wiki/Images/DemoNodeSeperation.png)

# Code #

```
            return Fluently.CreateDirectedGraph()
                .Edges.Add(edges =>
                               {
                                   edges.FromNodeWithName("a").ToNodeWithName("b");
                                   edges.FromNodeWithName("a").ToNodeWithName("c");
                                   edges.FromNodeWithName("c").ToNodeWithName("d");
                                   edges.FromNodeWithName("c").ToNodeWithName("e");
                               })
                .WithLabel("Minimum Node Seperation of 2 inches.")
                .WithMinimumNodeSeperation(2);

```

# Dot Produced #

```
digraph "DirectedGraph" {
graph [label="Minimum Node Seperation of 2 inches.", nodesep=2];

"a";
"b";
"c";
"d";
"e";
"a" -> "b";
"a" -> "c";
"c" -> "d";
"c" -> "e";
}
```