using UnityEngine;
using System.Collections;

public class StateMachine : MonoBehaviour {

    public enum GameState
    {
        START,
        INTRO,
        REPLENISHING,
        SUMMONING,
        MARCHING,
        BATTLE,
        SECONDMARCH,
        P1WINS,
        P2WINS
    }

    private GameState current;
    private Player player1;
    private Player player2;
    private Player currentPlayer;
    private Board board;


	// Use this for initialization
	void Start () {
        current = GameState.START;      	
	}
	
	// Update is called once per frame
	void Update () {

        switch (current)
        {
            case (GameState.START):
                break;

            case (GameState.INTRO):
                currentPlayer = player1;

                //draw
                currentPlayer.getDeck().draw();

                break;

            case (GameState.REPLENISHING):

                // replenish Lifeblood and Mana
                if (currentPlayer == player1)
                {
                    currentPlayer.regainLifeblood(board.getBasecamp1().getEnvironment().lifebloodBonus());
                    currentPlayer.regainMana(board.getBasecamp1().getEnvironment().manaBonus());
                } else
                {
                    currentPlayer.regainLifeblood(board.getBasecamp2().getEnvironment().lifebloodBonus());
                    currentPlayer.regainMana(board.getBasecamp2().getEnvironment().manaBonus());
                }

                //check for structures that are due to be built, and build them
                break;

            case (GameState.SUMMONING):
                // player can summon as many creatures as their Lifeblood will allow

                // player announces new structures
                break;

            case (GameState.MARCHING):
                // move logic - check for initiative and create helper function for moving
                break;

            case (GameState.BATTLE):
                // battle logic
                // create function that lists all possible targets
                // use Creature's attack function
                break;

            case (GameState.SECONDMARCH):
                //Again, characters who still have initiative can move.
                break;

            case (GameState.P1WINS):
                break;

            case (GameState.P2WINS):
                break;
        }            	
	}

    void OnGUI()
    {

        if(GUILayout.Button("Next Phase"))
        {
            if (current == GameState.INTRO)
            {
                current = GameState.REPLENISHING;
            } else if (current == GameState.REPLENISHING)
            {
                current = GameState.SUMMONING;
            } else if (current == GameState.SUMMONING)
            {
                current = GameState.MARCHING;
            } else if (current == GameState.MARCHING)
            {
                current = GameState.BATTLE;
            } else if (current == GameState.BATTLE) {
                current = GameState.SECONDMARCH;
            } else if (current == GameState.SECONDMARCH)
            {
                current = GameState.INTRO;
            }
        }

    }

}
