using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Nez;

namespace Acrostic
{
    public class BaseScene : Scene
    {
        public BaseScene() : base()
        {
            ClearColor = Color.Black;
        }

        public BaseScene NextScene;
        public SceneTransition Transition;
        public bool Transitioning = true;

        public void LoadNextScene(BaseScene scene)
        {
            NextScene = scene;
            SceneTransition Transition = new FadeTransition(() => NextScene);
            Transition.OnTransitionCompleted = TransitionComplete;
            Core.StartSceneTransition(Transition);
        }

        public void TransitionComplete()
        {
            NextScene.Transitioning = false;
        }

        public IEnumerator TransitionRoutine()
        {
            SceneTransition Transition = new FadeTransition(() => NextScene);
            yield return null;
        }
    }
}
