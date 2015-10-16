# Description #

An illustration of the node and edge coloring functionality in a graph.

# Graph #

![http://fluentdot.googlecode.com/svn/wiki/Images/DemoNodeAndEdgeColors.png](http://fluentdot.googlecode.com/svn/wiki/Images/DemoNodeAndEdgeColors.png)

# Code #

```
            return Fluently.CreateDirectedGraph()
                .Nodes.Add(x =>
                               {
                                   x.WithName("Red").WithColor(Color.Red);
                                   x.WithName("Green").WithColor(Color.Green);
                                   x.WithName("Blue").WithColor(Color.Blue);
                                   x.WithName("Yellow").WithColor(Color.Yellow);
                                   x.WithName("Cyan").WithColor(Color.Cyan);
                                   x.WithName("FilledBrown").WithFillColor(Color.Brown).WithStyle(NodeStyle.Filled);
                                   x.WithName("FilledGoldenRod").WithFillColor(Color.Goldenrod).WithStyle(NodeStyle.Filled);
                               }
                )
                .Edges.Add(x =>
                               {
                                   x.FromNodeWithName("Red").ToNodeWithName("Green").WithColor(Color.Coral).WithLabel("Coral");
                                   x.FromNodeWithName("Red").ToNodeWithName("Blue").WithColor(Color.DarkOrange).WithLabel("DarkOrange");
                                   x.FromNodeWithName("Blue").ToNodeWithName("Yellow").WithColor(Color.DeepSkyBlue).WithLabel("DeepSkyBlue");
                                   x.FromNodeWithName("Blue").ToNodeWithName("Cyan").WithColor(Color.Chocolate).WithLabel("Chocolate");
                                   x.FromNodeWithName("Cyan").ToNodeWithName("FilledBrown").WithColor(Color.Purple).WithLabel("Purple");
                                   x.FromNodeWithName("Cyan").ToNodeWithName("FilledGoldenRod").WithColor(Color.HotPink).WithLabel("HotPink");
                               }
                );

```

# Dot Produced #

```
digraph "DirectedGraph" {
"Red" [color="#ff0000"];
"Green" [color="#008000"];
"Blue" [color="#0000ff"];
"Yellow" [color="#ffff00"];
"Cyan" [color="#00ffff"];
"FilledBrown" [fillcolor="#a52a2a", style="filled"];
"FilledGoldenRod" [fillcolor="#daa520", style="filled"];
"Red" -> "Green" [color="#ff7f50", label="Coral"];
"Red" -> "Blue" [color="#ff8c00", label="DarkOrange"];
"Blue" -> "Yellow" [color="#00bfff", label="DeepSkyBlue"];
"Blue" -> "Cyan" [color="#d2691e", label="Chocolate"];
"Cyan" -> "FilledBrown" [color="#800080", label="Purple"];
"Cyan" -> "FilledGoldenRod" [color="#ff69b4", label="HotPink"];
}
```