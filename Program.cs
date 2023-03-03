// See https://aka.ms/new-console-template for more information

using MediaUnzipTool;
using SharpCompress.Archives;
using SharpCompress.Archives.Rar;
using SharpCompress.Archives.Zip;
using SharpCompress.Common;
using SharpCompress.Readers;


try
{
    var archive = ArchiveFactory.Open(@"E:\新建文件夹\h\微醺（老王）\微醺时刻\Pic.2",new ReaderOptions {Password = "233"});
    archive.WriteToDirectory(@"E:\新建文件夹\h\微醺（老王）\微醺时刻\T");
}
catch (Exception e)
{
    Console.WriteLine(e);
}

// UnzipTool.UnZip(@"E:\新建文件夹\h\微醺（老王）\微醺时刻\Pic.2",@"E:\新建文件夹\h\微醺（老王）\微醺时刻\T");