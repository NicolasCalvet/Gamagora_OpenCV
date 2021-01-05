﻿using System;

using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using Emgu.CV.Util;

namespace TP1_EmguCV {
    class Program {
        static void Main(string[] args) {

            Exercice3();

        }

        static void Exercice3() {

            String window = "TP1";
            CvInvoke.NamedWindow(window);

            Mat matWebcam = new Mat("..\\..\\..\\..\\images\\crochet.jpg"); //Because it is located in directory "netcoreapp3.1"

            Image<Bgr, Byte> baseImg = matWebcam.ToImage<Bgr, Byte>();
            Image<Gray, Byte> grayScaleBaseImg = matWebcam.ToImage<Gray, Byte>();
            Image<Hsv, Byte> hsvScaleBaseImg = matWebcam.ToImage<Hsv, Byte>();

            Image<Bgr, Byte> resultImage = new Image<Bgr, byte>(baseImg.Width * 3, baseImg.Height);

            CopyToImage(ref baseImg, ref resultImage, 0, 0);
            CopyToImage(ref grayScaleBaseImg, ref resultImage, baseImg.Width, 0);
            GrayCopyChannelToImage(ref hsvScaleBaseImg, ref resultImage, baseImg.Width * 2, 0, 0);

            Mat matRes = resultImage.Mat;

            CvInvoke.Imshow(window, matRes);
            CvInvoke.WaitKey(0);  //Wait for the key pressing event
            CvInvoke.DestroyWindow(window); //Destroy the window if key is pressed

        }

        // BGR to BGR
        static void CopyToImage(ref Image<Bgr, Byte> inputImg, ref Image<Bgr, Byte> outputImg, int offsetX, int offsetY) {

            for (int i = 0; i < inputImg.Height; i++) {
                for (int j = 0; j < inputImg.Width; j++) {

                    outputImg.Data[i + offsetY, j + offsetX, 0] = inputImg.Data[i, j, 0];
                    outputImg.Data[i + offsetY, j + offsetX, 1] = inputImg.Data[i, j, 1];
                    outputImg.Data[i + offsetY, j + offsetX, 2] = inputImg.Data[i, j, 2];

                }
            }

        }

        // Gray to BGR
        static void CopyToImage(ref Image<Gray, Byte> inputImg, ref Image<Bgr, Byte> outputImg, int offsetX, int offsetY) {

            for (int i = 0; i < inputImg.Height; i++) {
                for (int j = 0; j < inputImg.Width; j++) {

                    outputImg.Data[i + offsetY, j + offsetX, 0] = inputImg.Data[i, j, 0];
                    outputImg.Data[i + offsetY, j + offsetX, 1] = inputImg.Data[i, j, 0];
                    outputImg.Data[i + offsetY, j + offsetX, 2] = inputImg.Data[i, j, 0];

                }
            }

        }

        // Gray to BGR
        static void GrayCopyChannelToImage(ref Image<Hsv, Byte> inputImg, ref Image<Bgr, Byte> outputImg, int offsetX, int offsetY, int channel) {

            for (int i = 0; i < inputImg.Height; i++) {
                for (int j = 0; j < inputImg.Width; j++) {

                    outputImg.Data[i + offsetY, j + offsetX, 0] = inputImg.Data[i, j, channel];
                    outputImg.Data[i + offsetY, j + offsetX, 1] = inputImg.Data[i, j, channel];
                    outputImg.Data[i + offsetY, j + offsetX, 2] = inputImg.Data[i, j, channel];

                }
            }

        }

    }
}
