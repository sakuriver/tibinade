using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;
using System.IO.Compression;

public class Compressor
{
    public static byte[] Compress(byte[] rawData)
    {
        byte[] result = null;

        using (MemoryStream compressedStream = new MemoryStream())
        {
            using (GZipStream gZipStream = new GZipStream(compressedStream, CompressionMode.Compress))
            {
                gZipStream.Write(rawData, 0, rawData.Length);
            }
            result = compressedStream.ToArray();
        }

        return result;
    }

    public static byte[] Decompress(byte[] compressedData)
    {
        byte[] result = null;

        using (MemoryStream compressedStream = new MemoryStream(compressedData))
        {
            using (MemoryStream decompressedStream = new MemoryStream())
            {
                using (GZipStream gZipStream = new GZipStream(compressedStream, CompressionMode.Decompress))
                {
#if STREAM_COPY
                    gZipStream.CopyTo(decompressedStream);
#else
                    var buffer = new byte[1024];

                    for (; ; )
                    {
                        var len = gZipStream.Read(buffer, 0, buffer.Length);

                        if (len == 0)
                            break;

                        gZipStream.Write(buffer, 0, len);
                    }
#endif
                }
                    result = decompressedStream.ToArray();
            }
        }

        return result;
    }
}