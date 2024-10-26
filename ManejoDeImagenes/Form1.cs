using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;

namespace ManejoDeImagenes
{
    public partial class FormImagenes : Form
    {
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
            imagenAntesCorte.ImageLocation = DialogoAbrirImagen.FileName;
            imagenDespuesCorte.Image = null;
            imagenAntesCuant.ImageLocation = DialogoAbrirImagen.FileName;
            imagenDespuesCuant.Image = null;
            imagenColor.ImageLocation = DialogoAbrirImagen.FileName;
            imagenGrisLightness.Image = null;
            imagenGrisAverage.Image = null;
            imagenGrisLuminosity.Image = null;
            imagenColor.SizeMode = PictureBoxSizeMode.Zoom;
            imagenGrisLightness.SizeMode = PictureBoxSizeMode.Zoom;
            imagenGrisAverage.SizeMode = PictureBoxSizeMode.Zoom;
            imagenGrisLuminosity.SizeMode = PictureBoxSizeMode.Zoom;
            imgSepOrigen.ImageLocation = DialogoAbrirImagen.FileName;
            imgSep1.Image = null;
            imgSep2.Image = null;
            imgSep3.Image = null;
            imgSep4.Image = null;
            imgSep5.Image = null;
            imgSep6.Image = null;
            imgSep7.Image = null;
            imgSep8.Image = null;
            imgOrigenEstaganografia.ImageLocation = DialogoAbrirImagen.FileName;
            imgMensajeEstaganografia.Image = null;
            imgAntesOpUn.ImageLocation = DialogoAbrirImagen.FileName;
            imgUmbralBinarioAntes.ImageLocation = DialogoAbrirImagen.FileName;
            imgUmbralCorteAntes.ImageLocation = DialogoAbrirImagen.FileName;
            imagenUmbralesEscalonAntes.ImageLocation = DialogoAbrirImagen.FileName;
            imagenSumaResta1.ImageLocation = DialogoAbrirImagen.FileName;
            imagenMultiDiv1.ImageLocation = DialogoAbrirImagen.FileName;
            imagenBooleana1.ImageLocation = DialogoAbrirImagen.FileName;
            imagenComponentesConexas.ImageLocation = DialogoAbrirImagen.FileName;
            imagenHistograma.ImageLocation = DialogoAbrirImagen.FileName;
            imagenHistogramaEstiramientoOrigen.ImageLocation = DialogoAbrirImagen.FileName;
            imagenEqualizacionEntrada.ImageLocation = DialogoAbrirImagen.FileName;
            imgRuidoAnt.ImageLocation = DialogoAbrirImagen.FileName;
            imgFiltrosEntrada.ImageLocation = DialogoAbrirImagen.FileName;
            imgEntradaBordes_1.ImageLocation = DialogoAbrirImagen.FileName;
            imgEntradaBordes_2.ImageLocation = DialogoAbrirImagen.FileName;
            imgEntradaBordes_3.ImageLocation = DialogoAbrirImagen.FileName;
            imgEntradaMagGrad.ImageLocation = DialogoAbrirImagen.FileName;
            imgPerfiladoEntrada.ImageLocation = DialogoAbrirImagen.FileName;
        }

        private void bGenerarImagen_Click(object sender, EventArgs e)
        {
            if (imgAntesOpUn.Image != null)
            {
                imgDespuesOpUn.Image = OperacionesUnarias.aplicaOperaciones(imgAntesOpUn.Image, (int)suma1.Value, (int)suma2.Value, (int)suma3.Value, mult1.Value, mult2.Value, mult3.Value, div1.Value, div2.Value, div3.Value, gama1.Value, gama2.Value, gama3.Value);
            }
        }

        private void btCortar_Click(object sender, EventArgs e)
        {
            if (imagenDespuesCorte.Image != null)
            {
                imagenAntesCorte.Image = imagenDespuesCorte.Image;
            }
            if (imagenAntesCorte.Image != null)
            {
                imagenDespuesCorte.Image = Corte.cortarImagen(imagenAntesCorte.Image);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (imagenDespuesCorte.Image != null)
            {
                imagenAntesCorte.Image = imagenDespuesCorte.Image;
            }
            if (imagenAntesCorte.Image != null)
            {
                imagenDespuesCorte.Image = Corte.agrandarImagen(imagenAntesCorte.Image);
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (imagenAntesCuant.Image != null)
            {
                imagenDespuesCuant.Image = Cuantificacion.disminuirBytes(imagenAntesCuant.Image,(int)numericUpDown1.Value);
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (imagenColor.Image != null)
            {
                imagenGrisLightness.Image = Cuantificacion.escalaDeGrisesLightness(imagenColor.Image);
                imagenGrisAverage.Image = Cuantificacion.escalaDeGrisesAverage(imagenColor.Image);
                imagenGrisLuminosity.Image = Cuantificacion.escalaDeGrisesLuminosity(imagenColor.Image);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (imgSepOrigen.Image != null)
            {
                imgSep1.Image = Separar.bit_a_separar(imgSepOrigen.Image, 1);
                imgSep2.Image = Separar.bit_a_separar(imgSepOrigen.Image, 2);
                imgSep3.Image = Separar.bit_a_separar(imgSepOrigen.Image, 3);
                imgSep4.Image = Separar.bit_a_separar(imgSepOrigen.Image, 4);
                imgSep5.Image = Separar.bit_a_separar(imgSepOrigen.Image, 5);
                imgSep6.Image = Separar.bit_a_separar(imgSepOrigen.Image, 6);
                imgSep7.Image = Separar.bit_a_separar(imgSepOrigen.Image, 7);
                imgSep8.Image = Separar.bit_a_separar(imgSepOrigen.Image, 8);
            }
        }

        private void ocultarMensaje_Click(object sender, EventArgs e)
        {
            if( imgOrigenEstaganografia.Image != null)
            {
                imgMensajeEstaganografia.Image = Esteganografia.encriptar(imgOrigenEstaganografia.Image, imgAOcultar.Image);
            }
        }

        private void saveImageDialog_FileOk(object sender, CancelEventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    if (imagenDespuesCorte.Image != null)
                    {
                        imagenDespuesCorte.Image.Save(saveImageDialog.FileName);
                    }
                    break;
                case 2:
                    if (imagenGrisAverage.Image != null)
                    {
                        imagenGrisAverage.Image.Save(saveImageDialog.FileName);
                    }
                    break;
                case 4:
                    if (imgMensajeEstaganografia.Image != null)
                    {
                        imgMensajeEstaganografia.Image.Save(saveImageDialog.FileName);
                    }
                    break;
                case 6:
                    if (imgUmbralBinarioDespues.Image != null)
                    {
                        imgUmbralBinarioDespues.Image.Save(saveImageDialog.FileName);
                    }
                    break;
                case 11:
                    if (imagenBoolenaResultado.Image != null)
                    {
                        imagenBoolenaResultado.Image.Save(saveImageDialog.FileName,System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    break;
                case 16:
                    if (imgRuidoDes.Image != null)
                    {
                        imgRuidoDes.Image.Save(saveImageDialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    break;
                case 21:
                    if (imgSalidaMagGrad.Image != null)
                    {
                        imgSalidaMagGrad.Image.Save(saveImageDialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    break;
                default:
                    break;
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
            if (imgUmbralBinarioAntes.Image != null)
            {
                imgUmbralBinarioDespues.Image = OperacionesUnarias.umbralBinario(imgUmbralBinarioAntes.Image, umbralBinarioInferiorC1.Value, umbralBinarioInferiorC2.Value, umbralBinarioInferiorC3.Value, umbralBinarioSuperiorC1.Value, umbralBinarioSuperiorC2.Value, umbralBinarioSuperiorC3.Value, UmbralBinarioInverso.Checked);
            }
        }

        private void AplicarUmbralCorte_Click(object sender, EventArgs e)
        {
            if (imgUmbralCorteAntes.Image != null)
            {
                imgUmbralCorteDespues.Image = OperacionesUnarias.umbralCorte(imgUmbralCorteAntes.Image, umbralCorteInferiorC1.Value, umbralCorteInferiorC2.Value, umbralCorteInferiorC3.Value, umbralCorteSuperiorC1.Value, umbralCorteSuperiorC2.Value, umbralCorteSuperiorC3.Value, umbralCorteInverso.Checked, umbralCorteExtencion.Checked);
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
            if ((imagenSumaResta1.Image != null) && (imagenSumaResta2.Image != null))
            {
                imagenSumaRestaFinal.Image = Operaciones2Imagenes.suma_imagenes(imagenSumaResta1.Image, imagenSumaResta2.Image, txtPesoSuma1.Value, txtPesoSuma2.Value);
            }
        }

        private void btRestarImagenes_Click(object sender, EventArgs e)
        {
            if ((imagenSumaResta1.Image != null) && (imagenSumaResta2.Image != null))
            {
                imagenSumaRestaFinal.Image = Operaciones2Imagenes.resta_imagenes(imagenSumaResta1.Image, imagenSumaResta2.Image);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if ((imagenMultiDiv1.Image != null) && (imagenMultiDiv2.Image != null))
            {
                imagenMultiDivResultado.Image = Operaciones2Imagenes.multiplica_imagenes(imagenMultiDiv1.Image, imagenMultiDiv2.Image, txtPesoMultiDiv.Value);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
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
                if (imagenUmbralesEscalonAntes.Image != null)
                {
                    imagenUmbralesEscalonDespues.Image = OperacionesUnarias.umbralEscalon(imagenUmbralesEscalonAntes.Image, umbrales);
                }
            }
            catch (Exception)
            {
                
                
            }

        }

        private void btAND_Click(object sender, EventArgs e)
        {
            if ((imagenBooleana1.Image != null) && (imagenBooleana2.Image != null))
            {
                imagenBoolenaResultado.Image = Operaciones2Imagenes.AND_imagenes(imagenBooleana1.Image, imagenBooleana2.Image, chkNOT1.Checked);
            }
        }

        private void btOR_Click(object sender, EventArgs e)
        {
            if ((imagenBooleana1.Image != null) && (imagenBooleana2.Image != null))
            {
                imagenBoolenaResultado.Image = Operaciones2Imagenes.OR_imagenes(imagenBooleana1.Image, imagenBooleana2.Image, chkNOT1.Checked);
            }
        }

        private void btXOR_Click(object sender, EventArgs e)
        {
            if ((imagenBooleana1.Image != null) && (imagenBooleana2.Image != null))
            {
                imagenBoolenaResultado.Image = Operaciones2Imagenes.XOR_imagenes(imagenBooleana1.Image, imagenBooleana2.Image, chkNOT1.Checked);
            }
        }

        private void btHistograma_Click(object sender, EventArgs e)
        {
            if (imagenHistograma.Image != null)
            {
                controlHistogramas1.Canales = Histogramas.obten_histograma(imagenHistograma.Image);
                controlHistogramas1.GeneraHistograma();
            }
        }

        private void btEstirar_Click(object sender, EventArgs e)
        {
            if (imagenHistogramaEstiramientoOrigen.Image != null)
            {
                imagenHistogramaEstiramientoSalida.Image = Histogramas.estiramiento(imagenHistogramaEstiramientoOrigen.Image, (int)txtLimiteInferiorEstirar_1.Value, (int)txtLimiteInferiorEstirar_2.Value, (int)txtLimiteInferiorEstirar_3.Value, (int)txtLimiteSuperiorEstirar_1.Value, (int)txtLimiteSuperiorEstirar_2.Value, (int)txtLimiteSuperiorEstirar_3.Value);
                controlHistogramas_estiramiento_salida.Canales = Histogramas.obten_histograma(imagenHistogramaEstiramientoSalida.Image);
                controlHistogramas_estiramiento_salida.GeneraHistograma();
            }
        }

        private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl2.SelectedIndex == 1)
            {
                if (imagenHistogramaEstiramientoOrigen.Image != null)
                {
                    controlHistogramas_estiramiento_entrada.Canales = Histogramas.obten_histograma(imagenHistogramaEstiramientoOrigen.Image);
                    controlHistogramas_estiramiento_entrada.GeneraHistograma();
                }
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (imagenEqualizacionEntrada.Image != null)
            {
                imagenEqualizacionSalida.Image = Histogramas.aplica_equalizacion(imagenEqualizacionEntrada.Image, Histogramas.obten_equalizacion(Histogramas.obten_histograma(imagenEqualizacionEntrada.Image), imagenEqualizacionEntrada.Image.Width * imagenEqualizacionEntrada.Image.Height));
                controlHistogramasEqualizacion2.Canales = Histogramas.obten_histograma(imagenEqualizacionSalida.Image);
                controlHistogramasEqualizacion2.GeneraHistograma();
            }
        }

        private void tabControl4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl4.SelectedIndex == 1)
            {
                if (imagenEqualizacionEntrada.Image != null)
                {
                    controlHistogramasEqualizacion1.Canales = Histogramas.obten_histograma(imagenEqualizacionEntrada.Image);
                    controlHistogramasEqualizacion1.GeneraHistograma();
                }
            }
        }

        private void btComponentesConexas_Click(object sender, EventArgs e)
        {
            if (imagenComponentesConexas.Image != null)
            {
                int[,] componentes = Vecindad.obtenComponentesConexas(imagenComponentesConexas.Image);
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
            if (imgRuidoAnt.Image != null)
            {
                imgRuidoDes.Image = Ruido.aplicarRuido(imgRuidoAnt.Image, int.Parse(centroRuidoG.Text), decimal.Parse(sigmaRuidoG.Text), (int)RuidoGauss.Value, int.Parse(infRuidoU.Text), int.Parse(supRuidoU.Text), (int)RuidoNormal.Value, int.Parse(infRuidoSyP.Text), int.Parse(supRuidoSyP.Text), (int)RuidoSyP.Value);
            }
        }

        private void aplicaFiltro_Click(object sender, EventArgs e)
        {
            if (imgFiltrosEntrada.Image != null)
            {
                imgFiltrosSalida.Image = Filtros.aplicarFiltro(imgFiltrosEntrada.Image, filtro_seleccionado(GBfiltros), (int)tamano_mascara.Value, (double)sigma_filtro.Value, (int)T_filtro.Value);
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
            if (imgEntradaBordes_1.Image != null)
            {
                imgSalidaBorde_1_1.Image = Bordes.aplicarBorde_Derivada_X(imgEntradaBordes_1.Image, chkBorde_1.Checked);
                imgSalidaBorde_1_2.Image = Bordes.aplicarBorde_Derivada_Y(imgEntradaBordes_1.Image, chkBorde_1.Checked);
                imgSalidaBorde_1_3.Image = Bordes.aplicarBorde_Diagonal_1(imgEntradaBordes_1.Image, chkBorde_1.Checked);
                imgSalidaBorde_1_4.Image = Bordes.aplicarBorde_Diagonal_2(imgEntradaBordes_1.Image, chkBorde_1.Checked);
            }
        }

        private void Bordes_2_Click(object sender, EventArgs e)
        {
            if (imgEntradaBordes_2.Image != null)
            {
                imgSalidaBordes_2_1.Image = Bordes.aplicarBorde_Prewitt_X(imgEntradaBordes_2.Image, chkBorde_2.Checked);
                imgSalidaBordes_2_2.Image = Bordes.aplicarBorde_Prewitt_Y(imgEntradaBordes_2.Image, chkBorde_2.Checked);
                imgSalidaBordes_2_3.Image = Bordes.aplicarBorde_Scharr_X(imgEntradaBordes_2.Image, chkBorde_2.Checked);
                imgSalidaBordes_2_4.Image = Bordes.aplicarBorde_Scharr_Y(imgEntradaBordes_2.Image, chkBorde_2.Checked);
            }
        }

        private void Bordes_3_Click(object sender, EventArgs e)
        {
            if (imgEntradaBordes_3.Image != null)
            {
                imgSalidaBordes_3_1.Image = Bordes.aplicarBorde_Sobel_X(imgEntradaBordes_3.Image, chkBordes_3.Checked);
                imgSalidaBordes_3_2.Image = Bordes.aplicarBorde_Sobel_Y(imgEntradaBordes_3.Image, chkBordes_3.Checked);
                imgSalidaBordes_3_3.Image = Bordes.aplicarBorde_Laplace_1(imgEntradaBordes_3.Image, chkBordes_3.Checked);
                imgSalidaBordes_3_4.Image = Bordes.aplicarBorde_Laplace_2(imgEntradaBordes_3.Image, chkBordes_3.Checked);
            }
        }

        private void MagGrad_Click(object sender, EventArgs e)
        {
            if (imgEntradaMagGrad.Image != null)
            {
                imgSalidaMagGrad.Image = Bordes.aplicarMagGrad(imgEntradaMagGrad.Image);
            }
        }

        private void Perfilado_Click(object sender, EventArgs e)
        {
            if (imgPerfiladoEntrada.Image != null)
            {
                imgPerfiladoSalida_1.Image = Bordes.aplicarPerfilado_Laplace_1(imgPerfiladoEntrada.Image,1,false);
                imgPerfiladoSalida_2.Image = Bordes.aplicarPerfilado_Laplace_2(imgPerfiladoEntrada.Image,false);
            }
        }
    }
}
