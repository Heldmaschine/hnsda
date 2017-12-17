
using System;
using System.Collections.Generic;
using UnityEngine.Assertions.Comparers;

public class ModifiableStat : GenericStat, IStatModifiable
{
    private List<Modifier> _statMods;

    public override float StatValue
    {
        get { return StatModifierValue; }
    }

    public float StatModifierValue { get; private set; }

    public ModifiableStat()
    {
        StatModifierValue = 0;
        _statMods = new List<Modifier>();
    }

    public void AddModifier(Modifier mod)
    {
        _statMods.Add(mod);
    }

    public void ClearModifiers()
    {
        _statMods.Clear();
    }

    public void UpdateModifiers()
    {
        StatModifierValue = 0;
        float flatMod = 0;
        float incMod = 0;
        float moreMod = 1;

        foreach (Modifier mod in _statMods)
        {

            switch (mod.Type)
            {
                case Modifier.Types.Flat:
                    flatMod += mod.Value;
                    break;
                case Modifier.Types.Increased:
                    incMod += mod.Value;
                    break;
                case Modifier.Types.More:
                    if(Math.Abs(mod.Value) > float.Epsilon) moreMod *= mod.Value;
                    break;
            }
        }

        StatModifierValue += ((base.StatValue + flatMod) * (1+incMod)) * moreMod;
    }
}