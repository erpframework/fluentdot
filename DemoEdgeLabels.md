# Description #

A demo of applying different parameters to edge head and tail labels.

# Graph #

![http://fluentdot.googlecode.com/svn/wiki/Images/DemoEdgeLabels.png](http://fluentdot.googlecode.com/svn/wiki/Images/DemoEdgeLabels.png)

# Code #

```
            return Fluently.CreateDirectedGraph()
                .Edges.Add(edges =>
                               {
                                   edges.FromNodeWithName("a").ToNodeWithName("b").WithLabelAngle(100).WithTailLabel("Angle : 100");
                                   edges.FromNodeWithName("a").ToNodeWithName("c").WithLabelAngle(-100).WithHeadLabel("Angle : -100");
                                   edges.FromNodeWithName("b").ToNodeWithName("c").FloatLabel().WithLabel("Floating Label");
                                   edges.FromNodeWithName("c").ToNodeWithName("d").WithLabelDistance(5).WithHeadLabel("Distance : 50");
                                   edges.FromNodeWithName("b").ToNodeWithName("e").WithLabelDistance(0.5).WithTailLabel("Distance : 0.5");
                                   edges.FromNodeWithName("e").ToNodeWithName("f").WithLabelFontColor(Color.Blue).WithLabelFontSize(28).WithLabelFontName("Times-Roman").WithHeadLabel("Blue Times-Roman 28 Point");
                                   edges.FromNodeWithName("e").ToNodeWithName("g").FloatLabel().WithLabel("Floating Label");
                                   edges.FromNodeWithName("g").ToNodeWithName("h").WithLabelFontColor(Color.Red).WithLabelFontSize(7).WithLabelFontName("Helvetica").WithTailLabel("Red Helvetica 14 Point");
                                   edges.FromNodeWithName("g").ToNodeWithName("i").Decorate().WithLabel("Decorated Label");
                                   edges.FromNodeWithName("e").ToNodeWithName("j").Decorate().WithLabel("Decorated Label");
                               }
                )
                .WithMinimumNodeSeperation(2);

```

# Dot Produced #

```
digraph "DirectedGraph" {
graph [nodesep=2];

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
"a" -> "b" [labelangle=100, taillabel="Angle : 100"];
"a" -> "c" [labelangle=-100, headlabel="Angle : -100"];
"b" -> "c" [labelfloat="true", label="Floating Label"];
"c" -> "d" [labeldistance=5, headlabel="Distance : 50"];
"b" -> "e" [labeldistance=0.5, taillabel="Distance : 0.5"];
"e" -> "f" [labelfontcolor="#0000ff", labelfontsize=28, labelfontname="Times-Roman", headlabel="Blue Times-Roman 28 Point"];
"e" -> "g" [labelfloat="true", label="Floating Label"];
"g" -> "h" [labelfontcolor="#ff0000", labelfontsize=7, labelfontname="Helvetica", taillabel="Red Helvetica 14 Point"];
"g" -> "i" [decorate=true, label="Decorated Label"];
"e" -> "j" [decorate=true, label="Decorated Label"];
}
```