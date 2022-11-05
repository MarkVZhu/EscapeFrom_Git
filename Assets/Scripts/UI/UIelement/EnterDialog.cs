using UnityEngine;

public class EnterDialog : MonoBehaviour
{
    public GameObject enterDialog;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<PlayerController>().movementSpeed = 0;
            collision.GetComponent<PlayerController>().allowedJumps = 0;
            enterDialog.SetActive(true);
        }
    }
}
