using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandManager : MonoBehaviour
{
    [SerializeField]
    public List<GameObject> hand = new List<GameObject>();

    public int listLength;
    public int storedListLength;

    public BattleSystem battleSystem;
    public GameObject cardAnchor;

    // Start is called before the first frame update
    void Start()
    {
        battleSystem = FindObjectOfType<BattleSystem>();
        listLength = hand.Count;
        storedListLength = 0;
    }

    // Update is called once per frame
    void Update()
    {
        listLength = hand.Count;
        cardAnchor.transform.position = new Vector3(transform.position.x - (hand.Count - 1) * 0.5f, transform.position.y, transform.position.z);

        SpreadHand();

        if (Input.GetMouseButtonDown(1))
        {
            hand.Remove(hand[hand.Count-1]);
        }
    }

    private void SpreadHand()
    {
        for (int i = 0; i < hand.Count; i++)
        {
            DraggableObject currentCard = hand[i].GetComponent<DraggableObject>();
            if (!currentCard.selected)
            {
                hand[i].transform.position = new Vector3((cardAnchor.transform.position.x) + (i * 1), transform.position.y, hand[i].transform.position.z);
            }     
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("card") && (!hand.Contains(collision.gameObject)))
        {
            hand.Add(collision.gameObject);
        }
    }

    /*private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("card"))
        {
            hand.Remove(collision.gameObject);
        }
    }*/
}
