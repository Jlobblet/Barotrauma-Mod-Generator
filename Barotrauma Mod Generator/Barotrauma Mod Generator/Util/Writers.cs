using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Barotrauma_Mod_Generator.Util
{
    public class ControlWriter : TextWriter
    {
        private readonly Control _textbox;
        public ControlWriter(Control textbox)
        {
            _textbox = textbox;
        }

        public override void Write(char value)
        {
            _textbox.Text += value;
        }

        public override void Write(string value)
        {
            _textbox.Text += value;
        }

        public override Encoding Encoding => Encoding.ASCII;
    }

    public class MultiTextWriter : TextWriter
    {
        private readonly IEnumerable<TextWriter> _writers;
        public MultiTextWriter(IEnumerable<TextWriter> writers)
        {
            _writers = writers.ToList();
        }
        public MultiTextWriter(params TextWriter[] writers)
        {
            _writers = writers;
        }

        public override void Write(char value)
        {
            foreach (TextWriter writer in _writers)
            {
                writer.Write(value);
            }
        }

        public override void Write(string value)
        {
            foreach (TextWriter writer in _writers)
            {
                writer.Write(value);
            }
        }

        public override void Flush()
        {
            foreach (TextWriter writer in _writers)
            {
                writer.Flush();
            }
        }

        public override void Close()
        {
            foreach (TextWriter writer in _writers)
            {
                writer.Close();
            }
        }

        public override Encoding Encoding => Encoding.ASCII;
    }
}
