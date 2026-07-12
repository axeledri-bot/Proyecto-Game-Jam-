using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private GameObject[] levelArray;
    [SerializeField] private GameObject hacker;
    private int currentLevel;

    public void SelectRandomLevel()
    {
        currentLevel = Random.Range(0, levelArray.Length);

        levelArray[currentLevel].SetActive(true);

        hacker.GetComponent<HackerPenguin>().InitiatePenguin();
    }

    private void OnEnable()
    {
        SelectRandomLevel();
    }

    private void OnDisable()
    {
        levelArray[currentLevel].SetActive(false);
    }

    public void HackFailed()
    {
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().InformHackSuccesfulOrNot(false);
    }

}
