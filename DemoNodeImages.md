# Description #

A demo of how nodes can contain images.

# Graph #

![http://fluentdot.googlecode.com/svn/wiki/Images/DemoNodeImages.png](http://fluentdot.googlecode.com/svn/wiki/Images/DemoNodeImages.png)

# Code #

```
            return Fluently.CreateDirectedGraph()
                .Nodes.Add(nodes =>
                               {
                                   nodes.WithName("a").ContainsImage(fullMoon);
                                   nodes.WithName("b").ContainsImage(science);
                                   nodes.WithName("c").ContainsImage(fullMoon).WithHeight(1.5).WithWidth(1.5);
                                   nodes.WithName("d").ContainsImage(science);
                                   nodes.WithName("e").ContainsScaledImage(fullMoon).WithHeight(1.5).WithWidth(1.5).WithLabel("Scaled Image");
                                   nodes.WithName("f").ContainsScaledImage(science).WithHeight(1.8).WithWidth(1.5).WithLabel("Scaled Image");
                                   nodes.WithName("g").ContainsImage(fullMoon);
                                   nodes.WithName("h").ContainsImage(science);
                               })
                .Edges.Add(edges =>
                               {
                                   edges.FromNodeWithName("a").ToNodeWithName("b");
                                   edges.FromNodeWithName("a").ToNodeWithName("c");
                                   edges.FromNodeWithName("b").ToNodeWithName("c");
                                   edges.FromNodeWithName("c").ToNodeWithName("d");
                                   edges.FromNodeWithName("b").ToNodeWithName("e");
                                   edges.FromNodeWithName("e").ToNodeWithName("f");
                                   edges.FromNodeWithName("e").ToNodeWithName("g");
                                   edges.FromNodeWithName("g").ToNodeWithName("h");
                               }
                );

```

# Dot Produced #

```
digraph "DirectedGraph" {
"a" [image="C:\Documents and Settings\riaanh\Local Settings\Temp\tmp171.tmp"];
"b" [image="C:\Documents and Settings\riaanh\Local Settings\Temp\tmp172.tmp"];
"c" [image="C:\Documents and Settings\riaanh\Local Settings\Temp\tmp171.tmp", height=1.5, width=1.5];
"d" [image="C:\Documents and Settings\riaanh\Local Settings\Temp\tmp172.tmp"];
"e" [image="C:\Documents and Settings\riaanh\Local Settings\Temp\tmp171.tmp", imagescale=true, height=1.5, width=1.5, label="Scaled Image"];
"f" [image="C:\Documents and Settings\riaanh\Local Settings\Temp\tmp172.tmp", imagescale=true, height=1.8, width=1.5, label="Scaled Image"];
"g" [image="C:\Documents and Settings\riaanh\Local Settings\Temp\tmp171.tmp"];
"h" [image="C:\Documents and Settings\riaanh\Local Settings\Temp\tmp172.tmp"];
"a" -> "b";
"a" -> "c";
"b" -> "c";
"c" -> "d";
"b" -> "e";
"e" -> "f";
"e" -> "g";
"g" -> "h";
}
```