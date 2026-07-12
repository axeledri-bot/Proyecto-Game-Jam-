using System.Collections;
using System.Threading;
using UnityEngine;

public class GameManager : MonoBehaviour
{


    [SerializeField] private GameObject player, transmisionCanv, soldadoCanv, gridSys;

    [SerializeField] private float maxTimer;

    private bool hackSuccesful;

    private void Start()
    {
        StartCoroutine(TimerToMinigame());
    }

    public IEnumerator TimerToMinigame()
    {
        yield return new WaitForSeconds(maxTimer);

        soldadoCanv.SetActive(true);
    }

    public void ActivateMinigame()
    {
        transmisionCanv.SetActive(true);
    }

    public void CloseMinigame()
    {
        transmisionCanv.SetActive(false);
    }

    public void InformHackSuccesfulOrNot(bool status)
    {
        hackSuccesful = status;
        CloseMinigame();
        player.GetComponent<PlayerScript>().GrantPlayerMove();
    }

    public bool CheckForPlayer()
    {
        return player.GetComponent<PlayerScript>().CheckIsDed();
    }

    public IEnumerator ManageBombs()
    {
        if (hackSuccesful)
        {
            gridSys.GetComponent<GridSystem>().SelectAllRandomSpace();
        }
        else
        {
            gridSys.GetComponent<GridSystem>().SelectFullLockSpace();
        }

        yield return new WaitForSeconds(maxTimer);

        gridSys.GetComponent<GridSystem>().DropBombs();

        yield return new WaitForSeconds(maxTimer);

        if (CheckForPlayer())
        {

        }
        else
        {
            StartCoroutine(TimerToMinigame());
        }
    }

}
