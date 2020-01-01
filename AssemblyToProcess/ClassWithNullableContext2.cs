using System;

#nullable enable

// Roslyn compiler adds [NullableContext(2)] because majority of methods use nullable reference types

// [NullableContext(2)]
// [Nullable(0)]
public class ClassWithNullableContext2
{
    // [NullableContext(1)]
    public void SomeMethod(string nonNullArg, /* [Nullable(2)] */ string? nullArg)
    {
        Console.WriteLine(nonNullArg);
    }

    // [NullableContext(1)]
    public string MethodWithReturnValue(bool returnNull)
    {
#pragma warning disable CS8603 // Possible null reference return.
        return returnNull ? null : "";
#pragma warning restore CS8603 // Possible null reference return.
    }

    public string? MethodAllowsNullReturnValue()
    {
        return null;
    }

    public void AnotherMethod(string? nullArg)
    {

    }

    public void AndAnotherMethod(string? nullArg)
    {

    }

    public string? AndEventAnotherMethod(string? nullArg)
    {
        return nullArg;
    }
}
