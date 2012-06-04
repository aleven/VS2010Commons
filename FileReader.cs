using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace VS2010Commons
{
    public class FileReader
    {

        public FileReader()
        {

        }

        //public byte[] GetImg(String path)
        //{

        //    try
        //    {

        //        ReadableByteChannel channel = new FileInputStream(path).getChannel();

        //        ByteBuffer buf = ByteBuffer.allocateDirect(12000);

        //        byte[] result = new byte[12000];

        //        int numRead = 0;

        //        while (numRead >= 0)
        //        {

        //            buf.rewind();

        //            numRead = channel.read(buf);

        //            buf.rewind();

        //            for (int i = 0; i < numRead; i++)
        //            {

        //                byte b = buf.get();

        //                result[i] = b;

        //            }



        //        }

        //        return result;

        //    }

        //    catch (Exception e)
        //    {

        //        return null;

        //    }

        //}

        public static byte[] ReadFile(string filePath)
        {
            byte[] buffer;
            FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            try
            {
                int length = (int)fileStream.Length;  // get file length
                buffer = new byte[length];            // create buffer
                int count;                            // actual number of bytes read
                int sum = 0;                          // total number of bytes read

                // read until Read method returns 0 (end of the stream has been reached)
                while ((count = fileStream.Read(buffer, sum, length - sum)) > 0)
                    sum += count;  // sum is a buffer offset for next reading
            }
            finally
            {
                fileStream.Close();
            }
            return buffer;
        }
    }
}
