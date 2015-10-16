# Description #

Demonstration of how sub graphs and ranking can help with the layout of graphs.

# Graph #

![http://fluentdot.googlecode.com/svn/wiki/Images/DemoSubGraphsAndRanks.png](http://fluentdot.googlecode.com/svn/wiki/Images/DemoSubGraphsAndRanks.png)

# Code #

```
            return Fluently.CreateDirectedGraph()
                .SubGraphs.Add(s => s.WithName("c0")
                                        .WithRank(RankType.Maximum)
                                        .Edges.Add(edge =>
                                                       {
                                                           edge.FromNodeWithName("a").ToNodeWithName("b");
                                                           edge.FromNodeWithName("b").ToNodeWithName("c");
                                                           edge.FromNodeWithName("c").ToNodeWithName("d");
                                                       })
                )
                .SubGraphs.Add(s => s.WithName("c1")
                                        .WithRank(RankType.Maximum)
                                        .Edges.Add(edge =>
                                                       {
                                                           edge.FromNodeWithName("d").ToNodeWithName("e");
                                                           edge.FromNodeWithName("e").ToNodeWithName("f");
                                                           edge.FromNodeWithName("f").ToNodeWithName("g");
                                                       })
                                                      )
                 .SubGraphs.Add(s => s.WithName("c2")
                                        .WithRank(RankType.Maximum)
                                        .Edges.Add(edge =>
                                                       {
                                                           edge.FromNodeWithName("g").ToNodeWithName("h");
                                                           edge.FromNodeWithName("h").ToNodeWithName("i");
                                                           edge.FromNodeWithName("i").ToNodeWithName("j");
                                                       }))
                .SubGraphs.Add(s => s.WithName("c3")
                                        .WithRank(RankType.Maximum)
                                        .Edges.Add(edge =>
                                                       {
                                                           edge.FromNodeWithName("j").ToNodeWithName("k");
                                                           edge.FromNodeWithName("k").ToNodeWithName("l");
                                                           edge.FromNodeWithName("l").ToNodeWithName("m");
                                                       }))
                .SubGraphs.Add(s => s.WithName("c4")
                                        .WithRank(RankType.Minimum)
                                        .Edges.Add(edge =>
                                                       {
                                                           edge.FromNodeWithName("m").ToNodeWithName("n");
                                                           edge.FromNodeWithName("n").ToNodeWithName("o");
                                                           edge.FromNodeWithName("o").ToNodeWithName("p");
                                                       }))
            .Edges.Add(edge => {
                edge.FromNodeWithName("aa").ToNodeWithName("a");
                edge.FromNodeWithName("dd").ToNodeWithName("d");
                edge.FromNodeWithName("gg").ToNodeWithName("g");
                edge.FromNodeWithName("jj").ToNodeWithName("j");
                edge.FromNodeWithName("mm").ToNodeWithName("m");
                edge.FromNodeWithName("aa").ToNodeWithName("dd");
                edge.FromNodeWithName("dd").ToNodeWithName("gg");
                edge.FromNodeWithName("gg").ToNodeWithName("jj");
                edge.FromNodeWithName("jj").ToNodeWithName("mm");
            });

```

# Dot Produced #

```
digraph "DirectedGraph" {
subgraph "c0" {
graph [rank="max"];

"a";
"b";
"c";
"d";
"a" -> "b";
"b" -> "c";
"c" -> "d";
}
subgraph "c1" {
graph [rank="max"];

"e";
"f";
"g";
"d" -> "e";
"e" -> "f";
"f" -> "g";
}
subgraph "c2" {
graph [rank="max"];

"h";
"i";
"j";
"g" -> "h";
"h" -> "i";
"i" -> "j";
}
subgraph "c3" {
graph [rank="max"];

"k";
"l";
"m";
"j" -> "k";
"k" -> "l";
"l" -> "m";
}
subgraph "c4" {
graph [rank="min"];

"n";
"o";
"p";
"m" -> "n";
"n" -> "o";
"o" -> "p";
}
"aa";
"dd";
"gg";
"jj";
"mm";
"aa" -> "a";
"dd" -> "d";
"gg" -> "g";
"jj" -> "j";
"mm" -> "m";
"aa" -> "dd";
"dd" -> "gg";
"gg" -> "jj";
"jj" -> "mm";
}
```