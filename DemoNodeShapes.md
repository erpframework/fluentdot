# Description #

Showing off all possible shapes available through Dot.

# Graph #

![http://fluentdot.googlecode.com/svn/wiki/Images/DemoNodeShapes.png](http://fluentdot.googlecode.com/svn/wiki/Images/DemoNodeShapes.png)

# Code #

```
            var graph =  Fluently.CreateUndirectedGraph();
            
            foreach (var item in typeof(NodeShape).GetFields(BindingFlags.Public | BindingFlags.Static).Where(x => typeof(NodeShape).IsAssignableFrom(x.FieldType)))
            {
                var shape = (NodeShape) item.GetValue(null);
                graph.Nodes.Add(x => x.WithName(item.Name).WithShape(shape));
            }
            return graph;

```

# Dot Produced #

```
graph "UndirectedGraph" {
"Box" [shape=box];
"Polygon" [shape=polygon];
"Ellipse" [shape=ellipse];
"Circle" [shape=circle];
"Point" [shape=point];
"Egg" [shape=egg];
"Triangle" [shape=triangle];
"PlainText" [shape=plaintext];
"Diamond" [shape=diamond];
"Trapezium" [shape=trapezium];
"House" [shape=house];
"Parallelogram" [shape=parallelogram];
"Pentagon" [shape=pentagon];
"Hexagon" [shape=hexagon];
"Septagon" [shape=septagon];
"Octagon" [shape=octagon];
"DoubleCircle" [shape=doublecircle];
"DoubleOctagon" [shape=doubleoctagon];
"TripleOctagon" [shape=tripleoctagon];
"InvertedTriangle" [shape=invtriangle];
"InvertedTrapezium" [shape=invtrapezium];
"InvertedHouse" [shape=invhouse];
"MDiamond" [shape=Mdiamond];
"MSquare" [shape=Msquare];
"MCircle" [shape=Mcircle];
"Rectangle" [shape=rectangle];
"None" [shape=none];
"Note" [shape=note];
"Tab" [shape=tab];
"Folder" [shape=folder];
"Box3D" [shape=box3d];
"Component" [shape=component];
}
```