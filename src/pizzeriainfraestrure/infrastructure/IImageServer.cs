using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IImageServer
{
    ValueTask<IEnumerable<String>> GetImages(byte[] image);
}