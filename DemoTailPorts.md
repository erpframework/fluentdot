# Description #

A demo of the different tail port options available.

# Graph #

![http://fluentdot.googlecode.com/svn/wiki/Images/DemoTailPorts.png](http://fluentdot.googlecode.com/svn/wiki/Images/DemoTailPorts.png)

# Code #

```
            return Fluently.CreateDirectedGraph()
                .Edges.Add(edges =>
                {
                    edges.FromNodeWithName("a").ToNodeWithName("b").WithTailPort(CompassPoint.North).WithLabel("North");
                    edges.FromNodeWithName("a").ToNodeWithName("c").WithTailPort(CompassPoint.NorthEast).WithLabel("NorthEast");
                    edges.FromNodeWithName("a").ToNodeWithName("d").WithTailPort(CompassPoint.East).WithLabel("East");
                    edges.FromNodeWithName("a").ToNodeWithName("e").WithTailPort(CompassPoint.SouthEast).WithLabel("SouthEast");
                    edges.FromNodeWithName("a").ToNodeWithName("f").WithTailPort(CompassPoint.South).WithLabel("South");
                    edges.FromNodeWithName("a").ToNodeWithName("g").WithTailPort(CompassPoint.SouthWest).WithLabel("SouthWest");
                    edges.FromNodeWithName("a").ToNodeWithName("h").WithTailPort(CompassPoint.West).WithLabel("West");
                    edges.FromNodeWithName("a").ToNodeWithName("i").WithTailPort(CompassPoint.NorthWest).WithLabel("NorthWest");
                    edges.FromNodeWithName("a").ToNodeWithName("j").WithTailPort(CompassPoint.Appropriate).WithLabel("Appropriate");
                    edges.FromNodeWithName("a").ToNodeWithName("k").WithTailPort(CompassPoint.Center).WithLabel("Center");
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
"a" -> "b" [tailport="n", label="North"];
"a" -> "c" [tailport="ne", label="NorthEast"];
"a" -> "d" [tailport="e", label="East"];
"a" -> "e" [tailport="se", label="SouthEast"];
"a" -> "f" [tailport="s", label="South"];
"a" -> "g" [tailport="sw", label="SouthWest"];
"a" -> "h" [tailport="w", label="West"];
"a" -> "i" [tailport="nw", label="NorthWest"];
"a" -> "j" [tailport="_", label="Appropriate"];
"a" -> "k" [tailport="c", label="Center"];
}
```