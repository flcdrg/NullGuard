﻿using System;
using System.Diagnostics.CodeAnalysis;

public class ClassWithRefReturns
{
    private string? _value = null;

    public ref string GetNonNullRef()
    {
        return ref _value!;
    }

    public ref string? GetNullRef()
    {
        return ref _value;
    }

    public class Generic<T>
    {
        private T _value = default!;

        public ref T GetMaybeNullUnconstrainedRef()
        {
            return ref _value;
        }
    }

    public class GenericNonNull<T> where T : notnull
    {
        private T _value = default!;

        public GenericNonNull([AllowNull] T value)
        {
#pragma warning disable CS8601 // Possible null reference assignment
            _value = value;
#pragma warning restore CS8601 // Possible null reference assignment
        }

        public ref T GetNonNullRef()
        {
            return ref _value;
        }
    }
}

