class ThreeColorStack
{
    int[] arr;
    int redTop;
    int blueTop;
    int greenTop;
    int greenStart;
    int capacity;

    public ThreeColorStack(int n)
    {
        capacity = n;
        arr = new int[n];

        redTop = -1; // red starts left          
        blueTop = n; // starts right
        greenStart = n / 2; //starts in the middle
        greenTop = greenStart - 1;
    }

    public void PushRed(int x)
    {
        if (redTop + 1 == greenTop + 1)
            throw new Exception("red push overflow");

        redTop++;
        arr[redTop] = x;
    }

    public int PopRed()
    {
        if (redTop == -1)
            throw new Exception("red pop overflow");

        return arr[redTop--];
    }

    public bool IsEmptyRed()
    {
        return redTop == -1;
    }

    public void PushGreen(int x)
    {
        if (greenTop + 1 == blueTop)
            throw new Exception("green push overflow");

        greenTop++;
        arr[greenTop] = x;
    }

    public int PopGreen()
    {
        if (greenTop < greenStart)
            throw new Exception("green pop overflow");

        return arr[greenTop--];
    }

    public bool IsEmptyGreen()
    {
        return greenTop < greenStart;
    }

    public void PushBlue(int x)
    {
        if (blueTop - 1 == greenTop)
            throw new Exception("blue push overflow");

        blueTop--;
        arr[blueTop] = x;
    }

    public int PopBlue()
    {
        if (blueTop == capacity)
            throw new Exception("blue pop overflow");

        return arr[blueTop++];
    }

    public bool IsEmptyBlue()
    {
        return blueTop == capacity;
    }
}

class Program
{
    static void Main(string[] args)
    {
        ThreeColorStack stack = new ThreeColorStack(10);

        stack.PushRed(1);
        Console.WriteLine("pushed to red stack: 1");
        stack.PushRed(2);
        Console.WriteLine("pushed to red stack: 2");


        stack.PushGreen(1);
        Console.WriteLine("pushed to green stack: 1");
        stack.PushGreen(2);
        Console.WriteLine("pushed to green stack: 2");

        stack.PushBlue(1);
        Console.WriteLine("pushed to blue stack: 1");
        stack.PushBlue(2);
        Console.WriteLine("pushed to blue stack: 2");

        Console.WriteLine("popping red: " + stack.PopRed());
        Console.WriteLine("popping green: " + stack.PopGreen());
        Console.WriteLine("popping blue: " + stack.PopBlue());

        Console.WriteLine("red empty? " + stack.IsEmptyRed());
        Console.WriteLine("green empty? " + stack.IsEmptyGreen());
        Console.WriteLine("blue empty? " + stack.IsEmptyBlue());

        Console.WriteLine("popping red: " + stack.PopRed());
        Console.WriteLine("popping green: " + stack.PopGreen());
        Console.WriteLine("popping blue: " + stack.PopBlue());

        Console.WriteLine("red empty? " + stack.IsEmptyRed());
        Console.WriteLine("green empty? " + stack.IsEmptyGreen());
        Console.WriteLine("blue empty? " + stack.IsEmptyBlue());
    }
}