using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManejoDeImagenes
{
    class Esteganografia
    {
        internal static Image encriptar(Image pImagenEntrada, Image pImagenOcultar)
        {
            BitmapData imagenOriginalDatos = ((Bitmap)pImagenEntrada).LockBits(new Rectangle(0, 0, pImagenEntrada.Width, pImagenEntrada.Height), ImageLockMode.ReadWrite, pImagenEntrada.PixelFormat);

            int altoImagen = imagenOriginalDatos.Height;
            int anchoImagen = imagenOriginalDatos.Width;
            Bitmap imagenSalida = new Bitmap(width: anchoImagen, height: altoImagen, format: PixelFormat.Format24bppRgb);
            BitmapData imagenSalidaDatos = imagenSalida.LockBits(new Rectangle(0, 0, anchoImagen, altoImagen), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData imagenOcultarDatos = ((Bitmap)pImagenOcultar).LockBits(new Rectangle(0, 0, pImagenOcultar.Width, pImagenOcultar.Height), ImageLockMode.ReadWrite, pImagenOcultar.PixelFormat);

            int altoImagenO = imagenOcultarDatos.Height;
            int anchoImagenO = imagenOcultarDatos.Width;

            System.IntPtr primerPixel = imagenOriginalDatos.Scan0;
            System.IntPtr primerPixelSalida = imagenSalidaDatos.Scan0;
            System.IntPtr primerPixelOcultar = imagenOcultarDatos.Scan0;

            decimal GRIS;
            int bit_aux = 254;
            int paso = 0;
            unsafe
            {
                byte* punteroPixel = (byte*)(void*)primerPixel;
                byte* punteroPixelSalida = (byte*)(void*)primerPixelSalida;
                byte* punteroPixelOcultar = (byte*)(void*)primerPixelOcultar;

                if (pImagenOcultar.PixelFormat == PixelFormat.Format8bppIndexed)
                {
                    paso = 1;
                }
                else
                {
                    paso = 3;
                }

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
                                GRIS = (decimal)punteroPixel[0] + (decimal)punteroPixel[1] + (decimal)punteroPixel[2];
                                GRIS = Math.Round(GRIS / 3);
                                GRIS = ((int)GRIS & bit_aux);
                                if ((columna <= anchoImagenO) && (renglon <= altoImagenO))
                                {
                                    GRIS = (int)GRIS | (int)((punteroPixelOcultar[0] & 128) / 128);
                                    punteroPixelOcultar += paso;
                                }
                                punteroPixelSalida[0] = (byte)GRIS;
                                punteroPixelSalida[1] = (byte)GRIS;
                                punteroPixelSalida[2] = (byte)GRIS;
                                punteroPixelSalida += 3;
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
                                GRIS = (decimal)punteroPixel[0];
                                GRIS = ((int)GRIS & bit_aux);
                                if ((columna < anchoImagenO) && (renglon < altoImagenO))
                                {
                                    GRIS = (int)GRIS | (int)((punteroPixelOcultar[0] & 128) / 128);
                                    punteroPixelOcultar += paso;
                                }
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
            ((Bitmap)pImagenOcultar).UnlockBits(imagenOcultarDatos);

            return imagenSalida;
        }

    }
}
