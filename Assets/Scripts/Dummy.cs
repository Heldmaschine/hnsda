using System;
using UnityEngine;
// TODO : MAKE NEW SYSTEM TO REMOVE THIS
using Completed;


///<summary>
/// Dummy unit
///  inherits Enemy for some common functionality (because rn im too lazy to implement MovingObject)
/// </summary>

public class Dummy : Enemy
{
    private GameObject hitText;
    //Start overrides the virtual Start function of the base class.
    //TODO: REMOVE <> TO MAEK IT FANCIER
    private StatManager<ModifiableStat> stats;

    protected override void Start()
    {
        stats = new StatManager<ModifiableStat>();

        DisplayStatValues();

        var health = stats.GetStat(StatManager<ModifiableStat>.StatList.Life);
        health.AddModifier(new Modifier(Modifier.Types.Flat, 10f));      // 60
        health.AddModifier(new Modifier(Modifier.Types.Increased, 0.5f));           // 90
        health.AddModifier(new Modifier(Modifier.Types.More, 2.0f));     // 180
        health.UpdateModifiers();

        DisplayStatValues();
        base.Start();
    }

    void ForEachEnum<T>(Action<T> action)
    {
        if (action != null)
        {
            var statTypes = Enum.GetValues(typeof(T));
            foreach (var statType in statTypes)
            {
                action((T)statType);
            }
        }
    }

    void DisplayStatValues()
    {
        ForEachEnum<StatManager<ModifiableStat>.StatList>((statType) =>
        {
            var stat = stats.GetStat(statType);
            if (stat != null)
            {
                Debug.Log(string.Format("Stat {0}'s value is {1}",
                    stat.StatName, stat.StatValue));
            }
        });
    }

    //MoveEnemy is called by the GameManger each turn to tell each Enemy to try to move towards the player.



    //OnCantMove is called if Enemy attempts to move into a space occupied by a Player, it overrides the OnCantMove function of MovingObject 
    //and takes a generic parameter T which we use to pass in the component we expect to encounter, in this case Player
    protected override void OnCantMove <T> (T component)
	{
	    
        base.OnCantMove(component);
		//OnGUI(true);	
	}
}

