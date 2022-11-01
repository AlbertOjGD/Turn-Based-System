using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : StateMachine
    {
    [SerializeField]
    public GameObject prefab;
    public GameObject spawnedObj;
    public List<GameObject> cards = new List<GameObject>();
    public bool selecting;

        void Start()
        {
            //call for initial state machine state
            SetState(new Begin(this));
        }

        private void Update()
        {
            //spawn a prefab and add it to the 'cards' list
            if (Input.GetKeyDown(KeyCode.A))
            {
                AttackButtonPressed();
            }

            //remove the most recent prefab and clear it from the 'cards' list
            if (Input.GetKeyDown(KeyCode.S))
            {
                RemoveButtonPressed();
            }

            //remove all cards sequentially from the cards list
            if (Input.GetKeyDown(KeyCode.Space) && !selecting)
            {
                ResolveButtonPressed();
            }
        }

        public void AttackButtonPressed()
        {
            StartCoroutine(State.Attack());
        }

        public void RemoveButtonPressed()
        {
            StartCoroutine(State.Remove());
        }

        public void ResolveButtonPressed()
        {
            StartCoroutine(State.Resolve());
    }
}

