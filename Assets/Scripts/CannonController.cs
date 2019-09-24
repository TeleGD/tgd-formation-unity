using UnityEngine;
using UnityEngine.UI; //permet de manipuler l'affichage de la force

//Le nom de la classe qui hérite de MonoBehavior doit avoir le même nom que le fichier
public class CannonController : MonoBehaviour
{
    public GameObject projectilePrefab; //projectile tiré par le canon
    public Slider forceIndicator; //slider indicateur de force (UI)

    private float position = 0; //position du canon sur l'axe X
    private float angle = 45; //angle du canon

    //La fonction update est appelée à chaque frame
    void Update()
    {
        //met à jour les variables qui représentent la position du canon...
        position = Mathf.Clamp(position + Input.GetAxis("Horizontal") * Time.deltaTime * 2, -5, 5);
        angle = Mathf.Clamp(angle - Input.GetAxis("Vertical") * Time.deltaTime * 20, 20, 80);

        //... puis on les applique au transform pour voir le changement dans Unity
        transform.position = new Vector3(position, 0, -3);
        transform.eulerAngles = new Vector3(angle, 0, 0);

        //On calcule la force du tir
        float force = 1 - Mathf.Abs(Mathf.Cos(Time.time));
        //On met à jour l'affichage de la force
        forceIndicator.value = force;

        //Si le joueur appuie sur Espace
        if(Input.GetButtonDown("Jump"))
        {
            //On calcule la position d'apparition de la pièce TGD...
            Vector3 coinPosition = transform.position + transform.up * 1.3f;
            //...puis on l'instancie dans la scène
            GameObject go = Instantiate(projectilePrefab, coinPosition, transform.rotation);

            //On applique une force sur la nouvelle pièce
            Rigidbody rb = go.GetComponent<Rigidbody>();
            rb.AddForce(transform.up * force * 10, ForceMode.Impulse);
            rb.angularVelocity = new Vector3(Random.Range(-2, 3), Random.Range(-2, 3), Random.Range(-2, 3));
        }
    }
}
