using UnityEngine;

public class GridSpace : MonoBehaviour
{
    private bool isPlayerHere, isTargeted, isStart, isFinish;



    public void SetAsStart()
    {
        isStart = true;
    }
    public void SetAsFinish()
    {
        isFinish = true;
    }
}
