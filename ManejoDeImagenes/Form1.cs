using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;

namespace ManejoDeImagenes
{
    public partial class FormImagenes : Form
    {
        private Image ImageToSave;

        public FormImagenes()
        {
            InitializeComponent();
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();    
        }

        private void abrirImagenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogoAbrirImagen.ShowDialog();
        }

        private void DialogoAbrirImagen_FileOk(object sender, CancelEventArgs e)
        {
            imagenOriginalZoom.ImageLocation = DialogoAbrirImagen.FileName;
            imagenOriginalZoom.SizeMode = PictureBoxSizeMode.Zoom;
          
            ///imagenes nuevas
            imagenDespuesCorte.Image = null;
            imagenDespuesCuant.Image = null;
            imagenGrisLightness.Image = null;
            imagenGrisAverage.Image = null;
            imagenGrisLuminosity.Image = null;

            imgMensajeEstaganografia.Image = null;
            imgDespuesOpUn.Image = null;

            imagenDespuesCorte.SizeMode = PictureBoxSizeMode.Zoom;
            imagenDespuesCuant.SizeMode = PictureBoxSizeMode.Zoom;
            imagenGrisLightness.SizeMode = PictureBoxSizeMode.Zoom;
            imagenGrisAverage.SizeMode = PictureBoxSizeMode.Zoom;
            imagenGrisLuminosity.SizeMode = PictureBoxSizeMode.Zoom;

            imgMensajeEstaganografia.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void bGenerarImagen_Click(object sender, EventArgs e)
        {
            if (imagenOriginalZoom.Image != null)
            {
                imgDespuesOpUn.Image = OperacionesUnarias.aplicaOperaciones(imagenOriginalZoom.Image, (int)suma1.Value, (int)suma2.Value, (int)suma3.Value, mult1.Value, mult2.Value, mult3.Value, div1.Value, div2.Value, div3.Value, gama1.Value, gama2.Value, gama3.Value);
            }
        }

        private void btCortar_Click(object sender, EventArgs e)
        {
            if (imagenDespuesCorte.Image != null)
            {
                imagenDespuesCorte.Image = Corte.cortarImagen(imagenDespuesCorte.Image);
            }
            else
            {
                if (imagenOriginalZoom.Image != null)
                {
                    imagenDespuesCorte.Image = Corte.cortarImagen(imagenOriginalZoom.Image);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (imagenDespuesCorte.Image != null)
            {
                imagenDespuesCorte.Image = Corte.cortarImagen(imagenDespuesCorte.Image);
            }
            else
            {
                if (imagenOriginalZoom.Image != null)
                {
                    imagenDespuesCorte.Image = Corte.agrandarImagen(imagenOriginalZoom.Image);
                }
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (imagenOriginalZoom.Image != null)
            {
                imagenDespuesCuant.Image = Cuantificacion.disminuirBytes(imagenOriginalZoom.Image,(int)numericUpDown1.Value);
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (imagenOriginalZoom.Image != null)
            {
                imagenGrisLightness.Image = Cuantificacion.escalaDeGrisesLightness(imagenOriginalZoom.Image);
                imagenGrisAverage.Image = Cuantificacion.escalaDeGrisesAverage(imagenOriginalZoom.Image);
                imagenGrisLuminosity.Image = Cuantificacion.escalaDeGrisesLuminosity(imagenOriginalZoom.Image);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            flowDivSeparar.Controls.Clear();    
            if (imagenOriginalZoom.Image != null)
            {
                for(int i=1; i <= 8; i++)
                {
                    if (chkSepararCanales.Checked)
                    {
                        Image[] imagenes = Separar.bit_a_separarARGB(imagenOriginalZoom.Image, i);
                        PictureBox pictureBoxR = new PictureBox
                        {
                            SizeMode = PictureBoxSizeMode.Zoom,
                            Size = new Size(200, 200),
                            Image=imagenes[1],
                            BorderStyle = BorderStyle.FixedSingle
                        };
                        PictureBox pictureBoxG = new PictureBox
                        {
                            SizeMode = PictureBoxSizeMode.Zoom,
                            Size = new Size(200, 200),
                            Image = imagenes[2],
                            BorderStyle = BorderStyle.FixedSingle
                            
                        };
                        PictureBox pictureBoxB = new PictureBox
                        {
                            SizeMode = PictureBoxSizeMode.Zoom,
                            Size = new Size(200, 200),
                            Image = imagenes[3],
                            BorderStyle = BorderStyle.FixedSingle
                        };
                        pictureBoxR.DoubleClick += imagenOriginalZoom_DoubleClick;
                        flowDivSeparar.Controls.Add(pictureBoxR);
                        pictureBoxG.DoubleClick += imagenOriginalZoom_DoubleClick;
                        flowDivSeparar.Controls.Add(pictureBoxG);
                        pictureBoxB.DoubleClick += imagenOriginalZoom_DoubleClick;
                        flowDivSeparar.Controls.Add(pictureBoxB);
                    }
                    else
                    {
                        PictureBox pictureBox = new PictureBox
                        {
                            SizeMode = PictureBoxSizeMode.Zoom,
                            Size = new Size(200, 200),
                            Image = Separar.bit_a_separar(imagenOriginalZoom.Image, i)
                        };
                        pictureBox.DoubleClick += imagenOriginalZoom_DoubleClick;
                        flowDivSeparar.Controls.Add(pictureBox);
                    }
                }
            }
        }

        private void ocultarMensaje_Click(object sender, EventArgs e)
        {
            if(imagenOriginalZoom.Image != null)
            {
                imgMensajeEstaganografia.Image = Esteganografia.encriptar(imagenOriginalZoom.Image, imgAOcultar.Image);
            }
        }

        private void saveImageDialog_FileOk(object sender, CancelEventArgs e)
        {
            if (ImageToSave != null)
            {
                ImageToSave.Save(saveImageDialog.FileName.Replace(".bmp","") + ".bmp", ImageFormat.Bmp);
            }
        }

        private void guardarImagenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveImageDialog.ShowDialog();
        }

        private void btnImgOcultar_Click(object sender, EventArgs e)
        {
            abrirImagenOcultar.ShowDialog();
        }

        private void abrirImagenOcultar_FileOk(object sender, CancelEventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 9:
                    imagenSumaResta2.ImageLocation = abrirImagenOcultar.FileName;
                    break;
                case 10:
                    imagenMultiDiv2.ImageLocation = abrirImagenOcultar.FileName;
                    break;
                case 11:
                    imagenBooleana2.ImageLocation = abrirImagenOcultar.FileName;
                    break;
                default:
                    imgAOcultar.ImageLocation = abrirImagenOcultar.FileName;
                    break;
            }
        }

        private void umbralCorteInferiorC1_ValueChanged(object sender, EventArgs e)
        {
            txtUCIC1.Text = umbralCorteInferiorC1.Value.ToString();
            txtUCIC2.Text = umbralCorteInferiorC2.Value.ToString();
            txtUCIC3.Text = umbralCorteInferiorC3.Value.ToString();
            txtUCSC1.Text = umbralCorteSuperiorC1.Value.ToString();
            txtUCSC2.Text = umbralCorteSuperiorC2.Value.ToString();
            txtUCSC3.Text = umbralCorteSuperiorC3.Value.ToString();
        }

        private void umbralBinarioInferiorC1_ValueChanged(object sender, EventArgs e)
        {
            txtUBIC1.Text = umbralBinarioInferiorC1.Value.ToString();
            txtUBIC2.Text = umbralBinarioInferiorC2.Value.ToString();
            txtUBIC3.Text = umbralBinarioInferiorC3.Value.ToString();
            txtUBSC1.Text = umbralBinarioSuperiorC1.Value.ToString();
            txtUBSC2.Text = umbralBinarioSuperiorC2.Value.ToString();
            txtUBSC3.Text = umbralBinarioSuperiorC3.Value.ToString();
        }

        private void AplicarUmbralBinario_Click(object sender, EventArgs e)
        {
            if (imagenOriginalZoom.Image != null)
            {
                imgUmbralBinarioDespues.Image = OperacionesUnarias.umbralBinario(imagenOriginalZoom.Image, umbralBinarioInferiorC1.Value, umbralBinarioInferiorC2.Value, umbralBinarioInferiorC3.Value, umbralBinarioSuperiorC1.Value, umbralBinarioSuperiorC2.Value, umbralBinarioSuperiorC3.Value, UmbralBinarioInverso.Checked);
            }
        }

        private void AplicarUmbralCorte_Click(object sender, EventArgs e)
        {
            if (imagenOriginalZoom.Image != null)
            {
                imgUmbralCorteDespues.Image = OperacionesUnarias.umbralCorte(imagenOriginalZoom.Image, umbralCorteInferiorC1.Value, umbralCorteInferiorC2.Value, umbralCorteInferiorC3.Value, umbralCorteSuperiorC1.Value, umbralCorteSuperiorC2.Value, umbralCorteSuperiorC3.Value, umbralCorteInverso.Checked, umbralCorteExtencion.Checked);
            }
        }

        private void txtUBIC1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                umbralBinarioInferiorC1.Value = int.Parse(txtUBIC1.Text);
                umbralBinarioInferiorC2.Value = int.Parse(txtUBIC2.Text);
                umbralBinarioInferiorC3.Value = int.Parse(txtUBIC3.Text);
                umbralBinarioSuperiorC1.Value = int.Parse(txtUBSC1.Text);
                umbralBinarioSuperiorC2.Value = int.Parse(txtUBSC2.Text);
                umbralBinarioSuperiorC3.Value = int.Parse(txtUBSC3.Text);
            }
            catch (Exception)
            {
            }
        }

        private void txtUCIC1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                umbralCorteInferiorC1.Value = int.Parse(txtUCIC1.Text);
                umbralCorteInferiorC2.Value = int.Parse(txtUCIC2.Text);
                umbralCorteInferiorC3.Value = int.Parse(txtUCIC3.Text);
                umbralCorteSuperiorC1.Value = int.Parse(txtUCSC1.Text);
                umbralCorteSuperiorC2.Value = int.Parse(txtUCSC2.Text);
                umbralCorteSuperiorC3.Value = int.Parse(txtUCSC3.Text);
            }
            catch (Exception)
            {
            }
        }

        private void btSumarImagenes_Click(object sender, EventArgs e)
        {
            imagenSumaResta1.Image = imagenOriginalZoom.Image;
            if ((imagenSumaResta1.Image != null) && (imagenSumaResta2.Image != null))
            {
                imagenSumaRestaFinal.Image = Operaciones2Imagenes.suma_imagenes(imagenSumaResta1.Image, imagenSumaResta2.Image, txtPesoSuma1.Value, txtPesoSuma2.Value);
            }
        }

        private void btRestarImagenes_Click(object sender, EventArgs e)
        {
            imagenSumaResta1.Image = imagenOriginalZoom.Image;
            if ((imagenSumaResta1.Image != null) && (imagenSumaResta2.Image != null))
            {
                imagenSumaRestaFinal.Image = Operaciones2Imagenes.resta_imagenes(imagenSumaResta1.Image, imagenSumaResta2.Image);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            imagenMultiDiv1.Image = imagenOriginalZoom.Image;
            if ((imagenMultiDiv1.Image != null) && (imagenMultiDiv2.Image != null))
            {
                imagenMultiDivResultado.Image = Operaciones2Imagenes.multiplica_imagenes(imagenMultiDiv1.Image, imagenMultiDiv2.Image, txtPesoMultiDiv.Value);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            imagenMultiDiv1.Image = imagenOriginalZoom.Image;
            if ((imagenMultiDiv1.Image != null) && (imagenMultiDiv2.Image != null))
            {
                imagenMultiDivResultado.Image = Operaciones2Imagenes.divide_imagenes(imagenMultiDiv1.Image, imagenMultiDiv2.Image, txtPesoMultiDiv.Value);
            }
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            panelUmbralEscalon.Controls.Clear();
            int n = (int)txtNumUmbrales.Value;
            TextBox[] txtUmbral = new TextBox[n];
            Label[] lbUmbral = new Label[n];
            
            for (int i = 0; i < n; i++)
            {
                lbUmbral[i] = new Label();
                lbUmbral[i].Text = "Umbral " + (i+1);
                lbUmbral[i].Left = (int)(200 * Math.Floor((double)(i / 4)));
                lbUmbral[i].Top = 30 * (i % 4);
                txtUmbral[i] = new TextBox();
                txtUmbral[i].Name = "txtUmbral" + i;
                txtUmbral[i].Left = (int)(200 * Math.Floor((double)(i / 4))) +70;
                txtUmbral[i].Top = 30 * (i % 4);
                txtUmbral[i].Text = ((i + 1) * (255 / n)).ToString();
            }
            
            for (int i = 0; i < n; i++)
            {
                panelUmbralEscalon.Controls.Add(txtUmbral[i]);
                panelUmbralEscalon.Controls.Add(lbUmbral[i]);
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 8:
                    numericUpDown2_ValueChanged(null, System.EventArgs.Empty);
                    break;
                default:
                    imgAOcultar.ImageLocation = abrirImagenOcultar.FileName;
                    break;
            }
        }

        private void btUmbralEscalon_Click(object sender, EventArgs e)
        {
            try
            {
                int n = (int)txtNumUmbrales.Value;
                int[] umbrales = new int[n];
                for (int i = 0; i < n; i++)
                {
                    string nombre = "txtUmbral" + i;
                    TextBox valor = (TextBox)panelUmbralEscalon.Controls[nombre];
                    umbrales[i] = int.Parse(valor.Text);
                }
                if (imagenOriginalZoom.Image != null)
                {
                    imagenUmbralesEscalonDespues.Image = OperacionesUnarias.umbralEscalon(imagenOriginalZoom.Image, umbrales);
                }
            }
            catch (Exception)
            {
                
                
            }
        }

        private void btAND_Click(object sender, EventArgs e)
        {
            imagenBooleana1.Image = imagenOriginalZoom.Image;
            if ((imagenBooleana1.Image != null) && (imagenBooleana2.Image != null))
            {
                imagenBoolenaResultado.Image = Operaciones2Imagenes.AND_imagenes(imagenBooleana1.Image, imagenBooleana2.Image, chkNOT1.Checked);
            }
        }

        private void btOR_Click(object sender, EventArgs e)
        {
            imagenBooleana1.Image = imagenOriginalZoom.Image;
            if ((imagenBooleana1.Image != null) && (imagenBooleana2.Image != null))
            {
                imagenBoolenaResultado.Image = Operaciones2Imagenes.OR_imagenes(imagenBooleana1.Image, imagenBooleana2.Image, chkNOT1.Checked);
            }
        }

        private void btXOR_Click(object sender, EventArgs e)
        {
            imagenBooleana1.Image = imagenOriginalZoom.Image;
            if ((imagenBooleana1.Image != null) && (imagenBooleana2.Image != null))
            {
                imagenBoolenaResultado.Image = Operaciones2Imagenes.XOR_imagenes(imagenBooleana1.Image, imagenBooleana2.Image, chkNOT1.Checked);
            }
        }

        private void btHistograma_Click(object sender, EventArgs e)
        {
            if (imagenOriginalZoom.Image != null)
            {
                controlHistogramas1.Canales = Histogramas.obten_histograma(imagenOriginalZoom.Image);
                controlHistogramas1.GeneraHistograma();
            }
        }

        private void btEstirar_Click(object sender, EventArgs e)
        {
            if (imagenOriginalZoom.Image != null)
            {
                imagenHistogramaEstiramientoSalida.Image = Histogramas.estiramiento(imagenOriginalZoom.Image, (int)txtLimiteInferiorEstirar_1.Value, (int)txtLimiteInferiorEstirar_2.Value, (int)txtLimiteInferiorEstirar_3.Value, (int)txtLimiteSuperiorEstirar_1.Value, (int)txtLimiteSuperiorEstirar_2.Value, (int)txtLimiteSuperiorEstirar_3.Value);
                controlHistogramas_estiramiento_salida.Canales = Histogramas.obten_histograma(imagenHistogramaEstiramientoSalida.Image);
                controlHistogramas_estiramiento_salida.GeneraHistograma();
            }
        }

        private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl2.SelectedIndex == 1)
            {
                if (imagenOriginalZoom.Image != null)
                {
                    controlHistogramas_estiramiento_entrada.Canales = Histogramas.obten_histograma(imagenOriginalZoom.Image);
                    controlHistogramas_estiramiento_entrada.GeneraHistograma();
                }
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (imagenOriginalZoom.Image != null)
            {
                imagenEqualizacionSalida.Image = Histogramas.aplica_equalizacion(imagenOriginalZoom.Image, Histogramas.obten_equalizacion(Histogramas.obten_histograma(imagenOriginalZoom.Image), imagenOriginalZoom.Image.Width * imagenOriginalZoom.Image.Height));
                controlHistogramasEqualizacion2.Canales = Histogramas.obten_histograma(imagenEqualizacionSalida.Image);
                controlHistogramasEqualizacion2.GeneraHistograma();
            }
        }

        private void tabControl4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl4.SelectedIndex == 1)
            {
                if (imagenOriginalZoom.Image != null)
                {
                    controlHistogramasEqualizacion1.Canales = Histogramas.obten_histograma(imagenOriginalZoom.Image);
                    controlHistogramasEqualizacion1.GeneraHistograma();
                }
            }
        }

        private void btComponentesConexas_Click(object sender, EventArgs e)
        {
            if (imagenOriginalZoom.Image != null)
            {
                int[,] componentes = Vecindad.obtenComponentesConexas(imagenOriginalZoom.Image);
                StringBuilder texto = new StringBuilder();
                List<int> campos = new List<int>();
                SortedList<int, int> campos_2 = new SortedList<int, int>();

                for (int renglon = 0; renglon < componentes.GetUpperBound(0); renglon++)
                {
                    for (int columna = 0; columna < componentes.GetUpperBound(1); columna++)
                    {
                        if (!campos_2.ContainsKey(componentes[renglon, columna]))
                        {
                            campos_2.Add(componentes[renglon, columna],1);
                        }
                        else
                        {
                            campos_2[componentes[renglon, columna]] += 1;
                        }
                        texto.Append(componentes[renglon,columna].ToString() + " ");
                    }
                    texto.Append(System.Environment.NewLine);
                }
                foreach (int llave in campos_2.Keys)
                {
                    if (campos_2[llave] > 100) 
                    {
                        campos.Add(llave);
                    }
                }
                txtConexas.Text = texto.ToString();
                txtConexas.Text = campos.Count.ToString();
            }
        }

        private void RuidoGauss_ValueChanged(object sender, EventArgs e)
        {
            RuidoGaussTxt.Text = RuidoGauss.Value.ToString();
            RuidoNormalTxt.Text = RuidoNormal.Value.ToString();
            RuidoSyPTxt.Text = RuidoSyP.Value.ToString();
        }

        private void RuidoGaussTxt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                RuidoGauss.Value = int.Parse(RuidoGaussTxt.Text);
                RuidoNormal.Value = int.Parse(RuidoNormalTxt.Text);
                RuidoSyP.Value = int.Parse(RuidoSyPTxt.Text);
            }
            catch (Exception)
            {
            }
        }

        private void AplicaRuido_Click(object sender, EventArgs e)
        {
            if (imagenOriginalZoom.Image != null)
            {
                imgRuidoDes.Image = Ruido.aplicarRuido(imagenOriginalZoom.Image, int.Parse(centroRuidoG.Text), decimal.Parse(sigmaRuidoG.Text), (int)RuidoGauss.Value, int.Parse(infRuidoU.Text), int.Parse(supRuidoU.Text), (int)RuidoNormal.Value, int.Parse(infRuidoSyP.Text), int.Parse(supRuidoSyP.Text), (int)RuidoSyP.Value);
            }
        }

        private void aplicaFiltro_Click(object sender, EventArgs e)
        {
            if (imagenOriginalZoom.Image != null)
            {
                imgFiltrosSalida.Image = Filtros.aplicarFiltro(imagenOriginalZoom.Image, filtro_seleccionado(GBfiltros), (int)tamano_mascara.Value, (double)sigma_filtro.Value, (int)T_filtro.Value);
            }
        }

        private int filtro_seleccionado(GroupBox lista_filtros)
        {
            int valor = -1, numero = lista_filtros.Controls.Count;
            foreach (RadioButton filtro in lista_filtros.Controls)
            {
                if (filtro.Checked)
                {
                    valor = numero;
                }
                numero--;
            }
            return valor;
        }

        private void Borde_1_Click(object sender, EventArgs e)
        {
            if (imagenOriginalZoom.Image != null)
            {
                imgSalidaBorde_1_1.Image = Bordes.aplicarBorde_Derivada_X(imagenOriginalZoom.Image, chkBorde_1.Checked);
                imgSalidaBorde_1_2.Image = Bordes.aplicarBorde_Derivada_Y(imagenOriginalZoom.Image, chkBorde_1.Checked);
                imgSalidaBorde_1_3.Image = Bordes.aplicarBorde_Diagonal_1(imagenOriginalZoom.Image, chkBorde_1.Checked);
                imgSalidaBorde_1_4.Image = Bordes.aplicarBorde_Diagonal_2(imagenOriginalZoom.Image, chkBorde_1.Checked);
            }
        }

        private void Bordes_2_Click(object sender, EventArgs e)
        {
            if (imagenOriginalZoom.Image != null)
            {
                imgSalidaBordes_2_1.Image = Bordes.aplicarBorde_Prewitt_X(imagenOriginalZoom.Image, chkBorde_2.Checked);
                imgSalidaBordes_2_2.Image = Bordes.aplicarBorde_Prewitt_Y(imagenOriginalZoom.Image, chkBorde_2.Checked);
                imgSalidaBordes_2_3.Image = Bordes.aplicarBorde_Scharr_X(imagenOriginalZoom.Image, chkBorde_2.Checked);
                imgSalidaBordes_2_4.Image = Bordes.aplicarBorde_Scharr_Y(imagenOriginalZoom.Image, chkBorde_2.Checked);
            }
        }

        private void Bordes_3_Click(object sender, EventArgs e)
        {
            if (imagenOriginalZoom.Image != null)
            {
                imgSalidaBordes_3_1.Image = Bordes.aplicarBorde_Sobel_X(imagenOriginalZoom.Image, chkBordes_3.Checked);
                imgSalidaBordes_3_2.Image = Bordes.aplicarBorde_Sobel_Y(imagenOriginalZoom.Image, chkBordes_3.Checked);
                imgSalidaBordes_3_3.Image = Bordes.aplicarBorde_Laplace_1(imagenOriginalZoom.Image, chkBordes_3.Checked);
                imgSalidaBordes_3_4.Image = Bordes.aplicarBorde_Laplace_2(imagenOriginalZoom.Image, chkBordes_3.Checked);
            }
        }

        private void MagGrad_Click(object sender, EventArgs e)
        {
            if (imagenOriginalZoom.Image != null)
            {
                imgSalidaMagGrad.Image = Bordes.aplicarMagGrad(imagenOriginalZoom.Image);
            }
        }

        private void Perfilado_Click(object sender, EventArgs e)
        {
            if (imagenOriginalZoom.Image != null)
            {
                imgPerfiladoSalida_1.Image = Bordes.aplicarPerfilado_Laplace_1(imagenOriginalZoom.Image,1,false);
                imgPerfiladoSalida_2.Image = Bordes.aplicarPerfilado_Laplace_2(imagenOriginalZoom.Image,false);
            }
        }

        private void imagenOriginalZoom_DoubleClick(object sender, EventArgs e)
        {
            Form imagen = new Form();
            PictureBox imagenOrigen = new PictureBox();
            PictureBox imagenAux = new PictureBox();
            imagenAux = (PictureBox)sender;
            imagenOrigen.Image = imagenAux.Image;
            imagen.Controls.Add(imagenOrigen);

            imagenOrigen.Left = 0;
            imagenOrigen.Top = 0;
            imagenOrigen.Width = imagenOrigen.Image.Width;
            imagenOrigen.Height = imagenOrigen.Image.Height;

            imagen.AutoScroll = true;
            imagen.ShowDialog();
        }

        private void imagenOriginalZoom_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var pictureBox = (PictureBox)sender;
                pictureBox.Location = new Point(pictureBox.Left + e.X, pictureBox.Top + e.Y);
            }
        }

        private void imagen_MouseUp(object sender, MouseEventArgs e)
        {
            ImageToSave = ((PictureBox)sender).Image;
            if (e.Button == MouseButtons.Right)
            {
                saveImageDialog.ShowDialog();
            }
        }
    }
}
