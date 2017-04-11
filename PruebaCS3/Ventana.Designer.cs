
namespace PruebaCS3 {

    partial class Ventana {

        protected override void Dispose(bool disposing) {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            //this.components += new MouseEventHandler(zelda);
            this.mainMenuItem = new System.Windows.Forms.MainMenu(this.components);
            this.menuItemFile = new System.Windows.Forms.MenuItem();
            this.menuItemOpen = new System.Windows.Forms.MenuItem();
            this.menuItemReOpen = new System.Windows.Forms.MenuItem();
            this.menuItemSave = new System.Windows.Forms.MenuItem();
            this.menuItemExit = new System.Windows.Forms.MenuItem();
            this.menuItemShow = new System.Windows.Forms.MenuItem();
            this.menuItemInfo = new System.Windows.Forms.MenuItem();
            this.menuItemHistograms = new System.Windows.Forms.MenuItem();
            this.menuItemGenerate = new System.Windows.Forms.MenuItem();
            this.menuItemGrayscale = new System.Windows.Forms.MenuItem();
            this.menuItemEqualization = new System.Windows.Forms.MenuItem();
            this.menuItemContrast = new System.Windows.Forms.MenuItem();
            this.menuItemBinarization = new System.Windows.Forms.MenuItem();
            this.menuItemPrecalculus = new System.Windows.Forms.MenuItem();
            this.menuItemMosaic = new System.Windows.Forms.MenuItem();
            this.menuItemMorphology = new System.Windows.Forms.MenuItem();
            this.menuItemOnes = new System.Windows.Forms.MenuItem();
            this.menuItemIdentity = new System.Windows.Forms.MenuItem();
            this.menuItemCross = new System.Windows.Forms.MenuItem();
            this.menuItemX = new System.Windows.Forms.MenuItem();
            this.menuItemConvolution = new System.Windows.Forms.MenuItem();
            this.menuItemCustom3x3 = new System.Windows.Forms.MenuItem();
            this.menuItemCustom5x5 = new System.Windows.Forms.MenuItem();
            this.menuItemCustom7x7 = new System.Windows.Forms.MenuItem();
            this.menuItemApply = new System.Windows.Forms.MenuItem();
            this.menuItemSobel = new System.Windows.Forms.MenuItem();
            this.menuItemRoberts = new System.Windows.Forms.MenuItem();
            this.menuItemPrewitt = new System.Windows.Forms.MenuItem();
            this.menuItemAverage = new System.Windows.Forms.MenuItem();
            this.menuItemMedian = new System.Windows.Forms.MenuItem();
            this.menuItemLaplace4 = new System.Windows.Forms.MenuItem();
            this.menuItemLaplace8 = new System.Windows.Forms.MenuItem();
            this.menuItemDilation = new System.Windows.Forms.MenuItem();
            this.menuItemErosion = new System.Windows.Forms.MenuItem();
            this.menuItemOpening = new System.Windows.Forms.MenuItem();
            this.menuItemClosing = new System.Windows.Forms.MenuItem();
            this.menuItemWhiteTopHat = new System.Windows.Forms.MenuItem();
            this.menuItemBlackTopHat = new System.Windows.Forms.MenuItem();
            this.menuItemACM = new System.Windows.Forms.MenuItem();
            this.menuItemTransform = new System.Windows.Forms.MenuItem();
            this.menuItemScale = new System.Windows.Forms.MenuItem();
            this.menuItemRotateCW = new System.Windows.Forms.MenuItem();
            this.menuItemRotateCCW = new System.Windows.Forms.MenuItem();
            this.menuItemComic = new System.Windows.Forms.MenuItem();
            this.menuItemCreateBlankPage = new System.Windows.Forms.MenuItem();
            this.menuItemFrame = new System.Windows.Forms.MenuItem();
            this.menuItemSpeech = new System.Windows.Forms.MenuItem();
            this.menuItemThought = new System.Windows.Forms.MenuItem();
            this.menuItemScream = new System.Windows.Forms.MenuItem();
            this.SuspendLayout();
            // 
            // mainMenuItem
            // 
            this.mainMenuItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemFile,
            this.menuItemShow,
            this.menuItemGenerate,
            this.menuItemMorphology,
            this.menuItemConvolution,
            this.menuItemApply,
            this.menuItemTransform,
            this.menuItemComic});
            // 
            // menuItemFile
            // 
            this.menuItemFile.Index = 0;
            this.menuItemFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemOpen,
            this.menuItemReOpen,
            this.menuItemSave,
            this.menuItemExit});
            this.menuItemFile.Text = "&File";
            // 
            // menuItemOpen
            // 
            this.menuItemOpen.Index = 0;
            this.menuItemOpen.Text = "&Open";
            this.menuItemOpen.Click += new System.EventHandler(this.menuItemOpen_Click);
            // 
            // menuItemReOpen
            // 
            this.menuItemReOpen.Index = 1;
            this.menuItemReOpen.Text = "Reopen";
            this.menuItemReOpen.Click += new System.EventHandler(this.menuItemReopen_Click);
            // 
            // menuItemSave
            // 
            this.menuItemSave.Index = 2;
            this.menuItemSave.Text = "&Save";
            this.menuItemSave.Click += new System.EventHandler(this.menuItemSave_Click);
            // 
            // menuItemExit
            // 
            this.menuItemExit.Index = 3;
            this.menuItemExit.Text = "&Exit";
            this.menuItemExit.Click += new System.EventHandler(this.menuItemExit_Click);
            // 
            // menuItemShow
            // 
            this.menuItemShow.Index = 1;
            this.menuItemShow.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemInfo,
            this.menuItemHistograms});
            this.menuItemShow.Text = "&Show";
            // 
            // menuItemInfo
            // 
            this.menuItemInfo.Index = 0;
            this.menuItemInfo.Text = "&Info";
            this.menuItemInfo.Click += new System.EventHandler(this.menuItemInfo_Click);
            // 
            // menuItemHistograms
            // 
            this.menuItemHistograms.Index = 1;
            this.menuItemHistograms.Text = "&Histograms";
            this.menuItemHistograms.Click += new System.EventHandler(this.menuItemHistograms_Click);
            // 
            // menuItemGenerate
            // 
            this.menuItemGenerate.Index = 2;
            this.menuItemGenerate.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemGrayscale,
            this.menuItemEqualization,
            this.menuItemContrast,
            this.menuItemBinarization,
            this.menuItemPrecalculus,
            this.menuItemMosaic});
            this.menuItemGenerate.Text = "&Generate";
            // 
            // menuItemGrayscale
            // 
            this.menuItemGrayscale.Index = 0;
            this.menuItemGrayscale.Text = "&Grayscale";
            this.menuItemGrayscale.Click += new System.EventHandler(this.menuItemGrayscale_Click);
            // 
            // menuItemEqualization
            // 
            this.menuItemEqualization.Index = 1;
            this.menuItemEqualization.Text = "&Equalization";
            this.menuItemEqualization.Click += new System.EventHandler(this.menuItemEqualization_Click);
            // 
            // menuItemContrast
            // 
            this.menuItemContrast.Index = 2;
            this.menuItemContrast.Text = "&Contrast";
            this.menuItemContrast.Click += new System.EventHandler(this.menuItemContrast_Click);
            // 
            // menuItemBinarization
            // 
            this.menuItemBinarization.Index = 3;
            this.menuItemBinarization.Text = "&Binarization";
            this.menuItemBinarization.Click += new System.EventHandler(this.menuItemBinarization_Click);
            // 
            // menuItemPrecalculus
            // 
            this.menuItemPrecalculus.Index = 4;
            this.menuItemPrecalculus.Text = "&Precalculus";
            this.menuItemPrecalculus.Click += new System.EventHandler(this.menuItemPrecalculus_Click);
            // 
            // menuItemMosaic
            // 
            this.menuItemMosaic.Index = 5;
            this.menuItemMosaic.Text = "&Mosaic";
            this.menuItemMosaic.Click += new System.EventHandler(this.menuItemMosaic_Click);
            // 
            // menuItemMorphology
            // 
            this.menuItemMorphology.Index = 3;
            this.menuItemMorphology.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemOnes,
            this.menuItemIdentity,
            this.menuItemCross,
            this.menuItemX});
            this.menuItemMorphology.Text = "&Matrix for morphology";
            // 
            // menuItemOnes
            // 
            this.menuItemOnes.Index = 0;
            this.menuItemOnes.Text = "&Ones";
            this.menuItemOnes.Click += new System.EventHandler(this.menuItemOnes_Click);
            // 
            // menuItemIdentity
            // 
            this.menuItemIdentity.Index = 1;
            this.menuItemIdentity.Text = "&Identity";
            this.menuItemIdentity.Click += new System.EventHandler(this.menuItemIdentity_Click);
            // 
            // menuItemCross
            // 
            this.menuItemCross.Index = 2;
            this.menuItemCross.Text = "&Cross";
            this.menuItemCross.Click += new System.EventHandler(this.menuItemCross_Click);
            // 
            // menuItemX
            // 
            this.menuItemX.Index = 3;
            this.menuItemX.Text = "&X";
            this.menuItemX.Click += new System.EventHandler(this.menuItemX_Click);
            // 
            // menuItemConvolution
            // 
            this.menuItemConvolution.Index = 4;
            this.menuItemConvolution.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemCustom3x3,
            this.menuItemCustom5x5,
            this.menuItemCustom7x7});
            this.menuItemConvolution.Text = "&Matrix for convolution";
            // 
            // menuItemCustom3x3
            // 
            this.menuItemCustom3x3.Index = 0;
            this.menuItemCustom3x3.Text = "&Custom 3x3 ...";
            this.menuItemCustom3x3.Click += new System.EventHandler(this.menuItemCustom3x3_Click);
            // 
            // menuItemCustom5x5
            // 
            this.menuItemCustom5x5.Index = 1;
            this.menuItemCustom5x5.Text = "&Custom 5x5 ...";
            this.menuItemCustom5x5.Click += new System.EventHandler(this.menuItemCustom5x5_Click);
            // 
            // menuItemCustom7x7
            // 
            this.menuItemCustom7x7.Index = 2;
            this.menuItemCustom7x7.Text = "&Custom 7x7 ...";
            this.menuItemCustom7x7.Click += new System.EventHandler(this.menuItemCustom7x7_Click);
            // 
            // menuItemApply
            // 
            this.menuItemApply.Index = 5;
            this.menuItemApply.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemSobel,
            this.menuItemRoberts,
            this.menuItemPrewitt,
            this.menuItemAverage,
            this.menuItemMedian,
            this.menuItemLaplace4,
            this.menuItemLaplace8,
            this.menuItemDilation,
            this.menuItemErosion,
            this.menuItemOpening,
            this.menuItemClosing,
            this.menuItemWhiteTopHat,
            this.menuItemBlackTopHat,
            this.menuItemACM});
            this.menuItemApply.Text = "&Apply";
            // 
            // menuItemSobel
            // 
            this.menuItemSobel.Index = 0;
            this.menuItemSobel.Text = "&Sobel";
            this.menuItemSobel.Click += new System.EventHandler(this.menuItemSobel_Click);
            // 
            // menuItemRoberts
            // 
            this.menuItemRoberts.Index = 1;
            this.menuItemRoberts.Text = "&Roberts";
            this.menuItemRoberts.Click += new System.EventHandler(this.menuItemRoberts_Click);
            // 
            // menuItemPrewitt
            // 
            this.menuItemPrewitt.Index = 2;
            this.menuItemPrewitt.Text = "&Prewitt";
            this.menuItemPrewitt.Click += new System.EventHandler(this.menuItemPrewitt_Click);
            // 
            // menuItemAverage
            // 
            this.menuItemAverage.Index = 3;
            this.menuItemAverage.Text = "&Average";
            this.menuItemAverage.Click += new System.EventHandler(this.menuItemAverage_Click);
            // 
            // menuItemMedian
            // 
            this.menuItemMedian.Index = 4;
            this.menuItemMedian.Text = "&Median";
            this.menuItemMedian.Click += new System.EventHandler(this.menuItemMedian_Click);
            // 
            // menuItemLaplace4
            // 
            this.menuItemLaplace4.Index = 5;
            this.menuItemLaplace4.Text = "&Laplace 4";
            this.menuItemLaplace4.Click += new System.EventHandler(this.menuItemLaplace4_Click);
            // 
            // menuItemLaplace8
            // 
            this.menuItemLaplace8.Index = 6;
            this.menuItemLaplace8.Text = "&Laplace 8";
            this.menuItemLaplace8.Click += new System.EventHandler(this.menuItemLaplace8_Click);
            // 
            // menuItemDilation
            // 
            this.menuItemDilation.Index = 7;
            this.menuItemDilation.Text = "&Dilation";
            this.menuItemDilation.Click += new System.EventHandler(this.menuItemDilation_Click);
            // 
            // menuItemErosion
            // 
            this.menuItemErosion.Index = 8;
            this.menuItemErosion.Text = "&Erosion";
            this.menuItemErosion.Click += new System.EventHandler(this.menuItemErosion_Click);
            // 
            // menuItemOpening
            // 
            this.menuItemOpening.Index = 9;
            this.menuItemOpening.Text = "&Opening";
            this.menuItemOpening.Click += new System.EventHandler(this.menuItemOpening_Click);
            // 
            // menuItemClosing
            // 
            this.menuItemClosing.Index = 10;
            this.menuItemClosing.Text = "&Closing";
            this.menuItemClosing.Click += new System.EventHandler(this.menuItemClosing_Click);
            // 
            // menuItemWhiteTopHat
            // 
            this.menuItemWhiteTopHat.Index = 11;
            this.menuItemWhiteTopHat.Text = "&White Top Hat";
            this.menuItemWhiteTopHat.Click += new System.EventHandler(this.menuItemWhiteTopHat_Click);
            // 
            // menuItemBlackTopHat
            // 
            this.menuItemBlackTopHat.Index = 12;
            this.menuItemBlackTopHat.Text = "&Black Top Hat";
            this.menuItemBlackTopHat.Click += new System.EventHandler(this.menuItemBlackTopHat_Click);
            // 
            // menuItemACM
            // 
            this.menuItemACM.Index = 13;
            this.menuItemACM.Text = "&Apply Custom Matrix";
            this.menuItemACM.Click += new System.EventHandler(this.menuItemACM_Click);
            // 
            // menuItemTransform
            // 
            this.menuItemTransform.Index = 6;
            this.menuItemTransform.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemScale,
            this.menuItemRotateCW,
            this.menuItemRotateCCW});
            this.menuItemTransform.Text = "&Transform";
            // 
            // menuItemScale
            // 
            this.menuItemScale.Index = 0;
            this.menuItemScale.Text = "&Scale";
            this.menuItemScale.Click += new System.EventHandler(this.menuItemScale_Click);
            // 
            // menuItemRotateCW
            // 
            this.menuItemRotateCW.Index = 1;
            this.menuItemRotateCW.Text = "&RotateCW";
            this.menuItemRotateCW.Click += new System.EventHandler(this.menuItemRotateCW_Click);
            // 
            // menuItemRotateCCW
            // 
            this.menuItemRotateCCW.Index = 2;
            this.menuItemRotateCCW.Text = "&RotateCCW";
            this.menuItemRotateCCW.Click += new System.EventHandler(this.menuItemRotateCCW_Click);
            // 
            // menuItemComic
            // 
            this.menuItemComic.Index = 7;
            this.menuItemComic.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemCreateBlankPage,
            this.menuItemFrame,
            this.menuItemSpeech,
            this.menuItemThought,
            this.menuItemScream});
            this.menuItemComic.Text = "&Comic";
            // 
            // menuItemCreateBlankPage
            // 
            this.menuItemCreateBlankPage.Index = 0;
            this.menuItemCreateBlankPage.Text = "&CreateBlankPage";
            this.menuItemCreateBlankPage.Click += new System.EventHandler(this.menuItemCreateBlankPage_Click);
            // 
            // menuItemFrame
            // 
            this.menuItemFrame.Index = 1;
            this.menuItemFrame.Text = "&Frame";
            this.menuItemFrame.Click += new System.EventHandler(this.menuItemFrame_Click);
            // 
            // menuItemSpeech
            // 
            this.menuItemSpeech.Index = 2;
            this.menuItemSpeech.Text = "&Speech";
            this.menuItemSpeech.Click += new System.EventHandler(this.menuItemSpeech_Click);
            // 
            // menuItemThought
            // 
            this.menuItemThought.Index = 3;
            this.menuItemThought.Text = "&Thought";
            this.menuItemThought.Click += new System.EventHandler(this.menuItemThought_Click);
            // 
            // menuItemScream
            // 
            this.menuItemScream.Index = 4;
            this.menuItemScream.Text = "&Scream";
            this.menuItemScream.Click += new System.EventHandler(this.menuItemScream_Click);
            // 
            // Ventana
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(800, 580);
            this.Menu = this.mainMenuItem;
            this.Name = "Ventana";
            this.Text = "P.D.I. - Proyecto II - Alejandro Sans & Victor Felipe";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ImageProcessing_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.clickEvent);
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.MainMenu mainMenuItem;

        private System.Windows.Forms.MenuItem menuItemFile;
        private System.Windows.Forms.MenuItem menuItemOpen;
        private System.Windows.Forms.MenuItem menuItemReOpen;
        private System.Windows.Forms.MenuItem menuItemSave;
        private System.Windows.Forms.MenuItem menuItemExit;

        private System.Windows.Forms.MenuItem menuItemShow;
        private System.Windows.Forms.MenuItem menuItemInfo;
        private System.Windows.Forms.MenuItem menuItemHistograms;

        private System.Windows.Forms.MenuItem menuItemGenerate;
        private System.Windows.Forms.MenuItem menuItemGrayscale;
        private System.Windows.Forms.MenuItem menuItemEqualization;
        private System.Windows.Forms.MenuItem menuItemContrast;
        private System.Windows.Forms.MenuItem menuItemBinarization;
        private System.Windows.Forms.MenuItem menuItemPrecalculus;
        private System.Windows.Forms.MenuItem menuItemMosaic;

        private System.Windows.Forms.MenuItem menuItemMorphology;
        private System.Windows.Forms.MenuItem menuItemOnes;
        private System.Windows.Forms.MenuItem menuItemIdentity;
        private System.Windows.Forms.MenuItem menuItemCross;
        private System.Windows.Forms.MenuItem menuItemX;

        private System.Windows.Forms.MenuItem menuItemConvolution;
        private System.Windows.Forms.MenuItem menuItemCustom3x3;
        private System.Windows.Forms.MenuItem menuItemCustom5x5;
        private System.Windows.Forms.MenuItem menuItemCustom7x7;

        private System.Windows.Forms.MenuItem menuItemApply;

        private System.Windows.Forms.MenuItem menuItemSobel;
        private System.Windows.Forms.MenuItem menuItemRoberts;
        private System.Windows.Forms.MenuItem menuItemPrewitt;
        private System.Windows.Forms.MenuItem menuItemAverage;
        private System.Windows.Forms.MenuItem menuItemMedian;
        private System.Windows.Forms.MenuItem menuItemLaplace4;
        private System.Windows.Forms.MenuItem menuItemLaplace8;
        private System.Windows.Forms.MenuItem menuItemDilation;
        private System.Windows.Forms.MenuItem menuItemErosion;
        private System.Windows.Forms.MenuItem menuItemOpening;
        private System.Windows.Forms.MenuItem menuItemClosing;
        private System.Windows.Forms.MenuItem menuItemWhiteTopHat;
        private System.Windows.Forms.MenuItem menuItemBlackTopHat;
        private System.Windows.Forms.MenuItem menuItemACM;

        private System.Windows.Forms.MenuItem menuItemTransform;
        private System.Windows.Forms.MenuItem menuItemScale;
        private System.Windows.Forms.MenuItem menuItemRotateCW;
        private System.Windows.Forms.MenuItem menuItemRotateCCW;

        private System.Windows.Forms.MenuItem menuItemComic;
        private System.Windows.Forms.MenuItem menuItemCreateBlankPage;
        private System.Windows.Forms.MenuItem menuItemFrame;
        private System.Windows.Forms.MenuItem menuItemSpeech;
        private System.Windows.Forms.MenuItem menuItemThought;
        private System.Windows.Forms.MenuItem menuItemScream;

    }
}
