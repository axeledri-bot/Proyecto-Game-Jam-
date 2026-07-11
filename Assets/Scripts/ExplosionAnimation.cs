using UnityEngine;

public class ExplosionAnimation : MonoBehaviour
{
    [SerializeField] private GameObject targetMark, gridSpace;

    public void removeMark()
    {
        targetMark.SetActive(false);
        gridSpace.GetComponent<GridSpace>().UnsetTarget();
    }

    public void DeactivateExplosion()
    {
        gameObject.SetActive(false);
    }
}
