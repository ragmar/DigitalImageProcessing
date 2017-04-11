﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PruebaCS3
{
    public partial class Histogramas : Form
    {

        public Histogramas(long[] red, long[] green, long[] blue)
        {
            InitializeComponent();

            redH = new long[256];
            greenH = new long[256];
            blueH = new long[256];
            myValues = new long[256];
            red.CopyTo(redH, 0);
            green.CopyTo(greenH, 0);
            blue.CopyTo(blueH, 0);

            getMaxim();

            this.RepeatR.Text = this.RepeatR.Text + " " + MaxRed.ToString();
            this.ValueR.Text = this.ValueR.Text + " " + ValueRed.ToString();

            this.RepeatG.Text = this.RepeatG.Text + " " + MaxGreen.ToString();
            this.ValueG.Text = this.ValueG.Text + " " + ValueGreen.ToString();

            this.RepeatB.Text = this.RepeatB.Text + " " + MaxBlue.ToString();
            this.ValueB.Text = this.ValueB.Text + " " + ValueBlue.ToString();


            this.panelRed.Paint += new PaintEventHandler(rojo);

            this.panelGreen.Paint += new PaintEventHandler(verde);

            this.panelBlue.Paint += new PaintEventHandler(azul);

        }

        private void rojo(object sender, PaintEventArgs e)
        {
            redH.CopyTo(myValues, 0);
            myColor = Color.Red;
            if(limits)
                ComputeXYUnitValues(MaxRed);
            PintarHistograma(e);
        }

        private void verde(object sender, PaintEventArgs e)
        {
            greenH.CopyTo(myValues, 0);
            myColor = Color.Green;
            if (limits)
                ComputeXYUnitValues(MaxGreen);
            PintarHistograma(e);

        }

        private void azul(object sender, PaintEventArgs e)
        {
            blueH.CopyTo(myValues, 0);
            myColor = Color.Blue;
            if (limits)
                ComputeXYUnitValues(MaxBlue);
            PintarHistograma(e);
        }

        private void ShowL_Click(object sender, EventArgs e)
        {
            limits = true;
            this.panelRed.Refresh();
            this.panelGreen.Refresh();
            this.panelBlue.Refresh();
            
        }

        private void HideL_Click(object sender, EventArgs e)
        {
            limits = false;
            long maxR = 0, maxG = 0, maxB = 0;
            for (int i = 1; i < 255; i++)
            {
                if (maxR < redH[i])
                    maxR = redH[i];
                if (maxG < greenH[i])
                    maxG = greenH[i];
                if (maxB < blueH[i])
                    maxB = blueH[i];
            }
            ComputeXYUnitValues(maxR);
            this.panelRed.Refresh();
            ComputeXYUnitValues(maxG);
            this.panelGreen.Refresh();
            ComputeXYUnitValues(maxB);
            this.panelBlue.Refresh();
        }

        private void PintarHistograma(PaintEventArgs e)
        {
            int a;
            Graphics g = e.Graphics;
            Pen myPen = new Pen(new SolidBrush(myColor), myXUnit);

            if (limits) a = 0;
            else a = 1;
                g.DrawString(a.ToString(), myFont, new SolidBrush(myColor), new PointF(myOffset, this.panelRed.Height - myFont.Height), System.Drawing.StringFormat.GenericDefault);
                g.DrawString((myValues.Length - a -1).ToString(), myFont,
                new SolidBrush(myColor),
                new PointF(myOffset + (myValues.Length * myXUnit) - g.MeasureString((myValues.Length - 1).ToString(), myFont).Width,
                this.panelRed.Height - myFont.Height),
                System.Drawing.StringFormat.GenericDefault);
                for (; a < myValues.Length; ++a)
                {
                    g.DrawLine(myPen,
                        new PointF(myOffset + (a * myXUnit), this.panelRed.Height - myOffset),
                        new PointF(myOffset + (a * myXUnit), this.panelRed.Height - myOffset - myValues[a] * myYUnit));

                }
            
            
            g.DrawRectangle(new System.Drawing.Pen(new SolidBrush(Color.Black), 1), 0, 0, this.panelRed.Width - 1, this.panelRed.Height - 1);
        }


        private void getMaxim()
        {
            MaxRed = 0;
            MaxGreen = 0;
            MaxBlue = 0;
            ValueRed = 0;
            ValueGreen = 0;
            ValueBlue = 0;
            for (int i = 0; i < 256; i++)
            {
                if (redH[i] > MaxRed)
                {
                    MaxRed = redH[i];
                    ValueRed = i;
                }
                if (greenH[i] > MaxGreen)
                {
                    MaxGreen = greenH[i];
                    ValueGreen = i;
                }
                if (blueH[i] > MaxBlue)
                {
                    MaxBlue = blueH[i];
                    ValueBlue = i;
                }
            }
        }

        private void ComputeXYUnitValues(long max)
        {
            myMaxValue = max;
            myYUnit = (float)(this.panelRed.Height - (2 * myOffset)) / myMaxValue;
            myXUnit = (float)(this.panelRed.Width - (2 * myOffset)) / 255;
        }

        private bool limits = true;
        private long[] redH;
        private long[] greenH;
        private long[] blueH;
        private long MaxRed;
        private long MaxGreen;
        private long MaxBlue;
        private long ValueRed;
        private long ValueGreen;
        private long ValueBlue;
        private long myMaxValue;
        private long[] myValues;
        private float myYUnit;      
        private float myXUnit;     
        private int myOffset = 20; 
        private Color myColor;
        private Font myFont = new Font("Arial", 10);

        private void Ok_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
