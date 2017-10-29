using UnityEngine;
using System.Collections;
// TODO : MAKE NEW SYSTEM TO REMOVE THIS
using Completed;
using UnityEngine.UI;


//inherits Enemy for some common functionality
public class Dummy : Enemy
{
    private GameObject hitText;
    //Start overrides the virtual Start function of the base class.
    protected override void Start ()
	{

        //Call the start function of our base class MovingObject.
        base.Start ();
	}

    void OnGUI(bool displayMessage)
    {
        if (displayMessage) { GUI.Label(new Rect((Screen.width * 0.5f - 50f), (Screen.height * 0.5f - 10f), 100f, 20f), "Testing"); }
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

