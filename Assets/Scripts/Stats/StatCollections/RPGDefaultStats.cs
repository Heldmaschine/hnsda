public class RPGDefaultStats : RPGStatCollection {
    protected override void ConfigureStats() {
        //var stamina = CreateOrGetStat<RPGAttribute>(RPGStatType.Stamina);
        //stamina.StatName = "Stamina";
        //stamina.StatBaseValue = 10;

        //var wisdom = CreateOrGetStat<RPGAttribute>(RPGStatType.Wisdom);
        //wisdom.StatName = "Wisdom";
        //wisdom.StatBaseValue = 5;

        //var health = CreateOrGetStat<RPGVital>(RPGStatType.Health);
        //health.StatName = "Health";
        //health.StatBaseValue = 100;
        //health.AddLinker(new RPGStatLinkerBasic(CreateOrGetStat<RPGAttribute>(RPGStatType.Stamina), 10f));
        //health.UpdateLinkers();
        //health.SetCurrentValueToMax();

        //var mana = CreateOrGetStat<RPGVital>(RPGStatType.Mana);
        //mana.StatName = "Mana";
        //mana.StatBaseValue = 2000;
        //mana.AddLinker(new RPGStatLinkerBasic(CreateOrGetStat<RPGAttribute>(RPGStatType.Wisdom), 50f));
        //mana.UpdateLinkers();
        //mana.SetCurrentValueToMax();
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
    }
}
