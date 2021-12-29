using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace _7DaysToDieUtils.Utils
{
    public class ImageUtils
    {
		/// <summary>
		/// 图片转为base64编码的字符串
		/// </summary>
		/// <param name="filePath"></param>
		/// <param name="format"></param>
		/// <returns></returns>
		public static string ImgToBase64String(string filePath, ImageFormat format)
		{
			try
			{
				Bitmap bmp = new Bitmap(filePath);

				MemoryStream ms = new MemoryStream();
				bmp.Save(ms, format);
				byte[] arr = new byte[ms.Length];
				ms.Position = 0;
				ms.Read(arr, 0, (int)ms.Length);
				ms.Close();
				return Convert.ToBase64String(arr);
			}
			catch (Exception ex)
			{
				DialogUtils.ShowErrorDialog(ex);
				return null;
			}
		}

		/// <summary>
		/// base64编码的字符串转为图片
		/// </summary>
		/// <param name="strbase64"></param>
		/// <returns></returns>
		public static Bitmap Base64StringToImage(string strbase64, string savePath,ImageFormat format)
		{
			try
			{
				byte[] arr = Convert.FromBase64String(strbase64);
				MemoryStream ms = new MemoryStream(arr);
				Bitmap bmp = new Bitmap(ms);

				bmp.Save(savePath, format);
				ms.Close();
				return bmp;
			}
			catch (Exception ex)
			{
				DialogUtils.ShowErrorDialog(ex);
				return null;
			}
		}
	}
}
