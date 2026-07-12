using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    //[SerializeField] private GameObject selector;
    [SerializeField] private GameObject creditos;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

    }
    public void Inicio()
    {
        menu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    //public void Opciones()
    //{
    //    menu.SetActive(false);
    //    selector.SetActive(true);
    //}
    public void Creditos()
    {
        menu.SetActive(false);
        creditos.SetActive(true);
    }
    public void Regresar()
    {
        menu.SetActive(true);
        //selector.SetActive(false);
        creditos.SetActive(false);
    }

    public void Salir()
    {
        Application.Quit();
    }

}
