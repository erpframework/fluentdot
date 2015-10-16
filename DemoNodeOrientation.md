# Description #

A demo of the node orientation.

# Graph #

![http://fluentdot.googlecode.com/svn/wiki/Images/DemoNodeOrientation.png](http://fluentdot.googlecode.com/svn/wiki/Images/DemoNodeOrientation.png)

# Code #

```
            var graph = Fluently.CreateDirectedGraph();
            
            graph.Nodes.Add(x => x.WithName("D0").WithOrientation(0));
            
            for (int i = 30; i < 360; i += 30)
            {
                graph.Nodes.Add(x => x.WithName("D" + i).WithOrientation(i).WithShape(NodeShape.Polygon));
                graph.Edges.Add(edge => edge.FromNodeWithName("D" + (i - 30).ToString()).ToNodeWithName("D" + i));
            }
            return graph;

```

# Dot Produced #

```
digraph "DirectedGraph" {
"D0" [orientation=0];
"D30" [orientation=30, shape=polygon];
"D60" [orientation=60, shape=polygon];
"D90" [orientation=90, shape=polygon];
"D120" [orientation=120, shape=polygon];
"D150" [orientation=150, shape=polygon];
"D180" [orientation=180, shape=polygon];
"D210" [orientation=210, shape=polygon];
"D240" [orientation=240, shape=polygon];
"D270" [orientation=270, shape=polygon];
"D300" [orientation=300, shape=polygon];
"D330" [orientation=330, shape=polygon];
"D0" -> "D30";
"D30" -> "D60";
"D60" -> "D90";
"D90" -> "D120";
"D120" -> "D150";
"D150" -> "D180";
"D180" -> "D210";
"D210" -> "D240";
"D240" -> "D270";
"D270" -> "D300";
"D300" -> "D330";
}
```