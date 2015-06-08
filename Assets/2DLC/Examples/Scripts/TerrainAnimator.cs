using UnityEngine;
using System.Collections;
using _2DLC.Comps;
using _2DLC.Beans;
using System.Collections.Generic;
using _2DLC.Core;

namespace _2DLC.Examples {
    [RequireComponent(typeof(Terrain2D))]
    public class TerrainAnimator : MonoBehaviour {

        public string animPoints;

        private Terrain2D terrain2D;
        private T2DRenderer t2DRenderer;
        private List<int> animPointsList = new List<int>();
        private float oldTime;
        private bool sumUp = true;

        void Start() {
            terrain2D = gameObject.GetComponent<Terrain2D>();
            t2DRenderer = new T2DRenderer(terrain2D);
            string[] nums = animPoints.Split(',');
            foreach (string s in nums) {
                animPointsList.Add(int.Parse(s.Trim()));
            }
        }

        void Update() {
            if (Time.time - oldTime >= 0.8f) {
                List<Point> pointList = terrain2D.GetPoints();
                bool more = sumUp;

                for (int i = 0; i < pointList.Count; i++) {
                    if (animPointsList.Contains(i)) {
                        if (more) {
                            pointList[i].pos.y += 0.5f;
                        } else {
                            pointList[i].pos.y -= 0.5f;
                        }
                        more = !more;
                    }
                }

                terrain2D.points = pointList.ToArray();
                //terrain2D.savedRender = !terrain2D.render;
                t2DRenderer.Render();

                sumUp = !sumUp;
                oldTime = Time.time;
            }
        }
    }
}
