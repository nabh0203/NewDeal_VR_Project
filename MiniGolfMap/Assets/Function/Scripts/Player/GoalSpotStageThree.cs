using System.Collections;
using UnityEngine;

public class GoalSpotStageThree : MonoBehaviour
{
    public GameObject Player;
    //public GameObject GoalParticle;
    public Transform NextStage;
    public float delay = 2.0f; // Unity �����Ϳ��� ���� ������ ������ �ð�

    private void OnTriggerEnter(Collider other)
    {
        // Ʈ���ſ� �������� �� ����Ǵ� �Լ�
        MoveToTargetPosition();
        VR_Fade_NBH.instance.FadeOut();
        //Instantiate(GoalParticle, transform.position , Quaternion.identity);
    }

    public void MoveToTargetPosition()
    {
        StartCoroutine(MoveAfterDelay(delay));
    }

    private IEnumerator MoveAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        if (Player == null)
        {
            Debug.LogError("Player is not assigned in GoalSpot script.");
            yield break;
        }

        if (NextStage == null)
        {
            Debug.LogError("NextStage is not assigned in GoalSpot script.");
            yield break;
        }

        // ���� ������Ʈ�� NextStage�� ��ġ�� �̵���ŵ�ϴ�.
        Player.transform.position = NextStage.position;

        // �÷��̾��� y�� ȸ�� ������ -90���� �����մϴ�.
        Player.transform.rotation = Quaternion.Euler(0, 90, 0);

        Debug.Log("Player moved to the next stage position after delay.");
    }
}
