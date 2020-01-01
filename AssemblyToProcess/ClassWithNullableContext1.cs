using System;

#nullable enable

// Roslyn compiler adds [NullableContext(1)] because majority of methods do not use nullable reference types

// [NullableContext(1)]
// [Nullable(0)]
public class ClassWithNullableContext1
{
    public void SomeMethod(string nonNullArg, /* [Nullable(2)] */ string? nullArg)
    {
        Console.WriteLine(nonNullArg);
    }

    public string MethodWithReturnValue(bool returnNull)
    {
#pragma warning disable CS8603 // Possible null reference return.
        return returnNull ? null : "";
#pragma warning restore CS8603 // Possible null reference return.
    }

    // [NullableContext(2)]
    public string? MethodAllowsNullReturnValue()
    {
        return null;
    }

    public string AnotherMethod(string nonNullArg)
    {
        return nonNullArg;
    }

    public void AndAnotherMethod(string nonNullArg)
    {

    }
}
