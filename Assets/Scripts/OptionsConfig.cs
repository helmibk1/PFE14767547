using UnityEngine;

public class OptionsConfig : MonoBehaviour
{
    [System.Serializable]
    public class Option
    {
        [HideInInspector]
        public string name;
        public bool enabled;
        public GameObject m_Object;
    }

    public Option[] options;

    public bool AnyOptionsEnabled()
    {
        foreach (Option o in options)
        {
            if (o.enabled)
                return true;
        }
        return false;
    }
}
