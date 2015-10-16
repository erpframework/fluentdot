# Description #

A demo of the basic arrow shapes that DOT supports.

# Graph #

![http://fluentdot.googlecode.com/svn/wiki/Images/DemoArrowShapes.png](http://fluentdot.googlecode.com/svn/wiki/Images/DemoArrowShapes.png)

# Code #

```
            var graph = Fluently.CreateDirectedGraph();
            int a = 1;
            int b = 2;
            foreach (var item in typeof(ArrowShape).GetFields(BindingFlags.Public | BindingFlags.Static).Where(x => typeof(ArrowShape).IsAssignableFrom(x.FieldType)))
            {
                var shape = (ArrowShape) item.GetValue(null);
                graph.Edges.Add(
                    x => x.FromNodeWithName(a.ToString()).ToNodeWithName(b.ToString())
                             .WithArrowTail(shape)
                             .WithLabel(item.Name));
                a+=2;
                b+=2;
            }
            return graph;

```

# Dot Produced #

```
digraph "DirectedGraph" {
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
"1" -> "2" [arrowtail="box", label="Box"];
"3" -> "4" [arrowtail="crow", label="Crow"];
"5" -> "6" [arrowtail="diamond", label="Diamond"];
"7" -> "8" [arrowtail="dot", label="Dot"];
"9" -> "10" [arrowtail="inv", label="Inverted"];
"11" -> "12" [arrowtail="none", label="None"];
"13" -> "14" [arrowtail="normal", label="Normal"];
"15" -> "16" [arrowtail="tee", label="Tee"];
"17" -> "18" [arrowtail="vee", label="Vee"];
}
```