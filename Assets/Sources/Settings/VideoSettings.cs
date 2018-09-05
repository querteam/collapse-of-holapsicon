using UnityEngine;

namespace Settings.Video
{
    
    public class VideoSettings
    {
        private Resolution m_Resolution;
        public Resolution Resolution
        {
            get
            {
                return m_Resolution;
            }
            set
            {
                m_Resolution = value;
                Screen.SetResolution(
                    m_Resolution.width,
                    m_Resolution.height,
                    displayMode,
                    m_Resolution.refreshRate);
            }
        }


        public FullScreenMode displayMode = FullScreenMode.FullScreenWindow;

        public GameRenderQuality gameRenderQuality = new GameRenderQuality();
        public TerrainRenderQuality terrainRenderQuality = new TerrainRenderQuality();
        public ShadowsRenderQuality shadowsQuality = new ShadowsRenderQuality();
        public ShadersRenderQuality shadersQuality = new ShadersRenderQuality();


    }

    public class RenderQualityProp
    {
        public string[] names = new[]
        {
            "Ultra",
            "Very High",
            "High",
            "Normal",
            "Medium",
            "Low"
        };

        public int value;
    }

    public class GameRenderQuality : RenderQualityProp { }
    public class TerrainRenderQuality : RenderQualityProp { }
    public class ShadowsRenderQuality : RenderQualityProp { }
    public class ShadersRenderQuality : RenderQualityProp { }

}
