# Description #

A demo of the different head port options available.

# Graph #

![http://fluentdot.googlecode.com/svn/wiki/Images/DemoHeadPorts.png](http://fluentdot.googlecode.com/svn/wiki/Images/DemoHeadPorts.png)

# Code #

```
            return Fluently.CreateDirectedGraph()
                .Edges.Add(edges =>
                {
                    edges.FromNodeWithName("a").ToNodeWithName("b").WithHeadPort(CompassPoint.North).WithLabel("North");
                    edges.FromNodeWithName("a").ToNodeWithName("c").WithHeadPort(CompassPoint.NorthEast).WithLabel("NorthEast");
                    edges.FromNodeWithName("a").ToNodeWithName("d").WithHeadPort(CompassPoint.East).WithLabel("East");
                    edges.FromNodeWithName("a").ToNodeWithName("e").WithHeadPort(CompassPoint.SouthEast).WithLabel("SouthEast");
                    edges.FromNodeWithName("a").ToNodeWithName("f").WithHeadPort(CompassPoint.South).WithLabel("South");
                    edges.FromNodeWithName("a").ToNodeWithName("g").WithHeadPort(CompassPoint.SouthWest).WithLabel("SouthWest");
                    edges.FromNodeWithName("a").ToNodeWithName("h").WithHeadPort(CompassPoint.West).WithLabel("West");
                    edges.FromNodeWithName("a").ToNodeWithName("i").WithHeadPort(CompassPoint.NorthWest).WithLabel("NorthWest");
                    edges.FromNodeWithName("a").ToNodeWithName("j").WithHeadPort(CompassPoint.Appropriate).WithLabel("Appropriate");
                    edges.FromNodeWithName("a").ToNodeWithName("k").WithHeadPort(CompassPoint.Center).WithLabel("Center");
                })
                .WithLabel("Head Ports - Labels on edges specify the head port used.");

```

# Dot Produced #

```
digraph "DirectedGraph" {
graph [label="Head Ports - Labels on edges specify the head port used."];

"a";
"b";
"c";
"d";
"e";
"f";
"g";
"h";
"i";
"j";
"k";
"a" -> "b" [headport="n", label="North"];
"a" -> "c" [headport="ne", label="NorthEast"];
"a" -> "d" [headport="e", label="East"];
"a" -> "e" [headport="se", label="SouthEast"];
"a" -> "f" [headport="s", label="South"];
"a" -> "g" [headport="sw", label="SouthWest"];
"a" -> "h" [headport="w", label="West"];
"a" -> "i" [headport="nw", label="NorthWest"];
"a" -> "j" [headport="_", label="Appropriate"];
"a" -> "k" [headport="c", label="Center"];
}
```