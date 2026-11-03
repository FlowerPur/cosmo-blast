using UnityEngine;

public abstract class Menu : MonoBehaviour
{
    protected void TransitionToMenu(GameObject menu)
    {
        menu.SetActive(true);
        gameObject.SetActive(false);
    }
}
