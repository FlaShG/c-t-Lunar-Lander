using UnityEngine;
using UnityEditor;

public class TestOutputGroups
{
    [MenuItem("Edit/Scene Tests/Test Audio Source Ouput Groups")]
    public static void TestAudioSourceOutputGroups()
    {
        var sources = Object.FindObjectsOfType<AudioSource>();
        var okay = true;
        foreach(var source in sources)
        {
            if(source.outputAudioMixerGroup == null)
            {
                Debug.LogAssertion("This AudioSource doesn't have an Audio Mixer Ouput Group.", source);
                okay = false;
            }
        }

        if(okay)
        {
            Debug.Log("All AudioSources have Audio Mixer Ouput Groups.");
        }
    }
}
