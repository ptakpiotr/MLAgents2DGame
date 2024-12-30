using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GhostScript : Agent
{
    public Rigidbody2D rigidbody;
    public float upForce = 0.2f;

    private Vector2 startingPos;

    public override void Initialize()
    {
        startingPos = transform.position;
    }

    public override void OnEpisodeBegin()
    {
        startingPos = transform.position;
        rigidbody.linearVelocity = Vector2.zero;
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        AddReward(0.1f);
        var vectorAction = actions.DiscreteActions.Array;
        Debug.Log(string.Join(",", vectorAction));
        if (Mathf.FloorToInt(vectorAction[0]) != 1) { return; }

        Jump();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Kiwi":
                AddReward(1f);
                break;
            case "Strawberry":
                AddReward(2f);
                break;
            case "Flag":
                AddReward(5f);
                break;
            default:
                if(collision.tag != "Player")
                {
                    AddReward(-1000f);
                    EndEpisode();
                    //Remove after training -> restarts position again 
                    SceneManager.LoadScene("SampleScene");
                }
                break;
        }
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var discreteActionsOut = actionsOut.DiscreteActions;
        discreteActionsOut[0] = Input.GetKey(KeyCode.Space) ? 1 : 0;
    }

    private void Jump()
    {
        rigidbody.linearVelocity = Vector2.zero;
        rigidbody.AddForce(new Vector2(0, upForce), ForceMode2D.Impulse);
        //Vector2.ClampMagnitude();
    }
}
