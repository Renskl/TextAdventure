using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Adventure
{
    public static class TextureManager
    {
        public static Dictionary<string, int> LoadedTextures = new Dictionary<string, int>();

        public static int LoadTexture(string filename)
        {
            if (!String.IsNullOrEmpty(filename))
            {
                if (LoadedTextures.ContainsKey(filename))
                    return LoadedTextures[filename];
                else
                {
                    int id = GL.GenTexture();
                    GL.BindTexture(TextureTarget.Texture2D, id);
                    GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
                    GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);
                    if (File.Exists(filename))
                    {
                        Bitmap bmp = new Bitmap(filename);
                        BitmapData bmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                        GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, bmpData.Width, bmpData.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, bmpData.Scan0);
                        bmp.UnlockBits(bmpData);
                        return id;
                    }
                    else
                    {
                        Logger.Log(Logger.Severity.WARNING, String.Format("Could not find or load Texture {0}", filename));
                        return -1;
                    }
                    
                }
            }
            else
            {
                Logger.Log(Logger.Severity.ERROR, String.Format("Could not find or load Texture {0}. The filename provided is invalid.", filename));
                return -1;
            }
        }
    }
}
