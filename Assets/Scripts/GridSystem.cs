using UnityEngine;

public class GridSystem : MonoBehaviour
{
    // GRID CREATION VARIABLES
    private int columnRange, rowRange;
    private GameObject[,] gridSpaceArray;
    [SerializeField] private GameObject gridSpace, bunker;
    private GameObject startSpace, finishSpace;

    // GRID BOMBING VARIABLES
    [SerializeField] private int maxBombs = 4, maxObstacles = 5;
    private GameObject[] bombingSpaces;
    private PlayerScript playerScript;

    private void Awake()
    {
        columnRange = Random.Range(6, 8);
        rowRange = Random.Range(6, 8);
        StartGrid();
        PlaceObstacles();

        bombingSpaces = new GameObject[maxBombs];
    }

    private void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SelectFullLockSpace();
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            for (int i = 0; i < maxBombs; i++)
            {
                bombingSpaces[i].GetComponent<GridSpace>().LooseBombs();
            }
        }
    }

    public void GetGridRange(out int col, out int row)
    {
        col = columnRange;
        row = rowRange;
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

        int bunkerX, bunkerY;
        startSpace.GetComponent<GridSpace>().GetCoordinates(out bunkerX, out bunkerY);
        Instantiate(bunker, new Vector3(bunkerX - 1, 0, bunkerY + 1), Quaternion.Euler(0, 135, 0));
    }

    public void PlaceObstacles()
    {
        int startX, startY, finishX, finishY, randomX, randomY;
        startSpace.GetComponent<GridSpace>().GetCoordinates(out startX, out startY);
        finishSpace.GetComponent<GridSpace>().GetCoordinates(out finishX, out finishY);

        for (int i=0; i < maxObstacles; i++)
        {
            while (true)
            {
                randomX = Random.Range(0, columnRange);
                randomY = Random.Range(0, rowRange);
                if (randomX == startX && randomY == startY || randomX == startX + 1 && randomY == startY || randomX == startX && randomY == startY - 1 ||
                    randomX == finishX && randomY == finishY || randomX == finishX - 1 && randomY == finishY || randomX == finishX && randomY == finishY + 1 ||
                    GetSpace(randomX, randomY).GetComponent<GridSpace>().CheckIsObstacle())
                {
                }
                else
                {
                    GetSpace(randomX, randomY).GetComponent<GridSpace>().ChangeObstacleStatus();
                    break;
                }
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
        for (int i = 0; i < maxBombs - 1; i++)
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
        int playerX, playerY, checkX, checkY;
        playerScript.GetPlayerCoordinates(out playerX, out playerY);

        for (int i = 0; i < maxBombs - 1; i++)
        {
            checkX = Random.Range(playerX - 1, playerX + 2);
            checkY = Random.Range(playerY - 1, playerY + 2);

            if (CheckSpace(checkX, checkY))
            {
                bombingSpaces[i] = GetSpace(checkX, checkY);
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
            else
            {
                i--;
            }
        }
    }

    public void SelectFullLockSpace()
    {
        int playerX, playerY, checkX, checkY;
        playerScript.GetPlayerCoordinates(out playerX, out playerY);

        for (int i = 0; i < maxBombs; i++)
        {
            checkX = Random.Range(playerX - 1, playerX + 2);
            checkY = Random.Range(playerY - 1, playerY + 2);

            if (CheckSpace(checkX, checkY))
            {
                bombingSpaces[i] = GetSpace(checkX, checkY);
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
            else
            {
                i--;
            }
        }
    }

}
