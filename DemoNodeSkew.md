# Description #

A demo of how nodes with polygon shapes can be skewed.

# Graph #

![http://fluentdot.googlecode.com/svn/wiki/Images/DemoNodeSkew.png](http://fluentdot.googlecode.com/svn/wiki/Images/DemoNodeSkew.png)

# Code #

```
            var graph = Fluently.CreateDirectedGraph()
                .TheDefaults.ForNodes.Are(x => x.WithShape(NodeShape.Polygon))
                .WithLabel("Skew of polygon node shapes. The values on the edges indicate the skew value.");
            int a = 1;
            int b = 2;
            for (double i = -3; i < 3; i+= 0.5 )
            {
                graph.Nodes.Add(
                    x =>
                    {
                        x.WithName(a.ToString()).WithSkew(i);
                        x.WithName(b.ToString()).WithSkew(i);
                    })
                    .Edges.Add(
                        x => x.FromNodeWithName(a.ToString()).ToNodeWithName(b.ToString()).WithLabel(i.ToString())
                    );
                a += 2;
                b += 2;
            }
            return graph;

```

# Dot Produced #

```
digraph "DirectedGraph" {
graph [label="Skew of polygon node shapes. The values on the edges indicate the skew value."];

node [shape=polygon];
"1" [skew="-3"];
"2" [skew="-3"];
"3" [skew="-2.5"];
"4" [skew="-2.5"];
"5" [skew="-2"];
"6" [skew="-2"];
"7" [skew="-1.5"];
"8" [skew="-1.5"];
"9" [skew="-1"];
"10" [skew="-1"];
"11" [skew="-0.5"];
"12" [skew="-0.5"];
"13" [skew="0"];
"14" [skew="0"];
"15" [skew="0.5"];
"16" [skew="0.5"];
"17" [skew="1"];
"18" [skew="1"];
"19" [skew="1.5"];
"20" [skew="1.5"];
"21" [skew="2"];
"22" [skew="2"];
"23" [skew="2.5"];
"24" [skew="2.5"];
"1" -> "2" [label="-3"];
"3" -> "4" [label="-2.5"];
"5" -> "6" [label="-2"];
"7" -> "8" [label="-1.5"];
"9" -> "10" [label="-1"];
"11" -> "12" [label="-0.5"];
"13" -> "14" [label="0"];
"15" -> "16" [label="0.5"];
"17" -> "18" [label="1"];
"19" -> "20" [label="1.5"];
"21" -> "22" [label="2"];
"23" -> "24" [label="2.5"];
}
```