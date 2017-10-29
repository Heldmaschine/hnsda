using System;
using UnityEngine;
using System.Collections;
// TODO : MAKE NEW SYSTEM TO REMOVE THIS
using Completed;
using UnityEngine.UI;


///<summary>
/// Dummy unit
///  inherits Enemy for some common functionality (because rn im too lazy to implement MovingObject)
/// </summary>

public class Dummy : Enemy
{
    private GameObject hitText;
    //Start overrides the virtual Start function of the base class.
    protected override void Start ()
	{
	    var stats = new StatManager();

	    var statTypes = Enum.GetValues(typeof(StatManager.StatList));
	    foreach (var statType in statTypes)
	    {
	        GenericStat stat = stats.GetStat((StatManager.StatList)statType);
	        if (stat != null)
	        {
	            Debug.Log(string.Format("Stat {0}'s value is {1}",
	                stat.StatName, stat.StatValue));
	        }
	    }
        //Call the start function of our base class MovingObject.
        base.Start ();
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

