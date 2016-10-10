using System;
using System.Threading.Tasks;

namespace NGraphics.Plugin.Autodetect
{
    public class AutodetectNGraphicsPlatform
    {
        private static readonly IPlatform NullPlat = new NullPlatform();

        static Lazy<IPlatform> Implementation = new Lazy<IPlatform>(() => CreatePlatform(), System.Threading.LazyThreadSafetyMode.PublicationOnly);

        private static IPlatform CreatePlatform()
        {
            #if PORTABLE
                        return NullPlat;
            #else
                        return Platforms.Current;
            #endif

        }

        internal static Exception NotImplementedInReferenceAssembly()
        {
            return new NotImplementedException("This functionality is not implemented in the portable version of this assembly.  You should reference the NuGet package from your main application project in order to reference the platform-specific implementation.");
        }

        public static IPlatform AutodetectNull { get { return NullPlat; } }

        public static IPlatform AutodetectCurrent
        {
            get
            {
                var ret = Implementation.Value;
                if (ret == null)
                {
                    throw NotImplementedInReferenceAssembly();
                }
                return ret;
            }
        }

    }

    public static class AutodetectGraphicFilesEx
    {
        public static async Task WriteSvgAsync(this Graphic g, string path)
        {
            using (var s = await AutodetectNGraphicsPlatform.AutodetectCurrent.OpenFileStreamForWritingAsync(path))
            {
                using (var w = new System.IO.StreamWriter(s, System.Text.Encoding.UTF8))
                {
                    g.WriteSvg(w);
                }
            }
        }
    }

}

