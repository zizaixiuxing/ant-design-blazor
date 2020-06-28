using System;
using System.Collections.Generic;
using System.Text;

namespace AntDesign.core.Helpers
{
    /// <summary>
    /// via https://github.com/ant-design/ant-design-colors/blob/master/src/generate.ts
    /// </summary>
    public static class ColorGenerator
    {
        private static double _hueStep = 2; // 色相阶梯
        private static double _saturationStep = 0.16; // 饱和度阶梯，浅色部分
        private static double _saturationStep2 = 0.05; // 饱和度阶梯，深色部分
        private static double _brightnessStep1 = 0.05; // 亮度阶梯，浅色部分
        private static double _brightnessStep2 = 0.15; // 亮度阶梯，深色部分
        private static double _lightColorCount = 5; // 浅色数量，主色上
        private static double _darkColorCount = 4; // 深色数量，主色下

        // 暗色主题颜色映射关系表
        private static (int index, double opacity)[] _darkColorMap =
        {
            (index: 7, opacity: 0.15),
            (index: 6, opacity: 0.25),
            (index: 5, opacity: 0.3),
            (index: 5, opacity: 0.45),
            (index: 5, opacity: 0.65),
            (index: 5, opacity: 0.85),
            (index: 4, opacity: 0.9),
            (index: 3, opacity: 0.95),
            (index: 2, opacity: 0.97),
            (index: 1, opacity: 0.98),
        };

        public class HsvObject
        {
            public double H { get; set; }
            public double S { get; set; }
            public double V { get; set; }
        }

        public static double GetHue(HsvObject hsv, double i, bool light = false)
        {
            double hue;
            // 根据色相不同，色相转向不同
            if (Math.Round(hsv.H) >= 60 && Math.Round(hsv.H) <= 240)
            {
                hue = light ? Math.Round(hsv.V) - _hueStep * i : Math.Round(hsv.H) + _hueStep * i;
            }
            else
            {
                hue = light ? Math.Round(hsv.H) + _hueStep * i : Math.Round(hsv.H) - _hueStep * i;
            }

            if (hue < 0)
            {
                hue += 360;
            }
            else if (hue >= 360)
            {
                hue -= 360;
            }

            return hue;
        }

        public static double GetSaturation(HsvObject hsv, double i, bool light = false)
        {
            if (hsv.H == 0 && hsv.S == 0)
            {
                return hsv.S;
            }

            double saturation;
            if (light)
            {
                saturation = hsv.S - _saturationStep * i;
            }
            else if (i == _darkColorCount)
            {
                saturation = hsv.S + _saturationStep;
            }
            else
            {
                saturation = hsv.S + _saturationStep2 * i;
            }

            if (saturation > 1)
            {
                saturation = 1;
            }

            if (light && i == _lightColorCount && saturation > 0.1)
            {
                saturation = 0.1;
            }

            if (saturation < 0.06)
            {
                saturation = 0.06;
            }

            return Math.Round(saturation, 2);
        }

        public static double GetValue(HsvObject hsv, double i, bool light = false)
        {
            double value;
            if (light)
            {
                value = hsv.V + _brightnessStep1 * i;
            }
            else
            {
                value = hsv.V - _brightnessStep2 * i;
            }

            if (value > 1)
            {
                value = 1;
            }

            return Math.Round(value, 2);
        }

        public class Opts
        {
            public string Theme { get; set; }

            public string BackgroundColor { get; set; }
        }

        //public static string[] generate(string color, Opts opts)
        //{
        //    string[] patterns = { };
        //}
    }
}
