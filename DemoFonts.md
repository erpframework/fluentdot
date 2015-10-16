# Description #

A demo of the different font styles that DOT provides.

# Graph #

![http://fluentdot.googlecode.com/svn/wiki/Images/DemoFonts.png](http://fluentdot.googlecode.com/svn/wiki/Images/DemoFonts.png)

# Code #

```
            return Fluently.CreateDirectedGraph()
                .WithLabel("Courier Purple SizedUp Graph Label")
                .WithFontColor(Color.Purple)
                .WithFontSize(28)
                .WithFontName("Courier")
                .Nodes.Add(nodes =>
                               {
                                   nodes.WithName("RedFont").WithFontColor(Color.Red);
                                   nodes.WithName("BlueFont").WithFontColor(Color.Blue);
                                   nodes.WithName("SizeUp").WithFontSize(28.0);
                                   nodes.WithName("SizeDown").WithFontSize(7.0);
                                   nodes.WithName("TimesRoman").WithFontName("Times-Roman");
                                   nodes.WithName("Helvetica").WithFontName("Helvetica");
                                   nodes.WithName("Courier").WithFontName("Courier");
                               })
                .Edges.Add(edges =>
                               {
                                   edges.FromNodeWithName("RedFont").ToNodeWithName("BlueFont").WithFontColor(Color.Brown).WithLabel("BrownFont");
                                   edges.FromNodeWithName("RedFont").ToNodeWithName("SizeUp").WithFontColor(Color.HotPink).WithLabel("HotPink");
                                   edges.FromNodeWithName("BlueFont").ToNodeWithName("SizeUp");
                                   edges.FromNodeWithName("SizeUp").ToNodeWithName("SizeDown");
                                   edges.FromNodeWithName("BlueFont").ToNodeWithName("NormalSize").WithFontSize(28.0).WithLabel("SizeUp");
                                   edges.FromNodeWithName("NormalSize").ToNodeWithName("TimesRoman").WithFontSize(7.0).WithLabel("SizeDown");
                                   edges.FromNodeWithName("NormalSize").ToNodeWithName("Helvetica").WithFontName("Times-Roman").WithLabel("Times-Roman");
                                   edges.FromNodeWithName("Helvetica").ToNodeWithName("Courier").WithFontName("Helvetica").WithLabel("Helvetica");
                               });

```

# Dot Produced #

```
digraph "DirectedGraph" {
graph [label="Courier Purple SizedUp Graph Label", fontcolor="#800080", fontsize=28, fontname="Courier"];

"RedFont" [fontcolor="#ff0000"];
"BlueFont" [fontcolor="#0000ff"];
"SizeUp" [fontsize=28];
"SizeDown" [fontsize=7];
"TimesRoman" [fontname="Times-Roman"];
"Helvetica" [fontname="Helvetica"];
"Courier" [fontname="Courier"];
"NormalSize";
"RedFont" -> "BlueFont" [fontcolor="#a52a2a", label="BrownFont"];
"RedFont" -> "SizeUp" [fontcolor="#ff69b4", label="HotPink"];
"BlueFont" -> "SizeUp";
"SizeUp" -> "SizeDown";
"BlueFont" -> "NormalSize" [fontsize=28, label="SizeUp"];
"NormalSize" -> "TimesRoman" [fontsize=7, label="SizeDown"];
"NormalSize" -> "Helvetica" [fontname="Times-Roman", label="Times-Roman"];
"Helvetica" -> "Courier" [fontname="Helvetica", label="Helvetica"];
}
```