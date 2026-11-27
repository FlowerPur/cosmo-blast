using UnityEngine;

namespace CosmoBlast.Menus
{
    public abstract class Menu : MonoBehaviour
    {
        protected void SwitchTo(Menu menu)
        {
            menu.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
