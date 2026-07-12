using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausa : MonoBehaviour
{
    private GameObject pauser;

    public string escena;

    private void Start()
    {
        pauser = transform.GetChild(1).gameObject;
    }
    private void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape) )
        {
            pauser.SetActive(true);
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
        SceneManager.LoadScene("Menu");

    }
}
