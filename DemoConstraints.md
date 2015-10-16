# Description #

A demo of not applying constraints to edges.

# Graph #

![http://fluentdot.googlecode.com/svn/wiki/Images/DemoConstraints.png](http://fluentdot.googlecode.com/svn/wiki/Images/DemoConstraints.png)

# Code #

```
            return Fluently.CreateDirectedGraph()
                .Edges.Add(edges =>
                               {
                                   edges.FromNodeWithName("a").ToNodeWithName("b");
                                   edges.FromNodeWithName("a").ToNodeWithName("c");
                                   edges.FromNodeWithName("b").ToNodeWithName("c").DoNotConstrainNodes().WithLabel("Not Constrained");
                                   edges.FromNodeWithName("c").ToNodeWithName("d").DoNotConstrainNodes().WithLabel("Not Constrained");
                                   edges.FromNodeWithName("b").ToNodeWithName("e");
                                   edges.FromNodeWithName("e").ToNodeWithName("f").WithMinimumLength(2).WithLabel("Minimum Length : 2");
                                   edges.FromNodeWithName("e").ToNodeWithName("g").WithMinimumLength(3).WithLabel("Minimum Length : 3");
                                   edges.FromNodeWithName("g").ToNodeWithName("h").DoNotConstrainNodes().WithLabel("Not Constrained");
                               }
                );

```

# Dot Produced #

```
digraph "DirectedGraph" {
"a";
"b";
"c";
"d";
"e";
"f";
"g";
"h";
"a" -> "b";
"a" -> "c";
"b" -> "c" [constraint=false, label="Not Constrained"];
"c" -> "d" [constraint=false, label="Not Constrained"];
"b" -> "e";
"e" -> "f" [minlen=2, label="Minimum Length : 2"];
"e" -> "g" [minlen=3, label="Minimum Length : 3"];
"g" -> "h" [constraint=false, label="Not Constrained"];
}
```