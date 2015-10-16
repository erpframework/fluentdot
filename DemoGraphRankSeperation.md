# Description #

A demo of how rank seperation affects the layout of a graph.

# Graph #

![http://fluentdot.googlecode.com/svn/wiki/Images/DemoGraphRankSeperation.png](http://fluentdot.googlecode.com/svn/wiki/Images/DemoGraphRankSeperation.png)

# Code #

```
            return Fluently.CreateDirectedGraph()
                .Edges.Add(edge =>
                {
                    edge.FromNodeWithName("a").ToNodeWithName("b");
                    edge.FromNodeWithName("b").ToNodeWithName("c");
                    edge.FromNodeWithName("c").ToNodeWithName("d");
                    edge.FromNodeWithName("d").ToNodeWithName("e");
                    edge.FromNodeWithName("e").ToNodeWithName("f");
                    edge.FromNodeWithName("f").ToNodeWithName("g");
                    edge.FromNodeWithName("aa").ToNodeWithName("a");
                    edge.FromNodeWithName("dd").ToNodeWithName("d");
                    edge.FromNodeWithName("gg").ToNodeWithName("g");
                }
                )
                .WithRankSeperation(2, true)
                .WithLabel("2 inch minimum rank seperation, seperated equally.");

```

# Dot Produced #

```
digraph "DirectedGraph" {
graph [ranksep="2 equally", label="2 inch minimum rank seperation, seperated equally."];

"a";
"b";
"c";
"d";
"e";
"f";
"g";
"aa";
"dd";
"gg";
"a" -> "b";
"b" -> "c";
"c" -> "d";
"d" -> "e";
"e" -> "f";
"f" -> "g";
"aa" -> "a";
"dd" -> "d";
"gg" -> "g";
}
```