using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManejoDeImagenes
{
    class Bordes
    {
        internal static Image aplicarBorde_Derivada_X(Image pImagenEntrada, bool pSumar_128)
        {
            BitmapData imagenOriginalDatos = ((Bitmap)pImagenEntrada).LockBits(new Rectangle(0, 0, pImagenEntrada.Width, pImagenEntrada.Height), ImageLockMode.ReadWrite, pImagenEntrada.PixelFormat);

            int altoImagen = imagenOriginalDatos.Height;
            int anchoImagen = imagenOriginalDatos.Width;
            Bitmap imagenSalida = new Bitmap(width: anchoImagen, height: altoImagen, format: PixelFormat.Format24bppRgb);
            BitmapData imagenSalidaDatos = imagenSalida.LockBits(new Rectangle(0, 0, anchoImagen, altoImagen), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            System.IntPtr primerPixel = imagenOriginalDatos.Scan0;
            System.IntPtr primerPixelSalida = imagenSalidaDatos.Scan0;

            int GRIS, R, G, B;
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
                                R = (int)(decimal)punteroPixel[2];
                                G = (int)(decimal)punteroPixel[1];
                                B = (int)(decimal)punteroPixel[0];
                                if (renglon >= 1)
                                {
                                    R = G = B = 0;
                                    byte* punteroPixelaux = punteroPixel;
                                    punteroPixelaux = punteroPixel - 3;
                                    R += (punteroPixelaux[2] * -1) + punteroPixel[2];
                                    G += (punteroPixelaux[1] * -1) + punteroPixel[1];
                                    B += (punteroPixelaux[0] * -1) + punteroPixel[0];
                                    if (pSumar_128)
                                    {
                                        R += 128;
                                        G += 128;
                                        B += 128;
                                    }
                                } 
                                
                                //obtiene el valor del canal de color del pixel
                                if (R > 255)
                                    R = 255;
                                if (G > 255)
                                    G = 255;
                                if (B > 255)
                                    B = 255;
                                if (R < 0)
                                    R = 0;
                                if (G < 0)
                                    G = 0;
                                if (B < 0)
                                    B = 0;
                                punteroPixelSalida[2] = (byte)R;
                                punteroPixelSalida[1] = (byte)G;
                                punteroPixelSalida[0] = (byte)B;
                                punteroPixelSalida += 3;
                                punteroPixel += 3;
                                break;
                            case PixelFormat.Format32bppArgb:
                                R = (int)(decimal)punteroPixel[2];
                                G = (int)(decimal)punteroPixel[1];
                                B = (int)(decimal)punteroPixel[0];
                                if (renglon >= 1)
                                {
                                    R = G = B = 0;
                                    byte* punteroPixelaux = punteroPixel;
                                    punteroPixelaux = punteroPixel - 3;
                                    R += (punteroPixelaux[2] * -1) + punteroPixel[2];
                                    G += (punteroPixelaux[1] * -1) + punteroPixel[1];
                                    B += (punteroPixelaux[0] * -1) + punteroPixel[0];
                                    if (pSumar_128)
                                    {
                                        R += 128;
                                        G += 128;
                                        B += 128;
                                    }
                                }

                                //obtiene el valor del canal de color del pixel
                                if (R > 255)
                                    R = 255;
                                if (G > 255)
                                    G = 255;
                                if (B > 255)
                                    B = 255;
                                if (R < 0)
                                    R = 0;
                                if (G < 0)
                                    G = 0;
                                if (B < 0)
                                    B = 0;
                                punteroPixelSalida[2] = (byte)R;
                                punteroPixelSalida[1] = (byte)G;
                                punteroPixelSalida[0] = (byte)B;
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
                                GRIS = (int)(decimal)punteroPixel[0];
                                if (renglon >= 1)
                                {
                                    R = G = B = 0;
                                    byte* punteroPixelaux = punteroPixel;
                                    punteroPixelaux = punteroPixel - 1;
                                    GRIS += (punteroPixelaux[0] * -1) + punteroPixel[0];
                                }
                                //obtiene el valor del canal de color del pixel
                                if (GRIS > 255)
                                    GRIS = 255;
                                if (GRIS < 0)
                                    GRIS = 0;
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
        internal static Image aplicarBorde_Derivada_Y(Image pImagenEntrada, bool pSumar_128)
        {
            BitmapData imagenOriginalDatos = ((Bitmap)pImagenEntrada).LockBits(new Rectangle(0, 0, pImagenEntrada.Width, pImagenEntrada.Height), ImageLockMode.ReadWrite, pImagenEntrada.PixelFormat);

            int altoImagen = imagenOriginalDatos.Height;
            int anchoImagen = imagenOriginalDatos.Width;
            Bitmap imagenSalida = new Bitmap(width: anchoImagen, height: altoImagen, format: PixelFormat.Format24bppRgb);
            BitmapData imagenSalidaDatos = imagenSalida.LockBits(new Rectangle(0, 0, anchoImagen, altoImagen), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            System.IntPtr primerPixel = imagenOriginalDatos.Scan0;
            System.IntPtr primerPixelSalida = imagenSalidaDatos.Scan0;

            int GRIS, R, G, B;
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
                                R = (int)(decimal)punteroPixel[2];
                                G = (int)(decimal)punteroPixel[1];
                                B = (int)(decimal)punteroPixel[0];
                                if (renglon >= 1)
                                {
                                    R = G = B = 0;
                                    byte* punteroPixelaux = punteroPixel;
                                    punteroPixelaux = punteroPixel - (anchoImagen * 3);
                                    R += (punteroPixelaux[2] * -1) + punteroPixel[2];
                                    G += (punteroPixelaux[1] * -1) + punteroPixel[1];
                                    B += (punteroPixelaux[0] * -1) + punteroPixel[0];
                                    if (pSumar_128)
                                    {
                                        R += 128;
                                        G += 128;
                                        B += 128;
                                    }
                                }

                                //obtiene el valor del canal de color del pixel
                                if (R > 255)
                                    R = 255;
                                if (G > 255)
                                    G = 255;
                                if (B > 255)
                                    B = 255;
                                if (R < 0)
                                    R = 0;
                                if (G < 0)
                                    G = 0;
                                if (B < 0)
                                    B = 0;
                                punteroPixelSalida[2] = (byte)R;
                                punteroPixelSalida[1] = (byte)G;
                                punteroPixelSalida[0] = (byte)B;
                                punteroPixelSalida += 3;
                                punteroPixel += 3;
                                break;
                            case PixelFormat.Format32bppArgb:
                                R = (int)(decimal)punteroPixel[2];
                                G = (int)(decimal)punteroPixel[1];
                                B = (int)(decimal)punteroPixel[0];
                                if (renglon >= 1)
                                {
                                    R = G = B = 0;
                                    byte* punteroPixelaux = punteroPixel;
                                    punteroPixelaux = punteroPixel - (anchoImagen * 4);
                                    R += (punteroPixelaux[2] * -1) + punteroPixel[2];
                                    G += (punteroPixelaux[1] * -1) + punteroPixel[1];
                                    B += (punteroPixelaux[0] * -1) + punteroPixel[0];
                                    if (pSumar_128)
                                    {
                                        R += 128;
                                        G += 128;
                                        B += 128;
                                    }
                                }

                                //obtiene el valor del canal de color del pixel
                                if (R > 255)
                                    R = 255;
                                if (G > 255)
                                    G = 255;
                                if (B > 255)
                                    B = 255;
                                if (R < 0)
                                    R = 0;
                                if (G < 0)
                                    G = 0;
                                if (B < 0)
                                    B = 0;
                                punteroPixelSalida[2] = (byte)R;
                                punteroPixelSalida[1] = (byte)G;
                                punteroPixelSalida[0] = (byte)B;
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
                                GRIS = (int)(decimal)punteroPixel[0];
                                if (renglon >= 1)
                                {
                                    R = G = B = 0;
                                    byte* punteroPixelaux = punteroPixel;
                                    punteroPixelaux = punteroPixel - (anchoImagen);
                                    GRIS += (punteroPixelaux[0] * -1) + punteroPixel[0];
                                }
                                //obtiene el valor del canal de color del pixel
                                if (GRIS > 255)
                                    GRIS = 255;
                                if (GRIS < 0)
                                    GRIS = 0;
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
        internal static Image aplicarBorde_Diagonal_1(Image pImagenEntrada, bool pSumar_128)
        {
            BitmapData imagenOriginalDatos = ((Bitmap)pImagenEntrada).LockBits(new Rectangle(0, 0, pImagenEntrada.Width, pImagenEntrada.Height), ImageLockMode.ReadWrite, pImagenEntrada.PixelFormat);

            int altoImagen = imagenOriginalDatos.Height;
            int anchoImagen = imagenOriginalDatos.Width;
            Bitmap imagenSalida = new Bitmap(width: anchoImagen, height: altoImagen, format: PixelFormat.Format24bppRgb);
            BitmapData imagenSalidaDatos = imagenSalida.LockBits(new Rectangle(0, 0, anchoImagen, altoImagen), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            System.IntPtr primerPixel = imagenOriginalDatos.Scan0;
            System.IntPtr primerPixelSalida = imagenSalidaDatos.Scan0;

            int GRIS, R, G, B;
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
                                R = (int)(decimal)punteroPixel[2];
                                G = (int)(decimal)punteroPixel[1];
                                B = (int)(decimal)punteroPixel[0];
                                if (renglon >= 1)
                                {
                                    if (columna >= 1)
                                    {
                                        R = G = B = 0;
                                        byte* punteroPixelaux = punteroPixel;
                                        punteroPixelaux = punteroPixel - 3 - (anchoImagen * 3);
                                        R += (punteroPixelaux[2] * -1) + punteroPixel[2];
                                        G += (punteroPixelaux[1] * -1) + punteroPixel[1];
                                        B += (punteroPixelaux[0] * -1) + punteroPixel[0];
                                        if (pSumar_128)
                                        {
                                            R += 128;
                                            G += 128;
                                            B += 128;
                                        }
                                    }
                                }
                                //obtiene el valor del canal de color del pixel
                                if (R > 255)
                                    R = 255;
                                if (G > 255)
                                    G = 255;
                                if (B > 255)
                                    B = 255;
                                if (R < 0)
                                    R = 0;
                                if (G < 0)
                                    G = 0;
                                if (B < 0)
                                    B = 0;
                                punteroPixelSalida[2] = (byte)R;
                                punteroPixelSalida[1] = (byte)G;
                                punteroPixelSalida[0] = (byte)B;
                                punteroPixelSalida += 3;
                                punteroPixel += 3;
                                break;
                            case PixelFormat.Format32bppArgb:
                                R = (int)(decimal)punteroPixel[2];
                                G = (int)(decimal)punteroPixel[1];
                                B = (int)(decimal)punteroPixel[0];
                                if (renglon >= 1)
                                {
                                    if (columna >= 1)
                                    {
                                        R = G = B = 0;
                                        byte* punteroPixelaux = punteroPixel;
                                        punteroPixelaux = punteroPixel - 3 - (anchoImagen * 4);
                                        R += (punteroPixelaux[2] * -1) + punteroPixel[2];
                                        G += (punteroPixelaux[1] * -1) + punteroPixel[1];
                                        B += (punteroPixelaux[0] * -1) + punteroPixel[0];
                                        if (pSumar_128)
                                        {
                                            R += 128;
                                            G += 128;
                                            B += 128;
                                        }
                                    }
                                }
                                //obtiene el valor del canal de color del pixel
                                if (R > 255)
                                    R = 255;
                                if (G > 255)
                                    G = 255;
                                if (B > 255)
                                    B = 255;
                                if (R < 0)
                                    R = 0;
                                if (G < 0)
                                    G = 0;
                                if (B < 0)
                                    B = 0;
                                punteroPixelSalida[2] = (byte)R;
                                punteroPixelSalida[1] = (byte)G;
                                punteroPixelSalida[0] = (byte)B;
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
                                GRIS = (int)(decimal)punteroPixel[0];
                                if (renglon >= 1)
                                {
                                    R = G = B = 0;
                                    byte* punteroPixelaux = punteroPixel;
                                    punteroPixelaux = punteroPixel - 1;
                                    GRIS += (punteroPixelaux[0] * -1) + punteroPixel[0];
                                }
                                //obtiene el valor del canal de color del pixel
                                if (GRIS > 255)
                                    GRIS = 255;
                                if (GRIS < 0)
                                    GRIS = 0;
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
        internal static Image aplicarBorde_Diagonal_2(Image pImagenEntrada, bool pSumar_128)
        {
            BitmapData imagenOriginalDatos = ((Bitmap)pImagenEntrada).LockBits(new Rectangle(0, 0, pImagenEntrada.Width, pImagenEntrada.Height), ImageLockMode.ReadWrite, pImagenEntrada.PixelFormat);

            int altoImagen = imagenOriginalDatos.Height;
            int anchoImagen = imagenOriginalDatos.Width;
            Bitmap imagenSalida = new Bitmap(width: anchoImagen, height: altoImagen, format: PixelFormat.Format24bppRgb);
            BitmapData imagenSalidaDatos = imagenSalida.LockBits(new Rectangle(0, 0, anchoImagen, altoImagen), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            System.IntPtr primerPixel = imagenOriginalDatos.Scan0;
            System.IntPtr primerPixelSalida = imagenSalidaDatos.Scan0;

            int GRIS, R, G, B;
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
                                R = (int)(decimal)punteroPixel[2];
                                G = (int)(decimal)punteroPixel[1];
                                B = (int)(decimal)punteroPixel[0];
                                if (renglon >= 1)
                                {
                                    if (columna < anchoImagen-1)
                                    {
                                        R = G = B = 0;
                                        byte* punteroPixelaux = punteroPixel;
                                        punteroPixelaux = punteroPixel + 3 - (anchoImagen * 3);
                                        R += (punteroPixelaux[2] * -1) + punteroPixel[2];
                                        G += (punteroPixelaux[1] * -1) + punteroPixel[1];
                                        B += (punteroPixelaux[0] * -1) + punteroPixel[0];
                                        if(pSumar_128)
                                        {
                                            R += 128;
                                            G += 128;
                                            B += 128;
                                        }
                                    }
                                }
                                //obtiene el valor del canal de color del pixel
                                if (R > 255)
                                    R = 255;
                                if (G > 255)
                                    G = 255;
                                if (B > 255)
                                    B = 255;
                                if (R < 0)
                                    R = 0;
                                if (G < 0)
                                    G = 0;
                                if (B < 0)
                                    B = 0;
                                punteroPixelSalida[2] = (byte)R;
                                punteroPixelSalida[1] = (byte)G;
                                punteroPixelSalida[0] = (byte)B;
                                punteroPixelSalida += 3;
                                punteroPixel += 3;
                                break;
                            case PixelFormat.Format32bppArgb:
                                R = (int)(decimal)punteroPixel[2];
                                G = (int)(decimal)punteroPixel[1];
                                B = (int)(decimal)punteroPixel[0];
                                if (renglon >= 1)
                                {
                                    if (columna < anchoImagen - 1)
                                    {
                                        R = G = B = 0;
                                        byte* punteroPixelaux = punteroPixel;
                                        punteroPixelaux = punteroPixel + 3 - (anchoImagen * 4);
                                        R += (punteroPixelaux[2] * -1) + punteroPixel[2];
                                        G += (punteroPixelaux[1] * -1) + punteroPixel[1];
                                        B += (punteroPixelaux[0] * -1) + punteroPixel[0];
                                        if (pSumar_128)
                                        {
                                            R += 128;
                                            G += 128;
                                            B += 128;
                                        }
                                    }
                                }
                                //obtiene el valor del canal de color del pixel
                                if (R > 255)
                                    R = 255;
                                if (G > 255)
                                    G = 255;
                                if (B > 255)
                                    B = 255;
                                if (R < 0)
                                    R = 0;
                                if (G < 0)
                                    G = 0;
                                if (B < 0)
                                    B = 0;
                                punteroPixelSalida[2] = (byte)R;
                                punteroPixelSalida[1] = (byte)G;
                                punteroPixelSalida[0] = (byte)B;
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
                                GRIS = (int)(decimal)punteroPixel[0];
                                if (renglon >= 1)
                                {
                                    R = G = B = 0;
                                    byte* punteroPixelaux = punteroPixel;
                                    punteroPixelaux = punteroPixel - 1;
                                    GRIS += (punteroPixelaux[0] * -1) + punteroPixel[0];
                                }
                                //obtiene el valor del canal de color del pixel
                                if (GRIS > 255)
                                    GRIS = 255;
                                if (GRIS < 0)
                                    GRIS = 0;
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
        internal static Image aplicarBorde_Prewitt_X(Image pImagenEntrada, bool pSumar_128)
        {
            BitmapData imagenOriginalDatos = ((Bitmap)pImagenEntrada).LockBits(new Rectangle(0, 0, pImagenEntrada.Width, pImagenEntrada.Height), ImageLockMode.ReadWrite, pImagenEntrada.PixelFormat);

            int altoImagen = imagenOriginalDatos.Height;
            int anchoImagen = imagenOriginalDatos.Width;
            Bitmap imagenSalida = new Bitmap(width: anchoImagen, height: altoImagen, format: PixelFormat.Format24bppRgb);
            BitmapData imagenSalidaDatos = imagenSalida.LockBits(new Rectangle(0, 0, anchoImagen, altoImagen), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            System.IntPtr primerPixel = imagenOriginalDatos.Scan0;
            System.IntPtr primerPixelSalida = imagenSalidaDatos.Scan0;

            int GRIS, R, G, B;
            int[,] mascara = new int[3, 3];
            mascara[0, 0] = -1;
            mascara[0, 1] = 0;
            mascara[0, 2] = 1;
            mascara[1, 0] = -1;
            mascara[1, 1] = 0;
            mascara[1, 2] = 1;
            mascara[2, 0] = -1;
            mascara[2, 1] = 0;
            mascara[2, 2] = 1;
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
                                R = (int)(decimal)punteroPixel[2];
                                G = (int)(decimal)punteroPixel[1];
                                B = (int)(decimal)punteroPixel[0];
                                if ((renglon >= 1) && (renglon < (altoImagen - 1)))
                                {
                                    if ((columna >= 1) && (columna < (anchoImagen - 1)))
                                    {
                                        R = 0;
                                        G = 0;
                                        B = 0;
                                        byte* punteroPixelaux = punteroPixel;
                                        for (int i = -1; i <= 1; i++)
                                        {
                                            for (int j = -1; j <= 1; j++)
                                            {
                                                punteroPixelaux = punteroPixel + (i * anchoImagen * 3) + (j * 3);
                                                R += punteroPixelaux[2] * mascara[i + 1, j + 1];
                                                G += punteroPixelaux[1] * mascara[i + 1, j + 1];
                                                B += punteroPixelaux[0] * mascara[i + 1, j + 1];
                                            }
                                        }
                                        if (pSumar_128)
                                        {
                                            R += 128;
                                            G += 128;
                                            B += 128;
                                        }
                                    }
                                }

                                //obtiene el valor del canal de color del pixel
                                if (R > 255)
                                    R = 255;
                                if (G > 255)
                                    G = 255;
                                if (B > 255)
                                    B = 255;
                                if (R < 0)
                                    R = 0;
                                if (G < 0)
                                    G = 0;
                                if (B < 0)
                                    B = 0;
                                punteroPixelSalida[2] = (byte)R;
                                punteroPixelSalida[1] = (byte)G;
                                punteroPixelSalida[0] = (byte)B;
                                punteroPixelSalida += 3;
                                punteroPixel += 3;
                                break;
                            case PixelFormat.Format32bppArgb:
                                R = (int)(decimal)punteroPixel[2];
                                G = (int)(decimal)punteroPixel[1];
                                B = (int)(decimal)punteroPixel[0];
                                if ((renglon >= 1) && (renglon < (altoImagen - 1)))
                                {
                                    if ((columna >= 1) && (columna < (anchoImagen - 1)))
                                    {
                                        R = 0;
                                        G = 0;
                                        B = 0;
                                        byte* punteroPixelaux = punteroPixel;
                                        for (int i = -1; i <= 1; i++)
                                        {
                                            for (int j = -1; j <= 1; j++)
                                            {
                                                punteroPixelaux = punteroPixel + (i * anchoImagen * 4) + (j * 4);
                                                R += punteroPixelaux[2] * mascara[i + 1, j + 1];
                                                G += punteroPixelaux[1] * mascara[i + 1, j + 1];
                                                B += punteroPixelaux[0] * mascara[i + 1, j + 1];
                                            }
                                        }
                                        if (pSumar_128)
                                        {
                                            R += 128;
                                            G += 128;
                                            B += 128;
                                        }
                                    }
                                }

                                //obtiene el valor del canal de color del pixel
                                if (R > 255)
                                    R = 255;
                                if (G > 255)
                                    G = 255;
                                if (B > 255)
                                    B = 255;
                                if (R < 0)
                                    R = 0;
                                if (G < 0)
                                    G = 0;
                                if (B < 0)
                                    B = 0;
                                punteroPixelSalida[2] = (byte)R;
                                punteroPixelSalida[1] = (byte)G;
                                punteroPixelSalida[0] = (byte)B;
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
                                GRIS = (int)(decimal)punteroPixel[0];
                                if ((renglon >= 1) && (renglon < (altoImagen - 1)))
                                {
                                    if ((columna >= 1) && (columna < (anchoImagen - 1)))
                                    {
                                        byte* punteroPixelaux = punteroPixel;
                                        for (int i = -1; i <= 1; i++)
                                        {
                                            for (int j = -1; j <= 1; j++)
                                            {
                                                punteroPixelaux = punteroPixel + (i * anchoImagen) + (j);
                                                GRIS += punteroPixelaux[0] * mascara[i + 1, j + 1];
                                            }
                                        }
                                    }
                                }
                                //obtiene el valor del canal de color del pixel
                                if (GRIS > 255)
                                    GRIS = 255;
                                if (GRIS < 0)
                                    GRIS = 0;
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
        internal static Image aplicarBorde_Prewitt_Y(Image pImagenEntrada, bool pSumar_128)
        {
            BitmapData imagenOriginalDatos = ((Bitmap)pImagenEntrada).LockBits(new Rectangle(0, 0, pImagenEntrada.Width, pImagenEntrada.Height), ImageLockMode.ReadWrite, pImagenEntrada.PixelFormat);

            int altoImagen = imagenOriginalDatos.Height;
            int anchoImagen = imagenOriginalDatos.Width;
            Bitmap imagenSalida = new Bitmap(width: anchoImagen, height: altoImagen, format: PixelFormat.Format24bppRgb);
            BitmapData imagenSalidaDatos = imagenSalida.LockBits(new Rectangle(0, 0, anchoImagen, altoImagen), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            System.IntPtr primerPixel = imagenOriginalDatos.Scan0;
            System.IntPtr primerPixelSalida = imagenSalidaDatos.Scan0;

            int GRIS, R, G, B;
            int[,] mascara = new int[3, 3];
            mascara[0, 0] = -1;
            mascara[0, 1] = -1;
            mascara[0, 2] = -1;
            mascara[1, 0] = 0;
            mascara[1, 1] = 0;
            mascara[1, 2] = 0;
            mascara[2, 0] = 1;
            mascara[2, 1] = 1;
            mascara[2, 2] = 1;
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
                                R = (int)(decimal)punteroPixel[2];
                                G = (int)(decimal)punteroPixel[1];
                                B = (int)(decimal)punteroPixel[0];
                                if ((renglon >= 1) && (renglon < (altoImagen - 1)))
                                {
                                    if ((columna >= 1) && (columna < (anchoImagen - 1)))
                                    {
                                        R = 0;
                                        G = 0;
                                        B = 0;
                                        byte* punteroPixelaux = punteroPixel;
                                        for (int i = -1; i <= 1; i++)
                                        {
                                            for (int j = -1; j <= 1; j++)
                                            {
                                                punteroPixelaux = punteroPixel + (i * anchoImagen * 3) + (j * 3);
                                                R += punteroPixelaux[2] * mascara[i + 1, j + 1];
                                                G += punteroPixelaux[1] * mascara[i + 1, j + 1];
                                                B += punteroPixelaux[0] * mascara[i + 1, j + 1];
                                            }
                                        }
                                        if (pSumar_128)
                                        {
                                            R += 128;
                                            G += 128;
                                            B += 128;
                                        }
                                    }
                                }

                                //obtiene el valor del canal de color del pixel
                                if (R > 255)
                                    R = 255;
                                if (G > 255)
                                    G = 255;
                                if (B > 255)
                                    B = 255;
                                if (R < 0)
                                    R = 0;
                                if (G < 0)
                                    G = 0;
                                if (B < 0)
                                    B = 0;
                                punteroPixelSalida[2] = (byte)R;
                                punteroPixelSalida[1] = (byte)G;
                                punteroPixelSalida[0] = (byte)B;
                                punteroPixelSalida += 3;
                                punteroPixel += 3;
                                break;
                            case PixelFormat.Format32bppArgb:
                                R = (int)(decimal)punteroPixel[2];
                                G = (int)(decimal)punteroPixel[1];
                                B = (int)(decimal)punteroPixel[0];
                                if ((renglon >= 1) && (renglon < (altoImagen - 1)))
                                {
                                    if ((columna >= 1) && (columna < (anchoImagen - 1)))
                                    {
                                        R = 0;
                                        G = 0;
                                        B = 0;
                                        byte* punteroPixelaux = punteroPixel;
                                        for (int i = -1; i <= 1; i++)
                                        {
                                            for (int j = -1; j <= 1; j++)
                                            {
                                                punteroPixelaux = punteroPixel + (i * anchoImagen * 4) + (j * 4);
                                                R += punteroPixelaux[2] * mascara[i + 1, j + 1];
                                                G += punteroPixelaux[1] * mascara[i + 1, j + 1];
                                                B += punteroPixelaux[0] * mascara[i + 1, j + 1];
                                            }
                                        }
                                        if (pSumar_128)
                                        {
                                            R += 128;
                                            G += 128;
                                            B += 128;
                                        }
                                    }
                                }

                                //obtiene el valor del canal de color del pixel
                                if (R > 255)
                                    R = 255;
                                if (G > 255)
                                    G = 255;
                                if (B > 255)
                                    B = 255;
                                if (R < 0)
                                    R = 0;
                                if (G < 0)
                                    G = 0;
                                if (B < 0)
                                    B = 0;
                                punteroPixelSalida[2] = (byte)R;
                                punteroPixelSalida[1] = (byte)G;
                                punteroPixelSalida[0] = (byte)B;
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
                                GRIS = (int)(decimal)punteroPixel[0];
                                if ((renglon >= 1) && (renglon < (altoImagen - 1)))
                                {
                                    if ((columna >= 1) && (columna < (anchoImagen - 1)))
                                    {
                                        byte* punteroPixelaux = punteroPixel;
                                        for (int i = -1; i <= 1; i++)
                                        {
                                            for (int j = -1; j <= 1; j++)
                                            {
                                                punteroPixelaux = punteroPixel + (i * anchoImagen) + (j);
                                                GRIS += punteroPixelaux[0] * mascara[i + 1, j + 1];
                                            }
                                        }
                                    }
                                }
                                //obtiene el valor del canal de color del pixel
                                if (GRIS > 255)
                                    GRIS = 255;
                                if (GRIS < 0)
                                    GRIS = 0;
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
        internal static Image aplicarBorde_Scharr_X(Image pImagenEntrada, bool pSumar_128)
        {
            BitmapData imagenOriginalDatos = ((Bitmap)pImagenEntrada).LockBits(new Rectangle(0, 0, pImagenEntrada.Width, pImagenEntrada.Height), ImageLockMode.ReadWrite, pImagenEntrada.PixelFormat);

            int altoImagen = imagenOriginalDatos.Height;
            int anchoImagen = imagenOriginalDatos.Width;
            Bitmap imagenSalida = new Bitmap(width: anchoImagen, height: altoImagen, format: PixelFormat.Format24bppRgb);
            BitmapData imagenSalidaDatos = imagenSalida.LockBits(new Rectangle(0, 0, anchoImagen, altoImagen), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            System.IntPtr primerPixel = imagenOriginalDatos.Scan0;
            System.IntPtr primerPixelSalida = imagenSalidaDatos.Scan0;

            int GRIS, R, G, B;
            int[,] mascara = new int[3, 3];
            mascara[0, 0] = -3;
            mascara[0, 1] = 0;
            mascara[0, 2] = 3;
            mascara[1, 0] = -10;
            mascara[1, 1] = 0;
            mascara[1, 2] = 10;
            mascara[2, 0] = -3;
            mascara[2, 1] = 0;
            mascara[2, 2] = 3;
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
                                R = (int)(decimal)punteroPixel[2];
                                G = (int)(decimal)punteroPixel[1];
                                B = (int)(decimal)punteroPixel[0];
                                if ((renglon >= 1) && (renglon < (altoImagen - 1)))
                                {
                                    if ((columna >= 1) && (columna < (anchoImagen - 1)))
                                    {
                                        R = 0;
                                        G = 0;
                                        B = 0;
                                        byte* punteroPixelaux = punteroPixel;
                                        for (int i = -1; i <= 1; i++)
                                        {
                                            for (int j = -1; j <= 1; j++)
                                            {
                                                punteroPixelaux = punteroPixel + (i * anchoImagen * 3) + (j * 3);
                                                R += punteroPixelaux[2] * mascara[i + 1, j + 1];
                                                G += punteroPixelaux[1] * mascara[i + 1, j + 1];
                                                B += punteroPixelaux[0] * mascara[i + 1, j + 1];
                                            }
                                        }
                                        if (pSumar_128)
                                        {
                                            R += 128;
                                            G += 128;
                                            B += 128;
                                        }
                                    }
                                }

                                //obtiene el valor del canal de color del pixel
                                if (R > 255)
                                    R = 255;
                                if (G > 255)
                                    G = 255;
                                if (B > 255)
                                    B = 255;
                                if (R < 0)
                                    R = 0;
                                if (G < 0)
                                    G = 0;
                                if (B < 0)
                                    B = 0;
                                punteroPixelSalida[2] = (byte)R;
                                punteroPixelSalida[1] = (byte)G;
                                punteroPixelSalida[0] = (byte)B;
                                punteroPixelSalida += 3;
                                punteroPixel += 3;
                                break;
                            case PixelFormat.Format32bppArgb:
                                R = (int)(decimal)punteroPixel[2];
                                G = (int)(decimal)punteroPixel[1];
                                B = (int)(decimal)punteroPixel[0];
                                if ((renglon >= 1) && (renglon < (altoImagen - 1)))
                                {
                                    if ((columna >= 1) && (columna < (anchoImagen - 1)))
                                    {
                                        R = 0;
                                        G = 0;
                                        B = 0;
                                        byte* punteroPixelaux = punteroPixel;
                                        for (int i = -1; i <= 1; i++)
                                        {
                                            for (int j = -1; j <= 1; j++)
                                            {
                                                punteroPixelaux = punteroPixel + (i * anchoImagen * 4) + (j * 4);
                                                R += punteroPixelaux[2] * mascara[i + 1, j + 1];
                                                G += punteroPixelaux[1] * mascara[i + 1, j + 1];
                                                B += punteroPixelaux[0] * mascara[i + 1, j + 1];
                                            }
                                        }
                                        if (pSumar_128)
                                        {
                                            R += 128;
                                            G += 128;
                                            B += 128;
                                        }
                                    }
                                }

                                //obtiene el valor del canal de color del pixel
                                if (R > 255)
                                    R = 255;
                                if (G > 255)
                                    G = 255;
                                if (B > 255)
                                    B = 255;
                                if (R < 0)
                                    R = 0;
                                if (G < 0)
                                    G = 0;
                                if (B < 0)
                                    B = 0;
                                punteroPixelSalida[2] = (byte)R;
                                punteroPixelSalida[1] = (byte)G;
                                punteroPixelSalida[0] = (byte)B;
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
                                GRIS = (int)(decimal)punteroPixel[0];
                                if ((renglon >= 1) && (renglon < (altoImagen - 1)))
                                {
                                    if ((columna >= 1) && (columna < (anchoImagen - 1)))
                                    {
                                        byte* punteroPixelaux = punteroPixel;
                                        for (int i = -1; i <= 1; i++)
                                        {
                                            for (int j = -1; j <= 1; j++)
                                            {
                                                punteroPixelaux = punteroPixel + (i * anchoImagen) + (j);
                                                GRIS += punteroPixelaux[0] * mascara[i + 1, j + 1];
                                            }
                                        }
                                    }
                                }
                                //obtiene el valor del canal de color del pixel
                                if (GRIS > 255)
                                    GRIS = 255;
                                if (GRIS < 0)
                                    GRIS = 0;
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
        internal static Image aplicarBorde_Scharr_Y(Image pImagenEntrada, bool pSumar_128)
        {
            BitmapData imagenOriginalDatos = ((Bitmap)pImagenEntrada).LockBits(new Rectangle(0, 0, pImagenEntrada.Width, pImagenEntrada.Height), ImageLockMode.ReadWrite, pImagenEntrada.PixelFormat);

            int altoImagen = imagenOriginalDatos.Height;
            int anchoImagen = imagenOriginalDatos.Width;
            Bitmap imagenSalida = new Bitmap(width: anchoImagen, height: altoImagen, format: PixelFormat.Format24bppRgb);
            BitmapData imagenSalidaDatos = imagenSalida.LockBits(new Rectangle(0, 0, anchoImagen, altoImagen), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            System.IntPtr primerPixel = imagenOriginalDatos.Scan0;
            System.IntPtr primerPixelSalida = imagenSalidaDatos.Scan0;

            int GRIS, R, G, B;
            int[,] mascara = new int[3, 3];
            mascara[0, 0] = -3;
            mascara[0, 1] = -10;
            mascara[0, 2] = -3;
            mascara[1, 0] = 0;
            mascara[1, 1] = 0;
            mascara[1, 2] = 0;
            mascara[2, 0] = 3;
            mascara[2, 1] = 10;
            mascara[2, 2] = 3;
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
                                R = (int)(decimal)punteroPixel[2];
                                G = (int)(decimal)punteroPixel[1];
                                B = (int)(decimal)punteroPixel[0];
                                if ((renglon >= 1) && (renglon < (altoImagen - 1)))
                                {
                                    if ((columna >= 1) && (columna < (anchoImagen - 1)))
                                    {
                                        R = 0;
                                        G = 0;
                                        B = 0;
                                        byte* punteroPixelaux = punteroPixel;
                                        for (int i = -1; i <= 1; i++)
                                        {
                                            for (int j = -1; j <= 1; j++)
                                            {
                                                punteroPixelaux = punteroPixel + (i * anchoImagen * 3) + (j * 3);
                                                R += punteroPixelaux[2] * mascara[i + 1, j + 1];
                                                G += punteroPixelaux[1] * mascara[i + 1, j + 1];
                                                B += punteroPixelaux[0] * mascara[i + 1, j + 1];
                                            }
                                        }
                                        if (pSumar_128)
                                        {
                                            R += 128;
                                            G += 128;
                                            B += 128;
                                        }
                                    }
                                }

                                //obtiene el valor del canal de color del pixel
                                if (R > 255)
                                    R = 255;
                                if (G > 255)
                                    G = 255;
                                if (B > 255)
                                    B = 255;
                                if (R < 0)
                                    R = 0;
                                if (G < 0)
                                    G = 0;
                                if (B < 0)
                                    B = 0;
                                punteroPixelSalida[2] = (byte)R;
                                punteroPixelSalida[1] = (byte)G;
                                punteroPixelSalida[0] = (byte)B;
                                punteroPixelSalida += 3;
                                punteroPixel += 3;
                                break;
                            case PixelFormat.Format32bppArgb:
                                R = (int)(decimal)punteroPixel[2];
                                G = (int)(decimal)punteroPixel[1];
                                B = (int)(decimal)punteroPixel[0];
                                if ((renglon >= 1) && (renglon < (altoImagen - 1)))
                                {
                                    if ((columna >= 1) && (columna < (anchoImagen - 1)))
                                    {
                                        R = 0;
                                        G = 0;
                                        B = 0;
                                        byte* punteroPixelaux = punteroPixel;
                                        for (int i = -1; i <= 1; i++)
                                        {
                                            for (int j = -1; j <= 1; j++)
                                            {
                                                punteroPixelaux = punteroPixel + (i * anchoImagen * 4) + (j * 4);
                                                R += punteroPixelaux[2] * mascara[i + 1, j + 1];
                                                G += punteroPixelaux[1] * mascara[i + 1, j + 1];
                                                B += punteroPixelaux[0] * mascara[i + 1, j + 1];
                                            }
                                        }
                                        if (pSumar_128)
                                        {
                                            R += 128;
                                            G += 128;
                                            B += 128;
                                        }
                                    }
                                }

                                //obtiene el valor del canal de color del pixel
                                if (R > 255)
                                    R = 255;
                                if (G > 255)
                                    G = 255;
                                if (B > 255)
                                    B = 255;
                                if (R < 0)
                                    R = 0;
                                if (G < 0)
                                    G = 0;
                                if (B < 0)
                                    B = 0;
                                punteroPixelSalida[2] = (byte)R;
                                punteroPixelSalida[1] = (byte)G;
                                punteroPixelSalida[0] = (byte)B;
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
                                GRIS = (int)(decimal)punteroPixel[0];
                                if ((renglon >= 1) && (renglon < (altoImagen - 1)))
                                {
                                    if ((columna >= 1) && (columna < (anchoImagen - 1)))
                                    {
                                        byte* punteroPixelaux = punteroPixel;
                                        for (int i = -1; i <= 1; i++)
                                        {
                                            for (int j = -1; j <= 1; j++)
                                            {
                                                punteroPixelaux = punteroPixel + (i * anchoImagen) + (j);
                                                GRIS += punteroPixelaux[0] * mascara[i + 1, j + 1];
                                            }
                                        }
                                    }
                                }
                                //obtiene el valor del canal de color del pixel
                                if (GRIS > 255)
                                    GRIS = 255;
                                if (GRIS < 0)
                                    GRIS = 0;
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
        internal static Image aplicarBorde_Sobel_X(Image pImagenEntrada, bool pSumar_128)
        {
            BitmapData imagenOriginalDatos = ((Bitmap)pImagenEntrada).LockBits(new Rectangle(0, 0, pImagenEntrada.Width, pImagenEntrada.Height), ImageLockMode.ReadWrite, pImagenEntrada.PixelFormat);

            int altoImagen = imagenOriginalDatos.Height;
            int anchoImagen = imagenOriginalDatos.Width;
            Bitmap imagenSalida = new Bitmap(width: anchoImagen, height: altoImagen, format: PixelFormat.Format24bppRgb);
            BitmapData imagenSalidaDatos = imagenSalida.LockBits(new Rectangle(0, 0, anchoImagen, altoImagen), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            System.IntPtr primerPixel = imagenOriginalDatos.Scan0;
            System.IntPtr primerPixelSalida = imagenSalidaDatos.Scan0;

            int GRIS, R, G, B;
            int[,] mascara = new int[3, 3];
            mascara[0, 0] = -1;
            mascara[0, 1] = 0;
            mascara[0, 2] = 1;
            mascara[1, 0] = -2;
            mascara[1, 1] = 0;
            mascara[1, 2] = 2;
            mascara[2, 0] = -1;
            mascara[2, 1] = 0;
            mascara[2, 2] = 1;
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
                                R = (int)(decimal)punteroPixel[2];
                                G = (int)(decimal)punteroPixel[1];
                                B = (int)(decimal)punteroPixel[0];
                                if ((renglon >= 1) && (renglon < (altoImagen - 1)))
                                {
                                    if ((columna >= 1) && (columna < (anchoImagen - 1)))
                                    {
                                        R = 0;
                                        G = 0;
                                        B = 0;
                                        byte* punteroPixelaux = punteroPixel;
                                        for (int i = -1; i <= 1; i++)
                                        {
                                            for (int j = -1; j <= 1; j++)
                                            {
                                                punteroPixelaux = punteroPixel + (i * anchoImagen * 3) + (j * 3);
                                                R += punteroPixelaux[2] * mascara[i + 1, j + 1];
                                                G += punteroPixelaux[1] * mascara[i + 1, j + 1];
                                                B += punteroPixelaux[0] * mascara[i + 1, j + 1];
                                            }
                                        }
                                        if (pSumar_128)
                                        {
                                            R += 128;
                                            G += 128;
                                            B += 128;
                                        }
                                    }
                                }

                                //obtiene el valor del canal de color del pixel
                                if (R > 255)
                                    R = 255;
                                if (G > 255)
                                    G = 255;
                                if (B > 255)
                                    B = 255;
                                if (R < 0)
                                    R = 0;
                                if (G < 0)
                                    G = 0;
                                if (B < 0)
                                    B = 0;
                                punteroPixelSalida[2] = (byte)R;
                                punteroPixelSalida[1] = (byte)G;
                                punteroPixelSalida[0] = (byte)B;
                                punteroPixelSalida += 3;
                                punteroPixel += 3;
                                break;
                            case PixelFormat.Format32bppArgb:
                                R = (int)(decimal)punteroPixel[2];
                                G = (int)(decimal)punteroPixel[1];
                                B = (int)(decimal)punteroPixel[0];
                                if ((renglon >= 1) && (renglon < (altoImagen - 1)))
                                {
                                    if ((columna >= 1) && (columna < (anchoImagen - 1)))
                                    {
                                        R = 0;
                                        G = 0;
                                        B = 0;
                                        byte* punteroPixelaux = punteroPixel;
                                        for (int i = -1; i <= 1; i++)
                                        {
                                            for (int j = -1; j <= 1; j++)
                                            {
                                                punteroPixelaux = punteroPixel + (i * anchoImagen * 4) + (j * 4);
                                                R += punteroPixelaux[2] * mascara[i + 1, j + 1];
                                                G += punteroPixelaux[1] * mascara[i + 1, j + 1];
                                                B += punteroPixelaux[0] * mascara[i + 1, j + 1];
                                            }
                                        }
                                        if (pSumar_128)
                                        {
                                            R += 128;
                                            G += 128;
                                            B += 128;
                                        }
                                    }
                                }

                                //obtiene el valor del canal de color del pixel
                                if (R > 255)
                                    R = 255;
                                if (G > 255)
                                    G = 255;
                                if (B > 255)
                                    B = 255;
                                if (R < 0)
                                    R = 0;
                                if (G < 0)
                                    G = 0;
                                if (B < 0)
                                    B = 0;
                                punteroPixelSalida[2] = (byte)R;
                                punteroPixelSalida[1] = (byte)G;
                                punteroPixelSalida[0] = (byte)B;
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
                                GRIS = (int)(decimal)punteroPixel[0];
                                if ((renglon >= 1) && (renglon < (altoImagen - 1)))
                                {
                                    if ((columna >= 1) && (columna < (anchoImagen - 1)))
                                    {
                                        byte* punteroPixelaux = punteroPixel;
                                        for (int i = -1; i <= 1; i++)
                                        {
                                            for (int j = -1; j <= 1; j++)
                                            {
                                                punteroPixelaux = punteroPixel + (i * anchoImagen) + (j);
                                                GRIS += punteroPixelaux[0] * mascara[i + 1, j + 1];
                                            }
                                        }
                                    }
                                }
                                //obtiene el valor del canal de color del pixel
                                if (GRIS > 255)
                                    GRIS = 255;
                                if (GRIS < 0)
                                    GRIS = 0;
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
        internal static Image aplicarBorde_Sobel_Y(Image pImagenEntrada, bool pSumar_128)
        {
            BitmapData imagenOriginalDatos = ((Bitmap)pImagenEntrada).LockBits(new Rectangle(0, 0, pImagenEntrada.Width, pImagenEntrada.Height), ImageLockMode.ReadWrite, pImagenEntrada.PixelFormat);

            int altoImagen = imagenOriginalDatos.Height;
            int anchoImagen = imagenOriginalDatos.Width;
            Bitmap imagenSalida = new Bitmap(width: anchoImagen, height: altoImagen, format: PixelFormat.Format24bppRgb);
            BitmapData imagenSalidaDatos = imagenSalida.LockBits(new Rectangle(0, 0, anchoImagen, altoImagen), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            System.IntPtr primerPixel = imagenOriginalDatos.Scan0;
            System.IntPtr primerPixelSalida = imagenSalidaDatos.Scan0;

            int GRIS, R, G, B;
            int[,] mascara = new int[3, 3];
            mascara[0, 0] = -1;
            mascara[0, 1] = -2;
            mascara[0, 2] = -1;
            mascara[1, 0] = 0;
            mascara[1, 1] = 0;
            mascara[1, 2] = 0;
            mascara[2, 0] = 1;
            mascara[2, 1] = 2;
            mascara[2, 2] = 1;
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
                                R = (int)(decimal)punteroPixel[2];
                                G = (int)(decimal)punteroPixel[1];
                                B = (int)(decimal)punteroPixel[0];
                                if ((renglon >= 1) && (renglon < (altoImagen - 1)))
                                {
                                    if ((columna >= 1) && (columna < (anchoImagen - 1)))
                                    {
                                        R = 0;
                                        G = 0;
                                        B = 0;
                                        byte* punteroPixelaux = punteroPixel;
                                        for (int i = -1; i <= 1; i++)
                                        {
                                            for (int j = -1; j <= 1; j++)
                                            {
                                                punteroPixelaux = punteroPixel + (i * anchoImagen * 3) + (j * 3);
                                                R += punteroPixelaux[2] * mascara[i + 1, j + 1];
                                                G += punteroPixelaux[1] * mascara[i + 1, j + 1];
                                                B += punteroPixelaux[0] * mascara[i + 1, j + 1];
                                            }
                                        }
                                        if (pSumar_128)
                                        {
                                            R += 128;
                                            G += 128;
                                            B += 128;
                                        }
                                    }
                                }

                                //obtiene el valor del canal de color del pixel
                                if (R > 255)
                                    R = 255;
                                if (G > 255)
                                    G = 255;
                                if (B > 255)
                                    B = 255;
                                if (R < 0)
                                    R = 0;
                                if (G < 0)
                                    G = 0;
                                if (B < 0)
                                    B = 0;
                                punteroPixelSalida[2] = (byte)R;
                                punteroPixelSalida[1] = (byte)G;
                                punteroPixelSalida[0] = (byte)B;
                                punteroPixelSalida += 3;
                                punteroPixel += 3;
                                break;
                            case PixelFormat.Format32bppArgb:
                                R = (int)(decimal)punteroPixel[2];
                                G = (int)(decimal)punteroPixel[1];
                                B = (int)(decimal)punteroPixel[0];
                                if ((renglon >= 1) && (renglon < (altoImagen - 1)))
                                {
                                    if ((columna >= 1) && (columna < (anchoImagen - 1)))
                                    {
                                        R = 0;
                                        G = 0;
                                        B = 0;
                                        byte* punteroPixelaux = punteroPixel;
                                        for (int i = -1; i <= 1; i++)
                                        {
                                            for (int j = -1; j <= 1; j++)
                                            {
                                                punteroPixelaux = punteroPixel + (i * anchoImagen * 4) + (j * 4);
                                                R += punteroPixelaux[2] * mascara[i + 1, j + 1];
                                                G += punteroPixelaux[1] * mascara[i + 1, j + 1];
                                                B += punteroPixelaux[0] * mascara[i + 1, j + 1];
                                            }
                                        }
                                        if (pSumar_128)
                                        {
                                            R += 128;
                                            G += 128;
                                            B += 128;
                                        }
                                    }
                                }

                                //obtiene el valor del canal de color del pixel
                                if (R > 255)
                                    R = 255;
                                if (G > 255)
                                    G = 255;
                                if (B > 255)
                                    B = 255;
                                if (R < 0)
                                    R = 0;
                                if (G < 0)
                                    G = 0;
                                if (B < 0)
                                    B = 0;
                                punteroPixelSalida[2] = (byte)R;
                                punteroPixelSalida[1] = (byte)G;
                                punteroPixelSalida[0] = (byte)B;
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
                                GRIS = (int)(decimal)punteroPixel[0];
                                if ((renglon >= 1) && (renglon < (altoImagen - 1)))
                                {
                                    if ((columna >= 1) && (columna < (anchoImagen - 1)))
                                    {
                                        byte* punteroPixelaux = punteroPixel;
                                        for (int i = -1; i <= 1; i++)
                                        {
                                            for (int j = -1; j <= 1; j++)
                                            {
                                                punteroPixelaux = punteroPixel + (i * anchoImagen) + (j);
                                                GRIS += punteroPixelaux[0] * mascara[i + 1, j + 1];
                                            }
                                        }
                                    }
                                }
                                //obtiene el valor del canal de color del pixel
                                if (GRIS > 255)
                                    GRIS = 255;
                                if (GRIS < 0)
                                    GRIS = 0;
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
        internal static Image aplicarBorde_Laplace_1(Image pImagenEntrada, bool pSumar_128)
        {
            BitmapData imagenOriginalDatos = ((Bitmap)pImagenEntrada).LockBits(new Rectangle(0, 0, pImagenEntrada.Width, pImagenEntrada.Height), ImageLockMode.ReadWrite, pImagenEntrada.PixelFormat);

            int altoImagen = imagenOriginalDatos.Height;
            int anchoImagen = imagenOriginalDatos.Width;
            Bitmap imagenSalida = new Bitmap(width: anchoImagen, height: altoImagen, format: PixelFormat.Format24bppRgb);
            BitmapData imagenSalidaDatos = imagenSalida.LockBits(new Rectangle(0, 0, anchoImagen, altoImagen), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            System.IntPtr primerPixel = imagenOriginalDatos.Scan0;
            System.IntPtr primerPixelSalida = imagenSalidaDatos.Scan0;

            int GRIS, R, G, B;
            int[,] mascara = new int[3, 3];
            mascara[0, 0] = 0;
            mascara[0, 1] = 1;
            mascara[0, 2] = 0;
            mascara[1, 0] = 1;
            mascara[1, 1] = -4;
            mascara[1, 2] = 1;
            mascara[2, 0] = 0;
            mascara[2, 1] = 1;
            mascara[2, 2] = 0;
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
                                R = (int)(decimal)punteroPixel[2];
                                G = (int)(decimal)punteroPixel[1];
                                B = (int)(decimal)punteroPixel[0];
                                if ((renglon >= 1) && (renglon < (altoImagen - 1)))
                                {
                                    if ((columna >= 1) && (columna < (anchoImagen - 1)))
                                    {
                                        R = 0;
                                        G = 0;
                                        B = 0;
                                        byte* punteroPixelaux = punteroPixel;
                                        for (int i = -1; i <= 1; i++)
                                        {
                                            for (int j = -1; j <= 1; j++)
                                            {
                                                punteroPixelaux = punteroPixel + (i * anchoImagen * 3) + (j * 3);
                                                R += punteroPixelaux[2] * mascara[i + 1, j + 1];
                                                G += punteroPixelaux[1] * mascara[i + 1, j + 1];
                                                B += punteroPixelaux[0] * mascara[i + 1, j + 1];
                                            }
                                        }
                                        if (pSumar_128)
                                        {
                                            R += 128;
                                            G += 128;
                                            B += 128;
                                        }
                                    }
                                }

                                //obtiene el valor del canal de color del pixel
                                if (R > 255)
                                    R = 255;
                                if (G > 255)
                                    G = 255;
                                if (B > 255)
                                    B = 255;
                                if (R < 0)
                                    R = 0;
                                if (G < 0)
                                    G = 0;
                                if (B < 0)
                                    B = 0;
                                punteroPixelSalida[2] = (byte)R;
                                punteroPixelSalida[1] = (byte)G;
                                punteroPixelSalida[0] = (byte)B;
                                punteroPixelSalida += 3;
                                punteroPixel += 3;
                                break;
                            case PixelFormat.Format32bppArgb:
                                R = (int)(decimal)punteroPixel[2];
                                G = (int)(decimal)punteroPixel[1];
                                B = (int)(decimal)punteroPixel[0];
                                if ((renglon >= 1) && (renglon < (altoImagen - 1)))
                                {
                                    if ((columna >= 1) && (columna < (anchoImagen - 1)))
                                    {
                                        R = 0;
                                        G = 0;
                                        B = 0;
                                        byte* punteroPixelaux = punteroPixel;
                                        for (int i = -1; i <= 1; i++)
                                        {
                                            for (int j = -1; j <= 1; j++)
                                            {
                                                punteroPixelaux = punteroPixel + (i * anchoImagen * 4) + (j * 4);
                                                R += punteroPixelaux[2] * mascara[i + 1, j + 1];
                                                G += punteroPixelaux[1] * mascara[i + 1, j + 1];
                                                B += punteroPixelaux[0] * mascara[i + 1, j + 1];
                                            }
                                        }
                                        if (pSumar_128)
                                        {
                                            R += 128;
                                            G += 128;
                                            B += 128;
                                        }
                                    }
                                }

                                //obtiene el valor del canal de color del pixel
                                if (R > 255)
                                    R = 255;
                                if (G > 255)
                                    G = 255;
                                if (B > 255)
                                    B = 255;
                                if (R < 0)
                                    R = 0;
                                if (G < 0)
                                    G = 0;
                                if (B < 0)
                                    B = 0;
                                punteroPixelSalida[2] = (byte)R;
                                punteroPixelSalida[1] = (byte)G;
                                punteroPixelSalida[0] = (byte)B;
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
                                GRIS = (int)(decimal)punteroPixel[0];
                                if ((renglon >= 1) && (renglon < (altoImagen - 1)))
                                {
                                    if ((columna >= 1) && (columna < (anchoImagen - 1)))
                                    {
                                        byte* punteroPixelaux = punteroPixel;
                                        for (int i = -1; i <= 1; i++)
                                        {
                                            for (int j = -1; j <= 1; j++)
                                            {
                                                punteroPixelaux = punteroPixel + (i * anchoImagen) + (j);
                                                GRIS += punteroPixelaux[0] * mascara[i + 1, j + 1];
                                            }
                                        }
                                    }
                                }
                                //obtiene el valor del canal de color del pixel
                                if (GRIS > 255)
                                    GRIS = 255;
                                if (GRIS < 0)
                                    GRIS = 0;
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
        internal static Image aplicarBorde_Laplace_2(Image pImagenEntrada, bool pSumar_128)
        {
            BitmapData imagenOriginalDatos = ((Bitmap)pImagenEntrada).LockBits(new Rectangle(0, 0, pImagenEntrada.Width, pImagenEntrada.Height), ImageLockMode.ReadWrite, pImagenEntrada.PixelFormat);

            int altoImagen = imagenOriginalDatos.Height;
            int anchoImagen = imagenOriginalDatos.Width;
            Bitmap imagenSalida = new Bitmap(width: anchoImagen, height: altoImagen, format: PixelFormat.Format24bppRgb);
            BitmapData imagenSalidaDatos = imagenSalida.LockBits(new Rectangle(0, 0, anchoImagen, altoImagen), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            System.IntPtr primerPixel = imagenOriginalDatos.Scan0;
            System.IntPtr primerPixelSalida = imagenSalidaDatos.Scan0;

            int GRIS, R, G, B;
            int[,] mascara = new int[3, 3];
            mascara[0, 0] = -1;
            mascara[0, 1] = -1;
            mascara[0, 2] = -1;
            mascara[1, 0] = -1;
            mascara[1, 1] = 8;
            mascara[1, 2] = -1;
            mascara[2, 0] = -1;
            mascara[2, 1] = -1;
            mascara[2, 2] = -1;
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
                                R = (int)(decimal)punteroPixel[2];
                                G = (int)(decimal)punteroPixel[1];
                                B = (int)(decimal)punteroPixel[0];
                                if ((renglon >= 1) && (renglon < (altoImagen - 1)))
                                {
                                    if ((columna >= 1) && (columna < (anchoImagen - 1)))
                                    {
                                        R = 0;
                                        G = 0;
                                        B = 0;
                                        byte* punteroPixelaux = punteroPixel;
                                        for (int i = -1; i <= 1; i++)
                                        {
                                            for (int j = -1; j <= 1; j++)
                                            {
                                                punteroPixelaux = punteroPixel + (i * anchoImagen * 3) + (j * 3);
                                                R += punteroPixelaux[2] * mascara[i + 1, j + 1];
                                                G += punteroPixelaux[1] * mascara[i + 1, j + 1];
                                                B += punteroPixelaux[0] * mascara[i + 1, j + 1];
                                            }
                                        }
                                        if (pSumar_128)
                                        {
                                            R += 128;
                                            G += 128;
                                            B += 128;
                                        }
                                    }
                                }

                                //obtiene el valor del canal de color del pixel
                                if (R > 255)
                                    R = 255;
                                if (G > 255)
                                    G = 255;
                                if (B > 255)
                                    B = 255;
                                if (R < 0)
                                    R = 0;
                                if (G < 0)
                                    G = 0;
                                if (B < 0)
                                    B = 0;
                                punteroPixelSalida[2] = (byte)R;
                                punteroPixelSalida[1] = (byte)G;
                                punteroPixelSalida[0] = (byte)B;
                                punteroPixelSalida += 3;
                                punteroPixel += 3;
                                break;
                            case PixelFormat.Format32bppArgb:
                                R = (int)(decimal)punteroPixel[2];
                                G = (int)(decimal)punteroPixel[1];
                                B = (int)(decimal)punteroPixel[0];
                                if ((renglon >= 1) && (renglon < (altoImagen - 1)))
                                {
                                    if ((columna >= 1) && (columna < (anchoImagen - 1)))
                                    {
                                        R = 0;
                                        G = 0;
                                        B = 0;
                                        byte* punteroPixelaux = punteroPixel;
                                        for (int i = -1; i <= 1; i++)
                                        {
                                            for (int j = -1; j <= 1; j++)
                                            {
                                                punteroPixelaux = punteroPixel + (i * anchoImagen * 4) + (j * 4);
                                                R += punteroPixelaux[2] * mascara[i + 1, j + 1];
                                                G += punteroPixelaux[1] * mascara[i + 1, j + 1];
                                                B += punteroPixelaux[0] * mascara[i + 1, j + 1];
                                            }
                                        }
                                        if (pSumar_128)
                                        {
                                            R += 128;
                                            G += 128;
                                            B += 128;
                                        }
                                    }
                                }

                                //obtiene el valor del canal de color del pixel
                                if (R > 255)
                                    R = 255;
                                if (G > 255)
                                    G = 255;
                                if (B > 255)
                                    B = 255;
                                if (R < 0)
                                    R = 0;
                                if (G < 0)
                                    G = 0;
                                if (B < 0)
                                    B = 0;
                                punteroPixelSalida[2] = (byte)R;
                                punteroPixelSalida[1] = (byte)G;
                                punteroPixelSalida[0] = (byte)B;
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
                                GRIS = (int)(decimal)punteroPixel[0];
                                if ((renglon >= 1) && (renglon < (altoImagen - 1)))
                                {
                                    if ((columna >= 1) && (columna < (anchoImagen - 1)))
                                    {
                                        byte* punteroPixelaux = punteroPixel;
                                        for (int i = -1; i <= 1; i++)
                                        {
                                            for (int j = -1; j <= 1; j++)
                                            {
                                                punteroPixelaux = punteroPixel + (i * anchoImagen) + (j);
                                                GRIS += punteroPixelaux[0] * mascara[i + 1, j + 1];
                                            }
                                        }
                                    }
                                }
                                //obtiene el valor del canal de color del pixel
                                if (GRIS > 255)
                                    GRIS = 255;
                                if (GRIS < 0)
                                    GRIS = 0;
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
        internal static Image aplicarMagGrad(Image pImagenEntrada)
        {
            BitmapData imagenOriginalDatos = ((Bitmap)pImagenEntrada).LockBits(new Rectangle(0, 0, pImagenEntrada.Width, pImagenEntrada.Height), ImageLockMode.ReadWrite, pImagenEntrada.PixelFormat);

            int altoImagen = imagenOriginalDatos.Height;
            int anchoImagen = imagenOriginalDatos.Width;
            Bitmap imagenSalida = new Bitmap(width: anchoImagen, height: altoImagen, format: PixelFormat.Format24bppRgb);
            BitmapData imagenSalidaDatos = imagenSalida.LockBits(new Rectangle(0, 0, anchoImagen, altoImagen), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            System.IntPtr primerPixel = imagenOriginalDatos.Scan0;
            System.IntPtr primerPixelSalida = imagenSalidaDatos.Scan0;

            int GRIS, R, G, B;
            int GRIS_1, R_1, G_1, B_1;
            int[,] mascaraX = new int[3, 3];
            mascaraX[0, 0] = -1;
            mascaraX[0, 1] = 0;
            mascaraX[0, 2] = 1;
            mascaraX[1, 0] = -2;
            mascaraX[1, 1] = 0;
            mascaraX[1, 2] = 2;
            mascaraX[2, 0] = -1;
            mascaraX[2, 1] = 0;
            mascaraX[2, 2] = 1;
            int[,] mascaraY = new int[3, 3];
            mascaraY[0, 0] = -1;
            mascaraY[0, 1] = -2;
            mascaraY[0, 2] = -1;
            mascaraY[1, 0] = 0;
            mascaraY[1, 1] = 0;
            mascaraY[1, 2] = 0;
            mascaraY[2, 0] = 1;
            mascaraY[2, 1] = 2;
            mascaraY[2, 2] = 1;
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
                                R = (int)(decimal)punteroPixel[2];
                                G = (int)(decimal)punteroPixel[1];
                                B = (int)(decimal)punteroPixel[0];
                                if ((renglon >= 1) && (renglon < (altoImagen - 1)))
                                {
                                    if ((columna >= 1) && (columna < (anchoImagen - 1)))
                                    {
                                        R = 0;
                                        G = 0;
                                        B = 0;
                                        R_1 = 0;
                                        G_1 = 0;
                                        B_1 = 0;
                                        byte* punteroPixelaux = punteroPixel;
                                        for (int i = -1; i <= 1; i++)
                                        {
                                            for (int j = -1; j <= 1; j++)
                                            {
                                                punteroPixelaux = punteroPixel + (i * anchoImagen * 3) + (j * 3);
                                                R += punteroPixelaux[2] * mascaraX[i + 1, j + 1];
                                                G += punteroPixelaux[1] * mascaraX[i + 1, j + 1];
                                                B += punteroPixelaux[0] * mascaraX[i + 1, j + 1];
                                                R_1 += punteroPixelaux[2] * mascaraY[i + 1, j + 1];
                                                G_1 += punteroPixelaux[1] * mascaraY[i + 1, j + 1];
                                                B_1 += punteroPixelaux[0] * mascaraY[i + 1, j + 1];
                                            }
                                        }
                                        R = (int)Math.Sqrt(Math.Pow(R, 2) + Math.Pow(R_1, 2));
                                        G = (int)Math.Sqrt(Math.Pow(G, 2) + Math.Pow(G_1, 2));
                                        B = (int)Math.Sqrt(Math.Pow(B, 2) + Math.Pow(B_1, 2));
                                    }
                                }

                                //obtiene el valor del canal de color del pixel
                                if (R > 255)
                                    R = 255;
                                if (G > 255)
                                    G = 255;
                                if (B > 255)
                                    B = 255;
                                if (R < 0)
                                    R = 0;
                                if (G < 0)
                                    G = 0;
                                if (B < 0)
                                    B = 0;
                                punteroPixelSalida[2] = (byte)R;
                                punteroPixelSalida[1] = (byte)G;
                                punteroPixelSalida[0] = (byte)B;
                                punteroPixelSalida += 3;
                                punteroPixel += 3;
                                break;
                            case PixelFormat.Format32bppArgb:
                                R = (int)(decimal)punteroPixel[2];
                                G = (int)(decimal)punteroPixel[1];
                                B = (int)(decimal)punteroPixel[0];
                                if ((renglon >= 1) && (renglon < (altoImagen - 1)))
                                {
                                    if ((columna >= 1) && (columna < (anchoImagen - 1)))
                                    {
                                        R = 0;
                                        G = 0;
                                        B = 0;
                                        R_1 = 0;
                                        G_1 = 0;
                                        B_1 = 0;
                                        byte* punteroPixelaux = punteroPixel;
                                        for (int i = -1; i <= 1; i++)
                                        {
                                            for (int j = -1; j <= 1; j++)
                                            {
                                                punteroPixelaux = punteroPixel + (i * anchoImagen * 4) + (j * 4);
                                                R += punteroPixelaux[2] * mascaraX[i + 1, j + 1];
                                                G += punteroPixelaux[1] * mascaraX[i + 1, j + 1];
                                                B += punteroPixelaux[0] * mascaraX[i + 1, j + 1];
                                                R_1 += punteroPixelaux[2] * mascaraY[i + 1, j + 1];
                                                G_1 += punteroPixelaux[1] * mascaraY[i + 1, j + 1];
                                                B_1 += punteroPixelaux[0] * mascaraY[i + 1, j + 1];
                                            }
                                        }
                                        R = (int)Math.Sqrt(Math.Pow(R, 2) + Math.Pow(R_1, 2));
                                        G = (int)Math.Sqrt(Math.Pow(G, 2) + Math.Pow(G_1, 2));
                                        B = (int)Math.Sqrt(Math.Pow(B, 2) + Math.Pow(B_1, 2));
                                    }
                                }

                                //obtiene el valor del canal de color del pixel
                                if (R > 255)
                                    R = 255;
                                if (G > 255)
                                    G = 255;
                                if (B > 255)
                                    B = 255;
                                if (R < 0)
                                    R = 0;
                                if (G < 0)
                                    G = 0;
                                if (B < 0)
                                    B = 0;
                                punteroPixelSalida[2] = (byte)R;
                                punteroPixelSalida[1] = (byte)G;
                                punteroPixelSalida[0] = (byte)B;
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
                                GRIS = (int)(decimal)punteroPixel[0];
                                if ((renglon >= 1) && (renglon < (altoImagen - 1)))
                                {
                                    if ((columna >= 1) && (columna < (anchoImagen - 1)))
                                    {
                                        byte* punteroPixelaux = punteroPixel;
                                        for (int i = -1; i <= 1; i++)
                                        {
                                            for (int j = -1; j <= 1; j++)
                                            {
                                                punteroPixelaux = punteroPixel + (i * anchoImagen) + (j);
                                                GRIS += punteroPixelaux[0] * mascaraX[i + 1, j + 1];
                                            }
                                        }
                                    }
                                }
                                //obtiene el valor del canal de color del pixel
                                if (GRIS > 255)
                                    GRIS = 255;
                                if (GRIS < 0)
                                    GRIS = 0;
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
        internal static Image aplicarPerfilado_Laplace_2(Image pImagenEntrada, bool pSumar_128)
        {
            BitmapData imagenOriginalDatos = ((Bitmap)pImagenEntrada).LockBits(new Rectangle(0, 0, pImagenEntrada.Width, pImagenEntrada.Height), ImageLockMode.ReadWrite, pImagenEntrada.PixelFormat);

            int altoImagen = imagenOriginalDatos.Height;
            int anchoImagen = imagenOriginalDatos.Width;
            Bitmap imagenSalida = new Bitmap(width: anchoImagen, height: altoImagen, format: PixelFormat.Format24bppRgb);
            BitmapData imagenSalidaDatos = imagenSalida.LockBits(new Rectangle(0, 0, anchoImagen, altoImagen), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            System.IntPtr primerPixel = imagenOriginalDatos.Scan0;
            System.IntPtr primerPixelSalida = imagenSalidaDatos.Scan0;

            int GRIS, R, G, B;
            int[,] mascara = new int[3, 3];
            mascara[0, 0] = -1;
            mascara[0, 1] = -1;
            mascara[0, 2] = -1;
            mascara[1, 0] = -1;
            mascara[1, 1] = 9;
            mascara[1, 2] = -1;
            mascara[2, 0] = -1;
            mascara[2, 1] = -1;
            mascara[2, 2] = -1;
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
                                R = (int)(decimal)punteroPixel[2];
                                G = (int)(decimal)punteroPixel[1];
                                B = (int)(decimal)punteroPixel[0];
                                if ((renglon >= 1) && (renglon < (altoImagen - 1)))
                                {
                                    if ((columna >= 1) && (columna < (anchoImagen - 1)))
                                    {
                                        R = 0;
                                        G = 0;
                                        B = 0;
                                        byte* punteroPixelaux = punteroPixel;
                                        for (int i = -1; i <= 1; i++)
                                        {
                                            for (int j = -1; j <= 1; j++)
                                            {
                                                punteroPixelaux = punteroPixel + (i * anchoImagen * 3) + (j * 3);
                                                R += punteroPixelaux[2] * mascara[i + 1, j + 1];
                                                G += punteroPixelaux[1] * mascara[i + 1, j + 1];
                                                B += punteroPixelaux[0] * mascara[i + 1, j + 1];
                                            }
                                        }
                                        if (pSumar_128)
                                        {
                                            R += 128;
                                            G += 128;
                                            B += 128;
                                        }
                                    }
                                }

                                //obtiene el valor del canal de color del pixel
                                if (R > 255)
                                    R = 255;
                                if (G > 255)
                                    G = 255;
                                if (B > 255)
                                    B = 255;
                                if (R < 0)
                                    R = 0;
                                if (G < 0)
                                    G = 0;
                                if (B < 0)
                                    B = 0;
                                punteroPixelSalida[2] = (byte)R;
                                punteroPixelSalida[1] = (byte)G;
                                punteroPixelSalida[0] = (byte)B;
                                punteroPixelSalida += 3;
                                punteroPixel += 3;
                                break;
                            case PixelFormat.Format32bppArgb:
                                R = (int)(decimal)punteroPixel[2];
                                G = (int)(decimal)punteroPixel[1];
                                B = (int)(decimal)punteroPixel[0];
                                if ((renglon >= 1) && (renglon < (altoImagen - 1)))
                                {
                                    if ((columna >= 1) && (columna < (anchoImagen - 1)))
                                    {
                                        R = 0;
                                        G = 0;
                                        B = 0;
                                        byte* punteroPixelaux = punteroPixel;
                                        for (int i = -1; i <= 1; i++)
                                        {
                                            for (int j = -1; j <= 1; j++)
                                            {
                                                punteroPixelaux = punteroPixel + (i * anchoImagen * 4) + (j * 4);
                                                R += punteroPixelaux[2] * mascara[i + 1, j + 1];
                                                G += punteroPixelaux[1] * mascara[i + 1, j + 1];
                                                B += punteroPixelaux[0] * mascara[i + 1, j + 1];
                                            }
                                        }
                                        if (pSumar_128)
                                        {
                                            R += 128;
                                            G += 128;
                                            B += 128;
                                        }
                                    }
                                }

                                //obtiene el valor del canal de color del pixel
                                if (R > 255)
                                    R = 255;
                                if (G > 255)
                                    G = 255;
                                if (B > 255)
                                    B = 255;
                                if (R < 0)
                                    R = 0;
                                if (G < 0)
                                    G = 0;
                                if (B < 0)
                                    B = 0;
                                punteroPixelSalida[2] = (byte)R;
                                punteroPixelSalida[1] = (byte)G;
                                punteroPixelSalida[0] = (byte)B;
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
                                GRIS = (int)(decimal)punteroPixel[0];
                                if ((renglon >= 1) && (renglon < (altoImagen - 1)))
                                {
                                    if ((columna >= 1) && (columna < (anchoImagen - 1)))
                                    {
                                        byte* punteroPixelaux = punteroPixel;
                                        for (int i = -1; i <= 1; i++)
                                        {
                                            for (int j = -1; j <= 1; j++)
                                            {
                                                punteroPixelaux = punteroPixel + (i * anchoImagen) + (j);
                                                GRIS += punteroPixelaux[0] * mascara[i + 1, j + 1];
                                            }
                                        }
                                    }
                                }
                                //obtiene el valor del canal de color del pixel
                                if (GRIS > 255)
                                    GRIS = 255;
                                if (GRIS < 0)
                                    GRIS = 0;
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
        internal static Image aplicarPerfilado_Laplace_1(Image pImagenEntrada, int a, bool pSumar_128)
        {
            BitmapData imagenOriginalDatos = ((Bitmap)pImagenEntrada).LockBits(new Rectangle(0, 0, pImagenEntrada.Width, pImagenEntrada.Height), ImageLockMode.ReadWrite, pImagenEntrada.PixelFormat);

            int altoImagen = imagenOriginalDatos.Height;
            int anchoImagen = imagenOriginalDatos.Width;
            Bitmap imagenSalida = new Bitmap(width: anchoImagen, height: altoImagen, format: PixelFormat.Format24bppRgb);
            BitmapData imagenSalidaDatos = imagenSalida.LockBits(new Rectangle(0, 0, anchoImagen, altoImagen), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            System.IntPtr primerPixel = imagenOriginalDatos.Scan0;
            System.IntPtr primerPixelSalida = imagenSalidaDatos.Scan0;

            int GRIS, R, G, B;
            int[,] mascara = new int[3, 3];
            mascara[0, 0] = 0;
            mascara[0, 1] = a;
            mascara[0, 2] = 0;
            mascara[1, 0] = a;
            mascara[1, 1] = -4*a+1;
            mascara[1, 2] = a;
            mascara[2, 0] = 0;
            mascara[2, 1] = a;
            mascara[2, 2] = 0;
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
                                R = (int)(decimal)punteroPixel[2];
                                G = (int)(decimal)punteroPixel[1];
                                B = (int)(decimal)punteroPixel[0];
                                if ((renglon >= 1) && (renglon < (altoImagen - 1)))
                                {
                                    if ((columna >= 1) && (columna < (anchoImagen - 1)))
                                    {
                                        R = 0;
                                        G = 0;
                                        B = 0;
                                        byte* punteroPixelaux = punteroPixel;
                                        for (int i = -1; i <= 1; i++)
                                        {
                                            for (int j = -1; j <= 1; j++)
                                            {
                                                punteroPixelaux = punteroPixel + (i * anchoImagen * 3) + (j * 3);
                                                R += punteroPixelaux[2] * mascara[i + 1, j + 1];
                                                G += punteroPixelaux[1] * mascara[i + 1, j + 1];
                                                B += punteroPixelaux[0] * mascara[i + 1, j + 1];
                                            }
                                        }
                                        if (pSumar_128)
                                        {
                                            R += 128;
                                            G += 128;
                                            B += 128;
                                        }
                                    }
                                }

                                //obtiene el valor del canal de color del pixel
                                if (R > 255)
                                    R = 255;
                                if (G > 255)
                                    G = 255;
                                if (B > 255)
                                    B = 255;
                                if (R < 0)
                                    R = 0;
                                if (G < 0)
                                    G = 0;
                                if (B < 0)
                                    B = 0;
                                punteroPixelSalida[2] = (byte)R;
                                punteroPixelSalida[1] = (byte)G;
                                punteroPixelSalida[0] = (byte)B;
                                punteroPixelSalida += 3;
                                punteroPixel += 3;
                                break;
                            case PixelFormat.Format32bppArgb:
                                R = (int)(decimal)punteroPixel[2];
                                G = (int)(decimal)punteroPixel[1];
                                B = (int)(decimal)punteroPixel[0];
                                if ((renglon >= 1) && (renglon < (altoImagen - 1)))
                                {
                                    if ((columna >= 1) && (columna < (anchoImagen - 1)))
                                    {
                                        R = 0;
                                        G = 0;
                                        B = 0;
                                        byte* punteroPixelaux = punteroPixel;
                                        for (int i = -1; i <= 1; i++)
                                        {
                                            for (int j = -1; j <= 1; j++)
                                            {
                                                punteroPixelaux = punteroPixel + (i * anchoImagen * 4) + (j * 4);
                                                R += punteroPixelaux[2] * mascara[i + 1, j + 1];
                                                G += punteroPixelaux[1] * mascara[i + 1, j + 1];
                                                B += punteroPixelaux[0] * mascara[i + 1, j + 1];
                                            }
                                        }
                                        if (pSumar_128)
                                        {
                                            R += 128;
                                            G += 128;
                                            B += 128;
                                        }
                                    }
                                }

                                //obtiene el valor del canal de color del pixel
                                if (R > 255)
                                    R = 255;
                                if (G > 255)
                                    G = 255;
                                if (B > 255)
                                    B = 255;
                                if (R < 0)
                                    R = 0;
                                if (G < 0)
                                    G = 0;
                                if (B < 0)
                                    B = 0;
                                punteroPixelSalida[2] = (byte)R;
                                punteroPixelSalida[1] = (byte)G;
                                punteroPixelSalida[0] = (byte)B;
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
                                GRIS = (int)(decimal)punteroPixel[0];
                                if ((renglon >= 1) && (renglon < (altoImagen - 1)))
                                {
                                    if ((columna >= 1) && (columna < (anchoImagen - 1)))
                                    {
                                        byte* punteroPixelaux = punteroPixel;
                                        for (int i = -1; i <= 1; i++)
                                        {
                                            for (int j = -1; j <= 1; j++)
                                            {
                                                punteroPixelaux = punteroPixel + (i * anchoImagen) + (j);
                                                GRIS += punteroPixelaux[0] * mascara[i + 1, j + 1];
                                            }
                                        }
                                    }
                                }
                                //obtiene el valor del canal de color del pixel
                                if (GRIS > 255)
                                    GRIS = 255;
                                if (GRIS < 0)
                                    GRIS = 0;
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
