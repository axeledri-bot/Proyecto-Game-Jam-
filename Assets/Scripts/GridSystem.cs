using UnityEngine;

public class GridSystem : MonoBehaviour
{
    // GRID CREATION VARIABLES
    private int columnRange, rowRange;
    private GameObject[,] gridSpaceArray;
    [SerializeField] private GameObject gridSpace;
    private GameObject startSpace, finishSpace;

    // GRID BOMBING VARIABLES
    [SerializeField] private int maxBombs = 3;
    private GameObject[] bombingSpaces;

    private void Awake()
    {
        columnRange = Random.Range(4, 8);
        rowRange = Random.Range(4, 8);
        StartGrid();

        bombingSpaces = new GameObject[maxBombs];
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SelectAllRandomSpace();
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            for (int i = 0; i < maxBombs; i++)
            {
                bombingSpaces[i].GetComponent<GridSpace>().LooseBombs();
            }
        }
    }

    public void StartGrid()
    {
        gridSpaceArray = new GameObject[columnRange, rowRange];

        for (int x = 0; x < columnRange; x++)
        {
            for (int y = 0; y < rowRange; y++)
            {

                //GameObject newGridSpace = new GameObject($"gridCoordinate {x},{y}", typeof());
                GameObject newGridSpace = Instantiate(gridSpace, transform.position, transform.rotation);

                newGridSpace.transform.SetParent(transform);
                newGridSpace.transform.localPosition = transform.localPosition + new Vector3(x, -.05f, y);

                if (y == rowRange - 1 && x == 0)
                {
                    newGridSpace.GetComponent<GridSpace>().SetAsStart();
                    newGridSpace.GetComponent<Renderer>().material.color = Color.red;
                    startSpace = newGridSpace;
                }
                if (x == columnRange - 1 && y == 0)
                {
                    newGridSpace.GetComponent<GridSpace>().SetAsFinish();
                    newGridSpace.GetComponent<Renderer>().material.color = Color.cyan;
                    finishSpace = newGridSpace;
                }


                newGridSpace.GetComponent<GridSpace>().SetCoordinates(x, y);
                gridSpaceArray[x, y] = newGridSpace;

            }
        }
    }


    public GameObject GetStartSpace()
    {
        return startSpace;
    }

    public bool CheckSpace(int column, int row)
    {
        if (column >= columnRange || row >= rowRange || column < 0 || row < 0)
        {
            return false;
        }
        if (gridSpaceArray[column, row].GetComponent<GridSpace>().CheckIsObstacle())
        {
            return false;
        }
        return true;

    }
    public GameObject GetSpace(int column, int row)
    {
        return gridSpaceArray[column, row];
    }

    public void SelectAllRandomSpace()
    {
        for (int i = 0; i < maxBombs; i++)
        {
            bombingSpaces[i] = GetSpace(Random.Range(0, columnRange), Random.Range(0, rowRange));
            if (!bombingSpaces[i].GetComponent<GridSpace>().CheckIsTarget())
            {
                bombingSpaces[i].GetComponent<GridSpace>().SetTarget();
            }
            else
            {
                bombingSpaces[i] = null;
                i--;
            }
        }
    }

    public void SelectSemiRandomSpace()
    {

    }

    public void selectFullLockSpace()
    {

    }
}
