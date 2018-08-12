
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public Text endText;

    public void EndGame()
    {
        
        endText.gameObject.SetActive(true);
        
    }
}
