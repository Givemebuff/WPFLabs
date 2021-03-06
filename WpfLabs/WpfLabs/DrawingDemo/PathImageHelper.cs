﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfLabs.DrawingDemo
{
    public static class PathImageHelper
    {
        /// <summary>
        /// 矢量图片前景色
        /// </summary>
        public static readonly DependencyProperty ImageForegroundProperty = DependencyProperty.RegisterAttached(
            "ImageForeground", typeof(Brush), typeof(PathImageHelper), new PropertyMetadata(default(Brush), OnImageForegroundChanged));

        /// <summary>
        /// 矢量图片前景色
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static Brush GetImageForeground(DependencyObject obj)
        {
            return (Brush) obj.GetValue(ImageForegroundProperty);
        }

        /// <summary>
        /// 矢量图片前景色
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="value"></param>
        public static void SetImageForeground(DependencyObject obj, Brush value)
        {
            obj.SetValue(ImageForegroundProperty, value);
        }

        private static void OnImageForegroundChanged(DependencyObject dependencyObject,
            DependencyPropertyChangedEventArgs args)
        {
            var newBrush = (Brush) args.NewValue;

            var img = dependencyObject as Image;
            if (img != null)
            {
                var drawingImage = img.Source as DrawingImage;
                if (drawingImage != null)
                {
                    var geometryDrawing = drawingImage.Drawing as GeometryDrawing;
                    if (geometryDrawing != null && !geometryDrawing.IsFrozen)
                    {
                        geometryDrawing.Brush = newBrush;
                    }
                }
            }
        }
    }
}
