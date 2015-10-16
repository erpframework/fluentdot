# Description #

A demo of how records can be used to build composite nodes.

# Graph #

![http://fluentdot.googlecode.com/svn/wiki/Images/DemoRecords.png](http://fluentdot.googlecode.com/svn/wiki/Images/DemoRecords.png)

# Code #

```
            return Fluently.CreateDirectedGraph()
                .Nodes.AddRecord(record =>
                                     {
                                         record.WithName("struct1")
                                             .WithElement("f0", x => x.WithLabel("left"))
                                             .WithElement("f1", x => x.WithLabel("mid dle"))
                                             .WithElement("f2", x => x.WithLabel("right"));
                                         record.WithName("struct2")
                                             .WithElement("f0", x => x.WithLabel("one"))
                                             .WithElement("f1", x => x.WithLabel("two"));
                                         record.WithName("struct3")
                                             .WithElement("f0", x => x.WithLabel(@"hello\nworld"))
                                             .WithGroup(g1 => g1
                                                                  .WithElement("b")
                                                                  .WithGroup(g2 => g2
                                                                                       .WithElement("c")
                                                                                       .WithElement("here", x => x.WithLabel("d"))
                                                                                       .WithElement("e"),
                                                                             g2 => g2.IsInverted())
                                                                  .WithElement("f"), g1 => g1.IsInverted())
                                             .WithElement("g")
                                             .WithElement("h");
                                     }
                )
                .Edges.Add(edges =>
                               {
                                   edges.FromRecordWithName("struct1", "f1").ToRecordWithName("struct2", "f0");
                                   edges.FromRecordWithName("struct1", "f2").ToRecordWithName("struct3", "here");
                               });

```

# Dot Produced #

```
digraph "DirectedGraph" {
"struct1" [shape=record, label="<f0> left|<f1> mid\ dle|<f2> right"];
"struct2" [shape=record, label="<f0> one|<f1> two"];
"struct3" [shape=record, label="<f0> hello\nworld|{<b> b|{<c> c|<here> d|<e> e}|<f> f}|<g> g|<h> h"];
"struct1":"f1" -> "struct2":"f0";
"struct1":"f2" -> "struct3":"here";
}
```