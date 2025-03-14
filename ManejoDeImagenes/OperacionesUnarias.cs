using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManejoDeImagenes
{
    class OperacionesUnarias
    {
        internal static Image aplicaOperaciones(Image pImagenEntrada, int suma_canal_1, int suma_canal_2, int suma_canal_3, decimal mult_canal_1, decimal mult_canal_2, decimal mult_canal_3, decimal div_canal_1, decimal div_canal_2, decimal div_canal_3, decimal gama_canal_1, decimal gama_canal_2, decimal gama_canal_3)
        {
            BitmapData imagenOriginalDatos = ((Bitmap)pImagenEntrada).LockBits(new Rectangle(0, 0, pImagenEntrada.Width, pImagenEntrada.Height), ImageLockMode.ReadWrite, pImagenEntrada.PixelFormat);

            int altoImagen = imagenOriginalDatos.Height;
            int anchoImagen = imagenOriginalDatos.Width;
            Bitmap imagenSalida = new Bitmap(width: anchoImagen, height: altoImagen, format: PixelFormat.Format24bppRgb);
            BitmapData imagenSalidaDatos = imagenSalida.LockBits(new Rectangle(0, 0, anchoImagen, altoImagen), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            System.IntPtr primerPixel = imagenOriginalDatos.Scan0;
            System.IntPtr primerPixelSalida = imagenSalidaDatos.Scan0;

            int GRIS,R,G,B;
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
                                R = (int)((decimal)punteroPixel[2] * mult_canal_1 / div_canal_1) + suma_canal_1;
                                G = (int)((decimal)punteroPixel[1] * mult_canal_2 / div_canal_2) + suma_canal_2;
                                B = (int)((decimal)punteroPixel[0] * mult_canal_3 / div_canal_3) + suma_canal_3;
                                R = (int)Math.Pow((double)R, (double)gama_canal_1);
                                G = (int)Math.Pow((double)G, (double)gama_canal_2);
                                B = (int)Math.Pow((double)B, (double)gama_canal_3);
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
                                //obtiene el valor del canal de color del pixel
                                R = (int)((decimal)punteroPixel[2] * mult_canal_1 / div_canal_1) + suma_canal_1;
                                G = (int)((decimal)punteroPixel[1] * mult_canal_2 / div_canal_2) + suma_canal_2;
                                B = (int)((decimal)punteroPixel[0] * mult_canal_3 / div_canal_3) + suma_canal_3;
                                R = (int)Math.Pow((double)R, (double)gama_canal_1);
                                G = (int)Math.Pow((double)G, (double)gama_canal_2);
                                B = (int)Math.Pow((double)B, (double)gama_canal_3);
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
                                GRIS = (int)((decimal)punteroPixel[0] * mult_canal_1 / div_canal_1) + suma_canal_1;
                                GRIS = (int)Math.Pow((double)GRIS, (double)gama_canal_1);
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
        internal static Image umbralBinario(Image pImagenEntrada, int limite_inf_canal_1, int limite_inf_canal_2, int limite_inf_canal_3, int limite_sup_canal_1, int limite_sup_canal_2, int limite_sup_canal_3, bool inverso)
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
                                //obtiene el valor del canal de color del pixel
                                R = (int)punteroPixel[2];
                                G = (int)punteroPixel[1];
                                B = (int)punteroPixel[0];
                                if ((R > limite_sup_canal_1) || (R < limite_inf_canal_1))
                                    R = 0;
                                else
                                    R = 255;
                                if ((G > limite_sup_canal_2) || (G < limite_inf_canal_2))
                                    G = 0;
                                else
                                    G = 255;
                                if ((B > limite_sup_canal_3) || (B < limite_inf_canal_3))
                                    B = 0;
                                else
                                    B = 255;
                                if (inverso)
                                {
                                    R = 255 - R;
                                    G = 255 - G;
                                    B = 255 - B;
                                }
                                punteroPixelSalida[2] = (byte)R;
                                punteroPixelSalida[1] = (byte)G;
                                punteroPixelSalida[0] = (byte)B;
                                punteroPixelSalida += 3;
                                punteroPixel += 3;
                                break;
                            case PixelFormat.Format32bppArgb:
                                //obtiene el valor del canal de color del pixel
                                R = (int)punteroPixel[2];
                                G = (int)punteroPixel[1];
                                B = (int)punteroPixel[0];
                                if ((R > limite_sup_canal_1) || (R < limite_inf_canal_1))
                                    R = 0;
                                else
                                    R = 255;
                                if ((G > limite_sup_canal_2) || (G < limite_inf_canal_2))
                                    G = 0;
                                else
                                    G = 255;
                                if ((B > limite_sup_canal_3) || (B < limite_inf_canal_3))
                                    B = 0;
                                else
                                    B = 255;
                                if (inverso)
                                {
                                    R = 255 - R;
                                    G = 255 - G;
                                    B = 255 - B;
                                }
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
                                GRIS = (int)punteroPixel[0];
                                if ((GRIS > limite_sup_canal_1) || (GRIS < limite_inf_canal_1))
                                    GRIS = 0;
                                else
                                    GRIS = 255;
                                if (inverso)
                                {
                                    GRIS = 255 - GRIS;
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

            return imagenSalida;
        }
        internal static Image umbralCorte(Image pImagenEntrada, int limite_inf_canal_1, int limite_inf_canal_2, int limite_inf_canal_3, int limite_sup_canal_1, int limite_sup_canal_2, int limite_sup_canal_3, bool inverso, bool extension)
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
                                //obtiene el valor del canal de color del pixel
                                R = (int)punteroPixel[2];
                                G = (int)punteroPixel[1];
                                B = (int)punteroPixel[0];
                                if ((R > limite_sup_canal_1) || (R < limite_inf_canal_1))
                                    R = 0;
                                else
                                    if (extension)
                                        R = 255 * (R - limite_inf_canal_1) / (limite_sup_canal_1 - limite_inf_canal_1);
                                if ((G > limite_sup_canal_2) || (G < limite_inf_canal_2))
                                    G = 0;
                                else
                                    if (extension)
                                        G = 255 * (G - limite_inf_canal_1) / (limite_sup_canal_1 - limite_inf_canal_1);
                                if ((B > limite_sup_canal_3) || (B < limite_inf_canal_3))
                                    B = 0;
                                else
                                    if (extension)
                                        B = 255 * (B - limite_inf_canal_1) / (limite_sup_canal_1 - limite_inf_canal_1);
                                if (inverso)
                                {
                                    R = 255 - R;
                                    G = 255 - G;
                                    B = 255 - B;
                                }
                                punteroPixelSalida[2] = (byte)R;
                                punteroPixelSalida[1] = (byte)G;
                                punteroPixelSalida[0] = (byte)B;
                                punteroPixelSalida += 3;
                                punteroPixel += 3;
                                break;
                            case PixelFormat.Format32bppArgb:
                                //obtiene el valor del canal de color del pixel
                                R = (int)punteroPixel[2];
                                G = (int)punteroPixel[1];
                                B = (int)punteroPixel[0];
                                if ((R > limite_sup_canal_1) || (R < limite_inf_canal_1))
                                    R = 0;
                                else
                                    if (extension)
                                    R = 255 * (R - limite_inf_canal_1) / (limite_sup_canal_1 - limite_inf_canal_1);
                                if ((G > limite_sup_canal_2) || (G < limite_inf_canal_2))
                                    G = 0;
                                else
                                    if (extension)
                                    G = 255 * (G - limite_inf_canal_1) / (limite_sup_canal_1 - limite_inf_canal_1);
                                if ((B > limite_sup_canal_3) || (B < limite_inf_canal_3))
                                    B = 0;
                                else
                                    if (extension)
                                    B = 255 * (B - limite_inf_canal_1) / (limite_sup_canal_1 - limite_inf_canal_1);
                                if (inverso)
                                {
                                    R = 255 - R;
                                    G = 255 - G;
                                    B = 255 - B;
                                }
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
                                GRIS = (int)punteroPixel[0];
                                if ((GRIS > limite_sup_canal_1) || (GRIS < limite_inf_canal_1))
                                    GRIS = 0;
                                if (inverso)
                                {
                                    GRIS = 255 - GRIS;
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

            return imagenSalida;
        }
        internal static Image umbralEscalon(Image pImagenEntrada, int[] umbrales)
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
                                //obtiene el valor del canal de color del pixel
                                R = (int)punteroPixel[2];
                                G = (int)punteroPixel[1];
                                B = (int)punteroPixel[0];
                                if (R > umbrales[umbrales.Length - 1])
                                { R = 255; }
                                else
                                {
                                    for (int i = 0; i < umbrales.Length; i++)
                                    {
                                        if (R <= umbrales[i])
                                        {
                                            if (i == 0)
                                            { R = 0; }
                                            else
                                            { R = umbrales[i - 1]; }
                                            break;
                                        }
                                    }
                                }
                                if (G > umbrales[umbrales.Length - 1])
                                { G = 255; }
                                else
                                {
                                    for (int i = 0; i < umbrales.Length; i++)
                                    {
                                        if (G <= umbrales[i])
                                        {
                                            if (i == 0)
                                            { G = 0; }
                                            else
                                            { G = umbrales[i - 1]; }
                                            break;
                                        }
                                    }
                                }
                                if (B > umbrales[umbrales.Length - 1])
                                { B = 255; }
                                else
                                {
                                    for (int i = 0; i < umbrales.Length; i++)
                                    {
                                        if (B <= umbrales[i])
                                        {
                                            if (i == 0)
                                            { B = 0; }
                                            else
                                            { B = umbrales[i - 1]; }
                                            break;
                                        }
                                    }
                                }
                                punteroPixelSalida[2] = (byte)R;
                                punteroPixelSalida[1] = (byte)G;
                                punteroPixelSalida[0] = (byte)B;
                                punteroPixelSalida += 3;
                                punteroPixel += 3;
                                break;
                            case PixelFormat.Format32bppArgb:
                                //obtiene el valor del canal de color del pixel
                                R = (int)punteroPixel[2];
                                G = (int)punteroPixel[1];
                                B = (int)punteroPixel[0];
                                if (R > umbrales[umbrales.Length - 1])
                                { R = 255; }
                                else
                                {
                                    for (int i = 0; i < umbrales.Length; i++)
                                    {
                                        if (R <= umbrales[i])
                                        {
                                            if (i == 0)
                                            { R = 0; }
                                            else
                                            { R = umbrales[i - 1]; }
                                            break;
                                        }
                                    }
                                }
                                if (G > umbrales[umbrales.Length - 1])
                                { G = 255; }
                                else
                                {
                                    for (int i = 0; i < umbrales.Length; i++)
                                    {
                                        if (G <= umbrales[i])
                                        {
                                            if (i == 0)
                                            { G = 0; }
                                            else
                                            { G = umbrales[i - 1]; }
                                            break;
                                        }
                                    }
                                }
                                if (B > umbrales[umbrales.Length - 1])
                                { B = 255; }
                                else
                                {
                                    for (int i = 0; i < umbrales.Length; i++)
                                    {
                                        if (B <= umbrales[i])
                                        {
                                            if (i == 0)
                                            { B = 0; }
                                            else
                                            { B = umbrales[i - 1]; }
                                            break;
                                        }
                                    }
                                }
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
                                GRIS = (int)punteroPixel[0];
                                if (GRIS >= umbrales[umbrales.Length - 1])
                                { GRIS = 255; }
                                else
                                {
                                    for (int i = 0; i < umbrales.Length; i++)
                                    {
                                        if (GRIS <= umbrales[i])
                                        {
                                            if (i == 0)
                                            { GRIS = 0; }
                                            else
                                            { GRIS = umbrales[i - 1]; }
                                            break;
                                        }
                                    }
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

            return imagenSalida;
        }
    }
}
