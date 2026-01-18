using System;
//using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace SpiroGraph
{
    public class DrawingSpec
    {
        public DrawingSpec()
        {
        }

        private string drawingName;
        private Point center;
        private string backgroundColor;

        // curves is a list of DrawingInputType structures
        private ArrayList curves = new ArrayList(20);

        public string DrawingName
        {
            get { return drawingName; }
            set { drawingName = value; }
        }

        public string BackgroundColor
        {
            get { return backgroundColor; }
            set { backgroundColor = value; }
        }

        public Point Center
        {
            get { return center; }
            set { center = value; }
        }
	
        public ArrayList Curves
        {
            get { return curves; }
        }
        
        public void saveDrawing(string fileName)
        {
            XmlSerializer x = new XmlSerializer(typeof(DrawingSpec), new Type[1] { typeof(DrawingInputType) });
            Stream s;
            try
            {
                s = File.Create(fileName);
            }
            catch (Exception)
            {
                System.Windows.Forms.MessageBox.Show("Error creating file.");
                return;
            }
            try
            {
                x.Serialize(s, this);
            }
            catch (Exception)
            {
                System.Windows.Forms.MessageBox.Show("Error saving drawing specification.");
            }
            s.Close();
        }

        public static DrawingSpec retrieveDrawing(string fileName)
        {
            DrawingSpec drawingSpec;
            XmlSerializer x = new XmlSerializer(typeof(DrawingSpec), new Type[1] { typeof(DrawingInputType) });
            FileStream s = new FileStream(fileName, FileMode.Open);
            try
            {
                drawingSpec = (DrawingSpec)x.Deserialize(s);
            }
            catch (Exception)
            {
                System.Windows.Forms.MessageBox.Show("Error loading drawing specification ... make sure the selected file was created by this program.");
                drawingSpec = new DrawingSpec();
            }
            s.Close();
            return drawingSpec;
        }

        public int UndoLastPattern()
        {
            curves.RemoveAt(curves.Count - 1);
            return curves.Count;
        }


    }

}
