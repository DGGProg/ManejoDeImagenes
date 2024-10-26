using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManejoDeImagenes
{
    class Corte
    {
        internal static Image cortarImagen(Image pImagenEntrada)
        {


            BitmapData imagenOriginalDatos = ((Bitmap)pImagenEntrada).LockBits(new Rectangle(0, 0, pImagenEntrada.Width, pImagenEntrada.Height), ImageLockMode.ReadWrite, pImagenEntrada.PixelFormat);

            int altoImagen = imagenOriginalDatos.Height;
            int anchoImagen = imagenOriginalDatos.Width;
            Bitmap imagenSalida = new Bitmap(width: anchoImagen / 2,height: altoImagen / 2 ,format: pImagenEntrada.PixelFormat);
            BitmapData imagenSalidaDatos = imagenSalida.LockBits(new Rectangle(0, 0, anchoImagen / 2, altoImagen / 2 ), ImageLockMode.ReadWrite, pImagenEntrada.PixelFormat);

            System.IntPtr primerPixel = imagenOriginalDatos.Scan0;
            System.IntPtr primerPixelSalida = imagenSalidaDatos.Scan0;

            unsafe
            {
                byte* punteroPixel = (byte*)(void*)primerPixel;
                byte* punteroPixelSalida = (byte*)(void*)primerPixelSalida;

                for (int renglon = 0; renglon < altoImagen-1; renglon++)
                {
                    for (int columna = 0; columna < anchoImagen; columna++)
                    {
                        switch (pImagenEntrada.PixelFormat)
                        {
                            case PixelFormat.Alpha:
                                break;
                            case PixelFormat.Canonical:
                                break;
                            case PixelFormat.DontCare:
                                break;
                            case PixelFormat.Extended:
                                break;
                            case PixelFormat.Format16bppArgb1555:
                                break;
                            case PixelFormat.Format16bppGrayScale:
                                break;
                            case PixelFormat.Format16bppRgb555:
                                break;
                            case PixelFormat.Format16bppRgb565:
                                break;
                            case PixelFormat.Format1bppIndexed:
                                break;
                            case PixelFormat.Format24bppRgb:
                                //obtiene el valor del canal de color del pixel
                                if (((columna % 2) == 0) && ((renglon % 2) == 0))
                                {
                                    punteroPixelSalida[0] = punteroPixel[0];
                                    punteroPixelSalida[1] = punteroPixel[1];
                                    punteroPixelSalida[2] = punteroPixel[2];
                                    punteroPixelSalida += 3;
                                }
                                punteroPixel += 3;
                                break;
                            case PixelFormat.Format32bppArgb:
                                break;
                            case PixelFormat.Format32bppPArgb:
                                break;
                            case PixelFormat.Format32bppRgb:
                                break;
                            case PixelFormat.Format48bppRgb:
                                break;
                            case PixelFormat.Format4bppIndexed:
                                break;
                            case PixelFormat.Format64bppArgb:
                                break;
                            case PixelFormat.Format64bppPArgb:
                                break;
                            case PixelFormat.Format8bppIndexed:
                                //obtiene el valor del canal de color del pixel
                                if (((columna % 2) == 0) && ((renglon % 2) == 0))
                                {
                                    punteroPixelSalida[0] = punteroPixel[0];
                                    punteroPixelSalida ++;
                                }
                                punteroPixel ++;
                                break;
                            case PixelFormat.Gdi:
                                break;
                            case PixelFormat.Indexed:
                                break;
                            case PixelFormat.Max:
                                break;
                            case PixelFormat.PAlpha:
                                break;
                            default:
                                break;
                        }

                        
                    }
                }
            }
            imagenSalida.UnlockBits(imagenSalidaDatos);
            ((Bitmap)pImagenEntrada).UnlockBits(imagenOriginalDatos);

            return imagenSalida;
        }
        internal static Image agrandarImagen(Image pImagenEntrada)
        {


            BitmapData imagenOriginalDatos = ((Bitmap)pImagenEntrada).LockBits(new Rectangle(0, 0, pImagenEntrada.Width, pImagenEntrada.Height), ImageLockMode.ReadWrite, pImagenEntrada.PixelFormat);

            int altoImagen = imagenOriginalDatos.Height;
            int anchoImagen = imagenOriginalDatos.Width;
            Bitmap imagenSalida = new Bitmap(width: anchoImagen * 2, height: altoImagen * 2, format: PixelFormat.Format24bppRgb);
            BitmapData imagenSalidaDatos = imagenSalida.LockBits(new Rectangle(0, 0, anchoImagen * 2, altoImagen * 2), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            System.IntPtr primerPixel = imagenOriginalDatos.Scan0;
            System.IntPtr primerPixelSalida = imagenSalidaDatos.Scan0;

            unsafe
            {
                byte* punteroPixel = (byte*)(void*)primerPixel;
                byte* punteroPixelSalida = (byte*)(void*)primerPixelSalida;
                int ren_ant = 0;
                for (int renglon = 0; renglon < altoImagen; renglon++)
                {
                    for (int columna = 0; columna < anchoImagen; columna++)
                    {
                        switch (pImagenEntrada.PixelFormat)
                        {
                            case PixelFormat.Alpha:
                                break;
                            case PixelFormat.Canonical:
                                break;
                            case PixelFormat.DontCare:
                                break;
                            case PixelFormat.Extended:
                                break;
                            case PixelFormat.Format16bppArgb1555:
                                break;
                            case PixelFormat.Format16bppGrayScale:
                                break;
                            case PixelFormat.Format16bppRgb555:
                                break;
                            case PixelFormat.Format16bppRgb565:
                                break;
                            case PixelFormat.Format1bppIndexed:
                                break;
                            case PixelFormat.Format24bppRgb:
                                //obtiene el valor del canal de color del pixel
                                if (ren_ant != renglon)
                                {
                                    ren_ant = renglon;
                                    punteroPixelSalida += (anchoImagen * 6);
                                }
                                    punteroPixelSalida[0] = punteroPixel[0];
                                    punteroPixelSalida[1] = punteroPixel[1];
                                    punteroPixelSalida[2] = punteroPixel[2];
                                    punteroPixelSalida[3] = punteroPixel[0];
                                    punteroPixelSalida[4] = punteroPixel[1];
                                    punteroPixelSalida[5] = punteroPixel[2];
                                    (punteroPixelSalida + (anchoImagen * 6))[0] = punteroPixel[0];
                                    (punteroPixelSalida + (anchoImagen * 6))[1] = punteroPixel[1];
                                    (punteroPixelSalida + (anchoImagen * 6))[2] = punteroPixel[2];
                                    (punteroPixelSalida + (anchoImagen * 6))[3] = punteroPixel[0];
                                    (punteroPixelSalida + (anchoImagen * 6))[4] = punteroPixel[1];
                                    (punteroPixelSalida + (anchoImagen * 6))[5] = punteroPixel[2];
                                    punteroPixelSalida += 6;
                                    
                                punteroPixel += 3;
                                break;
                            case PixelFormat.Format32bppArgb:
                                break;
                            case PixelFormat.Format32bppPArgb:
                                break;
                            case PixelFormat.Format32bppRgb:
                                break;
                            case PixelFormat.Format48bppRgb:
                                break;
                            case PixelFormat.Format4bppIndexed:
                                break;
                            case PixelFormat.Format64bppArgb:
                                break;
                            case PixelFormat.Format64bppPArgb:
                                break;
                            case PixelFormat.Format8bppIndexed:
                                //obtiene el valor del canal de color del pixel
                                if (ren_ant != renglon)
                                {
                                    ren_ant = renglon;
                                    punteroPixelSalida += (anchoImagen * 6);
                                }
                                    punteroPixelSalida[0] = punteroPixel[0];
                                    punteroPixelSalida[1] = punteroPixel[0];
                                    punteroPixelSalida[2] = punteroPixel[0];
                                    punteroPixelSalida[3] = punteroPixel[0];
                                    punteroPixelSalida[4] = punteroPixel[0];
                                    punteroPixelSalida[5] = punteroPixel[0];
                                    (punteroPixelSalida + (anchoImagen * 6))[0] = punteroPixel[0];
                                    (punteroPixelSalida + (anchoImagen * 6))[1] = punteroPixel[0];
                                    (punteroPixelSalida + (anchoImagen * 6))[2] = punteroPixel[0];
                                    (punteroPixelSalida + (anchoImagen * 6))[3] = punteroPixel[0];
                                    (punteroPixelSalida + (anchoImagen * 6))[4] = punteroPixel[0];
                                    (punteroPixelSalida + (anchoImagen * 6))[5] = punteroPixel[0];
                                    punteroPixelSalida += 6;
                                    
                                punteroPixel ++;
                                break;
                            case PixelFormat.Gdi:
                                break;
                            case PixelFormat.Indexed:
                                break;
                            case PixelFormat.Max:
                                break;
                            case PixelFormat.PAlpha:
                                break;
                            default:
                                break;
                        }


                    }
                }
            }
            imagenSalida.UnlockBits(imagenSalidaDatos);
            ((Bitmap)pImagenEntrada).UnlockBits(imagenOriginalDatos);

            return imagenSalida;
        }
    }
}
