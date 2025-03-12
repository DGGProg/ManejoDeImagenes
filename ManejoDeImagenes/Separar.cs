using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManejoDeImagenes
{
    class Separar
    {
     /// <summary>
     /// Separa una imagen por bits del menos al mas significativo (primero convierte la imagen a escala de grises tomando en cuenta 3 canales RGB o 4 para el caso ARGB)
     /// </summary>
     /// <param name="pImagenEntrada"></param>
     /// <param name="bit_a_separar">bit del 1 al 8 que se desea separar</param>
     /// <returns>Imagen de salida formato 24 bits RGB</returns>
        internal static Image bit_a_separar(Image pImagenEntrada, int bit_a_separar)
        {
            BitmapData imagenOriginalDatos = ((Bitmap)pImagenEntrada).LockBits(new Rectangle(0, 0, pImagenEntrada.Width, pImagenEntrada.Height), ImageLockMode.ReadWrite, pImagenEntrada.PixelFormat);

            int altoImagen = imagenOriginalDatos.Height;
            int anchoImagen = imagenOriginalDatos.Width;
            Bitmap imagenSalida = new Bitmap(width: anchoImagen, height: altoImagen, format: PixelFormat.Format24bppRgb);
            BitmapData imagenSalidaDatos = imagenSalida.LockBits(new Rectangle(0, 0, anchoImagen, altoImagen), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            System.IntPtr primerPixel = imagenOriginalDatos.Scan0;
            System.IntPtr primerPixelSalida = imagenSalidaDatos.Scan0;

            decimal GRIS;
            int bit_aux= 1<<(bit_a_separar-1);
            unsafe
            {
                byte* punteroPixel = (byte*)(void*)primerPixel;
                byte* punteroPixelSalida = (byte*)(void*)primerPixelSalida;

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
                                GRIS = (byte)punteroPixel[0] + (byte)punteroPixel[1] + (byte)punteroPixel[2];
                                GRIS = (byte)Math.Round(GRIS / 3);
                                GRIS = (byte)GRIS & (1 << (bit_a_separar - 1));
                                punteroPixelSalida[0] = 0;
                                punteroPixelSalida[1] = 0;
                                punteroPixelSalida[2] = 0;
                                if (GRIS != 0)
                                {
                                    punteroPixelSalida[0] = 255;
                                    punteroPixelSalida[1] = 255;
                                    punteroPixelSalida[2] = 255;
                                }
                                punteroPixelSalida += 3;
                                punteroPixel += 3;
                                break;
                            case PixelFormat.Format32bppArgb:
                                //obtiene el valor del canal de color del pixel
                                GRIS = (byte)punteroPixel[0] + (byte)punteroPixel[1] + (byte)punteroPixel[2] + (byte)punteroPixel[3];
                                GRIS = Math.Round(GRIS / 4);
                                GRIS = (byte)GRIS & (1 << (bit_a_separar - 1));
                                punteroPixelSalida[0] = 0;
                                punteroPixelSalida[1] = 0;
                                punteroPixelSalida[2] = 0;
                                if (GRIS != 0)
                                {
                                    punteroPixelSalida[0] = 255;
                                    punteroPixelSalida[1] = 255;
                                    punteroPixelSalida[2] = 255;
                                }
                                punteroPixelSalida += 3;
                                punteroPixel += 4;
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
                                GRIS = (byte)punteroPixel[0];
                                GRIS = ((int)GRIS & bit_aux) / bit_aux * 255;
                                punteroPixelSalida[0] = (byte)GRIS;
                                punteroPixelSalida[1] = (byte)GRIS;
                                punteroPixelSalida[2] = (byte)GRIS;
                                punteroPixelSalida += 3;
                                punteroPixel++;
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
