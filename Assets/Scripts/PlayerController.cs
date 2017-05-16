using UnityEngine;

public class PlayerController : MonoBehaviour {

    bool isTransferring = false;
    ActorController[] actors;
    ActorController currentActor;

	void Start () {
        actors = GetComponentsInChildren<ActorController>();
        foreach (ActorController actor in actors)
        {
            if (actor.isActiveAndEnabled)
            {
                currentActor = actor;
            }
        }
    }

	void FixedUpdate () {
		if (isTransferring)
        {
            if (Input.GetMouseButtonDown (0))
            {
                ChooseTarget();
            }
        }
	}

    public void TransferConsciousness ()
    {
        isTransferring = true;
        currentActor.enabled = false;
    }

    public void CancelTransfer ()
    {
        isTransferring = false;
    }

    void ChooseTarget ()
    {
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y), Vector2.zero, 0f);

        if (hit.transform.CompareTag ("PlayableActor"))
        {
            ActorController actorController = hit.transform.GetComponent<ActorController>();
            if (actorController != null)
            {
                currentActor.enabled = false;
                actorController.enabled = true;
                currentActor = actorController;
            }
        }
    }
}
