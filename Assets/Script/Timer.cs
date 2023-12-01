using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public static float timeRemaining = 11;
    void Update()
    {
        GetComponent<TextMeshProUGUI>().text = ((int)timeRemaining).ToString();
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }

        if (timeRemaining < 0.1 && !ShootPlayer.isShootPlayer && ShootPlayer.turnPlayer)
        {
            ShootPlayer.turnPlayer = false;
            timeRemaining = 11;
            for (int i = 0; i < ShootPlayer.compteur.Count; i++)
            {
                Destroy(ShootPlayer.compteur[i]);
            }
        }

        if (timeRemaining < 0.1 && !ShootPlayer.isShootIA && !ShootPlayer.turnPlayer)
        {
            ShootPlayer.turnPlayer = true;
            timeRemaining = 11;
        }
    }
}
