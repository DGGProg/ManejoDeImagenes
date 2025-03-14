using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManejoDeImagenes
{
    class Operaciones2Imagenes
    {
        internal static Image suma_imagenes(Image pImagenEntrada1, Image pImagenEntrada2)
        {
            BitmapData imagen1 = ((Bitmap)pImagenEntrada1).LockBits(new Rectangle(0, 0, pImagenEntrada1.Width, pImagenEntrada1.Height), ImageLockMode.ReadWrite, pImagenEntrada1.PixelFormat);
            BitmapData imagen2 = ((Bitmap)pImagenEntrada2).LockBits(new Rectangle(0, 0, pImagenEntrada2.Width, pImagenEntrada2.Height), ImageLockMode.ReadWrite, pImagenEntrada2.PixelFormat);

            int altoImagen1 = imagen1.Height;
            int anchoImagen1 = imagen1.Width;
            int altoImagen2 = imagen2.Height;
            int anchoImagen2 = imagen2.Width;
            
            int altoImageSalida = 0;
            if (altoImagen1 > altoImagen2)
            {
                altoImageSalida = altoImagen1;
            }
            else
            {
                altoImageSalida = altoImagen2;
            }
            
            int anchoImageSalida = 0;
            if (anchoImagen1 > anchoImagen2)
            {
                anchoImageSalida = anchoImagen1;
            }
            else
            {
                anchoImageSalida = anchoImagen2;
            }

            Bitmap imagenSalida = new Bitmap(width: anchoImageSalida, height: altoImageSalida, format: PixelFormat.Format24bppRgb);
            BitmapData imagenSalidaDatos = imagenSalida.LockBits(new Rectangle(0, 0, anchoImagen1, altoImagen1), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            System.IntPtr primerPixel1 = imagen1.Scan0;
            System.IntPtr primerPixel2 = imagen2.Scan0;
            System.IntPtr primerPixelSalida = imagenSalidaDatos.Scan0;

            decimal NUEVO_R = 0, NUEVO_G = 0, NUEVO_B = 0;
            decimal R1 = 0, G1 = 0, B1 = 0, R2 = 0, G2 = 0, B2 = 0;

            unsafe
            {
                byte* punteroPixel1 = (byte*)(void*)primerPixel1;
                byte* punteroPixel2 = (byte*)(void*)primerPixel2;
                byte* punteroPixelSalida = (byte*)(void*)primerPixelSalida;
                int paso1, paso2;
                paso1 = paso2 = 0;
                switch (pImagenEntrada1.PixelFormat)
                {
                    case PixelFormat.Format24bppRgb:
                        //obtiene el valor del canal de color del pixel
                        paso1 = 3;
                        break;
                    case PixelFormat.Format32bppArgb:
                        //obtiene el valor del canal de color del pixel
                        paso1 = 4;
                        break;
                    case PixelFormat.Format8bppIndexed:
                        paso1 = 1;
                        break;
                    default:
                        break;
                }
                switch (pImagenEntrada2.PixelFormat)
                {
                    case PixelFormat.Format24bppRgb:
                        //obtiene el valor del canal de color del pixel
                        paso2 = 3;
                        break;
                    case PixelFormat.Format32bppArgb:
                        //obtiene el valor del canal de color del pixel
                        paso2 = 4;
                        break;
                    case PixelFormat.Format8bppIndexed:
                        paso2 = 1;
                        break;
                    default:
                        break;
                }

                for (int renglon = 0; renglon < altoImageSalida; renglon++)
                {
                    for (int columna = 0; columna < anchoImageSalida; columna++)
                    {
                        if ((paso1 != 0) && (paso2 != 0))
                        {
                            if ((columna < anchoImagen1)&&(renglon < altoImagen1))
                            {
                                try
                                {
                                    R1 = (decimal)punteroPixel1[0];
                                }
                                catch (Exception)
                                {
                                    R1 = 0;
                                }
                                try
                                {
                                    G1 = (decimal)punteroPixel1[1];
                                }
                                catch (Exception)
                                {
                                    G1 = 0;
                                }
                                try
                                {
                                    B1 = (decimal)punteroPixel1[2];
                                }
                                catch (Exception)
                                {
                                    B1 = 0;
                                }
                            }
                            else 
                            {
                                R1 = G1 = B1 = 0;
                            }

                            if ((columna < anchoImagen2)&&(renglon < altoImagen2))
                            {
                                try
                                {
                                    R2 = (decimal)punteroPixel2[0];
                                }
                                catch (Exception)
                                {
                                    R2 = 0;
                                }
                                try
                                {
                                    G2 = (decimal)punteroPixel2[1];
                                }
                                catch (Exception)
                                {
                                    G2 = 0;
                                }
                                try
                                {
                                    B2 = (decimal)punteroPixel2[2];
                                }
                                catch (Exception)
                                {
                                    B2 = 0;
                                }
                            }
                            else
                            {
                                R2 = G2 = B2 = 0;
                            }
                        }
                        else
                        {
                            if (paso1 == 3)
                            {
                                if ((columna < anchoImagen1)&&(renglon < altoImagen1))
                                {

                                    try
                                    {
                                        R1 = (decimal)punteroPixel1[0];
                                    }
                                    catch (Exception)
                                    {
                                        R1 = 0;
                                    }
                                    try
                                    {
                                        G1 = (decimal)punteroPixel1[1];
                                    }
                                    catch (Exception)
                                    {
                                        G1 = 0;
                                    }
                                    try
                                    {
                                        B1 = (decimal)punteroPixel1[2];
                                    }
                                    catch (Exception)
                                    {
                                        B1 = 0;
                                    }
                                }
                                else
                                {
                                    R1 = G1 = B1 = 0;
                                }

                                if ((columna < anchoImagen2)&&(renglon < altoImagen2))
                                {
                                    try
                                    {
                                        R2 = (decimal)punteroPixel2[0];
                                    }
                                    catch (Exception)
                                    {
                                        R2 = 0;
                                    }
                                    B2 = G2 = R2;
                                }
                                else
                                {
                                    R2 = G2 = B2 = 0;
                                }
                            }
                            else
                            {
                                if (paso2 == 3)
                                {
                                    if ((columna < anchoImagen1)&&(renglon < altoImagen1))
                                    {

                                        try
                                        {
                                            R1 = (decimal)punteroPixel1[0];
                                        }
                                        catch (Exception)
                                        {
                                            R1 = 0;
                                        }
                                        B1 = G1 = R1;
                                    }
                                    else
                                    {
                                        R1 = G1 = B1 = 0;
                                    }

                                    if ((columna < anchoImagen2)&&(renglon < altoImagen2))
                                    {
                                        try
                                        {
                                            R2 = (decimal)punteroPixel2[0];
                                        }
                                        catch (Exception)
                                        {
                                            R2 = 0;
                                        }
                                        try
                                        {
                                            G2 = (decimal)punteroPixel2[1];
                                        }
                                        catch (Exception)
                                        {
                                            G2 = 0;
                                        }
                                        try
                                        {
                                            B2 = (decimal)punteroPixel2[2];
                                        }
                                        catch (Exception)
                                        {
                                            B2 = 0;
                                        }
                                    }
                                    else
                                    {
                                        R2 = G2 = B2 = 0;
                                    }
                                }
                                else
                                {
                                    if ((columna < anchoImagen1)&&(renglon < altoImagen1))
                                    {

                                        try
                                        {
                                            R1 = (decimal)punteroPixel1[0];
                                        }
                                        catch (Exception)
                                        {
                                            R1 = 0;
                                        }
                                        B1 = G1 = R1;
                                    }
                                    else
                                    {
                                        R1 = G1 = B1 = 0;
                                    }

                                    if ((columna < anchoImagen2)&&(renglon < altoImagen2))
                                    {
                                        try
                                        {
                                            R2 = (decimal)punteroPixel2[0];
                                        }
                                        catch (Exception)
                                        {
                                            R2 = 0;
                                        }
                                        B2 = G2 = R2;
                                    }
                                    else
                                    {
                                        R2 = G2 = B2 = 0;
                                    }
                                }
                            }
                        }
                        NUEVO_R = (R1 + R2) / 2;
                        NUEVO_G = (G1 + G2) / 2;
                        NUEVO_B = (B1 + B2) / 2;
                        
                        punteroPixelSalida[0] = (byte)NUEVO_R;
                        punteroPixelSalida[1] = (byte)NUEVO_G;
                        punteroPixelSalida[2] = (byte)NUEVO_B;
                        punteroPixelSalida += 3;
                        if ((columna < anchoImagen1)&&(renglon < altoImagen1))
                        {
                            punteroPixel1 += paso1;
                        }
                        if ((columna < anchoImagen2)&&(renglon < altoImagen2))
                        {
                            punteroPixel2 += paso2;
                        }
                    }
                }
            }
            imagenSalida.UnlockBits(imagenSalidaDatos);
            ((Bitmap)pImagenEntrada1).UnlockBits(imagen1);
            ((Bitmap)pImagenEntrada2).UnlockBits(imagen2);

            return imagenSalida;
        }
        internal static Image suma_imagenes(Image pImagenEntrada1, Image pImagenEntrada2, decimal pPeso1, decimal pPeso2)
        {
            BitmapData imagen1 = ((Bitmap)pImagenEntrada1).LockBits(new Rectangle(0, 0, pImagenEntrada1.Width, pImagenEntrada1.Height), ImageLockMode.ReadWrite, pImagenEntrada1.PixelFormat);
            BitmapData imagen2 = ((Bitmap)pImagenEntrada2).LockBits(new Rectangle(0, 0, pImagenEntrada2.Width, pImagenEntrada2.Height), ImageLockMode.ReadWrite, pImagenEntrada2.PixelFormat);

            int altoImagen1 = imagen1.Height;
            int anchoImagen1 = imagen1.Width;
            int altoImagen2 = imagen2.Height;
            int anchoImagen2 = imagen2.Width;

            int altoImageSalida = 0;
            if (altoImagen1 > altoImagen2)
            {
                altoImageSalida = altoImagen1;
            }
            else
            {
                altoImageSalida = altoImagen2;
            }

            int anchoImageSalida = 0;
            if (anchoImagen1 > anchoImagen2)
            {
                anchoImageSalida = anchoImagen1;
            }
            else
            {
                anchoImageSalida = anchoImagen2;
            }

            Bitmap imagenSalida = new Bitmap(width: anchoImageSalida, height: altoImageSalida, format: PixelFormat.Format24bppRgb);
            BitmapData imagenSalidaDatos = imagenSalida.LockBits(new Rectangle(0, 0, anchoImagen1, altoImagen1), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            System.IntPtr primerPixel1 = imagen1.Scan0;
            System.IntPtr primerPixel2 = imagen2.Scan0;
            System.IntPtr primerPixelSalida = imagenSalidaDatos.Scan0;

            decimal NUEVO_R = 0, NUEVO_G = 0, NUEVO_B = 0;
            decimal R1 = 0, G1 = 0, B1 = 0, R2 = 0, G2 = 0, B2 = 0;

            unsafe
            {
                byte* punteroPixel1 = (byte*)(void*)primerPixel1;
                byte* punteroPixel2 = (byte*)(void*)primerPixel2;
                byte* punteroPixelSalida = (byte*)(void*)primerPixelSalida;
                int paso1, paso2;
                paso1 = paso2 = 0;
                switch (pImagenEntrada1.PixelFormat)
                {
                    case PixelFormat.Format24bppRgb:
                        //obtiene el valor del canal de color del pixel
                        paso1 = 3;
                        break;
                    case PixelFormat.Format32bppArgb:
                        //obtiene el valor del canal de color del pixel
                        paso1 = 4;
                        break;
                    case PixelFormat.Format8bppIndexed:
                        paso1 = 1;
                        break;
                    default:
                        break;
                }
                switch (pImagenEntrada2.PixelFormat)
                {
                    case PixelFormat.Format24bppRgb:
                        //obtiene el valor del canal de color del pixel
                        paso2 = 3;
                        break;
                    case PixelFormat.Format32bppArgb:
                        //obtiene el valor del canal de color del pixel
                        paso2 = 4;
                        break;
                    case PixelFormat.Format8bppIndexed:
                        paso2 = 1;
                        break;
                    default:
                        break;
                }

                for (int renglon = 0; renglon < altoImageSalida; renglon++)
                {
                    for (int columna = 0; columna < anchoImageSalida; columna++)
                    {
                        if ((paso1 != 0) && (paso2 != 0))
                        {
                            if ((columna < anchoImagen1) && (renglon < altoImagen1))
                            {
                                try
                                {
                                    R1 = (decimal)punteroPixel1[0];
                                }
                                catch (Exception)
                                {
                                    R1 = 0;
                                }
                                try
                                {
                                    G1 = (decimal)punteroPixel1[1];
                                }
                                catch (Exception)
                                {
                                    G1 = 0;
                                }
                                try
                                {
                                    B1 = (decimal)punteroPixel1[2];
                                }
                                catch (Exception)
                                {
                                    B1 = 0;
                                }
                            }
                            else
                            {
                                R1 = G1 = B1 = 0;
                            }

                            if ((columna < anchoImagen2) && (renglon < altoImagen2))
                            {
                                try
                                {
                                    R2 = (decimal)punteroPixel2[0];
                                }
                                catch (Exception)
                                {
                                    R2 = 0;
                                }
                                try
                                {
                                    G2 = (decimal)punteroPixel2[1];
                                }
                                catch (Exception)
                                {
                                    G2 = 0;
                                }
                                try
                                {
                                    B2 = (decimal)punteroPixel2[2];
                                }
                                catch (Exception)
                                {
                                    B2 = 0;
                                }
                            }
                            else
                            {
                                R2 = G2 = B2 = 0;
                            }
                        }
                        else
                        {
                            if (paso1 == 3)
                            {
                                if ((columna < anchoImagen1) && (renglon < altoImagen1))
                                {

                                    try
                                    {
                                        R1 = (decimal)punteroPixel1[0];
                                    }
                                    catch (Exception)
                                    {
                                        R1 = 0;
                                    }
                                    try
                                    {
                                        G1 = (decimal)punteroPixel1[1];
                                    }
                                    catch (Exception)
                                    {
                                        G1 = 0;
                                    }
                                    try
                                    {
                                        B1 = (decimal)punteroPixel1[2];
                                    }
                                    catch (Exception)
                                    {
                                        B1 = 0;
                                    }
                                }
                                else
                                {
                                    R1 = G1 = B1 = 0;
                                }

                                if ((columna < anchoImagen2) && (renglon < altoImagen2))
                                {
                                    try
                                    {
                                        R2 = (decimal)punteroPixel2[0];
                                    }
                                    catch (Exception)
                                    {
                                        R2 = 0;
                                    }
                                    B2 = G2 = R2;
                                }
                                else
                                {
                                    R2 = G2 = B2 = 0;
                                }
                            }
                            else
                            {
                                if (paso2 == 3)
                                {
                                    if ((columna < anchoImagen1) && (renglon < altoImagen1))
                                    {

                                        try
                                        {
                                            R1 = (decimal)punteroPixel1[0];
                                        }
                                        catch (Exception)
                                        {
                                            R1 = 0;
                                        }
                                        B1 = G1 = R1;
                                    }
                                    else
                                    {
                                        R1 = G1 = B1 = 0;
                                    }

                                    if ((columna < anchoImagen2) && (renglon < altoImagen2))
                                    {
                                        try
                                        {
                                            R2 = (decimal)punteroPixel2[0];
                                        }
                                        catch (Exception)
                                        {
                                            R2 = 0;
                                        }
                                        try
                                        {
                                            G2 = (decimal)punteroPixel2[1];
                                        }
                                        catch (Exception)
                                        {
                                            G2 = 0;
                                        }
                                        try
                                        {
                                            B2 = (decimal)punteroPixel2[2];
                                        }
                                        catch (Exception)
                                        {
                                            B2 = 0;
                                        }
                                    }
                                    else
                                    {
                                        R2 = G2 = B2 = 0;
                                    }
                                }
                                else
                                {
                                    if ((columna < anchoImagen1) && (renglon < altoImagen1))
                                    {

                                        try
                                        {
                                            R1 = (decimal)punteroPixel1[0];
                                        }
                                        catch (Exception)
                                        {
                                            R1 = 0;
                                        }
                                        B1 = G1 = R1;
                                    }
                                    else
                                    {
                                        R1 = G1 = B1 = 0;
                                    }

                                    if ((columna < anchoImagen2) && (renglon < altoImagen2))
                                    {
                                        try
                                        {
                                            R2 = (decimal)punteroPixel2[0];
                                        }
                                        catch (Exception)
                                        {
                                            R2 = 0;
                                        }
                                        B2 = G2 = R2;
                                    }
                                    else
                                    {
                                        R2 = G2 = B2 = 0;
                                    }
                                }
                            }
                        }
                        NUEVO_R = (R1 * pPeso1) + (R2 * pPeso2);
                        NUEVO_G = (G1 * pPeso1) + (G2 * pPeso2);
                        NUEVO_B = (B1 * pPeso1) + (B2 * pPeso2);
                        if (NUEVO_R > 255) { NUEVO_R = 255; }
                        if (NUEVO_G > 255) { NUEVO_G = 255; }
                        if (NUEVO_B > 255) { NUEVO_B = 255; }
                        if (NUEVO_R < 0) { NUEVO_R = 0; }
                        if (NUEVO_G < 0) { NUEVO_G = 0; }
                        if (NUEVO_B < 0) { NUEVO_B = 0; }

                        punteroPixelSalida[0] = (byte)NUEVO_R;
                        punteroPixelSalida[1] = (byte)NUEVO_G;
                        punteroPixelSalida[2] = (byte)NUEVO_B;
                        punteroPixelSalida += 3;
                        if ((columna < anchoImagen1) && (renglon < altoImagen1))
                        {
                            punteroPixel1 += paso1;
                        }
                        if ((columna < anchoImagen2) && (renglon < altoImagen2))
                        {
                            punteroPixel2 += paso2;
                        }
                    }
                }
            }
            imagenSalida.UnlockBits(imagenSalidaDatos);
            ((Bitmap)pImagenEntrada1).UnlockBits(imagen1);
            ((Bitmap)pImagenEntrada2).UnlockBits(imagen2);

            return imagenSalida;
        }
        internal static Image resta_imagenes(Image pImagenEntrada1, Image pImagenEntrada2)
        {
            BitmapData imagen1 = ((Bitmap)pImagenEntrada1).LockBits(new Rectangle(0, 0, pImagenEntrada1.Width, pImagenEntrada1.Height), ImageLockMode.ReadWrite, pImagenEntrada1.PixelFormat);
            BitmapData imagen2 = ((Bitmap)pImagenEntrada2).LockBits(new Rectangle(0, 0, pImagenEntrada2.Width, pImagenEntrada2.Height), ImageLockMode.ReadWrite, pImagenEntrada2.PixelFormat);

            int altoImagen1 = imagen1.Height;
            int anchoImagen1 = imagen1.Width;
            int altoImagen2 = imagen2.Height;
            int anchoImagen2 = imagen2.Width;

            int altoImageSalida = 0;
            if (altoImagen1 > altoImagen2)
            {
                altoImageSalida = altoImagen1;
            }
            else
            {
                altoImageSalida = altoImagen2;
            }

            int anchoImageSalida = 0;
            if (anchoImagen1 > anchoImagen2)
            {
                anchoImageSalida = anchoImagen1;
            }
            else
            {
                anchoImageSalida = anchoImagen2;
            }

            Bitmap imagenSalida = new Bitmap(width: anchoImageSalida, height: altoImageSalida, format: PixelFormat.Format24bppRgb);
            BitmapData imagenSalidaDatos = imagenSalida.LockBits(new Rectangle(0, 0, anchoImagen1, altoImagen1), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            System.IntPtr primerPixel1 = imagen1.Scan0;
            System.IntPtr primerPixel2 = imagen2.Scan0;
            System.IntPtr primerPixelSalida = imagenSalidaDatos.Scan0;

            decimal NUEVO_R = 0, NUEVO_G = 0, NUEVO_B = 0;
            decimal R1 = 0, G1 = 0, B1 = 0, R2 = 0, G2 = 0, B2 = 0;
            unsafe
            {
                byte* punteroPixel1 = (byte*)(void*)primerPixel1;
                byte* punteroPixel2 = (byte*)(void*)primerPixel2;
                byte* punteroPixelSalida = (byte*)(void*)primerPixelSalida;
                int paso1, paso2;
                paso1 = paso2 = 0;
                switch (pImagenEntrada1.PixelFormat)
                {
                    case PixelFormat.Format24bppRgb:
                        //obtiene el valor del canal de color del pixel
                        paso1 = 3;
                        break;
                    case PixelFormat.Format32bppArgb:
                        //obtiene el valor del canal de color del pixel
                        paso1 = 4;
                        break;
                    case PixelFormat.Format8bppIndexed:
                        paso1 = 1;
                        break;
                    default:
                        break;
                }
                switch (pImagenEntrada2.PixelFormat)
                {
                    case PixelFormat.Format24bppRgb:
                        //obtiene el valor del canal de color del pixel
                        paso2 = 3;
                        break;
                    case PixelFormat.Format32bppArgb:
                        //obtiene el valor del canal de color del pixel
                        paso2 = 4;
                        break;
                    case PixelFormat.Format8bppIndexed:
                        paso2 = 1;
                        break;
                    default:
                        break;
                }

                for (int renglon = 0; renglon < altoImageSalida; renglon++)
                {
                    for (int columna = 0; columna < anchoImageSalida; columna++)
                    {
                        if ((paso1 != 0) && (paso2 != 0))
                        {
                            if ((columna < anchoImagen1) && (renglon < altoImagen1))
                            {
                                try
                                {
                                    R1 = (decimal)punteroPixel1[0];
                                }
                                catch (Exception)
                                {
                                    R1 = 0;
                                }
                                try
                                {
                                    G1 = (decimal)punteroPixel1[1];
                                }
                                catch (Exception)
                                {
                                    G1 = 0;
                                }
                                try
                                {
                                    B1 = (decimal)punteroPixel1[2];
                                }
                                catch (Exception)
                                {
                                    B1 = 0;
                                }
                            }
                            else
                            {
                                R1 = G1 = B1 = 0;
                            }

                            if ((columna < anchoImagen2) && (renglon < altoImagen2))
                            {
                                try
                                {
                                    R2 = (decimal)punteroPixel2[0];
                                }
                                catch (Exception)
                                {
                                    R2 = 0;
                                }
                                try
                                {
                                    G2 = (decimal)punteroPixel2[1];
                                }
                                catch (Exception)
                                {
                                    G2 = 0;
                                }
                                try
                                {
                                    B2 = (decimal)punteroPixel2[2];
                                }
                                catch (Exception)
                                {
                                    B2 = 0;
                                }
                            }
                            else
                            {
                                R2 = G2 = B2 = 0;
                            }
                        }
                        else
                        {
                            if (paso1 == 3)
                            {
                                if ((columna < anchoImagen1) && (renglon < altoImagen1))
                                {

                                    try
                                    {
                                        R1 = (decimal)punteroPixel1[0];
                                    }
                                    catch (Exception)
                                    {
                                        R1 = 0;
                                    }
                                    try
                                    {
                                        G1 = (decimal)punteroPixel1[1];
                                    }
                                    catch (Exception)
                                    {
                                        G1 = 0;
                                    }
                                    try
                                    {
                                        B1 = (decimal)punteroPixel1[2];
                                    }
                                    catch (Exception)
                                    {
                                        B1 = 0;
                                    }
                                }
                                else
                                {
                                    R1 = G1 = B1 = 0;
                                }

                                if ((columna < anchoImagen2) && (renglon < altoImagen2))
                                {
                                    try
                                    {
                                        R2 = (decimal)punteroPixel2[0];
                                    }
                                    catch (Exception)
                                    {
                                        R2 = 0;
                                    }
                                    B2 = G2 = R2;
                                }
                                else
                                {
                                    R2 = G2 = B2 = 0;
                                }
                            }
                            else
                            {
                                if (paso2 == 3)
                                {
                                    if ((columna < anchoImagen1) && (renglon < altoImagen1))
                                    {

                                        try
                                        {
                                            R1 = (decimal)punteroPixel1[0];
                                        }
                                        catch (Exception)
                                        {
                                            R1 = 0;
                                        }
                                        B1 = G1 = R1;
                                    }
                                    else
                                    {
                                        R1 = G1 = B1 = 0;
                                    }

                                    if ((columna < anchoImagen2) && (renglon < altoImagen2))
                                    {
                                        try
                                        {
                                            R2 = (decimal)punteroPixel2[0];
                                        }
                                        catch (Exception)
                                        {
                                            R2 = 0;
                                        }
                                        try
                                        {
                                            G2 = (decimal)punteroPixel2[1];
                                        }
                                        catch (Exception)
                                        {
                                            G2 = 0;
                                        }
                                        try
                                        {
                                            B2 = (decimal)punteroPixel2[2];
                                        }
                                        catch (Exception)
                                        {
                                            B2 = 0;
                                        }
                                    }
                                    else
                                    {
                                        R2 = G2 = B2 = 0;
                                    }
                                }
                                else
                                {
                                    if ((columna < anchoImagen1) && (renglon < altoImagen1))
                                    {

                                        try
                                        {
                                            R1 = (decimal)punteroPixel1[0];
                                        }
                                        catch (Exception)
                                        {
                                            R1 = 0;
                                        }
                                        B1 = G1 = R1;
                                    }
                                    else
                                    {
                                        R1 = G1 = B1 = 0;
                                    }

                                    if ((columna < anchoImagen2) && (renglon < altoImagen2))
                                    {
                                        try
                                        {
                                            R2 = (decimal)punteroPixel2[0];
                                        }
                                        catch (Exception)
                                        {
                                            R2 = 0;
                                        }
                                        B2 = G2 = R2;
                                    }
                                    else
                                    {
                                        R2 = G2 = B2 = 0;
                                    }
                                }
                            }
                        }
                        NUEVO_R = Math.Abs(R1 - R2);
                        NUEVO_G = Math.Abs(G1 - G2);
                        NUEVO_B = Math.Abs(B1 - B2);
                        
                        punteroPixelSalida[0] = (byte)NUEVO_R;
                        punteroPixelSalida[1] = (byte)NUEVO_G;
                        punteroPixelSalida[2] = (byte)NUEVO_B;
                        punteroPixelSalida += 3;
                        if ((columna < anchoImagen1) && (renglon < altoImagen1))
                        {
                            punteroPixel1 += paso1;
                        }
                        if ((columna < anchoImagen2) && (renglon < altoImagen2))
                        {
                            punteroPixel2 += paso2;
                        }
                    }
                }
            }
            imagenSalida.UnlockBits(imagenSalidaDatos);
            ((Bitmap)pImagenEntrada1).UnlockBits(imagen1);
            ((Bitmap)pImagenEntrada2).UnlockBits(imagen2);

            return imagenSalida;
        }
        internal static Image multiplica_imagenes(Image pImagenEntrada1, Image pImagenEntrada2, decimal pPeso)
        {
            BitmapData imagen1 = ((Bitmap)pImagenEntrada1).LockBits(new Rectangle(0, 0, pImagenEntrada1.Width, pImagenEntrada1.Height), ImageLockMode.ReadWrite, pImagenEntrada1.PixelFormat);
            BitmapData imagen2 = ((Bitmap)pImagenEntrada2).LockBits(new Rectangle(0, 0, pImagenEntrada2.Width, pImagenEntrada2.Height), ImageLockMode.ReadWrite, pImagenEntrada2.PixelFormat);

            int altoImagen1 = imagen1.Height;
            int anchoImagen1 = imagen1.Width;
            int altoImagen2 = imagen2.Height;
            int anchoImagen2 = imagen2.Width;

            int altoImageSalida = 0;
            if (altoImagen1 > altoImagen2)
            {
                altoImageSalida = altoImagen1;
            }
            else
            {
                altoImageSalida = altoImagen2;
            }

            int anchoImageSalida = 0;
            if (anchoImagen1 > anchoImagen2)
            {
                anchoImageSalida = anchoImagen1;
            }
            else
            {
                anchoImageSalida = anchoImagen2;
            }

            Bitmap imagenSalida = new Bitmap(width: anchoImageSalida, height: altoImageSalida, format: PixelFormat.Format24bppRgb);
            BitmapData imagenSalidaDatos = imagenSalida.LockBits(new Rectangle(0, 0, anchoImagen1, altoImagen1), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            System.IntPtr primerPixel1 = imagen1.Scan0;
            System.IntPtr primerPixel2 = imagen2.Scan0;
            System.IntPtr primerPixelSalida = imagenSalidaDatos.Scan0;

            decimal NUEVO_R = 0, NUEVO_G = 0, NUEVO_B = 0;
            decimal R1 = 0, G1 = 0, B1 = 0, R2 = 0, G2 = 0, B2 = 0;

            unsafe
            {
                byte* punteroPixel1 = (byte*)(void*)primerPixel1;
                byte* punteroPixel2 = (byte*)(void*)primerPixel2;
                byte* punteroPixelSalida = (byte*)(void*)primerPixelSalida;
                int paso1, paso2;
                paso1 = paso2 = 0;
                switch (pImagenEntrada1.PixelFormat)
                {
                    case PixelFormat.Format24bppRgb:
                        //obtiene el valor del canal de color del pixel
                        paso1 = 3;
                        break;
                    case PixelFormat.Format32bppArgb:
                        //obtiene el valor del canal de color del pixel
                        paso1 = 4;
                        break;
                    case PixelFormat.Format8bppIndexed:
                        paso1 = 1;
                        break;
                    default:
                        break;
                }
                switch (pImagenEntrada2.PixelFormat)
                {
                    case PixelFormat.Format24bppRgb:
                        //obtiene el valor del canal de color del pixel
                        paso2 = 3;
                        break;
                    case PixelFormat.Format32bppArgb:
                        //obtiene el valor del canal de color del pixel
                        paso2 = 4;
                        break;
                    case PixelFormat.Format8bppIndexed:
                        paso2 = 1;
                        break;
                    default:
                        break;
                }

                for (int renglon = 0; renglon < altoImageSalida; renglon++)
                {
                    for (int columna = 0; columna < anchoImageSalida; columna++)
                    {
                        if ((paso1 != 0) && (paso2 != 0))
                        {
                            if ((columna < anchoImagen1) && (renglon < altoImagen1))
                            {
                                try
                                {
                                    R1 = (decimal)punteroPixel1[0];
                                }
                                catch (Exception)
                                {
                                    R1 = 0;
                                }
                                try
                                {
                                    G1 = (decimal)punteroPixel1[1];
                                }
                                catch (Exception)
                                {
                                    G1 = 0;
                                }
                                try
                                {
                                    B1 = (decimal)punteroPixel1[2];
                                }
                                catch (Exception)
                                {
                                    B1 = 0;
                                }
                            }
                            else
                            {
                                R1 = G1 = B1 = 0;
                            }

                            if ((columna < anchoImagen2) && (renglon < altoImagen2))
                            {
                                try
                                {
                                    R2 = (decimal)punteroPixel2[0];
                                }
                                catch (Exception)
                                {
                                    R2 = 0;
                                }
                                try
                                {
                                    G2 = (decimal)punteroPixel2[1];
                                }
                                catch (Exception)
                                {
                                    G2 = 0;
                                }
                                try
                                {
                                    B2 = (decimal)punteroPixel2[2];
                                }
                                catch (Exception)
                                {
                                    B2 = 0;
                                }
                            }
                            else
                            {
                                R2 = G2 = B2 = 0;
                            }
                        }
                        else
                        {
                            if (paso1 == 3)
                            {
                                if ((columna < anchoImagen1) && (renglon < altoImagen1))
                                {

                                    try
                                    {
                                        R1 = (decimal)punteroPixel1[0];
                                    }
                                    catch (Exception)
                                    {
                                        R1 = 0;
                                    }
                                    try
                                    {
                                        G1 = (decimal)punteroPixel1[1];
                                    }
                                    catch (Exception)
                                    {
                                        G1 = 0;
                                    }
                                    try
                                    {
                                        B1 = (decimal)punteroPixel1[2];
                                    }
                                    catch (Exception)
                                    {
                                        B1 = 0;
                                    }
                                }
                                else
                                {
                                    R1 = G1 = B1 = 0;
                                }

                                if ((columna < anchoImagen2) && (renglon < altoImagen2))
                                {
                                    try
                                    {
                                        R2 = (decimal)punteroPixel2[0];
                                    }
                                    catch (Exception)
                                    {
                                        R2 = 0;
                                    }
                                    B2 = G2 = R2;
                                }
                                else
                                {
                                    R2 = G2 = B2 = 0;
                                }
                            }
                            else
                            {
                                if (paso2 == 3)
                                {
                                    if ((columna < anchoImagen1) && (renglon < altoImagen1))
                                    {

                                        try
                                        {
                                            R1 = (decimal)punteroPixel1[0];
                                        }
                                        catch (Exception)
                                        {
                                            R1 = 0;
                                        }
                                        B1 = G1 = R1;
                                    }
                                    else
                                    {
                                        R1 = G1 = B1 = 0;
                                    }

                                    if ((columna < anchoImagen2) && (renglon < altoImagen2))
                                    {
                                        try
                                        {
                                            R2 = (decimal)punteroPixel2[0];
                                        }
                                        catch (Exception)
                                        {
                                            R2 = 0;
                                        }
                                        try
                                        {
                                            G2 = (decimal)punteroPixel2[1];
                                        }
                                        catch (Exception)
                                        {
                                            G2 = 0;
                                        }
                                        try
                                        {
                                            B2 = (decimal)punteroPixel2[2];
                                        }
                                        catch (Exception)
                                        {
                                            B2 = 0;
                                        }
                                    }
                                    else
                                    {
                                        R2 = G2 = B2 = 0;
                                    }
                                }
                                else
                                {
                                    if ((columna < anchoImagen1) && (renglon < altoImagen1))
                                    {

                                        try
                                        {
                                            R1 = (decimal)punteroPixel1[0];
                                        }
                                        catch (Exception)
                                        {
                                            R1 = 0;
                                        }
                                        B1 = G1 = R1;
                                    }
                                    else
                                    {
                                        R1 = G1 = B1 = 0;
                                    }

                                    if ((columna < anchoImagen2) && (renglon < altoImagen2))
                                    {
                                        try
                                        {
                                            R2 = (decimal)punteroPixel2[0];
                                        }
                                        catch (Exception)
                                        {
                                            R2 = 0;
                                        }
                                        B2 = G2 = R2;
                                    }
                                    else
                                    {
                                        R2 = G2 = B2 = 0;
                                    }
                                }
                            }
                        }
                        NUEVO_R = ((R1 * R2) / pPeso);
                        NUEVO_G = ((G1 * G2) / pPeso);
                        NUEVO_B = ((B1 * B2) / pPeso);
                        if (NUEVO_R > 255) { NUEVO_R = 255; }
                        if (NUEVO_G > 255) { NUEVO_G = 255; }
                        if (NUEVO_B > 255) { NUEVO_B = 255; }
                        if (NUEVO_R < 0) { NUEVO_R = 0; }
                        if (NUEVO_G < 0) { NUEVO_G = 0; }
                        if (NUEVO_B < 0) { NUEVO_B = 0; }

                        punteroPixelSalida[0] = (byte)NUEVO_R;
                        punteroPixelSalida[1] = (byte)NUEVO_G;
                        punteroPixelSalida[2] = (byte)NUEVO_B;
                        punteroPixelSalida += 3;
                        if ((columna < anchoImagen1) && (renglon < altoImagen1))
                        {
                            punteroPixel1 += paso1;
                        }
                        if ((columna < anchoImagen2) && (renglon < altoImagen2))
                        {
                            punteroPixel2 += paso2;
                        }
                    }
                }
            }
            imagenSalida.UnlockBits(imagenSalidaDatos);
            ((Bitmap)pImagenEntrada1).UnlockBits(imagen1);
            ((Bitmap)pImagenEntrada2).UnlockBits(imagen2);

            return imagenSalida;
        }
        internal static Image divide_imagenes(Image pImagenEntrada1, Image pImagenEntrada2, decimal pPeso)
        {
            BitmapData imagen1 = ((Bitmap)pImagenEntrada1).LockBits(new Rectangle(0, 0, pImagenEntrada1.Width, pImagenEntrada1.Height), ImageLockMode.ReadWrite, pImagenEntrada1.PixelFormat);
            BitmapData imagen2 = ((Bitmap)pImagenEntrada2).LockBits(new Rectangle(0, 0, pImagenEntrada2.Width, pImagenEntrada2.Height), ImageLockMode.ReadWrite, pImagenEntrada2.PixelFormat);

            int altoImagen1 = imagen1.Height;
            int anchoImagen1 = imagen1.Width;
            int altoImagen2 = imagen2.Height;
            int anchoImagen2 = imagen2.Width;

            int altoImageSalida = 0;
            if (altoImagen1 > altoImagen2)
            {
                altoImageSalida = altoImagen1;
            }
            else
            {
                altoImageSalida = altoImagen2;
            }

            int anchoImageSalida = 0;
            if (anchoImagen1 > anchoImagen2)
            {
                anchoImageSalida = anchoImagen1;
            }
            else
            {
                anchoImageSalida = anchoImagen2;
            }

            Bitmap imagenSalida = new Bitmap(width: anchoImageSalida, height: altoImageSalida, format: PixelFormat.Format24bppRgb);
            BitmapData imagenSalidaDatos = imagenSalida.LockBits(new Rectangle(0, 0, anchoImagen1, altoImagen1), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            System.IntPtr primerPixel1 = imagen1.Scan0;
            System.IntPtr primerPixel2 = imagen2.Scan0;
            System.IntPtr primerPixelSalida = imagenSalidaDatos.Scan0;

            decimal NUEVO_R = 0, NUEVO_G = 0, NUEVO_B = 0;
            decimal R1 = 0, G1 = 0, B1 = 0, R2 = 0, G2 = 0, B2 = 0;

            unsafe
            {
                byte* punteroPixel1 = (byte*)(void*)primerPixel1;
                byte* punteroPixel2 = (byte*)(void*)primerPixel2;
                byte* punteroPixelSalida = (byte*)(void*)primerPixelSalida;
                int paso1, paso2;
                paso1 = paso2 = 0;
                switch (pImagenEntrada1.PixelFormat)
                {
                    case PixelFormat.Format24bppRgb:
                        //obtiene el valor del canal de color del pixel
                        paso1 = 3;
                        break;
                    case PixelFormat.Format32bppArgb:
                        //obtiene el valor del canal de color del pixel
                        paso1 = 4;
                        break;
                    case PixelFormat.Format8bppIndexed:
                        paso1 = 1;
                        break;
                    default:
                        break;
                }
                switch (pImagenEntrada2.PixelFormat)
                {
                    case PixelFormat.Format24bppRgb:
                        //obtiene el valor del canal de color del pixel
                        paso2 = 3;
                        break;
                    case PixelFormat.Format32bppArgb:
                        //obtiene el valor del canal de color del pixel
                        paso2 = 4;
                        break;
                    case PixelFormat.Format8bppIndexed:
                        paso2 = 1;
                        break;
                    default:
                        break;
                }

                for (int renglon = 0; renglon < altoImageSalida; renglon++)
                {
                    for (int columna = 0; columna < anchoImageSalida; columna++)
                    {
                        if ((paso1 != 0) && (paso2 != 0))
                        {
                            if ((columna < anchoImagen1) && (renglon < altoImagen1))
                            {
                                try
                                {
                                    R1 = (decimal)punteroPixel1[0];
                                }
                                catch (Exception)
                                {
                                    R1 = 1;
                                }
                                try
                                {
                                    G1 = (decimal)punteroPixel1[1];
                                }
                                catch (Exception)
                                {
                                    G1 = 1;
                                }
                                try
                                {
                                    B1 = (decimal)punteroPixel1[2];
                                }
                                catch (Exception)
                                {
                                    B1 = 1;
                                }
                            }
                            else
                            {
                                R1 = G1 = B1 = 1;
                            }

                            if ((columna < anchoImagen2) && (renglon < altoImagen2))
                            {
                                try
                                {
                                    R2 = (decimal)punteroPixel2[0];
                                }
                                catch (Exception)
                                {
                                    R2 = 1;
                                }
                                try
                                {
                                    G2 = (decimal)punteroPixel2[1];
                                }
                                catch (Exception)
                                {
                                    G2 = 1;
                                }
                                try
                                {
                                    B2 = (decimal)punteroPixel2[2];
                                }
                                catch (Exception)
                                {
                                    B2 = 1;
                                }
                            }
                            else
                            {
                                R2 = G2 = B2 = 1;
                            }
                        }
                        else
                        {
                            if (paso1 == 3)
                            {
                                if ((columna < anchoImagen1) && (renglon < altoImagen1))
                                {

                                    try
                                    {
                                        R1 = (decimal)punteroPixel1[0];
                                    }
                                    catch (Exception)
                                    {
                                        R1 = 1;
                                    }
                                    try
                                    {
                                        G1 = (decimal)punteroPixel1[1];
                                    }
                                    catch (Exception)
                                    {
                                        G1 = 1;
                                    }
                                    try
                                    {
                                        B1 = (decimal)punteroPixel1[2];
                                    }
                                    catch (Exception)
                                    {
                                        B1 = 1;
                                    }
                                }
                                else
                                {
                                    R1 = G1 = B1 = 1;
                                }

                                if ((columna < anchoImagen2) && (renglon < altoImagen2))
                                {
                                    try
                                    {
                                        R2 = (decimal)punteroPixel2[0];
                                    }
                                    catch (Exception)
                                    {
                                        R2 = 1;
                                    }
                                    B2 = G2 = R2;
                                }
                                else
                                {
                                    R2 = G2 = B2 = 1;
                                }
                            }
                            else
                            {
                                if (paso2 == 3)
                                {
                                    if ((columna < anchoImagen1) && (renglon < altoImagen1))
                                    {

                                        try
                                        {
                                            R1 = (decimal)punteroPixel1[0];
                                        }
                                        catch (Exception)
                                        {
                                            R1 = 1;
                                        }
                                        B1 = G1 = R1;
                                    }
                                    else
                                    {
                                        R1 = G1 = B1 = 1;
                                    }

                                    if ((columna < anchoImagen2) && (renglon < altoImagen2))
                                    {
                                        try
                                        {
                                            R2 = (decimal)punteroPixel2[0];
                                        }
                                        catch (Exception)
                                        {
                                            R2 = 1;
                                        }
                                        try
                                        {
                                            G2 = (decimal)punteroPixel2[1];
                                        }
                                        catch (Exception)
                                        {
                                            G2 = 1;
                                        }
                                        try
                                        {
                                            B2 = (decimal)punteroPixel2[2];
                                        }
                                        catch (Exception)
                                        {
                                            B2 = 1;
                                        }
                                    }
                                    else
                                    {
                                        R2 = G2 = B2 = 1;
                                    }
                                }
                                else
                                {
                                    if ((columna < anchoImagen1) && (renglon < altoImagen1))
                                    {

                                        try
                                        {
                                            R1 = (decimal)punteroPixel1[0];
                                        }
                                        catch (Exception)
                                        {
                                            R1 = 1;
                                        }
                                        B1 = G1 = R1;
                                    }
                                    else
                                    {
                                        R1 = G1 = B1 = 1;
                                    }

                                    if ((columna < anchoImagen2) && (renglon < altoImagen2))
                                    {
                                        try
                                        {
                                            R2 = (decimal)punteroPixel2[0];
                                        }
                                        catch (Exception)
                                        {
                                            R2 = 1;
                                        }
                                        B2 = G2 = R2;
                                    }
                                    else
                                    {
                                        R2 = G2 = B2 = 1;
                                    }
                                }
                            }
                        }
                        if (R2 < 1) { R2 = 1; }
                        if (G2 < 1) { G2 = 1; }
                        if (B2 < 1) { B2 = 1; }
                        NUEVO_R = (pPeso * (R1 / R2));
                        NUEVO_G = (pPeso * (G1 / G2));
                        NUEVO_B = (pPeso * (B1 / B2));
                        if (NUEVO_R > 255) { NUEVO_R = 255; }
                        if (NUEVO_G > 255) { NUEVO_G = 255; }
                        if (NUEVO_B > 255) { NUEVO_B = 255; }
                        if (NUEVO_R < 0) { NUEVO_R = 0; }
                        if (NUEVO_G < 0) { NUEVO_G = 0; }
                        if (NUEVO_B < 0) { NUEVO_B = 0; }

                        punteroPixelSalida[0] = (byte)NUEVO_R;
                        punteroPixelSalida[1] = (byte)NUEVO_G;
                        punteroPixelSalida[2] = (byte)NUEVO_B;
                        punteroPixelSalida += 3;
                        if ((columna < anchoImagen1) && (renglon < altoImagen1))
                        {
                            punteroPixel1 += paso1;
                        }
                        if ((columna < anchoImagen2) && (renglon < altoImagen2))
                        {
                            punteroPixel2 += paso2;
                        }
                    }
                }
            }
            imagenSalida.UnlockBits(imagenSalidaDatos);
            ((Bitmap)pImagenEntrada1).UnlockBits(imagen1);
            ((Bitmap)pImagenEntrada2).UnlockBits(imagen2);

            return imagenSalida;
        }
        internal static Image AND_imagenes(Image pImagenEntrada1, Image pImagenEntrada2, bool not)
        {
            BitmapData imagen1 = ((Bitmap)pImagenEntrada1).LockBits(new Rectangle(0, 0, pImagenEntrada1.Width, pImagenEntrada1.Height), ImageLockMode.ReadWrite, pImagenEntrada1.PixelFormat);
            BitmapData imagen2 = ((Bitmap)pImagenEntrada2).LockBits(new Rectangle(0, 0, pImagenEntrada2.Width, pImagenEntrada2.Height), ImageLockMode.ReadWrite, pImagenEntrada2.PixelFormat);

            int altoImagen1 = imagen1.Height;
            int anchoImagen1 = imagen1.Width;
            int altoImagen2 = imagen2.Height;
            int anchoImagen2 = imagen2.Width;

            int altoImageSalida = 0;
            if (altoImagen1 > altoImagen2)
            {
                altoImageSalida = altoImagen1;
            }
            else
            {
                altoImageSalida = altoImagen2;
            }

            int anchoImageSalida = 0;
            if (anchoImagen1 > anchoImagen2)
            {
                anchoImageSalida = anchoImagen1;
            }
            else
            {
                anchoImageSalida = anchoImagen2;
            }

            Bitmap imagenSalida = new Bitmap(width: anchoImageSalida, height: altoImageSalida, format: PixelFormat.Format24bppRgb);
            BitmapData imagenSalidaDatos = imagenSalida.LockBits(new Rectangle(0, 0, anchoImagen1, altoImagen1), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            System.IntPtr primerPixel1 = imagen1.Scan0;
            System.IntPtr primerPixel2 = imagen2.Scan0;
            System.IntPtr primerPixelSalida = imagenSalidaDatos.Scan0;

            decimal NUEVO_R = 0, NUEVO_G = 0, NUEVO_B = 0;
            decimal R1 = 0, G1 = 0, B1 = 0, R2 = 0, G2 = 0, B2 = 0;

            unsafe
            {
                byte* punteroPixel1 = (byte*)(void*)primerPixel1;
                byte* punteroPixel2 = (byte*)(void*)primerPixel2;
                byte* punteroPixelSalida = (byte*)(void*)primerPixelSalida;
                int paso1, paso2;
                paso1 = paso2 = 0;
                switch (pImagenEntrada1.PixelFormat)
                {
                    case PixelFormat.Format24bppRgb:
                        //obtiene el valor del canal de color del pixel
                        paso1 = 3;
                        break;
                    case PixelFormat.Format32bppArgb:
                        //obtiene el valor del canal de color del pixel
                        paso1 = 4;
                        break;
                    case PixelFormat.Format8bppIndexed:
                        paso1 = 1;
                        break;
                    default:
                        break;
                }
                switch (pImagenEntrada2.PixelFormat)
                {
                    case PixelFormat.Format24bppRgb:
                        //obtiene el valor del canal de color del pixel
                        paso2 = 3;
                        break;
                    case PixelFormat.Format32bppArgb:
                        //obtiene el valor del canal de color del pixel
                        paso2 = 4;
                        break;
                    case PixelFormat.Format8bppIndexed:
                        paso2 = 1;
                        break;
                    default:
                        break;
                }

                for (int renglon = 0; renglon < altoImageSalida; renglon++)
                {
                    for (int columna = 0; columna < anchoImageSalida; columna++)
                    {
                        if ((paso1 != 0) && (paso2 != 0))
                        {
                            if ((columna < anchoImagen1) && (renglon < altoImagen1))
                            {
                                try
                                {
                                    R1 = (decimal)punteroPixel1[0];
                                }
                                catch (Exception)
                                {
                                    R1 = 0;
                                }
                                try
                                {
                                    G1 = (decimal)punteroPixel1[1];
                                }
                                catch (Exception)
                                {
                                    G1 = 0;
                                }
                                try
                                {
                                    B1 = (decimal)punteroPixel1[2];
                                }
                                catch (Exception)
                                {
                                    B1 = 0;
                                }
                            }
                            else
                            {
                                R1 = G1 = B1 = 0;
                            }

                            if ((columna < anchoImagen2) && (renglon < altoImagen2))
                            {
                                try
                                {
                                    R2 = (decimal)punteroPixel2[0];
                                }
                                catch (Exception)
                                {
                                    R2 = 0;
                                }
                                try
                                {
                                    G2 = (decimal)punteroPixel2[1];
                                }
                                catch (Exception)
                                {
                                    G2 = 0;
                                }
                                try
                                {
                                    B2 = (decimal)punteroPixel2[2];
                                }
                                catch (Exception)
                                {
                                    B2 = 0;
                                }
                            }
                            else
                            {
                                R2 = G2 = B2 = 0;
                            }
                        }
                        else
                        {
                            if (paso1 == 3)
                            {
                                if ((columna < anchoImagen1) && (renglon < altoImagen1))
                                {

                                    try
                                    {
                                        R1 = (decimal)punteroPixel1[0];
                                    }
                                    catch (Exception)
                                    {
                                        R1 = 0;
                                    }
                                    try
                                    {
                                        G1 = (decimal)punteroPixel1[1];
                                    }
                                    catch (Exception)
                                    {
                                        G1 = 0;
                                    }
                                    try
                                    {
                                        B1 = (decimal)punteroPixel1[2];
                                    }
                                    catch (Exception)
                                    {
                                        B1 = 0;
                                    }
                                }
                                else
                                {
                                    R1 = G1 = B1 = 0;
                                }

                                if ((columna < anchoImagen2) && (renglon < altoImagen2))
                                {
                                    try
                                    {
                                        R2 = (decimal)punteroPixel2[0];
                                    }
                                    catch (Exception)
                                    {
                                        R2 = 0;
                                    }
                                    B2 = G2 = R2;
                                }
                                else
                                {
                                    R2 = G2 = B2 = 0;
                                }
                            }
                            else
                            {
                                if (paso2 == 3)
                                {
                                    if ((columna < anchoImagen1) && (renglon < altoImagen1))
                                    {

                                        try
                                        {
                                            R1 = (decimal)punteroPixel1[0];
                                        }
                                        catch (Exception)
                                        {
                                            R1 = 0;
                                        }
                                        B1 = G1 = R1;
                                    }
                                    else
                                    {
                                        R1 = G1 = B1 = 0;
                                    }

                                    if ((columna < anchoImagen2) && (renglon < altoImagen2))
                                    {
                                        try
                                        {
                                            R2 = (decimal)punteroPixel2[0];
                                        }
                                        catch (Exception)
                                        {
                                            R2 = 0;
                                        }
                                        try
                                        {
                                            G2 = (decimal)punteroPixel2[1];
                                        }
                                        catch (Exception)
                                        {
                                            G2 = 0;
                                        }
                                        try
                                        {
                                            B2 = (decimal)punteroPixel2[2];
                                        }
                                        catch (Exception)
                                        {
                                            B2 = 0;
                                        }
                                    }
                                    else
                                    {
                                        R2 = G2 = B2 = 0;
                                    }
                                }
                                else
                                {
                                    if ((columna < anchoImagen1) && (renglon < altoImagen1))
                                    {

                                        try
                                        {
                                            R1 = (decimal)punteroPixel1[0];
                                        }
                                        catch (Exception)
                                        {
                                            R1 = 0;
                                        }
                                        B1 = G1 = R1;
                                    }
                                    else
                                    {
                                        R1 = G1 = B1 = 0;
                                    }

                                    if ((columna < anchoImagen2) && (renglon < altoImagen2))
                                    {
                                        try
                                        {
                                            R2 = (decimal)punteroPixel2[0];
                                        }
                                        catch (Exception)
                                        {
                                            R2 = 0;
                                        }
                                        B2 = G2 = R2;
                                    }
                                    else
                                    {
                                        R2 = G2 = B2 = 0;
                                    }
                                }
                            }
                        }
                        if (not)
                        {
                            R2 = (int)R2 ^ 255;
                            G2 = (int)G2 ^ 255;
                            B2 = (int)B2 ^ 255;
                        }

                        NUEVO_R = ((int)R1 & (int)R2);
                        NUEVO_G = ((int)G1 & (int)G2);
                        NUEVO_B = ((int)B1 & (int)B2);

                        punteroPixelSalida[0] = (byte)NUEVO_R;
                        punteroPixelSalida[1] = (byte)NUEVO_G;
                        punteroPixelSalida[2] = (byte)NUEVO_B;
                        punteroPixelSalida += 3;
                        if ((columna < anchoImagen1) && (renglon < altoImagen1))
                        {
                            punteroPixel1 += paso1;
                        }
                        if ((columna < anchoImagen2) && (renglon < altoImagen2))
                        {
                            punteroPixel2 += paso2;
                        }
                    }
                }
            }
            imagenSalida.UnlockBits(imagenSalidaDatos);
            ((Bitmap)pImagenEntrada1).UnlockBits(imagen1);
            ((Bitmap)pImagenEntrada2).UnlockBits(imagen2);

            return imagenSalida;
        }
        internal static Image OR_imagenes(Image pImagenEntrada1, Image pImagenEntrada2, bool not)
        {
            BitmapData imagen1 = ((Bitmap)pImagenEntrada1).LockBits(new Rectangle(0, 0, pImagenEntrada1.Width, pImagenEntrada1.Height), ImageLockMode.ReadWrite, pImagenEntrada1.PixelFormat);
            BitmapData imagen2 = ((Bitmap)pImagenEntrada2).LockBits(new Rectangle(0, 0, pImagenEntrada2.Width, pImagenEntrada2.Height), ImageLockMode.ReadWrite, pImagenEntrada2.PixelFormat);

            int altoImagen1 = imagen1.Height;
            int anchoImagen1 = imagen1.Width;
            int altoImagen2 = imagen2.Height;
            int anchoImagen2 = imagen2.Width;

            int altoImageSalida = 0;
            if (altoImagen1 > altoImagen2)
            {
                altoImageSalida = altoImagen1;
            }
            else
            {
                altoImageSalida = altoImagen2;
            }

            int anchoImageSalida = 0;
            if (anchoImagen1 > anchoImagen2)
            {
                anchoImageSalida = anchoImagen1;
            }
            else
            {
                anchoImageSalida = anchoImagen2;
            }

            Bitmap imagenSalida = new Bitmap(width: anchoImageSalida, height: altoImageSalida, format: PixelFormat.Format24bppRgb);
            BitmapData imagenSalidaDatos = imagenSalida.LockBits(new Rectangle(0, 0, anchoImagen1, altoImagen1), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            System.IntPtr primerPixel1 = imagen1.Scan0;
            System.IntPtr primerPixel2 = imagen2.Scan0;
            System.IntPtr primerPixelSalida = imagenSalidaDatos.Scan0;

            decimal NUEVO_R = 0, NUEVO_G = 0, NUEVO_B = 0;
            decimal R1 = 0, G1 = 0, B1 = 0, R2 = 0, G2 = 0, B2 = 0;

            unsafe
            {
                byte* punteroPixel1 = (byte*)(void*)primerPixel1;
                byte* punteroPixel2 = (byte*)(void*)primerPixel2;
                byte* punteroPixelSalida = (byte*)(void*)primerPixelSalida;
                int paso1, paso2;
                paso1 = paso2 = 0;
                switch (pImagenEntrada1.PixelFormat)
                {
                    case PixelFormat.Format24bppRgb:
                        //obtiene el valor del canal de color del pixel
                        paso1 = 3;
                        break;
                    case PixelFormat.Format32bppArgb:
                        //obtiene el valor del canal de color del pixel
                        paso1 = 4;
                        break;
                    case PixelFormat.Format8bppIndexed:
                        paso1 = 1;
                        break;
                    default:
                        break;
                }
                switch (pImagenEntrada2.PixelFormat)
                {
                    case PixelFormat.Format24bppRgb:
                        //obtiene el valor del canal de color del pixel
                        paso2 = 3;
                        break;
                    case PixelFormat.Format32bppArgb:
                        //obtiene el valor del canal de color del pixel
                        paso2 = 4;
                        break;
                    case PixelFormat.Format8bppIndexed:
                        paso2 = 1;
                        break;
                    default:
                        break;
                }

                for (int renglon = 0; renglon < altoImageSalida; renglon++)
                {
                    for (int columna = 0; columna < anchoImageSalida; columna++)
                    {
                        if ((paso1 != 0) && (paso2 != 0))
                        {
                            if ((columna < anchoImagen1) && (renglon < altoImagen1))
                            {
                                try
                                {
                                    R1 = (decimal)punteroPixel1[0];
                                }
                                catch (Exception)
                                {
                                    R1 = 0;
                                }
                                try
                                {
                                    G1 = (decimal)punteroPixel1[1];
                                }
                                catch (Exception)
                                {
                                    G1 = 0;
                                }
                                try
                                {
                                    B1 = (decimal)punteroPixel1[2];
                                }
                                catch (Exception)
                                {
                                    B1 = 0;
                                }
                            }
                            else
                            {
                                R1 = G1 = B1 = 0;
                            }

                            if ((columna < anchoImagen2) && (renglon < altoImagen2))
                            {
                                try
                                {
                                    R2 = (decimal)punteroPixel2[0];
                                }
                                catch (Exception)
                                {
                                    R2 = 0;
                                }
                                try
                                {
                                    G2 = (decimal)punteroPixel2[1];
                                }
                                catch (Exception)
                                {
                                    G2 = 0;
                                }
                                try
                                {
                                    B2 = (decimal)punteroPixel2[2];
                                }
                                catch (Exception)
                                {
                                    B2 = 0;
                                }
                            }
                            else
                            {
                                R2 = G2 = B2 = 0;
                            }
                        }
                        else
                        {
                            if (paso1 == 3)
                            {
                                if ((columna < anchoImagen1) && (renglon < altoImagen1))
                                {

                                    try
                                    {
                                        R1 = (decimal)punteroPixel1[0];
                                    }
                                    catch (Exception)
                                    {
                                        R1 = 0;
                                    }
                                    try
                                    {
                                        G1 = (decimal)punteroPixel1[1];
                                    }
                                    catch (Exception)
                                    {
                                        G1 = 0;
                                    }
                                    try
                                    {
                                        B1 = (decimal)punteroPixel1[2];
                                    }
                                    catch (Exception)
                                    {
                                        B1 = 0;
                                    }
                                }
                                else
                                {
                                    R1 = G1 = B1 = 0;
                                }

                                if ((columna < anchoImagen2) && (renglon < altoImagen2))
                                {
                                    try
                                    {
                                        R2 = (decimal)punteroPixel2[0];
                                    }
                                    catch (Exception)
                                    {
                                        R2 = 0;
                                    }
                                    B2 = G2 = R2;
                                }
                                else
                                {
                                    R2 = G2 = B2 = 0;
                                }
                            }
                            else
                            {
                                if (paso2 == 3)
                                {
                                    if ((columna < anchoImagen1) && (renglon < altoImagen1))
                                    {

                                        try
                                        {
                                            R1 = (decimal)punteroPixel1[0];
                                        }
                                        catch (Exception)
                                        {
                                            R1 = 0;
                                        }
                                        B1 = G1 = R1;
                                    }
                                    else
                                    {
                                        R1 = G1 = B1 = 0;
                                    }

                                    if ((columna < anchoImagen2) && (renglon < altoImagen2))
                                    {
                                        try
                                        {
                                            R2 = (decimal)punteroPixel2[0];
                                        }
                                        catch (Exception)
                                        {
                                            R2 = 0;
                                        }
                                        try
                                        {
                                            G2 = (decimal)punteroPixel2[1];
                                        }
                                        catch (Exception)
                                        {
                                            G2 = 0;
                                        }
                                        try
                                        {
                                            B2 = (decimal)punteroPixel2[2];
                                        }
                                        catch (Exception)
                                        {
                                            B2 = 0;
                                        }
                                    }
                                    else
                                    {
                                        R2 = G2 = B2 = 0;
                                    }
                                }
                                else
                                {
                                    if ((columna < anchoImagen1) && (renglon < altoImagen1))
                                    {

                                        try
                                        {
                                            R1 = (decimal)punteroPixel1[0];
                                        }
                                        catch (Exception)
                                        {
                                            R1 = 0;
                                        }
                                        B1 = G1 = R1;
                                    }
                                    else
                                    {
                                        R1 = G1 = B1 = 0;
                                    }

                                    if ((columna < anchoImagen2) && (renglon < altoImagen2))
                                    {
                                        try
                                        {
                                            R2 = (decimal)punteroPixel2[0];
                                        }
                                        catch (Exception)
                                        {
                                            R2 = 0;
                                        }
                                        B2 = G2 = R2;
                                    }
                                    else
                                    {
                                        R2 = G2 = B2 = 0;
                                    }
                                }
                            }
                        }
                        if (not)
                        {
                            R2 = (int)R2 ^ 255;
                            G2 = (int)G2 ^ 255;
                            B2 = (int)B2 ^ 255;
                        }

                        NUEVO_R = ((int)R1 | (int)R2);
                        NUEVO_G = ((int)G1 | (int)G2);
                        NUEVO_B = ((int)B1 | (int)B2);

                        punteroPixelSalida[0] = (byte)NUEVO_R;
                        punteroPixelSalida[1] = (byte)NUEVO_G;
                        punteroPixelSalida[2] = (byte)NUEVO_B;
                        punteroPixelSalida += 3;
                        if ((columna < anchoImagen1) && (renglon < altoImagen1))
                        {
                            punteroPixel1 += paso1;
                        }
                        if ((columna < anchoImagen2) && (renglon < altoImagen2))
                        {
                            punteroPixel2 += paso2;
                        }
                    }
                }
            }
            imagenSalida.UnlockBits(imagenSalidaDatos);
            ((Bitmap)pImagenEntrada1).UnlockBits(imagen1);
            ((Bitmap)pImagenEntrada2).UnlockBits(imagen2);

            return imagenSalida;
        }
        internal static Image XOR_imagenes(Image pImagenEntrada1, Image pImagenEntrada2, bool not)
        {
            BitmapData imagen1 = ((Bitmap)pImagenEntrada1).LockBits(new Rectangle(0, 0, pImagenEntrada1.Width, pImagenEntrada1.Height), ImageLockMode.ReadWrite, pImagenEntrada1.PixelFormat);
            BitmapData imagen2 = ((Bitmap)pImagenEntrada2).LockBits(new Rectangle(0, 0, pImagenEntrada2.Width, pImagenEntrada2.Height), ImageLockMode.ReadWrite, pImagenEntrada2.PixelFormat);

            int altoImagen1 = imagen1.Height;
            int anchoImagen1 = imagen1.Width;
            int altoImagen2 = imagen2.Height;
            int anchoImagen2 = imagen2.Width;

            int altoImageSalida = 0;
            if (altoImagen1 > altoImagen2)
            {
                altoImageSalida = altoImagen1;
            }
            else
            {
                altoImageSalida = altoImagen2;
            }

            int anchoImageSalida = 0;
            if (anchoImagen1 > anchoImagen2)
            {
                anchoImageSalida = anchoImagen1;
            }
            else
            {
                anchoImageSalida = anchoImagen2;
            }

            Bitmap imagenSalida = new Bitmap(width: anchoImageSalida, height: altoImageSalida, format: PixelFormat.Format24bppRgb);
            BitmapData imagenSalidaDatos = imagenSalida.LockBits(new Rectangle(0, 0, anchoImagen1, altoImagen1), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            System.IntPtr primerPixel1 = imagen1.Scan0;
            System.IntPtr primerPixel2 = imagen2.Scan0;
            System.IntPtr primerPixelSalida = imagenSalidaDatos.Scan0;

            decimal NUEVO_R = 0, NUEVO_G = 0, NUEVO_B = 0;
            decimal R1 = 0, G1 = 0, B1 = 0, R2 = 0, G2 = 0, B2 = 0;

            unsafe
            {
                byte* punteroPixel1 = (byte*)(void*)primerPixel1;
                byte* punteroPixel2 = (byte*)(void*)primerPixel2;
                byte* punteroPixelSalida = (byte*)(void*)primerPixelSalida;
                int paso1, paso2;
                paso1 = paso2 = 0;
                switch (pImagenEntrada1.PixelFormat)
                {
                    case PixelFormat.Format24bppRgb:
                        //obtiene el valor del canal de color del pixel
                        paso1 = 3;
                        break;
                    case PixelFormat.Format32bppArgb:
                        //obtiene el valor del canal de color del pixel
                        paso1 = 4;
                        break;
                    case PixelFormat.Format8bppIndexed:
                        paso1 = 1;
                        break;
                    default:
                        break;
                }
                switch (pImagenEntrada2.PixelFormat)
                {
                    case PixelFormat.Format24bppRgb:
                        //obtiene el valor del canal de color del pixel
                        paso2 = 3;
                        break;
                    case PixelFormat.Format32bppArgb:
                        //obtiene el valor del canal de color del pixel
                        paso2 = 4;
                        break;
                    case PixelFormat.Format8bppIndexed:
                        paso2 = 1;
                        break;
                    default:
                        break;
                }

                for (int renglon = 0; renglon < altoImageSalida; renglon++)
                {
                    for (int columna = 0; columna < anchoImageSalida; columna++)
                    {
                        if ((paso1 != 0) && (paso2 != 0))
                        {
                            if ((columna < anchoImagen1) && (renglon < altoImagen1))
                            {
                                try
                                {
                                    R1 = (decimal)punteroPixel1[0];
                                }
                                catch (Exception)
                                {
                                    R1 = 0;
                                }
                                try
                                {
                                    G1 = (decimal)punteroPixel1[1];
                                }
                                catch (Exception)
                                {
                                    G1 = 0;
                                }
                                try
                                {
                                    B1 = (decimal)punteroPixel1[2];
                                }
                                catch (Exception)
                                {
                                    B1 = 0;
                                }
                            }
                            else
                            {
                                R1 = G1 = B1 = 0;
                            }

                            if ((columna < anchoImagen2) && (renglon < altoImagen2))
                            {
                                try
                                {
                                    R2 = (decimal)punteroPixel2[0];
                                }
                                catch (Exception)
                                {
                                    R2 = 0;
                                }
                                try
                                {
                                    G2 = (decimal)punteroPixel2[1];
                                }
                                catch (Exception)
                                {
                                    G2 = 0;
                                }
                                try
                                {
                                    B2 = (decimal)punteroPixel2[2];
                                }
                                catch (Exception)
                                {
                                    B2 = 0;
                                }
                            }
                            else
                            {
                                R2 = G2 = B2 = 0;
                            }
                        }
                        else
                        {
                            if (paso1 == 3)
                            {
                                if ((columna < anchoImagen1) && (renglon < altoImagen1))
                                {

                                    try
                                    {
                                        R1 = (decimal)punteroPixel1[0];
                                    }
                                    catch (Exception)
                                    {
                                        R1 = 0;
                                    }
                                    try
                                    {
                                        G1 = (decimal)punteroPixel1[1];
                                    }
                                    catch (Exception)
                                    {
                                        G1 = 0;
                                    }
                                    try
                                    {
                                        B1 = (decimal)punteroPixel1[2];
                                    }
                                    catch (Exception)
                                    {
                                        B1 = 0;
                                    }
                                }
                                else
                                {
                                    R1 = G1 = B1 = 0;
                                }

                                if ((columna < anchoImagen2) && (renglon < altoImagen2))
                                {
                                    try
                                    {
                                        R2 = (decimal)punteroPixel2[0];
                                    }
                                    catch (Exception)
                                    {
                                        R2 = 0;
                                    }
                                    B2 = G2 = R2;
                                }
                                else
                                {
                                    R2 = G2 = B2 = 0;
                                }
                            }
                            else
                            {
                                if (paso2 == 3)
                                {
                                    if ((columna < anchoImagen1) && (renglon < altoImagen1))
                                    {

                                        try
                                        {
                                            R1 = (decimal)punteroPixel1[0];
                                        }
                                        catch (Exception)
                                        {
                                            R1 = 0;
                                        }
                                        B1 = G1 = R1;
                                    }
                                    else
                                    {
                                        R1 = G1 = B1 = 0;
                                    }

                                    if ((columna < anchoImagen2) && (renglon < altoImagen2))
                                    {
                                        try
                                        {
                                            R2 = (decimal)punteroPixel2[0];
                                        }
                                        catch (Exception)
                                        {
                                            R2 = 0;
                                        }
                                        try
                                        {
                                            G2 = (decimal)punteroPixel2[1];
                                        }
                                        catch (Exception)
                                        {
                                            G2 = 0;
                                        }
                                        try
                                        {
                                            B2 = (decimal)punteroPixel2[2];
                                        }
                                        catch (Exception)
                                        {
                                            B2 = 0;
                                        }
                                    }
                                    else
                                    {
                                        R2 = G2 = B2 = 0;
                                    }
                                }
                                else
                                {
                                    if ((columna < anchoImagen1) && (renglon < altoImagen1))
                                    {

                                        try
                                        {
                                            R1 = (decimal)punteroPixel1[0];
                                        }
                                        catch (Exception)
                                        {
                                            R1 = 0;
                                        }
                                        B1 = G1 = R1;
                                    }
                                    else
                                    {
                                        R1 = G1 = B1 = 0;
                                    }

                                    if ((columna < anchoImagen2) && (renglon < altoImagen2))
                                    {
                                        try
                                        {
                                            R2 = (decimal)punteroPixel2[0];
                                        }
                                        catch (Exception)
                                        {
                                            R2 = 0;
                                        }
                                        B2 = G2 = R2;
                                    }
                                    else
                                    {
                                        R2 = G2 = B2 = 0;
                                    }
                                }
                            }
                        }
                        if (not)
                        {
                            R2 = (int)R2 ^ 255;
                            G2 = (int)G2 ^ 255;
                            B2 = (int)B2 ^ 255;
                        }

                        NUEVO_R = ((int)R1 ^ (int)R2);
                        NUEVO_G = ((int)G1 ^ (int)G2);
                        NUEVO_B = ((int)B1 ^ (int)B2);

                        punteroPixelSalida[0] = (byte)NUEVO_R;
                        punteroPixelSalida[1] = (byte)NUEVO_G;
                        punteroPixelSalida[2] = (byte)NUEVO_B;
                        punteroPixelSalida += 3;
                        if ((columna < anchoImagen1) && (renglon < altoImagen1))
                        {
                            punteroPixel1 += paso1;
                        }
                        if ((columna < anchoImagen2) && (renglon < altoImagen2))
                        {
                            punteroPixel2 += paso2;
                        }
                    }
                }
            }
            imagenSalida.UnlockBits(imagenSalidaDatos);
            ((Bitmap)pImagenEntrada1).UnlockBits(imagen1);
            ((Bitmap)pImagenEntrada2).UnlockBits(imagen2);

            return imagenSalida;
        }
    }
}
