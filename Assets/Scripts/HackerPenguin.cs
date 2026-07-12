using System.Collections;
using UnityEngine;

public class HackerPenguin : MonoBehaviour
{

    private NodeInfo currentNode;
    private int markedInput;
    private bool readyToMove, receivedInpt;

    [SerializeField] private float vel;

    private void Start()
    {
        InitiatePenguin();
    }

    private void Update()
    {
        if (readyToMove)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                markedInput = 0;
                receivedInpt = true;
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                markedInput = 1;
                receivedInpt = true;
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                markedInput = 2;
                receivedInpt = true;
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                markedInput = 3;
                receivedInpt = true;
            }
        }
        if (receivedInpt)
        {
            if (markedInput == currentNode.prevInpt && currentNode.prevNode != null)
            {
                StartCoroutine(MoveToNode(currentNode.prevNode.transform.position, currentNode.prevNode.GetComponent<NodeInfo>()));
            }
            if (markedInput == currentNode.nextInpt && currentNode.nextNode != null)
            {
                StartCoroutine(MoveToNode(currentNode.nextNode.transform.position, currentNode.nextNode.GetComponent<NodeInfo>()));
            }
            if (markedInput == currentNode.otherInpt && currentNode.otherNode != null)
            {
                StartCoroutine(MoveToNode(currentNode.otherNode.transform.position, currentNode.otherNode.GetComponent<NodeInfo>()));
            }
            receivedInpt = false;
        }
    }

    public void InitiatePenguin()
    {
        currentNode = GameObject.FindGameObjectWithTag("StartingNode").GetComponent<NodeInfo>();

        transform.position = currentNode.transform.position;

        readyToMove = true;
    }

    private IEnumerator MoveToNode(Vector3 targetPos, NodeInfo node)
    {
        readyToMove = false;
        while (transform.position != targetPos)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, vel * Time.deltaTime);
            yield return null;
        }
        if (transform.position == targetPos)
        {
            currentNode = node;
            readyToMove = true;
        }
    }
}
