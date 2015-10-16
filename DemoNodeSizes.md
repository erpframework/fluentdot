# Description #

A demo of the different node sizing properties that DOT provides.

# Graph #

![http://fluentdot.googlecode.com/svn/wiki/Images/DemoNodeSizes.png](http://fluentdot.googlecode.com/svn/wiki/Images/DemoNodeSizes.png)

# Code #

```
            return Fluently.CreateDirectedGraph()
                .Nodes.Add(nodes =>
                               {
                                   nodes.WithName("TinyHeight_Expanded").WithHeight(0.1).WithWidth(1.5);
                                   nodes.WithName("TinyWidth_Expanded").WithHeight(1.5).WithWidth(0.1);
                                   nodes.WithName("Fixed_Size1").WithHeight(0.5).WithWidth(0.5).IsFixedSize();
                                   nodes.WithName("Fixed_Size2").WithHeight(0.5).WithWidth(0.5).IsFixedSize();
                               })
                .Edges.Add(edges =>
                               {
                                   edges.FromNodeWithName("TinyHeight_Expanded").ToNodeWithName("TinyWidth_Expanded");
                                   edges.FromNodeWithName("TinyHeight_Expanded").ToNodeWithName("Fixed_Size1");
                                   edges.FromNodeWithName("TinyWidth_Expanded").ToNodeWithName("Fixed_Size1");
                                   edges.FromNodeWithName("Fixed_Size1").ToNodeWithName("Fixed_Size2");
                               });

```

# Dot Produced #

```
digraph "DirectedGraph" {
"TinyHeight_Expanded" [height=0.1, width=1.5];
"TinyWidth_Expanded" [height=1.5, width=0.1];
"Fixed_Size1" [height=0.5, width=0.5, fixedsize=true];
"Fixed_Size2" [height=0.5, width=0.5, fixedsize=true];
"TinyHeight_Expanded" -> "TinyWidth_Expanded";
"TinyHeight_Expanded" -> "Fixed_Size1";
"TinyWidth_Expanded" -> "Fixed_Size1";
"Fixed_Size1" -> "Fixed_Size2";
}
```