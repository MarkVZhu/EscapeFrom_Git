using UnityEngine;

public class PassDialog : MonoBehaviour
{
    public GameObject enterDialog;
    public GameObject dialog;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            enterDialog.SetActive(false);
            dialog.SetActive(false);
            GameObject.Find("Player").GetComponent<PlayerController>().movementSpeed = 4;
            GameObject.Find("Player").GetComponent<PlayerController>().allowedJumps = 2;
        }
    }
}
