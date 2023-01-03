using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurtainController : MonoBehaviour {

        [Range(0,1)]
        public float close = 0;

        public float openScale = 0.75f; //amount of scale applied when the curtains are fully open.
        public float closedScale = 0.3f;//amount of scale applied when the curtains are fully closed.

        private Transform left_curtain;
        private Transform right_curtain;

        void Awake () {
            left_curtain = gameObject.transform.GetChild(0);
            right_curtain = gameObject.transform.GetChild(1);
        }

        void Update () {

            float scale = Mathf.Lerp(openScale,closedScale,close);

            if (left_curtain != null)
                left_curtain.localScale = new Vector3(1,scale,1);
            if (right_curtain != null)
                right_curtain.localScale = new Vector3(1,scale,1);

        }
    }
