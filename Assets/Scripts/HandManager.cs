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
        cardAnchor.transform.position = new Vector3(transform.position.x - (hand.Count - 1) * 0.5f, transform.position.y, transform.position.z);

        //SpreadHand();
    }
}
