using Unity.VisualScripting;
using UnityEngine;

public class GridSystem : MonoBehaviour
{

    private int columnRange, rowRange;

    private GameObject[,] gridSpaceArray;
    [SerializeField] private GameObject gridSpace;

    private void Awake()
    {
        columnRange = Random.Range(6, 11);
        rowRange = Random.Range(5, 9);

        StartGrid();
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
                }
                if (x == columnRange - 1 && y == 0)
                {
                    newGridSpace.GetComponent<GridSpace>().SetAsFinish();
                }

                gridSpaceArray[x, y] = newGridSpace;

            }
        }
    }

}
