using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform[] waypoints;

    private SpriteRenderer sprite;

    private Transform target;
    private int destPoint = 0;

    [SerializeField] private GameObject GameOverUI, objectToDestroy, kunai;

    private bool canMove;
    public static EnemyPatrol instance;

    [SerializeField] private Animator enemyAnimator;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("There is already an instance of EnemyPatrol in the scene.");
            return;
        }

        instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        canMove = true;
        target = waypoints[0];
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            // We need to calculate the direction where the destination is
            Vector3 dir = target.position - transform.position;
            transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
            Debug.Log("On bouge");

            // If the enemy reached is destination
            if (Vector3.Distance(transform.position, target.position) < 0.3f)
            {
                // His destination switch to the next point
                destPoint = (destPoint + 1) % waypoints.Length;
                target = waypoints[destPoint];
                Debug.Log("On change");

                sprite.flipX = !sprite.flipX;
            }
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Debug.Log("Death");


            // Stop player movement
            PlayerMovements.instance.rb.velocity = new Vector2(0, 0);

            // Disable all movements
            PlayerMovements.instance.enableMovements = false;
            KunaiRotation.instance.enableRotation = false;
            KunaiThrow.instance.enableThrow = false;

            // Active Game Over UI
            GameOverUI.gameObject.SetActive(true);

            Timer.instance.timerActive = false;
        }


        if (collision.transform.CompareTag("Kunai") && KunaiThrow.instance.isThrow == true)
        {
            canMove = false;
            enemyAnimator.SetTrigger("Explosion");
            StartCoroutine(EnemyDies());
        }
    }


    IEnumerator EnemyDies()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(objectToDestroy);
    }
}