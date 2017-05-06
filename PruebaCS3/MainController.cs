
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Drawing.Imaging;

namespace DigitalImageProcessing {

    /// <summary>
    /// Sets the limits of the window.
    /// </summary>
    public struct Limit
    {
        public int x1, y1, x2, y2;

        public Limit(int u1, int v1, int u2, int v2)
        {
            x1 = u1;
            y1 = v1;
            x2 = u2;
            y2 = v2;
        }
    }

    public class MainController {

        public MainController()
        {
            
        }

        /// <summary>
        /// Create a copy of an image to manipulate.
        /// </summary>
        /// <param name="temporalImage"></param>
        /// <returns></returns>
        public Bitmap createExteTemp(Bitmap temporalImage)
        {
            Bitmap extendedTemp = new Bitmap(temporalImage.Width + 6, temporalImage.Height + 6);
            for (int a = 0; a < extendedTemp.Width; ++a)
            {
                extendedTemp.SetPixel(a, 0, Color.Black);
                extendedTemp.SetPixel(a, 1, Color.Black);
                extendedTemp.SetPixel(a, 2, Color.Black);
                extendedTemp.SetPixel(a, extendedTemp.Height - 3, Color.Black);
                extendedTemp.SetPixel(a, extendedTemp.Height - 2, Color.Black);
                extendedTemp.SetPixel(a, extendedTemp.Height - 1, Color.Black);
            }
            for (int a = 0; a < extendedTemp.Height; ++a)
            {
                extendedTemp.SetPixel(0, a, Color.Black);
                extendedTemp.SetPixel(1, a, Color.Black);
                extendedTemp.SetPixel(2, a, Color.Black);
                extendedTemp.SetPixel(extendedTemp.Width - 3, a, Color.Black);
                extendedTemp.SetPixel(extendedTemp.Width - 2, a, Color.Black);
                extendedTemp.SetPixel(extendedTemp.Width - 1, a, Color.Black);
            }
            for (int a = 3; a < extendedTemp.Width - 3; ++a)
            {
                for (int b = 3; b < extendedTemp.Height - 3; ++b)
                {
                    extendedTemp.SetPixel(a, b, temporalImage.GetPixel(a - 3, b - 3));
                }
            }
            return extendedTemp;
        }

        public Bitmap applyAverTemp(Bitmap temporalImage, int matrixToUse)
        {
            Color c;
            int acumR, acumG, acumB, cont;
            Bitmap extendedTemp;
            extendedTemp = createExteTemp(temporalImage);
            cleanEE();
            binaryEE(matrixToUse);
            acumR = acumG = acumB = cont = 0;
            for (int a = 0; a < 7; ++a)
                for (int b = 0; b < 7; ++b)
                    if (eeM[a, b] == 255)
                        cont++;
            if (cont == 0)
                cont = 1;
            for (int a = 3; a < extendedTemp.Width - 3; ++a)
            {
                for (int b = 3; b < extendedTemp.Height - 3; ++b)
                {
                    acumR = acumG = acumB = 0;
                    if (eeM[2, 2] == 255) { c = extendedTemp.GetPixel(a - 1, b - 1); acumR += c.R; acumG += c.G; acumB += c.B; }
                    if (eeM[2, 3] == 255) { c = extendedTemp.GetPixel(a - 1, b); acumR += c.R; acumG += c.G; acumB += c.B; }
                    if (eeM[2, 4] == 255) { c = extendedTemp.GetPixel(a - 1, b + 1); acumR += c.R; acumG += c.G; acumB += c.B; }
                    if (eeM[3, 2] == 255) { c = extendedTemp.GetPixel(a, b - 1); acumR += c.R; acumG += c.G; acumB += c.B; }
                    if (eeM[3, 3] == 255) { c = extendedTemp.GetPixel(a, b); acumR += c.R; acumG += c.G; acumB += c.B; }
                    if (eeM[3, 4] == 255) { c = extendedTemp.GetPixel(a, b + 1); acumR += c.R; acumG += c.G; acumB += c.B; }
                    if (eeM[4, 2] == 255) { c = extendedTemp.GetPixel(a + 1, b - 1); acumR += c.R; acumG += c.G; acumB += c.B; }
                    if (eeM[4, 3] == 255) { c = extendedTemp.GetPixel(a + 1, b); acumR += c.R; acumG += c.G; acumB += c.B; }
                    if (eeM[4, 4] == 255) { c = extendedTemp.GetPixel(a + 1, b + 1); acumR += c.R; acumG += c.G; acumB += c.B; }
                    temporalImage.SetPixel(a - 3, b - 3, Color.FromArgb((int)(acumR / cont), (int)(acumG / cont), (int)(acumB / cont)));
                }
            }
            return temporalImage;
        }

        /// <summary>
        /// Add noise on Image
        /// </summary>
        /// <param name="OriginalImage"></param>
        /// <param name="Amount"></param>
        /// <returns></returns>
        public static Bitmap AddNoise(Bitmap OriginalImage, int Amount)
        {
            Bitmap NewBitmap = new Bitmap(OriginalImage.Width, OriginalImage.Height);
            Random TempRandom = new Random();
            for (int x = 0; x < NewBitmap.Width; ++x)
            {
                for (int y = 0; y < NewBitmap.Height; ++y)
                {
                    Color CurrentPixel = OriginalImage.GetPixel(x, y);
                    int R = CurrentPixel.R + TempRandom.Next(-Amount, Amount + 1);
                    int G = CurrentPixel.G + TempRandom.Next(-Amount, Amount + 1);
                    int B = CurrentPixel.B + TempRandom.Next(-Amount, Amount + 1);
                    R = R > 255 ? 255 : R;
                    R = R < 0 ? 0 : R;
                    G = G > 255 ? 255 : G;
                    G = G < 0 ? 0 : G;
                    B = B > 255 ? 255 : B;
                    B = B < 0 ? 0 : B;
                    Color TempValue = Color.FromArgb(R, G, B);
                    NewBitmap.SetPixel(x, y, TempValue);
                }
            }
            return NewBitmap;
        }

        /// <summary>
        /// Create a bitmap image
        /// </summary>
        /// <param name="sImageText"></param>
        /// <param name="letterSize"></param>
        /// <returns></returns>
        private Bitmap CreateBitmapImage(string sImageText, int letterSize)
        {
            Bitmap objBmpImage = new Bitmap(1, 1);

            int intWidth = 0;
            int intHeight = 0;

            // Create the Font object for the image text drawing.
            Font objFont = new Font("Arial", letterSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);

            // Create a graphics object to measure the text's width and height.
            Graphics objGraphics = Graphics.FromImage(objBmpImage);

            // This is where the bitmap size is determined.
            intWidth = (int)objGraphics.MeasureString(sImageText, objFont).Width;
            intHeight = (int)objGraphics.MeasureString(sImageText, objFont).Height;

            // Create the bmpImage again with the correct size for the text and font.
            objBmpImage = new Bitmap(objBmpImage, new Size(intWidth, intHeight));

            // Add the colors to the new bitmap.
            objGraphics = Graphics.FromImage(objBmpImage);

            // Set Background color
            objGraphics.Clear(Color.White);
            objGraphics.SmoothingMode = SmoothingMode.AntiAlias;
            objGraphics.TextRenderingHint = TextRenderingHint.AntiAlias;
            objGraphics.DrawString(sImageText, objFont, new SolidBrush(Color.FromArgb(0, 0, 0)), 0, 0);
            objGraphics.Flush();

            return (objBmpImage);
        }

        /// <summary>
        /// Add a Speech of the comic option.
        /// </summary>
        /// <param name="posX"></param>
        /// <param name="posY"></param>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        public bool speech(int posX, int posY, int m, int n, string p, int q)
        {
            Bitmap temp = (Bitmap)_currentBitmap;
            Bitmap bmap = (Bitmap)temp.Clone();
            Bitmap text = new Bitmap(1, 1);
            escaNoUniTemp(m, n);
            for (int a = posX; a < posX + m; ++a)
                for (int b = posY; b < posY + n; ++b)
                    if (_temporalBitmap.GetPixel(a - posX, b - posY) == Color.FromArgb(0, 0, 0) || _temporalBitmap.GetPixel(a - posX, b - posY) == Color.FromArgb(255, 255, 255))
                        bmap.SetPixel(a, b, _temporalBitmap.GetPixel(a - posX, b - posY));
            text = CreateBitmapImage(p, q);
            double valor;
            valor = 0.5;
            if (text.Width > ((int)(_temporalBitmap.Width * (1 - valor))) || text.Height > ((int)_temporalBitmap.Height * (1 - valor)))
                return false;
            for (int a = posX + ((int)((float)(text.Width) * valor)); a < posX + text.Width + ((int)((float)(text.Width) * valor)); ++a)
                for (int b = posY + ((int)((float)(text.Width) * valor)); b < posY + text.Height + ((int)((float)(text.Width) * valor)); ++b)
                    bmap.SetPixel(a, b, text.GetPixel(a - (posX + ((int)((float)(text.Width) * valor))), b - (posY + ((int)((float)(text.Width) * valor)))));
            _currentBitmap = (Bitmap)bmap.Clone();
            _originalBitmap = (Bitmap)bmap.Clone();
            return true;
        }


        public void escaNoUniTemp(int ancho, int alto)
        {
            Bitmap _bitmapAuxiliar = new Bitmap(ancho, alto);
            double fancho = ((double)_temporalBitmap.Width) / ((double)ancho);
            double falto = ((double)_temporalBitmap.Height) / ((double)alto);
            for (int a = 0; a < ancho; ++a)
            {
                for (int b = 0; b < alto; ++b)
                {
                    _bitmapAuxiliar.SetPixel(a, b, _temporalBitmap.GetPixel(((int)(a * fancho)), ((int)(b * falto))));
                }
            }
            _temporalBitmap = (Bitmap)_bitmapAuxiliar.Clone();
        }

        public void frame(int factor, int x1, int y1, int x2, int y2)
        {
            Bitmap temp = (Bitmap)_currentBitmap;
            Bitmap bmap = (Bitmap)temp.Clone();

            for (int a = x1; a < x2; ++a) {
                for (int b = y1; b < y1 + factor; ++b)
                {
                    bmap.SetPixel(a, b, Color.FromArgb(0, 0, 0));
                }
                for (int b = y2 - factor; b < y2; ++b)
                {
                    bmap.SetPixel(a, b, Color.FromArgb(0, 0, 0));
                }
            }

            for (int a = y1; a < y2; ++a)
            {
                for (int b = x1; b < x1 + factor; ++b)
                {
                    bmap.SetPixel(b, a, Color.FromArgb(0, 0, 0));
                }
                for (int b = x2 - factor; b < x2; ++b)
                {
                    bmap.SetPixel(b, a, Color.FromArgb(0, 0, 0));
                }
            }

            escaNoUniTemp(x2 - x1 - (2 * factor), y2 - y1 - (2 * factor));

            _temporalBitmap = AddNoise(_temporalBitmap, 50);
            _temporalBitmap = applyAverTemp(_temporalBitmap, 0);
            for(int a = x1 + factor; a < x2 - factor; ++a)
                for(int b = y1 + factor; b < y2 - factor; ++b)
                    bmap.SetPixel(a, b, _temporalBitmap.GetPixel(a - (x1 + factor), b - (y1 + factor)));

            _currentBitmap = (Bitmap)bmap.Clone();
            _originalBitmap = (Bitmap)bmap.Clone();
        }

        /// <summary>
        /// Create blank page for the comic option.
        /// </summary>
        /// <param name="m"></param>
        /// <param name="n"></param>
        public void createBlankPage(int m, int n)
        {
            Bitmap bmap = new Bitmap(m, n);
            for (int a = 0; a < m; ++a)
                for (int b = 0; b < n; ++b)
                    bmap.SetPixel(a, b, Color.FromArgb(255, 255, 255));
            _currentBitmap = (Bitmap)bmap.Clone();
            _originalBitmap = (Bitmap)bmap.Clone();
        }

        /// <summary>
        /// No Uniform Scale
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="position"></param>
        public void escaNoUniforme(int width, int height, int position)
        {
            Bitmap _bitmapAuxiliar = new Bitmap(width, height);
            double fancho = ((double)_bitmapBD[position].Width) / ((double)width);
            double falto = ((double)_bitmapBD[position].Height) / ((double)height);
            for (int a = 0; a < width; ++a)
            {
                for (int b = 0; b < height; ++b)
                {
                    _bitmapAuxiliar.SetPixel(a, b, _bitmapBD[position].GetPixel(((int)(a * fancho)), ((int)(b * falto))));
                }
            }
            _bitmapBD[position] = (Bitmap)_bitmapAuxiliar.Clone();
        }
        
        public void pintarSubImagen(int iniX, int iniY, int finX, int finY, int posicion)
        {
            for (int a = iniX; a < finX; ++a)
                for (int b = iniY; b < finY; ++b)
                    if (finX < _bitmapAux.Width && finY < _bitmapAux.Height)
                        _bitmapAux.SetPixel(a, b, _bitmapBD[posicion].GetPixel(a - iniX, b - iniY));
        }

        public int indice(int posX, int posY)
        {
            int posicion, limite;
            double diferencia, difAbs;
            diferencia = 255;
            posicion = 0;
            limite = promediosBD.Length;
            for (int a = 0; a < limite; ++a)
            {
                difAbs = Math.Abs(promediosSub[posX, posY] - promediosBD[a]);
                if (diferencia > difAbs)
                {
                    diferencia = difAbs;
                    posicion = a;
                }
            }
            return posicion;
        }

        /// <summary>
        /// Precalculous for Mosaic
        /// </summary>
        /// <param name="archivos"></param>
        /// <param name="newWidth"></param>
        /// <param name="newHeight"></param>
        public void generatePrecalculus(string[] files, int newWidth, int newHeight)
        {
            double red, green, blue, wXh;
            promediosBD = new double[files.Length];
            red = green = blue = 0.0;
            int archivosLength, bitmapAuxWidth, bitmapAuxHeight;
            archivosLength = files.Length;
            _bitmapBD = new Bitmap[files.Length];
            for (int a = 0; a < archivosLength; ++a)
            {
                _bitmapBD[a] = (Bitmap)Bitmap.FromFile(files[a]);
                escaNoUniforme(newWidth, newHeight, a);
                bitmapAuxWidth = _bitmapBD[a].Width;
                for (int b = 0; b < bitmapAuxWidth; ++b)
                {
                    bitmapAuxHeight = _bitmapBD[a].Height;
                    for (int c = 0; c < bitmapAuxHeight; ++c)
                    {
                        red += _bitmapBD[a].GetPixel(b, c).R;
                        green += _bitmapBD[a].GetPixel(b, c).G;
                        blue += _bitmapBD[a].GetPixel(b, c).B;
                    }
                }
                wXh = _bitmapBD[a].Width * _bitmapBD[a].Height;
                red /= wXh;
                green /= wXh;
                blue /= wXh;
                promediosBD[a] = (red + green + blue) / 3.0;
                Console.WriteLine("Iteration {0} done.", a);
            }
        }

        /// <summary>
        /// Mosaic Generator
        /// </summary>
        /// <param name="horizontal"></param>
        /// <param name="vertical"></param>
        public void generateMosaic(int horizontal, int vertical)
        {
            int posicion, currentBitmapWidth, currentBitmapHeight;
            sumaDeRs = new double[horizontal, vertical];
            sumaDeGs = new double[horizontal, vertical];
            sumaDeBs = new double[horizontal, vertical];
            promediosSub = new double[horizontal, vertical];
            int posX, posY, var1, var2;
            posX = posY = 0;
            currentBitmapWidth = _currentBitmap.Width;
            for (int a = 0; a < currentBitmapWidth; ++a)
            {
                if (a == 0)
                    posX = 0;
                var1 = (int)(currentBitmapWidth / horizontal);
                if (var1 == 0)
                    var1 = 1;
                if (a % var1 == 0 && a != 0 && posX < horizontal - 1)
                    posX++;
                currentBitmapHeight = _currentBitmap.Height;
                for (int b = 0; b < currentBitmapHeight; ++b)
                {
                    if (b == 0)
                        posY = 0;
                    var2 = (int)(currentBitmapHeight / vertical);
                    if (var2 == 0)
                        var2 = 1;
                    if (b % var2 == 0 && b != 0 && posY < vertical - 1)
                        posY++;
                    sumaDeRs[posX, posY] += _currentBitmap.GetPixel(a, b).R;
                    sumaDeGs[posX, posY] += _currentBitmap.GetPixel(a, b).G;
                    sumaDeBs[posX, posY] += _currentBitmap.GetPixel(a, b).B;
                }
            }
            _bitmapAux = new Bitmap(_bitmapBD[0].Width * horizontal, _bitmapBD[0].Height * vertical);
            for (int a = 0; a < horizontal; ++a)
            {
                for (int b = 0; b < vertical; ++b)
                {
                    sumaDeRs[a, b] /= ((_currentBitmap.Width / horizontal) * (_currentBitmap.Height / vertical));
                    sumaDeGs[a, b] /= ((_currentBitmap.Width / horizontal) * (_currentBitmap.Height / vertical));
                    sumaDeBs[a, b] /= ((_currentBitmap.Width / horizontal) * (_currentBitmap.Height / vertical));
                    promediosSub[a, b] = (sumaDeRs[a, b] + sumaDeGs[a, b] + sumaDeBs[a, b]) / 3.0;
                    posicion = indice(a, b);
                    pintarSubImagen(
                                    (_bitmapAux.Width / horizontal) * a,
                                    (_bitmapAux.Height / vertical) * b,
                                    ((_bitmapAux.Width / horizontal) * a) + (_bitmapAux.Width / horizontal),
                                    ((_bitmapAux.Height / vertical) * b) + (_bitmapAux.Height / vertical),
                                    posicion
                                    );
                    Console.WriteLine("Iteration ({0}, {1}) done.", a, b);
                }
            }
            _currentBitmap = (Bitmap)_bitmapAux.Clone();
            _originalBitmap = (Bitmap)_bitmapAux.Clone();
        }

        /// <summary>
        /// apply filter TopHat on the Bitmap
        /// </summary>
        /// <param name="matrixToUse"></param>
        /// <param name="which"></param>
        public void applyTopHat(int matrixToUse, int which)
        {
            Bitmap temp = (Bitmap)_currentBitmap;
            Bitmap bmap = (Bitmap)temp.Clone();
            int red, green, blue;
            red = green = blue = 0;
            if (which == 0)
            {
                for (int a = 3; a < _extended.Width - 3; ++a)
                {
                    for (int b = 3; b < _extended.Height - 3; ++b)
                    {
                        red = _copy.GetPixel(a - 3, b - 3).R - bmap.GetPixel(a - 3, b - 3).R;
                        green = _copy.GetPixel(a - 3, b - 3).G - bmap.GetPixel(a - 3, b - 3).G;
                        blue = _copy.GetPixel(a - 3, b - 3).B - bmap.GetPixel(a - 3, b - 3).B;
                        if (red < 0) red = 0;
                        if (red > 255) red = 255;
                        if (green < 0) green = 0;
                        if (green > 255) green = 255;
                        if (blue < 0) blue = 0;
                        if (blue > 255) blue = 255;
                        bmap.SetPixel(a - 3, b - 3, Color.FromArgb(red, green, blue));
                    }
                }
            }
            else
            {
                for (int a = 3; a < _extended.Width - 3; ++a)
                {
                    for (int b = 3; b < _extended.Height - 3; ++b)
                    {
                        red = bmap.GetPixel(a - 3, b - 3).R - _copy.GetPixel(a - 3, b - 3).R;
                        green = bmap.GetPixel(a - 3, b - 3).G - _copy.GetPixel(a - 3, b - 3).G;
                        blue = bmap.GetPixel(a - 3, b - 3).B - _copy.GetPixel(a - 3, b - 3).B;
                        if (red < 0) red = 0;
                        if (red > 255) red = 255;
                        if (green < 0) green = 0;
                        if (green > 255) green = 255;
                        if (blue < 0) blue = 0;
                        if (blue > 255) blue = 255;
                        bmap.SetPixel(a - 3, b - 3, Color.FromArgb(red, green, blue));
                    }
                }
            }
            _currentBitmap = (Bitmap)bmap.Clone();
            _originalBitmap = (Bitmap)bmap.Clone();
        }

        /// <summary>
        /// Create a copy in grayscale of the bitmap
        /// </summary>
        public void createGrayscaleCopy()
        {
            _copy = new Bitmap(_currentBitmap.Width, _currentBitmap.Height);
            Color c;
            for (int a = 3; a < _extended.Width - 3; ++a)
            {
                for (int b = 3; b < _extended.Height - 3; ++b)
                {
                    c = _currentBitmap.GetPixel(a - 3, b - 3);
                    byte gray = (byte)(.299 * c.R + .587 * c.G + .114 * c.B);
                    _copy.SetPixel(a - 3, b - 3, Color.FromArgb(gray, gray, gray));
                }
            }
        }

        /// <summary>
        /// Create a copy of the current Bitmap
        /// </summary>
        public void createCopy()
        {
            _copy = new Bitmap(_currentBitmap.Width, _currentBitmap.Height);
            int red, green, blue;
            red = green = blue = 0;
            for (int a = 3; a < _extended.Width - 3; ++a)
            {
                for (int b = 3; b < _extended.Height - 3; ++b)
                {
                    red = _currentBitmap.GetPixel(a - 3, b - 3).R;
                    green = _currentBitmap.GetPixel(a - 3, b - 3).G;
                    blue = _currentBitmap.GetPixel(a - 3, b - 3).B;
                    _copy.SetPixel(a - 3, b - 3, Color.FromArgb(red, green, blue));
                }
            }
        }

        /// <summary>
        /// Matrix of Laplace 8
        /// </summary>
        public void laplace8()
        {
            eeM[2, 2] = -1;
            eeM[2, 3] = -1;
            eeM[2, 4] = -1;
            eeM[3, 2] = -1;
            eeM[3, 3] = 8;
            eeM[3, 4] = -1;
            eeM[4, 2] = -1;
            eeM[4, 3] = -1;
            eeM[4, 4] = -1;
        }

        /// <summary>
        /// Matrix of laplace 4
        /// </summary>
        public void laplace4()
        {
            eeM[2, 2] = 0;
            eeM[2, 3] = -1;
            eeM[2, 4] = 0;
            eeM[3, 2] = -1;
            eeM[3, 3] = 4;
            eeM[3, 4] = -1;
            eeM[4, 2] = 0;
            eeM[4, 3] = -1;
            eeM[4, 4] = 0;
        }

        /// <summary>
        /// Apply filter Median on the bitmap
        /// </summary>
        /// <param name="matrixToUse"></param>
        public void applyMedian(int matrixToUse)
        {
            Color c;
            int acumR, acumG, acumB, cont;
            Bitmap temp = (Bitmap)_currentBitmap;
            Bitmap bmap = (Bitmap)temp.Clone();
            cleanEE();
            binaryEE(matrixToUse);
            acumR = acumG = acumB = cont = 0;
            for (int a = 0; a < 7; ++a)
                for (int b = 0; b < 7; ++b)
                    if (eeM[a, b] == 255)
                        cont++;
            if (cont == 0)
                cont = 1;
            for (int a = 3; a < _extended.Width - 3; ++a)
            {
                for (int b = 3; b < _extended.Height - 3; ++b)
                {
                    c = bubbly(a, b);
                    bmap.SetPixel(a - 3, b - 3, Color.FromArgb(c.R, c.G, c.B));
                }
            }
            _currentBitmap = (Bitmap)bmap.Clone();
            _originalBitmap = (Bitmap)bmap.Clone();
        }

        public Color bubbly(int i, int j)
        {
            Color c;
            int cont, contAux;
            c = Color.FromArgb(0, 0, 0);
            cont = contAux = 0;
            for (int a = 0; a < 7; ++a)
                for (int b = 0; b < 7; ++b)
                    if (eeM[a, b] == 255)
                        cont++;
            Color[] colors = new Color[cont];
            if (eeM[2, 2] == 255) { colors[contAux] = _extended.GetPixel(i - 1, j - 1); contAux++; }
            if (eeM[2, 3] == 255) { colors[contAux] = _extended.GetPixel(i - 1, j); contAux++; }
            if (eeM[2, 4] == 255) { colors[contAux] = _extended.GetPixel(i - 1, j + 1); contAux++; }
            if (eeM[3, 2] == 255) { colors[contAux] = _extended.GetPixel(i, j - 1); contAux++; }
            if (eeM[3, 3] == 255) { colors[contAux] = _extended.GetPixel(i, j); contAux++; }
            if (eeM[3, 4] == 255) { colors[contAux] = _extended.GetPixel(i, j + 1); contAux++; }
            if (eeM[4, 2] == 255) { colors[contAux] = _extended.GetPixel(i + 1, j - 1); contAux++; }
            if (eeM[4, 3] == 255) { colors[contAux] = _extended.GetPixel(i + 1, j); contAux++; }
            if (eeM[4, 4] == 255) { colors[contAux] = _extended.GetPixel(i + 1, j + 1); contAux++; }
            for (int a = 0; a < contAux; ++a)
                for (int b = 0; b < contAux; ++b)
                    if (colors[a].R + colors[a].G + colors[a].B > colors[b].R + colors[b].G + colors[b].B)
                    {
                        c = colors[a];
                        colors[a] = colors[b];
                        colors[b] = c;
                    }
            if (cont % 2 == 0)
                c = Color.FromArgb((colors[cont / 2].R + colors[cont / 2 + 1].R) / 2,
                                    (colors[cont / 2].G + colors[cont / 2 + 1].G) / 2,
                                    (colors[cont / 2].B + colors[cont / 2 + 1].B) / 2);
            else
                c = Color.FromArgb(colors[cont / 2].R,
                                    colors[cont / 2].G,
                                    colors[cont / 2].B);
            return c;
        }

        /// <summary>
        /// Apply filter Average on the bitmap
        /// </summary>
        /// <param name="matrixToUse"></param>
        public void applyAverage(int matrixToUse)
        {
            Color c;
            int acumR, acumG, acumB, cont;
            Bitmap temp = (Bitmap)_currentBitmap;
            Bitmap bmap = (Bitmap)temp.Clone();
            cleanEE();
            binaryEE(matrixToUse);
            acumR = acumG = acumB = cont = 0;
            for (int a = 0; a < 7; ++a)
                for (int b = 0; b < 7; ++b)
                    if (eeM[a, b] == 255)
                        cont++;
            if (cont == 0)
                cont = 1;
            for (int a = 3; a < _extended.Width - 3; ++a)
            {
                for (int b = 3; b < _extended.Height - 3; ++b)
                {
                    acumR = acumG = acumB = 0;
                    if (eeM[2, 2] == 255) { c = _extended.GetPixel(a - 1, b - 1); acumR += c.R; acumG += c.G; acumB += c.B; }
                    if (eeM[2, 3] == 255) { c = _extended.GetPixel(a - 1, b); acumR += c.R; acumG += c.G; acumB += c.B; }
                    if (eeM[2, 4] == 255) { c = _extended.GetPixel(a - 1, b + 1); acumR += c.R; acumG += c.G; acumB += c.B; }
                    if (eeM[3, 2] == 255) { c = _extended.GetPixel(a, b - 1); acumR += c.R; acumG += c.G; acumB += c.B; }
                    if (eeM[3, 3] == 255) { c = _extended.GetPixel(a, b); acumR += c.R; acumG += c.G; acumB += c.B; }
                    if (eeM[3, 4] == 255) { c = _extended.GetPixel(a, b + 1); acumR += c.R; acumG += c.G; acumB += c.B; }
                    if (eeM[4, 2] == 255) { c = _extended.GetPixel(a + 1, b - 1); acumR += c.R; acumG += c.G; acumB += c.B; }
                    if (eeM[4, 3] == 255) { c = _extended.GetPixel(a + 1, b); acumR += c.R; acumG += c.G; acumB += c.B; }
                    if (eeM[4, 4] == 255) { c = _extended.GetPixel(a + 1, b + 1); acumR += c.R; acumG += c.G; acumB += c.B; }
                    bmap.SetPixel(a - 3, b - 3, Color.FromArgb((int)(acumR / cont), (int)(acumG / cont), (int)(acumB / cont)));
                }
            }
            _currentBitmap = (Bitmap)bmap.Clone();
            _originalBitmap = (Bitmap)bmap.Clone();
        }

        /// <summary>
        /// Apply filter erosion on the bitmap
        /// </summary>
        /// <param name="matrixToUse"></param>
        public void applyErosion(int matrixToUse)
        {
            Bitmap temp = (Bitmap)_currentBitmap;
            Bitmap bmap = (Bitmap)temp.Clone();
            int x;
            int y;
            cleanEE();
            binaryEE(matrixToUse);
            for (int a = 3; a < _extended.Width - 3; ++a)
                for (int b = 3; b < _extended.Height - 3; ++b)
                    if (_extended.GetPixel(a, b).R == 255)
                    /* If the pixel is white, verify eeM can be in the image
                     If it can be, nothing has to be done
                     If i can't be, draw the elements of the eeM black in the image*/
                    {
                        if (
                            (eeM[2, 2] == 255 && _extended.GetPixel(a - 1, b - 1).R == 0) ||
                            (eeM[2, 3] == 255 && _extended.GetPixel(a - 1, b).R == 0) ||
                            (eeM[2, 4] == 255 && _extended.GetPixel(a - 1, b + 1).R == 0) ||
                            (eeM[3, 2] == 255 && _extended.GetPixel(a, b - 1).R == 0) ||
                            (eeM[3, 3] == 255 && _extended.GetPixel(a, b).R == 0) ||
                            (eeM[3, 4] == 255 && _extended.GetPixel(a, b + 1).R == 0) ||
                            (eeM[4, 2] == 255 && _extended.GetPixel(a + 1, b - 1).R == 0) ||
                            (eeM[4, 3] == 255 && _extended.GetPixel(a + 1, b).R == 0) ||
                            (eeM[4, 4] == 255 && _extended.GetPixel(a + 1, b + 1).R == 0)
                            )
                        {
                            x = a - 1 - 3;
                            y = b - 1 - 3;
                            if (eeM[2, 2] == 255 && 0 <= x && x < bmap.Width && 0 <= y && y < bmap.Height)
                                bmap.SetPixel(x, y, Color.FromArgb(0, 0, 0));
                            y = b - 3;
                            if (eeM[2, 3] == 255 && 0 <= x && x < bmap.Width && 0 <= y && y < bmap.Height)
                                bmap.SetPixel(x, y, Color.FromArgb(0, 0, 0));
                            y = b + 1 - 3;
                            if (eeM[2, 4] == 255 && 0 <= x && x < bmap.Width && 0 <= y && y < bmap.Height)
                                bmap.SetPixel(x, y, Color.FromArgb(0, 0, 0));
                            x = a - 3;
                            y = b - 1 - 3;
                            if (eeM[3, 2] == 255 && 0 <= x && x < bmap.Width && 0 <= y && y < bmap.Height)
                                bmap.SetPixel(x, y, Color.FromArgb(0, 0, 0));
                            y = b - 3;
                            if (eeM[3, 3] == 255 && 0 <= x && x < bmap.Width && 0 <= y && y < bmap.Height)
                                bmap.SetPixel(x, y, Color.FromArgb(0, 0, 0));
                            y = b + 1 - 3;
                            if (eeM[3, 4] == 255 && 0 <= x && x < bmap.Width && 0 <= y && y < bmap.Height)
                                bmap.SetPixel(x, y, Color.FromArgb(0, 0, 0));
                            x = a + 1 - 3;
                            y = b - 1 - 3;
                            if (eeM[4, 2] == 255 && 0 <= x && x < bmap.Width && 0 <= y && y < bmap.Height)
                                bmap.SetPixel(x, y, Color.FromArgb(0, 0, 0));
                            y = b - 3;
                            if (eeM[4, 3] == 255 && 0 <= x && x < bmap.Width && 0 <= y && y < bmap.Height)
                                bmap.SetPixel(x, y, Color.FromArgb(0, 0, 0));
                            y = b + 1 - 3;
                            if (eeM[4, 4] == 255 && 0 <= x && x < bmap.Width && 0 <= y && y < bmap.Height)
                                bmap.SetPixel(x, y, Color.FromArgb(0, 0, 0));
                        }
                    }
            _currentBitmap = (Bitmap)bmap.Clone();
            _originalBitmap = (Bitmap)bmap.Clone();
        }

        /// <summary>
        /// Apply filter dilatation on the image
        /// </summary>
        /// <param name="matrixToUse"></param>
        public void applyDilation(int matrixToUse)
        {
            Bitmap temp = (Bitmap)_currentBitmap;
            Bitmap bmap = (Bitmap)temp.Clone();
            int x;
            int y;
            cleanEE();
            binaryEE(matrixToUse);
            for (int a = 3; a < _extended.Width - 3; ++a)
                for (int b = 3; b < _extended.Height - 3; ++b)
                    if (_extended.GetPixel(a, b).R == 255) // If the pixel is white draw the elements of the eeM white in the image
                    {
                        x = a - 1 - 3;
                        y = b - 1 - 3;
                        if (eeM[2, 2] == 255 && 0 <= x && x < bmap.Width && 0 <= y && y < bmap.Height)
                            bmap.SetPixel(x, y, Color.FromArgb(255, 255, 255));
                        y = b - 3;
                        if (eeM[2, 3] == 255 && 0 <= x && x < bmap.Width && 0 <= y && y < bmap.Height)
                            bmap.SetPixel(x, y, Color.FromArgb(255, 255, 255));
                        y = b + 1 - 3;
                        if (eeM[2, 4] == 255 && 0 <= x && x < bmap.Width && 0 <= y && y < bmap.Height)
                            bmap.SetPixel(x, y, Color.FromArgb(255, 255, 255));
                        x = a - 3;
                        y = b - 1 - 3;
                        if (eeM[3, 2] == 255 && 0 <= x && x < bmap.Width && 0 <= y && y < bmap.Height)
                            bmap.SetPixel(x, y, Color.FromArgb(255, 255, 255));
                        y = b - 3;
                        if (eeM[3, 3] == 255 && 0 <= x && x < bmap.Width && 0 <= y && y < bmap.Height)
                            bmap.SetPixel(x, y, Color.FromArgb(255, 255, 255));
                        y = b + 1 - 3;
                        if (eeM[3, 4] == 255 && 0 <= x && x < bmap.Width && 0 <= y && y < bmap.Height)
                            bmap.SetPixel(x, y, Color.FromArgb(255, 255, 255));
                        x = a + 1 - 3;
                        y = b - 1 - 3;
                        if (eeM[4, 2] == 255 && 0 <= x && x < bmap.Width && 0 <= y && y < bmap.Height)
                            bmap.SetPixel(x, y, Color.FromArgb(255, 255, 255));
                        y = b - 3;
                        if (eeM[4, 3] == 255 && 0 <= x && x < bmap.Width && 0 <= y && y < bmap.Height)
                            bmap.SetPixel(x, y, Color.FromArgb(255, 255, 255));
                        y = b + 1 - 3;
                        if (eeM[4, 4] == 255 && 0 <= x && x < bmap.Width && 0 <= y && y < bmap.Height)
                            bmap.SetPixel(x, y, Color.FromArgb(255, 255, 255));
                    }
            _currentBitmap = (Bitmap)bmap.Clone();
            _originalBitmap = (Bitmap)bmap.Clone();
        }

        public void binaryEE(int matrixToUse)
        {
            if (matrixToUse == 0)
            {              // Matrix of ones
                eeM[2, 2] = 255;
                eeM[2, 3] = 255;
                eeM[2, 4] = 255;
                eeM[3, 2] = 255;
                eeM[3, 3] = 255;
                eeM[3, 4] = 255;
                eeM[4, 2] = 255;
                eeM[4, 3] = 255;
                eeM[4, 4] = 255;
            }
            else if (matrixToUse == 1)
            {       // Identity Matrix
                eeM[2, 2] = 255;
                eeM[3, 3] = 255;
                eeM[4, 4] = 255;
            }
            else if (matrixToUse == 2)
            {      // Cross Matrix
                eeM[2, 3] = 255;
                eeM[3, 2] = 255;
                eeM[3, 3] = 255;
                eeM[3, 4] = 255;
                eeM[4, 3] = 255;
            }
            else
            {   // X Matrix
                eeM[2, 2] = 255;
                eeM[2, 4] = 255;
                eeM[3, 3] = 255;
                eeM[4, 2] = 255;
                eeM[4, 4] = 255;
            }
        }

        /// <summary>
        /// Apply custom Matrix on current image
        /// </summary>
        public void applyCustomMatrix()
        {
            Bitmap temp = (Bitmap)_currentBitmap;
            Bitmap bmap = (Bitmap)temp.Clone();
            Color c;
            double red, green, blue;
            for (int a = 3; a < _extended.Width - 3; ++a)
            {
                for (int b = 3; b < _extended.Height - 3; ++b)
                {
                    c = bitmapEE(a, b, 2);
                    red = c.R;
                    green = c.G;
                    blue = c.B;
                    if (red < 0) red = 0;
                    if (red > 255) red = 255;
                    if (green < 0) green = 0;
                    if (green > 255) green = 255;
                    if (blue < 0) blue = 0;
                    if (blue > 255) blue = 255;
                    bmap.SetPixel(a - 3, b - 3, Color.FromArgb((int)red, (int)green, (int)blue));
                }
            }
            _currentBitmap = (Bitmap)bmap.Clone();
            _originalBitmap = (Bitmap)bmap.Clone();
        }

        public void prewittGYEE()
        {
            eeY[2, 2] = 1;
            eeY[2, 3] = 1;
            eeY[2, 4] = 1;
            eeY[4, 2] = -1;
            eeY[4, 3] = -1;
            eeY[4, 4] = -1;
        }

        public void prewittGXEE()
        {
            eeX[2, 2] = -1;
            eeX[3, 2] = -1;
            eeX[4, 2] = -1;
            eeX[2, 4] = 1;
            eeX[3, 4] = 1;
            eeX[4, 4] = 1;
        }

        public void robertsGYEE()
        {
            eeY[4, 3] = -1;
            eeY[3, 4] = 1;
        }

        public void robertsGXEE()
        {
            eeX[3, 3] = 1;
            eeX[4, 4] = -1;
        }

        /// <summary>
        /// Apply filet convolution on the current image
        /// </summary>
        /// <param name="mask"></param>
        public void applyConvolution(int mask)
        {
            Bitmap temp = (Bitmap)_currentBitmap;
            Bitmap bmap = (Bitmap)temp.Clone();
            Color c, cx, cy;
            double red, green, blue;
            red = green = blue = 0;
            cleanEE();
            if (mask == 0)
            {
                sobelGXEE();
                sobelGYEE();
            }
            else if (mask == 1)
            {
                robertsGXEE();
                robertsGYEE();
            }
            else if (mask == 2)
            {
                prewittGXEE();
                prewittGYEE();
            }
            else if (mask == 3)
            {
                laplace4();
            }
            else
            {
                laplace8();
            }
            for (int a = 3; a < _extended.Width - 3; ++a)
            {
                for (int b = 3; b < _extended.Height - 3; ++b)
                {
                    if(mask == 0 || mask == 1 || mask == 2) {
                        cx = bitmapEE(a, b, 0);
                        cy = bitmapEE(a, b, 1);
                        red = Math.Sqrt((double)(cx.R * cx.R + cy.R * cy.R));
                        green = Math.Sqrt((double)(cx.G * cx.G + cy.G * cy.G));
                        blue = Math.Sqrt((double)(cx.B * cx.B + cy.B * cy.B));
                    } else {
                        c = bitmapEE(a, b, 3);
                        red = c.R;
                        green = c.G;
                        blue = c.B;
                    }
                    if (red < 0) red = 0;
                    if (red > 255) red = 255;
                    if (green < 0) green = 0;
                    if (green > 255) green = 255;
                    if (blue < 0) blue = 0;
                    if (blue > 255) blue = 255;
                    bmap.SetPixel(a - 3, b - 3, Color.FromArgb((int)red, (int)green, (int)blue));
                }
            }
            _currentBitmap = (Bitmap)bmap.Clone();
            _originalBitmap = (Bitmap)bmap.Clone();
        }

        public void sobelGYEE()
        {
            eeY[2, 2] = -1;
            eeY[2, 3] = -2;
            eeY[2, 4] = -1;
            eeY[4, 2] = 1;
            eeY[4, 3] = 2;
            eeY[4, 4] = 1;
        }

        public void sobelGXEE()
        {
            eeX[2, 2] = -1;
            eeX[3, 2] = -2;
            eeX[4, 2] = -1;
            eeX[2, 4] = 1;
            eeX[3, 4] = 2;
            eeX[4, 4] = 1;
        }

        public Color bitmapEE(int i, int j, int NXY)
        {
            int red, green, blue;
            red = green = blue = 0;
            if(NXY == 0)
            {
                for (int p = i - 3; p <= i + 3; ++p)
                {
                    for (int q = j - 3; q <= j + 3; ++q)
                    {
                        if (eeX[(-1) * ((i - 3) - p), (-1) * ((j - 3) - q)] != 0)
                        {
                            red += eeX[(-1) * ((i - 3) - p), (-1) * ((j - 3) - q)] * _extended.GetPixel(p, q).R;
                            green += eeX[(-1) * ((i - 3) - p), (-1) * ((j - 3) - q)] * _extended.GetPixel(p, q).G;
                            blue += eeX[(-1) * ((i - 3) - p), (-1) * ((j - 3) - q)] * _extended.GetPixel(p, q).B;
                        }
                    }
                }
            }
            else if (NXY == 1)
            {
                for (int p = i - 3; p <= i + 3; ++p)
                {
                    for (int q = j - 3; q <= j + 3; ++q)
                    {
                        if (eeY[(-1) * ((i - 3) - p), (-1) * ((j - 3) - q)] != 0)
                        {
                            red += eeY[(-1) * ((i - 3) - p), (-1) * ((j - 3) - q)] * _extended.GetPixel(p, q).R;
                            green += eeY[(-1) * ((i - 3) - p), (-1) * ((j - 3) - q)] * _extended.GetPixel(p, q).G;
                            blue += eeY[(-1) * ((i - 3) - p), (-1) * ((j - 3) - q)] * _extended.GetPixel(p, q).B;
                        }
                    }
                }
            }
            else if (NXY == 2)
            {
                for (int p = i - 3; p <= i + 3; ++p)
                {
                    for (int q = j - 3; q <= j + 3; ++q)
                    {
                        if (eeC[(-1) * ((i - 3) - p), (-1) * ((j - 3) - q)] != 0)
                        {
                            red += eeC[(-1) * ((i - 3) - p), (-1) * ((j - 3) - q)] * _extended.GetPixel(p, q).R;
                            green += eeC[(-1) * ((i - 3) - p), (-1) * ((j - 3) - q)] * _extended.GetPixel(p, q).G;
                            blue += eeC[(-1) * ((i - 3) - p), (-1) * ((j - 3) - q)] * _extended.GetPixel(p, q).B;
                        }
                    }
                }
            }
            else
            {
                for (int p = i - 3; p <= i + 3; ++p)
                {
                    for (int q = j - 3; q <= j + 3; ++q)
                    {
                        if (eeM[(-1) * ((i - 3) - p), (-1) * ((j - 3) - q)] != 0)
                        {
                            red += eeM[(-1) * ((i - 3) - p), (-1) * ((j - 3) - q)] * _extended.GetPixel(p, q).R;
                            green += eeM[(-1) * ((i - 3) - p), (-1) * ((j - 3) - q)] * _extended.GetPixel(p, q).G;
                            blue += eeM[(-1) * ((i - 3) - p), (-1) * ((j - 3) - q)] * _extended.GetPixel(p, q).B;
                        }
                    }
                }
            }
            if (red < 0) red = 0;
            if (red > 255) red = 255;
            if (green < 0) green = 0;
            if (green > 255) green = 255;
            if (blue < 0) blue = 0;
            if (blue > 255) blue = 255;
            return Color.FromArgb(red, green, blue);
        }

        public void cleanEE()
        {
            for (int a = 0; a < 7; ++a)
            {
                for (int b = 0; b < 7; ++b)
                {
                    eeM[a, b] = 0;
                    eeX[a, b] = 0;
                    eeY[a, b] = 0;
                }
            }
        }

        /// <summary>
        /// Apply filter binarize on the current image
        /// </summary>
        public void binarize()
        {
            Bitmap temp = (Bitmap)_currentBitmap;
            Bitmap bmap = (Bitmap)temp.Clone();
            for (int a = 0; a < _currentBitmap.Width; ++a)
            {
                for (int b = 0; b < _currentBitmap.Height; ++b)
                {
                    if (((double)(_currentBitmap.GetPixel(a, b).R + _currentBitmap.GetPixel(a, b).G + _currentBitmap.GetPixel(a, b).B)) / 3.0f < 128.0f)
                        bmap.SetPixel(a, b, Color.Black);
                    else
                        bmap.SetPixel(a, b, Color.White);
                }
            }
            _currentBitmap = (Bitmap)bmap.Clone();
            _originalBitmap = (Bitmap)bmap.Clone();
        }

        public void createExtended()
        {
            _extended = new Bitmap(_currentBitmap.Width + 6, _currentBitmap.Height + 6);
            for (int a = 0; a < _extended.Width; ++a)
            {
                _extended.SetPixel(a, 0, Color.Black);
                _extended.SetPixel(a, 1, Color.Black);
                _extended.SetPixel(a, 2, Color.Black);
                _extended.SetPixel(a, _extended.Height - 3, Color.Black);
                _extended.SetPixel(a, _extended.Height - 2, Color.Black);
                _extended.SetPixel(a, _extended.Height - 1, Color.Black);
            }
            for (int a = 0; a < _extended.Height; ++a)
            {
                _extended.SetPixel(0, a, Color.Black);
                _extended.SetPixel(1, a, Color.Black);
                _extended.SetPixel(2, a, Color.Black);
                _extended.SetPixel(_extended.Width - 3, a, Color.Black);
                _extended.SetPixel(_extended.Width - 2, a, Color.Black);
                _extended.SetPixel(_extended.Width - 1, a, Color.Black);
            }
            for (int a = 3; a < _extended.Width - 3; ++a)
            {
                for (int b = 3; b < _extended.Height - 3; ++b)
                {
                    _extended.SetPixel(a, b, _currentBitmap.GetPixel(a - 3, b - 3));
                }
            }
        }

        public bool isBinary()
        {
            for (int a = 0; a < _currentBitmap.Width; ++a)
                for (int b = 0; b < _currentBitmap.Height; ++b)
                    if( !((_currentBitmap.GetPixel(a, b).R == 0 && _currentBitmap.GetPixel(a, b).G == 0 && _currentBitmap.GetPixel(a, b).B == 0) ||
                         (_currentBitmap.GetPixel(a, b).R == 255 && _currentBitmap.GetPixel(a, b).G == 255 && _currentBitmap.GetPixel(a, b).B == 255)))
                        return false;
            return true;
        }

        public void createEE()
        {
            eeM = new int[7, 7];
            eeC = new int[7, 7];
            eeX = new int[7, 7];
            eeY = new int[7, 7];
        }

        public void firstExtended()
        {
            _extended = new Bitmap(7, 7);
        }

        public void reiniciarEscalamiento()
        {
            escalamiento = 1.0;
        }

        public void reiniciarGrados()
        {
            grados = 0.0;
        }

        public Bitmap TemporalBitmap
        {
            get
            {
                if (_temporalBitmap == null)
                    _temporalBitmap = new Bitmap(1, 1);
                return _temporalBitmap;
            }
            set
            {
                _temporalBitmap = value;
            }
        }

        public Bitmap CurrentBitmap
        {
            get
            {
                if (_currentBitmap == null)
                    _currentBitmap = new Bitmap(1, 1);
                return _currentBitmap;
            }
            set
            {
                _currentBitmap = value;
            }
        }

        public Bitmap OriginalBitmap
        {
            get
            {
                if (_originalBitmap == null)
                    _originalBitmap = new Bitmap(1, 1);
                return _originalBitmap;
            }
            set
            {
                _originalBitmap = value;
            }
        }

        public string TemporalPath
        {
            get
            {
                return temporalPath;
            }
            set
            {
                temporalPath = value;
            }
        }

        public string BitmapPath
        {
            get {
                return bitmapPath;
            }
            set {
                bitmapPath = value;
            }
        }

        public void SaveBitmap(string saveFilePath) {
            bitmapPath = saveFilePath;
            if (System.IO.File.Exists(saveFilePath))
                System.IO.File.Delete(saveFilePath);
            _currentBitmap.Save(saveFilePath);
        }

        public void RestorePrevious() {
            _bitmapbeforeProcessing = _currentBitmap;
        }

        /// <summary>
        /// Get current histogram of the image
        /// </summary>
        public void GetHistogram()
        {
            System.Drawing.Bitmap picture = this.CurrentBitmap;
            System.Drawing.Color c;
            HashSet<Color> colors = new HashSet<Color>();
            for (int a = 0; a < picture.Size.Width; ++a)
            {
                for (int b = 0; b < picture.Size.Height; ++b)
                {
                    c = picture.GetPixel(a, b);
                    colors.Add(c);
                    redH[c.R]++;
                    greenH[c.G]++;
                    blueH[c.B]++;
                }
            }
            this.colors = colors.Count;

        }

        public void resetHistogram()
        {
            for (int i = 0; i < 256; i++)
            {
                redH[i] = 0;
                greenH[i] = 0;
                blueH[i] = 0;
            }
        }

        /// <summary>
        /// Apply filter Grayscale on current image
        /// </summary>
        public void setGrayscale()
        {
            Bitmap temp = (Bitmap)_currentBitmap;
            Bitmap bmap = (Bitmap)temp.Clone();
            Color c;
            resetHistogram();
            HashSet<Color> colors = new HashSet<Color>();
            for (int a = 0; a < bmap.Width; ++a)
            {
                for (int b = 0; b < bmap.Height; ++b)
                {
                    c = bmap.GetPixel(a, b);
                    byte gray = (byte)(.299 * c.R + .587 * c.G + .114 * c.B);
                    bmap.SetPixel(a, b, Color.FromArgb(gray, gray, gray));
                    colors.Add(Color.FromArgb(gray, gray, gray));
                    redH[gray]++;
                    greenH[gray]++;
                    blueH[gray]++;

                }
            }
            this.colors = colors.Count;
            _currentBitmap = (Bitmap)bmap.Clone();
            _originalBitmap = (Bitmap)bmap.Clone();
        }

        /// <summary>
        /// Apply filter Equialization on current image
        /// </summary>
        public void setEqualization()
        {
            float[] redH = new float[256];
            float[] greenH = new float[256];
            float[] blueH = new float[256];
            float[] cdfRedH = new float[256];
            float[] cdfGreenH = new float[256];
            float[] cdfBlueH = new float[256];
            float cdfMinR = 255;
            float cdfMinG = 255;
            float cdfMinB = 255;
            float acumR = 0;
            float acumG = 0;
            float acumB = 0;
            Bitmap temp = (Bitmap)_currentBitmap;
            Bitmap bmap = (Bitmap)temp.Clone();
            Color c;
            for (int a = 0; a < 256; ++a)
                redH[a] = greenH[a] = blueH[a] = cdfRedH[a] = cdfGreenH[a] = cdfBlueH[a] = 0;
           for (int a = 0; a < 256; ++a)
            {
                redH[a] = this.redH[a];
                greenH[a] = this.greenH[a];
                blueH[a] = this.blueH[a];
                if (redH[a] > 0 && a <cdfMinR)
                    cdfMinR = a;
                if (greenH[a] > 0 && a < cdfMinG)
                    cdfMinG = a;
                if (blueH[a] > 0 && a < cdfMinB)
                    cdfMinB = a;
                cdfRedH[a] = cdfGreenH[a] = cdfBlueH[a] = 0;
            }
            for (int a = 0; a < 256; ++a)
            {
                acumR += redH[a];
                cdfRedH[a] = acumR;
                acumG += greenH[a];
                cdfGreenH[a] = acumG;
                acumB += blueH[a];
                cdfBlueH[a] = acumB;
                redH[a] = (int)Math.Min(Math.Max((cdfRedH[a] - cdfMinR) / ((bmap.Width * bmap.Height) - cdfMinR) * (255), 0), 255);
                greenH[a] = (int)Math.Min(Math.Max((cdfGreenH[a] - cdfMinG) / ((bmap.Width * bmap.Height) - cdfMinG) * (255), 0), 255);
                blueH[a] = (int)Math.Min(Math.Max((cdfBlueH[a] - cdfMinB) / ((bmap.Width * bmap.Height) - cdfMinB) * (255), 0), 255);
            }
            resetHistogram();
            HashSet<Color> colors = new HashSet<Color>();
            for (int a = 0; a < bmap.Width; ++a)
                for (int b = 0; b < bmap.Height; ++b)
                {
                    c = bmap.GetPixel(a, b);
                    bmap.SetPixel(a, b, Color.FromArgb((int)redH[c.R], (int)greenH[c.G], (int)blueH[c.B]));
                    colors.Add(Color.FromArgb((int)redH[c.R], (int)greenH[c.G], (int)blueH[c.B]));
                    this.redH[(int)redH[c.R]]++;
                    this.greenH[(int)greenH[c.G]]++;
                    this.blueH[(int)blueH[c.B]]++;
                }
            this.colors = colors.Count;
            _currentBitmap = (Bitmap)bmap.Clone();
            _originalBitmap = (Bitmap)bmap.Clone();
        }

        /// <summary>
        /// Apply filter Contrast on current image
        /// </summary>
        /// <param name="minR"></param>
        /// <param name="maxR"></param>
        /// <param name="minG"></param>
        /// <param name="maxG"></param>
        /// <param name="minB"></param>
        /// <param name="maxB"></param>
        public void setContrast(int minR, int maxR, int minG, int maxG, int minB, int maxB)
        {
            Bitmap temp = (Bitmap)_currentBitmap;
            Bitmap bmap = (Bitmap)temp.Clone();
            int red, green, blue;
            resetHistogram();
            Color c;
            HashSet<Color> colors = new HashSet<Color>();
            for (int a = 0; a < bmap.Width; ++a)
                for (int b = 0; b < bmap.Height; ++b)
                {
                    c = bmap.GetPixel(a, b);
                    red = (int)Math.Min(Math.Max((float)255 * ((float)(c.R - minR) / (float)(maxR - minR)), 0), 255);
                    green = (int)Math.Min(Math.Max((float)255 * ((float)(c.G - minG) / (float)(maxG - minG)), 0), 255);
                    blue = (int)Math.Min(Math.Max((float)255 * ((float)(c.B - minB) / (float)(maxB - minB)), 0), 255);
                    bmap.SetPixel(a, b, Color.FromArgb(red, green, blue));
                    redH[red]++;
                    greenH[green]++;
                    blueH[blue]++;
                    colors.Add(Color.FromArgb(red, green, blue));
                }
            this.colors = colors.Count;
            _currentBitmap = (Bitmap)bmap.Clone();
            _originalBitmap = (Bitmap)bmap.Clone();
        }

        public Color interpolar(double x, double y) //  Up Scale interpolation
        {
            Color cv00, cv10, cv01, cv11, cr, cs, cp;
            int v00x, v00y, v01x, v01y, v10x, v10y, v11x, v11y;
            double tRx, tSx, rx, ry, sx, sy, tPy;
            v00x = (int)Math.Floor(x);
            v00y = (int)Math.Floor(y);
            v01x = v00x;
            v01y = v00y + 1;
            v10x = v00x + 1;
            v10y = v00y;
            v11x = v00x + 1;
            v11y = v00y + 1;
            if (v11x >= _currentBitmap.Width || v11y >= _currentBitmap.Height)
                return _currentBitmap.GetPixel(v00x, v00y);
            tRx = ((double)(x - v00x)) / ((double)(v10x - v00x));
            cv00 = _currentBitmap.GetPixel(v00x, v00y);
            cv10 = _currentBitmap.GetPixel(v10x, v10y);
            cr = Color.FromArgb((int)((1.0 - tRx) * ((double)cv00.R) + tRx * ((double)cv10.R)),
                                (int)((1.0 - tRx) * ((double)cv00.G) + tRx * ((double)cv10.G)),
                                (int)((1.0 - tRx) * ((double)cv00.B) + tRx * ((double)cv10.B)));
            tSx = ((double)(x - v01x)) / ((double)(v11x - v01x));
            cv01 = _currentBitmap.GetPixel(v01x, v01y);
            cv11 = _currentBitmap.GetPixel(v11x, v11y);
            cs = Color.FromArgb((int)((1.0 - tSx) * ((double)cv01.R) + tSx * ((double)cv11.R)),
                                (int)((1.0 - tSx) * ((double)cv01.G) + tSx * ((double)cv11.G)),
                                (int)((1.0 - tSx) * ((double)cv01.B) + tSx * ((double)cv11.B)));
            rx = x;
            ry = v00y;
            sx = x;
            sy = v01y;
            tPy = ((double)(y - ry)) / ((double)(sy - ry));
            cp = Color.FromArgb((int)((1.0 - tPy) * ((double)cr.R) + tPy * ((double)cs.R)),
                                (int)((1.0 - tPy) * ((double)cr.G) + tPy * ((double)cs.G)),
                                (int)((1.0 - tPy) * ((double)cr.B) + tPy * ((double)cs.B)));
            return cp;
        }

        /// <summary>
        /// Scale current image
        /// </summary>
        /// <param name="esca"></param>
        /// <param name="iterar"></param>
        public void scaleImage(double esca, bool iterar)
        {
            _currentBitmap = _originalBitmap;
            if (iterar)
                rotateAlfa(0, false);
            if (esca != -1.0)
                escalamiento = esca / 100;
            if (esca == 100)
                return;
            int w1 = _currentBitmap.Width;
            int h1 = _currentBitmap.Height;
            int w2 = (int)(((double)w1) * escalamiento);
            int h2 = (int)(((double)h1) * escalamiento);
            Bitmap bm = new Bitmap(w2, h2);
            double fx = ((double)w2) / ((double)w1);
            double fy = ((double)h2) / ((double)h1);
            if (escalamiento < 1)
            {
                matrixA = new int[w2, h2];
                matrixR = new int[w2, h2];
                matrixG = new int[w2, h2];
                matrixB = new int[w2, h2];
                Color c;
                for (int x = 0; x < w2; ++x)
                    for (int y = 0; y < h2; ++y)
                    {
                        matrixA[x, y] = matrixR[x, y] = matrixG[x, y] = matrixB[x, y] = 0;
                        bm.SetPixel(x, y, Color.Black);
                    }
                for (int x = 0; x < w1; ++x)
                    for (int y = 0; y < h1; ++y)
                    {
                        c = _currentBitmap.GetPixel(x, y);
                        matrixA[(int)(((double)x) * fx), (int)(((double)y) * fy)]++;
                        matrixR[(int)(((double)x) * fx), (int)(((double)y) * fy)] += c.R;
                        matrixG[(int)(((double)x) * fx), (int)(((double)y) * fy)] += c.G;
                        matrixB[(int)(((double)x) * fx), (int)(((double)y) * fy)] += c.B;
                    }
                for (int x = 0; x < w2; ++x)
                    for (int y = 0; y < h2; ++y)
                    {
                        matrixR[x, y] /= matrixA[x, y];
                        matrixG[x, y] /= matrixA[x, y];
                        matrixB[x, y] /= matrixA[x, y];
                        c = Color.FromArgb(matrixR[x, y], matrixG[x, y], matrixB[x, y]);
                        bm.SetPixel(x, y, c);
                    }
                _currentBitmap = (Bitmap)bm.Clone();
            }
            if (escalamiento > 1)
            {
                for (int x = 0; x < w2; ++x)
                    for (int y = 0; y < h2; ++y)
                        bm.SetPixel(x, y, interpolar(((double)x) / fx, ((double)y) / fy));
                _currentBitmap = (Bitmap)bm.Clone();
            }
        }

        /// <summary>
        /// Rotate current image
        /// </summary>
        /// <param name="alfa"></param>
        /// <param name="iterar"></param>
        public void rotateAlfa(double alfa, bool iterar)
        {
            Color c = Color.FromArgb(0, 0, 0);
            int tope;
            _currentBitmap = _originalBitmap;
            if (iterar)
                scaleImage(-1.0, false);
            grados += alfa;
            if (grados % 360 == 0 || grados % (-360) == 0)
            {
                grados = 0;
                return;
            }
            while (grados > 360)
                grados -= 360;
            while (grados < -360)
                grados += 360;
            if (grados < 0)
                grados = 360 + grados;
            if (grados == 90)
                tope = 1;
            else if (grados == 180)
                tope = 2;
            else
                tope = 3;
            if (grados == 90 || grados == 180 || grados == 270)
            {
                for (int z = 0; z < tope; z++)
                {
                    Bitmap bm1 = new Bitmap(_currentBitmap.Height, _currentBitmap.Width);
                    for (int a = 0; a < _currentBitmap.Height; ++a)
                    {
                        for (int b = 0; b < _currentBitmap.Width; ++b)
                        {
                            bm1.SetPixel(a, b, _currentBitmap.GetPixel(b, a));
                        }
                    }
                    Bitmap bm2 = new Bitmap(_currentBitmap.Height, _currentBitmap.Width);
                    for (int a = 0; a < _currentBitmap.Height; ++a)
                    {
                        for (int b = 0; b < _currentBitmap.Width; ++b)
                        {
                            if (a < _currentBitmap.Height - 1)
                                bm2.SetPixel(a, b, bm1.GetPixel(_currentBitmap.Height - 1 - a, b));
                            else
                                bm2.SetPixel(a, b, bm1.GetPixel(0, b));
                        }
                    }
                    _currentBitmap = (Bitmap)bm2.Clone();
                }
            }
            else
            {
                Bitmap bm = (Bitmap)_currentBitmap;
                Color supIzq, supDer, infIzq, infDer;
                double viejoAngulo, nuevoAngulo, distancia, anguloCoorPolar, xReal, yReal, deltaX, deltaY,
                        supR, supG, supB, infR, infG, infB;
                int x, y, xFloor, xCeiling, yFloor, yCeiling, red, green, blue,
                    viejoCX, viejoCY, nuevoCX, nuevoCY, width, height, xLength, yLength;
                viejoAngulo = 0;
                nuevoAngulo = (-1) * grados * Math.PI / 180;
                xLength = 1;
                yLength = 1;
                width = bm.Width;
                height = bm.Height;
                if ((0 <= grados && grados < 90) || (180 <= grados && grados < 270))
                {
                    viejoAngulo = (-1) * 90 * Math.PI / 180;
                    xLength = (int)Math.Abs(Math.Ceiling((bm.Width * Math.Cos(nuevoAngulo) + bm.Height * Math.Cos(viejoAngulo - nuevoAngulo))));
                    yLength = (int)Math.Abs(Math.Ceiling((bm.Width * Math.Sin(nuevoAngulo) + bm.Height * Math.Sin(viejoAngulo - nuevoAngulo))));
                }
                if ((90 <= grados && grados < 180) || (270 <= grados && grados < 360))
                {
                    viejoAngulo = (-1) * 270 * Math.PI / 180;
                    xLength = (int)Math.Abs(Math.Ceiling((bm.Width * Math.Cos(nuevoAngulo) + bm.Height * Math.Cos(viejoAngulo - nuevoAngulo))));
                    yLength = (int)Math.Abs(Math.Ceiling((bm.Width * Math.Sin(nuevoAngulo) + bm.Height * Math.Sin(viejoAngulo - nuevoAngulo))));
                }
                viejoCX = width / 2;
                viejoCY = height / 2;
                nuevoCX = xLength / 2;
                nuevoCY = yLength / 2;
                Bitmap bmBilinearInterpolation = new Bitmap(xLength, yLength);
                for (int a = 0; a < yLength; ++a)
                {
                    for (int b = 0; b < xLength; ++b)
                    {
                        bmBilinearInterpolation.SetPixel(b, a, c);
                    }
                }
                for (int a = 0; a < yLength; ++a)
                {
                    for (int b = 0; b < xLength; ++b)
                    {
                        x = b - nuevoCX;
                        y = nuevoCY - a;
                        distancia = Math.Sqrt(x * x + y * y);
                        anguloCoorPolar = 0.0;
                        if (x == 0)
                        {
                            if (y == 0)
                            {
                                bmBilinearInterpolation.SetPixel(b, a, bm.GetPixel(viejoCX, viejoCY));
                                continue;
                            }
                            else if (y < 0)
                            {
                                anguloCoorPolar = 1.5 * Math.PI;
                            }
                            else
                            {
                                anguloCoorPolar = 0.5 * Math.PI;
                            }
                        }
                        else
                        {
                            anguloCoorPolar = Math.Atan2((double)y, (double)x);
                        }
                        anguloCoorPolar -= nuevoAngulo;
                        xReal = distancia * Math.Cos(anguloCoorPolar);
                        yReal = distancia * Math.Sin(anguloCoorPolar);
                        xReal = xReal + (double)viejoCX;
                        yReal = (double)viejoCY - yReal;
                        xFloor = (int)(Math.Floor(xReal));
                        yFloor = (int)(Math.Floor(yReal));
                        xCeiling = (int)(Math.Ceiling(xReal));
                        yCeiling = (int)(Math.Ceiling(yReal));
                        if (xFloor < 0 || xCeiling < 0 || xFloor >= width || xCeiling >= width
                            || yFloor < 0 || yCeiling < 0 || yFloor >= height || yCeiling >= height)
                            continue;
                        deltaX = xReal - (double)xFloor;
                        deltaY = yReal - (double)yFloor;
                        supIzq = bm.GetPixel(xFloor, yFloor);
                        supDer = bm.GetPixel(xCeiling, yFloor);
                        infIzq = bm.GetPixel(xFloor, yCeiling);
                        infDer = bm.GetPixel(xCeiling, yCeiling);
                        supR = (1 - deltaX) * supIzq.R + deltaX * supDer.R;
                        supG = (1 - deltaX) * supIzq.G + deltaX * supDer.G;
                        supB = (1 - deltaX) * supIzq.B + deltaX * supDer.B;
                        infR = (1 - deltaX) * infIzq.R + deltaX * infDer.R;
                        infG = (1 - deltaX) * infIzq.G + deltaX * infDer.G;
                        infB = (1 - deltaX) * infIzq.B + deltaX * infDer.B;
                        red = (int)(Math.Round((1 - deltaY) * supR + deltaY * infR));
                        green = (int)(Math.Round((1 - deltaY) * supG + deltaY * infG));
                        blue = (int)(Math.Round((1 - deltaY) * supB + deltaY * infB));
                        if (red < 0)
                            red = 0;
                        if (red > 255)
                            red = 255;
                        if (green < 0)
                            green = 0;
                        if (green > 255)
                            green = 255;
                        if (blue < 0)
                            blue = 0;
                        if (blue > 255)
                            blue = 255;
                        bmBilinearInterpolation.SetPixel(b, a, Color.FromArgb(red, green, blue));
                    }
                }
                _currentBitmap = (Bitmap)bmBilinearInterpolation.Clone();
            }
        }

        private double escalamiento;
        private double grados;
        private string bitmapPath;
        private string temporalPath;
        private Bitmap _copy;
        private Bitmap _extended;
        private Bitmap _currentBitmap;
        private Bitmap _originalBitmap;
        private Bitmap _temporalBitmap;
        private Bitmap _bitmapbeforeProcessing;
        private Bitmap _bitmapAux;
        private Bitmap[] _bitmapBD;
        public double[] promediosBD;
        public double[,] sumaDeRs;
        public double[,] sumaDeGs;
        public double[,] sumaDeBs;
        public double[,] promediosSub;
        public long[] redH = new long[256];
        public long[] greenH = new long[256];
        public long[] blueH = new long[256];
        public long colors;
        public int[,] matrixA;
        public int[,] matrixR;
        public int[,] matrixG;
        public int[,] matrixB;
        public int[,] eeM;
        public int[,] eeC;
        public int[,] eeX;
        public int[,] eeY;
        public List<Limit> list_Limit;

    }

}
