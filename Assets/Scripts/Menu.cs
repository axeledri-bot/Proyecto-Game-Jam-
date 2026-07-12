using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private GameObject menu;
    private GameObject selector;
    private GameObject creditos;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        //menu = transform.GetChild(3).gameObject;
        //selector = transform.GetChild(4).gameObject;
        //creditos = transform.GetChild(5).gameObject;
        Cursor.visible = true;

    }
    public void Inicio()
    {

        SceneManager.LoadScene("No Penguin's Land");
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }
    public void Opciones()
    {
        menu.SetActive(false);
        selector.SetActive(true);
    }
    public void Creditos()
    {
        menu.SetActive(false);
        creditos.SetActive(true);
    }
    public void Regresar()
    {
        menu.SetActive(true);
        selector.SetActive(false);
        creditos.SetActive(false);
    }

    public void Salir()
    {
        Application.Quit();
    }
    
}
