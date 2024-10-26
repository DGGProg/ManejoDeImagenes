using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManejoDeImagenes
{
    class InvertirImagen
    {

        internal static Image invierteImagen (Image pImagenEntrada, Boolean pCanalRojoActivo, Boolean pCanalVerdeActivo, Boolean pCanalAzulActivo, int pGanaciaRojo, int pGananciaVerde, int pGananciaAzul, Decimal pContrasteRojo, Decimal pContrasteVerde, Decimal pContrasteAzul)
        {
            Bitmap imagenSalida = (Bitmap)pImagenEntrada.Clone();

            BitmapData imagenOriginalDatos = imagenSalida.LockBits(new Rectangle(0, 0, imagenSalida.Width, imagenSalida.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int anchoExploracion = imagenOriginalDatos.Stride;
            int altoImagen = imagenOriginalDatos.Height;
            int anchoImagen = imagenOriginalDatos.Width;
            byte R, G, B;
            int canalR, canalG, canalB;
            System.IntPtr primerPixel = imagenOriginalDatos.Scan0;

            canalR = canalG = canalB = 0;
            canalR = pCanalRojoActivo.CompareTo(false);
            canalG = pCanalVerdeActivo.CompareTo(false);
            canalB = pCanalAzulActivo.CompareTo(false);


            unsafe
            {
                byte* punteroPixel = (byte*)(void*)primerPixel;
                for (int renglon = 0; renglon < altoImagen; renglon++)
                {
                    for (int columna = 0; columna < anchoImagen; columna++)
                    {
                        //obtiene el valor del canal de color del pixel
                        B = punteroPixel[0];
                        G = punteroPixel[1];
                        R = punteroPixel[2];

                        //agrega la ganancia indicada al canal, si excede el valor lo deja en el maximo (255)
                        if (pCanalAzulActivo)
                        {
                            if ((pGananciaAzul + pContrasteAzul * (int)B) > 255) { B = 255; } else { if ((pGananciaAzul + pContrasteAzul * (int)B) < 0) { B = 0; } else { B = (byte)(pContrasteAzul * (int)B + pGananciaAzul); } }
                        }
                        if (pCanalVerdeActivo)
                        {
                            if ((pGananciaVerde + pContrasteVerde * (int)G) > 255) { G = 255; } else { if ((pGananciaVerde + pContrasteVerde * (int)G) < 0) { G = 0; } else { G = (byte)(pContrasteVerde * (int)G + pGananciaVerde); } }
                        }
                        if (pCanalAzulActivo)
                        {
                            if ((pGanaciaRojo + pContrasteRojo * (int)R) > 255) { R = 255; } else { if ((pGanaciaRojo + pContrasteRojo * (int)R) < 0) { R = 0; } else { R = (byte)(pContrasteRojo * (int)R + pGanaciaRojo); } }
                        }

                        //prende o apaga el canal de color indicado (multiplica por 0 o 1)
                        punteroPixel[0] = (byte)(B * canalB);
                        punteroPixel[1] = (byte)(G * canalG);
                        punteroPixel[2] = (byte)(R * canalR);

                        punteroPixel += 3;
                    }
                }
            }
            imagenSalida.UnlockBits(imagenOriginalDatos);
   
            return imagenSalida;
        }

    }
}
