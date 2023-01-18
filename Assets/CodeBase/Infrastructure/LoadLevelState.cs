﻿using CodeBase.CameraLogic;
using UnityEngine;

namespace CodeBase.Infrastructure
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private const string InitialPointTag = "InitialPoint";

        private readonly GameStateMachine gameStateMachine;
        private readonly SceneLoader sceneLoader;
        private readonly LoadingCurtain loadingCurtain;
        private readonly IGameFactory gameFactory;

        public LoadLevelState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, LoadingCurtain loadingCurtain)
        {
            this.gameStateMachine = gameStateMachine;
            this.sceneLoader = sceneLoader;
            this.loadingCurtain = loadingCurtain;
        }

        public void Enter(string sceneName)
        {
            loadingCurtain.Show();
            sceneLoader.Load(sceneName, OnLoaded);
        }
        
        public void Exit() => loadingCurtain.Hide();

        private void OnLoaded()
        {
            var hero = gameFactory.CreateHero(at: GameObject.FindWithTag(InitialPointTag));
            CameraFollow(hero);

            gameFactory.CreateHud();
            
            gameStateMachine.Enter<GameLoopState>();
        }

        private void CameraFollow(GameObject follower) => 
            Camera.main.GetComponent<CameraFollow>().Follow(follower);
    }
}