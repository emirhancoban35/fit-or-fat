using UnityEngine;
using Zenject;

public class DefaultInstaller : MonoInstaller
{
    public GameManager gameManager;
    public override void InstallBindings()
    {
        Container.BindInstance(gameManager);
    }
}