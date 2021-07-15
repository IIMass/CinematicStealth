using UnityEngine;
using UnityEngine.Playables;

public class SkipCutscene : MonoBehaviour
{
    [SerializeField] private PlayableDirector director;
    [SerializeField] private float timeToSkip;

    private bool skipped;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S) && !skipped)
        {
            skipped = true;
            director.time = timeToSkip;
        }
    }
}
