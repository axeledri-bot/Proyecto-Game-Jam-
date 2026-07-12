using UnityEngine;

public class CameraAlign : MonoBehaviour
{

    [SerializeField] private GameObject gridSysObj;
    private GridSystem gridSys;

    private int posX, posY;

    private void Start()
    {
        gridSys = gridSysObj.GetComponent<GridSystem>();

        gridSys.GetGridRange(out posX, out posY);
        transform.position = new Vector3(posX / 2, transform.position.y, (posY / 2)-4);

    }

}
