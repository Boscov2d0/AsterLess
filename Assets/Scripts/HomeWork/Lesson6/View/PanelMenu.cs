using UnityEngine;
using UnityEngine.UI;

internal sealed class PanelMenu : BaseUi
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