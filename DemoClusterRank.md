# Description #

A demo of how global cluster rank affects the layout of clusters.

# Graph #

![http://fluentdot.googlecode.com/svn/wiki/Images/DemoClusterRank.png](http://fluentdot.googlecode.com/svn/wiki/Images/DemoClusterRank.png)

# Code #

```
            return Fluently.CreateDirectedGraph()
                .Clusters.Add(c0 => c0
                                        .WithName("c0")
                                        .WithBackgroundColor(Color.LightSteelBlue)
                                        .Edges.Add(edges => edges.FromNodeWithName("a0").ToNodeWithName("a1"))
                .Clusters.Add(c1 => c1
                                        .WithName("c1")
                                        .WithBackgroundColor(Color.LightSlateGray)
                                        .Edges.Add(edges => edges.FromNodeWithName("b0").ToNodeWithName("b1"))
                )
                .Edges.Add(edges => edges.FromNodeWithName("a0").ToNodeWithName("b0")))
                .WithClusterRankMode(ClusterMode.Global);

```

# Dot Produced #

```
digraph "DirectedGraph" {
graph [clusterrank="global"];

subgraph "clusterc0" {
graph [bgcolor="#b0c4de"];

subgraph "clusterc1" {
graph [bgcolor="#778899"];

"b0";
"b1";
"b0" -> "b1";
}
"a0";
"a1";
"a0" -> "a1";
"a0" -> "b0";
}
}
```