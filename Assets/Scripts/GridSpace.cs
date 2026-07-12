using TMPro;
using UnityEngine;

public class GridSpace : MonoBehaviour
{
    private bool isPlayerHere, isTargeted, isStart, isFinish, isObstacle;
    private int column, row;
    private string[] rowLetter = { "A", "B", "C", "D", "E", "F", "G", "H" };

    [SerializeField] private GameObject explosionSfx, targetMark, helicopterPrefab, heliGobj;
    [SerializeField] private GameObject[] obstacleArray;


    private void Update()
    {
        if (isPlayerHere && isFinish)
        {
            heliGobj.SetActive(true);
        }
    }



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
        heliGobj = Instantiate(helicopterPrefab, transform.position, transform.rotation);
        heliGobj.transform.SetParent(transform);
        heliGobj.SetActive(false);
    }
    public bool CheckIsObstacle()
    {
        return isObstacle;
    }
    public void ChangeObstacleStatus()
    {
        isObstacle = !isObstacle;
        if (isObstacle)
        {
            int i = Random.Range(0, obstacleArray.Length);
            if (i == 3)
            {
                obstacleArray[i].SetActive(true);
                int[] prettyAngles = { 90, 180, 270, 360 };
                obstacleArray[i].transform.Rotate(new Vector3(0, prettyAngles[Random.Range(0,prettyAngles.Length)],0));
            }
            else
            {
                obstacleArray[i].SetActive(true);
                obstacleArray[i].transform.Rotate(new Vector3(0, Random.Range(0, 360), 0));
            }
        }
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
    public void CheckForPlayer()
    {
        if (isPlayerHere)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>().KrillPlayer();
        }
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
