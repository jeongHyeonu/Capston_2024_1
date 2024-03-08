using UnityEngine;

public class Mirror : MonoBehaviour
{
    [SerializeField] private RenderTexture m_MirrorRenderTexture;
    bool capture = false;
    public void CaptureRenderTexture()
    {
        Texture2D texture = new Texture2D(m_MirrorRenderTexture.width, m_MirrorRenderTexture.height, TextureFormat.RGB24, false);

        RenderTexture.active = m_MirrorRenderTexture;
        texture.ReadPixels(new Rect(0, 0, m_MirrorRenderTexture.width, m_MirrorRenderTexture.height), 0, 0);
        texture.Apply();

        byte[] bytes = texture.EncodeToPNG();
        System.IO.File.WriteAllBytes("RenderTextureCapture.png", bytes);

        RenderTexture.active = null;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (capture == false)
            {
                CaptureRenderTexture();

            }
            /*if (capture == true)
            {
                transform.Translate(new Vector3(-3f, 0f, 0f));
            }*/
                
            capture = true;
        }
    }
}