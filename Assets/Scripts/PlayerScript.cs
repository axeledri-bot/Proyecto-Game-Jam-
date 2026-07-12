using System.Collections;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    [SerializeField] private GameObject gridSystemObj;
    private GridSystem gridSystem;


    private int currentColumn, currentRow;
    private GameObject currentGridSpace, targetGridSpace;

    [SerializeField] private float movVel, rotVel;
    private bool canIMove;

    [SerializeField] GameObject animatorGbj;
    private Animator animator;
    private bool isDed;

    private void Start()
    {
        gridSystem = gridSystemObj.GetComponent<GridSystem>();

        SnapToPlace(gridSystem.GetStartSpace());

        animator = animatorGbj.GetComponent<Animator>();

        //canIMove = true;

    }

    private void Update()
    {
        if (canIMove)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                if (gridSystem.CheckSpace(currentColumn, currentRow + 1))
                {
                    //MoveToSpace(gridSystem.GetSpace(currentColumn, currentRow + 1));
                    StartCoroutine(RotatePlayer(Quaternion.Euler(0, 90, 0), gridSystem.GetSpace(currentColumn, currentRow + 1)));
                    canIMove = false;
                }
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                if (gridSystem.CheckSpace(currentColumn, currentRow - 1))
                {
                    //MoveToSpace(gridSystem.GetSpace(currentColumn, currentRow - 1));
                    StartCoroutine(RotatePlayer(Quaternion.Euler(0, 270, 0), gridSystem.GetSpace(currentColumn, currentRow - 1)));
                    canIMove = false;
                }
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                if (gridSystem.CheckSpace(currentColumn + 1, currentRow))
                {
                    //MoveToSpace(gridSystem.GetSpace(currentColumn + 1, currentRow));
                    StartCoroutine(RotatePlayer(Quaternion.Euler(0, 180, 0), gridSystem.GetSpace(currentColumn + 1, currentRow)));
                    canIMove = false;
                }
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                if (gridSystem.CheckSpace(currentColumn - 1, currentRow))
                {
                    //MoveToSpace(gridSystem.GetSpace(currentColumn - 1, currentRow));
                    StartCoroutine(RotatePlayer(Quaternion.Euler(0, 0, 0), gridSystem.GetSpace(currentColumn - 1, currentRow)));
                    canIMove = false;
                }
            }
        }
    }

    private void SnapToPlace(GameObject gridPos)
    {
        if (currentGridSpace != null)
        {
            currentGridSpace.GetComponent<GridSpace>().ChangePlayerStatus();
        }
        currentGridSpace = gridPos;
        transform.position = new Vector3(gridPos.transform.position.x, transform.position.y, gridPos.transform.position.z);
        currentGridSpace.GetComponent<GridSpace>().GetCoordinates(out currentColumn, out currentRow);
        currentGridSpace.GetComponent<GridSpace>().ChangePlayerStatus();
    }
    private void MoveToSpace(GameObject gridPos)
    {
        if (currentGridSpace != null)
        {
            currentGridSpace.GetComponent<GridSpace>().ChangePlayerStatus();
        }

        Vector3 targetPos = new Vector3(gridPos.transform.position.x, transform.position.y, gridPos.transform.position.z);
        StartCoroutine(MoveToTarget(targetPos, gridPos));
    }

    private IEnumerator MoveToTarget(Vector3 targetPos, GameObject gridPos)
    {
        while (transform.position != targetPos)
        {
            animator.SetBool("IsRunning", true);
            transform.position = Vector3.MoveTowards(transform.position, targetPos, movVel * Time.deltaTime);
            yield return null;
        }
        if (transform.position == targetPos)
        {
            currentGridSpace = gridPos;
            currentGridSpace.GetComponent<GridSpace>().GetCoordinates(out currentColumn, out currentRow);
            currentGridSpace.GetComponent<GridSpace>().ChangePlayerStatus();

            animator.SetBool("IsRunning", false);

            //canIMove = true;
            StartCoroutine(GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().ManageBombs());
        }
    }

    private IEnumerator RotatePlayer(Quaternion targetRot, GameObject gridPos)
    {
        while (Quaternion.Angle(transform.rotation, targetRot) != 0)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRot, rotVel * Time.deltaTime);
            yield return null;
        }
        MoveToSpace(gridPos);
    }

    public void GetPlayerCoordinates(out int x, out int y)
    {
        currentGridSpace.GetComponent<GridSpace>().GetCoordinates(out x, out y);
    }

    public void KrillPlayer()
    {
        isDed = true;
        animator.SetBool("isDed", isDed);
    }

    public void GrantPlayerMove()
    {
        canIMove = true;
    }

    public bool CheckIsDed()
    {
        return isDed;
    }
}
