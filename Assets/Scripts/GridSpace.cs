using TMPro;
using UnityEngine;

public class GridSpace : MonoBehaviour
{
    private bool isPlayerHere, isTargeted, isStart, isFinish, isObstacle;
    private int column, row;
    private string[] rowLetter = { "A", "B", "C", "D", "E", "F", "G", "H" };

    [SerializeField] private GameObject explosionSfx, targetMark;

    public void SetCoordinates(int x, int y)
    {
        column = x;
        row = y;
    }

    public void GetCoordinates(out int x, out int y)
    {
        x = column;
        y = row;
    }

    public void SetAsStart()
    {
        isStart = true;
    }
    public void SetAsFinish()
    {
        isFinish = true;
    }
    public bool CheckIsObstacle()
    {
        return isObstacle;
    }
    public bool CheckIsTarget()
    {
        return isTargeted;
    }
    public void SetTarget()
    {
        isTargeted = true;
        targetMark.SetActive(true);
    }
    public void UnsetTarget()
    {
        isTargeted = false;
    }
    public void LooseBombs()
    {
        explosionSfx.SetActive(true);
    }
    public void ChangePlayerStatus()
    {
        isPlayerHere = !isPlayerHere;
    }
}
