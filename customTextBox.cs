namespace SpiroGraph
{
    /// <summary>
    /// This class implements a version of text box in which return acts as a tab
    /// </summary>
    class customTextBox : System.Windows.Forms.TextBox
    {
        // This method intercepts the Enter Key signal before the containing Form does
        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message m, System.Windows.Forms.Keys k)
        {
            // detect the pushing of Enter Key
            if (m.Msg == 256 && k == System.Windows.Forms.Keys.Enter)
            {
                // Execute an alternative action: tab to next control
                System.Windows.Forms.SendKeys.Send("\t");
                // return true to stop any further interpretation of this key action
                return true;
            }
            // if not pushing Enter Key, then process the signal as usual
            return base.ProcessCmdKey(ref m, k);
        }
    }
}
