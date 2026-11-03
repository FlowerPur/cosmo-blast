using UnityEngine;

public abstract class Menu : MonoBehaviour
{
    protected void SwitchTo(Menu menu)
    {
        menu.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
}
