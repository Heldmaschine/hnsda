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

    public StatManager.StatList StatType { get; set; }

    public Modifier()
    {
        Type = Types.None;
        Value = 0;
        StatType = StatManager.StatList.None;
    }

    public Modifier(StatManager.StatList targetStat, Types modType, float value)
    {
        Type = modType;
        Value = value;
        StatType = targetStat;
    }
}
