using Modules.Core.Abstract.Model;
using Runtime.Utility;
using strange.extensions.command.impl;
using UnityEngine;

public class OnSROptionsInjectionCommand : Command
{
    [Inject] public ProjectSROptions Options { get; set; }
    [Inject] public IGameModel GameModel { get; set; }

    public override void Execute()
    {
        if (!GameModel.IsEnableSrDebugger) return;
        SRDebug.Instance.AddOptionContainer(Options);
        Debug.Log("/SROptionsInjectionCommand/ ---> Execute");
    }
}