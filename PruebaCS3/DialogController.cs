
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PruebaCS3 {

    public partial class DialogController : Form {

        public DialogController() {
            InitializeComponent();
            puedoTransformar = false;
            oDlg = new OpenFileDialog(); // Open Dialog Initialization
            oDlg.RestoreDirectory = true;
            oDlg.InitialDirectory = "C:\\";
            oDlg.FilterIndex = 1;
            oDlg.Filter = "jpg files (*.jpg)|*.jpg|jpeg files (*.jpeg)|*.jpeg|png files (*.png)|*.png|bmp files (*.bmp)|*.bmp";
            /*************************/
            sDlg = new SaveFileDialog(); // Save Dialog Initialization
            sDlg.RestoreDirectory = true;
            sDlg.InitialDirectory = "C:\\";
            sDlg.FilterIndex = 1;
            sDlg.Filter = "jpg files (*.jpg)|*.jpg|jpeg files (*.jpeg)|*.jpeg|png files (*.png)|*.png|bmp files (*.bmp)|*.bmp";
            imageHandler.crearEE();
            imageHandler.firstExtended();
            menuItemDilation.Enabled = menuItemErosion.Enabled = menuItemOpening.Enabled = menuItemClosing.Enabled = false;
            primeraVez = true;
            matrixToUse = 0;
            menuItemOnes.Checked = true;
            menuItemCustom3x3.Checked = true;
            menuItemPrecalculus.Enabled = false;
            menuItemMosaic.Enabled = false;
            menuItemFrame.Enabled = false;
            menuItemSpeech.Enabled = false;
            menuItemThought.Enabled = false;
            menuItemScream.Enabled = false;
            cantidad = 0;
            imageHandler.lim = new List<Limite>();
        }

        private static string[] GetFiles(string sourceFolder, string filters, System.IO.SearchOption searchOption)
        {
            return filters.Split('|').SelectMany(filter => System.IO.Directory.GetFiles(sourceFolder, filter, searchOption)).ToArray();
        }

        private void ImageProcessing_Paint(object sender, PaintEventArgs e) {
            Graphics g = e.Graphics;
            g.DrawImage(imageHandler.CurrentBitmap, new Rectangle(this.AutoScrollPosition.X, this.AutoScrollPosition.Y, Convert.ToInt32(imageHandler.CurrentBitmap.Width * zoomFactor), Convert.ToInt32(imageHandler.CurrentBitmap.Height * zoomFactor)));
        }

        private void initThings()
        {
            menuItemDilation.Enabled = menuItemErosion.Enabled = menuItemOpening.Enabled = menuItemClosing.Enabled = false;
            if (imageHandler.isBinary())
                menuItemDilation.Enabled = menuItemErosion.Enabled = menuItemOpening.Enabled = menuItemClosing.Enabled = true;
            imageHandler.createExtended();
        }

        private void menuItemOpen_Click(object sender, EventArgs e) {
            if (DialogResult.OK == oDlg.ShowDialog())
            {
                puedoTransformar = true;
                imageHandler.reiniciarEscalamiento();
                imageHandler.reiniciarGrados();
                imageHandler.CurrentBitmap = (Bitmap)Bitmap.FromFile(oDlg.FileName);
                imageHandler.OriginalBitmap = (Bitmap)Bitmap.FromFile(oDlg.FileName);
                imageHandler.BitmapPath = oDlg.FileName;
                imageOriginal.CurrentBitmap = imageHandler.CurrentBitmap;
                imageOriginal.BitmapPath = imageHandler.BitmapPath;
                this.AutoScroll = true;
                this.AutoScrollMinSize = new Size(Convert.ToInt32(imageHandler.CurrentBitmap.Width * zoomFactor), Convert.ToInt32(imageHandler.CurrentBitmap.Height * zoomFactor));
                this.Invalidate();
                imageHandler.resetHistogram();
                imageHandler.GetHistogram();
                imageHandler.redH.CopyTo(imageOriginal.redH, 0);
                imageHandler.greenH.CopyTo(imageOriginal.greenH, 0);
                imageHandler.blueH.CopyTo(imageOriginal.blueH, 0);
                menuItemDilation.Enabled = menuItemErosion.Enabled = menuItemOpening.Enabled = menuItemClosing.Enabled = false;
                initThings();
                primeraVez = false;
                menuItemPrecalculus.Enabled = true;
            }
        }

        private bool factorNoValido(int factor, int x1, int y1, int x2, int y2)
        {
            if (factor * 2 > x2 - x1 || factor * 2 > y2 - y1)
                return true;
            return false;
        }

        private bool insideFrames2(int x, int y, int m, int n)
        {
            for (int a = 0; a < imageHandler.lim.Count; ++a)
            {
                if (
                    ((imageHandler.lim.ElementAt(a).x1 <= x && x <= imageHandler.lim.ElementAt(a).x2) &&
                    (imageHandler.lim.ElementAt(a).y1 <= y && y <= imageHandler.lim.ElementAt(a).y2)) &&
                    ((imageHandler.lim.ElementAt(a).x1 <= x + m && x + m <= imageHandler.lim.ElementAt(a).x2) &&
                    (imageHandler.lim.ElementAt(a).y1 <= y && y <= imageHandler.lim.ElementAt(a).y2)) &&
                    ((imageHandler.lim.ElementAt(a).x1 <= x && x <= imageHandler.lim.ElementAt(a).x2) &&
                    (imageHandler.lim.ElementAt(a).y1 <= y + n && y + n <= imageHandler.lim.ElementAt(a).y2)) &&
                    ((imageHandler.lim.ElementAt(a).x1 <= x + m && x + m <= imageHandler.lim.ElementAt(a).x2) &&
                    (imageHandler.lim.ElementAt(a).y1 <= y + n && y + n <= imageHandler.lim.ElementAt(a).y2))
                    )
                    return true;
            }
            return false;
        }

        private bool insideFrames(int x1, int y1, int x2, int y2)
        {
            for (int a = 0; a < imageHandler.lim.Count; ++a)
            {
                if (
                    ((imageHandler.lim.ElementAt(a).x1 <= x1 && x1 <= imageHandler.lim.ElementAt(a).x2) &&
                    (imageHandler.lim.ElementAt(a).y1 <= y1 && y1 <= imageHandler.lim.ElementAt(a).y2)) ||
                    ((imageHandler.lim.ElementAt(a).x1 <= x2 && x2 <= imageHandler.lim.ElementAt(a).x2) &&
                    (imageHandler.lim.ElementAt(a).y1 <= y1 && y1 <= imageHandler.lim.ElementAt(a).y2)) ||
                    ((imageHandler.lim.ElementAt(a).x1 <= x1 && x1 <= imageHandler.lim.ElementAt(a).x2) &&
                    (imageHandler.lim.ElementAt(a).y1 <= y2 && y2 <= imageHandler.lim.ElementAt(a).y2)) ||
                    ((imageHandler.lim.ElementAt(a).x1 <= x2 && x2 <= imageHandler.lim.ElementAt(a).x2) &&
                    (imageHandler.lim.ElementAt(a).y1 <= y2 && y2 <= imageHandler.lim.ElementAt(a).y2))
                    )
                    return true;
            }
            return false;
        }

        private bool outsidePage2(int x, int y, int m, int n)
        {
            if (
                x + m >= imageHandler.CurrentBitmap.Width ||
                y + n >= imageHandler.CurrentBitmap.Width
                )
                return true;
            else
                return false;
        }

        private bool outsidePage(int x1, int y1, int x2, int y2)
        {
            if (
                x1 >= imageHandler.CurrentBitmap.Width ||
                x2 >= imageHandler.CurrentBitmap.Width ||
                y1 >= imageHandler.CurrentBitmap.Height ||
                y2 >= imageHandler.CurrentBitmap.Height
                )
                return true;
            else
                return false;
        }

        private void clickEvent(object sender, MouseEventArgs e)
        {
            int x1, y1, x2, y2, factor, m, n;
            string p;
            int q;
            bool entradaExitosa, outsideP, insideF, factorNoV, medidaApropiada;
            outsideP = insideF = factorNoV = false;
            x1 = y1 = x2 = y2 = 0;
            if (menuItemFrame.Checked)
            {
                if (e.Button == MouseButtons.Left && cantidad == 0)
                {
                    firstX = e.X;
                    firstY = e.Y;
                    cantidad = 1;
                }
                else if (e.Button == MouseButtons.Left && cantidad == 1)
                {
                    lastX = e.X;
                    lastY = e.Y;
                    cantidad = 0;
                    do
                    {
                        Dialog sc = new Dialog();
                        sc.textBoxFactor.Text = "10";
                        sc.ShowDialog();
                        factor = (int) sc.factor;
                        entradaExitosa = sc.entradaExitosa;
                        if (!entradaExitosa)
                            MessageBox.Show("An integer number between 1 and 1000 must be chosen", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    } while (!entradaExitosa);
                    if (DialogResult.OK == oDlg.ShowDialog())
                    {
                        imageHandler.TemporalBitmap = (Bitmap)Bitmap.FromFile(oDlg.FileName);
                        imageHandler.TemporalPath = oDlg.FileName;
                        this.Cursor = Cursors.WaitCursor;
                        imageHandler.RestorePrevious();
                        initThings();
                        if (firstX < lastX)
                        {
                            if (firstY < lastY)
                            {
                                x1 = firstX;
                                y1 = firstY;
                                x2 = lastX;
                                y2 = lastY;
                            }
                            else
                            {
                                x1 = firstX;
                                y1 = lastY;
                                x2 = lastX;
                                y2 = firstY;
                            }
                        }
                        else
                        {
                            if (firstY < lastY)
                            {
                                x1 = lastX;
                                y1 = firstY;
                                x2 = firstX;
                                y2 = lastY;
                            }
                            else
                            {
                                x1 = lastX;
                                y1 = lastY;
                                x2 = firstX;
                                y2 = firstY;
                            }
                        }
                        outsideP = outsidePage(x1, y1, x2, y2);
                        insideF = insideFrames(x1, y1, x2, y2);
                        factorNoV = factorNoValido(factor, x1, y1, x2, y2);
                        if (!outsideP && !insideF && !factorNoV)
                        {
                            imageHandler.frame(factor, x1, y1, x2, y2);
                            imageHandler.lim.Add(new Limite(x1, y1, x2, y2));
                        }
                        if (outsideP)
                            MessageBox.Show("Position outside the paper");
                        if (insideF)
                            MessageBox.Show("Position inside a frame");
                        if (factorNoV)
                            MessageBox.Show("Invalid factor");
                        this.Invalidate();
                        this.Cursor = Cursors.Default;
                    }
                }
            }
            if (menuItemSpeech.Checked || menuItemThought.Checked || menuItemScream.Checked)
            {
                cantidad = 0;
                if (e.Button == MouseButtons.Left)
                {
                    do
                    {
                        Dimensions dim = new Dimensions();
                        dim.textBoxM.Text = "40";
                        dim.textBoxN.Text = "20";
                        dim.ShowDialog();
                        m = (int)dim.factorM;
                        n = (int)dim.factorN;
                        entradaExitosa = dim.entradaExitosa;
                        if (!entradaExitosa)
                            MessageBox.Show("An integer number between 1 and 1000 must be chosen", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    } while (!entradaExitosa);
                    medidaApropiada = false;
                    do
                    {
                        do
                        {
                            Texto dim = new Texto();
                            dim.textBoxM.Text = "";
                            // Set the Multiline property to true.
                            dim.textBoxM.Multiline = true;
                            // Add vertical scroll bars to the TextBox control.
                            dim.textBoxM.ScrollBars = ScrollBars.Vertical;
                            // Allow the RETURN key to be entered in the TextBox control.
                            dim.textBoxM.AcceptsReturn = true;
                            // Allow the TAB key to be entered in the TextBox control.
                            dim.textBoxM.AcceptsTab = true;
                            // Set WordWrap to true to allow text to wrap to the next line.
                            dim.textBoxM.WordWrap = true;
                            dim.textBoxN.Text = "10";
                            dim.ShowDialog();
                            p = dim.textBoxM.Text;
                            q = (int)dim.factorN;
                            entradaExitosa = dim.entradaExitosa;
                            if (!entradaExitosa)
                                MessageBox.Show("An integer number between 1 and 1000 must be chosen", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        } while (!entradaExitosa);
                        string fileName;
                        fileName = "";
                        if(menuItemSpeech.Checked)
                            fileName = "Speech.png";
                        if(menuItemThought.Checked)
                            fileName = "Thought.png";
                        if(menuItemScream.Checked)
                            fileName = "Scream.png";
                        string fullPath;
                        fullPath = System.IO.Path.GetFullPath(fileName);
                        imageHandler.TemporalBitmap = (Bitmap)Bitmap.FromFile(fullPath);
                        imageHandler.TemporalPath = fullPath;
                        this.Cursor = Cursors.WaitCursor;
                        imageHandler.RestorePrevious();
                        initThings();
                        outsideP = outsidePage2(e.X, e.Y, m, n);
                        insideF = insideFrames2(e.X, e.Y, m, n);
                        if (!outsideP && insideF)
                        {
                            if(p.Equals(""))
                                p = " ";
                            medidaApropiada = imageHandler.speech(e.X, e.Y, m, n, p, q);
                            if (!medidaApropiada)
                                MessageBox.Show("Medidas inapropiadas");
                        }
                        this.Invalidate();
                        this.Cursor = Cursors.Default;
                        if (outsideP)
                        {
                            MessageBox.Show("Position outside the paper");
                            break;
                        }
                        if (!insideF)
                        {
                            MessageBox.Show("Position outside the frame");
                            break;
                        }
                    } while(!medidaApropiada);
                }
            }
        }

        private void menuItemReopen_Click(object sender, EventArgs e)
        {
            imageHandler.reiniciarEscalamiento();
            imageHandler.reiniciarGrados();
            if (!primeraVez)
            {
                imageHandler.CurrentBitmap = (Bitmap)Bitmap.FromFile(oDlg.FileName);
                imageHandler.OriginalBitmap = (Bitmap)Bitmap.FromFile(oDlg.FileName);
                imageHandler.CurrentBitmap = imageOriginal.CurrentBitmap;
                imageHandler.BitmapPath = imageOriginal.BitmapPath;
                imageOriginal.redH.CopyTo(imageHandler.redH, 0);
                imageOriginal.greenH.CopyTo(imageHandler.greenH, 0);
                imageOriginal.blueH.CopyTo(imageHandler.blueH, 0);
            }
            menuItemDilation.Enabled = menuItemErosion.Enabled = menuItemOpening.Enabled = menuItemClosing.Enabled = false;
            initThings();
            this.AutoScrollMinSize = new Size(Convert.ToInt32(imageHandler.CurrentBitmap.Width * zoomFactor), Convert.ToInt32(imageHandler.CurrentBitmap.Height * zoomFactor));
            this.Invalidate();
        }

        private void menuItemSave_Click(object sender, EventArgs e) {
            if (DialogResult.OK == sDlg.ShowDialog())
            {
                imageOriginal.CurrentBitmap = imageHandler.CurrentBitmap;
                imageOriginal.BitmapPath = imageHandler.BitmapPath;
                imageHandler.SaveBitmap(sDlg.FileName);
                if (mosai)
                {
                    initThings();
                }
                else {
                    mosai = true;
                }
            }
        }

        private void menuItemInfo_Click(object sender, EventArgs e)
        {
            initThings();
            Information info = new Information(imageHandler);
            info.Show();
        }

        private void menuItemHistograms_Click(object sender, EventArgs e)
        {
            initThings();
            Histogram Histo = new Histogram(imageHandler.redH,imageHandler.greenH,imageHandler.blueH);
            Histo.Show();
        }

        private void menuItemExit_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void menuItemGrayscale_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            imageHandler.RestorePrevious();
            initThings();
            imageHandler.setGrayscale();
            this.Invalidate();
            this.Cursor = Cursors.Default;
        }

        private void menuItemEqualization_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            imageHandler.RestorePrevious();
            initThings();
            imageHandler.setEqualization();
            this.Invalidate();
            this.Cursor = Cursors.Default;
        }

        private void menuItemContrast_Click(object sender, EventArgs e)
        {
            Contrast Contrast = new Contrast(imageHandler.redH, imageHandler.greenH, imageHandler.blueH);
            Contrast.ShowDialog();
            if (Contrast.acepto)
            {
                initThings();
                imageHandler.setContrast(Contrast.minR, Contrast.maxR, Contrast.minG, Contrast.maxG, Contrast.minB, Contrast.maxB);
                Contrast.acepto = false;
            }
            Contrast.Close();
            this.Invalidate();
        }

        private void menuItemBinarization_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            imageHandler.RestorePrevious();
            if (!imageHandler.isBinary())
            {
                initThings();
                imageHandler.binarize();
                imageHandler.createExtended();
            }
            menuItemDilation.Enabled = menuItemErosion.Enabled = menuItemOpening.Enabled = menuItemClosing.Enabled = true;
            this.Invalidate();
            this.Cursor = Cursors.Default;
        }

        private void menuItemPrecalculus_Click(object sender, EventArgs e)
        {
            MosaicDialog o1 = new MosaicDialog();
            o1.ShowDialog();
            this.Cursor = Cursors.WaitCursor;
            imageHandler.RestorePrevious();
            initThings();
            string[] archivos = GetFiles(o1.textBoxPath.Text, "*.jpg|*.jpeg|*.png|*.bmp", System.IO.SearchOption.TopDirectoryOnly);
            imageHandler.generatePrecalculus(archivos, (int)o1.numericW.Value, (int)o1.numericH.Value);
            menuItemMosaic.Enabled = true;
            this.Invalidate();
            this.Cursor = Cursors.Default;
        }

        private void menuItemMosaic_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            imageHandler.RestorePrevious();
            initThings();
            mosai = false;
            if (menuItemMosaic.Enabled)
                imageHandler.generateMosaic(100, 100);
            this.Invalidate();
            this.Cursor = Cursors.Default;
            this.AutoScrollMinSize = new Size(Convert.ToInt32(imageHandler.CurrentBitmap.Width * zoomFactor), Convert.ToInt32(imageHandler.CurrentBitmap.Height * zoomFactor));
        }

        private void menuItemOnes_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            imageHandler.RestorePrevious();
            initThings();
            menuItemOnes.Checked = true;
            menuItemIdentity.Checked = false;
            menuItemCross.Checked = false;
            menuItemX.Checked = false;
            matrixToUse = 0;
            this.Invalidate();
            this.Cursor = Cursors.Default;
        }

        private void menuItemIdentity_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            imageHandler.RestorePrevious();
            initThings();
            menuItemOnes.Checked = false;
            menuItemIdentity.Checked = true;
            menuItemCross.Checked = false;
            menuItemX.Checked = false;
            matrixToUse = 1;
            this.Invalidate();
            this.Cursor = Cursors.Default;
        }

        private void menuItemCross_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            imageHandler.RestorePrevious();
            initThings();
            menuItemOnes.Checked = false;
            menuItemIdentity.Checked = false;
            menuItemCross.Checked = true;
            menuItemX.Checked = false;
            matrixToUse = 2;
            this.Invalidate();
            this.Cursor = Cursors.Default;
        }

        private void menuItemX_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            imageHandler.RestorePrevious();
            initThings();
            menuItemOnes.Checked = false;
            menuItemIdentity.Checked = false;
            menuItemCross.Checked = false;
            menuItemX.Checked = true;
            matrixToUse = 3;
            this.Invalidate();
            this.Cursor = Cursors.Default;
        }

        private void menuItemCustom3x3_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            imageHandler.RestorePrevious();
            initThings();
            menuItemCustom3x3.Checked = true;
            menuItemCustom5x5.Checked = false;
            menuItemCustom7x7.Checked = false;
            bool pulsoAceptar;
            int c;
            int[] vectorEnviar = new int[9];
            do
            {
                ThreePerThree tpt = new ThreePerThree();
                tpt.ShowDialog();
                for (int a = 0; a < 9; ++a)
                    vectorEnviar[a] = (int)tpt.numericUpDown[a].Value;
                pulsoAceptar = tpt.pulsoAceptar;
                if (!pulsoAceptar)
                    MessageBox.Show("Please, chose the matriz to apply the convolution", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } while (!pulsoAceptar);
            for (int a = 0; a < 7; ++a)
            {
                for (int b = 0; b < 7; ++b)
                {
                    imageHandler.eeC[a, b] = 0;
                }
            }
            c = 0;
            for (int a = 2; a < 5; ++a)
            {
                for (int b = 2; b < 5; ++b)
                {
                    imageHandler.eeC[a, b] = vectorEnviar[c];
                    c++;
                }
            }
            this.Invalidate();
            this.Cursor = Cursors.Default;
        }

        private void menuItemCustom5x5_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            imageHandler.RestorePrevious();
            initThings();
            menuItemCustom3x3.Checked = false;
            menuItemCustom5x5.Checked = true;
            menuItemCustom7x7.Checked = false;
            bool pulsoAceptar;
            int c;
            int[] vectorEnviar = new int[25];
            do
            {
                CustomFivePerFive tpt = new CustomFivePerFive();
                tpt.ShowDialog();
                for (int a = 0; a < 25; ++a)
                    vectorEnviar[a] = (int)tpt.numericUpDown[a].Value;
                pulsoAceptar = tpt.pulsoAceptar;
                if (!pulsoAceptar)
                    MessageBox.Show("Please, chose the matriz to apply the convolution", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } while (!pulsoAceptar);
            for (int a = 0; a < 7; ++a)
            {
                for (int b = 0; b < 7; ++b)
                {
                    imageHandler.eeC[a, b] = 0;
                }
            }
            c = 0;
            for (int a = 1; a < 6; ++a)
            {
                for (int b = 1; b < 6; ++b)
                {
                    imageHandler.eeC[a, b] = vectorEnviar[c];
                    c++;
                }
            }
            this.Invalidate();
            this.Cursor = Cursors.Default;
        }

        private void menuItemCustom7x7_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            imageHandler.RestorePrevious();
            initThings();
            menuItemCustom3x3.Checked = false;
            menuItemCustom5x5.Checked = false;
            menuItemCustom7x7.Checked = true;
            bool pulsoAceptar;
            int c;
            int[] vectorEnviar = new int[49];
            do
            {
                CustomSevenPerSeven tpt = new CustomSevenPerSeven();
                tpt.ShowDialog();
                for (int a = 0; a < 49; ++a)
                    vectorEnviar[a] = (int)tpt.numericUpDown[a].Value;
                pulsoAceptar = tpt.pulsoAceptar;
                if (!pulsoAceptar)
                    MessageBox.Show("Please, chose the matriz to apply the convolution", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } while (!pulsoAceptar);
            for (int a = 0; a < 7; ++a)
            {
                for (int b = 0; b < 7; ++b)
                {
                    imageHandler.eeC[a, b] = 0;
                }
            }
            c = 0;
            for (int a = 0; a < 7; ++a)
            {
                for (int b = 0; b < 7; ++b)
                {
                    imageHandler.eeC[a, b] = vectorEnviar[c];
                    c++;
                }
            }
            this.Invalidate();
            this.Cursor = Cursors.Default;
        }

        private void menuItemSobel_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            imageHandler.RestorePrevious();
            initThings();
            imageHandler.applyConvolution(0);
            this.Invalidate();
            this.Cursor = Cursors.Default;
        }

        private void menuItemRoberts_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            imageHandler.RestorePrevious();
            initThings();
            imageHandler.applyConvolution(1);
            this.Invalidate();
            this.Cursor = Cursors.Default;
        }

        private void menuItemPrewitt_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            imageHandler.RestorePrevious();
            initThings();
            imageHandler.applyConvolution(2);
            this.Invalidate();
            this.Cursor = Cursors.Default;
        }

        private void menuItemAverage_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            imageHandler.RestorePrevious();
            initThings();
            imageHandler.applyAverage(matrixToUse);
            this.Invalidate();
            this.Cursor = Cursors.Default;
        }

        private void menuItemMedian_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            imageHandler.RestorePrevious();
            initThings();
            imageHandler.applyMedian(matrixToUse);
            this.Invalidate();
            this.Cursor = Cursors.Default;
        }

        private void menuItemLaplace4_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            imageHandler.RestorePrevious();
            initThings();
            imageHandler.applyConvolution(3);
            this.Invalidate();
            this.Cursor = Cursors.Default;
        }

        private void menuItemLaplace8_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            imageHandler.RestorePrevious();
            initThings();
            imageHandler.applyConvolution(4);
            this.Invalidate();
            this.Cursor = Cursors.Default;
        }

        private void menuItemDilation_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            imageHandler.RestorePrevious();
            initThings();
            imageHandler.applyDilation(matrixToUse);
            this.Invalidate();
            this.Cursor = Cursors.Default;
        }

        private void menuItemErosion_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            imageHandler.RestorePrevious();
            initThings();
            imageHandler.applyErosion(matrixToUse);
            this.Invalidate();
            this.Cursor = Cursors.Default;
        }

        private void menuItemOpening_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            imageHandler.RestorePrevious();
            initThings();
            imageHandler.applyErosion(matrixToUse);
            imageHandler.applyDilation(matrixToUse);
            this.Invalidate();
            this.Cursor = Cursors.Default;
        }

        private void menuItemClosing_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            imageHandler.RestorePrevious();
            initThings();
            imageHandler.applyDilation(matrixToUse);
            imageHandler.applyErosion(matrixToUse);
            this.Invalidate();
            this.Cursor = Cursors.Default;
        }

        private void menuItemWhiteTopHat_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            imageHandler.RestorePrevious();
            initThings();
            imageHandler.createGrayscaleCopy();
            imageHandler.binarize();
            imageHandler.applyDilation(matrixToUse);
            imageHandler.applyTopHat(matrixToUse, 0);
            this.Invalidate();
            this.Cursor = Cursors.Default;
        }

        private void menuItemBlackTopHat_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            imageHandler.RestorePrevious();
            initThings();
            imageHandler.createGrayscaleCopy();
            imageHandler.binarize();
            imageHandler.applyErosion(matrixToUse);
            imageHandler.applyTopHat(matrixToUse, 1);
            this.Invalidate();
            this.Cursor = Cursors.Default;
        }

        private void menuItemCreateBlankPage_Click(object sender, EventArgs e)
        {
            bool entradaExitosa;
            int m;
            int n;
            imageHandler.lim.Clear();
            do
            {
                Dimensions dim = new Dimensions();
                dim.textBoxM.Text = "600";
                dim.textBoxN.Text = "450";
                dim.ShowDialog();
                m = (int)dim.factorM;
                n = (int)dim.factorN;
                entradaExitosa = dim.entradaExitosa;
                if (!entradaExitosa)
                    MessageBox.Show("An integer number between 1 and 1000 must be chosen", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } while (!entradaExitosa);
            this.Cursor = Cursors.WaitCursor;
            imageHandler.RestorePrevious();
            imageHandler.createBlankPage(m, n);
            menuItemFrame.Enabled = true;
            menuItemSpeech.Enabled = true;
            menuItemThought.Enabled = true;
            menuItemScream.Enabled = true;
            menuItemFrame.Checked = true;
            menuItemSpeech.Checked = false;
            menuItemThought.Checked = false;
            menuItemScream.Checked = false;
            cantidad = 0;
            this.Invalidate();
            this.Cursor = Cursors.Default;
        }

        private void menuItemFrame_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            imageHandler.RestorePrevious();
            menuItemFrame.Checked = true;
            menuItemSpeech.Checked = false;
            menuItemThought.Checked = false;
            menuItemScream.Checked = false;
            this.Invalidate();
            this.Cursor = Cursors.Default;
        }

        private void menuItemSpeech_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            imageHandler.RestorePrevious();
            menuItemFrame.Checked = false;
            menuItemSpeech.Checked = true;
            menuItemThought.Checked = false;
            menuItemScream.Checked = false;
            this.Invalidate();
            this.Cursor = Cursors.Default;
        }

        private void menuItemThought_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            imageHandler.RestorePrevious();
            menuItemFrame.Checked = false;
            menuItemSpeech.Checked = false;
            menuItemThought.Checked = true;
            menuItemScream.Checked = false;
            this.Invalidate();
            this.Cursor = Cursors.Default;
        }

        private void menuItemScream_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            imageHandler.RestorePrevious();
            menuItemFrame.Checked = false;
            menuItemSpeech.Checked = false;
            menuItemThought.Checked = false;
            menuItemScream.Checked = true;
            this.Invalidate();
            this.Cursor = Cursors.Default;
        }

        private void menuItemACM_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            imageHandler.RestorePrevious();
            initThings();
            imageHandler.applyCustomMatrix();
            this.Invalidate();
            this.Cursor = Cursors.Default;
        }

        public Form IsFormAlreadyOpen(Type FormType)
        {
            foreach (Form OpenForm in Application.OpenForms)
            {
                if (OpenForm.GetType() == FormType)
                    return OpenForm;
            }

            return null;
        }

        private void menuItemScale_Click(object sender, EventArgs e) {
            double factor;
            bool entradaExitosa;
            do {
                Dialog sc = new Dialog();
                sc.textBoxFactor.Text = "100";
                sc.ShowDialog();
                factor = sc.factor;
                entradaExitosa = sc.entradaExitosa;
                if (!entradaExitosa)
                    MessageBox.Show("An integer number between 1 and 1000 must be chosen", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } while (!entradaExitosa);
            this.Cursor = Cursors.WaitCursor;
            imageHandler.RestorePrevious();
            if (puedoTransformar)
                imageHandler.scaleImage(factor, true);
            this.Invalidate();
            this.Cursor = Cursors.Default;
            this.AutoScrollMinSize = new Size(Convert.ToInt32(imageHandler.CurrentBitmap.Width * zoomFactor), Convert.ToInt32(imageHandler.CurrentBitmap.Height * zoomFactor));
            imageHandler.GetHistogram();
        }

        private void menuItemRotateCW_Click(object sender, EventArgs e) {
            double factor;
            bool entradaExitosa;
            do {
                Dialog sc = new Dialog();
                sc.textBoxFactor.Text = "360";
                sc.ShowDialog();
                factor = sc.factor;
                entradaExitosa = sc.entradaExitosa;
                if (!entradaExitosa)
                    MessageBox.Show("An integer number between 1 and 1000 must be chosen", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } while (!entradaExitosa);
            this.Cursor = Cursors.WaitCursor;
            imageHandler.RestorePrevious();
            if(puedoTransformar)
                imageHandler.rotateAlfa(factor, true);
            this.Invalidate();
            this.Cursor = Cursors.Default;
            this.AutoScrollMinSize = new Size(Convert.ToInt32(imageHandler.CurrentBitmap.Width * zoomFactor), Convert.ToInt32(imageHandler.CurrentBitmap.Height * zoomFactor));
            imageHandler.GetHistogram();
        }

        private void menuItemRotateCCW_Click(object sender, EventArgs e) {
            double factor;
            bool entradaExitosa;
            do {
                Dialog sc = new Dialog();
                sc.textBoxFactor.Text = "360";
                sc.ShowDialog();
                factor = sc.factor;
                entradaExitosa = sc.entradaExitosa;
                if (!entradaExitosa)
                    MessageBox.Show("An integer number between 1 and 1000 must be chosen", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } while (!entradaExitosa);
            this.Cursor = Cursors.WaitCursor;
            imageHandler.RestorePrevious();
            if(puedoTransformar)
                imageHandler.rotateAlfa((-1.0) * factor, true);
            this.Invalidate();
            this.Cursor = Cursors.Default;
            this.AutoScrollMinSize = new Size(Convert.ToInt32(imageHandler.CurrentBitmap.Width * zoomFactor), Convert.ToInt32(imageHandler.CurrentBitmap.Height * zoomFactor));
            imageHandler.GetHistogram();
        }

        OpenFileDialog oDlg;
        SaveFileDialog sDlg;
        bool primeraVez;
        bool puedoTransformar;
        bool mosai = true;
        double zoomFactor = 1.0;
        int matrixToUse;
        int firstX;
        int firstY;
        int lastX;
        int lastY;
        int cantidad;
        Manejador imageHandler = new Manejador();
        Manejador imageOriginal = new Manejador();

    }

}
