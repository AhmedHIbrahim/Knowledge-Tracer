using UnityEngine;

public class AnswerCell : MonoBehaviour
{

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            GameObject.Find("TileManager").SendMessage("ValidateAnswer", gameObject.tag);
            Destroy(gameObject.transform.parent.gameObject);
        }
    }
}
