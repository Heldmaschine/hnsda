using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class for handling stat points
/// </summary>

    /*
        •	Уровень – от 1 до 100
        •	50 базового здоровья (+ 12 за уровень)
        •	0 регенерации здоровья
        •	40 маны (+ 6 за уровень)
        •	1,75% регенерации маны в секунду
        •	0 энергетического щита
        •	20,0% заряда энергетического щита в секунду
        •	53 рейтинга уклонения (+3 за уровень)
        •	0 базовой брони
        •	0% сопротивлений
        •	Базовый множитель критического удара: 150%
        Атрибуты:
        •	Сила – 0,5 максимального здоровья, 0,2% физического урона за единицу
        •	Ловкость – 0,2% увеличение рейтинга уклонения, 2 рейтинга точности за единицу
        •	Интеллект – 0,5 максимальной маны, 0,2 увеличение максимального энергетического щита за единицу

        Два одноручных оружия:

        •	На 10% больше скорости атаки 
        •	15% дополнительного шанса блокировки 
        •	На 20% больше физического урона от атаки 

        Максимумы
        •	75% максимальной вероятности блокировки
        •	75% максимального сопротивления хаосу
        •	75% максимального сопротивления холоду 
        •	75% максимального сопротивления огню
        •	75% максимального сопротивления электричеству
        •	Может иметь до 75% ухода от атак
        •	Может иметь до 75% ухода от заклинаний
        •	Может иметь до 90% максимального снижения физического урона
        •	Может устанавливать до 3 ловушек
        •	Можно установить до 5 мин
        •	Может вызвать 1 тотем
*/


public class StatManager
{
    private Dictionary<StatList, GenericStat> _statDict;
    public enum StatList
    {
        Level,
        Strengh,
        Dexterity,
        Intelligence,
        Life,
        Mana,
        EShield,
        LifeRegen,
        ManaRagen,
        EShieldRegen,
        Accuracy,
        Evasion,
        Dodge
    }
    public StatManager()
    {
        _statDict = new Dictionary<StatList, GenericStat>();
        ConfigureStats();
    }

    protected virtual void ConfigureStats()
    {
        GenericStat level = CreateOrGetStat(StatList.Level);
        level.StatName = "Level";
        level.StatValue = 1;

        GenericStat life = CreateOrGetStat(StatList.Life);
        life.StatName = "Life";
        life.StatValue = 50;

        GenericStat mana = CreateOrGetStat(StatList.Mana);
        mana.StatName = "Mana";
        mana.StatValue = 40;
    }

    public bool Contains(StatList statType)
    {
        return _statDict.ContainsKey(statType);
    }

    public GenericStat GetStat(StatList statType)
    {
        if (Contains(statType))
        {
            return _statDict[statType];
        }
        return null;
    }

    protected GenericStat CreateStat(StatList statType)
    {
        GenericStat stat = new GenericStat();
        _statDict.Add(statType, stat);
        return stat;
    }

    protected GenericStat CreateOrGetStat(StatList statType)
    {
        GenericStat stat = GetStat(statType);
        if (stat == null)
        {
            stat = CreateStat(statType);
        }
        return stat;
    }
}
