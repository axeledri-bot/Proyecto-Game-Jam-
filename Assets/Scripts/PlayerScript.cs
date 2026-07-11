using System;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    [SerializeField] private GameObject gridSystemObj;
    private GridSystem gridSystem;

    private int currentColumn, currentRow;

    private void Start()
    {
        gridSystem = gridSystemObj.GetComponent<GridSystem>();

        MoveToSpace(gridSystem.GetStartSpace());

    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.W))
        {
            if(gridSystem.CheckSpace(currentColumn, currentRow + 1))
            {
                MoveToSpace(gridSystem.GetSpace(currentColumn, currentRow + 1));
            }
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (gridSystem.CheckSpace(currentColumn, currentRow - 1))
            {
                MoveToSpace(gridSystem.GetSpace(currentColumn, currentRow - 1));
            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (gridSystem.CheckSpace(currentColumn + 1, currentRow))
            {
                MoveToSpace(gridSystem.GetSpace(currentColumn + 1, currentRow));
            }
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (gridSystem.CheckSpace(currentColumn - 1, currentRow))
            {
                MoveToSpace(gridSystem.GetSpace(currentColumn - 1, currentRow));
            }
        }
    }


    private void MoveToSpace(GameObject startPos)
    {
        transform.position = new Vector3(startPos.transform.position.x, transform.position.y, startPos.transform.position.z);
        startPos.GetComponent<GridSpace>().GetCoordinates(out currentColumn, out currentRow);
    }

}
