# Description #

Demo of the different arrow directions that dot supports.

# Graph #

![http://fluentdot.googlecode.com/svn/wiki/Images/DemoArrowDirections.png](http://fluentdot.googlecode.com/svn/wiki/Images/DemoArrowDirections.png)

# Code #

```
            return Fluently.CreateDirectedGraph()
                .Edges.Add(edges =>
                               {
                                   edges.FromNodeWithName("a").ToNodeWithName("b")
                                       .WithArrowDirection(ArrowDirection.Back)
                                       .WithLabel("Back");
                                   edges.FromNodeWithName("c").ToNodeWithName("d")
                                       .WithArrowDirection(ArrowDirection.Both)
                                       .WithLabel("Both");
                                   edges.FromNodeWithName("e").ToNodeWithName("f")
                                       .WithArrowDirection(ArrowDirection.Forward)
                                       .WithLabel("Forward");
                                   edges.FromNodeWithName("g").ToNodeWithName("h")
                                       .WithArrowDirection(ArrowDirection.None)
                                       .WithLabel("None");
                               });

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
"a" -> "b" [dir="back", label="Back"];
"c" -> "d" [dir="both", label="Both"];
"e" -> "f" [dir="forward", label="Forward"];
"g" -> "h" [dir="none", label="None"];
}
```