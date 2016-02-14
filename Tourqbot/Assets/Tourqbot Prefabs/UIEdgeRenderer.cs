using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Tourqbot_Prefabs
{

    class UIEdgeRenderer : MonoBehaviour
    {

        public Color EditorColor = Color.yellow;
        public bool DrawInEditor = true;

        void OnDrawGizmos()
        {
            if (!DrawInEditor)
                return;

            var coliderPoints = GetComponent<EdgeCollider2D>().points;

            if (coliderPoints.Length < 2)
                return;

            Gizmos.color = EditorColor;

            for (var n = 0; n < coliderPoints.Length - 1; n++)
            {
                var firstPoint = coliderPoints[n];
                var secondPoint = coliderPoints[n + 1];

                var drawFrom = transform.position + new Vector3(firstPoint.x, firstPoint.y, 0);
                var drawTo = transform.position + new Vector3(secondPoint.x, secondPoint.y, 0);

                Gizmos.DrawLine(drawFrom, drawTo);
            }
        }
    }
}
