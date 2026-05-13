using UnityEngine;
// WICHTIG: Diese Zeile brauchen wir für das neue System!
using UnityEngine.InputSystem; 

public class SpielerBewegung : MonoBehaviour
{
    public float geschwindigkeit = 5f;

    void Update()
    {
        float x = 0f;
        float z = 0f;

        // Wir prüfen, ob eine Tastatur angeschlossen ist
        if (Keyboard.current != null)
        {
            // W und S für Vor/Zurück
            if (Keyboard.current.wKey.isPressed) z = 1f;
            if (Keyboard.current.sKey.isPressed) z = -1f;
            
            // A und D für Links/Rechts
            if (Keyboard.current.dKey.isPressed) x = 1f;
            if (Keyboard.current.aKey.isPressed) x = -1f;
        }

        // Berechnet die Richtung (.normalized verhindert, dass man schräg schneller läuft)
        Vector3 bewegung = new Vector3(x, 0f, z).normalized;

        // Bewegt den Würfel
        transform.Translate(bewegung * geschwindigkeit * Time.deltaTime, Space.World);
    }
}