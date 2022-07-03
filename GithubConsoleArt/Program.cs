using System;
using System.Drawing;
using System.Drawing.Imaging;



#pragma warning disable CA1416 // Validate platform compatibility
Image Picture = Image.FromFile(@"C:\Users\johnd\Desktop\johndward01\imgs\Csharp_Logo_stretched.png");
#pragma warning restore CA1416 // Validate platform compatibility
Console.SetBufferSize((Picture.Width * 0x2), (Picture.Height * 0x2));
FrameDimension Dimension = new FrameDimension(Picture.FrameDimensionsList[0x0]);
int FrameCount = Picture.GetFrameCount(Dimension);
int Left = Console.WindowLeft, Top = Console.WindowTop;
char[] Chars = { '#', '#', '@', '%', '=', '+', '*', ':', '-', '.', ' ' };
Picture.SelectActiveFrame(Dimension, 0x0);
Thread.Sleep(10000);
for (int i = 0x0; i < Picture.Height; i++)
{
    Thread.Sleep(250);
    for (int x = 0x0; x < Picture.Width; x++)
    {
        Color Color = ((Bitmap)Picture).GetPixel(x, i);
        int Gray = (Color.R + Color.G + Color.B) / 0x3;
        int Index = (Gray * (Chars.Length - 0x1)) / 0xFF;
        Console.Write(Chars[Index]);
    }
    Console.Write('\n');
}
Console.SetCursorPosition(Left, Top);
Console.Read();