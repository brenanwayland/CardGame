using UnityEngine;
using System.Collections;

public class GUITest : MonoBehaviour {

    private Creature card1 = new NobleShade();

    void OnGUI()
    {
        GUILayout.Label("Name: " + card1.getCardName());
        GUILayout.Label("Type: " + card1.getCardType().ToString());
        GUILayout.Label("Vitality: " + card1.getVitality());
    }
}
