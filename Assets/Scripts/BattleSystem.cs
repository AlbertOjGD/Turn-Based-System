using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : StateMachine
    {
    [SerializeField]
    public GameObject prefab;
    public GameObject spawnedObj;
    public GridManager gm;
    public bool selecting;
    public bool paused;

        void Start()
        {
            gm = FindObjectOfType<GridManager>();
            //call for initial state machine state
            SetState(new Begin(this));
        }

        private void Update()
        {
            /*spawn a prefab and add it to the 'cards' list
            if (Input.GetKeyDown(KeyCode.A))
            {
                AttackButtonPressed();
            }

            //remove the most recent prefab and clear it from the 'cards' list
            if (Input.GetKeyDown(KeyCode.S))
            {
                RemoveButtonPressed();
            }*/

            //remove all cards sequentially from the cards list
            if (Input.GetKeyDown(KeyCode.Space) && !selecting)
            {
                ResolveButtonPressed();
            }

            if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
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

