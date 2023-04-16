#if false

// ReSharper disable InconsistentNaming
#pragma warning disable CS0693
Console.WriteLine();

var grid2x3 = Grid.WithRowsOfSize<IN.N3>(Row.WithViews(new()));

public class Grid
{
    public IEnumerable<Row> Rows { get; }

    private Grid(Row[] rows)
    {
        Rows = rows;
    }
    
    public static Grid WithRowsOfSize<RowSize>(Row<RowSize> row1) where RowSize : IN => new(Row.WithViews(new()));
    public static Grid WithRowsOfSize<RowSize>(Row<RowSize> row1, Row row2) where RowSize : IN => new(new[] { row1, row2 });
    public static Grid WithRowsOfSize<RowSize>(Row<RowSize> row1, Row row2, Row row3) where RowSize : IN => new(new[] { row1, row2, row3 });
    public static Grid WithRowsOfSize<RowSize>(Row<RowSize> row1, Row row2, Row row3, Row row4) where RowSize : IN => new(new[] { row1, row2, row3, row4 });
    public static Grid WithRowsOfSize<RowSize>(Row<RowSize> row1, Row row2, Row row3, Row row4, Row row5) where RowSize : IN => new(new[] { row1, row2, row3, row4, row5 });
    public static Grid WithRowsOfSize<RowSize>(Row<RowSize> row1, Row row2, Row row3, Row row4, Row row5, Row row6) where RowSize : IN => new(new[] { row1, row2, row3, row4, row5, row6 });
    public static Grid WithRowsOfSize<RowSize>(Row<RowSize> row1, Row row2, Row row3, Row row4, Row row5, Row row6, Row row7) where RowSize : IN => new(new[] { row1, row2, row3, row4, row5, row6, row7 });
    public static Grid WithRowsOfSize<RowSize>(Row<RowSize> row1, Row row2, Row row3, Row row4, Row row5, Row row6, Row row7, Row row8) where RowSize : IN => new(new[] { row1, row2, row3, row4, row5, row6, row7, row8 });
    public static Grid WithRowsOfSize<RowSize>(Row<RowSize> row1, Row row2, Row row3, Row row4, Row row5, Row row6, Row row7, Row row8, Row row9) where RowSize : IN => new(new[] { row1, row2, row3, row4, row5, row6, row7, row8, row9 });
    public static Grid WithRowsOfSize<RowSize>(Row<RowSize> row1, Row row2, Row row3, Row row4, Row row5, Row row6, Row row7, Row row8, Row row9, Row row10) where RowSize : IN => new(new[] { row1, row2, row3, row4, row5, row6, row7, row8, row9, row10 });
    public static Grid WithRowsOfSize<RowSize>(Row<RowSize> row1, Row row2, Row row3, Row row4, Row row5, Row row6, Row row7, Row row8, Row row9, Row row10, Row row11) where RowSize : IN => new(new[] { row1, row2, row3, row4, row5, row6, row7, row8, row9, row10, row11 });
    public static Grid WithRowsOfSize<RowSize>(Row<RowSize> row1, Row row2, Row row3, Row row4, Row row5, Row row6, Row row7, Row row8, Row row9, Row row10, Row row11, Row row12) where RowSize : IN => new(new[] { row1, row2, row3, row4, row5, row6, row7, row8, row9, row10, row11, row12 });
    public static Grid WithRowsOfSize<RowSize>(Row<RowSize> row1, Row row2, Row row3, Row row4, Row row5, Row row6, Row row7, Row row8, Row row9, Row row10, Row row11, Row row12, Row row13) where RowSize : IN => new(new[] { row1, row2, row3, row4, row5, row6, row7, row8, row9, row10, row11, row12, row13 });
    
}

public interface IN
{
    public struct N1 : IN
    {
    }
    
    public struct N2 : IN
    {
    }
    
    public struct N3 : IN
    {
    }
    
    public struct N4 : IN
    {
    }
    
    public struct N5 : IN
    {
    }
    
    public struct N6 : IN
    {
    }
    
    public struct N7 : IN
    {
    }
    
    public struct N8 : IN
    {
    }
    
    public struct N9 : IN
    {
    }
    
    public struct N10 : IN
    {
    }
    
    public struct N11 : IN
    {
    }
    
    public struct N12 : IN
    {
    }

    public struct N13 : IN
    {
    }
}

public class Row
{
    public static Row<IN.N1> WithViews(View view1) => new(new[] { new Cell(view1) });
    public static Row<IN.N2> WithViews(View view1, View view2) => new(new[] { new Cell(view1), new Cell(view2) });
    public static Row<IN.N3> WithViews(View view1, View view2, View view3) => new(new[] { new Cell(view1), new Cell(view2), new Cell(view3) });

    public Cell?[] Columns { get; }
    private Row(Cell?[] columns)
    {
        Columns = columns;
    }
}

public class Row<ViewsCount>
    where ViewsCount : IN
{

    public static Row WithViews(View view1) => new(new[] { new Cell(view1) });
    public static Row WithViews(View view1, View view2) => new(new[] { new Cell(view1), new Cell(view2) });
    public static Row WithViews(View view1, View view2, View view3) => new(new[] { new Cell(view1), new Cell(view2), new Cell(view3) });
    public static Row WithViews(View view1, View view2, View view3, View view4) => new(new[] { new Cell(view1), new Cell(view2), new Cell(view3), new Cell(view4) });
    public static Row WithViews(View view1, View view2, View view3, View view4, View view5) => new(new[] { new Cell(view1), new Cell(view2), new Cell(view3), new Cell(view4), new Cell(view5) });
    public static Row WithViews(View view1, View view2, View view3, View view4, View view5, View view6) => new(new[] { new Cell(view1), new Cell(view2), new Cell(view3), new Cell(view4), new Cell(view5), new Cell(view6) });
    public static Row WithViews(View view1, View view2, View view3, View view4, View view5, View view6, View view7) => new(new[] { new Cell(view1), new Cell(view2), new Cell(view3), new Cell(view4), new Cell(view5), new Cell(view6), new Cell(view7) });
    public static Row WithViews(View view1, View view2, View view3, View view4, View view5, View view6, View view7, View view8) => new(new[] { new Cell(view1), new Cell(view2), new Cell(view3), new Cell(view4), new Cell(view5), new Cell(view6), new Cell(view7), new Cell(view8) });
    public static Row WithViews(View view1, View view2, View view3, View view4, View view5, View view6, View view7, View view8, View view9) => new(new[] { new Cell(view1), new Cell(view2), new Cell(view3), new Cell(view4), new Cell(view5), new Cell(view6), new Cell(view7), new Cell(view8), new Cell(view9) });
    public static Row WithViews(View view1, View view2, View view3, View view4, View view5, View view6, View view7, View view8, View view9, View view10) => new(new[] { new Cell(view1), new Cell(view2), new Cell(view3), new Cell(view4), new Cell(view5), new Cell(view6), new Cell(view7), new Cell(view8), new Cell(view9), new Cell(view10) });
    public static Row WithViews(View view1, View view2, View view3, View view4, View view5, View view6, View view7, View view8, View view9, View view10, View view11) => new(new[] { new Cell(view1), new Cell(view2), new Cell(view3), new Cell(view4), new Cell(view5), new Cell(view6), new Cell(view7), new Cell(view8), new Cell(view9), new Cell(view10), new Cell(view11) });
    public static Row WithViews(View view1, View view2, View view3, View view4, View view5, View view6, View view7, View view8, View view9, View view10, View view11, View view12) => new(new[] { new Cell(view1), new Cell(view2), new Cell(view3), new Cell(view4), new Cell(view5), new Cell(view6), new Cell(view7), new Cell(view8), new Cell(view9), new Cell(view10), new Cell(view11), new Cell(view12) });
    public static Row WithViews(View view1, View view2, View view3, View view4, View view5, View view6, View view7, View view8, View view9, View view10, View view11, View view12, View view13) => new(new[] { new Cell(view1), new Cell(view2), new Cell(view3), new Cell(view4), new Cell(view5), new Cell(view6), new Cell(view7), new Cell(view8), new Cell(view9), new Cell(view10), new Cell(view11), new Cell(view12), new Cell(view13) });
}

public class Cell
{
    public View? Content { get; }

    private Cell()
    {
    }

    public Cell(View content)
    {
        Content = content;
    }

    public static Cell Empty() => new();
}

public class View
{
}
#endif