Console.WriteLine();

Console.WriteLine(MeasureSpec.makeMeasureSpec(0, MeasureSpec.UNSPECIFIED));
Console.WriteLine(MeasureSpec.makeMeasureSpec(0, MeasureSpec.EXACTLY));
Console.WriteLine(MeasureSpec.makeMeasureSpec(0, MeasureSpec.AT_MOST));

Console.WriteLine(MeasureSpec.makeMeasureSpec(10, MeasureSpec.UNSPECIFIED));
Console.WriteLine(MeasureSpec.makeMeasureSpec(10, MeasureSpec.EXACTLY));
Console.WriteLine(MeasureSpec.makeMeasureSpec(10, MeasureSpec.AT_MOST));

public static class MeasureSpec
{
    private static readonly int MODE_SHIFT = 30;
    private static readonly int MODE_MASK = 0x3 << MODE_SHIFT;

    /**
         * Measure specification mode: The parent has not imposed any constraint
         * on the child. It can be whatever size it wants.
         */
    public static readonly int UNSPECIFIED = 0 << MODE_SHIFT;

    /**
         * Measure specification mode: The parent has determined an exact size
         * for the child. The child is going to be given those bounds regardless
         * of how big it wants to be.
         */
    public static readonly int EXACTLY = 1 << MODE_SHIFT;

    /**
         * Measure specification mode: The child can be as large as it wants up
         * to the specified size.
         */
    public static readonly int AT_MOST = 2 << MODE_SHIFT;

    /**
     * Creates a measure specification based on the supplied size and mode.
     * 
     * The mode must always be one of the following:
     * <ul>
     *     <li>{@link android.view.View.MeasureSpec#UNSPECIFIED}</li>
     *     <li>{@link android.view.View.MeasureSpec#EXACTLY}</li>
     *     <li>{@link android.view.View.MeasureSpec#AT_MOST}</li>
     * </ul>
     * <p>
     *     <strong>Note:</strong> On API level 17 and lower, makeMeasureSpec's
     *     implementation was such that the order of arguments did not matter
     *     and overflow in either value could impact the resulting MeasureSpec.
     *     {@link android.widget.RelativeLayout} was affected by this bug.
     *     Apps targeting API levels greater than 17 will get the fixed, more strict
     *     behavior.
     * </p>
     * @param size the size of the measure specification
     * @param mode the mode of the measure specification
     * @return the measure specification based on size and mode
     */
    public static int makeMeasureSpec(int size, int mode) => 
         (size & ~MODE_MASK) | (mode & MODE_MASK);
}