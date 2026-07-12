using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausa : MonoBehaviour
{
    [SerializeField] private GameObject pauser;
    [SerializeField] private GameObject menu;

    public string escena;

    private void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape) )
        {
            pauser.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;

        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            pauser.SetActive(false);
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void Regresar()
    {
        pauser.SetActive(false);
        Time.timeScale = 1;
    }
    public void Reiniciar()
    { 
        SceneManager.LoadScene(escena);
    }

    public void Menu()
    {
        Time.timeScale = 1;
        pauser.SetActive(false);
        menu.SetActive(true);
    }
}
