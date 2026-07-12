using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    
    public void TurnOff()
    {
        gameObject.SetActive(false);
    }

    public void HeliPicksPlayer()
    {
        GameObject.FindGameObjectWithTag("Player").SetActive(false);
        transform.parent.GetComponent<GridSpace>().ChangePlayerStatus();
    }

    public void GamemanagerActivateMinigame()
    {
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().ActivateMinigame();
        TurnOff();
    }
}
