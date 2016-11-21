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
            /*
             * The very beginning of the duel. Players will input their information, select a deck, select
             * environments for their respective Basecamps and the Warground, and draw their initial hand.
             **/
            case (GameState.START):
                // choose Decks and assign players
                Deck wasteland = new WastelandDeck();
                player1 = new Player(1, wasteland, "Joey Wheeler", 15, 10);
                player2 = new Player(2, wasteland, "Yugi Moto", 15, 10);

                // choose Environments for Basecamp and Warground
                Environment env1 = new Environment("Wicked Woods", Environment.EnvType.JUNGLE);
                Environment env2 = new Environment("Fallout Zone", Environment.EnvType.WASTELAND);
                Environment env3 = new Environment("Sunken Ship", Environment.EnvType.OCEAN);

                Basecamp bc1 = new Basecamp(player1, env1);
                Basecamp bc2 = new Basecamp(player2, env2);
                Warground wg = new Warground(env3);

                //set up board with choices
                board = new Board(bc1, bc2, wg);

                //each player draws full hand

                //begin the duel by transitioning to the Intro Phase
                currentPlayer = player1;
                current = GameState.INTRO;
                break;

            /*
             * Intro Phase: The player draws 1 card, and may change the Environment
             * of his/her Basecamp.
             */
            case (GameState.INTRO):
                //draw
                currentPlayer.getDeck().draw();

                break;

            /*
             * Replenishing Phase: Replenish lifeblood and mana with the bonuses
             * provided by the Basecamp's Environment. If any structures are due to be built,
             * they will now enter the game.
             */
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

            /*
             * Summoning Phase: The player summons Creatures, Lifeblood permitting, and
             * announces the construction of Structures.
             */
            case (GameState.SUMMONING):
                // player can summon as many creatures as their Lifeblood will allow

                // player announces new structures
                break;

                /*
                 * Marching Phase: The player can move any of his/her characters which
                 * have remaining Initiative to any adjacent Environment, provided they
                 * are not blocked by enemy Creatures or Structures.
                 */
            case (GameState.MARCHING):
                // move logic - check for initiative and create helper function for moving
                break;
    
                /*
                 * Battle Phase: Any Creature that has not yet attacked, unless otherwise
                 * specified by a card effect, may attack any eligible enemy Creature that is 
                 * within the same Environment. 
                 */
            case (GameState.BATTLE):
                // battle logic
                // create function that lists all possible targets
                // use Creature's attack function
                break;

            /*
             * Second Marching Phase: Any Creature that has not so far moved or 
             * attacked may do so now.
             */
            case (GameState.SECONDMARCH):
                //Again, characters who still have initiative can move.
                break;

                /*
                 */
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
