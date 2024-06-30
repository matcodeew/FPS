using UnityEngine;

public class WeaponsReaload : MonoBehaviour
{
    [SerializeField] private PlayerShoot playershoot;
    [SerializeField] private PlayerCamera plauerUi;
    public Animation reloadAnim;


    public void Reload()
    {
        reloadAnim.Play();
        playershoot.ammount = 10;
        plauerUi.CreateMunitionSprite();
    }
}
