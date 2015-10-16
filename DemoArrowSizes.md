# Description #

A demo of the arrow sizing that DOT supports.

# Graph #

![http://fluentdot.googlecode.com/svn/wiki/Images/DemoArrowSizes.png](http://fluentdot.googlecode.com/svn/wiki/Images/DemoArrowSizes.png)

# Code #

```
            var graph = Fluently.CreateDirectedGraph();
            
            int a = 1;
            int b = 2;
            for (double i = 0; i <= 2; i += 0.2)
            {
                graph.Edges.Add(
                    x => x.FromNodeWithName(a.ToString()).ToNodeWithName(b.ToString())
                             .WithArrowSize(i))
                    .WithLabel(i.ToString());
                a += 2;
                b += 2;
            }
            return graph;

```

# Dot Produced #

```
digraph "DirectedGraph" {
graph [label="0"];

"1";
"2";
"3";
"4";
"5";
"6";
"7";
"8";
"9";
"10";
"11";
"12";
"13";
"14";
"15";
"16";
"17";
"18";
"19";
"20";
"21";
"22";
"1" -> "2" [arrowsize=0];
"3" -> "4" [arrowsize=0.2];
"5" -> "6" [arrowsize=0.4];
"7" -> "8" [arrowsize=0.6];
"9" -> "10" [arrowsize=0.8];
"11" -> "12" [arrowsize=1];
"13" -> "14" [arrowsize=1.2];
"15" -> "16" [arrowsize=1.4];
"17" -> "18" [arrowsize=1.6];
"19" -> "20" [arrowsize=1.8];
"21" -> "22" [arrowsize=2];
}
```