using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericStat {

    public string StatName { get; set; }

    public virtual float StatValue { get; set; }

    public GenericStat()
    {
        this.StatName = string.Empty;
        this.StatValue = 0;
    }

    public GenericStat(string name, int value)
    {
        this.StatName = name;
        this.StatValue = value;
    }
}
