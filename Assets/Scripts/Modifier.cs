using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Modifier {

    public enum Types
    {
        None,
        Flat,
        Increased,
        More
    }

    public Types Type { get; set; }

    public float Value { get; set; }

    public Modifier()
    {
        Type = Types.None;
        Value = 0;
    }

    public Modifier(Types modType, float value)
    {
        Type = modType;
        Value = value;
    }
}
