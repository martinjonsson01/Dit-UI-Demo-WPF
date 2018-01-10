using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;

namespace Dit_Wpf_App
{
    public static class Utils
    {
        public static Point TransformToScreen(Point point, Visual relativeTo)
        {

            HwndSource hwndSource = PresentationSource.FromVisual(relativeTo) as HwndSource;

            Visual root = hwndSource.RootVisual;

            // Translate the point from the visual to the root.

            GeneralTransform transformToRoot = relativeTo.TransformToAncestor(root);

            Point pointRoot = transformToRoot.Transform(point);

            // Transform the point from the root to client coordinates.

            Matrix m = Matrix.Identity;

            Transform transform = VisualTreeHelper.GetTransform(root);



            if (transform != null)

            {

                m = Matrix.Multiply(m, transform.Value);

            }



            Vector offset = VisualTreeHelper.GetOffset(root);

            m.Translate(offset.X, offset.Y);



            Point pointClient = m.Transform(pointRoot);

            // Convert from “device-independent pixels” into pixels.

            pointClient = hwndSource.CompositionTarget.TransformToDevice.Transform(pointClient);



            POINT pointClientPixels = new POINT();

            pointClientPixels.x = (0 < pointClient.X) ? (int)(pointClient.X + 0.5) : (int)(pointClient.X - 0.5);

            pointClientPixels.y = (0 < pointClient.Y) ? (int)(pointClient.Y + 0.5) : (int)(pointClient.Y - 0.5);



            // Transform the point into screen coordinates.

            POINT pointScreenPixels = pointClientPixels;

            ClientToScreen(hwndSource.Handle, pointScreenPixels);



            return new Point(pointScreenPixels.x, pointScreenPixels.y);

        }

        [StructLayout(LayoutKind.Sequential)]
        public class POINT

        {

            public int x = 0;

            public int y = 0;

        }

        [DllImport("User32", EntryPoint = "ClientToScreen", SetLastError = true,
            ExactSpelling = true, CharSet = CharSet.Auto)]

        private static extern int ClientToScreen(IntPtr hWnd, [In, Out] POINT pt);

        /// <summary>
        /// Gets the current mouse position on the screen.
        /// </summary>
        /// <returns></returns>
        public static Point GetMousePosition(Window window)
        {

            // Position of the mouse relative to the window
            var position = Mouse.GetPosition(window);

            // Add the window position so its a "ToScreen"
            return new Point(position.X + window.Left + 5, position.Y + window.Top + 20);
        }

    }
}
