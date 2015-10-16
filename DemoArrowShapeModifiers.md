# Description #

A demo of the modifiers that DOT can apply to arrow shapes.

# Graph #

![http://fluentdot.googlecode.com/svn/wiki/Images/DemoArrowShapeModifiers.png](http://fluentdot.googlecode.com/svn/wiki/Images/DemoArrowShapeModifiers.png)

# Code #

```
            var graph = Fluently.CreateDirectedGraph();
            int a = 1;
            int b = 2;
            foreach (ArrowShapeModifier modifier in Enum.GetValues(typeof(ArrowShapeModifier)))
            {
                foreach (var item in typeof (ArrowShape).GetFields(BindingFlags.Public | BindingFlags.Static).Where(x => typeof (ArrowShape).IsAssignableFrom(x.FieldType)))
                {
                    var shape = (ArrowShape) item.GetValue(null);
                    if ((modifier == ArrowShapeModifier.RightClip) || (modifier == ArrowShapeModifier.LeftClip))
                    {
                        if (!shape.LRModifierAllowed)
                        {
                            continue;
                        }
                    } 
                    else if (modifier == ArrowShapeModifier.Open)
                    {
                        if (!shape.OModifierAllowed)
                        {
                            continue;
                        }
                    } 
                    else if (modifier == ArrowShapeModifier.None)
                    {
                        continue;
                    }
                    shape = shape.Modify(modifier);
                    graph.Edges.Add(
                        x => x.FromNodeWithName(a.ToString())
                                 .ToNodeWithName(b.ToString())
                                 .WithArrowHead(shape)
                                 .WithArrowTail(shape)
                                 .WithLabel(item.Name + " - " + modifier.ToString()));
                    
                    a += 2;
                    b += 2;
                }
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
"19";
"20";
"21";
"22";
"23";
"24";
"25";
"26";
"27";
"28";
"29";
"30";
"31";
"32";
"33";
"34";
"35";
"36";
"37";
"38";
"1" -> "2" [arrowhead="lbox", arrowtail="lbox", label="Box - LeftClip"];
"3" -> "4" [arrowhead="lcrow", arrowtail="lcrow", label="Crow - LeftClip"];
"5" -> "6" [arrowhead="ldiamond", arrowtail="ldiamond", label="Diamond - LeftClip"];
"7" -> "8" [arrowhead="linv", arrowtail="linv", label="Inverted - LeftClip"];
"9" -> "10" [arrowhead="lnormal", arrowtail="lnormal", label="Normal - LeftClip"];
"11" -> "12" [arrowhead="ltee", arrowtail="ltee", label="Tee - LeftClip"];
"13" -> "14" [arrowhead="lvee", arrowtail="lvee", label="Vee - LeftClip"];
"15" -> "16" [arrowhead="rbox", arrowtail="rbox", label="Box - RightClip"];
"17" -> "18" [arrowhead="rcrow", arrowtail="rcrow", label="Crow - RightClip"];
"19" -> "20" [arrowhead="rdiamond", arrowtail="rdiamond", label="Diamond - RightClip"];
"21" -> "22" [arrowhead="rinv", arrowtail="rinv", label="Inverted - RightClip"];
"23" -> "24" [arrowhead="rnormal", arrowtail="rnormal", label="Normal - RightClip"];
"25" -> "26" [arrowhead="rtee", arrowtail="rtee", label="Tee - RightClip"];
"27" -> "28" [arrowhead="rvee", arrowtail="rvee", label="Vee - RightClip"];
"29" -> "30" [arrowhead="obox", arrowtail="obox", label="Box - Open"];
"31" -> "32" [arrowhead="odiamond", arrowtail="odiamond", label="Diamond - Open"];
"33" -> "34" [arrowhead="odot", arrowtail="odot", label="Dot - Open"];
"35" -> "36" [arrowhead="oinv", arrowtail="oinv", label="Inverted - Open"];
"37" -> "38" [arrowhead="onormal", arrowtail="onormal", label="Normal - Open"];
}
```