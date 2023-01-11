using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;


public class SubtitleClip : PlayableAsset

{
    public string subtitleText;
    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        var playble = ScriptPlayable<SubtitleBehaviuor>.Create(graph);
        SubtitleBehaviuor subtitleBehaviuor = playble.GetBehaviour();
        subtitleBehaviuor.subtitleText = subtitleText;
        return playble;

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
