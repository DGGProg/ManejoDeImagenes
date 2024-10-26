using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManejoDeImagenes
{
    class Vecindad
    {
        internal static int[,] obtenComponentesConexas(Image pImagenEntrada)
        {
            BitmapData imagenOriginalDatos = ((Bitmap)pImagenEntrada).LockBits(new Rectangle(0, 0, pImagenEntrada.Width, pImagenEntrada.Height), ImageLockMode.ReadWrite, pImagenEntrada.PixelFormat);

            int altoImagen = imagenOriginalDatos.Height;
            int anchoImagen = imagenOriginalDatos.Width;
            Bitmap imagenSalida = new Bitmap(width: anchoImagen, height: altoImagen, format: PixelFormat.Format24bppRgb);
            BitmapData imagenSalidaDatos = imagenSalida.LockBits(new Rectangle(0, 0, anchoImagen, altoImagen), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            System.IntPtr primerPixel = imagenOriginalDatos.Scan0;
            System.IntPtr primerPixelSalida = imagenSalidaDatos.Scan0;

            int[,] componentes = new int[altoImagen,anchoImagen];

            int BINARIO, etiqueta_nueva = 0, etiqueta = 0;
            Dictionary<int,int> equivalencias = new Dictionary<int,int>();
            unsafe
            {
                byte* punteroPixel = (byte*)(void*)primerPixel;
                int paso = 1;
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
                        paso = 3;
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
                        paso = 1;
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

                for (int renglon = 0; renglon < altoImagen; renglon++)
                {
                    for (int columna = 0; columna < anchoImagen; columna++)
                    {
                        BINARIO = (int)punteroPixel[0];

                        if (BINARIO == 0)
                        {
                            if (renglon == 0)
                            {
                                if (columna == 0)
                                {
                                    etiqueta_nueva++;
                                    etiqueta = etiqueta_nueva;
                                }
                                else
                                {
                                    if (componentes[renglon, columna - 1] != 0)
                                    {
                                        etiqueta = componentes[renglon, columna - 1];
                                    }
                                    else
                                    {
                                        etiqueta = 0;
                                    }
                                }
                            }
                            else
                            {
                                if (columna == 0)
                                {
                                    if (componentes[renglon - 1, columna] != 0)
                                    {
                                        etiqueta = componentes[renglon - 1, columna];
                                    }
                                    else
                                    {
                                        etiqueta_nueva++;
                                        etiqueta = etiqueta_nueva;
                                    }
                                }
                                else
                                {
                                    if (componentes[renglon - 1, columna] != 0)
                                    {
                                        etiqueta = componentes[renglon - 1, columna];
                                        if ((componentes[renglon, columna - 1] != 0) && (componentes[renglon, columna - 1] != componentes[renglon - 1, columna]))
                                        {
                                            int mayor, menor;
                                            if (etiqueta > componentes[renglon, columna - 1])
                                            {
                                                mayor = etiqueta;
                                                menor = componentes[renglon, columna - 1];
                                            }
                                            else
                                            {
                                                menor = etiqueta;
                                                mayor = componentes[renglon, columna - 1];
                                            }

                                            try
                                            {
                                                int aux_valor = 0;
                                                SortedSet<int> aux = new SortedSet<int>();
                                                aux.Add(menor);
                                                aux.Add(mayor);
                                                while (equivalencias.TryGetValue(mayor, out aux_valor))
                                                {
                                                    if (!aux.Contains(aux_valor))
                                                    {
                                                        aux.Add(aux_valor);
                                                        mayor = aux_valor;
                                                    }
                                                    else
                                                        break;
                                                }
                                                if ((mayor != menor) && !aux.Contains(aux_valor))
                                                    equivalencias.Add(mayor, menor);
                                            }
                                            catch (Exception)
                                            {

                                            }
                                        }
                                        
                                    }
                                    else
                                    {
                                        if (componentes[renglon, columna - 1] != 0)
                                        {
                                            etiqueta = componentes[renglon, columna - 1];
                                            if ((componentes[renglon - 1, columna] != 0) && (componentes[renglon, columna - 1] != componentes[renglon-1, columna]))
                                            {
                                                int mayor, menor;
                                                if (etiqueta > componentes[renglon, columna - 1])
                                                {
                                                    mayor = etiqueta;
                                                    menor = componentes[renglon - 1, columna];
                                                }
                                                else
                                                {
                                                    menor = etiqueta;
                                                    mayor = componentes[renglon - 1, columna];
                                                }

                                                try
                                                {
                                                    int aux_valor = 0;
                                                    SortedSet<int> aux = new SortedSet<int>();
                                                    aux.Add(menor);
                                                    aux.Add(mayor);
                                                    while (equivalencias.TryGetValue(mayor, out aux_valor))
                                                    {
                                                        if (!aux.Contains(aux_valor))
                                                        {
                                                            aux.Add(aux_valor);
                                                            mayor = aux_valor;
                                                        }
                                                        else
                                                            break;
                                                    }
                                                    if ((mayor != menor) && !aux.Contains(aux_valor))
                                                        equivalencias.Add(mayor, menor);
                                                }
                                                catch (Exception)
                                                {

                                                }
                                            }
                                            
                                        }
                                        else
                                        {
                                            etiqueta_nueva++;
                                            etiqueta = etiqueta_nueva;
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            etiqueta = 0;
                        }
                        componentes[renglon, columna] = etiqueta;

                        punteroPixel += paso;
                    }
                }
            }

            for (int renglon = 0; renglon < altoImagen; renglon++)
            {
                for (int columna = 0; columna < anchoImagen; columna++)
                {
                    int aux_valor = 0;
                    int equivalencia = componentes[renglon, columna];
                    SortedSet<int> aux = new SortedSet<int>();
                    while (equivalencias.TryGetValue(equivalencia, out aux_valor))
                    {
                        if (!aux.Contains(aux_valor))
                        {
                            aux.Add(aux_valor);
                            equivalencia = aux_valor;
                        }
                        else
                        {
                            equivalencia = aux.Min;
                            break;
                        }
                    }
                    componentes[renglon, columna] = equivalencia;
                }
            }
            ((Bitmap)pImagenEntrada).UnlockBits(imagenOriginalDatos);

            return componentes;
        }
    }
}
