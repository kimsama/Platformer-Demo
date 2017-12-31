using System;
using UnityEngine;


namespace UnityStandardAssets._2D
{
    public class CameraFollowExt : MonoBehaviour
    {
        public float xMargin = 1f; // Distance in the x axis the player can move before the camera follows.
        public float yMargin = 1f; // Distance in the y axis the player can move before the camera follows.
        public float xSmooth = 8f; // How smoothly the camera catches up with it's target movement in the x axis.
        public float ySmooth = 8f; // How smoothly the camera catches up with it's target movement in the y axis.
        public Vector2 maxXAndY; // The maximum x and y coordinates the camera can have.
        public Vector2 minXAndY; // The minimum x and y coordinates the camera can have.

		[SerializeField]
        private Transform target = null; // Reference to the player's transform.

        private bool CheckXMargin()
        {
            // Returns true if the distance between the camera and the player in the x axis is greater than the x margin.
            return Mathf.Abs(transform.position.x - target.position.x) > xMargin;
        }


        private bool CheckYMargin()
        {
            // Returns true if the distance between the camera and the player in the y axis is greater than the y margin.
            return Mathf.Abs(transform.position.y - target.position.y) > yMargin;
        }


        private void Update()
        {
            TrackPlayer();
        }


        private void TrackPlayer()
        {
            // By default the target x and y coordinates of the camera are it's current x and y coordinates.
            float targetX = transform.position.x;
            float targetY = transform.position.y;

            // If the player has moved beyond the x margin...
            if (CheckXMargin())
            {
                // ... the target x coordinate should be a Lerp between the camera's current x position and the player's current x position.
                targetX = Mathf.Lerp(transform.position.x, target.position.x, xSmooth*Time.deltaTime);
            }

            // If the player has moved beyond the y margin...
            if (CheckYMargin())
            {
                // ... the target y coordinate should be a Lerp between the camera's current y position and the player's current y position.
                targetY = Mathf.Lerp(transform.position.y, target.position.y, ySmooth*Time.deltaTime);
            }

            // The target x and y coordinates should not be larger than the maximum or smaller than the minimum.
            targetX = Mathf.Clamp(targetX, minXAndY.x, maxXAndY.x);
            targetY = Mathf.Clamp(targetY, minXAndY.y, maxXAndY.y);

            // Set the camera's position to the target position with the same z component.
            transform.position = new Vector3(targetX, targetY, transform.position.z);
        }
#if UNITY_EDITOR		
		void OnDrawGizmosSelected()
		{
			// カメラの移動可能な範囲(右下/左上)を取得
			Vector3 maxXMinY = new Vector3(maxXAndY.x, minXAndY.y);
			Vector3 minXMaxY = new Vector3 (minXAndY.x, maxXAndY.y);

			// カメラの移動範囲のGizmoを描画
			UnityEditor.Handles.DrawSolidRectangleWithOutline (
				new Vector3[]{ maxXAndY, maxXMinY, minXAndY, minXMaxY },
				new Color(1, 0, 0, 0.1f), Color.white);


			// カメラの描画する縦幅・横幅を取得
			Camera camera = GetComponent<Camera> ();
			float cameraWidthHalf = camera.orthographicSize * camera.aspect;
			Vector3 cameraMaxXMinY = new Vector2 (cameraWidthHalf, -camera.orthographicSize);
			Vector3 cameraMaxXMaxY = new Vector3 (cameraWidthHalf, camera.orthographicSize);

			// カメラの描画範囲のGizmoを描画描画			
			UnityEditor.Handles.DrawSolidRectangleWithOutline (new Vector3[]{
				maxXAndY + (Vector2)cameraMaxXMaxY, maxXMinY + cameraMaxXMinY,
				minXAndY - (Vector2)cameraMaxXMaxY, minXMaxY - cameraMaxXMinY
			}, new Color(1, 0, 0, 0.1f), Color.white);
		}
	}
#endif
}
