using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManejoDeImagenes
{
    class Filtros
    {
        internal static Image aplicarFiltro(Image pImagenEntrada, int filtro, int tamano_mascara, double sigma, int T)
        {
            BitmapData imagenOriginalDatos = ((Bitmap)pImagenEntrada).LockBits(new Rectangle(0, 0, pImagenEntrada.Width, pImagenEntrada.Height), ImageLockMode.ReadWrite, pImagenEntrada.PixelFormat);

            int altoImagen = imagenOriginalDatos.Height;
            int anchoImagen = imagenOriginalDatos.Width;
            Bitmap imagenSalida = new Bitmap(width: anchoImagen, height: altoImagen, format: PixelFormat.Format24bppRgb);
            BitmapData imagenSalidaDatos = imagenSalida.LockBits(new Rectangle(0, 0, anchoImagen, altoImagen), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            System.IntPtr primerPixel = imagenOriginalDatos.Scan0;
            System.IntPtr primerPixelSalida = imagenSalidaDatos.Scan0;

            int GRIS, R, G, B;
            int pos_medio = (int)Math.Round((decimal)((tamano_mascara *tamano_mascara)/2), MidpointRounding.AwayFromZero);
            int[,] mascara_MedianaPonderada = new int[3,3];
            mascara_MedianaPonderada[0, 0] = 1;
            mascara_MedianaPonderada[0, 1] = 2;
            mascara_MedianaPonderada[0, 2] = 1;
            mascara_MedianaPonderada[1, 0] = 2;
            mascara_MedianaPonderada[1, 1] = 4;
            mascara_MedianaPonderada[1, 2] = 2;
            mascara_MedianaPonderada[2, 0] = 1;
            mascara_MedianaPonderada[2, 1] = 2;
            mascara_MedianaPonderada[2, 2] = 1;
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
                                if ((renglon >= Math.Floor((decimal)(tamano_mascara / 2))) && (renglon < (altoImagen - Math.Floor((decimal)(tamano_mascara / 2)))))
                                {
                                    if ((columna >= Math.Floor((decimal)(tamano_mascara / 2))) && (columna < (anchoImagen - Math.Floor((decimal)(tamano_mascara / 2)))))
                                    {
                                        R = G = B = 0;
                                        int aux = (int)Math.Floor((decimal)(tamano_mascara / 2));
                                        byte* punteroPixelaux = punteroPixel;
                                        List<int> l_r = new List<int>();
                                        List<int> l_g = new List<int>();
                                        List<int> l_b = new List<int>();
                                        switch (filtro)
                                        {
                                            case 1: //Media
                                                for (int i = -aux; i <= aux; i++)
                                                {
                                                    for (int j = -aux; j <= aux; j++)
                                                    {
                                                        punteroPixelaux = punteroPixel + (i * anchoImagen * 3) + (j * 3);
                                                        R += punteroPixelaux[2] / (tamano_mascara * tamano_mascara);
                                                        G += punteroPixelaux[1] / (tamano_mascara * tamano_mascara);
                                                        B += punteroPixelaux[0] / (tamano_mascara * tamano_mascara);
                                                    }
                                                }
                                                break;
                                            case 2: //Gaussiano
                                                double e, a;
                                                for (int i = -aux; i <= aux; i++)
                                                {
                                                    for (int j = -aux; j <= aux; j++)
                                                    {
                                                        punteroPixelaux = punteroPixel + (i * anchoImagen * 3) + (j * 3);
                                                        e = Math.Exp(-1 * ((Math.Pow(i, 2) + Math.Pow(j, 2)) / (2 * Math.Pow(sigma, 2))));
                                                        a = (1 / (2 * Math.PI * Math.Pow(sigma, 2))) * e;
                                                        R += (int)(punteroPixelaux[2] * a);
                                                        G += (int)(punteroPixelaux[1] * a);
                                                        B += (int)(punteroPixelaux[0] * a);
                                                    }
                                                }
                                                break;
                                            case 3: //Mediana
                                                for (int i = -aux; i <= aux; i++)
                                                {
                                                    for (int j = -aux; j <= aux; j++)
                                                    {
                                                        punteroPixelaux = punteroPixel + (i * anchoImagen * 3) + (j * 3);
                                                        l_r.Add(punteroPixelaux[2]);
                                                        l_g.Add(punteroPixelaux[1]);
                                                        l_b.Add(punteroPixelaux[0]);
                                                    }
                                                }
                                                l_r.Sort();
                                                l_g.Sort();
                                                l_b.Sort();
                                                R = l_r.ToArray()[pos_medio];
                                                G = l_g.ToArray()[pos_medio];
                                                B = l_b.ToArray()[pos_medio];
                                                break;
                                            case 4: //Mediana Ponderada
                                                for (int i = -aux; i <= aux; i++)
                                                {
                                                    for (int j = -aux; j <= aux; j++)
                                                    {
                                                        punteroPixelaux = punteroPixel + (i * anchoImagen * 3) + (j * 3);
                                                        for (int reps = 0; reps < mascara_MedianaPonderada[i + aux, j + aux]; reps++)
                                                        {
                                                            l_r.Add(punteroPixelaux[2]);
                                                            l_g.Add(punteroPixelaux[1]);
                                                            l_b.Add(punteroPixelaux[0]);
                                                        }
                                                    }
                                                }
                                                l_r.Sort();
                                                l_g.Sort();
                                                l_b.Sort();
                                                R = l_r.ToArray()[pos_medio];
                                                G = l_g.ToArray()[pos_medio];
                                                B = l_b.ToArray()[pos_medio];
                                                break;
                                            case 5: //Punto Medio
                                                for (int i = -aux; i <= aux; i++)
                                                {
                                                    for (int j = -aux; j <= aux; j++)
                                                    {
                                                        punteroPixelaux = punteroPixel + (i * anchoImagen * 3) + (j * 3);
                                                        l_r.Add(punteroPixelaux[2]);
                                                        l_g.Add(punteroPixelaux[1]);
                                                        l_b.Add(punteroPixelaux[0]);
                                                    }
                                                }
                                                l_r.Sort();
                                                l_g.Sort();
                                                l_b.Sort();
                                                R = (l_r.Min() + l_r.Max()) / 2;
                                                G = (l_g.Min() + l_g.Max()) / 2;
                                                B = (l_b.Min() + l_b.Max()) / 2;
                                                break;
                                            case 6: //Alpha-Media
                                                for (int i = -aux; i <= aux; i++)
                                                {
                                                    for (int j = -aux; j <= aux; j++)
                                                    {
                                                        punteroPixelaux = punteroPixel + (i * anchoImagen * 3) + (j * 3);
                                                        l_r.Add(punteroPixelaux[2]);
                                                        l_g.Add(punteroPixelaux[1]);
                                                        l_b.Add(punteroPixelaux[0]);
                                                    }
                                                }
                                                l_r.Sort();
                                                l_g.Sort();
                                                l_b.Sort();
                                                for (int i = 0 + T; i < l_r.Count - T; i++)
                                                {
                                                    R += l_r.ToArray()[i] / (tamano_mascara * tamano_mascara - (2 * T));
                                                    G += l_g.ToArray()[i] / (tamano_mascara * tamano_mascara - (2 * T));
                                                    B += l_b.ToArray()[i] / (tamano_mascara * tamano_mascara - (2 * T));
                                                }
                                                break;
                                            case 7: //Media Geometrica
                                                double N = 1.0/(tamano_mascara * tamano_mascara);
                                                double R_aux=1;
                                                double G_aux=1;
                                                double B_aux=1;
                                                for (int i = -aux; i <= aux; i++)
                                                {
                                                    for (int j = -aux; j <= aux; j++)
                                                    {
                                                        punteroPixelaux = punteroPixel + (i * anchoImagen * 3) + (j * 3);
                                                        R_aux *= Math.Pow(punteroPixelaux[2], N);
                                                        G_aux *= Math.Pow(punteroPixelaux[1], N);
                                                        B_aux *= Math.Pow(punteroPixelaux[0], N);
                                                    }
                                                }
                                                R = (int)R_aux;
                                                G = (int)G_aux;
                                                B = (int)B_aux;
                                                break;
                                            default:
                                                break;
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
                                if ((renglon >= Math.Floor((decimal)(tamano_mascara / 2))) && (renglon < (altoImagen - Math.Floor((decimal)(tamano_mascara / 2)))))
                                {
                                    if ((columna >= Math.Floor((decimal)(tamano_mascara / 2))) && (columna < (anchoImagen - Math.Floor((decimal)(tamano_mascara / 2)))))
                                    {
                                        R = G = B = 0;
                                        int aux = (int)Math.Floor((decimal)(tamano_mascara / 2));
                                        byte* punteroPixelaux = punteroPixel;
                                        List<int> l_r = new List<int>();
                                        List<int> l_g = new List<int>();
                                        List<int> l_b = new List<int>();
                                        switch (filtro)
                                        {
                                            case 1: //Media
                                                for (int i = -aux; i <= aux; i++)
                                                {
                                                    for (int j = -aux; j <= aux; j++)
                                                    {
                                                        punteroPixelaux = punteroPixel + (i * anchoImagen * 4) + (j * 4);
                                                        R += punteroPixelaux[2] / (tamano_mascara * tamano_mascara);
                                                        G += punteroPixelaux[1] / (tamano_mascara * tamano_mascara);
                                                        B += punteroPixelaux[0] / (tamano_mascara * tamano_mascara);
                                                    }
                                                }
                                                break;
                                            case 2: //Gaussiano
                                                double e, a;
                                                for (int i = -aux; i <= aux; i++)
                                                {
                                                    for (int j = -aux; j <= aux; j++)
                                                    {
                                                        punteroPixelaux = punteroPixel + (i * anchoImagen * 4) + (j * 4);
                                                        e = Math.Exp(-1 * ((Math.Pow(i, 2) + Math.Pow(j, 2)) / (2 * Math.Pow(sigma, 2))));
                                                        a = (1 / (2 * Math.PI * Math.Pow(sigma, 2))) * e;
                                                        R += (int)(punteroPixelaux[2] * a);
                                                        G += (int)(punteroPixelaux[1] * a);
                                                        B += (int)(punteroPixelaux[0] * a);
                                                    }
                                                }
                                                break;
                                            case 3: //Mediana
                                                for (int i = -aux; i <= aux; i++)
                                                {
                                                    for (int j = -aux; j <= aux; j++)
                                                    {
                                                        punteroPixelaux = punteroPixel + (i * anchoImagen * 4) + (j * 4);
                                                        l_r.Add(punteroPixelaux[2]);
                                                        l_g.Add(punteroPixelaux[1]);
                                                        l_b.Add(punteroPixelaux[0]);
                                                    }
                                                }
                                                l_r.Sort();
                                                l_g.Sort();
                                                l_b.Sort();
                                                R = l_r.ToArray()[pos_medio];
                                                G = l_g.ToArray()[pos_medio];
                                                B = l_b.ToArray()[pos_medio];
                                                break;
                                            case 4: //Mediana Ponderada
                                                for (int i = -aux; i <= aux; i++)
                                                {
                                                    for (int j = -aux; j <= aux; j++)
                                                    {
                                                        punteroPixelaux = punteroPixel + (i * anchoImagen * 4) + (j * 4);
                                                        for (int reps = 0; reps < mascara_MedianaPonderada[i + aux, j + aux]; reps++)
                                                        {
                                                            l_r.Add(punteroPixelaux[2]);
                                                            l_g.Add(punteroPixelaux[1]);
                                                            l_b.Add(punteroPixelaux[0]);
                                                        }
                                                    }
                                                }
                                                l_r.Sort();
                                                l_g.Sort();
                                                l_b.Sort();
                                                R = l_r.ToArray()[pos_medio];
                                                G = l_g.ToArray()[pos_medio];
                                                B = l_b.ToArray()[pos_medio];
                                                break;
                                            case 5: //Punto Medio
                                                for (int i = -aux; i <= aux; i++)
                                                {
                                                    for (int j = -aux; j <= aux; j++)
                                                    {
                                                        punteroPixelaux = punteroPixel + (i * anchoImagen * 4) + (j * 4);
                                                        l_r.Add(punteroPixelaux[2]);
                                                        l_g.Add(punteroPixelaux[1]);
                                                        l_b.Add(punteroPixelaux[0]);
                                                    }
                                                }
                                                l_r.Sort();
                                                l_g.Sort();
                                                l_b.Sort();
                                                R = (l_r.Min() + l_r.Max()) / 2;
                                                G = (l_g.Min() + l_g.Max()) / 2;
                                                B = (l_b.Min() + l_b.Max()) / 2;
                                                break;
                                            case 6: //Alpha-Media
                                                for (int i = -aux; i <= aux; i++)
                                                {
                                                    for (int j = -aux; j <= aux; j++)
                                                    {
                                                        punteroPixelaux = punteroPixel + (i * anchoImagen * 4) + (j * 4);
                                                        l_r.Add(punteroPixelaux[2]);
                                                        l_g.Add(punteroPixelaux[1]);
                                                        l_b.Add(punteroPixelaux[0]);
                                                    }
                                                }
                                                l_r.Sort();
                                                l_g.Sort();
                                                l_b.Sort();
                                                for (int i = 0 + T; i < l_r.Count - T; i++)
                                                {
                                                    R += l_r.ToArray()[i] / (tamano_mascara * tamano_mascara - (2 * T));
                                                    G += l_g.ToArray()[i] / (tamano_mascara * tamano_mascara - (2 * T));
                                                    B += l_b.ToArray()[i] / (tamano_mascara * tamano_mascara - (2 * T));
                                                }
                                                break;
                                            case 7: //Media Geometrica
                                                double N = 1.0 / (tamano_mascara * tamano_mascara);
                                                double R_aux = 1;
                                                double G_aux = 1;
                                                double B_aux = 1;
                                                for (int i = -aux; i <= aux; i++)
                                                {
                                                    for (int j = -aux; j <= aux; j++)
                                                    {
                                                        punteroPixelaux = punteroPixel + (i * anchoImagen * 4) + (j * 4);
                                                        R_aux *= Math.Pow(punteroPixelaux[2], N);
                                                        G_aux *= Math.Pow(punteroPixelaux[1], N);
                                                        B_aux *= Math.Pow(punteroPixelaux[0], N);
                                                    }
                                                }
                                                R = (int)R_aux;
                                                G = (int)G_aux;
                                                B = (int)B_aux;
                                                break;
                                            default:
                                                break;
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
                                if ((renglon >= Math.Floor((decimal)(tamano_mascara / 2))) && (renglon < (altoImagen - Math.Floor((decimal)(tamano_mascara / 2)))))
                                {
                                    if ((columna >= Math.Floor((decimal)(tamano_mascara / 2))) && (columna < (anchoImagen - Math.Floor((decimal)(tamano_mascara / 2)))))
                                    {
                                        R = G = B = 0;
                                        int aux = (int)Math.Floor((decimal)(tamano_mascara / 2));
                                        byte* punteroPixelaux = punteroPixel;
                                        switch (filtro)
                                        {
                                            case 1: //Media
                                                for (int i = -aux; i <= aux; i++)
                                                {
                                                    for (int j = -aux; j <= aux; j++)
                                                    {
                                                        punteroPixelaux = punteroPixel + (i * anchoImagen) + (j);
                                                        R += punteroPixelaux[0] / (tamano_mascara * tamano_mascara);
                                                        G += punteroPixelaux[1] / (tamano_mascara * tamano_mascara);
                                                        B += punteroPixelaux[2] / (tamano_mascara * tamano_mascara);
                                                    }
                                                }
                                                break;
                                            case 2: //Gaussiano
                                                double e, a;
                                                for (int i = -aux; i <= aux; i++)
                                                {
                                                    for (int j = -aux; j <= aux; j++)
                                                    {
                                                        punteroPixelaux = punteroPixel + (i * anchoImagen) + (j);
                                                        e = Math.Exp(-1 * ((Math.Pow(i, 2) + Math.Pow(j, 2)) / (2 * Math.Pow(sigma, 2))));
                                                        a = (1 / (2 * Math.PI * Math.Pow(sigma, 2))) * e;
                                                        R += (int)(punteroPixelaux[0] * a);
                                                        G += (int)(punteroPixelaux[1] * a);
                                                        B += (int)(punteroPixelaux[2] * a);
                                                    }
                                                }
                                                break;
                                            case 3: //Mediana
                                                List<int> l_r = new List<int>();
                                                List<int> l_g = new List<int>();
                                                List<int> l_b = new List<int>();
                                                for (int i = -aux; i <= aux; i++)
                                                {
                                                    for (int j = -aux; j <= aux; j++)
                                                    {
                                                        punteroPixelaux = punteroPixel + (i * anchoImagen) + (j);
                                                        l_r.Add(punteroPixelaux[0]);
                                                        l_g.Add(punteroPixelaux[1]);
                                                        l_b.Add(punteroPixelaux[2]);
                                                    }
                                                }
                                                l_r.Sort();
                                                l_g.Sort();
                                                l_b.Sort();
                                                R = l_r.ToArray()[pos_medio];
                                                G = l_g.ToArray()[pos_medio];
                                                B = l_b.ToArray()[pos_medio];
                                                break;
                                            default:
                                                break;
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
