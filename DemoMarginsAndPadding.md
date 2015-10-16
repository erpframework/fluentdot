# Description #

A demo of graph and node margins and padding.

# Graph #

![http://fluentdot.googlecode.com/svn/wiki/Images/DemoMarginsAndPadding.png](http://fluentdot.googlecode.com/svn/wiki/Images/DemoMarginsAndPadding.png)

# Code #

```
            return Fluently.CreateDirectedGraph()
                .Nodes.Add(nodes =>
                               {
                                   nodes.WithName("b").WithLabelMargin(0.5f, 0.5f).WithLabel("0.5 Point Margin");
                                   nodes.WithName("e").WithLabelMargin(1, 1).WithLabel("1 Point Margin");
                                   nodes.WithName("g").WithLabelMargin(2, 2).WithLabel("2 Point Margin");
                               })
                .Edges.Add(edges =>
                               {
                                   edges.FromNodeWithName("a").ToNodeWithName("b");
                                   edges.FromNodeWithName("a").ToNodeWithName("c");
                                   edges.FromNodeWithName("b").ToNodeWithName("c");
                                   edges.FromNodeWithName("c").ToNodeWithName("e");
                                   edges.FromNodeWithName("e").ToNodeWithName("f");
                                   edges.FromNodeWithName("e").ToNodeWithName("g");
                               })
                .WithBackgroundColor(Color.Gainsboro)
                .WithLabel("2 Point Graph Margin, 1 Inch Margin Around Graph")
                .WithMargin(2, 2)
                .WithPadding(1, 1);

```

# Dot Produced #

```
digraph "DirectedGraph" {
graph [bgcolor="#dcdcdc", label="2 Point Graph Margin, 1 Inch Margin Around Graph", margin="2.00,2.00", pad=1.00,1.00];

"b" [margin="0.50,0.50", label="0.5 Point Margin"];
"e" [margin="1.00,1.00", label="1 Point Margin"];
"g" [margin="2.00,2.00", label="2 Point Margin"];
"a";
"c";
"f";
"a" -> "b";
"a" -> "c";
"b" -> "c";
"c" -> "e";
"e" -> "f";
"e" -> "g";
}
```