using TMPro;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    [SerializeField] int fullgems;
    [SerializeField] TextMeshProUGUI Gem;
    
    public void Scoresuh(int gem)
    {
        fullgems = fullgems + gem;
        Gem.text = "Gems: " + fullgems.ToString();
    }


}
