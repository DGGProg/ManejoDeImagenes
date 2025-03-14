using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManejoDeImagenes
{
    class Ruido
    {
        internal static Image aplicarRuido(Image pImagenEntrada, int Gauss_centro, decimal Gauss_sigma, int Gauss_x100, int Uniforme_a, int Uniforme_b, int Uniforme_x100, int SyP_a, int SyP_b, int SyP_x100)
        {
            BitmapData imagenOriginalDatos = ((Bitmap)pImagenEntrada).LockBits(new Rectangle(0, 0, pImagenEntrada.Width, pImagenEntrada.Height), ImageLockMode.ReadWrite, pImagenEntrada.PixelFormat);

            int altoImagen = imagenOriginalDatos.Height;
            int anchoImagen = imagenOriginalDatos.Width;
            Bitmap imagenSalida = new Bitmap(width: anchoImagen, height: altoImagen, format: PixelFormat.Format24bppRgb);
            BitmapData imagenSalidaDatos = imagenSalida.LockBits(new Rectangle(0, 0, anchoImagen, altoImagen), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            System.IntPtr primerPixel = imagenOriginalDatos.Scan0;
            System.IntPtr primerPixelSalida = imagenSalidaDatos.Scan0;

            int GRIS, R, G, B, ruido_aux;
            double a, e;
            Random gauss = new Random(), uniforme = new Random(), SyP = new Random(), rand = new Random();
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
                                if (gauss.Next(0, 100) < Gauss_x100)
                                {
                                    double u1 = rand.NextDouble(); //these are uniform(0,1) random doubles
                                    double u2 = rand.NextDouble();
                                    double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) *
                                                 Math.Sin(2.0 * Math.PI * u2); //random normal(0,1)
                                    double randNormal =
                                                 Gauss_centro + (double)Gauss_sigma * randStdNormal; //random normal(mean,stdDev^2)
                                    ruido_aux = (int)randNormal;
                                    R += ruido_aux;
                                    G += ruido_aux;
                                    B += ruido_aux;
                                }
                                if (uniforme.Next(0, 100) < Uniforme_x100)
                                {
                                    ruido_aux = uniforme.Next(Uniforme_a, Uniforme_b);
                                    R += ruido_aux;
                                    G += ruido_aux;
                                    B += ruido_aux;
                                }
                                if (SyP.Next(0, 100) < SyP_x100)
                                {
                                    if (SyP.Next(0, 100) < 50)
                                    {
                                        R = G = B = SyP_a;
                                    }
                                    else
                                    {
                                        R = G = B = SyP_b;
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
                                if (gauss.Next(0, 100) < Gauss_x100)
                                {
                                    double u1 = rand.NextDouble(); //these are uniform(0,1) random doubles
                                    double u2 = rand.NextDouble();
                                    double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) *
                                                 Math.Sin(2.0 * Math.PI * u2); //random normal(0,1)
                                    double randNormal =
                                                 Gauss_centro + (double)Gauss_sigma * randStdNormal; //random normal(mean,stdDev^2)
                                    ruido_aux = (int)randNormal;
                                    R += ruido_aux;
                                    G += ruido_aux;
                                    B += ruido_aux;
                                }
                                if (uniforme.Next(0, 100) < Uniforme_x100)
                                {
                                    ruido_aux = uniforme.Next(Uniforme_a, Uniforme_b);
                                    R += ruido_aux;
                                    G += ruido_aux;
                                    B += ruido_aux;
                                }
                                if (SyP.Next(0, 100) < SyP_x100)
                                {
                                    if (SyP.Next(0, 100) < 50)
                                    {
                                        R = G = B = SyP_a;
                                    }
                                    else
                                    {
                                        R = G = B = SyP_b;
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
                                if (gauss.Next(0, 100) < Gauss_x100)
                                {
                                    double u1 = rand.NextDouble(); //these are uniform(0,1) random doubles
                                    double u2 = rand.NextDouble();
                                    double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) *
                                                 Math.Sin(2.0 * Math.PI * u2); //random normal(0,1)
                                    double randNormal =
                                                 Gauss_centro + (double)Gauss_sigma * randStdNormal; //random normal(mean,stdDev^2)
                                    ruido_aux = (int)randNormal;
                                    GRIS += ruido_aux;

                                }
                                if (uniforme.Next(0, 100) < Uniforme_x100)
                                {
                                    ruido_aux = uniforme.Next(Uniforme_a, Uniforme_b);
                                    GRIS += ruido_aux;

                                }
                                if (SyP.Next(0, 100) < SyP_x100)
                                {
                                    if (SyP.Next(0, 100) < 50)
                                    {
                                        GRIS = SyP_a;
                                    }
                                    else
                                    {
                                        GRIS = SyP_b;
                                    }
                                }

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
