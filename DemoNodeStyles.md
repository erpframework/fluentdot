# Description #

A demo of the different node styles that DOT provides.

# Graph #

![http://fluentdot.googlecode.com/svn/wiki/Images/DemoNodeStyles.png](http://fluentdot.googlecode.com/svn/wiki/Images/DemoNodeStyles.png)

# Code #

```
            var graph = Fluently.CreateDirectedGraph();
            int a = 1;
            int b = 2;
            foreach (var item in typeof(NodeStyle).GetFields(BindingFlags.Public | BindingFlags.Static).Where(x => typeof(NodeStyle).IsAssignableFrom(x.FieldType))) {
                var style = (NodeStyle)item.GetValue(null);
                graph.Nodes.Add(
                    x =>
                        {
                            x.WithName(a.ToString()).WithStyle(style);
                            x.WithName(b.ToString()).WithStyle(style);
                        })
                    .Edges.Add(
                    x => x.FromNodeWithName(a.ToString()).ToNodeWithName(b.ToString()).WithLabel(item.Name));
                a += 2;
                b += 2;
            }
            return graph;

```

# Dot Produced #

```
digraph "DirectedGraph" {
"1" [style="dashed"];
"2" [style="dashed"];
"3" [style="dotted"];
"4" [style="dotted"];
"5" [style="solid"];
"6" [style="solid"];
"7" [style="invis"];
"8" [style="invis"];
"9" [style="bold"];
"10" [style="bold"];
"11" [style="filled"];
"12" [style="filled"];
"13" [style="diagonals"];
"14" [style="diagonals"];
"15" [style="rounded"];
"16" [style="rounded"];
"1" -> "2" [label="Dashed"];
"3" -> "4" [label="Dotted"];
"5" -> "6" [label="Solid"];
"7" -> "8" [label="Invisible"];
"9" -> "10" [label="Bold"];
"11" -> "12" [label="Filled"];
"13" -> "14" [label="Diagonals"];
"15" -> "16" [label="Rounded"];
}
```