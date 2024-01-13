using UnityEngine;

public class WeaponsReaload : MonoBehaviour
{
    [SerializeField] private PlayerShoot playershoot;
    public Animation reloadAnim;
    bool reload = false;


    public void Reload()
    {
        reloadAnim.Play();
        playershoot.ammount = 10;
    }
}
