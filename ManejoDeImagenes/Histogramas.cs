using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManejoDeImagenes
{
    class Histogramas
    {
        internal static int[][] obten_histograma(Image pImagenEntrada)
        {
            BitmapData imagenOriginalDatos = ((Bitmap)pImagenEntrada).LockBits(new Rectangle(0, 0, pImagenEntrada.Width, pImagenEntrada.Height), ImageLockMode.ReadWrite, pImagenEntrada.PixelFormat);

            int altoImagen = imagenOriginalDatos.Height;
            int anchoImagen = imagenOriginalDatos.Width;
 
            System.IntPtr primerPixel = imagenOriginalDatos.Scan0;

            int[] R = new int[256], G = new int[256], B = new int[256];
            int[][] canales = new int[3][]; 
            unsafe
            {
                byte* punteroPixel = (byte*)(void*)primerPixel;
                
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
                                R[(int)punteroPixel[2]]++;
                                G[(int)punteroPixel[1]]++;
                                B[(int)punteroPixel[0]]++;
                                punteroPixel += 3;
                                break;
                            case PixelFormat.Format32bppArgb:
                                //obtiene el valor del canal de color del pixel
                                R[(int)punteroPixel[2]]++;
                                G[(int)punteroPixel[1]]++;
                                B[(int)punteroPixel[0]]++;
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
                                R[(int)punteroPixel[0]]++;
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
            ((Bitmap)pImagenEntrada).UnlockBits(imagenOriginalDatos);

            canales[0] = R;
            canales[1] = G;
            canales[2] = B;
            return canales;
        }
        internal static Image estiramiento(Image pImagenEntrada, int limite_inf_canal_1, int limite_inf_canal_2, int limite_inf_canal_3, int limite_sup_canal_1, int limite_sup_canal_2, int limite_sup_canal_3)
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

                                R = 255 * (R - limite_inf_canal_3) / (limite_sup_canal_3 - limite_inf_canal_3);
                                G = 255 * (G - limite_inf_canal_2) / (limite_sup_canal_2 - limite_inf_canal_2);
                                B = 255 * (B - limite_inf_canal_1) / (limite_sup_canal_1 - limite_inf_canal_1);

                                if (R > 255) { R = 255; }
                                if (G > 255) { G = 255; }
                                if (B > 255) { B = 255; }
                                if (R < 0) { R = 0; }
                                if (G < 0) { G = 0; }
                                if (B < 0) { B = 0; }

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

                                R = 255 * (R - limite_inf_canal_3) / (limite_sup_canal_3 - limite_inf_canal_3);
                                G = 255 * (G - limite_inf_canal_2) / (limite_sup_canal_2 - limite_inf_canal_2);
                                B = 255 * (B - limite_inf_canal_1) / (limite_sup_canal_1 - limite_inf_canal_1);

                                if (R > 255) { R = 255; }
                                if (G > 255) { G = 255; }
                                if (B > 255) { B = 255; }
                                if (R < 0) { R = 0; }
                                if (G < 0) { G = 0; }
                                if (B < 0) { B = 0; }

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
                                GRIS = 255 * (GRIS - limite_inf_canal_1) / (limite_sup_canal_1 - limite_inf_canal_1);
                                if (GRIS > 255) { B = 255; }
                                if (GRIS < 0) { R = 0; }
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
        internal static Image aplica_equalizacion(Image pImagenEntrada, int[][] pEcualizacion)
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

                                R = pEcualizacion[2][R];
                                G = pEcualizacion[1][G];
                                B = pEcualizacion[0][B];

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

                                R = pEcualizacion[2][R];
                                G = pEcualizacion[1][G];
                                B = pEcualizacion[0][B];

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

                                GRIS = pEcualizacion[0][GRIS];

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
        internal static int[][] obten_equalizacion(int[][] pHistograma, int numero_pixeles)
        {
            int[][] ecualizacion;
            ecualizacion = new int[3][];

            for(int canales = 0;canales<3;canales++)
            {
                int[] aux = new int[256];
                int acumulado = 0; 
                
                aux[0] = 0;
                acumulado=pHistograma[canales][0];
                for(int i = 1; i<255;i++)
                {
                    aux[i] = acumulado * 255 / numero_pixeles;
                    acumulado += pHistograma[canales][i];
                }
                aux[255] = 255;
                ecualizacion[canales] = aux;
            }
            return ecualizacion;
        }
    }
}
