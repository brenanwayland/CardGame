using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/*
 * The engine that runs each duel. It keeps track of game logic, such as 
 * whose turn it currently is, and cycles through the phases of the game.
 * All logic for summoning creatures and moving will be contained in the 
 * Board object.
 */

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

    private GameState currentState;
    private Player player1;
    private Player player2;
    private Player currentPlayer;
    private Board board;
    private List<Structure> declaredStructures;

    // helper class that keeps track of the building of structures
    private List<Structure> checkStructuresForBuild()
    {
        List<Structure> toBuild = new List<Structure>();
        for (int i = 0; i < declaredStructures.Count; i++)
        {
            if (declaredStructures[i].getTimeReq() == 0)
            {
                // add to array
                toBuild.Add(declaredStructures[i]);
            }
        }
        return toBuild;
    }

    private void structureCountdown()
    {
        for (int i = 0; i < declaredStructures.Count; i++)
        {
            Structure current = declaredStructures[i];
            current.timeReqDown(1);
        }
    }


    // Use this for initialization
    void Start () {
        currentState = GameState.START;      	
	}
	
	// Update is called once per frame
	void Update () {

        switch (currentState)
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
                currentState = GameState.INTRO;
                break;

            /*
             * Intro Phase: The player draws 1 card, and may change the Environment
             * of his/her Basecamp.
             */
            case (GameState.INTRO):
                //draw
                currentPlayer.getDeck().draw();

                bool changeBC = false;

                // if the player elects to, they may change their Basecamp's Environment
                if (changeBC)
                {
                    // TODO: Link to player choice
                    Environment newEnv = new Environment();
                    if (currentPlayer == player1)
                    {
                        board.getBasecamp(1).changeEnvironment(newEnv);
                    } else
                    {
                        board.getBasecamp(2).changeEnvironment(newEnv);
                    }
                }

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
                    currentPlayer.regainLifeblood(board.getBasecamp(1).getEnvironment().lifebloodBonus());
                    currentPlayer.regainMana(board.getBasecamp(1).getEnvironment().manaBonus());
                } else
                {
                    currentPlayer.regainLifeblood(board.getBasecamp(2).getEnvironment().lifebloodBonus());
                    currentPlayer.regainMana(board.getBasecamp(2).getEnvironment().manaBonus());
                }

                //check for structures that are due to be built, and build them
                structureCountdown();
                checkStructuresForBuild();
                break;

            /*
             * Summoning Phase: The player summons Creatures, Lifeblood permitting, and
             * announces the construction of Structures.
             */
            case (GameState.SUMMONING):
                // player can summon as many creatures as their Lifeblood will allow

                // player announces new structures
                Structure newStructure = new Structure();
                declaredStructures[0] = newStructure;
                break;

                /*
                 * Marching Phase: The player can move any of his/her characters which
                 * have remaining Initiative to any adjacent Environment, provided they
                 * are not blocked by enemy Creatures or Structures.
                 */
            case (GameState.MARCHING):
                // move logic - check for initiative and create helper function for moving
                Zone destination = board.getWarground();
                Creature toMove = new global::Creature();
                board.move(toMove, toMove.getCurrentLocation(), destination);
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

                //first, replenish all player's Creature's attack initiative
                for (int i = 0; i < currentPlayer.getCardsInPlay().Length; i++)
                {
                    Card current = currentPlayer.getCardsInPlay()[i];
                    if (current.getCardType() == Card.CardType.CREATURE)
                    {
                        Creature currentCreature = (Creature)current;
                        currentCreature.setAttackInit();
                    }
                }

                Creature attacker = new Creature();
                Creature target = new Creature();
                if (attacker.getCurrentLocation() == target.getCurrentLocation()) //maybe move this logic elsewhere
                {
                    attacker.attack(target);
                }
                break;

            /*
             * Second Marching Phase: Any Creature that has not so far moved or 
             * attacked may do so now.
             */
            case (GameState.SECONDMARCH):
                //Again, characters who still have initiative can move.
                Zone destination2 = board.getWarground();
                Creature toMove2 = new global::Creature();
                board.move(toMove2, toMove2.getCurrentLocation(), destination2);
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
            if (currentState == GameState.INTRO)
            {
                currentState = GameState.REPLENISHING;
            } else if (currentState == GameState.REPLENISHING)
            {
                currentState = GameState.SUMMONING;
            } else if (currentState == GameState.SUMMONING)
            {
                currentState = GameState.MARCHING;
            } else if (currentState == GameState.MARCHING)
            {
                currentState = GameState.BATTLE;
            } else if (currentState == GameState.BATTLE) {
                currentState = GameState.SECONDMARCH;
            } else if (currentState == GameState.SECONDMARCH)
            {
                currentState = GameState.INTRO;
            }
        }

    }

}
