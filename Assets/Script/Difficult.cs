using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Difficult : MonoBehaviour
{
    public TMP_Dropdown difficultDropdown;
    public static int difficult;

    public void Start()
    {
        difficultDropdown.value = 1;
        difficultDropdown.RefreshShownValue();
    }
    public void SetDifficulty()
    {
        if (difficultDropdown.value == 0)
        {
            difficult = 2;
            difficultDropdown.RefreshShownValue();

        }
        
        else if (difficultDropdown.value == 2)
        {
            difficult = 0;
            difficultDropdown.RefreshShownValue();
        }

        else if (difficultDropdown.value == 1)
        {
            difficult = 1;
        }
    }
}
