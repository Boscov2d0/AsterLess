using UnityEngine;
using UnityEngine.UI;

internal sealed class PanelSettings : BaseUi
{
    public override void Execute()
    {
        gameObject.SetActive(true);
    }
    public override void Cancel()
    {
        gameObject.SetActive(false);
    }
}